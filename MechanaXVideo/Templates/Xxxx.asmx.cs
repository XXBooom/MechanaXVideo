
/*	-----------------------------------------------------------------------	
	Copyright:	clickclickBOOM cc
	Author:		Alan Benington
	Started:	2015-12-03
	Status:		release	
	Version:	4.0.3
	Build:		20151203
	License:	GNU General Public License
	-----------------------------------------------------------------------	*/

/*	-----------------------------------------------------------------------	
	Development Notes:
	==================
	Re-started from WebMaxima
	---------------------------------------------------------------------------	*/

namespace clickclickboom.machinaX.MechanaX.Rekon.Service {

	using System;
	using System.Web.Services;
	using System.Xml;

	/// <summary>
	/// Web service implementation for Xxxx
	/// </summary>
	[WebService(Name = "Xxxx",
				Namespace = "http://www.clickclickBOOM.com/MachinaX/XxxxServiceX",	// NB: Needs to be constant accross implementations - called from cmsX.dll
				//Namespace = "urn:Xxxx.Service",	// Can be implementation based in not moved into cmsX.dll
				Description = "MachinaX Xxxx Web Service")]
	public class Xxxx : XxxxX {

		#region Constants - Stored procedure names
		// Procedures for YyyyTypes
		private const string PROC_GET_YYYY_TYPE = "GetYyyyType";
		private const string PROC_LIST_YYYY_TYPE = "ListYyyyTypes";
		private const string PROC_ADD_YYYY_TYPE = "AddYyyyType";
		private const string PROC_EDIT_YYYY_TYPE = "EditYyyyType";
		private const string PROC_DEL_YYYY_TYPE = "DeleteYyyyType";
		// Procedures for ZzzzTyps
		private const string PROC_GET_ZZZZ_TYP = "GetZzzzTyp";
		private const string PROC_LIST_ZZZZ_TYP = "ListZzzzTyps";
		private const string PROC_ADD_ZZZZ_TYP = "AddZzzzTyp";
		private const string PROC_EDIT_ZZZZ_TYP = "EditZzzzTyp";
		private const string PROC_DEL_ZZZZ_TYP = "DeleteZzzzTyp";
		// Error Bases
		private const int ERROR_BASE_YYYY_TYPE = 9320;
		private const int ERROR_BASE_ZZZZ_TYP = 9340;
		#endregion

		#region Constructors/Destructors
		/// <summary>
		/// Default Constructor 
		/// </summary>
		public Xxxx() : base() {
		}
		#endregion

		#region Xxxx Web Methods
		/// <summary>Get a Xxxx</summary>
		[WebMethod(Description = "Get a Xxxx")]
		public XmlDocument GetXxxx(int XxxxID) {
			try {
				_GetXxxx(XxxxID);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("GetXxxx");
			return Result;
		}

		/// <summary>Get a list of Xxxxs</summary>
		[WebMethod(Description = "Get a list of Xxxxs")]
		public XmlDocument ListXxxxs(int TypeID, string SortCol, bool SortDesc) {
			try {
				SetList(SortCol, SortDesc);
				_ListXxxxs(TypeID);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("ListXxxx");
			return Result;
		}

		/// <summary>Get a list of Xxxxs for drop-down</summary>
		[WebMethod(Description = "Get a list of Xxxxs for drop-down")]
		public XmlDocument ListXxxxsDrop(int TypeID, string SortCol, bool SortDesc) {
			try {
				SetList(SortCol, SortDesc);
				_ListXxxxs(TypeID, true);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("ListXxxxDrop");
			return Result;
		}

		/// <summary>Get a list of Xxxxs for filter drop-down (with 'All')</summary>
		[WebMethod(Description = "Get a list of Xxxxs for drop-down (with 'All')")]
		public XmlDocument ListXxxxsFilter(int TypeID, string SortCol, bool SortDesc) {
			try {
				SetList(SortCol, SortDesc);
				_ListXxxxsFilter(TypeID);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("ListXxxxFilter");
			return Result;
		}

		/// <summary>Get a list of Xxxxs for select drop-down (with 'Please Select...')</summary>
		[WebMethod(Description = "Get a list of Xxxxs for drop-down (with 'Please Select...')")]
		public XmlDocument ListXxxxsSelect(int TypeID, string SortCol, bool SortDesc) {
			try {
				SetList(SortCol, SortDesc);
				_ListXxxxsSelect(TypeID);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("ListXxxxSelect");
			return Result;
		}

		/// <summary>Get a sorted, filtered, paginated list of Xxxxs</summary>
		[WebMethod(Description = "Get a sorted, filtered, paginated list of Customer")]
		public XmlDocument IndexXxxxs(int TypeID, int StartPage, string SortCol, bool SortDesc, int Rows) {
			try {
				SetList(StartPage, Rows, SortCol, SortDesc);
				_IndexXxxxs(TypeID);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("IndexXxxx");
			return Result;
		}

		/// <summary>Get a list of series from a search</summary>
		[WebMethod(Description = "Get a list of series from a search")]
		public XmlDocument SearchXxxxs(int TypeID
			, int FirstnameType, string Firstname
			, int SurnameType, string Surname
			, int UsernameType, string Username
			, int EmailType, string Email
			, int TelephoneType, string Telephone
			, int CellphoneType, string Cellphone
			, int StartPage, string SortCol, bool SortDesc, int Rows
		) {
			try {
				SetList(StartPage, Rows, SortCol, SortDesc);
				_SearchXxxxs(TypeID
					, FirstnameType, Firstname
					, SurnameType, Surname
					, UsernameType, Username
					, EmailType, Email
					, TelephoneType, Telephone
					, CellphoneType, Cellphone
				);
			} catch (Exception e) {
				_AddError(e);
			}
			LogResult("SearchXxxx");
			return Result;
		}

		/// <summary>Add a new Xxxx</summary>
		[WebMethod(Description = "Add a new Xxxx")]
		public XmlDocument NewXxxx(int TypeID
			, DateTime StartDate
			, string Gender
		) {
			try {
				_NewXxxx(TypeID, StartDate, Gender);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("NewXxxx");
			return Result;
		}

		/// <summary>Update a Xxxx</summary>
		[WebMethod(Description = "Update a Xxxx")]
		public XmlDocument UpdateXxxx(int XxxxID
			, int TypeID
			, DateTime BirthDate
			, string Gender
			, DateTime StartDate
		) {
			try {
				_EditXxxx(XxxxID, TypeID, BirthDate, Gender, StartDate);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("UpdateXxxx");
			return Result;
		}

		/// <summary>Remove a Xxxx</summary>													 
		[WebMethod(Description = "Remove a Xxxx")]
		public XmlDocument RemoveXxxx(int XxxxID) {
			try {
				_DeleteXxxx(XxxxID);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("RemoveXxxx");
			return Result;
		}

		#endregion

		#region Yyyy Web Methods
		/// <summary>Get a Yyyy</summary>
		[WebMethod(Description = "Get a Yyyy")]
		public XmlDocument GetYyyy(int YyyyID) {
			try {
				_GetYyyy(YyyyID);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("GetYyyy");
			return Result;
		}

		/// <summary>Get a list of Yyyys</summary>
		[WebMethod(Description = "Get a list of Yyyys")]
		public XmlDocument ListYyyys(int TypeID, string SortCol, bool SortDesc) {
			try {
				SetList(SortCol, SortDesc);
				_ListYyyys(TypeID);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("ListYyyy");
			return Result;
		}

		/// <summary>Get a list of Yyyys for drop-down</summary>
		[WebMethod(Description = "Get a list of Yyyys for drop-down")]
		public XmlDocument ListYyyysDrop(int TypeID, string SortCol, bool SortDesc) {
			try {
				SetList(SortCol, SortDesc);
				_ListYyyys(TypeID, true);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("ListYyyyDrop");
			return Result;
		}

		/// <summary>Get a list of Yyyys for select drop-down</summary>
		[WebMethod(Description = "Get a list of Yyyys for select drop-down")]
		public XmlDocument ListYyyysSelect(int TypeID, string SortCol, bool SortDesc) {
			try {
				SetList(SortCol, SortDesc);
				_ListYyyysSelect(TypeID);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("ListYyyySelect");
			return Result;
		}

		/// <summary>Get a list of Yyyys for filter drop-down (with 'All')</summary>
		[WebMethod(Description = "Get a list of Yyyys for filter drop-down (with 'All')")]
		public XmlDocument ListYyyysFilter(int TypeID, string SortCol, bool SortDesc) {
			try {
				SetList(SortCol, SortDesc);
				_ListYyyysFilter(TypeID);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("ListYyyyFilter");
			return Result;
		}

		/// <summary>Add a new Yyyy</summary>
		[WebMethod(Description = "Add a new Yyyy")]
		public XmlDocument NewYyyy(string Name
			, string Note
			, string Desc
		) {
			try {
				_NewYyyy(Name, Note, Desc);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("NewYyyy");
			return Result;
		}

		/// <summary>Update a Yyyy</summary>
		[WebMethod(Description = "Update a Yyyy")]
		public XmlDocument UpdateYyyy(int YyyyID
			, string Name
			, string Note
			, string Desc
		) {
			try {
				_EditYyyy(YyyyID, Name, Note, Desc);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("UpdateYyyy");
			return Result;
		}

		/// <summary>Remove a Yyyy</summary>													 
		[WebMethod(Description = "Remove a Yyyy")]
		public XmlDocument RemoveYyyy(int YyyyID) {
			try {
				_DeleteYyyy(YyyyID);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("RemoveYyyy");
			return Result;
		}

		#endregion

		#region YyyyType Web Methods
		/// <summary>Get a YyyyType</summary>
		[WebMethod(Description = "Get a YyyyType")]
		public XmlDocument GetYyyyType(int YyyyTypeID) {
			try {
				ErrorBase = ERROR_BASE_YYYY_TYPE;
				_GetType(PROC_GET_YYYY_TYPE, YyyyTypeID);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("GetYyyyType");
			return Result;
		}

		/// <summary>Get a list of YyyyTypes</summary>
		[WebMethod(Description = "Get a list of YyyyTypes")]
		public XmlDocument ListYyyyTypes(int TypeID, string SortCol, bool SortDesc) {
			try {
				ErrorBase = ERROR_BASE_YYYY_TYPE;
				SetList(SortCol, SortDesc);
				_ListTypes(PROC_LIST_YYYY_TYPE);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("ListYyyyType");
			return Result;
		}

		/// <summary>Get a list of YyyyTypes for drop-down</summary>
		[WebMethod(Description = "Get a list of YyyyTypes for drop-down")]
		public XmlDocument ListYyyyTypesDrop(int TypeID, string SortCol, bool SortDesc) {
			try {
				ErrorBase = ERROR_BASE_YYYY_TYPE;
				SetList(SortCol, SortDesc);
				_ListTypes(PROC_LIST_YYYY_TYPE, true);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("ListYyyyTypeDrop");
			return Result;
		}

		/// <summary>Get a list of YyyyTypes for select drop-down</summary>
		[WebMethod(Description = "Get a list of YyyyTypes for select drop-down")]
		public XmlDocument ListYyyyTypesSelect(int TypeID, string SortCol, bool SortDesc) {
			try {
				ErrorBase = ERROR_BASE_YYYY_TYPE;
				SetList(SortCol, SortDesc);
				_ListTypesSelect(PROC_LIST_YYYY_TYPE);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("ListYyyyTypeSelect");
			return Result;
		}

		/// <summary>Get a list of YyyyTypes for filter drop-down (with 'All')</summary>
		[WebMethod(Description = "Get a list of YyyyTypes for filter drop-down (with 'All')")]
		public XmlDocument ListYyyyTypesFilter(int TypeID, string SortCol, bool SortDesc) {
			try {
				ErrorBase = ERROR_BASE_YYYY_TYPE;
				SetList(SortCol, SortDesc);
				_ListTypesFilter(PROC_LIST_YYYY_TYPE);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("ListYyyyTypeFilter");
			return Result;
		}

		/// <summary>Add a new YyyyType</summary>
		[WebMethod(Description = "Add a new YyyyType")]
		public XmlDocument NewYyyyType(string Name, string Note, string Desc) {
			try {
				ErrorBase = ERROR_BASE_YYYY_TYPE;
				_NewType(PROC_ADD_YYYY_TYPE, Name, Note, Desc);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("NewYyyyType");
			return Result;
		}

		/// <summary>Update a YyyyType</summary>
		[WebMethod(Description = "Update a YyyyType")]
		public XmlDocument UpdateYyyyType(int YyyyTypeID, string Name, string Note, string Desc) {
			try {
				ErrorBase = ERROR_BASE_YYYY_TYPE;
				_EditType(PROC_EDIT_YYYY_TYPE, YyyyTypeID, Name, Note, Desc);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("UpdateYyyyType");
			return Result;
		}

		/// <summary>Remove a YyyyType</summary>													 
		[WebMethod(Description = "Remove a YyyyType")]
		public XmlDocument RemoveYyyyType(int YyyyTypeID) {
			try {
				ErrorBase = ERROR_BASE_YYYY_TYPE;
				_DeleteType(PROC_DEL_YYYY_TYPE, YyyyTypeID);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("RemoveYyyyType");
			return Result;
		}

		#endregion

		#region Zzzz Web Methods
		/// <summary>Get a Zzzz</summary>
		[WebMethod(Description = "Get a Zzzz")]
		public XmlDocument GetZzzz(int ZzzzID) {
			try {
				_GetZzzz(ZzzzID);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("GetZzzz");
			return Result;
		}

		/// <summary>Get a list of Zzzzs</summary>
		[WebMethod(Description = "Get a list of Zzzzs")]
		public XmlDocument ListZzzzs(string SortCol, bool SortDesc) {
			try {
				SetList(SortCol, SortDesc);
				_ListZzzzs();
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("ListZzzz");
			return Result;
		}

		/// <summary>Get a list of Zzzzs for drop-down</summary>
		[WebMethod(Description = "Get a list of Zzzzs for drop-down")]
		public XmlDocument ListZzzzsDrop(string SortCol, bool SortDesc) {
			try {
				SetList(SortCol, SortDesc);
				_ListZzzzs(true);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("ListZzzzDrop");
			return Result;
		}

		/// <summary>Get a list of Zzzzs for select drop-down</summary>
		[WebMethod(Description = "Get a list of Zzzzs for select drop-down")]
		public XmlDocument ListZzzzsSelect(string SortCol, bool SortDesc) {
			try {
				SetList(SortCol, SortDesc);
				_ListZzzzsSelect();
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("ListZzzzSelect");
			return Result;
		}

		/// <summary>Get a list of Zzzzs for filter drop-down (with 'All')</summary>
		[WebMethod(Description = "Get a list of Zzzzs for filter drop-down (with 'All')")]
		public XmlDocument ListZzzzsFilter(string SortCol, bool SortDesc) {
			try {
				SetList(SortCol, SortDesc);
				_ListZzzzsFilter();
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("ListZzzzFilter");
			return Result;
		}

		/// <summary>Add a new Zzzz</summary>
		[WebMethod(Description = "Add a new Zzzz")]
		public XmlDocument NewZzzz(string Name, string Note) {
			try {
				_NewZzzz(Name, Note);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("NewZzzz");
			return Result;
		}

		/// <summary>Update a Zzzz</summary>
		[WebMethod(Description = "Update a Zzzz")]
		public XmlDocument UpdateZzzz(int ZzzzID, string Name, string Note) {
			try {
				_EditZzzz(ZzzzID, Name, Note);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("UpdateZzzz");
			return Result;
		}

		/// <summary>Remove a Zzzz</summary>													 
		[WebMethod(Description = "Remove a Zzzz")]
		public XmlDocument RemoveZzzz(int ZzzzID) {
			try {
				_DeleteZzzz(ZzzzID);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("RemoveZzzz");
			return Result;
		}

		#endregion

		#region ZzzzTyp Web Methods
		/// <summary>Get a ZzzzTyp</summary>
		[WebMethod(Description = "Get a ZzzzTyp")]
		public XmlDocument GetZzzzTyp(int ZzzzTypID) {
			try {
				ErrorBase = ERROR_BASE_ZZZZ_TYP;
				_GetTyp(PROC_GET_ZZZZ_TYP, ZzzzTypID);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("GetZzzzTyp");
			return Result;
		}

		/// <summary>Get a list of ZzzzTyps</summary>
		[WebMethod(Description = "Get a list of ZzzzTyps")]
		public XmlDocument ListZzzzTyps(string SortCol, bool SortDesc) {
			try {
				SetList(SortCol, SortDesc);
				ErrorBase = ERROR_BASE_ZZZZ_TYP;
				_ListTyps(PROC_LIST_ZZZZ_TYP);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("ListZzzzTyp");
			return Result;
		}

		/// <summary>Get a list of ZzzzTyps for drop-down</summary>
		[WebMethod(Description = "Get a list of ZzzzTyps for drop-down")]
		public XmlDocument ListZzzzTypsDrop(string SortCol, bool SortDesc) {
			try {
				SetList(SortCol, SortDesc);
				ErrorBase = ERROR_BASE_ZZZZ_TYP;
				_ListTyps(PROC_LIST_ZZZZ_TYP, true);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("ListZzzzTypDrop");
			return Result;
		}

		/// <summary>Get a list of ZzzzTyps for select drop-down</summary>
		[WebMethod(Description = "Get a list of ZzzzTyps for select drop-down")]
		public XmlDocument ListZzzzTypsSelect(string SortCol, bool SortDesc) {
			try {
				SetList(SortCol, SortDesc);
				ErrorBase = ERROR_BASE_ZZZZ_TYP;
				_ListTypsSelect(PROC_LIST_ZZZZ_TYP);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("ListZzzzTypSelect");
			return Result;
		}

		/// <summary>Get a list of ZzzzTyps for filter drop-down (with 'All')</summary>
		[WebMethod(Description = "Get a list of ZzzzTyps for filter drop-down (with 'All')")]
		public XmlDocument ListZzzzTypsFilter(string SortCol, bool SortDesc) {
			try {
				SetList(SortCol, SortDesc);
				ErrorBase = ERROR_BASE_ZZZZ_TYP;
				_ListTypsFilter(PROC_LIST_ZZZZ_TYP);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("ListZzzzTypFilter");
			return Result;
		}

		/// <summary>Add a new ZzzzTyp</summary>
		[WebMethod(Description = "Add a new ZzzzTyp")]
		public XmlDocument NewZzzzTyp(string Name, string Note) {
			try {
				ErrorBase = ERROR_BASE_ZZZZ_TYP;
				_NewTyp(PROC_ADD_ZZZZ_TYP, Name, Note);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("NewZzzzTyp");
			return Result;
		}

		/// <summary>Update a ZzzzTyp</summary>
		[WebMethod(Description = "Update a ZzzzTyp")]
		public XmlDocument UpdateZzzzTyp(int ZzzzTypID, string Name, string Note) {
			try {
				ErrorBase = ERROR_BASE_ZZZZ_TYP;
				_EditTyp(PROC_ADD_ZZZZ_TYP, ZzzzTypID, Name, Note);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("UpdateZzzzTyp");
			return Result;
		}

		/// <summary>Remove a ZzzzTyp</summary>													 
		[WebMethod(Description = "Remove a ZzzzTyp")]
		public XmlDocument RemoveZzzzTyp(int ZzzzTypID) {
			try {
				ErrorBase = ERROR_BASE_ZZZZ_TYP;
				_DeleteTyp(PROC_GET_ZZZZ_TYP, ZzzzTypID);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("RemoveZzzzTyp");
			return Result;
		}

		#endregion
	}
}