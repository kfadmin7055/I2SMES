#region 어셈블리 EBAP.UI.ADM.Management, v3.17
// C:\EBAP.NET\EBAP.UI.ADM.dll
// CLR Version : 4.0.30319.36415
#endregion

using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList.Nodes;
using EBAP.Business.WSBiz;
using EBAP.Core;
using EBAP.Core.Collections;
using EBAP.Core.Info;
using EBAP.Data.CodeUtil;
using System;
using System.Data;

namespace EBAP.UI.ADM.Management
{
    #region :: EBAP.UI.ADM.Management.Auth ::

    /// <summary>
    /// Form의 업무내용을 기술합니다.
    /// </summary>
    /// <remarks>
    /// Comment     : Form 기능 및 특이사항 기록
    ///               1.  
    ///               2. 
    /// History     :
    ///               1. (2018-04-10 오전 11:20:19 - 오인봉 - PC170245) : 최초 생성
    ///               2.
    ///               3.
    /// </remarks>
    public partial class Auth : EBAP.Win.BaseFrame.UIFrame
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// Auth Form을 생성합니다.
        /// </summary>
        public Auth()
        {
            InitializeComponent();

            AppConfig.CurrentDB = ConnectionString.METADB;
        }

        #endregion

        #region :: 전역변수 ::

        private string AUTHTYPE = "";

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler(Common Event)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: Auth_Load :: Form이 Load 시 발생합니다.

        /// <summary>
        /// Form이 Load 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Auth_Load(object sender, EventArgs e)
        {
            try
            {
                InitLocalization();
                InitGlobalInstance();
                InitComboBox();
                InitAuthType();
                InitGridControl();
                InitControls();

                //Form Load 후 조회를 실행해야 한다면 주석을 제거하세요.
                IsLoadSelectEvent = true;
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        private void InitAuthType()
        {
            if (MENUID.Contains("SYS"))
                AUTHTYPE = "";
            else if (MENUID.Contains("MRO"))
                AUTHTYPE = "MRO";
            else if (MENUID.Contains("MES"))
                AUTHTYPE = "MES";
            else if (MENUID.Contains("RACB"))
                AUTHTYPE = "RACB";
            else if (MENUID.Contains("QC04"))
                AUTHTYPE = "SPC";
            else if (MENUID.Contains("QC05"))
                AUTHTYPE = "OUT";
            else if (MENUID.Contains("QC06"))
                AUTHTYPE = "LABEL";
            else if (MENUID.Contains("CIS"))
                AUTHTYPE = "CIS";
            else if (MENUID.Contains("JIG"))
                AUTHTYPE = "JIG";
            else if (MENUID.Contains("ASMS"))
                AUTHTYPE = "ASMS";
            else if (MENUID.Contains("SMS"))
                AUTHTYPE = "SMS";
            else if (MENUID.Contains("RPT"))
                AUTHTYPE = "RPT";
            else if (MENUID.Contains("QCMS"))
                AUTHTYPE = "QCMS";
            else if (MENUID.Contains("HDMS"))
                AUTHTYPE = "HDMS";

            cboAuthType.EditValue = AUTHTYPE;
            //cboAuthType.ReadOnly = AUTHTYPE == "" ? false : true;

            lcAuthType.Visibility = AUTHTYPE == "" ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        /// <summary>
        /// 다국어 Initialize
        /// </summary>
        private void InitLocalization()
        {
            // localizer 를 사용하세요.
            // grpOption.Text = LANGCONVERTER.GetLanguageString("InquiryOption");
        }

        /// <summary>
        /// 전역변수 Initialize
        /// </summary>
        private void InitGlobalInstance()
        {
        }

        /// <summary>
        /// Grid Control Initialize
        /// </summary>
        private void InitGridControl()
        {
            InitViewAuthGroup();
            InitViewAuthGroupUser();
            InitMenuTree();
        }

        /// <summary>
        /// ViewAuthGroup 그리드컬럼 초기화
        /// </summary>
        private void InitViewAuthGroup()
        {
            viewAuthGroup.BeginInit();

            viewAuthGroup.InitColumn(AppConfig.CHECKCOLUMNNAME, "Select", 50, 0, true, true, DataType.CheckEdit);
            //viewAuthGroup.InitColumn("AUTHTYPE", "권한", 80, 0, true, true);
            //viewAuthGroup.InitColumn("GROUPCODE", "그룹코드", 100, 0, false, true);
            //viewAuthGroup.InitColumn("GROUPNAME", "그룹명", 170, 0, true, true);
            //viewAuthGroup.InitColumn("CHECKPROCESS", "공정체크여부", 80, 0, true, true, DataType.CheckEdit);
            //viewAuthGroup.InitColumn("RESTRICTIONFLAG", "예외권한여부", 80, 0, false, false, DataType.CheckEdit);
            //viewAuthGroup.InitColumn("DESCRIPTION", "그룹설명", 250, 0, true, true, DataType.Default);
            //viewAuthGroup.InitColumn("CHANGEBY", "등록자", 80, 0, false, true, DataType.Default);
            //viewAuthGroup.InitColumn("CHANGEDTTM", "등록일자", 130, 0, false, true, DataType.DateTime);
            viewAuthGroup.InitColumnFromDB();

            viewAuthGroup.MandatoryColumns = new string[] { "GROUPCODE", "GROUPNAME" };
            viewAuthGroup.NewRowEnableColumns = new string[] { "GROUPCODE" };
            viewAuthGroup.KeyColumns = new string[] { "GROUPCODE" };

            //viewAuthGroup.InitColumnFromDB();

            viewAuthGroup.InitComboBoxColumn("AUTHTYPE", AppCode.GetCodeMaster("C$AUTHTYPE", ""));

            viewAuthGroup.SetColumnAllowEdit("GROUPNAME", CurrentUser.ISADMIN);
            viewAuthGroup.SetColumnAllowEdit("CHECKPROCESS", CurrentUser.ISADMIN);
            viewAuthGroup.SetColumnAllowEdit("RESTRICTIONFLAG", CurrentUser.ISADMIN);
            viewAuthGroup.SetColumnAllowEdit("DESCRIPTION", CurrentUser.ISADMIN);
            //viewAuthGroup.SetColumnVisible("CHECKPROCESS", CurrentUser.ISADMIN);

            viewAuthGroup.SetColumnVisible("AUTHTYPE", AUTHTYPE == "" ? true : false);

            viewAuthGroup.EndInit();
        }

        /// <summary>
        /// ViewAuthGroupUser 그리드컬럼 초기화
        /// </summary>
        private void InitViewAuthGroupUser()
        {
            viewAuthGroupUser.BeginInit();

            viewAuthGroupUser.InitColumn(AppConfig.CHECKCOLUMNNAME, "Select", 50, 0, true, true, DataType.CheckEdit);
            //viewAuthGroupUser.InitColumn("GROUPCODE", "GroupCode", 80, 0, false, false);
            //viewAuthGroupUser.InitColumn("USERID", "ID", 90, 0, false, true, DataType.Default);
            //viewAuthGroupUser.InitColumn("USERNAME", "UserName", 100, 0, false, true, DataType.Popup);
            //viewAuthGroupUser.InitColumn("DEPTNAME", "DeptName", 170, 0, false, true, DataType.Default);
            //viewAuthGroupUser.InitColumn("EXPIREDATE", "ExpireDate", 100, 0, true, true, DataType.Date);
            //viewAuthGroupUser.InitColumn("ISDELEGATE", "권한위임", 80, 0, CurrentUser.ISADMIN, CurrentUser.ISADMIN, DataType.CheckEdit);
            //viewAuthGroupUser.InitColumn("CHANGEBY", "ChangeBy", 80, 0, false, false, DataType.Default);
            //viewAuthGroupUser.InitColumn("CHANGEDTTM", "ChangeDttm", 130, 0, false, false, DataType.DateTime);
            viewAuthGroupUser.InitColumnFromDB();

            // 신규입력할 때만 UserName입력가능하게 변경
            viewAuthGroupUser.KeyColumns = new string[] { "GROUPCODE", "USERID" };
            viewAuthGroupUser.NewRowEnableColumns = new string[] { "USERNAME" };
            viewAuthGroupUser.MandatoryColumns = new string[] { "GROUPCODE", "USERID", "USERNAME" };

            viewAuthGroupUser.EndInit();
        }

        private void InitMenuTree()
        {
            tlGroupAuthMenu.BeginInit();

            tlGroupAuthMenu.InitColumn("ISAUTH", "사용", 100, 0, true, true, DataType.CheckEdit);
            tlGroupAuthMenu.InitColumn("GROUPCODE", "그룹코드", 80, 0, false, false);
            tlGroupAuthMenu.InitColumn("MENUID", "메뉴ID", 80, 0, false, false);
            tlGroupAuthMenu.InitColumn("MENUNAME", "메뉴이름", 250, 100, false, true);
            tlGroupAuthMenu.InitColumn("PARENTMENUID", "부모메뉴", 50, 0, false, false);
            tlGroupAuthMenu.InitColumn("SELECTAUTH", "조회권한", 50, 0, true, true, DataType.CheckEdit);
            tlGroupAuthMenu.InitColumn("NEWAUTH", "신규권한", 50, 0, true, true, DataType.CheckEdit);
            tlGroupAuthMenu.InitColumn("SAVEAUTH", "저장권한", 50, 0, true, true, DataType.CheckEdit);
            tlGroupAuthMenu.InitColumn("DELAUTH", "삭제권한", 50, 0, true, true, DataType.CheckEdit);

            tlGroupAuthMenu.KeyFieldName = "MENUID";
            tlGroupAuthMenu.ParentFieldName = "PARENTMENUID";

            tlGroupAuthMenu.EndInit();
        }

        /// <summary>
        /// ComboBox Initialize
        /// </summary>
        private void InitComboBox()
        {
            cboAuthType.InitData(AppCode.GetCodeMaster("C$AUTHTYPE", ""));
        }

        /// <summary>
        /// 기타 Control Initialize
        /// </summary>
        private void InitControls()
        {
            if (CurrentUser.ISADMIN) return;

            lcgMenu.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        #endregion

        #region :: Auth_Link :: Form 간 Data 전송 시 발생합니다.

        /// <summary>
        /// Form 간 Data 전송 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Auth_Link(object sender, EventArgs e)
        {
            try
            {
                LinkData();

                // Link 후 조회를 실행해야 한다면 주석을 제거하세요.
                //RaiseSelectEvent();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Form 간 Data 전송 처리
        /// </summary>
        private void LinkData()
        {
        }

        #endregion

        #region :: Auth_Selection :: MainForm의 조회 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 조회 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Auth_Selection(object sender, EventArgs e)
        {
            try
            {
                SetFormLayout();
                SetGridLayout();
                SelectionData();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Form의 Layout을 변경합니다.
        /// </summary>
        private void SetFormLayout()
        {
        }

        /// <summary>
        /// Grid의 Layout을 변경합니다.
        /// </summary>
        private void SetGridLayout()
        {
        }

        /// <summary>
        /// 조회 처리 Method
        /// </summary>
        private void SelectionData()
        {
            DataSet ds;

            const string queryId = @"dbo.AuthGroup_Select";

            var paramList = new string[] { "@USERID", "@GROUPNAME", "@RESTRICTIONFLAG", "@AUTHTYPE" };
            var valueList = new object[] { CurrentUser.USERID, txtGroupName.EditValue, 0, cboAuthType.EditText };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            }

            tlGroupAuthMenu.FillData();
            gridAuthGroupUser.FillData();
            gridAuthGroup.FillData(ds);
        }

        /// <summary>
        /// 권한 그룹 메뉴 조회 Method
        /// </summary>
        /// <param name="groupCode">권한그룹 코드</param>
        private void SelectionAuthGroupMenu(string groupCode)
        {
            DataSet ds;

            const string queryId = @"dbo.AuthGroupMenu_Select";

            string[] paramList = new string[] { "@GROUPCODE" };
            object[] valueList = new object[] { groupCode };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            }

            tlGroupAuthMenu.FillData(ds);
        }

        /// <summary>
        /// 권한 그룹 사용자 조회 Method
        /// </summary>
        /// <param name="groupCode">권한그룹 코드</param>
        private void SelectionAuthGroupUser(string groupCode)
        {
            DataSet ds;

            const string queryId = @"dbo.AuthGroupUser_Select";

            string[] paramList = new string[] { "@GROUPCODE", "@USERNAME" };
            object[] valueList = new object[] { groupCode, txtUserName.EditValue };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            }

            gridAuthGroupUser.FillData(ds);
        }

        #endregion

        #region :: Auth_New :: MainForm의 신규 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 신규 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Auth_New(object sender, EventArgs e)
        {
            try
            {
                NewData();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 신규 처리 Method
        /// </summary>
        private void NewData()
        {
            if (gridAuthGroup.IsFocused)         //권한 그룹은 ADMIN만 추가 가능
            {
                if (CurrentUser.ISADMIN)
                    viewAuthGroup.AddNewRow("GROUPCODE");
                else
                    ShowMsgBox("권한 그룹은 ADMIN 사용자만 가능합니다.");
            }
            else if (gridAuthGroupUser.IsFocused)
                viewAuthGroupUser.AddNewRow("USERNAME");
        }

        #endregion

        #region :: Auth_Save :: MainForm의 저장 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 저장 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Auth_Save(object sender, EventArgs e)
        {
            try
            {
                SaveData();
                SaveAuthGroupUser();
                SaveAuthGroupMenu();

                // 저장 후 조회를 실행해야 한다면 주석을 제거하세요.
                //RaiseSelectEvent();

                // 저장 후 DataTable에 변경사항만 처리할 경우 주석을 제거하세요(DB 접속 필요없을 경우)
                viewAuthGroup.AcceptChanges();
                viewAuthGroupUser.AcceptChanges();
                tlGroupAuthMenu.AcceptChanges();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 저장 처리 Method
        /// </summary>
        private void SaveData()
        {
            const string queryId = @"dbo.AuthGroup_Save";

            string[] paramList = new string[] { "@GROUPCODE",
                                                "@GROUPNAME",
                                                "@CHECKPROCESS",
                                                "@RESTRICTIONFLAG",
                                                "@DESCRIPTION",
                                                "@CHANGEBY",
                                                "@AUTHTYPE" };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                wb.Tx_ExecuteNonQuery(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, viewAuthGroup.GetAddedModifedData());
            }
        }

        /// <summary>
        /// 그룹 사용자 저장
        /// </summary>
        private void SaveAuthGroupUser()
        {
            const string queryId = @"dbo.AuthGroupUser_Save";

            string[] paramList = new string[] { "@GROUPCODE",
                                                "@USERID",
                                                "@ISDELEGATE",
                                                "@EXPIREDATE",
                                                "@CHANGEBY" };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                wb.Tx_ExecuteNonQuery(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, viewAuthGroupUser.GetAddedModifedData());
            }
        }

        /// <summary>
        /// 그룹별 권한 저장
        /// </summary>
        private void SaveAuthGroupMenu()
        {
            const string queryId = @"dbo.AuthGroupMenu_Save";

            string[] paramList = new string[] { "@ISAUTH",
                                                "@GROUPCODE",
                                                "@MENUID",
                                                "@SELECTAUTH",
                                                "@NEWAUTH",
                                                "@SAVEAUTH",
                                                "@DELAUTH",
                                                "@CHANGEBY" };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                wb.Tx_ExecuteNonQuery(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, tlGroupAuthMenu.GetAddedModifedData());
            }
        }

        #endregion

        #region :: Auth_Delete :: MainForm의 삭제 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 삭제 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Auth_Delete(object sender, EventArgs e)
        {
            try
            {
                DeleteData();
                DeleteAuthGroupUser();

                // 삭제 후 조회를 실행해야 한다면 주석을 제거하세요.
                //RaiseSelectEvent();

                // 삭제 후 Check 된 ROW 만 삭제하려면 주석을 제거하세요(DB 접속 필요없을 경우)
                viewAuthGroup.RemoveCheckedRow();
                viewAuthGroupUser.RemoveCheckedRow();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 삭제 처리 Method
        /// </summary>
        private void DeleteData()
        {
            const string queryId = @"dbo.AuthGroup_Delete";

            string[] paramList = new string[] { "@GROUPCODE" };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                wb.Tx_ExecuteNonQuery(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, viewAuthGroup.GetCheckedData());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void DeleteAuthGroupUser()
        {
            const string queryId = @"dbo.AuthGroupUser_Delete";

            string[] paramList = new string[] { "@GROUPCODE",
                                                "@USERID" };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                wb.Tx_ExecuteNonQuery(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, viewAuthGroupUser.GetCheckedData());
            }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler(Control Event)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: ComboBox_EditValueChanged :: ComboBox 값을 변경하면 발생합니다.

        /// <summary>
        /// ComboBox 값을 변경하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                // 여기에 코드를 입력합니다.
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        #region :: viewList_InitNewRow :: 신규로 생성되는 Row의 기본값을 정의합니다.

        /// <summary>
        /// 신규로 생성되는 Row의 기본값을 정의합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewList_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                if (sender.Equals(viewAuthGroup))
                {
                    viewAuthGroup.SetRowCellValue(e.RowHandle, "AUTHTYPE", cboAuthType.EditText == "" ? "SYS" : cboAuthType.EditText);
                    viewAuthGroup.SetRowCellValue(e.RowHandle, "GROUPCODE", "");
                    viewAuthGroup.SetRowCellValue(e.RowHandle, "GROUPNAME", "");
                    viewAuthGroup.SetRowCellValue(e.RowHandle, "CHECKPROCESS", 0);
                    viewAuthGroup.SetRowCellValue(e.RowHandle, "RESTRICTIONFLAG", 0);
                    viewAuthGroup.SetRowCellValue(e.RowHandle, "DESCRIPTION", "");
                }

                if (sender.Equals(viewAuthGroupUser))
                {
                    DataRow dr = viewAuthGroup.GetFocusedDataRow();

                    if (dr == null) return;

                    string groupcode = dr["GROUPCODE"].ToString();

                    viewAuthGroupUser.SetRowCellValue(e.RowHandle, "GROUPCODE", groupcode);
                    viewAuthGroupUser.SetRowCellValue(e.RowHandle, "USERID", "");
                    viewAuthGroupUser.SetRowCellValue(e.RowHandle, "USERNAME", "");
                    viewAuthGroupUser.SetRowCellValue(e.RowHandle, "DEPTNAME", "");
                    viewAuthGroupUser.SetRowCellValue(e.RowHandle, "EXPIREDATE", "2050-12-31 00:00:00");

                }
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        #region :: viewList_CustomRowCellEditForEditing :: 클릭하면 해당 CELL을 Combo로 표시합니다.

        /// <summary>
        /// 클릭하면 해당 CELL을 Combo로 표시합니다. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewList_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            try
            {
                //DataRow dr = viewList.GetFocusedDataRow();

                //if (dr == null || e.Column.FieldName != "COLUMNNAME") return;

                //string siteId = dr["COLUMN"].ToString();

                //e.RepositoryItem = ControlUtil.MakeComboBoxCell(MESCode.GetCodeMaster("C$", ""));
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        #region :: viewList_ShowingEditor :: 조건에 따라 셀 수정 여부를 지정합니다.

        /// <summary>
        /// 조건에 따라 셀 수정 여부를 지정합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewList_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                //if (viewList.FocusedColumn.FieldName != "COLUMNNAME") return;

                //string status = viewList.GetFocusedRowCellValue("STATUS").ToString();

                //if (status == "FN") e.Cancel = true;
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        #region :: viewList_FocusedRowChanged :: 선택한 Row가 변경되면 발생합니다.

        /// <summary>
        /// 선택한 Row가 변경되면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow dr = viewAuthGroup.GetFocusedDataRow();

                if (dr == null) return;

                viewAuthGroupUser.ViewCaption = String.Format("권한 GROUP 사용자 - [ {0} : {1} ]", dr["GROUPCODE"], dr["GROUPNAME"]);
                lcgMenu.Text = String.Format("그룹별 MENU 권한 - [ {0} : {1} ]", dr["GROUPCODE"], dr["GROUPNAME"]);

                string groupCode = dr["GROUPCODE"].ToString();
                string rest = dr["RESTRICTIONFLAG"].ToString();

                SelectionAuthGroupUser(groupCode);
                SelectionAuthGroupMenu(groupCode);

                if (rest == "True")
                    tlGroupAuthMenu.Enabled = false;
                else
                    tlGroupAuthMenu.Enabled = true;
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        #region :: viewList_CellValueChanged :: Grid 값이 변경되면 발생합니다.

        /// <summary>
        /// Grid 값이 변경되면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewList_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                //string fieldName = e.Column.FieldName;
                //if (fieldName == "FIELDNAME")
                //{
                //    DateTime birthDate = Convert.ToDateTime(e.Value);

                //    viewList.SetFocusedRowCellValue("AGE", (GetServerTime().Year - birthDate.Year) + 1);
                //}
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        #region :: viewAuthGroupUser_ButtonEditClick :: 권한그룹 사용자 명 입력시 사용자 사번, 부서명 가져오는 이벤트

        /// <summary>
        /// 권한그룹 사용자 명 입력시 사용자 사번, 부서명 가져오는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewAuthGroupUser_ButtonEditClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                string fieldName = viewAuthGroupUser.FocusedColumn.FieldName;

                if (fieldName.In("USERNAME", "USERID"))
                {
                    ParamCollection param = new ParamCollection();
                    param.Add("USERID", string.Empty);
                    param.Add("USERNAME", viewAuthGroupUser.GetFocusedRowCellValue("USERNAME"));

                    DataRow dr = ExecutePopup("User Info", "EBAP.UI.ADM.dll", "EBAP.UI.ADM.Popup.PopUserInfo", param) as DataRow;

                    if (dr == null)
                    {
                        ShowMsgBox("입력한 사용자 정보가 없어요. 확인하세요", "사용자 확인");
                        viewAuthGroupUser.CancelUpdateCurrentRow();
                    }
                    else
                    {
                        viewAuthGroupUser.SetFocusedRowCellValue("USERID", dr["USERID"]);
                        viewAuthGroupUser.SetFocusedRowCellValue("USERNAME", dr["USERNAME"]);
                        viewAuthGroupUser.SetFocusedRowCellValue("DEPTNAME", dr["DEPTNAME"]);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        #region :: tlGroupAuthMenu_CellValueChanged :: 조회, 신규, 저장, 삭제 권한 변경 시 하위 메뉴들과 함께 변경됩니다.

        /// <summary>
        /// 조회, 신규, 저장, 삭제 권한 변경 시 하위 메뉴들과 함께 변경됩니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlGroupAuthMenu_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            string fieldName = e.Column.FieldName;
            if (fieldName == "ISAUTH" || fieldName == "SELECTAUTH" || fieldName == "NEWAUTH" || fieldName == "SAVEAUTH" || fieldName == "DELAUTH")
            {
                ChangeChildCheckValue(e.Node.Nodes, fieldName, e.Value);
                ChangeParentCheckValue(e.Node, fieldName, e.Value);
            }
        }

        /// <summary>
        /// Tree의 Check 컬럼 Value를 변경합니다.
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="fieldName"></param>
        /// <param name="value"></param>
        private void ChangeChildCheckValue(TreeListNodes nodes, string fieldName, object value)
        {
            foreach (TreeListNode node in nodes)
            {
                DataRowView drv = tlGroupAuthMenu.GetDataRecordByNode(node) as DataRowView;

                if (drv == null) return;

                drv.Row[fieldName] = value;

                if (node.HasChildren) ChangeChildCheckValue(node.Nodes, fieldName, value);
            }
        }

        /// <summary>
        /// Tree의 Check 컬럼 Value를 변경합니다.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="fieldName"></param>
        /// <param name="value"></param>
        private void ChangeParentCheckValue(TreeListNode node, string fieldName, object value)
        {
            TreeListNode pNode = node.ParentNode;

            if (pNode == null) return;

            DataRowView drv = tlGroupAuthMenu.GetDataRecordByNode(pNode) as DataRowView;

            if (drv == null) return;

            if (value.ToString() == "False")
            {
                // 자식 Node 중에 하나라도 Check 된 것이 있으면 Return 한다.
                if (pNode.HasChildren)
                {
                    foreach (TreeListNode cnode in pNode.Nodes)
                    {
                        if (cnode.GetValue(fieldName).ToString() == "True") return;
                    }
                }
            }

            drv.Row[fieldName] = value;

            ChangeParentCheckValue(pNode, fieldName, value);
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////



        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Private)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        // Common Event 처리 Method 조건 Check

        #region :: CheckSelectionCondition :: 조회 조건 Check Method

        /// <summary>
        /// 조회 조건 Check Method
        /// </summary>
        /// <returns></returns>
        protected override bool CheckSelectionCondition()
        {
            return base.CheckSelectionCondition();
        }

        #endregion

        #region :: CheckNewCondition :: 신규 조건 Check Method

        /// <summary>
        /// 신규 조건 Check Method
        /// </summary>
        /// <returns></returns>
        protected override bool CheckNewCondition()
        {
            return base.CheckNewCondition();
        }

        #endregion

        #region :: CheckDeleteCondition :: 삭제 조건 Check Method

        /// <summary>
        /// 삭제 조건 Check Method
        /// </summary>
        /// <returns></returns>
        protected override bool CheckDeleteCondition()
        {
            //return true;

            return base.CheckDeleteCondition();
            //return base.CheckDeleteCondition(viewList.GetCheckedData());
        }

        #endregion

        #region :: CheckSaveCondition :: 저장 조건 Check Method

        /// <summary>
        /// 저장 조건 Check Method
        /// </summary>
        /// <returns></returns>
        protected override bool CheckSaveCondition()
        {
            //return true;

            return base.CheckSaveCondition();
            //return base.CheckSaveCondition(viewList.GetAddedModifedData());
        }

        #endregion
    }

    #endregion
}
