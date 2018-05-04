
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
	[WebService(Name = "Yyyy",
				Namespace = "http://www.clickclickBOOM.com/MachinaX/ServiceX",	// NB: Needs to be constant accross implementations - called from cmsX.dll
				//Namespace = "urn:Tabula.Service",	// Can be implementation based in not moved into cmsX.dll
				Description = "MachinaX Yyyy Web Service")]
	public class Yyyy : YyyyX {

		#region Invisible properties
		#endregion

		#region Visible properties
		#endregion

		#region private methods
		#endregion

		#region Constructors/Destructors
		/// <summary>
		/// Default Constructor 
		/// </summary>
		public Yyyy() : base() {
		}
		#endregion

		#region Xxxx Web Methods
		/// <summary>Get a Xxxx</summary>
		[WebMethod(Description = "Get a Xxxx")]
		public XmlDocument Get(int XxxxID) {
			try {
				_Get(XxxxID);
				//ChangeDataRoot("item", "defaults");
				//_GetDefaults(ClientID, XxxxID, true);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("GetXxxx");
			return Result;
		}

		/// <summary>Get a Client's Xxxx</summary>
		[WebMethod(Description = "Get a Client's Xxxx")]
		public XmlDocument GetClientXxxx(int ClientID, string XxxxUID) {
			try {
				_Get(ClientID, XxxxUID);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("GetClientXxxx");
			return Result;
		}

		/// <summary>Get a Xxxx (+ Person data)</summary>
		[WebMethod(Description = "Get a Xxxx (+ Person data)")]
		public XmlDocument GetXxxx(int XxxxID) {
			try {
				_GetXxxx(XxxxID);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("GetXxxx");
			return Result;
		}

		/// <summary>Get a list of all Xxxx</summary>
		[WebMethod(Description = "Get a list of all Xxxx")]
		public XmlDocument ListXxxxsAll(int ClientID, string SortCol, bool SortDesc) {
			try {
				SetList(SortCol, SortDesc);
				_List(ClientID);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("ListXxxx");
			return Result;
		}

		/// <summary>Get a list of all Xxxx</summary>
		[WebMethod(Description = "Get a list of all Xxxx for drop-down")]
		public XmlDocument ListXxxxsDrop(int ClientID, string SortCol, bool SortDesc) {
			try {
				SetList(SortCol, SortDesc);
				_List(ClientID, true, "", "");
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("ListXxxxDrop");
			return Result;
		}

		/// <summary>Get a sorted, filtered, paginated list of Xxxx</summary>
		[WebMethod(Description = "Get a sorted, filtered, paginated list of Xxxx")]
		public XmlDocument List(int ClientID, int StartPage, string SortCol, bool SortDesc, int Rows) {
			try {
				SetList(StartPage, Rows, SortCol, SortDesc);
				_List(ClientID);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("ListXxxx");
			return Result;
		}

		/// <summary>Get a list of Xxxxs from a search</summary>
		[WebMethod(Description = "Get a list of Xxxxs from a search")]
		public XmlDocument Search(
			  int FirstnameType, string Firstname
			, int SurnameType, string Surname
			, int UsernameType, string Username
			, int EmailType, string Email
			, int TelephoneType, string Telephone
			, int CellphoneType, string Cellphone
			, int StartPage, string SortCol, bool SortDesc, int Rows
		) {
			try {
				SetList(StartPage, Rows, SortCol, SortDesc);
				_Search(
					  FirstnameType, Firstname
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
		public XmlDocument New(int PersonID
			, DateTime BirthDate
			, string Gender
			, DateTime StartDate
		) {
			try {
				_New(PersonID, BirthDate, Gender, StartDate);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("NewXxxx");
			return Result;
		}

		/// <summary>Update a Xxxx</summary>
		[WebMethod(Description = "Update a Xxxx")]
		public XmlDocument Update(int XxxxID
			, int PersonID
			, DateTime BirthDate
			, string Gender
			, DateTime StartDate
		) {
			try {
				_Edit(XxxxID, PersonID, BirthDate, Gender, StartDate);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("UpdateXxxx");
			return Result;
		}

		/// <summary>Remove a Xxxx</summary>													 
		[WebMethod(Description = "Remove a Xxxx")]											 
		public XmlDocument Remove(int XxxxID) {
			try {
				_Delete(XxxxID);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("RemoveXxxx");
			return Result;
		}
		
		#endregion

		#region Xxxx Default Web Methods
		/// <summary>Get a Xxxx's Defaults</summary>
		[WebMethod(Description = "Get a Xxxx's Defaults")]
		public XmlDocument GetDefaults(int ClientID, int XxxxID) {
			try {
				_GetDefaults(ClientID, XxxxID, false);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("GetDefaults");
			return Result;
		}

		/// <summary>Lists a Xxxx's Defaults</summary>
		[WebMethod(Description = "Lists a Xxxx's Defaults")]
		public XmlDocument ListDefaults(int ClientID, int XxxxID) {
			try {
				_GetDefaults(ClientID, XxxxID, true);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("ListDefaults");
			return Result;
		}

		/// <summary>Update a Xxxx Default</summary>
		[WebMethod(Description = "Update a Xxxx Default")]
		public XmlDocument UpdateDefault(int ClientID, int XxxxID, int TypeID, string Value) {
			try {
				_EditDefault(ClientID, XxxxID, TypeID, Value);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("UpdateDefault");
			return Result;
		}
		
		/// <summary>Remove a Xxxx Default</summary>													 
		[WebMethod(Description = "Remove a Xxxx Default")]
		public XmlDocument RemoveDefault(int XxxxID, int TypeID) {
			try {
				_DeleteDefault(XxxxID, TypeID);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("RemoveDefault");
			return Result;
		}
		#endregion

		#region Xxxx Yyyy Web Methods
		/// <summary>List a Xxxx's Yyyys</summary>
		[WebMethod(Description = "List a Xxxx's Yyyys")]
		public XmlDocument ListYyyys(int XxxxID) {
			try {
				_ListYyyys(XxxxID);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("ListYyyys");
			return Result;
		}

		/// <summary>Add a new Xxxx</summary>
		[WebMethod(Description = "Add a new Xxxx Yyyy")]
		public XmlDocument NewYyyy(int XxxxID
			, int YyyyID
			, decimal Credit
			, decimal Percent
		) {
			try {
				_NewYyyy(XxxxID, YyyyID, Credit, Percent);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("NewYyyy");
			return Result;
		}

		/// <summary>Remove a Xxxx Yyyy</summary>													 
		[WebMethod(Description = "Remove a Xxxx Yyyy")]
		public XmlDocument RemoveYyyy(int XxxxID, int YyyyID) {
			try {
				_DeleteYyyy(XxxxID, YyyyID);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("RemoveYyyy");
			return Result;
		}

		/// <summary>Remove all Xxxx Yyyys</summary>													 
		[WebMethod(Description = "Remove all Xxxx Yyyys")]
		public XmlDocument RemoveYyyys(int XxxxID) {
			try {
				_DeleteYyyys(XxxxID);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("RemoveYyyys");
			return Result;
		}
		#endregion

		#region Xxxx Service Web Methods
		/// <summary>List a Xxxx's Services</summary>
		[WebMethod(Description = "List a Xxxx's Services")]
		public XmlDocument ListServices(int XxxxID) {
			try {
				_ListServices(XxxxID);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("ListServices");
			return Result;
		}

		/// <summary>Add a new Xxxx</summary>
		[WebMethod(Description = "Add a new Xxxx Service")]
		public XmlDocument NewService(int XxxxID
			, int ServiceID
			, string Frequency
			, decimal Premium
			, bool IsPremium
			, decimal Credit
			, DateTime StartDate
			, bool InYyyy
		) {
			try {
				_NewService(XxxxID, ServiceID, Frequency, Premium, IsPremium, Credit, StartDate, InYyyy);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("NewService");
			return Result;
		}

		/// <summary>Remove a Xxxx Service</summary>													 
		[WebMethod(Description = "Remove a Xxxx Service")]
		public XmlDocument RemoveService(int XxxxID, int YyyyID) {
			try {
				_DeleteService(XxxxID, YyyyID);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("RemoveService");
			return Result;
		}

		/// <summary>Remove all Xxxx Services</summary>													 
		[WebMethod(Description = "Remove all Xxxx Services")]
		public XmlDocument RemoveServices(int XxxxID) {
			try {
				_DeleteServices(XxxxID);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("RemoveServices");
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

		/// <summary>Add a new Zzzz</summary>
		[WebMethod(Description = "Add a new Zzzz")]
		public XmlDocument NewZzzz(string UID
			, string StaffID
			, int ClientID
			//, int XxxxID
		) {
			try {
				_NewZzzz(UID, StaffID, ClientID);
			} catch (Exception e) {
				AddError(e);
			}
			LogResult("NewZzzz");
			return Result;
		}

		/// <summary>Update a Zzzz</summary>
		[WebMethod(Description = "Update a Zzzz")]
		public XmlDocument UpdateZzzz(int ZzzzID
			, string UID
			, string StaffID
			, int ClientID
			, int XxxxID
		) {
			try {
				_EditZzzz(ZzzzID, UID, StaffID, ClientID, XxxxID);
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
	}
}