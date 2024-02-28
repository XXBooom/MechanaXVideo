using System;
using System.Data;
using System.Xml;
using XXBoom.MachinaX.ServiceX;

namespace MechanaX.Video.Service {
	/// <summary>
	/// XxxxX extends ServiceX to implement the xxxx management functionality
	/// </summary>
	public class XxxxX : ProtoServiceX {

		#region Constants - Stored procedure names
		// Procedures for Xxxxs
		private const string PROC_GET_XXXX = "GetXxxx";
		private const string PROC_LIST_XXXX = "ListXxxxs";
		private const string PROC_INDEX_XXXX = "IndexXxxxs";
		private const string PROC_SEARCH_XXXX = "SearchXxxxs";
		private const string PROC_ADD_XXXX = "AddXxxx";
		private const string PROC_EDIT_XXXX = "EditXxxx";
		private const string PROC_DEL_XXXX = "DeleteXxxx";
		// Procedures for Yyyys
		private const string PROC_GET_YYYY = "GetYyyy";
		private const string PROC_LIST_YYYY = "ListYyyys";
		private const string PROC_ADD_YYYY = "AddYyyy";
		private const string PROC_EDIT_YYYY = "EditYyyy";
		private const string PROC_DEL_YYYY = "DeleteYyyy";
		// Procedures for Zzzzs
		private const string PROC_GET_ZZZZ = "GetZzzz";
		private const string PROC_LIST_ZZZZ = "ListZzzzs";
		private const string PROC_ADD_ZZZZ = "AddZzzz";
		private const string PROC_EDIT_ZZZZ = "EditZzzz";
		private const string PROC_DEL_ZZZZ = "DeleteZzzz";
		// Error Bases
		private const int ERROR_BASE_XXXX = 9300;
		private const int ERROR_BASE_YYYY = 9310;
		private const int ERROR_BASE_ZZZZ = 9330;
		#endregion

		#region Constructors/Destructors
		/// <summary>
		/// Default constructor for the Xxxx class.
		/// </summary>
		public XxxxX() : base("AwardsX", "ServicesX") {
		}
		public XxxxX(string rootName, string configName) : base(rootName, configName) {
		}
		#endregion

		#region Xxxx methods
		/// <summary>
		/// Gets details of a Xxxx.
		/// </summary>
		/// <returns>
		/// XmlDocument
		/// </returns>
		protected void _GetXxxx(int XxxxID) {
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
					_AddError(ERROR_BASE_XXXX, ERROR_GET, exc);
				}
			}
		}

		/// <summary>
		/// List Xxxx.
		/// </summary>
		/// <returns>
		/// XmlDocument
		/// </returns>
		protected void _ListXxxxs(int TypeID) {
			_ListXxxxs(TypeID, false, false, "");
		}
		protected void _ListXxxxs(int TypeID, bool IsDrop) {
			_ListXxxxs(TypeID, true, false, "");
		}
		protected void _ListXxxxsFilter(int TypeID) {
			_ListXxxxs(TypeID, true, true, DEFAULT_FILTER);
		}
		protected void _ListXxxxsSelect(int TypeID) {
			_ListXxxxs(TypeID, true, true, DEFAULT_SELECT);
		}
		protected void _ListXxxxs(int TypeID, bool IsDrop, bool WantFirst, string FirstPrompt) {
			using (Connect()) {
				try {
					using (Command(PROC_LIST_XXXX)) {
						AddSQLParameter(TypeID, "TypeID");
						AddSort();
						using (Reader()) {
							_InitDrop(IsDrop, WantFirst, FirstPrompt);
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
					_AddError(ERROR_BASE_XXXX, ERROR_LIST, exc);
				}
			}
		}

		/// <summary>
		/// List Xxxxs.
		/// </summary>
		/// <returns>
		/// XmlDocument
		/// </returns>
		protected void _IndexXxxxs(int TypeID) {
			using (Connect()) {
				try {
					using (Command(PROC_INDEX_XXXX)) {
						AddSQLParameter(TypeID, "TypeID");
						AddPageAndSort();
						using (Reader()) {
							while (Read()) {
								AddAttribute(Root, "rows", "TotalRows");
								AddAttribute(Root, "pages", "TotalPages");
								xxxxXml(AddItem(), true);
							}
						}
					}
				} catch (Exception exc) {
					_AddError(ERROR_BASE_XXXX, ERROR_INDEX, exc);
				}
			}
		}

		/// <summary>
		/// Search Xxxxs.
		/// </summary>
		/// <returns>
		/// XmlDocument
		/// </returns>
		protected void _SearchXxxxs(int TypeID
			, int FirstnameType, string Firstname
			, int SurnameType, string Surname
			, int UsernameType, string Username
			, int EmailType, string Email
			, int TelephoneType, string Telephone
			, int CellphoneType, string Cellphone
		) {
			using (Connect()) {
				try {
					using (Command(PROC_SEARCH_XXXX)) {
						AddSQLParameter(TypeID, "TypeID");
						AddSQLParameter(FirstnameType, "FirstnameSrchType");
						AddSQLParameter(Firstname, "Firstname", 255);

						AddSQLParameter(SurnameType, "SurnameSrchType");
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
					_AddError(ERROR_BASE_XXXX, ERROR_SEARCH, exc);
				}
			}
		}

		/// <summary>
		/// Add a new Xxxx.
		/// </summary>
		/// <returns>
		/// XmlDocument
		/// </returns>
		protected void _NewXxxx(int TypeID
			, DateTime StartDate
			, string Gender
			) {
			using (Connect()) {
				try {
					using (Command(PROC_ADD_XXXX)) {
						AddSQLParameter(TypeID, "TypeID");
						AddSQLParameter(StartDate, "StartDate");
						AddSQLParameter(Gender, "Gender", 10);
						using (Reader()) {
							if (Read()) {
								xxxxXml(AddItem(), false);
							}
						}
					}
				} catch (Exception exc) {
					_AddError(ERROR_BASE_XXXX, ERROR_ADD, exc);
				}
			}
		}

		/// <summary>
		/// Update a Xxxx.
		/// </summary>
		/// <returns>
		/// XmlDocument
		/// </returns>
		protected void _EditXxxx(int XxxxID
			, int TypeID
			, DateTime BirthDate
			, string Gender
			, DateTime StartDate
			) {
			using (Connect()) {
				try {
					using (Command(PROC_EDIT_XXXX)) {
						AddSQLParameter(XxxxID, "XxxxID");
						AddSQLParameter(TypeID, "TypeID");
						AddSQLParameter(BirthDate, "BirthDate");
						AddSQLParameter(Gender, "Gender", 10);
						AddSQLParameter(StartDate, "StartDate");
						using (Reader()) {
							if (Read()) {
								xxxxXml(AddItem());
							}
						}
					}
				} catch (Exception exc) {
					_AddError(ERROR_BASE_XXXX, ERROR_UPD, exc);
				}
			}
		}

		/// <summary>
		/// Delete a Xxxx.
		/// </summary>
		/// <returns>
		/// XmlDocument
		/// </returns>
		protected void _DeleteXxxx(int XxxxID) {
			using (Connect()) {
				try {
					using (Command(PROC_DEL_XXXX)) {
						AddSQLParameter(XxxxID, "XxxxID");
						Execute();
					}
				} catch (Exception exc) {
					_AddError(ERROR_BASE_XXXX, ERROR_DEL, exc);
				}
			}
		}

		/// <summary></summary>
		private void xxxxXmlDrop(XmlElement item) {
			AddAttribute(item, "id", "ID");
			AddAttribute(item, "desc", "Name");
		}
		/// <summary></summary>
		private void xxxxXml(XmlElement item) {
			xxxxXml(item, false);
		}
		/// <summary></summary>
		private void xxxxXml(XmlElement item, bool wantRow) {
			if (wantRow) {
				AddAttribute(item, "row", "RowID");
			}
			AddAttribute(item, "id", "ID");
			AddAttribute(item, "abcdefgh", "AbcdEfgh");
			AddAttribute(item, "abcdefgh", "AbcdEfgh");
			AddAttribute(item, "abcdefgh", "AbcdEfgh");
			AddAttribute(item, "abcdefgh", "AbcdEfgh");
			AddAttribute(item, "abcdefgh", "AbcdEfgh");
			AddAttribute(item, "abcdefgh", "AbcdEfgh");
			AddAttribute(item, "abcdefgh", "AbcdEfgh");
			AddAttribute(item, "abcdefgh", "AbcdEfgh");
			AddAttribute(item, "abcdefgh", "AbcdEfgh");
			AddAttribute(item, "abcdefgh", "AbcdEfgh");
			AddAttribute(item, "abcdefgh", "AbcdEfgh");
			AddAttribute(item, "abcdefgh", "AbcdEfgh");
			AddAttribute(item, "abcdefgh", "AbcdEfgh");
			AddAttribute(item, "abcdefgh", "AbcdEfgh");
			AddAttribute(item, "abcdefgh", "AbcdEfgh");
			AddAttribute(item, "abcdefgh", "AbcdEfgh");
			AddAttribute(item, "abcdefgh", "AbcdEfgh");
			AddAttribute(item, "abcdefgh", "AbcdEfgh");
			AddAttribute(item, "abcdefgh", "AbcdEfgh");
			AddAttribute(item, "abcdefgh", "AbcdEfgh");
			AddAttribute(item, "abcdefgh", "AbcdEfgh");
			AddAttribute(item, "abcdefgh", "AbcdEfgh");
			AddAttribute(item, "abcdefgh", "AbcdEfgh");
			AddAttribute(item, "abcdefgh", "AbcdEfgh");
			AddAttribute(item, "abcdefgh", "AbcdEfgh");
			AddAttribute(item, "abcdefgh", "AbcdEfgh");
			AddAttribute(item, "abcdefgh", "AbcdEfgh");
			AddAttribute(item, "abcdefgh", "AbcdEfgh");
			AddAttribute(item, "abcdefgh", "AbcdEfgh");
			AddAttribute(item, "abcdefgh", "AbcdEfgh");
			AddAttribute(item, "abcdefgh", "AbcdEfgh");
			AddAttribute(item, "abcdefgh", "AbcdEfgh");
			AddAttribute(item, "abcdefgh", "AbcdEfgh");
			AddAttribute(item, "abcdefgh", "AbcdEfgh");
			AddAttribute(item, "abcdefgh", "AbcdEfgh");
			AddAttribute(item, "abcdefgh", "AbcdEfgh");
			AddAttribute(item, "abcdefgh", "AbcdEfgh");
			AddAttribute(item, "createdate", "CreateDate", DbType.DateTime);
		}
		#endregion

		#region Yyyy methods
		/// <summary>
		/// Gets details of a Yyyy.
		/// </summary>
		/// <returns>
		/// XmlDocument
		/// </returns>
		protected void _GetYyyy(int YyyyID) {
			using (Connect()) {
				try {
					using (Command(PROC_GET_YYYY)) {
						AddSQLParameter(YyyyID, "YyyyID");
						using (Reader()) {
							if (Read()) {
								yyyyXml(AddItem());
							}
						}
					}
				} catch (Exception exc) {
					_AddError(ERROR_BASE_YYYY, ERROR_GET, exc);
				}
			}
		}

		/// <summary>
		/// List Yyyy.
		/// </summary>
		/// <returns>
		/// XmlDocument
		/// </returns>
		protected void _ListYyyys(int TypeID) {
			_ListYyyys(TypeID, false, false, "");
		}
		protected void _ListYyyys(int TypeID, bool IsDrop) {
			_ListYyyys(TypeID, true, false, "");
		}
		protected void _ListYyyysFilter(int TypeID) {
			_ListYyyys(TypeID, true, true, DEFAULT_FILTER);
		}
		protected void _ListYyyysSelect(int TypeID) {
			_ListYyyys(TypeID, true, true, DEFAULT_SELECT);
		}
		protected void _ListYyyys(int TypeID, bool IsDrop, bool WantFirst, string FirstPrompt) {
			using (Connect()) {
				try {
					using (Command(PROC_LIST_YYYY)) {
						AddSQLParameter(TypeID, "TypeID");
						AddSort();
						using (Reader()) {
							_InitDrop(IsDrop, WantFirst, FirstPrompt);
							while (Read()) {
								if (IsDrop) {
									yyyyXmlDrop(AddItem());
								} else {
									yyyyXml(AddItem());
								}
							}
						}
					}
				} catch (Exception exc) {
					_AddError(ERROR_BASE_YYYY, ERROR_LIST, exc);
				}
			}
		}

		/// <summary>
		/// Add a new Yyyy.
		/// </summary>
		/// <returns>
		/// XmlDocument
		/// </returns>
		protected void _NewYyyy(string Name
			, string Note
			, string Desc
			) {
			using (Connect()) {
				try {
					using (Command(PROC_ADD_YYYY)) {
						AddSQLParameter(Name, "Name", XTYPE_LEN_xName);
						AddSQLParameter(Note, "Note", XTYPE_LEN_xNote);
						AddSQLParameter(Desc, "Desc", XTYPE_LEN_xDesc);
						using (Reader()) {
							if (Read()) {
								yyyyXml(AddItem());
							}
						}
					}
				} catch (Exception exc) {
					_AddError(ERROR_BASE_YYYY, ERROR_ADD, exc);
				}
			}
		}

		/// <summary>
		/// Update a Yyyy.
		/// </summary>
		/// <returns>
		/// XmlDocument
		/// </returns>
		protected void _EditYyyy(int YyyyID
			, string Name
			, string Note
			, string Desc
			) {
			using (Connect()) {
				try {
					using (Command(PROC_EDIT_YYYY)) {
						AddSQLParameter(YyyyID, "YyyyID");
						AddSQLParameter(Name, "Name", XTYPE_LEN_xName);
						AddSQLParameter(Note, "Note", XTYPE_LEN_xNote);
						AddSQLParameter(Desc, "Desc", XTYPE_LEN_xDesc);
						using (Reader()) {
							if (Read()) {
								yyyyXml(AddItem());
							}
						}
					}
				} catch (Exception exc) {
					_AddError(ERROR_BASE_YYYY, ERROR_UPD, exc);
				}
			}
		}

		/// <summary>
		/// Delete a Yyyy.
		/// </summary>
		/// <returns>
		/// XmlDocument
		/// </returns>
		protected void _DeleteYyyy(int YyyyID) {
			using (Connect()) {
				try {
					using (Command(PROC_DEL_YYYY)) {
						AddSQLParameter(YyyyID, "YyyyID");
						Execute();
					}
				} catch (Exception exc) {
					_AddError(ERROR_BASE_YYYY, ERROR_DEL, exc);
				}
			}
		}


		/// <summary></summary>
		private void yyyyXmlDrop(XmlElement item) {
			AddAttribute(item, "id", "ID");
			AddAttribute(item, "desc", "Name");
		}
		/// <summary></summary>
		private void yyyyXml(XmlElement item) {
			yyyyXml(item, false);
		}
		/// <summary></summary>
		private void yyyyXml(XmlElement item, bool wantRow) {
			if (wantRow) {
				AddAttribute(item, "row", "RowID");
			}
			AddAttribute(item, "id", "ID");
			AddAttribute(item, "name", "Name");
			AddAttribute(item, "note", "Note");
			AddAttribute(item, "desc", "Desc");
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
					_AddError(ERROR_BASE_ZZZZ, ERROR_GET, exc);
				}
			}
		}

		/// <summary>
		/// List Zzzz.
		/// </summary>
		/// <returns>
		/// XmlDocument
		/// </returns>
		protected void _ListZzzzs() {
			_ListZzzzs(false, false, "");
		}
		protected void _ListZzzzs(bool IsDrop) {
			_ListZzzzs(true, false, "");
		}
		protected void _ListZzzzsFilter() {
			_ListZzzzs(true, true, DEFAULT_FILTER);
		}
		protected void _ListZzzzsSelect() {
			_ListZzzzs(true, true, DEFAULT_SELECT);
		}
		protected void _ListZzzzs(bool IsDrop, bool WantFirst, string FirstPrompt) {
			using (Connect()) {
				try {
					using (Command(PROC_LIST_ZZZZ)) {
						AddSort();
						using (Reader()) {
							_InitDrop(IsDrop, WantFirst, FirstPrompt);
							while (Read()) {
								if (IsDrop) {
									zzzzXmlDrop(AddItem());
								} else {
									zzzzXml(AddItem());
								}
							}
						}
					}
				} catch (Exception exc) {
					_AddError(ERROR_BASE_ZZZZ, ERROR_LIST, exc);
				}
			}
		}

		/// <summary>
		/// Add a new Zzzz.
		/// </summary>
		/// <returns>
		/// XmlDocument
		/// </returns>
		protected void _NewZzzz(string Name, string Note) {
			using (Connect()) {
				try {
					using (Command(PROC_ADD_ZZZZ)) {
						AddSQLParameter(Name, "Name", XTYPE_LEN_xName);
						AddSQLParameter(Note, "Note", XTYPE_LEN_xNote);
						using (Reader()) {
							if (Read()) {
								zzzzXml(AddItem());
							}
						}
					}
				} catch (Exception exc) {
					_AddError(ERROR_BASE_ZZZZ, ERROR_ADD, exc);
				}
			}
		}

		/// <summary>
		/// Update a Zzzz.
		/// </summary>
		/// <returns>
		/// XmlDocument
		/// </returns>
		protected void _EditZzzz(int ZzzzID, string Name, string Note) {
			using (Connect()) {
				try {
					using (Command(PROC_EDIT_ZZZZ)) {
						AddSQLParameter(ZzzzID, "ZzzzID");
						AddSQLParameter(Name, "Name", XTYPE_LEN_xName);
						AddSQLParameter(Note, "Note", XTYPE_LEN_xNote);
						using (Reader()) {
							if (Read()) {
								zzzzXml(AddItem());
							}
						}
					}
				} catch (Exception exc) {
					_AddError(ERROR_BASE_ZZZZ, ERROR_UPD, exc);
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
					_AddError(ERROR_BASE_ZZZZ, ERROR_DEL, exc);
				}
			}
		}


		/// <summary></summary>
		private void zzzzXmlDrop(XmlElement item) {
			AddAttribute(item, "id", "ID");
			AddAttribute(item, "desc", "Note");
		}
		/// <summary></summary>
		private void zzzzXml(XmlElement item) {
			zzzzXml(item, false);
		}
		/// <summary></summary>
		private void zzzzXml(XmlElement item, bool wantRow) {
			if (wantRow) {
				AddAttribute(item, "row", "RowID");
			}
			AddAttribute(item, "id", "ID");
			AddAttribute(item, "name", "Name");
			AddAttribute(item, "note", "Note");
		}
		#endregion
	}
}
