using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using EBAP.Core;
using System.Diagnostics;
using System.IO;
using EBAP.Win.Dialog;
using EBAP.Core.Info;
using EBAP.Win.Utility;
using EBAP.Core.Security;

namespace EBAP.Exe.MainUI
{
    /// <summary>
    /// 사용자 Sign 처리를 담당하는 Form입니다.
    /// </summary>
    /// <remarks>
    /// 2016-06-24 최초생성 : 오인봉
    /// 변경내역
    /// 
    /// </remarks>
    public partial class frmSignOn : EBAP.Win.BaseFrame.PopupFrame
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// 사용자 Sign 처리 Form을 생성합니다.
        /// </summary>
        public frmSignOn()
        {
            InitializeComponent();
        }

        #endregion

        #region :: 전역변수 ::

        private bool firstLogin = false;

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: frmSignOn_Load :: Form이 Load 시 발생합니다.

        /// <summary>
        /// Form이 Load 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSignOn_Load(object sender, EventArgs e)
        {
            try
            {
                InitComboBox();
                InitControls();
                SetPopParams();

                if(!firstLogin)
                {
                    lblLogin.Text = "      사용자 변경";
                    btnSignOn.Text = "사용자 변경";
                    txtID.EditValue = "";
                    txtPWD.EditValue = "";
                }

                if (txtID.TrimText == string.Empty)
                {
                    ActiveControl = txtID;
                    txtID.Select();
                }
                else if (txtPWD.TrimText == string.Empty)
                {
                    ActiveControl = txtPWD;
                    txtPWD.Select();
                }
                else
                {
                    if (firstLogin && chkSaveID.Checked)
                        btnSignOn.PerformClick();
                    else
                        btnSignOn.Select();
                }
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        /// <summary>
        /// ComboBox Initialize
        /// </summary>
        private void InitComboBox()
        {
            List<string> valueList = new List<string>();
            List<string> displayList = new List<string>();

            foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.AllCultures))
            {
                if (ci.Name.Contains("ko-KR") || ci.Name.Contains("en-US"))
                {
                    valueList.Add(ci.Name);
                    displayList.Add(String.Format("{0} : {1}", ci.Name, ci.DisplayName));
                }
            }

            cboLanguage.InitData(valueList.ToArray(), displayList.ToArray());
        }

        /// <summary>
        /// 기타 Control Initialize
        /// </summary>
        private void InitControls()
        {
            SetToolBarVisible(false);

            // 이전 로그인 정보 가져오기
            //string vEncrypt = Win32Util.GetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "ISENCRYPT");
            string vID = Win32Util.GetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "LASTLOGINID");
            string vPWD = Win32Util.GetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "LASTLOGINPWD");
            string vLanguage = Win32Util.GetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "LANGUAGE");
            string vSaveId = Win32Util.GetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "SAVEID");

            vID = vID == "" ? vID : Cryptography.RijndaelDecrypt(vID);
            vPWD = vPWD == "" ? vPWD : Cryptography.RijndaelDecrypt(vPWD);

            chkSaveID.Checked = vSaveId == "False" ? false : true;

            if (chkSaveID.Checked)
            {
                txtID.EditValue = vID;
                txtPWD.EditValue = vPWD;
            }
            cboLanguage.EditValue = vLanguage;

            if (cboLanguage.EditText == string.Empty)
                cboLanguage.EditValue = "ko-KR";
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetPopParams()
        {
            firstLogin = Convert.ToBoolean(PopParams["FIRSTLOGIN"]);
        }

        #endregion

        #region :: btnSignOn_Click :: Sign On 처리합니다.

        /// <summary>
        /// Sign On 처리합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSignOn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckCondition()) return;

                string userID = txtID.EditValue.ToString();
                string pwd = txtPWD.EditValue.ToString();

                if (userID == string.Empty)
                {
                    return;
                }

                DataTable dt = new DataTable("Table1");
                dt.AddColumn("VENDORCODE", "PLANTCODE", "LANGUAGE", "EPID", "USERID", "USERNAME", "EMPNO", "GRADECODE", "GRADENAME", "DEPTCODE", "DEPTNAME", "PHONE", "EMAILADDRESS", "SAVEID", "PWD");

                DataRow dr = dt.NewRow();

                dr["VENDORCODE"] = "";
                dr["PLANTCODE"] = "";
                dr["LANGUAGE"] = cboLanguage.EditValue.ToString();
                dr["EPID"] = userID;
                dr["USERID"] = userID;
                dr["SAVEID"] = chkSaveID.Checked.ToString();
                dr["PWD"] = pwd;

                dt.Rows.Add(dr);
                POPUPVALUE = dr;
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        #region :: txtPWD_KeyDown :: 비밀번호에서 Enter 키를 누르면 Sign On 버튼을 누른 기능을 합니다.

        /// <summary>
        /// 비밀번호에서 Enter 키를 누르면 Sign On 버튼을 누른 기능을 합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPWD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnSignOn.PerformClick();
        }

        /// <summary>
        /// 아이디와 비밀번호 입력 후 Validation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtID_Validated(object sender, EventArgs e)
        {
            dxValidationProvider.Validate();
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Private)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        // Initialize 관련 Method

        #region :: CheckCondition :: 로그인 필수조건 Check

        /// <summary>
        /// 로그인 필수조건 Check
        /// </summary>
        /// <returns></returns>
        private bool CheckCondition()
        {
            return dxValidationProvider.Validate();
        }

        #endregion
    }
}
