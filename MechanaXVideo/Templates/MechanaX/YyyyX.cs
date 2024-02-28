using System;
using System.Data;
using System.Xml;
using XXBoom.MachinaX.ServiceX;

namespace MechanaX.Video.Service {
	
	/// <summary>
	/// YyyyX extends ServiceX to implement the xxxx management functionality
	/// </summary>
	public class YyyyX : ServiceX {
		#region Properties
		#endregion

		#region Constants
		#endregion

		#region Constants - Stored procedure names
		// Procedures for Xxxxs
		private const string PROC_GET_XXXX = "GetXxxx";
		private const string PROC_GET_XXXX_PERSON = "GetXxxxPerson";
		private const string PROC_GET_XXXX_CLIENT = "GetClientXxxx";
		private const string PROC_LIST_XXXX = "ListXxxxs";
		private const string PROC_INDEX_XXXX = "IndexXxxxs";
		private const string PROC_SEARCH_XXXX = "SearchXxxxs";
		private const string PROC_ADD_XXXX = "AddXxxx";
		private const string PROC_EDIT_XXXX = "EditXxxx";
		private const string PROC_DEL_XXXX = "DeleteXxxx";
		// Procedures for Xxxx Defaults
		private const string PROC_GET_XXXX_DEFAULTS = "GetXxxxDefaults";
		private const string PROC_EDIT_XXXX_DEFAULT = "UpdateXxxxDefault";
		private const string PROC_DEL_XXXX_DEFAULT = "DeleteXxxxDefault";
		// Procedures for Xxxx Yyyys
		private const string PROC_LIST_XXXX_YYYYS = "ListXxxxYyyys";
		private const string PROC_ADD_XXXX_YYYYS = "AddXxxxYyyy";
		private const string PROC_DEL_XXXX_YYYY = "DeleteXxxxYyyy";
		private const string PROC_DEL_XXXX_YYYYS = "DeleteXxxxYyyys";
		// Procedures for Xxxx Services
		private const string PROC_LIST_XXXX_SERVICES = "ListXxxxServices";
		private const string PROC_ADD_XXXX_SERVICES = "AddXxxxService";
		private const string PROC_DEL_XXXX_SERVICE = "DeleteXxxxService";
		private const string PROC_DEL_XXXX_SERVICES = "DeleteXxxxServices";
		// Procedures for Zzzzs
		private const string PROC_GET_ZZZZ = "GetZzzz";
		private const string PROC_ADD_ZZZZ = "AddZzzz";
		private const string PROC_EDIT_ZZZZ = "EditZzzz";
		private const string PROC_DEL_ZZZZ = "DeleteZzzz";
		// Error Bases
		private new const int ERROR_BASE = 9300;
		private const int ERROR_DEFAULT_BASE = 9310;
		private const int ERROR_YYYY_BASE = 9320;
		private const int ERROR_SERVICE_BASE = 9330;
		#endregion

		#region Constructors/Destructors
		/// <summary>
		/// Default constructor for the Xxxx class.
		/// </summary>
		public YyyyX() : base("YyyyX", "FoundationX") {
		}
		#endregion

		#region Xxxx methods
		/// <summary>
		/// Gets details of a Xxxx.
		/// </summary>
		/// <returns>
		/// XmlDocument
		/// </returns>
		protected void _Get(int XxxxID) {
			using (Connect()) {
				try {
					using (Command(PROC_GET_XXXX)) {
						AddSQLParameter(XxxxID, "XxxxID");
						using (Reader()) {
							if (Read()) {
								xxxxXml(AddItem());
							}
						}
					}
				} catch (Exception exc) {
					_AddError(ERROR_BASE, ERROR_GET, exc);
				}
			}
		}

		/// <summary>
		/// Gets details of a Xxxx.
		/// </summary>
		/// <returns>
		/// XmlDocument
		/// </returns>
		protected void _Get(int ClientID, string XxxxUID) {
			using (Connect()) {
				try {
					using (Command(PROC_GET_XXXX_CLIENT)) {
						AddSQLParameter(ClientID, "ClientID");
						AddSQLParameter(XxxxUID, "XxxxUID", 100);
						using (Reader()) {
							if (Read()) {
								xxxxXml(AddItem());
							}
						}
					}
				} catch (Exception exc) {
					_AddError(ERROR_BASE, ERROR_GET, exc);
				}
			}
		}

		/// <summary>
		/// Gets details of a Xxxx.
		/// </summary>
		/// <returns>
		/// XmlDocument
		/// </returns>
		protected void _GetXxxx(int XxxxID) {
			using (Connect()) {
				try {
					using (Command(PROC_GET_XXXX_PERSON)) {
						AddSQLParameter(XxxxID, "XxxxID");
						using (Reader()) {
							if (Read()) {
								xxxxXml(AddItem(), false, false);
							}
						}
					}
				} catch (Exception exc) {
					_AddError(ERROR_BASE, ERROR_GET, exc);
				}
			}
		}

		/// <summary>
		/// List Xxxx.
		/// </summary>
		/// <returns>
		/// XmlDocument
		/// </returns>
		protected void _List(int ClientID, bool IsDrop, string DateStart, string DateEnd) {
			using (Connect()) {
				try {
					using (Command(PROC_LIST_XXXX)) {
						AddSQLParameter(ClientID, "ClientID");
						AddSort();
						using (Reader()) {
							while (Read()) {
								if (IsDrop) {
									xxxxXmlDrop(AddItem());
								} else {
									xxxxXml(AddItem());
								}
							}
						}
					}
				} catch (Exception exc) {
					_AddError(ERROR_BASE, ERROR_LIST, exc);
				}
			}
		}

		/// <summary>
		/// List Xxxx.
		/// </summary>
		/// <returns>
		/// XmlDocument
		/// </returns>
		protected void _List(int ClientID) {
			using (Connect()) {
				try {
					using (Command(PROC_INDEX_XXXX)) {
						AddSQLParameter(ClientID, "ClientID");
						AddPageAndSort();
						using (Reader()) {
							while (Read()) {
								AddAttribute(Root, "rows", "TotalRows");
								AddAttribute(Root, "pages", "TotalPages");
								xxxxXml(AddItem(), true, true);
							}
						}
					}
				} catch (Exception exc) {
					_AddError(ERROR_BASE, ERROR_INDEX, exc);
				}
			}
		}

		/// <summary>
		/// Search Xxxx.
		/// </summary>
		/// <returns>
		/// XmlDocument
		/// </returns>
		protected void _Search(
			 int FirstnameType		, string Firstname
			,int SurnameType		, string Surname
			,int UsernameType		, string Username
			,int EmailType			, string Email
			,int TelephoneType		, string Telephone
			,int CellphoneType		, string Cellphone
		) {
			using (Connect()) {
				try {
					using (Command(PROC_SEARCH_XXXX)) {
						AddSQLParameter(FirstnameType, "FirstnameType");
						AddSQLParameter(Firstname, "Firstname", 255);

						AddSQLParameter(SurnameType, "SurnameType");
						AddSQLParameter(Surname, "Surname", 255);

						AddSQLParameter(UsernameType, "UsernameSrchType");
						AddSQLParameter(Username, "Username", 255);

						AddSQLParameter(EmailType, "EmailSrchType");
						AddSQLParameter(Email, "Email", 255);

						AddSQLParameter(TelephoneType, "TelephoneSrchType");
						AddSQLParameter(Telephone, "Telephone", 50);

						AddSQLParameter(CellphoneType, "CellphoneSrchType");
						AddSQLParameter(Cellphone, "Cellphone", 50);

						AddPageAndSort();
						using (Reader()) {
							while (Read()) {
								xxxxXml(AddItem());
							}
						}
					}
				} catch (Exception exc) {
					_AddError(ERROR_BASE, ERROR_SEARCH, exc);
				}
			}
		}

		/// <summary>
		/// Add a new Xxxx.
		/// </summary>
		/// <returns>
		/// XmlDocument
		/// </returns>
		protected void _New(int PersonID
			, DateTime BirthDate
			, string Gender
			, DateTime StartDate	
			) {
			using (Connect()) {
				try {
					using (Command(PROC_ADD_XXXX)) {
						AddSQLParameter(PersonID	, "PersonID");
						AddSQLParameter(BirthDate	, "BirthDate");
						AddSQLParameter(Gender		, "Gender", 10);
						AddSQLParameter(StartDate	, "StartDate");
						using (Reader()) {
							if (Read()) {
								xxxxXml(AddItem(), false, false);
							}
						}
					}
				} catch (Exception exc) {
					_AddError(ERROR_BASE, ERROR_ADD, exc);
				}
			}
		}

		/// <summary>
		/// Update a Xxxx.
		/// </summary>
		/// <returns>
		/// XmlDocument
		/// </returns>
		protected void _Edit(int XxxxID
			, int PersonID
			, DateTime BirthDate
			, string Gender
			, DateTime StartDate
			) {
			using (Connect()) {
				try {
					using (Command(PROC_EDIT_XXXX)) {
						AddSQLParameter(XxxxID, "XxxxID");
						AddSQLParameter(PersonID	, "PersonID");
						AddSQLParameter(BirthDate	, "BirthDate");
						AddSQLParameter(Gender		, "Gender", 10);
						AddSQLParameter(StartDate	, "StartDate");
						using (Reader()) {
							if (Read()) {
								xxxxXml(AddItem());
							}
						}
					}
				} catch (Exception exc) {
					_AddError(ERROR_BASE, ERROR_UPD, exc);
				}
			}
		}

		/// <summary>
		/// Delete a Xxxx.
		/// </summary>
		/// <returns>
		/// XmlDocument
		/// </returns>
		protected void _Delete(int XxxxID) {
			using (Connect()) {
				try {
					using (Command(PROC_DEL_XXXX)) {
						AddSQLParameter(XxxxID, "XxxxID");
						Execute();
					}
				} catch (Exception exc) {
					_AddError(ERROR_BASE, ERROR_DEL, exc);
				}
			}
		}

		#endregion

		#region private Xxxx methods
		/// <summary></summary>
		private void xxxxXmlDrop(XmlElement item) {
			AddAttribute(item, "id", "ID");
			AddAttribute(item, "desc", "Name");
		}
		/// <summary></summary>
		private void xxxxXml(XmlElement item) {
			xxxxXml(item, false, true);
		}
		/// <summary></summary>
		private void xxxxXml(XmlElement item, bool wantRow, bool wantZzzz) {
			if (wantRow)
				AddAttribute(item, "row", "RowID");

			AddAttribute(item, "id", "ID");
			AddAttribute(item, "personid", "PersonID");
			AddAttribute(item, "birthdate", "BirthDate", DbType.DateTime);
			AddAttribute(item, "gender", "Gender");
			AddAttribute(item, "startdate", "StartDate", DbType.DateTime);
			AddAttribute(item, "fullname", "Fullname");
			AddAttribute(item, "username", "Username");
			AddAttribute(item, "password", "Password");
			AddAttribute(item, "firstname", "Firstname");
			AddAttribute(item, "surname", "Surname");
			AddAttribute(item, "email", "Email");
			AddAttribute(item, "telephone", "Telephone");
			AddAttribute(item, "cellphone", "CellPhone");
			if (wantZzzz) {
				AddAttribute(item, "uid", "UID");
				AddAttribute(item, "zzzzid", "ZzzzID");
				AddAttribute(item, "clientid", "ClientID");
				AddAttribute(item, "client", "Client");
				AddAttribute(item, "clientemail", "ClientEmail");
			}
		}
		#endregion

		#region Xxxx Default methods
		/// <summary>
		/// Gets details of a Xxxx.
		/// </summary>
		/// <returns>
		/// XmlDocument
		/// </returns>
		protected void _GetDefaults(int ClientID, int XxxxID, bool WantList) {
			using (Connect()) {
				try {
					using (Command(PROC_GET_XXXX_DEFAULTS)) {
						AddSQLParameter(ClientID, "ClientID");
						AddSQLParameter(XxxxID, "XxxxID");
						using (Reader()) {
							if (WantList) {
								while (Read()) {
									defaultXml(AddItem());
								}
							} else {
								defaultsXml(AddItem());
							}
						}
					}
				} catch (Exception exc) {
					_AddError(ERROR_DEFAULT_BASE, ERROR_GET, exc);
				}
			}
		}

		/// <summary>
		/// Update a Xxxx.
		/// </summary>
		/// <returns>
		/// XmlDocument
		/// </returns>
		protected void _EditDefault(int ClientID, int XxxxID, int TypeID, string Value) {
			using (Connect()) {
				try {
					using (Command(PROC_EDIT_XXXX_DEFAULT)) {
						AddSQLParameter(ClientID, "ClientID");
						AddSQLParameter(XxxxID, "XxxxID");
						AddSQLParameter(TypeID, "TypeID");
						AddSQLParameter(Value, "Value", 255);
						using (Reader()) {
							while (Read()) {
								defaultXml(AddItem());
							}
						}
					}
				} catch (Exception exc) {
					_AddError(ERROR_DEFAULT_BASE, ERROR_UPD, exc);
				}
			}
		}

		/// <summary>
		/// Update a Xxxx.
		/// </summary>
		/// <returns>
		/// XmlDocument
		/// </returns>
		protected void _DeleteDefault(int XxxxID, int TypeID) {
			using (Connect()) {
				try {
					using (Command(PROC_DEL_XXXX_DEFAULT)) {
						AddSQLParameter(XxxxID, "XxxxID");
						AddSQLParameter(TypeID, "TypeID");
						using (Reader()) {
							while (Read()) {
								defaultXml(AddItem());
							}
						}
					}
				} catch (Exception exc) {
					_AddError(ERROR_DEFAULT_BASE, ERROR_UPD, exc);
				}
			}
		}
		#endregion

		#region private Xxxx Default methods
		/// <summary></summary>
		private void defaultXml(XmlElement item) {
			//AddAttribute(item, "id", "ID");
			//AddAttribute(item, "xxxxid", "XxxxID");
			AddAttribute(item, "typeid", "TypeID");
			AddAttribute(item, "value", "Value");
			AddAttribute(item, "name", "Name");
			AddAttribute(item, "desc", "Description");
			AddAttribute(item, "unit", "Unit");
			AddAttribute(item, "isdef", "Defaulted");
		}
		/// <summary></summary>
		private void defaultsXml(XmlElement item) {
			while (Read()) {
				AddAttribute(item);
			}
		}
		#endregion

		#region Xxxx Yyyy methods
		/// <summary>
		/// Gets list of Xxxx Yyyys.
		/// </summary>
		/// <returns>
		/// XmlDocument
		/// </returns>
		protected void _ListYyyys(int XxxxID) {
			using (Connect()) {
				try {
					using (Command(PROC_LIST_XXXX_YYYYS)) {
						AddSQLParameter(XxxxID, "XxxxID");
						AddSort();
						using (Reader()) {
							while (Read()) {
								yyyyXml(AddItem());
							}
						}
					}
				} catch (Exception exc) {
					_AddError(ERROR_YYYY_BASE, ERROR_LIST, exc);
				}
			}
		}

		/// <summary>
		/// Add a Xxxx Yyyy.
		/// </summary>
		/// <returns>
		/// XmlDocument
		/// </returns>
		protected void _NewYyyy(int XxxxID
			, int YyyyID
			, decimal Credit
			, decimal Percent
			) {
			using (Connect()) {
				try {
					using (Command(PROC_ADD_XXXX_YYYYS)) {
						AddSQLParameter(XxxxID, "XxxxID");
						AddSQLParameter(YyyyID, "YyyyID");
						AddSQLParameter(Credit, "Credit");
						AddSQLParameter(Percent, "Percent");
						using (Reader()) {
							while (Read()) {
								yyyyXml(AddItem());
							}
						}
					}
				} catch (Exception exc) {
					_AddError(ERROR_YYYY_BASE, ERROR_ADD, exc);
				}
			}
		}

		/// <summary>
		/// Delete a Xxxx Yyyy.
		/// </summary>
		/// <returns>
		/// XmlDocument
		/// </returns>
		protected void _DeleteYyyy(int XxxxID, int YyyyID) {
			using (Connect()) {
				try {
					using (Command(PROC_DEL_XXXX_YYYY)) {
						AddSQLParameter(XxxxID, "XxxxID");
						AddSQLParameter(YyyyID, "YyyyID");
						using (Reader()) {
							while (Read()) {
								yyyyXml(AddItem());
							}
						}
					}
				} catch (Exception exc) {
					_AddError(ERROR_YYYY_BASE, ERROR_DEL, exc);
				}
			}
		}

		/// <summary>
		/// Delete all Xxxx Yyyys.
		/// </summary>
		/// <returns>
		/// XmlDocument
		/// </returns>
		protected void _DeleteYyyys(int XxxxID) {
			using (Connect()) {
				try {
					using (Command(PROC_DEL_XXXX_YYYYS)) {
						AddSQLParameter(XxxxID, "XxxxID");
						Execute();
					}
				} catch (Exception exc) {
					_AddError(ERROR_YYYY_BASE, ERROR_DEL, exc);
				}
			}
		}
		#endregion

		#region private Xxxx Yyyy methods
		/// <summary></summary>
		private void yyyyXml(XmlElement item) {
			AddAttribute(item, "xxxxid", "XxxxID");
			AddAttribute(item, "yyyyid", "YyyyID");
			AddAttribute(item, "credit", "Credit");
			AddAttribute(item, "percent", "Percent");
			AddAttribute(item, "uid", "UID");
			AddAttribute(item, "typeid", "TypeID");
			AddAttribute(item, "riskid", "RiskID");
			AddAttribute(item, "name", "Name");
			AddAttribute(item, "description", "Description");
			AddAttribute(item, "target", "Target");
			AddAttribute(item, "typename", "TypeName");
			AddAttribute(item, "typedescription", "TypeDescription");
			AddAttribute(item, "riskname", "RiskName");
			AddAttribute(item, "riskdescription", "RiskDescription");
		}							  
		#endregion

		#region Xxxx Service methods
		/// <summary>
		/// Gets list of Xxxx Services.
		/// </summary>
		/// <returns>
		/// XmlDocument
		/// </returns>
		protected void _ListServices(int XxxxID) {
			using (Connect()) {
				try {
					using (Command(PROC_LIST_XXXX_SERVICES)) {
						AddSQLParameter(XxxxID, "XxxxID");
						AddSort();
						using (Reader()) {
							while (Read()) {
								investmentXml(AddItem());
							}
						}
					}
				} catch (Exception exc) {
					_AddError(ERROR_SERVICE_BASE, ERROR_LIST, exc);
				}
			}
		}

		/// <summary>
		/// Add a Xxxx Service.
		/// </summary>
		/// <returns>
		/// XmlDocument
		/// </returns>
		protected void _NewService(int XxxxID
			, int ServiceID
			, string Frequency
			, decimal Premium
			, bool IsPremium
			, decimal Credit
			, DateTime StartDate
			, bool InYyyy
			) {
			using (Connect()) {
				try {
					using (Command(PROC_ADD_XXXX_SERVICES)) {
						AddSQLParameter(XxxxID, "XxxxID");
						AddSQLParameter(ServiceID, "ServiceID");
						AddSQLParameter(Frequency, "Frequency", 10);
						AddSQLParameter(Premium, "Premium");
						AddSQLParameter(IsPremium ? 1 : 0, "IsPremium");
						AddSQLParameter(Credit, "Credit");
						AddSQLParameter(StartDate, "StartDate");
						AddSQLParameter(InYyyy ? 1 : 0, "InYyyy");
						using (Reader()) {
							while (Read()) {
								investmentXml(AddItem());
							}
						}
					}
				} catch (Exception exc) {
					_AddError(ERROR_SERVICE_BASE, ERROR_ADD, exc);
				}
			}
		}

		/// <summary>
		/// Delete a Xxxx Service.
		/// </summary>
		/// <returns>
		/// XmlDocument
		/// </returns>
		protected void _DeleteService(int XxxxID, int ServiceID) {
			using (Connect()) {
				try {
					using (Command(PROC_DEL_XXXX_SERVICE)) {
						AddSQLParameter(XxxxID, "XxxxID");
						AddSQLParameter(ServiceID, "ServiceID");
						using (Reader()) {
							while (Read()) {
								investmentXml(AddItem());
							}
						}
					}
				} catch (Exception exc) {
					_AddError(ERROR_SERVICE_BASE, ERROR_DEL, exc);
				}
			}
		}

		/// <summary>
		/// Delete all Xxxx Services.
		/// </summary>
		/// <returns>
		/// XmlDocument
		/// </returns>
		protected void _DeleteServices(int XxxxID) {
			using (Connect()) {
				try {
					using (Command(PROC_DEL_XXXX_SERVICES)) {
						AddSQLParameter(XxxxID, "XxxxID");
						Execute();
					}
				} catch (Exception exc) {
					_AddError(ERROR_SERVICE_BASE, ERROR_DEL, exc);
				}
			}
		}
		#endregion

		#region private Xxxx Service methods
		/// <summary></summary>
		private void investmentXml(XmlElement item) {
			AddAttribute(item, "xxxxid", "XxxxID");
			AddAttribute(item, "serviceid", "ServiceID");
			AddAttribute(item, "frequency", "Frequency");
			AddAttribute(item, "premium", "Premium");
			AddAttribute(item, "ispremium", "IsPremium");
			AddAttribute(item, "credit", "Credit");
			AddAttribute(item, "startdate", "StartDate", DbType.Date);
			AddAttribute(item, "inyyyy", "InYyyy");
			AddAttribute(item, "uid", "UID");
			AddAttribute(item, "typeid", "TypeID");
			AddAttribute(item, "name", "Name");
			AddAttribute(item, "description", "Description");
			AddAttribute(item, "typename", "TypeName");
			AddAttribute(item, "typedescription", "TypeDescription");
		}
		#endregion

		#region Zzzz methods
		/// <summary>
		/// Gets details of a Zzzz.
		/// </summary>
		/// <returns>
		/// XmlDocument
		/// </returns>
		protected void _GetZzzz(int ZzzzID) {
			using (Connect()) {
				try {
					using (Command(PROC_GET_ZZZZ)) {
						AddSQLParameter(ZzzzID, "ZzzzID");
						using (Reader()) {
							if (Read()) {
								zzzzXml(AddItem());
							}
						}
					}
				} catch (Exception exc) {
					_AddError(ERROR_BASE, ERROR_GET, exc);
				}
			}
		}

		/// <summary>
		/// Add a new Zzzz.
		/// </summary>
		/// <returns>
		/// XmlDocument
		/// </returns>
		protected void _NewZzzz(string UID
			, string ZzzzID
			, int ClientID
			//, int XxxxID
			) {
			using (Connect()) {
				try {
					using (Command(PROC_ADD_ZZZZ)) {
						AddSQLParameter(UID, "UID", 100);
						AddSQLParameter(ZzzzID, "ZzzzID", 100);
						AddSQLParameter(ClientID, "ClientID");
						//AddSQLParameter(XxxxID, "XxxxID");
						using (Reader()) {
							if (Read()) {
								zzzzXml(AddItem());
							}
						}
					}
				} catch (Exception exc) {
					_AddError(ERROR_BASE, ERROR_ADD, exc);
				}
			}
		}

		/// <summary>
		/// Update a Zzzz.
		/// </summary>
		/// <returns>
		/// XmlDocument
		/// </returns>
		protected void _EditZzzz(int ZzzzID
			, string UID
			, string YyyyID
			, int ClientID
			, int XxxxID
			) {
			using (Connect()) {
				try {
					using (Command(PROC_EDIT_ZZZZ)) {
						AddSQLParameter(ZzzzID, "ZzzzID");
						AddSQLParameter(UID, "UID", 100);
						AddSQLParameter(YyyyID, "YyyyID", 100);
						AddSQLParameter(ClientID, "ClientID");
						AddSQLParameter(XxxxID, "XxxxID");
						using (Reader()) {
							if (Read()) {
								zzzzXml(AddItem());
							}
						}
					}
				} catch (Exception exc) {
					_AddError(ERROR_BASE, ERROR_UPD, exc);
				}
			}
		}

		/// <summary>
		/// Delete a Zzzz.
		/// </summary>
		/// <returns>
		/// XmlDocument
		/// </returns>
		protected void _DeleteZzzz(int ZzzzID) {
			using (Connect()) {
				try {
					using (Command(PROC_DEL_ZZZZ)) {
						AddSQLParameter(ZzzzID, "ZzzzID");
						Execute();
					}
				} catch (Exception exc) {
					_AddError(ERROR_BASE, ERROR_DEL, exc);
				}
			}
		}

		#endregion

		#region private Zzzz methods
		/// <summary></summary>
		private void zzzzXml(XmlElement item) {
			zzzzXml(item, false);
		}
		/// <summary></summary>
		private void zzzzXml(XmlElement item, bool wantRow) {
			if (wantRow)
				AddAttribute(item, "row", "RowID");

			AddAttribute(item, "id", "ID");
			AddAttribute(item, "uid", "UID");
			AddAttribute(item, "zzzzid", "ZzzzID");
			AddAttribute(item, "clientid", "ClientID");
			AddAttribute(item, "xxxxid", "XxxxID");
			AddAttribute(item, "name", "Name");
			AddAttribute(item, "email", "Email");
		}
		#endregion
	}
}

