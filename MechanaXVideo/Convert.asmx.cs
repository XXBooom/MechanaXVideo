
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

	using System;
	using System.Web.Services;
	using System.Xml;

	/// <summary>
	/// Web service implementation for Xxxx
	/// </summary>
	[WebService(Name = "Convert",
				Namespace = "http://www.clickclickBOOM.com/MachinaX/ServiceX",  // NB: Needs to be constant accross implementations - called from cmsX.dll
																				//Namespace = "urn:Tabula.Service",	// Can be implementation based in not moved into cmsX.dll
				Description = "MachinaX Video Convert Web Service")]
	public class Convert : ConvertX {

		private const string CONFIG_ID = "mov2mp4";

		/// <summary>Constructor</summary>
		public Convert() : base("Convert", CONFIG_ID) {
		}
		public Convert(string configID) : base("Convert", configID) {
		}

		/// <summary>Convert video: .mov to .mp4</summary>
		/// <param name="SourcePath">Filepath to the source.mov</param>
		/// <param name="DestFolder">Destination folder</param>
		[WebMethod(Description = "Convert video: .mov to .mp4")]
		public XmlDocument Mov2Mp4(string SourcePath, string DestFolder) {
			xLogger.Debug("Mov2Mp4", "SourcePath", SourcePath);

			try {
				_Mov2Mp4(SourcePath, DestFolder);
				AddOk();
				AddNode("output", OutputPath);
				AddTime();

				xLogger.Debug("Mov2Mp4:ok");
			} catch (x_exception e) {
				_AddError(e);
			} catch (System.Exception e) {
				_AddError(e);
			}
			return (Result);
		}

		/// <summary>Convert video: .mov to .mp4</summary>
		/// <param name="SourcePath">Filepath to the source.mov</param>
		/// <param name="DestFolder">Destination folder</param>
		/// <param name="Format">Destination format, ie mp4, mov, avi etc</param>
		[WebMethod(Description = "Convert video")]
		public XmlDocument Video(string SourcePath, string DestFolder, string Format) {
			xLogger.Debug("Video", "SourcePath", SourcePath);

			try {
				_Convert(SourcePath, DestFolder, Format);
				AddOk();
				AddNode("output", OutputPath);
				AddTime();

				xLogger.Debug("Video:ok");
			} catch (x_exception e) {
				_AddError(e);
			} catch (System.Exception e) {
				_AddError(e);
			}
			return (Result);
		}
	}
}