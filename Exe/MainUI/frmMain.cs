using DevExpress.XtraBars;
using EBAP.Business.WSBiz;
using EBAP.Core;
using EBAP.Core.Collections;
using EBAP.Core.Info;
using EBAP.Core.Localization;
using EBAP.Core.Security;
using EBAP.Data.CodeUtil;
using EBAP.Win.BaseFrame;
using EBAP.Win.Utility;
using System;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace EBAP.Exe.MainUI
{
    public partial class frmMain : EBAP.Win.BaseFrame.MainFrame
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        private string startmenuid = "";

        /// <summary>
        /// 
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuid"></param>
        public frmMain(string menuid)
        {
            InitializeComponent();

            startmenuid = menuid;
        }

        #endregion

        #region :: 전역변수 ::

        private int _faultPwd = 0;

        private System.Windows.Forms.Timer t10 = new System.Windows.Forms.Timer();      //업데이트 확인 타이머(10분)
        private System.Windows.Forms.Timer t30 = new System.Windows.Forms.Timer();      //필수 업데이트 타이머(30분)

        private bool b30start = false;
        private bool b10Start = false;
        //private bool b1Start = false;

        private int count30 = 0;
        private string exitTime = "";

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler(Common Event)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: frmMain_Load :: 폼이 Load 될 때 초기화 및 사용자 Log를 저장합니다.

        /// <summary>
        /// 폼이 Load 될 때 초기화 및 사용자 Log를 저장합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Debugger.IsAttached)
                    SignOn(true);
                else
                {
                    #region :: 디버그용 사용자 설정

                    ShowWaitDialog("디버깅 사용자 설정 중...");

                    CurrentUser = new UserInfo();
                    //Thread.Sleep(10000);

                    ShowWaitDialog("디버깅 사용자 설정 중...", "권한 설정 중...");

                    //InitUserMenu();
                    //Thread.Sleep(10000);
                    ShowWaitDialog("디버깅 사용자 설정 중...", "언어 및 로그 설정 중...");

                    SetLoginStatus(true);

                    SaveLanguageMaster(CurrentUser.CURRENTLANGUAGE);
                    SaveLanguageMessageMaster(CurrentUser.CURRENTLANGUAGE);
                    SetLocale(CurrentUser.CURRENTLANGUAGE);

                    string vendorCode = Win32Util.GetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "VENDORCODE");
                    string plantCode = Win32Util.GetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "PLANTCODE");

                    // 메인 PLC 연결 상태
                    SetPlcStatus(PlcType.Main, PlcStatus.Connected);

                    // 서브 PLC 연결 상태
                    SetPlcStatus(PlcType.Sub, PlcStatus.Disconnected);

                    InitVendorCode(AppCode.GetVendorCode(CurrentUser.USERID));
                    InitPlantCode(AppCode.GetPlantCode(CurrentUser.USERID));

                    SetVendor(vendorCode);
                    SetPlant(plantCode);

                    Win32Util.SetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "SIGNINSEQ", "-1");
                    CurrentUser.SIGNINSEQ = -1;
                    //Thread.Sleep(10000);

                    //RibbonPageCategory selectionCategory = Ribbon.PageCategories[0] as RibbonPageCategory;

                    //selectionCategory.Visible = CurrentUser.ISADMIN;
                    //Ribbon.Items["siDept"].Caption = CurrentUser.DEPARTMENTNAME;
                    SetUserInfo($"{CurrentUser.USERNAME} - {CurrentUser.GRADENAME}");
                    //Ribbon.Items["iUser"].Caption = String.Format("{0} - {1} ({2})", CurrentUser.USERNAME, CurrentUser.GRADENAME, "DEBUG MODE");

                    StartTimer();

                    InitializeMainForm();
                    ExecuteStartMenu();

                    #endregion
                }

                CloseWaitDialog();

                ExecuteCellInfo();
                //ExecuteNotify();

                if (startmenuid != "") ExecuteUI(startmenuid, null);
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        #region :: frmMain_FormClosing :: Main Form이 닫힐 때 발생합니다.

        /// <summary>
        /// Main Form이 닫힐 때 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CurrentUser == null || LOCALECONVERTER == null) return;

            if (e.CloseReason == CloseReason.ApplicationExitCall)
            {
                SaveSignLog(CurrentUser.SIGNINSEQ);

                return;
            }

            if (e.CloseReason != CloseReason.UserClosing) return;

            if (ShowMsgBox(String.Format(LOCALECONVERTER.GetLocaleMessage("CF_Exit"), Text), LOCALECONVERTER.GetLocaleString("Exit"), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                ShowWaitDialog(string.Format("{0} 을(를) 종료 중입니다.", Text), "시스템 정리 중...");
                CloseAllMdiChildren();

                ShowWaitDialog(string.Format("{0} 을(를) 종료 중입니다.", Text), "현재 사용자 로그아웃 처리 중...");

                SaveSignLog(CurrentUser.SIGNINSEQ);
            }
            else
                e.Cancel = true;
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Private)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: ExecuteCellInfo :: CELL 설정화면으로 이동합니다.

        /// <summary>
        /// CELL 설정화면으로 이동합니다.
        /// </summary>
        private void ExecuteCellInfo()
        {
            if (CurrentUser == null) return;

            if (FindMenuNode("CMN03") != null && CurrentUser.VENDORCODE == "")
            {
                ShowMsgBox("Store 설정이 필요하여 Store 설정 화면으로 이동합니다.");

                ExecuteUI("CMN03", null);
            }
        }

        private void ExecuteNotify()
        {
            if (CurrentUser == null || CurrentUser.ISADMIN) return;

            const string queryId = @"dbo.Notify_Select";

            DataSet ds;

            ParamCollection param = new ParamCollection();
            param.Add("@TYPE", "");
            param.Add("@SUBJECT", "");
            param.Add("@ISADMIN", false);
            param.Add("@USERID", CurrentUser.USERID);

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, param);
            }

            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0) return;

            ExecuteUI("CMN01", null);
        }

        private bool VNOTIFY = false;

        private void ExecuteNotifyT10()
        {
            if (CurrentUser == null) return;

            const string queryId = @"dbo.Notify_Select";

            DataSet ds;

            ParamCollection param = new ParamCollection();
            param.Add("@TYPE", "V");
            param.Add("@SUBJECT", "");
            param.Add("@ISADMIN", false);
            param.Add("@USERID", CurrentUser.USERID);

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, param);
            }

            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0) return;

            VNOTIFY = true;

            DataRow dr = ds.Tables[0].Rows[0];

            ParamCollection popParam = new ParamCollection();
            popParam.Add("NOTIFYSEQ", dr["SEQ"].ToString());
            popParam.Add("SUBJECT", dr["SUBJECT"].ToString());
            popParam.Add("CONTENTS", dr["CONTENTS"].ToString());

            ExecutePopup("중요 공지", "EBAP.UI.ADM.dll", "EBAP.UI.ADM.Popup.PopNotifyConfirm", popParam);

            VNOTIFY = false;
        }

        /// <summary>
        /// Main Form을 초기화합니다.
        /// </summary>
        private void InitializeMainForm()
        {
            if (CurrentUser == null) return;

            CurrentUser.LINECODE = Win32Util.GetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "LINE");
            CurrentUser.CELLCODE = Win32Util.GetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "CELL");
            CurrentUser.STATIONGROUP = Win32Util.GetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "STATIONGROUP");
            //CurrentUser.MSGKEY = AppCode.GetMessageKey(CurrentUser.VENDORCODE, CurrentUser.USERID, CurrentUser.IP);

            string docking = Win32Util.GetIniValue(AppConfig.SETTINGFILEPATH, "DOCKING", CurrentUser.USERID);

            SetBarItemVisible(CurrentUser.ISADMIN);
            SetConnectionType(AppUtil.CheckConnectType(CurrentUser.IP));

            InitDocking(docking);
            InitLinkMenu();
            InitFavoritesMenu();
            //ExecuteStartMenu();
        }

        /// <summary>
        /// 타이머를 시작합니다.
        /// </summary>
        private void StartTimer()
        {
            if (b10Start) return;

            t10.Interval = 600000; //10분
            //t10.Interval = 20000; //20초(테스트용)
            t10.Tick += t10_Tick;

            t10.Start();
            b10Start = true;

            t30.Interval = 3600000; //1시간
            //t30.Interval = 180000; //3분(테스트용)
            t30.Tick += t30_Tick;
        }

        private void SaveUserInfoForSAP(DataTable dt)
        {
            const string queryId = @"dbo.upOInsertEmployees_NEW";

            string[] paramList = new string[] { "@UserID",
                                                "@UserName",
                                                "@tmpPass",
                                                "@Department",
                                                "@EPID",
                                                "@UserEmail",
                                                "@ClassPosition",
                                                "@Vendorcode",
                                                "@EnPassword",
                                                "@EnUserID" };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                wb.Tx_ExecuteNonQuery(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, dt);
            }
        }

        private int USETIMECOUNT = 0;

        /// <summary>
        /// 10분 마다 업데이트 검사
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t10_Tick(object sender, EventArgs e)
        {
            if (!VNOTIFY) ExecuteNotifyT10();

            CheckUpdate.ISESSENTIAL = false;

            int updateCount = CheckUpdate.checkUpdate(CurrentUser.USERID);

            SetUpdateButtonVisible(false, "");

            if (updateCount == 0) return;

            USETIMECOUNT++;

            string caption = $"[ {Text} ] - {updateCount} 개의 Update가 있습니다.";
            string message = "\r\n업데이트를 실행하세요.";
            string reason = GetUpdateReason();

            SetUpdateButtonVisible(true, reason);

            if (Debugger.IsAttached) CheckUpdate.ISESSENTIAL = false;

            foreach (Form f in MdiChildren)
            {
                if (!(f is UIFrame)) continue;

                string menuId = (f as UIFrame).MENUID;

                if (menuId.In("MES0107", "SRMS0201"))
                {
                    CheckUpdate.ISESSENTIAL = false;
                    break;
                }
            }

            if (CheckUpdate.ISESSENTIAL)
            {
                if (!b30start)
                {
                    exitTime = DateTime.Now.AddHours(1).ToString("HH:mm:ss");
                    t30.Start();
                    b30start = true;
                }
                message = String.Format("\r\n필수 업데이트가 포함되어 \r\n{0} 분 뒤 ( {1} ) 이 프로그램이 강제 재시작 됩니다.", 60 - (count30++ * 10), exitTime);
                message += "\r\n현재 작업을 마무리 한 후 [ I2S ]을 재시작 하세요.";
                message += String.Format("\r\n\r\n[ 업데이트 내용 ]{0}", reason);
                //ShowInfoMessage("필수 업데이트", caption, message, Color.BlueViolet);
                ShowFlyoutDialog(caption, message);
            }
            else
            {
                caption = String.Format("[ {0} ] 개의 Update가 있어요.", updateCount);
                message = "\r\n업데이트를 실행하세요.";
                ShowAlertMessage(caption, reason, message);

                count30 = 0;
            }

            if (USETIMECOUNT > 288)
            {
                string updateMsg = "\r\n업데이트를 하지 않고 2일 이상 사용 중이에요.\r\n업데이트를 하고 사용하세요.";
                ShowAlertMessage("업데이트 권장", updateMsg, message);
            }
        }

        private string GetUpdateReason()
        {
            string reason = "";

            foreach (string r in CheckUpdate.updateReason)
            {
                reason += Environment.NewLine;
                reason += r;
            }

            return reason;
        }

        /// <summary>
        /// 30분 후 시스템 종료
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t30_Tick(object sender, EventArgs e)
        {
            t10.Stop();
            t30.Stop();
            SaveSignLog(CurrentUser.SIGNINSEQ);
            ShowMsgBox("필수 구성 요소가 업데이트 되어 프로그램을 재시작합니다.");
            ExitAndUpdate(false);
        }

        /// <summary>
        /// 시작 메뉴를 설정합니다.
        /// </summary>
        private void ExecuteStartMenu()
        {
            DataSet ds;

            const string queryId = @"dbo.MyMenu_Select";

            string[] paramList = new string[] { "@USERID",
                                                "@GUBUN" };

            object[] valueList = new object[] { CurrentUser.USERID,
                                                "S" };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            }

            string ip = "";

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ip = dr["IPADDRESS"].ToString();

                if (ip == "")
                    ExecuteUI(dr["MENUID"], null);
                else
                {
                    if (ip == CurrentUser.IP)
                        ExecuteUI(dr["MENUID"], null);
                }
            }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: SignOn :: 사용자 Sign On 처리합니다.

        /// <summary>
        /// 사용자 Sign ON 처리합니다.
        /// </summary>
        /// <param name="firstLogin">처음 로그인</param>
        protected override void SignOn(bool firstLogin)
        {
            CloseAllMdiChildren();

            //ShowWaitDialog("사용자 로그인 처리 중...");

            string vVendor = Win32Util.GetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "VENDORCODE");
            string vPlantCode = Win32Util.GetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "PLANTCODE");

            ParamCollection param = new ParamCollection();
            param.Add("FIRSTLOGIN", firstLogin);

            DataRow dr = ExecutePopup("Login", "EBAP.Exe.MainUI.exe", "EBAP.Exe.MainUI.frmSignOn", param) as DataRow;

            if (dr == null)
            {
                return;
            }

            bool bKnox = false;

            DataTable dt = dr.Table;

            ShowWaitDialog("사용자 로그인 처리 중...", "로그인 정보 확인 중...");

            DataRow userRow = SignIn(bKnox, dt);

            if (userRow == null)
            {
                CloseWaitDialog();
                return;
            }

            string lastLoginTime = userRow["LASTSIGNINTIME"].ToString();

            if ((GetCurrentTime() - Convert.ToDateTime(lastLoginTime)).TotalDays > 180)
            {
                StringBuilder sbMsg = new StringBuilder();
                sbMsg.AppendLine("최종 로그인 시간이 [ 180일 ] 경과하여 권한이 모두 삭제되었어요.");
                sbMsg.AppendLine("");
                sbMsg.AppendLine("MSNIB 담당자에게 연락하여 필요한 권한을 재요청 하셔야 해요.");
                sbMsg.AppendLine(String.Format("최종 로그인 시간 : [ {0} ]", Convert.ToDateTime(lastLoginTime).ToLongDateString()));

                ShowMsgBox(sbMsg.ToString());
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Format("{0} - {1} 님 로그인 하였습니다.", CurrentUser.USERNAME, CurrentUser.GRADENAME));
            sb.AppendLine();
            sb.AppendLine(String.Format("Last Login Time : {0}", userRow["LASTSIGNINTIME"]));
            sb.AppendLine(String.Format("Last Login IP Address : {0}", userRow["LASTSIGNIP"]));

            //if (CurrentUser.ISEXT) SaveUserInfoForSAP(dt);

            SetLoginStatus(true);

            SaveLanguageMaster(CurrentUser.CURRENTLANGUAGE);
            SaveLanguageMessageMaster(CurrentUser.CURRENTLANGUAGE);
            SetLocale(CurrentUser.CURRENTLANGUAGE);

            InitVendorCode(AppCode.GetVendorCode(CurrentUser.USERID));
            InitPlantCode(AppCode.GetPlantCode(CurrentUser.USERID));

            ShowWaitDialog("사용자 로그인 처리 중...", sb.ToString());
            Thread.Sleep(1000);
            CurrentUser.SIGNINSEQ = SaveSignLog(0);

            ShowWaitDialog("사용자 로그인 처리 중...", String.Format("[ {0} ] 님 사용자 권한 설정 중...", CurrentUser.USERNAME));
            //InitUserMenu();

            //Ribbon.Items["siDept"].Caption = CurrentUser.DEPARTMENTNAME;
            //Ribbon.Items["siUser"].Caption = String.Format("{0} - {1}", CurrentUser.USERNAME, CurrentUser.GRADENAME);
            SetUserInfo(String.Format("{0} - {1}", CurrentUser.USERNAME, CurrentUser.GRADENAME));

            //RibbonPageCategory selectionCategory = Ribbon.PageCategories[0] as RibbonPageCategory;

            //if (selectionCategory != null) selectionCategory.Visible = CurrentUser == null ? false : CurrentUser.ISADMIN;

            //ShowWaitDialog("사용자 로그인 처리 중...", "다국어 처리 중...");
            //ShowWaitDialog("사용자 로그인 처리 중...", String.Format("[ {0} ] 님 사용자 설정 처리 중...", userRow["USERID"]));
            //vVendor = "";
            //vPlantCode = "";
            if (vVendor == "") vVendor = CurrentUser.VENDORCODE;
            if (vPlantCode == "") vPlantCode = CurrentUser.PLANTCODE;

            SetVendor(vVendor);
            SetPlant(vPlantCode);

            InitializeMainForm();

            //Ribbon.Items["iSignOn"].Caption = LANGCONVERTER.GetLanguageString("ChangeUser");

            //Ribbon.SelectedPage = Ribbon.Pages[0];

            StartTimer();

            CloseWaitDialog();

            ExecuteStartMenu();
        }

        #region :: SignIn :: 사용자 Sign IN 처리합니다.

        /// <summary>
        /// 사용자 Sign IN 처리합니다.
        /// </summary>
        /// <param name="sso">Single Sign 사용유무</param>
        /// <param name="loginInfo">SSO 정보</param>
        /// <returns></returns>
        private DataRow SignIn(bool sso, DataTable loginInfo)
        {
            string vendor = loginInfo.Rows[0]["VENDORCODE"].ToString();
            string plantcode = loginInfo.Rows[0]["PLANTCODE"].ToString();
            string pwd = loginInfo.Rows[0]["PWD"].ToString();
            string language = loginInfo.Rows[0]["LANGUAGE"].ToString();
            string userid = loginInfo.Rows[0]["USERID"].ToString();
            string name = loginInfo.Rows[0]["USERNAME"].ToString();
            string saveid = loginInfo.Rows[0]["SAVEID"].ToString();

            DataSet ds;

            const string queryId = @"dbo.UserSignOn";

            string[] paramList = new string[] { "@VENDORCODE",
                                                "@PLANTCODE",
                                                "@USERID" };
            object[] valueList = new object[] { vendor,
                                                plantcode,
                                                userid };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];

                if (dr["LOCKFLAG"].ToString() != "True")
                {
                    if (sso || Cryptography.ValidateSHA256Hash(pwd, dr["PWD"].ToString()))
                    {
                        //현재 사용자 로그아웃 처리
                        if (CurrentUser != null && CurrentUser.SIGNINSEQ != 0)
                        {
                            ShowWaitDialog("사용자 로그인 처리 중...", "현재 사용자 로그아웃 처리 중...");
                            SaveSignLog(CurrentUser.SIGNINSEQ);
                        }

                        CurrentUser = new UserInfo(dr);
                        CurrentUser.CURRENTLANGUAGE = language == string.Empty ? "ko-KR" : language;

                        //Win32Util.SetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "SIGNINSEQ", (Owner as frmMain).CurrentUser.SIGNINSEQ.ToString());

                        Win32Util.SetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "SAVEID", saveid);
                        Win32Util.SetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "VENDORCODE", vendor);
                        Win32Util.SetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "PLANTCODE", plantcode);
                        Win32Util.SetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "LASTLOGINID", Cryptography.RijndaelEncrypt(userid));
                        Win32Util.SetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "LASTLOGINPWD", Cryptography.RijndaelEncrypt(pwd));
                        Win32Util.SetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "LANGUAGE", language);
                        //Win32Util.SetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "ISENCRYPT", "True");

                        //if (sso) KNOXInfoSave(loginInfo);

                        return dr;
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder(128);
                        sb.AppendLine(String.Format("비밀번호가 {0}번 틀렸습니다. 정확한 비밀번호를 입력하세요", (++_faultPwd)));
                        sb.Append("비밀번호를 3번 틀릴 경우 사용금지 처리됩니다. 주의하세요");

                        ShowMsgBox(sb.ToString(), "비밀번호 확인");

                        if (_faultPwd > 2)
                        {
                            ShowMsgBox("비밀번호가 3번 틀렸습니다. 사용금지 처리됩니다.");
                            //LockUser();
                            _faultPwd = 0;
                            return null;
                        }
                        return null;
                    }
                }
                else
                {
                    ShowMsgBox("잠긴 사용자 입니다. 관리자에게 문의하세요");
                    _faultPwd = 0;
                    return null;
                }
            }
            else
            {
                if (!sso)
                {
                    ShowMsgBox("사용자 ID를 확인하세요");

                    _faultPwd = 0;
                    return null;
                }
                else
                {
                    //KNOXInfoSave(loginInfo);
                    ShowMsgBox(String.Format("[ {0} ] 님에 대한 신규 사용자가 등록되었습니다. 관리자에게 확인하시기 바랍니다.", name));
                    return null;
                }
            }
        }

        #endregion

        //#region :: GetKNOXInfo :: KNOX 포탈 정보 가져오기

        ///// <summary>
        ///// KNOX 포탈 정보 가져오기
        ///// </summary>
        ///// <param name="vendorCode"></param>
        ///// <param name="plantCode"></param>
        ///// <param name="language"></param>
        ///// <param name="secureBox"></param>
        //private DataTable GetKNOXInfo(string vendorCode, string plantCode, string language, string secureBox)
        //{
        //    DataTable dt = new DataTable("Table1");

        //    if (secureBox != null && secureBox.Length > 0)
        //    {
        //        string[] strList = secureBox.Split(';');
        //        EPTRAYUTILLib.Util epUtil = new EPTRAYUTILLib.Util();

        //        string strEPRet = epUtil.DecryptDataList2(strList[2], strList[1], strList[0]);

        //        string[] str2 = strEPRet.Split(';');

        //        int pos;

        //        dt.AddColumn("VENDORCODE", "PLANTCODE", "LANGUAGE", "EPID", "LOGINID", "USERID", "USERNAME", "EMPNO", "GRADECODE", "GRADENAME", "DEPTCODE", "DEPTNAME", "PHONE", "OFFICEPHONE", "EMAILADDRESS", "SAVEID", "PWD");

        //        DataRow dr = dt.NewRow();

        //        dr["VENDORCODE"] = vendorCode;
        //        dr["PLANTCODE"] = plantCode;
        //        dr["LANGUAGE"] = language;
        //        dr["SAVEID"] = true.ToString();
        //        dr["PWD"] = string.Empty;

        //        string info, INFOKEY, InfoValue, UserId = string.Empty;

        //        for (int i = 0; i < str2.Length - 1; i++)
        //        {
        //            info = str2[i];

        //            if (info == string.Empty) continue;

        //            pos = info.LastIndexOf("=");

        //            if (pos > 0)
        //            {
        //                INFOKEY = info.Substring(0, pos);
        //                InfoValue = info.Substring(pos + 1, info.Length - pos - 1);

        //                if (INFOKEY == "EP_RETURNCODE" && InfoValue == "0")
        //                {
        //                    ShowMsgBox("Login Error");
        //                    return null;
        //                }

        //                switch (INFOKEY)
        //                {
        //                    case "EP_LOGINID":                   // LOGINID
        //                        dr["LOGINID"] = InfoValue;
        //                        break;
        //                    case "EP_USERID":                    // EPID 
        //                        dr["EPID"] = InfoValue;
        //                        UserId = InfoValue;
        //                        break;
        //                    case "EP_SABUN":                     // 사번을 사용자 ID로 사용합니다.
        //                        dr["USERID"] = InfoValue;
        //                        dr["EMPNO"] = InfoValue;
        //                        break;
        //                    case "EP_MAIL":
        //                        dr["EMAILADDRESS"] = InfoValue;
        //                        break;
        //                    case "EP_USERNAME":
        //                        dr["USERNAME"] = InfoValue;
        //                        break;
        //                    case "EP_COMPID":
        //                        break;
        //                    case "EP_COMPNAME":
        //                        break;
        //                    case "EP_DEPTID":
        //                        dr["DEPTCODE"] = InfoValue;
        //                        break;
        //                    case "EP_DEPTNAME":
        //                        dr["DEPTNAME"] = InfoValue;
        //                        break;
        //                    case "EP_GRDID":
        //                        dr["GRADECODE"] = InfoValue;
        //                        break;
        //                    case "EP_GRDNAME":
        //                        dr["GRADENAME"] = InfoValue;
        //                        break;
        //                    case "EP_MOBILE":
        //                        dr["PHONE"] = InfoValue;
        //                        break;
        //                    case "EP_COMPTEL":
        //                        dr["OFFICEPHONE"] = InfoValue;
        //                        break;
        //                    default:
        //                        break;
        //                }
        //            }
        //        }

        //        dt.Rows.Add(dr);
        //    }

        //    return dt;
        //}

        //#endregion

        //#region :: KNOXInfoSave :: KNOX 포탈 정보 DB 저장

        ///// <summary>
        ///// KNOX 포탈 정보 DB 저장
        ///// </summary>
        ///// <param name="dt"></param>
        //private void KNOXInfoSave(DataTable dt)
        //{
        //    const string queryId = @"dbo.SSOInfo_Save";

        //    string[] paramList = new string[] { "@EPID",
        //                                        "@LOGINID",
        //                                        "@USERID",
        //                                        "@USERNAME", 
        //                                        "@EMPNO",
        //                                        "@GRADECODE",
        //                                        "@GRADENAME",
        //                                        "@DEPTCODE",
        //                                        "@DEPTNAME",
        //                                        "@PHONE",
        //                                        "@OFFICEPHONE",
        //                                        "@EMAILADDRESS" };

        //    using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
        //    {
        //        wb.Tx_ExecuteNonQuery(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, dt);
        //    }
        //}

        //#endregion

        #region :: SaveSignLog :: Database에 사용자 Sign On Log를 저장합니다.

        /// <summary>
        /// Database에 사용자 Sign On Log를 저장합니다.
        /// </summary>
        /// <param name="seq"></param>
        /// <remarks>
        /// 2010-12-15 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        internal int SaveSignLog(int seq)
        {
            object obj = null;
            const string queryId = @"dbo.SignLog_Save";

            string[] paramList = new string[] { "@ORIGINALSEQ",
                                                "@VENDORCODE",
                                                "@PLANTCODE",
                                                "@USERID",
                                                "@HOSTNAME",
                                                "@OS",
                                                "@MACADDRESS",
                                                "@IPADDRESS" };

            object[] valueList = new object[] { seq,
                                                CurrentUser.VENDORCODE,
                                                CurrentUser.PLANTCODE,
                                                CurrentUser.USERID,
                                                Dns.GetHostName(),
                                                Environment.OSVersion.VersionString,
                                                AppUtil.GetMacAddress(),
                                                CurrentUser.IP };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                //obj = wb.NTx_ExecuteScalarFromQueryId(queryId, paramList, valueList);
                obj = wb.NTx_ExecuteScalar(ConnectionString.LOGDB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            }

            Win32Util.SetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "SIGNINSEQ", obj.ToString());

            return Convert.ToInt32(obj);
        }

        #endregion

        #region :: SaveLanguage :: 언어 마스터를 XML 파일로 저장합니다.

        /// <summary>
        /// 언어 마스터(단어)를 XML 파일로 저장합니다.
        /// </summary>
        /// <param name="language"></param>
        private void SaveLanguageMaster(string language)
        {
            DataSet ds;
            const string queryId = @"dbo.LocaleMaster_Get";

            string[] paramList = new string[] { "@LOCALE" };
            object[] valueList = new object[] { language };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            }

            ds.WriteXml(AppConfig.LOCALEXMLPATH);
        }

        /// <summary>
        /// 언어 마스터(메시지)를 XML 파일로 저장합니다.
        /// </summary>
        /// <param name="language"></param>
        private void SaveLanguageMessageMaster(string language)
        {
            DataSet ds;
            const string queryId = @"dbo.LocaleMessageMaster_Get";

            string[] paramList = new string[] { "@LOCALE" };
            object[] valueList = new object[] { language };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            }

            ds.WriteXml(AppConfig.MESSAGEXMLPATH);
        }

        #endregion        

        #endregion
    }
}
