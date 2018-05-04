
/*	-----------------------------------------------------------------------	
	Copyright:	clickclickBOOM cc
	Author:		Alan Benington
	Started:	2018-05-04
	Status:		release	
	Version:	4.0.3
	Build:		20180504
	License:	GNU General Public License
	-----------------------------------------------------------------------	*/

/*	-----------------------------------------------------------------------	
	Development Notes:
	==================
	Re-started from WebMaxima
	---------------------------------------------------------------------------	*/

namespace clickclickboom.machinaX.MechanaX.Video.Service {

	using NReco.VideoConverter;
	using System;
	using System.IO;
	using System.Xml;
	
	/// <summary>
	/// ConvertX extends ServiceX to implement the xxxx management functionality
	/// </summary>
	public class ConvertX : x_result {

		private const string CONFIG_ID = "default";
		private const string CONFIG_ROOT = "ConvertX";

		public string OutputPath { get; set; }
		public string OutputFolder { get; set; }
		public string ConfigID { get; set; }

		private x_config config;
		/// <summary>Generator default output file directory</summary>
		/// <value>full directory path</value>
		public x_config Config {
			get { return config; }
			set { config = value; }
		}

		private x_logger logger;
		/// <summary>Generator default output file directory</summary>
		/// <value>full directory path</value>
		public x_logger xLogger {
			get { return logger; }
			set { logger = value; }
		}

		public XmlElement Generator {
			get { return Config.Element(String.Format("{0}/Convertor[@id = '{1}']", CONFIG_ROOT, ConfigID)); }
		}

		private FFMpegConverter ffmpeg;
		protected FFMpegConverter _FFMpeg {
			get { return (ffmpeg != null) ? ffmpeg : (ffmpeg = new FFMpegConverter()); }
		}

		#region Constructors/Destructors
		/// <summary>
		/// Default constructor for the Xxxx class.
		/// </summary>
		public ConvertX(string thisid, string configID) : base(thisid) {
			ConfigID = configID;
			initialise();
		}
		/// <summary>Default constructor</summary>
		public ConvertX() : base("ConvertX") {
			ConfigID = CONFIG_ID;
			initialise();
		}
		private void initialise() {
			xLogger = new x_logger(typeof(ConvertX), ".vidx:", true, false);
			Config = new x_config();

			ResultType = x_resultType.webservice;
		}
		#endregion

		protected void _Mov2Mp4(string sourcePath, string destFolder) {
			OutputFolder = destFolder;
			//FileInfo source = new FileInfo(sourcePath);
			//OutputPath = string.Concat(destFolder, "\\", Path.GetFileNameWithoutExtension(source.Name), ".mp4");

			//_FFMpeg.ConvertMedia(sourcePath, OutputPath, Format.mp4);
			convert(sourcePath, Format.mp4);
		}

		protected void _Convert(string sourcePath, string destFolder, string format) {
			OutputFolder = destFolder;
			convert(sourcePath, format);
		}

		private void convert(string sourcePath, string format) {
			FileInfo source = new FileInfo(sourcePath);
			OutputPath = string.Format("{0}\\{1}.{2}", OutputFolder, Path.GetFileNameWithoutExtension(source.Name), format);

			_FFMpeg.ConvertMedia(sourcePath, OutputPath, format);
		}

	}
}

