using System;

namespace MechanaX.Video.Service {
	/// <summary>
	/// Result object for video conversion operations
	/// </summary>
	public class ConversionResult {
		public bool Success { get; private set; }
		public string OutputPath { get; private set; }
		public string ErrorMessage { get; private set; }
		public string[] Warnings { get; private set; }

		private ConversionResult() {
			Warnings = new string[0];
		}

		public static ConversionResult Ok(string outputPath) {
			return new ConversionResult {
				Success = true,
				OutputPath = outputPath
			};
		}

		public static ConversionResult Warning(string outputPath, string warning) {
			return new ConversionResult {
				Success = true,
				OutputPath = outputPath,
				Warnings = new[] { warning }
			};
		}

		public static ConversionResult Failure(string errorMessage) {
			return new ConversionResult {
				Success = false,
				ErrorMessage = errorMessage
			};
		}
	}

	/// <summary>
	/// Video information result object
	/// </summary>
	public class VideoInfo {
		public TimeSpan Duration { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
		public string VideoCodec { get; set; }
		public string AudioCodec { get; set; }
		public long FileSize { get; set; }
	}

	/// <summary>
	/// Health check result object
	/// </summary>
	public class HealthCheckResult {
		public bool FFmpegAvailable { get; set; }
		public string FFmpegVersion { get; set; }
	}

	/// <summary>
	/// Format constants for backward compatibility
	/// </summary>
	public static class Format {
		public const string mp4 = "mp4";
		public const string mov = "mov";
		public const string avi = "avi";
		public const string wmv = "wmv";
		public const string flv = "flv";
		public const string webm = "webm";
	}
}
