#region 어셈블리 EBAP.UI.ADM.Management, v3.17
// C:\EBAP.NET\EBAP.UI.ADM.dll
// CLR Version : 4.0.30319.36415
#endregion

using DevExpress.XtraGrid.Views.Grid;
using EBAP.Business.WSBiz;
using EBAP.Core;
using EBAP.Core.Collections;
using EBAP.Core.Info;
using EBAP.Core.Localization;
using EBAP.Core.Security;
using EBAP.Win.Utility;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace EBAP.UI.ADM.Management
{
    #region :: EBAP.UI.ADM.Management.UserMaster ::

    /// <summary>
    /// Form의 업무내용을 기술합니다.
    /// </summary>
    /// <remarks>
    /// Comment     : Form 기능 및 특이사항 기록
    ///               1.  
    ///               2. 
    /// History     :
    ///               1. (2018-04-10 오후 5:44:25 - 오인봉 - PC170245) : 최초 생성
    ///               2.
    ///               3.
    /// </remarks>
    public partial class UserMaster : EBAP.Win.BaseFrame.UIFrame
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// UserMaster Form을 생성합니다.
        /// </summary>
        public UserMaster()
        {
            InitializeComponent();

            AppConfig.CurrentDB = ConnectionString.METADB;
        }

        #endregion

        #region :: 전역변수 ::

        private readonly string SSISITE = "1031";
        private readonly string SSISYSTEMCODE = "O";
        private readonly int WINSOCKPORT = 15000;

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler(Common Event)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: UserMaster_Load :: Form이 Load 시 발생합니다.

        /// <summary>
        /// Form이 Load 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserMaster_Load(object sender, EventArgs e)
        {
            try
            {
                InitLocalization();
                InitGlobalInstance();
                InitComboBox();
                InitGridControl();
                InitControls();

                //Form Load 후 조회를 실행해야 한다면 주석을 제거하세요.
                //IsLoadSelectEvent = true;
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
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
            viewList.BeginInit();

            viewList.InitColumn(AppConfig.CHECKCOLUMNNAME, "Select", 60, 0, true, true, DataType.CheckEdit);
            viewList.InitColumn("USERID", "ID", 100, 0, false, true, DataType.LinkButton);
            viewList.InitColumn("USERNAME", "UserName", 120, 0, true, true);
            //viewList.InitColumn("EMPNO", "EmpNo", 80, 0, true, true);
            //viewList.InitColumn("GRADECODE", "GradeCode", 80, 0, true, true);
            //viewList.InitColumn("GRADENAME", "Grade", 120, 0, true, true);
            //viewList.InitColumn("DEPTCODE", "DeptCode", 100, 0, true, true);
            viewList.InitColumn("DEPTNAME", "DeptName", 160, 0, true, true);
            viewList.InitColumn("PHONE", "Phone", 90, 0, true, true);
            viewList.InitColumn("OFFICEPHONE", "OfficePhone", 90, 0, true, true);
            viewList.InitColumn("CELLPHONE", "CellPhone", 90, 0, true, true);
            viewList.InitColumn("EMAILADDRESS", "EMail", 180, 0, true, true);
            //viewList.InitColumn("SSOFLAG", "SSOFlag", 80, 0, false, false, DataType.CheckEdit);
            viewList.InitColumn("USEFLAG", "UseFlag", 80, 0, true, true, DataType.CheckEdit);
            viewList.InitColumn("LOCKFLAG", "LockFlag", 80, 0, false, false, DataType.CheckEdit);
            viewList.InitColumn("ADMINFLAG", "Admin Flag", 80, 0, CurrentUser.ISADMIN, true, DataType.CheckEdit);
            //viewList.InitColumn("SSOFLAG", "SSOFlag", 80, 0, false, true, DataType.CheckEdit);
            //viewList.InitColumn("EXTFLAG", "외주 사용자", 80, 0, true, true, DataType.CheckEdit);
            viewList.InitColumn("WORK", "AssignedTask", 250, 0, true, true);
            //viewList.InitColumn("EPID", "EPID", 120, 0, false, true, DataType.Default);
            //viewList.InitColumn("ENUSERID", "TPS ID", 120, 0, false, true, DataType.Default);
            viewList.InitColumn("LASTTIME", "최종 Login 시간", 130, 0, false, true, DataType.DateTime);
            viewList.InitColumn("CNT", "횟수", 60, 0, false, true, DataType.LinkButton, HorzAlign.Far);
            viewList.InitColumn("CHANGEBY", "ChangeBy", 80, 0, false, false);
            viewList.InitColumn("CHANGEDTTM", "ChangeDttm", 130, 0, false, false, DataType.DateTime, HorzAlign.Center);

            viewList.NewRowEnableColumns = new string[] { "USERID" };
            viewList.MandatoryColumns = new string[] { "USERID", "USERNAME" };
            viewList.KeyColumns = new string[] { "USERID" };

            viewList.SetFixedColumn("DEPTNAME");
            viewList.SetStyleFormatExpression("USERID", AppConfig.CONDITIONCOLOR, "[SSOFLAG] = 'True'", true);
            //viewList.SetStyleFormat("SSOFLAG", AppConfig.CONDITIONCOLOR, DevExpress.XtraGrid.FormatConditionEnum.Equal, 1, true);

            viewList.EndInit();
        }

        /// <summary>
        /// ComboBox Initialize
        /// </summary>
        private void InitComboBox()
        {

        }

        /// <summary>
        /// 기타 Control Initialize
        /// </summary>
        private void InitControls()
        {
            txtPwd.EditValue = "ebap" + GetCurrentTime().Year;
        }

        #endregion

        #region :: UserMaster_Link :: Form 간 Data 전송 시 발생합니다.

        /// <summary>
        /// Form 간 Data 전송 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserMaster_Link(object sender, EventArgs e)
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

        #region :: UserMaster_Selection :: MainForm의 조회 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 조회 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserMaster_Selection(object sender, EventArgs e)
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

            const string queryId = @"dbo.UserInfo_Select";

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, DatabaseParams);
            }

            gridList.FillData(ds);

            InitDataBindings(ds);
        }

        /// <summary>
        /// 컨트롤과 데이터를 바인딩합니다.
        /// </summary>
        private void InitDataBindings(DataSet ds)
        {
            DataTable dt = ds.Tables[0];

            txtUserId.BindingMapping(dt, "USERID");
            txtUserName.BindingMapping(dt, "USERNAME");
            txtEmpNo.BindingMapping(dt, "EMPNO");
            txtEmail.BindingMapping(dt, "EMAILADDRESS");
            txtGradeCode.BindingMapping(dt, "GRADECODE");
            txtGradeName.BindingMapping(dt, "GRADENAME");
            txtDeptCode.BindingMapping(dt, "DEPTCODE");
            txtDeptName.BindingMapping(dt, "DEPTNAME");
            txtPhone.BindingMapping(dt, "PHONE");
            txtOfficePhone.BindingMapping(dt, "OFFICEPHONE");
            txtCellPhone.BindingMapping(dt, "CELLPHONE");
            txtResponsibleWork.BindingMapping(dt, "WORK");
            chkUseFlag.BindingMapping(dt, "USEFLAG");

            chkLockFlag.BindingMapping(dt, "LOCKFLAG");
            chkAdminFlag.BindingMapping(dt, "ADMINFLAG");
            //chkSSOFlag.BindingMapping(dt, "SSOFLAG");
            //chkExtFlag.BindingMapping(dt, "EXTFLAG");
        }

        #endregion

        #region :: UserMaster_New :: MainForm의 신규 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 신규 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserMaster_New(object sender, EventArgs e)
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
            viewList.AddNewRow("USERID");
        }

        #endregion

        #region :: UserMaster_Save :: MainForm의 저장 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 저장 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserMaster_Save(object sender, EventArgs e)
        {
            try
            {
                SaveData();

                // 저장 후 조회를 실행해야 한다면 주석을 제거하세요.
                //RaiseSelectEvent();

                // 저장 후 DataTable에 변경사항만 처리할 경우 주석을 제거하세요(DB 접속 필요없을 경우)
                viewList.AcceptChanges();
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
            string queryId = @"dbo.UserInfo_Save";

            string[] paramList = new string[] { "@USERID",
                                                "@USERNAME",
                                                "@EMPNO",
                                                "@GRADECODE",
                                                "@GRADENAME",
                                                "@DEPTCODE",
                                                "@DEPTNAME",
                                                "@WORK",
                                                "@PHONE",
                                                "@OFFICEPHONE",
                                                "@CELLPHONE",
                                                "@EMAILADDRESS",
                                                "@USEFLAG",
                                                "@LOCKFLAG",
                                                "@ADMINFLAG",
                                                "@EXTFLAG",
                                                "@CHANGEBY" };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                wb.Tx_ExecuteNonQuery(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, viewList.GetAddedModifedData());
            }
        }

        #endregion

        #region :: UserMaster_Delete :: MainForm의 삭제 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 삭제 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserMaster_Delete(object sender, EventArgs e)
        {
            try
            {
                DeleteData();

                // 삭제 후 조회를 실행해야 한다면 주석을 제거하세요.
                //RaiseSelectEvent();

                // 삭제 후 Check 된 ROW 만 삭제하려면 주석을 제거하세요(DB 접속 필요없을 경우)
                viewList.RemoveCheckedRow();
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
            //const string queryId = @"dbo.";

            //string[] paramList = new string[] { "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "@VENDORCODE",
            //                                    "@PLANT" };

            //object[] valueList = new object[] { "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    CurrentUser.VENDORCODE,
            //                                    CurrentUser.PLANTCODE };

            //using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            //{
            //    wb.Tx_ExecuteNonQuery(ConnectionString.MESDB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            //    wb.Tx_ExecuteNonQuery(ConnectionString.MESDB, queryId, AppConfig.COMMANDSP, paramList, viewList.GetCheckedData());
            //    wb.Tx_ExecuteNonQueryFromQueryId(queryId, paramList, valueList);
            //    wb.Tx_ExecuteNonQueryFromQueryId(queryId, paramList, viewList.GetAddedModifedData());
            //}
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler(Control Event)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: btnResetPwd_Click :: 선택한 사용자의 비밀번호를 초기화합니다.

        /// <summary>
        /// 선택한 사용자의 비밀번호를 초기화합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResetPwd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckChangeCondition()) return;
                InitUserPassword();

                ShowMsgBox(String.Format("{0}", LOCALECONVERTER.GetLocaleMessage("OK_PROCESS")));
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool CheckChangeCondition()
        {
            return ShowMsgBox("선택한 사용자의 비밀번호를 변경 하시겠습니까?", "확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? true : false;
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitUserPassword()
        {
            const string queryId = @"dbo.UserInfo_ChangePassword";

            string[] paramList = new string[] { "@USERID",
                                                "@NEWPASSWORD",
                                                "@SHAPASSWORD",
                                                "@ENUSERID" };

            DataTable dt = viewList.GetCheckedData();
            dt.AddColumnWithValue(new string[] { "NEWPASSWORD", "SHAPASSWORD", "ENUSERID" }, new object[] { txtPwdEncrypt.TrimText, txtPwdSHA.TrimText, "" });

            foreach (DataRow dr in dt.Rows)
            {
                dr["ENUSERID"] = Cryptography.GetMD5Hash(String.Format("DJ{0}", dr["USERID"]));
            }

            dt.AcceptChanges();

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                wb.Tx_ExecuteNonQuery(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, dt);
            }
        }

        private void btnTPSID_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckTPSIDCondition()) return;
                CreateTPSID();

                ShowMsgBox(String.Format("{0}", LOCALECONVERTER.GetLocaleMessage("OK_PROCESS")));
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool CheckTPSIDCondition()
        {
            return ShowMsgBox("선택한 사용자의 TPS ID를 생성 하시겠습니까?", "확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? true : false;
        }

        /// <summary>
        /// 
        /// </summary>
        private void CreateTPSID()
        {
            const string queryId = @"dbo.UserInfo_TPSIDCreate";

            string[] paramList = new string[] { "@USERID",
                                                "@ENUSERID" };

            DataTable dt = viewList.GetCheckedData();
            dt.AddColumnWithValue(new string[] { "ENUSERID" }, new object[] { "" });

            foreach (DataRow dr in dt.Rows)
            {
                dr["ENUSERID"] = Cryptography.GetMD5Hash(String.Format("DJ{0}", dr["USERID"]));
            }

            dt.AcceptChanges();

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                wb.Tx_ExecuteNonQuery(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, dt);
            }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApproval_Click(object sender, EventArgs e)
        {
            ParamCollection param = new ParamCollection();
            param.Add("HTMLID", "RACB001");

            ExecutePopup("Approval", "EBAP.UI.ADM.dll", "EBAP.UI.ADM.Popup.PopApproval", param);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcelUpload_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable edt = AppUtil.GetExcelUploadData("Sheet");
                //DataTable edt = AppUtil.GetCVSUploadData();

                if (edt == null) return;

                gridList.FillData();

                DataTable dt = viewList.GetDataTableByDataSource();

                DataRow dr = null;
                ShowWaitDialog("엑셀데이터 복사 중입니다.");
                int i = 1;
                foreach (DataRow edr in edt.Rows)
                {
                    ShowWaitDialog("엑셀데이터 복사 중입니다.", string.Format("{0} 번째 데이터", i++));
                    dr = dt.NewRow();

                    dr["USERID"] = edr[1];
                    dr["EMPNO"] = edr[1];
                    dr["USERNAME"] = edr[0];
                    dr["DEPTNAME"] = edr[3];
                    dr["GRADENAME"] = edr[3];

                    dr["USEFLAG"] = true;
                    dr["LOCKFLAG"] = false;
                    dr["ADMINFLAG"] = false;
                    dr["SSOFLAG"] = false;
                    dr["EXTFLAG"] = true;
                    //dr["CHANGEBY"] = CurrentUser.USERID;
                    viewList.AddDataRow(dr);
                    //if (!viewList.Validate("", true))
                    //    dr.Delete();
                }
                CloseWaitDialog();
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

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
                viewList.SetRowCellValue(e.RowHandle, "USEFLAG", true);
                viewList.SetRowCellValue(e.RowHandle, "LOCKFLAG", false);
                viewList.SetRowCellValue(e.RowHandle, "ADMINFLAG", false);
                viewList.SetRowCellValue(e.RowHandle, "SSOFLAG", false);
                viewList.SetRowCellValue(e.RowHandle, "EXTFLAG", false);
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        #region :: txtPwd_EditValueChanged :: 변경할 비밀번호를 입력하면 암호화된 비밀번호가 표시됩니다.

        /// <summary>
        /// 변경할 비밀번호를 입력하면 암호화된 비밀번호가 표시됩니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPwd_EditValueChanged(object sender, EventArgs e)
        {
            string pwd = txtPwd.TrimText;
            txtPwdEncrypt.EditValue = Cryptography.GetMD5Hash(pwd);
            txtPwdSHA.EditValue = Cryptography.GetSHA256Hash(pwd);
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
                string fieldname = viewList.FocusedColumn.FieldName;
                if (fieldname == "USEFLAG" || fieldname == "LOCKFLAG" || fieldname == "ADMINFLAG" || fieldname == "WORK" || fieldname == "EXTFLAG" || fieldname == AppConfig.CHECKCOLUMNNAME) return;

                string status = viewList.GetFocusedRowCellValue("SSOFLAG").ToString();

                if (status == "True") e.Cancel = true;
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        /// <summary>
        /// 컨트롤의 Read Only 속성을 변경합니다.
        /// </summary>
        private void SetEditorReadonly(bool read)
        {
            txtUserName.ReadOnly = read;
            txtEmpNo.ReadOnly = read;
            txtEmail.ReadOnly = read;
            txtGradeCode.ReadOnly = read;
            txtGradeName.ReadOnly = read;
            txtDeptCode.ReadOnly = read;
            txtDeptName.ReadOnly = read;
            txtPhone.ReadOnly = read;
            txtOfficePhone.ReadOnly = read;
            txtCellPhone.ReadOnly = read;
            //chkSSOFlag.ReadOnly = true;
            //chkExtFlag.ReadOnly = read;
            //txtResponsibleWork.ReadOnly = read;
        }

        #endregion

        #region :: viewList_DoubleClick :: 사용자 ID를 더블클릭하면 사용자 정보 화면으로 이동합니다.

        /// <summary>
        /// 사용자 ID를 더블클릭하면 사용자 정보 화면으로 이동합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = viewList.GetFocusedDataRow();

                if (dr == null) return;

                string fieldName = viewList.FocusedColumn.FieldName;

                ParamCollection linkParam = new ParamCollection();

                if (fieldName == "USERID")
                {
                    linkParam.Add("USERID", dr["USERID"]);

                    ExecuteUI("CMN02", linkParam);
                }
                else if (fieldName == "CNT")
                {
                    linkParam.Add("USERID", dr["USERID"]);
                    linkParam.Add("USERNAME", dr["USERNAME"]);

                    ExecuteUI("SYS090101", linkParam);
                }
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
                DataRow dr = viewList.GetFocusedDataRow();

                if (dr == null) return;

                string status = dr["SSOFLAG"].ToString();

                if (status == "") return;

                SetEditorReadonly(Convert.ToBoolean(status));
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

        #region :: btnNewUser_Click :: 외주 신규 사용자를 등록합니다.

        /// <summary>
        /// 외주 신규 사용자를 등록합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewUser_Click(object sender, EventArgs e)
        {
            try
            {
                //if (ShowMsgBox("외주직원 신규 등록 작업을 계속 진행하시겠습니까?", "외주직원 신규등록", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

                string command = String.Format("New {0} {1} NewId Y {2}", SSISYSTEMCODE, SSISITE, GetLanguage());

                CallSSIMain(command);
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        private string GetLanguage()
        {
            string lang = "";

            switch (CurrentUser.CURRENTLANGUAGE)
            {
                case "ko-KR":
                    lang = "KOR";
                    break;
                case "en-US":
                    lang = "ENG";
                    break;
                case "zh-CHS":
                    lang = "CHI";
                    break;
                default:
                    lang = "KOR";
                    break;
            }

            return lang;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        private void CallSSIMain(string command)
        {
            string ssiPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), @"SSILogin\SSILogin.exe");
            //SSIPrgPath = "C:\\Program Files\\SSILogin\\SSILogin.exe";
            string ssiArgument = String.Format("{0} {1}", command, WINSOCKPORT);
            try
            {
                Process.Start(ssiPath, ssiArgument);
            }
            catch
            {
                ShowFlyoutDialog("파일 확인", "싱글게시판 > 세종사업장공지 > 제목에 SSI 라고 조회하시면 Setup 파일을 찾을 수 있습니다. 설치하시기 바랍니다.");
            }
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
