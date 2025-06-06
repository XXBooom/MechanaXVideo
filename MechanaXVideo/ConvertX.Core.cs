using FFMpegCore;
using FFMpegCore.Enums;
using System;
using System.IO;
using System.Xml;
using System.Threading.Tasks;
using XXBoom.MachinaX;

namespace MechanaX.Video.Service {

    /// <summary>
    /// ConvertXCore extends ServiceX to implement the video conversion functionality using FFMpegCore
    /// </summary>
    public class ConvertXCore : ConvertX {

        #region Constructors/Destructors
        /// <summary>
        /// Constructor for the ConvertXCore class.
        /// </summary>
        public ConvertXCore(string thisid, string configID) : base(thisid, configID) {
        }
        /// <summary>Default constructor</summary>
        public ConvertXCore() : base() {
        }
        #endregion

        protected void _Mov2Mp4Core(string sourcePath, string destFolder) {
            OutputFolder = destFolder;
            convert(sourcePath, Format.mp4);
        }

        protected void _Convert2FolderCore(string sourcePath, string destFolder, string format) {
            OutputFolder = destFolder;
            convert(sourcePath, format);
        }

        protected void _ConvertCore(string sourcePath, string outputPath) {
			_ConvertCore(sourcePath, outputPath, Format.mp4);
        }

        protected void _ConvertCore(string sourcePath, string outputPath, string format) {
            OutputPath = outputPath;
            
            try {
                // Use Task.Run to handle async in sync context (legacy SOAP constraint)
                var conversionTask = Task.Run(async () => await ConvertVideoAsync(sourcePath, outputPath, format));
                conversionTask.Wait(); // Block until completion
                
                if (!conversionTask.Result.Success) {
                    throw new Exception($"Video conversion failed: {conversionTask.Result.ErrorMessage}");
                }
            }
            catch (AggregateException ex) {
                // Unwrap the inner exception from Task.Wait()
                throw ex.InnerException ?? ex;
            }
        }

        private void convert(string sourcePath, string outputFormat) {
            FileInfo source = new FileInfo(sourcePath);
            OutputPath = string.Format("{0}\\{1}.{2}", OutputFolder, Path.GetFileNameWithoutExtension(source.Name), outputFormat);

            try {
                // Use Task.Run to handle async in sync context
                var conversionTask = Task.Run(async () => await ConvertVideoAsync(sourcePath, OutputPath, outputFormat));
                conversionTask.Wait();
                
                if (!conversionTask.Result.Success) {
                    throw new Exception($"Video conversion failed: {conversionTask.Result.ErrorMessage}");
                }
            }
            catch (AggregateException ex) {
                throw ex.InnerException ?? ex;
            }
        }

        /// <summary>
        /// Core conversion method using FFMpegCore with reliability optimizations
        /// </summary>
        private async Task<ConversionResult> ConvertVideoAsync(string sourcePath, string outputPath, string format) {
            try {
                xLogger.Debug("ConvertVideoAsync", "Starting conversion", $"Source: {sourcePath}, Output: {outputPath}, Format: {format}");

                // Pre-conversion validation
                if (!File.Exists(sourcePath)) {
                    return ConversionResult.Failure("Source file does not exist");
                }

                var inputAnalysis = await FFProbe.AnalyseAsync(sourcePath);
                if (inputAnalysis.Duration == TimeSpan.Zero) {
                    return ConversionResult.Failure("Invalid input file - no duration detected");
                }

                xLogger.Debug("ConvertVideoAsync", "Input analysis", $"Duration: {inputAnalysis.Duration}, Video streams: {inputAnalysis.VideoStreams.Count}, Audio streams: {inputAnalysis.AudioStreams.Count}");

                // Ensure output directory exists
                var outputDir = Path.GetDirectoryName(outputPath);
                if (!Directory.Exists(outputDir)) {
                    Directory.CreateDirectory(outputDir);
                }

                // Build conversion arguments with reliability settings
                var conversion = FFMpegArguments
                    .FromFileInput(sourcePath)
                    .OutputToFile(outputPath, overwrite: true, options => BuildConversionOptions(options, format));

                // Execute conversion
                var success = await conversion.ProcessAsynchronously(throwOnError: false);

                if (!success) {
                    return ConversionResult.Failure("FFmpeg process returned failure status");
                }

                // Post-conversion validation
                if (!File.Exists(outputPath)) {
                    return ConversionResult.Failure("Output file was not created");
                }

                var outputAnalysis = await FFProbe.AnalyseAsync(outputPath);
                if (outputAnalysis.Duration == TimeSpan.Zero) {
                    File.Delete(outputPath);
                    return ConversionResult.Failure("Conversion produced invalid output");
                }

                // Verify duration matches (within 2 second tolerance for reliability)
                var durationDiff = Math.Abs((inputAnalysis.Duration - outputAnalysis.Duration).TotalSeconds);
                if (durationDiff > 2.0) {
                    xLogger.Info("ConvertVideoAsync", "Duration mismatch", $"Input: {inputAnalysis.Duration}, Output: {outputAnalysis.Duration}, Diff: {durationDiff}s");
                    return ConversionResult.Warning(outputPath, $"Duration mismatch detected: {durationDiff:F1} seconds difference");
                }

                xLogger.Debug("ConvertVideoAsync", "Conversion successful", $"Output: {outputPath}, Duration: {outputAnalysis.Duration}");
                return ConversionResult.Ok(outputPath);
            }
            catch (Exception ex) {
                xLogger.Info("ConvertVideoAsync", "Conversion failed", ex.Message);
                return ConversionResult.Failure($"Conversion failed: {ex.Message}");
            }
        }

        /// <summary>
        /// Build FFmpeg conversion options optimized for browser compatibility and reliability
        /// </summary>
        private FFMpegArgumentOptions BuildConversionOptions(FFMpegArgumentOptions options, string format) {
            return options
                // Video codec settings for maximum browser compatibility
                .WithVideoCodec(VideoCodec.LibX264)
                .WithConstantRateFactor(23) // Good quality/size balance
                .ForcePixelFormat("yuv420p") // Required for browser compatibility
                .WithCustomArgument("-profile:v baseline") // Most compatible H.264 profile
				.WithCustomArgument("-level 4.0") // Supports up to 1080p reliably

				// Audio settings
				.WithAudioCodec(AudioCodec.Aac)
                .WithAudioBitrate(128)
                .WithAudioSamplingRate(44100)

                // Container optimizations for web playback
                .WithFastStart() // Enable progressive download
                .WithCustomArgument("-movflags +faststart") // Backup flag for older FFmpeg
                
                // Reliability and sync fixes
                .WithCustomArgument("-max_muxing_queue_size 1024") // Prevents audio/video desync
                .WithCustomArgument("-avoid_negative_ts make_zero") // Fix timestamp issues
                .WithCustomArgument("-fflags +genpts") // Generate missing timestamps
                .WithCustomArgument("-strict experimental") // Allow experimental codecs if needed
                
                // Error recovery options
                .WithCustomArgument("-err_detect ignore_err") // Continue on minor errors
                .WithCustomArgument("-ignore_unknown"); // Ignore unknown streams
        }
    }

}