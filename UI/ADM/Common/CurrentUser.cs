using DevExpress.XtraGrid.Views.Grid;
using EBAP.Business.WSBiz;
using EBAP.Core.Info;
using EBAP.Core.Security;
using EBAP.Win.ControlLibrary;
using EBAP.Win.Utility;
using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace EBAP.UI.ADM.Common
{
    /// <summary>
    /// 현재 사용자의 정보 조회를 담당하는 Form 입니다.
    /// </summary>
    /// <remarks>
    /// (2016-07-04) 최초생성 : 오인봉
    /// 변경내역
    /// 
    /// </remarks>
    public partial class CurrentUser : EBAP.Win.BaseFrame.UIFrame
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// CurrentUserInformation Form을 생성합니다.
        /// </summary>
        public CurrentUser()
        {
            InitializeComponent();

            AppConfig.CurrentDB = ConnectionString.METADB;
        }

        #endregion

        #region :: 전역변수 ::


        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////




        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler(Common Event)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: CurrentUser_Load :: Form이 Load 시 발생합니다.

        /// <summary>
        /// Form이 Load 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentUser_Load(object sender, EventArgs e)
        {
            try
            {
                InitLocalization();
                InitGlobalInstance();
                InitGridControl();
                InitComboBox();
                InitControls();

                // Form Load 후 조회를 실행해야 한다면 주석을 제거하세요.
                IsLoadSelectEvent = true;
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        #region :: CurrentUser_Authentication :: 사용자 권한 처리 시 발생합니다.

        /// <summary>
        /// 사용자 권한 처리 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentUser_Authentication(object sender, EventArgs e)
        {
            try
            {
                UserAuthProcess();
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region :: CurrentUser_Link :: Form 간 Data 전송 시 발생합니다.

        /// <summary>
        /// Form 간 Data 전송 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentUser_Link(object sender, EventArgs e)
        {
            try
            {
                LinkData();
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region :: CurrentUser_Selection :: MainForm의 조회 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 조회 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentUser_Selection(object sender, EventArgs e)
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

        #endregion

        #region :: CurrentUser_New :: MainForm의 신규 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 신규 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentUser_New(object sender, EventArgs e)
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

        #endregion

        #region :: CurrentUser_Delete :: MainForm의 삭제 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 삭제 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentUser_Delete(object sender, EventArgs e)
        {
            try
            {
                DeleteData();

                // 삭제 후 조회를 실행해야 한다면 주석을 제거하세요.
                //RaiseSelectEvent();

                // 삭제 후 Check 된 ROW 만 삭제하려면 주석을 제거하세요(DB 접속 필요없을 경우)
                //pGridView1.RemoveCheckedRow();
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region :: CurrentUser_Save :: MainForm의 저장 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 저장 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentUser_Save(object sender, EventArgs e)
        {
            try
            {
                SaveData();

                // 저장 후 조회를 실행해야 한다면 주석을 제거하세요.
                //RaiseSelectEvent();

                // 저장 후 DataTable에 변경사항만 처리할 경우 주석을 제거하세요(DB 접속 필요없을 경우)
                //pGridView1.AcceptChanges();
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region :: CurrentUser_Print :: MainForm의 인쇄 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 인쇄 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentUser_Print(object sender, EventArgs e)
        {
            try
            {
                if (!CheckPrintCondition()) return;

                PrintData();
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region :: CurrentUser_Chart :: MainForm의 Chart Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 Chart Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentUser_Chart(object sender, EventArgs e)
        {
            try
            {
                if (!CheckChartCondition()) return;

                ChartData();
            }
            catch
            {
                throw;
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

        #region :: GridView_InitNewRow :: 신규로 생성되는 Row의 기본값을 정의합니다.

        /// <summary>
        /// 신규로 생성되는 Row의 기본값을 정의합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                //pGridView1.SetRowCellValue(e.RowHandle, "VendorCode", CurrentUser.VendorCode);
                //pGridView1.SetRowCellValue(e.RowHandle, "PlantCode", CurrentUser.PlantCode);
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        #region :: btnDeleteSMenu_Click :: 선택한 시작 메뉴를 삭제합니다.

        /// <summary>
        /// 선택한 시작 메뉴를 삭제합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteSMenu_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = lbStartMenu.GetDataTableByDataSource();
                DataRow dr = dt.Rows[lbStartMenu.SelectedIndex];

                if (dr == null) return;

                btnDeleteSMenu.IsValid = CheckDeleteMenu(lbStartMenu, dr[AppConfig.DISPLAYMEMBER].ToString(), "시작 메뉴");
                if (!btnDeleteSMenu.IsValid) return;

                DeleteMyMenu(dr[AppConfig.VALUEMEMBER].ToString(), "S");

                dt.Rows.Remove(dr);
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        #region :: btnDeleteShortCut_Click :: 선택한 바로가기를 삭제합니다.

        /// <summary>
        /// 선택한 바로가기를 삭제합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteShortCut_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = lbShortCut.GetDataTableByDataSource();
                DataRow dr = dt.Rows[lbShortCut.SelectedIndex];

                if (dr == null) return;

                btnDeleteShortCut.IsValid = CheckDeleteMenu(lbShortCut, dr[AppConfig.DISPLAYMEMBER].ToString(), "바로가기 메뉴");
                if (!btnDeleteShortCut.IsValid) return;

                DeleteMyMenu(dr[AppConfig.VALUEMEMBER].ToString(), "T");

                dt.Rows.Remove(dr);

            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        #region :: btnDeleteFMenu_Click ::

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteFMenu_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = lbFavoritesMenu.GetDataTableByDataSource();
                DataRow dr = dt.Rows[lbFavoritesMenu.SelectedIndex];

                if (dr == null) return;

                btnDeleteFMenu.IsValid = CheckDeleteMenu(lbFavoritesMenu, dr[AppConfig.DISPLAYMEMBER].ToString(), "즐겨찾기 메뉴");
                if (!btnDeleteFMenu.IsValid) return;

                DeleteMyMenu(dr[AppConfig.VALUEMEMBER].ToString(), "F");

                dt.Rows.Remove(dr);
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listBox"></param>
        /// <param name="menuName"></param>
        /// <param name="gubun"></param>
        /// <returns></returns>
        private bool CheckDeleteMenu(PListBoxControl listBox, string menuName, string gubun)
        {
            if (listBox.SelectedIndex < 0)
            {
                ShowMsgBox(String.Format("삭제할 [ {0} ]를 선택하세요.", gubun));
                return false;
            }
            return DialogResult.Yes == ShowMsgBox(string.Format("선택한 {1} [ {0} ]를 삭제할까요?", menuName, gubun), "삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuid"></param>
        /// <param name="gubun"></param>
        private void DeleteMyMenu(string menuid, string gubun)
        {
            const string queryId = @"dbo.MyMenu_Delete";

            string[] paramList = new string[] { "@USERID",
                                                "@MENUID",
                                                "@GUBUN",
                                                "@IPADDRESS" };

            object[] valueList = new object[] { txtUserId.EditValue,
                                                menuid,
                                                gubun,
                                                CurrentUser.IP };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                wb.Tx_ExecuteNonQuery(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            }
        }

        #endregion

        #region :: btnChangePwd_Click :: 비밀번호를 변경합니다.

        /// <summary>
        /// 비밀번호를 변경합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangePwd_Click(object sender, EventArgs e)
        {
            try
            {
                btnChangePwd.IsValid = CheckChangePassword();

                if (!btnChangePwd.IsValid) return;

                int rlt = ChangePassword();

                if (rlt < 0)
                {
                    btnChangePwd.IsValid = false;
                    ShowMsgBox("사용자 정보에 이상이 있습니다. 확인하세요");
                    return;
                }

                txtCurrentPwd.Text = string.Empty;
                txtPwd.Text = string.Empty;
                txtConfirmPwd.Text = string.Empty;

                Win32Util.SetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "LASTLOGINPWD", "");

                RaiseSelectEvent();
            }
            catch (Exception ex)
            {
                btnChangePwd.IsValid = false;
                ShowExceptionBox(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool CheckChangePassword()
        {
            if (!CurrentUser.ISSSO)
            {
                if (!Cryptography.ValidateSHA256Hash(txtCurrentPwd.Text, txtEncriptPwd.Text))
                {
                    ShowMsgBox("현재 비밀번호를 확인하세요", "확인");
                    txtCurrentPwd.Select();
                    return false;
                }
            }
            if (txtPwd.Text.Trim() == string.Empty)
            {
                ShowMsgBox("새 비밀번호를 입력하세요.", "확인");
                txtPwd.Select();
                return false;
            }
            if (txtConfirmPwd.Text.Trim() == string.Empty)
            {
                ShowMsgBox("새 비밀번호 확인을 입력하세요.", "확인");
                txtConfirmPwd.Select();
                return false;
            }
            if (txtPwd.Text != txtConfirmPwd.Text)
            {
                ShowMsgBox("새 비밀번호와 새 비밀번호 확인이 달라요. 확인하세요", "확인");
                txtPwd.Select();
                return false;
            }
            if (!CheckPWDLength())
            {
                return false;
            }

            return DialogResult.Yes == ShowMsgBox("비밀번호를 변경할까요?", "변경 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private bool CheckPWDLength()
        {
            string pwd = txtConfirmPwd.TrimText;
            string strPattern = "";

            int includeNumber = 0; // 숫자 포함 체크
            int includeAlphbet = 0; // 알파벳 포함 체크
            int includeSpecialChar = 0; // 특수문자 포함 체크

            System.Text.RegularExpressions.Regex regex = null;

            // 특수문자가 있는지 검사
            strPattern = @"[!@#$%^&*()_+=\[{\]};:<>|./?,-]";
            regex = new System.Text.RegularExpressions.Regex(strPattern);
            includeSpecialChar = regex.IsMatch(pwd) ? 1 : 0;

            // 숫자가 있는지 검사
            strPattern = @"[0-9]+";
            regex = new System.Text.RegularExpressions.Regex(strPattern);
            includeNumber = regex.IsMatch(pwd) ? 1 : 0;

            // 알파벳 - 대문자구분
            strPattern = @"[A-Z]+";
            regex = new System.Text.RegularExpressions.Regex(strPattern);
            includeAlphbet = regex.IsMatch(pwd) ? 1 : 0;

            // 알파벳 - 소문자구분
            strPattern = @"[a-z]+";
            regex = new System.Text.RegularExpressions.Regex(strPattern);
            includeAlphbet = regex.IsMatch(pwd) ? 1 : 0;

            int sumPattern = includeSpecialChar + includeNumber + includeAlphbet;

            if (sumPattern < 1)
            {
                ShowMsgBox("비밀번호는 영문, 숫자, 특수문자를 조합해야 합니다.");
                return false;
            }
            else if (sumPattern < 3)
            {
                if (pwd.Length < 10)
                {
                    ShowMsgBox("비밀번호는 10자리 이상으로 입력하세요.");
                    return false;
                }
            }
            else if (sumPattern < 4)
            {
                if (pwd.Length < 8)
                {
                    ShowMsgBox("비밀번호는 8자리 이상으로 입력하세요.");
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        private int ChangePassword()
        {
            const string queryId = @"dbo.UserInfo_ChangePassword";

            string[] paramList = new string[] { "@USERID",
                                                "@NEWPASSWORD",
                                                "@SHAPASSWORD",
                                                "@ENUSERID",
                                                "@EPID" };

            object[] valueList = new object[] { CurrentUser.USERID,
                                                Cryptography.GetMD5Hash(txtPwd.Text),
                                                Cryptography.GetSHA256Hash(txtPwd.Text),
                                                Cryptography.GetMD5Hash(String.Format("DJ{0}", txtUserId.TrimText)),
                                                CurrentUser.EPID };
            int rlt = 0;
            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                rlt = wb.Tx_ExecuteNonQuery(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            }

            return rlt;
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////



        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Private)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        // Initialize 관련 Method

        #region :: InitLocalization :: 다국어 Initialize

        /// <summary>
        /// 다국어 Initialize
        /// </summary>
        private void InitLocalization()
        {
            // localizer 를 사용하세요.
        }

        #endregion

        #region :: InitGlobalInstance :: 전역변수 Initialize

        /// <summary>
        /// 전역변수 Initialize
        /// </summary>
        private void InitGlobalInstance()
        {
        }

        #endregion

        #region :: InitGridControl :: Grid Control Initialize

        /// <summary>
        /// Grid Control Initialize
        /// </summary>
        private void InitGridControl()
        {
            viewAuthGroup.BeginInit();

            viewAuthGroup.InitColumn("GROUPCODE", "GroupCode", 120, 0, false, true);
            viewAuthGroup.InitColumn("GROUPNAME", "GroupName", 200, 0, false, true);
            viewAuthGroup.InitColumn("DESCRIPTION", "Description", 250, 0, false, true, DataType.Default);
            viewAuthGroup.InitColumn("EXPIREDATE", "ExpireDate", 110, 0, false, true, DataType.Date, HorzAlign.Center);
            viewAuthGroup.InitColumn("RESTRICTIONFLAG", "예외권한", 80, 0, false, true, DataType.CheckEdit);
            viewAuthGroup.InitColumn("ISDELEGATE", "권한부여", 80, 0, false, true, DataType.CheckEdit);

            viewAuthGroup.EndInit();


            viewVendorAuth.BeginInit();

            viewVendorAuth.InitColumn("VENDORCODE", "VendorCode", 120, 0, false, true);
            viewVendorAuth.InitColumn("VENDORNAME", "Vendor", 200, 0, false, true);
            viewVendorAuth.InitColumn("EXPIREDATE", "ExpireDate", 110, 0, false, true, DataType.Date, HorzAlign.Center);
            viewVendorAuth.InitColumn("ISDELEGATE", "권한부여", 80, 0, false, true, DataType.CheckEdit);

            viewVendorAuth.EndInit();
        }

        #endregion

        #region :: InitComboBox :: ComboBox Initialize

        /// <summary>
        /// ComboBox Initialize
        /// </summary>
        private void InitComboBox()
        {

        }

        #endregion

        #region :: InitControls :: 기타 Control Initialize

        /// <summary>
        /// 기타 Control Initialize
        /// </summary>
        private void InitControls()
        {
            txtSearchUserId.Properties.ReadOnly = !CurrentUser.ISADMIN;

            txtSearchUserId.EditValue = CurrentUser.USERID;

            txtIP.EditValue = CurrentUser.IP;
        }

        #endregion

        // 사용자 권한 처리 Method

        #region :: UserAuthProcess :: 사용자 권한 처리

        /// <summary>
        /// 사용자 권한 처리
        /// </summary>
        private void UserAuthProcess()
        {
        }

        #endregion

        // Form 간 Data 전송 처리 Method

        #region :: LinkData :: Form 간 Data 전송 처리

        /// <summary>
        /// Form 간 Data 전송 처리
        /// </summary>
        private void LinkData()
        {
            txtSearchUserId.EditValue = LinkParams["USERID"];
        }

        #endregion

        // Common Event 처리 Method

        #region :: SelectionData :: 조회 처리 Method

        /// <summary>
        /// 조회 처리 Method
        /// </summary>
        private void SelectionData()
        {
            InitEditValue();

            DataSet ds;

            const string queryId = @"dbo.CurrentUserInfo_Select";

            string[] paramList = new string[] { "@USERID" };

            object[] valueList = new object[] { txtSearchUserId.EditValue };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            }

            gridAuthGroup.FillData(ds);

            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0) return;

            InitUserInfo(ds.Tables[0].Rows[0]);

            gridAuthGroup.FillData(ds, "Table1");

            lbStartMenu.InitData(ds.Tables[2]);
            lbFavoritesMenu.InitData(ds.Tables[3]);
            lbShortCut.InitData(ds.Tables[4]);
            gridVendorAuth.FillData(ds.Tables[5]);
        }

        /// <summary>
        /// 사용자 정보 Setting
        /// </summary>
        /// <param name="dr"></param>
        private void InitUserInfo(DataRow dr)
        {
            txtUserId.EditValue = dr["USERID"];
            txtUserName.EditValue = dr["USERNAME"];
            txtDeptCode.EditValue = dr["DEPTCODE"];
            txtDeptName.EditValue = dr["DEPTNAME"];
            txtWork.EditValue = dr["WORK"];
            txtPhone.EditValue = dr["PHONE"];
            txtOfficePhone.EditValue = dr["OFFICEPHONE"];
            txtCellPhone.EditValue = dr["CELLPHONE"];
            txtEmail.EditValue = dr["EMAILADDRESS"];
            chkAdminFlag.EditValue = dr["ADMINFLAG"];

            txtEncriptPwd.EditValue = dr["PWD"];
            txtMsgKey.EditValue = dr["MSGKEY"];

            bool ssoFlag = Convert.ToBoolean(dr["SSOFLAG"]) || CurrentUser.USERID != txtUserId.EditValue.ToString();

            //btnChangePwd.Enabled = !ssoFlag;
            //txtCurrentPwd.ReadOnly = ssoFlag;
            //txtPwd.ReadOnly = ssoFlag;
            //txtConfirmPwd.ReadOnly = ssoFlag;

            txtUserId.Properties.ReadOnly = ssoFlag;
            txtUserName.Properties.ReadOnly = ssoFlag;
            chkAdminFlag.Properties.ReadOnly = ssoFlag;
            txtEmail.Properties.ReadOnly = ssoFlag;
            txtPhone.Properties.ReadOnly = ssoFlag;
            txtDeptName.Properties.ReadOnly = ssoFlag;
            txtDeptCode.Properties.ReadOnly = ssoFlag;
            txtOfficePhone.Properties.ReadOnly = ssoFlag;
            txtCellPhone.Properties.ReadOnly = ssoFlag;
            txtWork.Properties.ReadOnly = ssoFlag;
        }

        #endregion

        #region :: NewData :: 신규 처리 Method

        /// <summary>
        /// 신규 처리 Method
        /// </summary>
        private void NewData()
        {
            //pGridView1.AddNewRow();
        }

        #endregion

        #region :: DeleteData :: 삭제 처리 Method

        /// <summary>
        /// 삭제 처리 Method
        /// </summary>
        private void DeleteData()
        {
            //string query = "dbo.DeleteProcedure_Name";

            //string[] paramList = new string[] { "@VendorCode",
            //                                    "@Plant" };

            //object[] valueList = new object[] { CurrentUser.VendorCode,
            //                                    CurrentUser.PlantCode };

            //using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            //{
            //   wb.Tx_ExecuteNonQuery(JIGDB, query, AppConfig.COMMANDSP, paramList, valueList);
            //}
        }

        #endregion

        #region :: SaveData :: 저장 처리 Method

        /// <summary>
        /// 저장 처리 Method
        /// </summary>
        private void SaveData()
        {
            string pwd;

            if (txtPwd.EditValue.ToString() == string.Empty || txtConfirmPwd.EditValue.ToString() == string.Empty)
                pwd = String.Empty;
            else
                pwd = Cryptography.GetMD5Hash(txtPwd.EditValue.ToString());

            const string queryId = @"dbo.CurrentUserInfo_Save";

            string[] paramList = new string[] { "@USERID",
                                                "@USERNAME",
                                                "@DEPTCODE",
                                                "@DEPTNAME",
                                                "@WORK",
                                                "@PHONE",
                                                "@OFFICEPHONE",
                                                "@CELLPHONE",
                                                "@EMAILADDRESS",
                                                "@PASSWORD",
                                                "@CHANGEBY" };

            object[] valueList = new object[] { txtUserId.EditValue,
                                                txtUserName.EditValue,
                                                txtDeptCode.EditValue.ToString(),
                                                txtDeptName.EditValue.ToString(),
                                                txtWork.EditValue.ToString(),
                                                txtPhone.EditValue.ToString(),
                                                txtOfficePhone.EditValue.ToString(),
                                                txtCellPhone.EditValue.ToString(),
                                                txtEmail.EditValue.ToString(),
                                                pwd,
                                                CurrentUser.USERID };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                wb.Tx_ExecuteNonQuery(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            }
        }

        #endregion

        #region :: PrintData :: 인쇄 처리 Method

        /// <summary>
        /// 인쇄 처리 Method
        /// </summary>
        private void PrintData()
        {
        }

        #endregion

        #region :: ChartData :: Chart 처리 Method

        /// <summary>
        /// Chart 처리 Method
        /// </summary>
        private void ChartData()
        {
        }

        #endregion


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
            return base.CheckDeleteCondition();

            //return true;
        }

        #endregion

        #region :: CheckSaveCondition :: 저장 조건 Check Method

        /// <summary>
        /// 저장 조건 Check Method
        /// </summary>
        /// <returns></returns>
        protected override bool CheckSaveCondition()
        {
            return base.CheckSaveCondition();
        }

        #endregion

        #region :: CheckPrintCondition :: 인쇄 조건 Check Method

        /// <summary>
        /// 인쇄 조건 Check Method
        /// </summary>
        /// <returns></returns>
        private bool CheckPrintCondition()
        {
            return true;
        }

        #endregion


        // 기타 Control Event 처리 Method는 아래에 기술하세요.

        #region :: SetFormLayout :: Form의 Layout을 변경합니다.

        /// <summary>
        /// Form의 Layout을 변경합니다.
        /// </summary>
        private void SetFormLayout()
        {
        }

        #endregion

        #region :: SetGridLayout :: Grid의 Layout을 변경합니다.

        /// <summary>
        /// Grid의 Layout을 변경합니다.
        /// </summary>
        private void SetGridLayout()
        {
        }

        #endregion

        private void btnCapicom_Click(object sender, EventArgs e)
        {
            try
            {
                string batchFileName = @"cmd.exe";

                ProcessStartInfo psInfo = new ProcessStartInfo(batchFileName);
                psInfo.RedirectStandardInput = true;
                psInfo.RedirectStandardOutput = true;
                psInfo.RedirectStandardError = true;
                psInfo.CreateNoWindow = true;
                psInfo.UseShellExecute = false;

                Process p = Process.Start(psInfo);
                System.IO.StreamWriter SW = p.StandardInput;
                System.IO.StreamReader SR = p.StandardOutput;
                SW.WriteLine(@"regsvr32 C:\EBAP.NET\capicom.dll");
                SW.Close();

                SR.ReadToEnd();
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }
    }
}
