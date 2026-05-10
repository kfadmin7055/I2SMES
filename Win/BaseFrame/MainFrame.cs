using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Colors;
using DevExpress.Utils.Drawing.Helpers;
using DevExpress.Utils.Taskbar;
using DevExpress.Utils.Taskbar.Core;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors;
using DevExpress.XtraTab.ViewInfo;
using DevExpress.XtraTabbedMdi;
using DevExpress.XtraTreeList.Nodes;
using EBAP.Business.WSBiz;
using EBAP.Core;
using EBAP.Core.Collections;
using EBAP.Core.Info;
using EBAP.Core.Interface;
using EBAP.Core.Localization;
using EBAP.Win.BaseFrame.Localization;
using EBAP.Win.BaseFrame.Properties;
using EBAP.Win.Dialog;
using EBAP.Win.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace EBAP.Win.BaseFrame
{
    /// <summary>
    /// 시스템에서 사용할 Main Form의 Super Class 입니다.
    /// </summary>
    /// <remarks>
    /// 2023-02-01 최초생성 : 오인봉
    /// 변경내역
    ///
    /// </remarks>
    public partial class MainFrame : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// MainFrame을 생성합니다.
        /// </summary>
        public MainFrame()
        {
            InitializeComponent();
        }

        #endregion

        #region :: 전역변수 ::

        private LocaleConverter _localeConverter;

        //private string _webserviceurl = @"http://localhost/PAPS/";
        //private string _webserviceurl = @"http://127.0.0.1/EBAPWS/";
        //private string _webserviceurl = @"http://localhost:16817/";
        //private string SYSTEMUPDATEURL = @"http://127.0.0.1/EBAPClient/EBAP.Exe.AutoUpdater.application";

        //private string UPDATEURLDEV = @"http://127.0.0.1/EBAPClient/EBAP.Exe.AutoUpdater.application";
        //private string UPDATEURL = @"http://127.0.0.1/EBAPClient/EBAP.Exe.AutoUpdater.application";
        
        private string DEVWEBURL = @"http://127.0.0.1/EBAPService/";
        private string WEBURL = @"http://49.247.172.63/EBAPService/";
        private bool LOGINFLAG = false;

        

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 다국어 :: 다국어 지원에 사용할 Localizer와 언어를 설정합니다.

        /// <summary>
        /// 다국어 지원에 사용할 Localizer
        /// </summary>
        [Browsable(false)]
        public LocaleConverter LOCALECONVERTER
        {
            get
            {
                return _localeConverter;
            }
        }

        /// <summary>
        /// 현재 사용 언어를 설정합니다.
        /// </summary>
        [Browsable(false)]
        protected internal string CURRENTLANGUAGE
        {
            get
            {
                return iLanguage.EditValue.ToString() == "한국어" ? "ko-KR" : "en-US";
            }
            //private set
            //{
            //    iLanguage.EditValue = value == "en-US" ? "English" : "한국어";
            //}
        }

        #endregion

        #region :: CurrentUser :: 현재 사용자의 정보를 설정합니다.

        /// <summary>
        /// 현재 사용자의 정보를 설정합니다.
        /// </summary>
        [Browsable(false)]
        public UserInfo CurrentUser
        {
            get;
            set;
        }

        #endregion

        #region :: ISMODIFIED :: UI 수정여부를 Check 하여 수정여부를 Caption에 표시합니다.

        /// <summary>
        /// UI 수정여부를 Check 하여 수정여부를 Caption에 표시합니다.
        /// </summary>
        [Browsable(false)]
        public bool ISMODIFIED
        {
            get
            {
                return siModified.Visibility == BarItemVisibility.Always ? true : false;
            }
            set
            {
                siModified.Visibility = value == true ? BarItemVisibility.Always : BarItemVisibility.Never;
            }
            //get;
            //set;
        }

        #endregion

        #region :: RUNMODE :: 운영/개발 모드를 설정합니다.

        /// <summary>
        /// 운영/개발 모드를 설정합니다.
        /// </summary>
        protected string RUNMODE
        {
            get;
            set;
        }

        #endregion



        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Control Event
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: iVendorCode_EditValueChanged :: Vendor를 선택하면 UserInformation의 Vendor를 변경합니다.

        /// <summary>
        /// Vendor를 선택하면 UserInformation의 Vendor를 변경합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iVendorCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (CurrentUser == null) return;

                string vendorCode = iVendorCode.EditValue.ToString();

                if (vendorCode == string.Empty)
                {
                    //cboPlantCode.DataSource = null;
                    iPlantCode.EditValue = "";
                }

                CurrentUser.VENDORCODE = vendorCode;
                CurrentUser.VENDORNAME = cboVendorCode.GetDisplayText(vendorCode);

                //Win32Util.SetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "VENDORCODE", vendorCode);
                //InitPlantCode(AppCode.GetPlantCode(iVendorCode.EditValue.ToString()));
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        #region :: iPlantCode_EditValueChanged :: Plant를 선택하면 UserInformation의 ORGANIZATIONID를 변경합니다.

        /// <summary>
        /// Plant를 선택하면 UserInformation의 ORGANIZATIONID를 변경합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iPlantCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (CurrentUser == null) return;

                string plantCode = iPlantCode.EditValue.ToString();

                if (sender != null)
                    CloseAllMdiChildren();

                CurrentUser.PLANTCODE = plantCode;
                CurrentUser.PLANTNAME = cboPlantCode.GetDisplayText(plantCode);

                //Win32Util.SetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "PLANTCODE", plantCode);

                InitUserMenu();
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        /// <summary>
        /// 실행 중인 Form을 모두 종료합니다.
        /// </summary>
        /// <param name="allClose"></param>
        protected void CloseAllMdiChildren(bool allClose = true)
        {
            if (MdiChildren == null || MdiChildren.Length == 0) return;

            foreach (Form f in MdiChildren)
            {
                if (!allClose && ActiveMdiChild == f) continue;

                f.Close();
                Thread.Sleep(10);
            }
            Application.DoEvents();
        }

        /// <summary>
        /// 사용자 Menu를 초기화합니다.
        /// </summary>
        protected void InitUserMenu()
        {
            if (CurrentUser == null || CurrentUser.PLANTCODE == "") return;

            DataSet ds;
            const string queryId = @"dbo.MenuAuth_Get";

            string[] paramList = new string[] { "@USERID", "@USEVENDORCODE", "@USEPLANTCODE" };
            object[] valueList = new object[] { CurrentUser.USERID, CurrentUser.VENDORCODE, CurrentUser.PLANTCODE };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            }

            //Win32Util.SetIniValue(AppConfig.SETTINGFILEPATH, "SHORTCUT", CurrentUser.USERID, ds.Tables[2].Rows[0][0].ToString());

            CreateMenu(ds);

            tlMenu.Refresh();

            if (ds.Tables[0].Rows.Count == 0) return;

            CurrentUser.RESTRICTIONS = ds.Tables[1].Rows[0][0].ToString();

            //ExpandMenu();
        }

        /// <summary>
        /// Link Menu를 초기화합니다.
        /// </summary>
        protected void InitLinkMenu()
        {
            if (CurrentUser == null || CurrentUser.PLANTCODE == "") return;

            DataSet ds;
            const string queryId = @"LinkMenu_Get";

            //string[] paramList = new string[] { "@USERID", "@USEVENDORCODE", "@USEPLANTCODE" };
            //object[] valueList = new object[] { CurrentUser.USERID, CurrentUser.VENDORCODE, CurrentUser.PLANTCODE };

            //간단한 조회일 경우
            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, null, null);
            }

            if (ds.Tables[0].Rows.Count == 0) return;

            PBarButtonItem button = null;

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                button = new PBarButtonItem();
                button.ItemClick += new ItemClickEventHandler(iLinkMenu_ItemClick);
                button.Caption = dr["MENUNAME"].ToString();
                button.Name = dr["MENUID"].ToString();
                button.CLASSNAME = dr["LINKURL"].ToString();
                button.Tag = dr["LINKTYPE"].ToString();

                iLinkMenu.AddItem(button).BeginGroup = Convert.ToBoolean(dr["ISBEGINGROUP"]);
            }
        }

        /// <summary>
        /// 즐겨찾기 Menu를 초기화합니다.
        /// </summary>
        protected void InitFavoritesMenu()
        {
            if (CurrentUser == null || CurrentUser.PLANTCODE == "") return;

            DataSet ds;
            const string queryId = @"dbo.MyMenu_Select";

            string[] paramList = new string[] { "@USERID", "@GUBUN" };
            object[] valueList = new object[] { CurrentUser.USERID, "F" };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            }

            if (ds.Tables[0].Rows.Count == 0) return;

            PBarButtonItem button = null;

            iFMenu.ClearLinks();

            //int key = 131121;       //Control+1
            string prevMenuId = "";
            int idx = 1;

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                button = new PBarButtonItem();

                // 1 ~ 9 까지 단축키 지정
                button.Caption = idx < 10 ? String.Format("&{0} {1}", idx++, dr["MENUNAME"].ToString()) : dr["MENUNAME"].ToString();

                button.Name = dr["MENUID"].ToString();
                button.DLLNAME = dr["DLLNAME"].ToString();
                button.CLASSNAME = dr["CLASSNAME"].ToString();
                button.Tag = "F";

                //if (idx < 10)
                //{
                //    Shortcut shortcut = (Shortcut)key;
                //    button.ItemShortcut = new BarShortcut(shortcut);
                //}

                iFMenu.AddItem(button).BeginGroup = idx > 0 && prevMenuId.Left(3) != dr["MENUID"].ToString().Left(3) ? true : false;

                prevMenuId = dr["MENUID"].ToString();
                //idx++;
                //key++;
            }
        }

        /// <summary>
        /// 사용자 권한에 따라 Menu의 데이터를 채웁니다.
        /// </summary>
        /// <param name="ds">Menu의 DataSource</param>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        ///
        /// </remarks>
        protected void CreateMenu(DataSet ds)
        {
            tlMenu.DataMember = "";

            tlMenu.DataSource = ds;
            tlMenu.DataMember = ds.Tables[0].TableName;
            //tlMenu.Focus();
            //pnlTreeMenu.Refresh();
            pnlTreeMenu.Show();

            CreateTopMenu(ds);
            pnlTreeMenu.HideImmediately();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ds"></param>
        private void CreateTopMenu(DataSet ds)
        {
            ClearMiddleMenu();
            Clear3rdMenu();

            List<BarItem> items = new List<BarItem>();

            foreach (BarItem bItem in barManagerTop.Items)
            {
                if (!(bItem is PBarButtonItem)) continue;

                items.Add(bItem);
                //barManagerTop.Items.Remove(bItem);
            }

            foreach (BarItem bItem in items)
            {
                barManagerTop.Items.Remove(bItem);
            }

            PBarButtonItem button = null;
            int idx = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr["FAVORITES"].ToString() == "0" || dr["MENUID"].ToString().Contains("CMN")) continue;

                if (dr["LVL"].ToString() == "0")
                {
                    button = new PBarButtonItem();
                    button.Caption = dr["MENUNAME"].ToString();
                    button.Name = dr["MENUID"].ToString();
                    button.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;

                    button.ItemAppearance.SetFont(new Font("나눔고딕", 10.25F, FontStyle.Bold));
                    barTop.AddItem(button).BeginGroup = false;

                    if (idx == 0) button.PerformClick();

                    idx++;
                }
            }
        }

        #endregion

        #region :: iNavigator_EditValueChanged :: Navigator의 메뉴 ID가 변경되면 해당 ID의 UI를 실행합니다.

        /// <summary>
        /// Navigator의 메뉴 ID가 변경되면 해당 ID의 UI를 실행합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iNavigator_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (iNavigator.EditValue == null || iNavigator.EditValue.ToString().Trim() == string.Empty) return;

                //ExecuteUI(iNavigator.EditValue, null);

                DataSet ds = tlMenu.DataSource as DataSet;

                if (ds == null) return;
                DataTable dt = ds.Tables[0];
                string menuName = iNavigator.EditValue.ToString().Trim();
                DataRow[] drs = dt.Select(String.Format("MENUNAME LIKE '%{0}%' AND SCREENID <> '' AND PARENTMENUID <> 'FAVORITES'", menuName));

                if (drs.Length == 0)
                {
                    ShowMsgBox(String.Format("[ {0} ] 로 검색된 메뉴가 없어요.", menuName));
                    return;
                }

                if (drs.Length == 1)
                {
                    ExecuteUI(drs[0]["MENUID"], null);
                    iNavigator.EditValue = null;
                    return;
                }

                DataTable newDt = new DataTable();
                newDt.AddColumnWithValueType(new string[] { "MENUID", "MENUPATH" }, new object[] { "", "" });

                foreach (DataRow dr in drs)
                {
                    DataRow nRow = newDt.NewRow();
                    nRow["MENUID"] = dr["MENUID"];
                    nRow["MENUPATH"] = String.Format("[ {0} ] {1}", dr["MENUID"], GetMenuFullPath(dr["MENUID"]));
                    newDt.Rows.Add(nRow);
                }

                ParamCollection param = new ParamCollection();
                param.Add("FINDMENU", newDt);
                param.Add("KEYWORD", menuName);
                object obj = ExecutePopup("메뉴 찾기", "EBAP.UI.ADM.dll", "EBAP.UI.ADM.Popup.PopMenuNavigator", param);

                if (obj != null) ExecuteUI(obj, null);

                iNavigator.EditValue = null;
            }
            catch(Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        /// <summary>
        /// Menu의 Full Path를 가져옵니다.
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        private string GetMenuFullPath(object menuId)
        {
            string allPath = string.Empty;
            TreeListNode node = tlMenu.FindNodeByKeyID(menuId);
            TreeListNode pNode = node.ParentNode;

            List<string> fullPath = new List<string>();
            fullPath.Add(node.GetDisplayText("MENUNAME"));

            while (pNode != null)
            {
                node = pNode;
                pNode = node.ParentNode;
                fullPath.Add(node.GetDisplayText("MENUNAME"));
            }

            for (int i = fullPath.Count - 1; i >= 0; i--)
            {
                allPath += fullPath.ToArray()[i];

                if (i > 0) allPath += "  ▶  ";
            }

            if (allPath == "즐겨찾는 메뉴") allPath = "시작 메뉴";

            return allPath;
        }

        #endregion

        #region :: iRun_EditValueChanged :: 운영/개발 모드를 지정합니다.

        /// <summary>
        /// 운영/개발 모드를 지정합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iRun_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string run = iRun.EditValue.ToString();

                ShowWaitDialog("데이터베이스 연결 변경", String.Format("데이터베이스 연결을 변경 ( {0} ) 중입니다.", run));

                AppConfig.WEBSERVICEURL = run == "개발" ? DEVWEBURL : WEBURL;

                GetServerTime();

                CloseWaitDialog();
            }
            catch(Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iLinkMenu_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                PBarButtonItem item = e.Item as PBarButtonItem;

                if (item == null || CurrentUser == null) return;

                if (item.Name == "L001")
                {
                    Process.Start("IExplore", String.Format(item.CLASSNAME, CurrentUser.GTPSID, CurrentUser.VENDORCODE));
                }
                else if (item.Name == "L004")
                {
                    //Process.Start(@"filefullpath", "3e3713d18c57103da3504c2408270237");
                }
                else
                {
                    if (item.Tag.ToString() == "P")
                    {
                        Process.Start(item.CLASSNAME);
                    }
                    else
                    {
                        ExecuteWebBrowser(item.CLASSNAME);
                        //Process.Start("IExplore", item.CLASSNAME);
                    }
                }

                CloseWaitDialog();
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        private void ExecuteWebBrowser(string url)
        {
            ProcessStartInfo pInfo = new ProcessStartInfo();
            Process process = new Process();
            pInfo.FileName = @"cmd";
            pInfo.WindowStyle = ProcessWindowStyle.Hidden;             // cmd창이 숨겨지도록 하기
            pInfo.CreateNoWindow = true;                               // cmd창을 띄우지 안도록 하기

            pInfo.UseShellExecute = false;
            pInfo.RedirectStandardOutput = true;        // cmd창에서 데이터를 가져오기
            pInfo.RedirectStandardInput = true;          // cmd창으로 데이터 보내기
            pInfo.RedirectStandardError = true;          // cmd창에서 오류 내용 가져오기

            process.EnableRaisingEvents = false;
            process.StartInfo = pInfo;
            process.Start();
            
            process.StandardInput.Write(String.Format(@"start microsoft-edge:{0} ", url) + Environment.NewLine); // 마이크로소프트 엣지
            //process.StandardInput.Write(String.Format(@"start IExplore {0} ", url) + Environment.NewLine); // IE
            //process.StandardInput.Write(String.Format(@"start firefox {0} ", url) + Environment.NewLine); // 파이어폭스
            //process.StandardInput.Write(String.Format(@"start whale {0} ", url) + Environment.NewLine); // 네이버 웨일
            //process.StandardInput.Write(String.Format(@"start swing {0} ", url) + Environment.NewLine);  // 이스트소프트 스윙
        }

        #region :: iLanguage_EditValueChanged :: 사용언어가 변경되면 UI의 언어를 변경합니다.

        /// <summary>
        /// 사용언어가 변경되면 UI의 언어를 변경합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iLanguage_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (CurrentUser == null) return;

                CurrentUser.CURRENTLANGUAGE = CURRENTLANGUAGE;
                SetLocale(CURRENTLANGUAGE);

                CloseAllMdiChildren();
                //foreach (Form form in MdiChildren) (form as UIFrame).RaiseLoadEvent();
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        /// <summary>
        /// 시스템 언어에 따라 Ribbon의 Caption을 변경합니다.
        /// </summary>
        /// <param name="locale"></param>
        protected void SetLocale(string locale)
        {
            //CURRENTLANGUAGE = locale;
            iLanguage.EditValue = locale == "en-US" ? "English" : "한국어";

            if (_localeConverter == null)
                _localeConverter = new LocaleConverter(locale);
            else
                _localeConverter.SetLocale(locale);

            //iRefresh.Caption = _languageconverter.GetLanguageString("Refresh");
            //iFloat.Caption = _languageconverter.GetLanguageString("Floating");
            //iSelect.Caption = _languageconverter.GetLanguageString("Inquiry");
            //iNew.Caption = _languageconverter.GetLanguageString("New");
            //iSave.Caption = _languageconverter.GetLanguageString("Save");
            //iDelete.Caption = _languageconverter.GetLanguageString("Delete");
            //iPrint.Caption = _languageconverter.GetLanguageString("Print");
            //iCapture.Caption = _languageconverter.GetLanguageString("CaptureScreen");
            //iExport.Caption = _languageconverter.GetLanguageString("Export");
            //iHelpDesk.Caption = _languageconverter.GetLanguageString("HelpDesk");
            //iUpdate.Caption = _languageconverter.GetLanguageString("SystemUpdate");
            //navUpdate.Caption = _languageconverter.GetLanguageString("SystemUpdate");
            //iClose.Caption = _languageconverter.GetLanguageString("Close");
            //iAllClose.Caption = _languageconverter.GetLanguageString("CloseAll");
            //iExit.Caption = _languageconverter.GetLanguageString("Exit");
            //iReload.Caption = _languageconverter.GetLanguageString("Refresh");
            //iSignOn.Caption = _languageconverter.GetLanguageString("ChangeUser");
            //iExpand.Caption = _languageconverter.GetLanguageString(@"Expand/Collapse");
            //iChart.Caption = _languageconverter.GetLanguageString("Chart");
            //iHelp.Caption = _languageconverter.GetLanguageString("Help");
            //iShortCut.Caption = _languageconverter.GetLanguageString("ShortCut");
            //navButtonShortCut.Caption = _languageconverter.GetLanguageString("ShortCut");

            switch (locale.ToUpper())
            {
                case "KO-KR":
                    DevExpress.Accessibility.EditResAccLocalizer.Active = new PEditResAccLocalizer();
                    DevExpress.Utils.Filtering.Internal.FilterUIElementLocalizer.Active = new PFilterUIElementLocalizer();
                    DevExpress.XtraPrinting.Localization.PreviewLocalizer.Active = new PPreviewLocalizer();
                    DevExpress.XtraGrid.Localization.GridLocalizer.Active = new PGridLocalizer();
                    DevExpress.XtraEditors.Controls.Localizer.Active = new PEditControlLocalizer();
                    DevExpress.XtraTreeList.Localization.TreeListLocalizer.Active = new PTreeListLocalizer();
                    DevExpress.XtraPivotGrid.Localization.PivotGridLocalizer.Active = new PPivotGridLocalizer();
                    DevExpress.XtraScheduler.Localization.SchedulerLocalizer.Active = new PSchedulerLocalizer();
                    DevExpress.XtraRichEdit.Localization.XtraRichEditLocalizer.Active = new PRichEditLocalizer();
                    DevExpress.XtraVerticalGrid.Localization.VGridLocalizer.Active = new PVGridLocalizer();
                    DevExpress.Office.Localization.OfficeResLocalizer.Active = new POfficeResLocalizer();
                    DevExpress.XtraLayout.Localization.LayoutResLocalizer.Active = new PLayoutResLocalizer();
                    DevExpress.XtraSpreadsheet.Localization.XtraSpreadsheetResLocalizer.Active = new PSpreadsheetResLocalizer();
                    break;
                default:
                    DevExpress.Accessibility.EditResAccLocalizer.Active = new DevExpress.Accessibility.EditResAccLocalizer();
                    DevExpress.Utils.Filtering.Internal.FilterUIElementLocalizer.Active = new DevExpress.Utils.Filtering.Internal.FilterUIElementLocalizer();
                    DevExpress.XtraPrinting.Localization.PreviewLocalizer.Active = new DevExpress.XtraPrinting.Localization.PreviewLocalizer();
                    DevExpress.XtraGrid.Localization.GridLocalizer.Active = new DevExpress.XtraGrid.Localization.GridLocalizer();
                    DevExpress.XtraEditors.Controls.Localizer.Active = new DevExpress.XtraEditors.Controls.Localizer();
                    DevExpress.XtraTreeList.Localization.TreeListLocalizer.Active = new DevExpress.XtraTreeList.Localization.TreeListLocalizer();
                    DevExpress.XtraPivotGrid.Localization.PivotGridLocalizer.Active = new DevExpress.XtraPivotGrid.Localization.PivotGridLocalizer();
                    DevExpress.XtraScheduler.Localization.SchedulerLocalizer.Active = new DevExpress.XtraScheduler.Localization.SchedulerLocalizer();
                    DevExpress.XtraRichEdit.Localization.XtraRichEditLocalizer.Active = new DevExpress.XtraRichEdit.Localization.XtraRichEditLocalizer();
                    DevExpress.XtraVerticalGrid.Localization.VGridLocalizer.Active = new DevExpress.XtraVerticalGrid.Localization.VGridLocalizer();
                    DevExpress.Office.Localization.OfficeResLocalizer.Active = new DevExpress.Office.Localization.OfficeResLocalizer();
                    DevExpress.XtraLayout.Localization.LayoutResLocalizer.Active = new DevExpress.XtraLayout.Localization.LayoutResLocalizer();
                    DevExpress.XtraSpreadsheet.Localization.XtraSpreadsheetResLocalizer.Active = new DevExpress.XtraSpreadsheet.Localization.XtraSpreadsheetResLocalizer();
                    break;
            }
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(locale);

            if (locale == "zh-CHS") return;

            Thread.CurrentThread.CurrentCulture = new CultureInfo(locale);
        }

        #endregion

        #region :: tlMenu_MouseDoubleClick :: Mouse를 Double Click 하면 해당 UI를 실행합니다.

        /// <summary>
        /// Mouse를 Double Click 하면 해당 UI를 실행합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlMenu_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (tlMenu.FocusedNode == null || e.Button != System.Windows.Forms.MouseButtons.Left || tlMenu.FocusedNode.HasChildren) return;

                ExecuteUI((tlMenu.GetDataRecordByNode(tlMenu.FocusedNode) as DataRowView).Row["MENUID"], null);
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        #region :: tlMenu_FocusedNodeChanged :: 메뉴의 Focused Node가 변경되면 해당 UI를 실행합니다.

        /// <summary>
        /// 메뉴의 Focused Node가 변경되면 해당 UI를 실행합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlMenu_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            try
            {
                if (e.OldNode == null || e.Node.HasChildren) return;

                ExecuteUI((tlMenu.GetDataRecordByNode(e.Node) as DataRowView).Row["MENUID"], null);
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        #region :: tlMenu_GetSelectImage :: 메뉴의 선택 Image를 가져와 설정합니다.

        /// <summary>
        /// 메뉴의 선택 Image를 가져와 설정합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlMenu_GetSelectImage(object sender, DevExpress.XtraTreeList.GetSelectImageEventArgs e)
        {
            if (e.Node.ParentNode == null)
            {
                string imageidx = e.Node.GetDisplayText("IMAGEIDX");

                e.NodeImageIndex = Convert.ToInt32(imageidx == string.Empty ? "0" : imageidx);
            }
            else
            {
                if ((e.Node.Level == 1 || e.Node.Level == 2) && e.Node.HasChildren)
                    e.NodeImageIndex = 1;
                else
                {
                    string id = e.Node.GetValue("MENUID").ToString();

                    if (id.Contains("_FA"))
                        e.NodeImageIndex = 4;
                    else
                        e.NodeImageIndex = (e.FocusedNode) ? 3 : 2;
                }
            }
        }

        #endregion

        #region :: barManagerItemClick :: 대메뉴, 중간메뉴, 3/4단계 메뉴를 만든다.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barManagerTop_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (e.Item.Name == "iUser") ExecuteUI("CMN02", null);
                else if (e.Item.Name == "iLoadMenu")
                {
                    InitUserMenu();
                }
                else if (e.Item.Name == "iLogout")
                {
                    //bool firstLogin = CurrentUser == null ? true : false;
                    //if (e.Item.Caption == "LOGOUT")
                    //{
                    //    //CloseAllMdiChildren();
                    //    //ClearTopMenu();
                    //    //ClearMiddleMenu();
                    //    //Clear3rdMenu();
                    //    //tlMenu.DataSource = null;
                    //    //CurrentUser.SIGNINSEQ = -1;
                    //    //SetUserInfo("");
                    //    //e.Item.Caption = "LOGIN";

                    //    Close();
                    //}
                    //else
                    SignOn(false);
                }
                else if (e.Item.Name == "iCellInfo") ExecuteUI("CMN03", null);
                else if (e.Item.Name == "iNotify") ExecuteUI("CMN01", null);
                //else if (e.Item.Name == "barButtonItem8") InitUserMenu();

                if (!(e.Item is PBarButtonItem)) return;

                ClearMiddleMenu();
                Clear3rdMenu();

                CreateMiddleMenu(e.Item.Name);

                ToggleColor(barManagerTop, e.Item);
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        protected void SetLoginStatus(bool login)
        {
            LOGINFLAG = login;
            iLogout.Caption = login ? "사용자 변경" : "로그인";
        }

        private void ClearTopMenu()
        {
            List<BarItem> item = new List<BarItem>();

            foreach (BarItem bItem in barManagerTop.Items)
            {
                if (!(bItem is PBarButtonItem)) continue;

                item.Add(bItem);
            }

            foreach (BarItem bItem in item)
            {
                barManagerTop.Items.Remove(bItem);
            }
        }

        private void ClearMiddleMenu()
        {
            List<BarItem> item = new List<BarItem>();

            foreach (BarItem bItem in barManagerMiddle.Items)
            {
                if (!(bItem is PBarButtonItem)) continue;

                item.Add(bItem);
            }

            foreach (BarItem bItem in item)
            {
                barManagerMiddle.Items.Remove(bItem);
            }
        }

        private void Clear3rdMenu()
        {
            List<BarItem> item = new List<BarItem>();

            foreach (BarItem bItem in barManagerMenu.Items)
            {
                if (bItem.Name == "iFMenu") continue;
                //if (!(bItem is PBarButtonItem)) continue;

                item.Add(bItem);
            }

            foreach (BarItem bItem in item)
            {
                if (bItem.Tag != null) continue;
                barManagerMenu.Items.Remove(bItem);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentMenuId"></param>
        private void CreateMiddleMenu(string parentMenuId)
        {
            DataSet ds = tlMenu.DataSource as DataSet;

            PBarButtonItem button = null;

            string filter = String.Format("FAVORITES <> 0 AND PARENTMENUID = '{0}'", parentMenuId);
            string sort = "IDX";
            DataRow[] drs = ds.Tables[0].Select(filter, sort);

            int idx = 0;

            foreach (DataRow dr in drs)
            {
                button = new PBarButtonItem();
                button.Caption = dr["MENUNAME"].ToString();
                button.Name = dr["MENUID"].ToString();
                button.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
                
                button.ItemAppearance.SetFont(new Font("나눔고딕", 8.75F, FontStyle.Bold));
                
                barMiddle.AddItem(button).BeginGroup = false;
                
                if (idx == 0) button.PerformClick();

                idx++;
            }

            //foreach (DataRow dr in ds.Tables[0].Rows)
            //{
            //    if (dr["FAVORITES"].ToString() == "0") continue;

            //    if (dr["LVL"].ToString() == "1" && dr["PARENTMENUID"].ToString() == parentMenuId)
            //    {
            //        button = new PBarButtonItem();
            //        button.Caption = dr["MENUNAME"].ToString();
            //        button.Name = dr["MENUID"].ToString();
            //        button.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            //        barMiddle.AddItem(button).BeginGroup = false;
            //    }
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barManagerMiddle_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (e.Item.Name == "iVisible")
                {
                    pnlTreeMenu.HideImmediately();
                    pnlMessage.HideImmediately();

                    pnlTop.Visible = !pnlTop.Visible;

                    iVisible.Caption = pnlTop.Visible ? "접기" : "펼치기";
                    //iVisible.ImageOptions.ImageUri.Uri = pnlTop.Visible ? "AlignHorizontalTop;GrayScaled" : "AlignHorizontalBottom;GrayScaled";
                }
                else if (e.Item.Name == "iCloseAll")
                {
                    if (MdiChildren.Length == 0) return;

                    if (ShowMsgBox($"실행 중인 모든 UI [ {MdiChildren.Length} 개 ] 를 닫습니다. 계속 하시겠습니까?", "모두 닫기", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                           == System.Windows.Forms.DialogResult.Yes)
                        CloseAllMdiChildren();
                }
                else if (e.Item.Name == "iUpdate") ExitAndUpdate(true);
                else if (e.Item.Name == "iNotice") ExecuteWebBrowser(@"https://sway.cloud.microsoft/U6rI3CDATDLH5ed7?ref=Link");

                if (!(e.Item is PBarButtonItem)) return;

                Clear3rdMenu();

                Create2DepthMenu(e.Item.Name);

                ToggleColor(barManagerMiddle, e.Item);
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void Create2DepthMenu(string parentMenuId)
        {
            DataSet ds = tlMenu.DataSource as DataSet;

            PBarSubItem item = null;
            PBarButtonItem button = null;

            string filter = String.Format("FAVORITES <> 0 AND PARENTMENUID = '{0}'", parentMenuId);
            string sort = "IDX";
            DataRow[] drs = ds.Tables[0].Select(filter, sort);

            foreach (DataRow dr in drs)
            {
                if (dr["CLASSNAME"].ToString() == "" && dr["DLLNAME"].ToString() == "")
                {
                    item = new PBarSubItem();
                    item.Caption = dr["MENUNAME"].ToString();
                    item.Name = dr["MENUID"].ToString();
                    //Create3DepthMenu(item, item.Name);

                    //item.ItemAppearance.SetFont(new Font("나눔고딕", 8.75F, FontStyle.Bold));

                    barMenu.AddItem(item).BeginGroup = false;

                    Create3DepthMenu(item, item.Name);
                }
                else
                {
                    button = new PBarButtonItem();
                    button.Caption = dr["MENUNAME"].ToString();
                    button.Name = dr["MENUID"].ToString();
                    button.DLLNAME = dr["DLLNAME"].ToString();
                    button.CLASSNAME = dr["CLASSNAME"].ToString();

                    button.ItemAppearance.SetFont(new Font("나눔고딕", 8.75F, FontStyle.Bold));

                    barMenu.AddItem(button).BeginGroup = false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="parentMenuId"></param>
        /// <returns></returns>
        private void Create3DepthMenu(PBarSubItem item, string parentMenuId)
        {
            DataSet ds = tlMenu.DataSource as DataSet;

            PBarButtonItem button = null;

            string filter = String.Format("FAVORITES <> 0 AND PARENTMENUID = '{0}' AND CLASSNAME <> '' AND DLLNAME <> ''", parentMenuId);
            string sort = "IDX";
            DataRow[] drs = ds.Tables[0].Select(filter, sort);

            foreach (DataRow dr in drs)
            {
                //if (dr["CLASSNAME"].ToString() == "" || dr["DLLNAME"].ToString() == "") continue;

                button = new PBarButtonItem();
                button.Caption = dr["MENUNAME"].ToString();
                button.Name = dr["MENUID"].ToString();
                button.DLLNAME = dr["DLLNAME"].ToString();
                button.CLASSNAME = dr["CLASSNAME"].ToString();

                item.AddItem(button).BeginGroup = Convert.ToBoolean(dr["ISBEGINGROUP"]);
                button.ItemAppearance.SetFont(new Font("나눔고딕", 8.75F));
            }

            //foreach (DataRow dr in ds.Tables[0].Rows)
            //{
            //    if (dr["FAVORITES"].ToString() == "0") continue;

            //    if (dr["LVL"].ToString() == "3" && dr["PARENTMENUID"].ToString() == parentMenuId)
            //    {
            //        if (dr["CLASSNAME"].ToString() == "" || dr["DLLNAME"].ToString() == "") continue;

            //        button = new PBarButtonItem();
            //        button.Caption = dr["MENUNAME"].ToString();
            //        button.Name = dr["MENUID"].ToString();
            //        button.DLLNAME = dr["DLLNAME"].ToString();
            //        button.CLASSNAME = dr["CLASSNAME"].ToString();

            //        item.AddItem(button).BeginGroup = false;
            //        button.ItemAppearance.SetFont(new Font("나눔고딕", 8F));
            //    }
            //}

            //return item;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barManagerMenu_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                PBarButtonItem item = e.Item as PBarButtonItem;

                if (item == null || item.DLLNAME == "" || item.CLASSNAME == "") return;

                TreeListNode focusedNode = tlMenu.FindNodeByKeyID(item.Name);

                if (tlMenu.FocusedNode == focusedNode)
                    ExecuteUI(e.Item.Name, null);
                else
                    tlMenu.FocusedNode = focusedNode;
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barManagerStatus_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (ActiveMdiChild == null) return;
                if (e.Item.Name == "iLinkMenu") return;
                switch (e.Item.Name)
                {
                    case "iFavorites":
                        RegistorFavorites();
                        break;
                    case "iStartMenu":
                        RegistorStartMenu();
                        break;
                    case "iTabClose":
                        ActiveMdiChild.Close();
                        break;
                    case "iTabCloseAll":
                        CloseAllMdiChildren();
                        break;
                    case "iTabCloseDiff":
                        CloseAllMdiChildren(false);
                        break;
                }
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="barManager"></param>
        /// <param name="clickItem"></param>
        private void ToggleColor(DevExpress.XtraBars.BarManager barManager, DevExpress.XtraBars.BarItem clickItem)
        {
            foreach (DevExpress.XtraBars.BarItem item in barManager.Items)
            {
                if (!(item is PBarButtonItem)) continue;

                (item as PBarButtonItem).Down = item == clickItem ? true : false;
            }
        }

        #endregion

        #region :: xtraTabbedMdiManager_SelectedPageChanged :: Active Mdi Child가 변경되면 발생합니다.

        /// <summary>
        /// Active Mdi Child가 변경되면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xtraTabbedMdiManager_SelectedPageChanged(object sender, EventArgs e)
        {
            ISMODIFIED = false;

            siMessage.Caption = LOCALECONVERTER.GetLocaleString("Ready");
            siDBTime.Caption = string.Empty;

            IFrameUI activeUI = (ActiveMdiChild as IFrameUI);

            if (activeUI == null) return;

            ISMODIFIED = activeUI.ISMODIFIED;
            ActiveMdiChild.Show();

            DataRow row = GetFocusedMenuRow(activeUI.MENUID);

            if (row == null) return;

            var isMulti = Convert.ToBoolean(row["ISMULTIEXECUTE"]);

            if (!isMulti) tlMenu.FocusedNode = tlMenu.FindNodeByKeyID(activeUI.MENUID);

            tlMenu.Refresh();
            TopMenuSelect(activeUI.TOPMENUID);
            MiddleMenuSelect(activeUI.MIDDLEMENUID);

            SetMenuPath(activeUI.MENUID, ActiveMdiChild.Text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectMenuId"></param>
        private void TopMenuSelect(string selectMenuId)
        {
            foreach (BarItem item in barManagerTop.Items)
            {
                if (!(item is PBarButtonItem)) continue;

                if (item.Name == selectMenuId)
                {
                    item.PerformClick();
                    (item as PBarButtonItem).Down = true;
                    ToggleColor(barManagerTop, item);
                    break;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectMenuId"></param>
        private void MiddleMenuSelect(string selectMenuId)
        {
            foreach (BarItem item in barManagerMiddle.Items)
            {
                if (!(item is PBarButtonItem)) continue;

                if (item.Name == selectMenuId)
                {
                    item.PerformClick();
                    (item as PBarButtonItem).Down = true;
                    ToggleColor(barManagerMiddle, item);
                    break;
                }
            }
        }

        #endregion

        #region :: xtraTabbedMdiManager_MouseMove :: 탭 머리글 도구 설명에 썸네일을 표시합니다.

        /// <summary>
        /// 탭 머리글 도구 설명에 썸네일을 표시합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xtraTabbedMdiManager_MouseMove(object sender, MouseEventArgs e)
        {
            BaseTabHitInfo hi = xtraTabbedMdiManager.CalcHitInfo(e.Location);

            if (hi.Page == xtraTabbedMdiManager.SelectedPage) return;

            if (hi.HitTest == XtraTabHitTest.PageHeader)
                ShowThumbnails(hi.Page);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        private void ShowThumbnails(DevExpress.XtraTab.IXtraTabPage page)
        {
            ToolTipControlInfo toolTip = new ToolTipControlInfo();
            toolTip.ToolTipType = ToolTipType.SuperTip;
            toolTip.Interval = 400;
            toolTip.Object = page;

            SuperToolTip superTip = new SuperToolTip();
            toolTip.SuperTip = superTip;
            superTip.Items.AddTitle($" {page.Text}  미리보기");
            superTip.Items.AddSeparator();

            ToolTipItem ttItem = new ToolTipItem();
            ttItem.Image = AppUtil.FormToBitmap((page as XtraMdiTabPage).MdiChild, new Size(400, 240));
            superTip.Items.Add(ttItem);

            ToolTipController.DefaultController.ShowHint(toolTip);
        }

        #endregion

        #region :: xtraTabbedMdiManager_MouseDown ::

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xtraTabbedMdiManager_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            BaseTabHitInfo hi = xtraTabbedMdiManager.CalcHitInfo(new Point(e.X, e.Y));

            xtraTabbedMdiManager.SelectedPage = (hi.Page as XtraMdiTabPage);

            if (hi.HitTest == XtraTabHitTest.PageHeader)
            {
                popMenuTab.ShowPopup(Cursor.Position);
            }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: SetWebserviceURL :: 웹서비스의 URL을 설정합니다.(RUN/DEV)

        /// <summary>
        /// 웹서비스의 URL을 설정합니다.(RUN/DEV)
        /// </summary>
        /// <param name="runURL">운영 웹서비스</param>
        /// <param name="devURL">개발 웹서비스</param>
        public void SetWebserviceURL(string runURL, string devURL)
        {
            WEBURL = runURL;
            DEVWEBURL = devURL;
        }

        #endregion

        #region :: ShowInfoMessage :: Alert Message를 보여줍니다.

        private int ALERTIDX = 1;

        /// <summary>
        /// Alert Message를 보여줍니다.
        /// </summary>
        /// <param name="title">Alert Control Caption</param>
        /// <param name="subject">Alert Message</param>
        /// <param name="text">Hot Tracked Text</param>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        ///
        /// </remarks>
        public void ShowInfoMessage(string title, string subject, string text)
        {
            ShowInfoMessage(title, subject, text, Color.Empty);
        }

        /// <summary>
        /// Alert Message를 보여줍니다.
        /// </summary>
        /// <param name="title">Alert Control Caption</param>
        /// <param name="subject">Alert Message</param>
        /// <param name="text">Hot Tracked Text</param>
        /// <param name="color">색깔</param>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        ///
        /// </remarks>
        public void ShowInfoMessage(string title, string subject, string text, Color color)
        {
            pinBtnDown = false;

            AlertControlShow(title, subject, text, ALERTIDX, color);
            //pnlMessage.ShowSliding();

            DataTable dt = lbMessage.DataSource as DataTable;

            if (dt == null) return;

            DataRow dr = dt.NewRow();

            dr["IDX"] = ALERTIDX++;
            dr["TITLE"] = title;
            dr["SUBJECT"] = subject;
            dr["TEXT"] = text;
            dr["DATE"] = GetCurrentTime().ToString("MM-dd hh:mm");
            dr["COLOR"] = color.Name;

            dt.Rows.InsertAt(dr, 0);

            lbMessage.SelectedIndex = 0;
        }

        /// <summary>
        /// 메세지 삭제
        /// </summary>
        public void RemoveMessage(string text)
        {
            DataTable dt = lbMessage.DataSource as DataTable;

            if (dt == null) return;

            dt.RemoveRow("TEXT", text);
        }

        #endregion

        #region :: ExecuteUI :: UI를 실행합니다.

        /// <summary>
        /// UI를 실행합니다.
        /// </summary>
        /// <param name="menuID">MENU ID</param>
        /// <param name="linkParams">Link Event Parameters</param>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        ///
        /// </remarks>
        protected internal void ExecuteUI(object menuID, ParamCollection linkParams)
        {
            string menuid = menuID.ToString().Replace("_FA", "");           //즐겨찾기 메뉴 실행할때는 _FA 제외
            //iNavigator.EditValue = string.Empty;

            DataRow row = GetFocusedMenuRow(menuid);

            if (row == null) return;

            string dllPath = row["DLLNAME"].ToString();
            string className = row["CLASSNAME"].ToString();
            string screenid = row["SCREENID"].ToString();

            if (dllPath == string.Empty || className == string.Empty)
            {
                ShowMsgBox($"메뉴 ID [ {menuID} ] 를 확인하세요.");
                return;
            }

            string text = row["MENUNAME"].ToString();
            string helpPath = row["HELPURL"].ToString();
            var isCommon = Convert.ToBoolean(row["ISCOMMON"]);
            var isMulti = Convert.ToBoolean(row["ISMULTIEXECUTE"]);

            //ExecutePopup(text, dllPath, className, null);

            ExecuteUI(menuid, screenid, text, dllPath, className, helpPath, linkParams, isCommon, isMulti);
        }

        /// <summary>
        /// Tree에서 메뉴 ID를 확인합니다.
        /// </summary>
        /// <param name="menuID"></param>
        /// <returns></returns>
        protected object FindMenuNode(object menuID)
        {
            return tlMenu.GetDataRecordByNode(tlMenu.FindNodeByKeyID(menuID));
        }

        /// <summary>
        /// Tree에서 선택한 Menu를 가져옵니다.
        /// </summary>
        /// <returns></returns>
        private DataRow GetFocusedMenuRow(object menuID)
        {
            DataRowView drv = tlMenu.GetDataRecordByNode(tlMenu.FindNodeByKeyID(menuID)) as DataRowView;

            if (drv == null)
            {
                ShowMsgBox(String.Format("[ {0} ] 은 권한이 없거나 존재하지 않는 UI 입니다.", menuID), "정보");
                return null;
            }

            tlMenu.Refresh();

            return drv.Row;
        }

        /// <summary>
        /// Menu의 Full Path를 가져옵니다.
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        private string GetLastParentMenu(object menuId)
        {
            string allPath = string.Empty;
            TreeListNode node = tlMenu.FindNodeByKeyID(menuId);
            TreeListNode pNode = node.ParentNode;

            List<string> fullPath = new List<string>();
            fullPath.Add(node.GetDisplayText("MENUNAME"));

            while (pNode != null)
            {
                node = pNode;
                pNode = node.ParentNode;
                fullPath.Add(node.GetDisplayText("MENUNAME"));
            }

            allPath = fullPath.ToArray()[fullPath.Count - 1];

            return allPath;
        }

        /// <summary>
        /// Menu의 Full Path를 가져옵니다.
        /// </summary>
        /// <param name="ui"></param>
        /// <param name="menuId"></param>
        /// <returns></returns>
        private string GetMenuFullPath(IFrameUI ui, object menuId)
        {
            string allPath = string.Empty;
            TreeListNode node = tlMenu.FindNodeByKeyID(menuId);
            TreeListNode pNode = node.ParentNode;

            List<string> fullPath = new List<string>();
            fullPath.Add(node.GetDisplayText("MENUNAME"));

            while (pNode != null)
            {
                node = pNode;
                pNode = node.ParentNode;
                fullPath.Add(node.GetDisplayText("MENUNAME"));

                switch (node.Level)
                {
                    case 0:
                        ui.TOPMENUID = node.GetValue("MENUID").ToString();
                        break;
                    case 1:
                        ui.MIDDLEMENUID = node.GetValue("MENUID").ToString();
                        break;
                }
            }

            for (int i = fullPath.Count - 1; i >= 0; i--)
            {
                allPath += fullPath.ToArray()[i];

                if (i > 0) allPath += "  ▶  ";
            }

            if (allPath == "즐겨찾는 메뉴") allPath = "시작 메뉴";

            return allPath;
        }

        /// <summary>
        /// UI를 실행합니다.
        /// </summary>
        /// <param name="menuId">MENU ID</param>
        /// <param name="screenId">SCREEN ID</param>
        /// <param name="text">Form 제목</param>
        /// <param name="dllPath">Dll 경로</param>
        /// <param name="className">Class 명</param>
        /// <param name="helpPath">도움말 경로</param>
        /// <param name="linkParams">Link Event Parameters</param>
        /// <param name="isCommon">Plant 사용 여부</param>
        /// <param name="isMulti">다중 실행 여부</param>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        ///
        /// </remarks>
        private void ExecuteUI(string menuId, string screenId, string text, string dllPath, string className, string helpPath, ParamCollection linkParams, bool isCommon, bool isMulti)
        {
            if (!isMulti)
            {
                if (CheckExecuteUI(menuId, isCommon, linkParams)) return;
            }

            CreateUI(menuId, screenId, text, dllPath, className, helpPath, linkParams, isCommon);
        }

        /// <summary>
        /// 실행 중인 UI 가 있는지를 검사합니다.
        /// </summary>
        /// <param name="menuID">MENU ID</param>
        /// <param name="isCommon">Plant 사용 여부</param>
        /// <param name="linkParams">Link Event Parameters</param>
        /// <returns></returns>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        ///
        /// </remarks>
        private bool CheckExecuteUI(string menuID, bool isCommon, ParamCollection linkParams)
        {
            if (MdiChildren.Length == 0) return false;

            foreach (Form childForm in MdiChildren)
            {
                //if (isCommon)
                //{
                if ((childForm as UIFrame).MENUID == menuID)
                {
                    childForm.BringToFront();

                    if (childForm is UIFrame)
                    {
                        (childForm as UIFrame).LinkParams = linkParams;
                        (childForm as UIFrame).RaiseLinkEvent();
                    }
                    ActivateMdiChild(childForm);

                    return true;
                }
                //}
                //else
                //{
                //    if ((childForm as UIFrame_MES).MENUID == menuID && (childForm as UIFrame_MES).VENDORCODE == CurrentUser.VENDORCODE && (childForm as UIFrame_MES).PLANTCODE == CurrentUser.PLANTCODE)
                //    {
                //        childForm.BringToFront();

                //        if (childForm is UIFrame_MES)
                //        {
                //            (childForm as UIFrame_MES).LinkParams = linkParams;
                //            (childForm as UIFrame_MES).RaiseLinkEvent();
                //        }
                //        ActivateMdiChild(childForm);

                //        return true;
                //    }
                //}

            }

            return false;
        }

        /// <summary>
        /// Form을 생성하고 실행합니다.
        /// </summary>
        /// <param name="menuId">MENU ID</param>
        /// <param name="screenId">SCREEN ID</param>
        /// <param name="text">Form 제목</param>
        /// <param name="dllPath">Dll 경로</param>
        /// <param name="className">Class 명</param>
        /// <param name="helpPath">도움말 경로</param>
        /// <param name="linkParams">Link Event Parameters</param>
        /// <param name="isCommon">공통 사용 여부</param>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        ///
        /// </remarks>
        private void CreateUI(string menuId, string screenId, string text, string dllPath, string className, string helpPath, ParamCollection linkParams, bool isCommon)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                DataTable menuAuths = CheckUserMenuAuth(menuId);

                if (menuAuths.Rows.Count == 0)
                {
                    ShowMsgBox(String.Format("[ {0} ] 에 대한 권한이 없어요. 메뉴를 [ 새로 고침 ] 하세요.", text));
                    return;
                }
                else if (menuAuths.Rows.Count > 1)
                {
                    ShowMsgBox("현재 사용자 권한에 이상이 있습니다. 관리자에게 문의 하세요.");
                    return;
                }

                string lastMenu = GetLastParentMenu(menuId);
                //ShowWaitDialog(String.Format("[ {0}[{1}] ] Loading...", text, CurrentUser.PLANTNAME));
                ShowWaitDialog(String.Format("[ {0}[{1}] ] Loading...", text, lastMenu));

                DataRow dr = menuAuths.Rows[0];

                SaveMenuExecuteLog(menuId);

                //UIFrame uiFrame = AppUtil.CreateInstanceForm(dllPath, className) as UIFrame;
                UIFrame uiFrame = AppUtil.CreateInstance<UIFrame>(dllPath, className);
                //uiFrame.Text = String.Format("{0}[{1}]", text, CurrentUser.PLANTNAME);
                uiFrame.Text = String.Format("{0}[{1}]", text, lastMenu);
                uiFrame.Dock = DockStyle.Top;

                uiFrame.SelectAuth = Convert.ToBoolean(dr["SELECTAUTH"]);
                uiFrame.NewAuth = Convert.ToBoolean(dr["NEWAUTH"]);
                uiFrame.SaveAuth = Convert.ToBoolean(dr["SAVEAUTH"]);
                uiFrame.DelAuth = Convert.ToBoolean(dr["DELAUTH"]);
                uiFrame.CopyAuth = Convert.ToBoolean(dr["COPYAUTH"]);
                uiFrame.SetMenuPath(GetMenuFullPath(uiFrame, menuId));

                uiFrame.MdiParent = this;
                uiFrame.MENUID = menuId;
                uiFrame.SCREENID = screenId;
                uiFrame.VENDORCODE = iVendorCode.EditValue.ToString();
                uiFrame.PLANTCODE = iPlantCode.EditValue.ToString();
                uiFrame.HELPPATH = helpPath;
                uiFrame.CLASSNAME = GetClassCaption(className);

                uiFrame.Show();

                uiFrame.RaiseAuthEvent();

                uiFrame.LinkParams = linkParams;
                uiFrame.RaiseLinkEvent();
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
            finally
            {
                Cursor = Cursors.Default;

                CloseWaitDialog();
            }
        }

        /// <summary>
        /// 사용자 권한을 UI가 실행될 때 실시간으로 CHECK 하여 실행합니다.
        /// </summary>
        /// <param name="menuId">메뉴 ID</param>
        /// <returns></returns>
        private DataTable CheckUserMenuAuth(string menuId)
        {
            DataSet ds;
            const string queryId = @"dbo.UserMenuAuth_Check";

            string[] paramList = new string[] { "@MENUID", "@USERID" };
            object[] valueList = new object[] { menuId, CurrentUser.USERID };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            }

            return ds.Tables[0];
        }


        /// <summary>
        /// Class Caption을 가져옵니다.
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        ///
        /// </remarks>
        private string GetClassCaption(string className)
        {
            var cName = string.Empty;

            try
            {
                cName = className.Substring(className.LastIndexOf(".") + 1);
            }
            catch
            {
                cName = string.Empty;
            }

            return cName;
        }

        #endregion

        #region :: ExecutePopup :: Popup을 생성하고 실행합니다.

        /// <summary>
        /// Popup을 생성하고 실행합니다.
        /// </summary>
        /// <param name="text">Popup 제목</param>
        /// <param name="dllPath">Dll 경로</param>
        /// <param name="className">Class 명</param>
        /// <param name="popParams">Popup Parameters</param>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        ///
        /// </remarks>
        public object ExecutePopup(string text, string dllPath, string className, ParamCollection popParams)
        {
            try
            {
                CloseWaitDialog();

                //PopupFrame popFrame = AppUtil.CreateInstanceForm(dllPath, className) as PopupFrame;
                PopupFrame popFrame = AppUtil.CreateInstance<PopupFrame>(dllPath, className);

                if (popFrame == null) return null;

                string adminText = (CurrentUser == null || !CurrentUser.ISADMIN) ? "" : $" - {className}";
                popFrame.Owner = this;
                popFrame.Text = $"{(LOCALECONVERTER == null ? text : LOCALECONVERTER.GetLocaleString(text))}{adminText}";
                popFrame.PopParams = popParams;

                if (ActiveMdiChild != null) SaveMenuExecuteLog((ActiveMdiChild as UIFrame).MENUID);

                if (popFrame.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    return popFrame.POPUPVALUE;
                else
                    return null;
            }
            catch
            {
                CloseWaitDialog();
                throw;
            }
        }

        #endregion

        #region :: SetMenuPath :: 메뉴 정보를 Status Bar에 보여줍니다.

        /// <summary>
        /// 메뉴 정보를 Status Bar에 보여줍니다.
        /// </summary>
        /// <param name="menuid"></param>
        /// <param name="text"></param>
        internal void SetMenuPath(string menuid, string text)
        {
            //string menuinfo = menuid == "" ? "" : String.Format("[{0}] {1} {2}", menuid, text, CurrentUser.ISADMIN ? String.Format("- {0}", (ActiveMdiChild as UIFrame).CLASSNAME) : "");
            //siMenuInfo.Caption = menuinfo;

            siMenuId.Caption = menuid;
            siMenuName.Caption = menuid == "" ? "" : String.Format("{0} : {1}", text, (ActiveMdiChild as UIFrame).CLASSNAME);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        public void SetSiMessage(string caption)
        {
            siMessage.Caption = caption;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        protected void SetConnectionType(string caption)
        {
            iConnectionType.Caption = caption;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        public void SetSiDBTime(string caption)
        {
            siDBTime.Caption = caption;
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Protected)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// PLC 접속 상태를 보여줍니다.
        /// </summary>
        /// <param name="status"></param>
        protected void SetPlcStatus(PlcType plcType, PlcStatus status)
        {
            var btn = plcType == PlcType.Main ? barBtn_MainPLC : barBtn_SubPLC;

            switch (status)
            {
                case PlcStatus.Disconnected:
                    //btn.Caption = (plcType == PlcType.Main ? "1번 PLC 미연결" : "2번 PLC 미연결");
                    btn.ImageOptions.ImageIndex = -1;
                    btn.ImageOptions.SvgImage = null;
                    btn.ImageOptions.Image = Properties.Resources.DisConn;
                    btn.ImageOptions.Image = new Bitmap(Properties.Resources.DisConn, new Size(32, 32));
                    break;

                case PlcStatus.Connecting:
                    //btn.Caption = (plcType == PlcType.Main ? "1번 PLC 연결중..." : "2번 PLC 연결중...");
                    btn.ImageOptions.ImageIndex = -1;
                    btn.ImageOptions.SvgImage = null;
                    btn.ImageOptions.Image = Properties.Resources.con;
                    btn.ImageOptions.Image = new Bitmap(Properties.Resources.con, new Size(32, 32));
                    break;

                case PlcStatus.Connected:
                    //btn.Caption = (plcType == PlcType.Main ? "1번 PLC 연결됨" : "2번 PLC 연결됨");
                    btn.ImageOptions.ImageIndex = -1;
                    btn.ImageOptions.SvgImage = null;
                    btn.ImageOptions.Image = Properties.Resources.Conn;
                    btn.ImageOptions.Image = new Bitmap(Properties.Resources.Conn, new Size(32, 32));
                    break;
            }
        }

        #region :: InitVendorCode :: Ribbon의 Vendor Data를 초기화합니다.

        /// <summary>
        /// Ribbon의 Vendor Data를 초기화합니다.
        /// </summary>
        /// <param name="dt"></param>
        protected void InitVendorCode(DataTable dt)
        {
            iVendorCode.EditValue = "";
            cboVendorCode.DataSource = null;
            if (dt == null || dt.Rows.Count == 0) return;

            cboVendorCode.Columns.Clear();
            iVendorCode.EditValue = "";

            cboVendorCode.DataSource = dt;
            cboVendorCode.ValueMember = AppConfig.VALUEMEMBER;
            cboVendorCode.DisplayMember = AppConfig.DISPLAYMEMBER;

            var columns = dt.GetColumnsFromDataTable();

            foreach (string column in columns)
            {
                var col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo { FieldName = column, Caption = column, Width = 70 };
                if (column == AppConfig.VALUEMEMBER)
                    col.Visible = false;
                else
                {
                    col.Alignment = HorzAlignment.Default;
                    col.Visible = true;
                }
                cboVendorCode.Columns.Add(col);
            }

            cboVendorCode.ShowHeader = cboVendorCode.Columns.Count < 3 ? false : true;

            iVendorCode.EditValue = dt.Rows[0][AppConfig.VALUEMEMBER];
        }

        #endregion

        #region :: InitPlantCode :: Ribbon의 Plant Data를 초기화합니다.

        /// <summary>
        /// Ribbon의 Plant Data를 초기화합니다.
        /// </summary>
        /// <param name="dt"></param>
        protected void InitPlantCode(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0) return;

            cboPlantCode.Columns.Clear();
            iPlantCode.EditValue = string.Empty;

            cboPlantCode.DataSource = dt;
            cboPlantCode.ValueMember = AppConfig.VALUEMEMBER;
            cboPlantCode.DisplayMember = AppConfig.DISPLAYMEMBER;

            var columns = dt.GetColumnsFromDataTable();

            foreach (string column in columns)
            {
                var col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo { FieldName = column, Caption = column, Width = 70 };
                if (column == AppConfig.VALUEMEMBER)
                {
                    col.Visible = false;
                }
                else
                {
                    col.Alignment = HorzAlignment.Default;
                    col.Visible = true;
                }

                if (cboPlantCode.Columns.Count < 2)
                    cboPlantCode.Columns.Add(col);
            }

            cboPlantCode.ShowHeader = cboPlantCode.Columns.Count < 3 ? false : true;

            iPlantCode.EditValue = dt.Rows[0][AppConfig.VALUEMEMBER];
        }

        #endregion

        #region :: ExitAndUpdate :: 업데이트를 하기 위해 시스템을 종료합니다.

        /// <summary>
        /// 업데이트를 하기 위해 시스템을 종료합니다.
        /// </summary>
        /// <param name="ismessage"></param>
        protected void ExitAndUpdate(bool ismessage)
        {
            //if(ismessage)
            //{
            if (!ismessage || ShowMsgBox("업데이트를 시작하시겠습니까? 프로그램이 재시작 됩니다.", "업데이트", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                           == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();

                string fileName = Path.Combine(AppConfig.ASSEMBLYFOLDER, Settings.Default.ExeFile);

                ProcessStartInfo pInfo = new ProcessStartInfo() { FileName = fileName };
                Process.Start(pInfo);
            }
            //}
            //else
            //{
            //    Application.Exit();

            //    ProcessStartInfo pInfo = new ProcessStartInfo() { FileName = "IExplore.exe", CreateNoWindow = true, WindowStyle = ProcessWindowStyle.Minimized, Arguments = UPDATEURL };
            //    Process process = Process.Start(pInfo);
            //    process.Close();
            //}
        }

        #endregion

        #region  :: InitDocking :: 메뉴 위치를 초기화합니다.

        /// <summary>
        /// 메뉴 위치를 초기화합니다.
        /// </summary>
        protected void InitDocking(string docking)
        {
            if (docking == string.Empty) return;

            switch (docking)
            {
                case "Top":
                    if (pnlTreeMenu.Dock == DevExpress.XtraBars.Docking.DockingStyle.Top) return;
                    pnlTreeMenu.Dock = DevExpress.XtraBars.Docking.DockingStyle.Top;
                    break;
                case "Bottom":
                    if (pnlTreeMenu.Dock == DevExpress.XtraBars.Docking.DockingStyle.Bottom) return;
                    pnlTreeMenu.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
                    break;
                case "Right":
                    if (pnlTreeMenu.Dock == DevExpress.XtraBars.Docking.DockingStyle.Right) return;
                    pnlTreeMenu.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
                    break;
                default:
                    if (pnlTreeMenu.Dock == DevExpress.XtraBars.Docking.DockingStyle.Left) return;
                    pnlTreeMenu.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
                    break;
            }
        }

        #endregion

        #region :: SignOn :: 사용자 Sign IN 처리합니다.

        /// <summary>
        /// 사용자 Sign ON 처리합니다.
        /// </summary>
        /// <param name="firstLogin">처음 로그인</param>
        protected virtual void SignOn(bool firstLogin)
        {
            throw new InvalidOperationException("Must Override SignOn()");
        }

        #endregion

        #region :: SetUpdateButtonVisible :: 업데이트 버튼의 Visible을 설정합니다.

        /// <summary>
        /// 업데이트 버튼의 Visible을 설정합니다.
        /// </summary>
        /// <param name="visible"></param>
        /// <param name="hint"></param>
        protected void SetUpdateButtonVisible(bool visible, string hint)
        {
            //navUpdate.Visible = visible;

            iUpdate.Visibility = visible ? BarItemVisibility.Always : BarItemVisibility.Never;
            iUpdate.Hint = hint;
        }

        #endregion

        #region :: SetVendor :: Ribbon의 Vendor을 설정합니다.

        /// <summary>
        /// Ribbon의 Vendor을 설정합니다.
        /// </summary>
        /// <param name="vendorCode">업체코드</param>
        protected internal void SetVendor(string vendorCode)
        {
            //iVendorCode_EditValueChanged(null, null);
            iVendorCode.EditValue = vendorCode;
        }

        #endregion

        #region :: SetPlant :: Ribbon의 Plant를 설정합니다.

        /// <summary>
        /// Ribbon의 Plant를 설정합니다.
        /// </summary>
        /// <param name="plantCode">사업장코드</param>
        protected internal void SetPlant(string plantCode)
        {
            //iPlantCode_EditValueChanged(null, null);
            iPlantCode.EditValue = plantCode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        protected void SetUserInfo(string info)
        {
            iUserConfig.Caption = info;
            //iUser.Caption = info;
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Internal)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: CaptureImage :: 현재 화면을 Capture 합니다.

        /// <summary>
        /// 현재 화면을 Capture 합니다.
        /// </summary>
        internal void CaptureImage()
        {
            if (ActiveMdiChild == null && xtraTabbedMdiManager.ActiveFloatForm == null) return;

            //Form form = xtraTabbedMdiManager.ActiveFloatForm ?? ActiveMdiChild;

            var rect = ActiveMdiChild.RectangleToScreen(ActiveMdiChild.Bounds);

            var bMap = CaptureBitmap(CreateGraphics(), rect);

            if (Clipboard.ContainsImage())
            {
                Clipboard.Clear();
            }
            Clipboard.SetImage(bMap);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rect"></param>
        /// <returns></returns>
        private Bitmap CaptureBitmap(Graphics g, Rectangle rect)
        {
            Bitmap image;

            using (var graphics = g)
            {
                image = new Bitmap(rect.Width, rect.Height, graphics);

                using (var memoryGrahics = Graphics.FromImage(image))
                {
                    memoryGrahics.CopyFromScreen(rect.X, rect.Y, 0, 0, rect.Size, CopyPixelOperation.SourceCopy);
                }
            }

            return image;
        }

        #endregion

        #region :: WaitDialog :: Wait Dialog를 보여주거나 숨깁니다.

        /// <summary>
        /// Wait Dialog를 보여줍니다.
        /// </summary>
        /// <param name="caption"></param>
        public void ShowWaitDialog(string caption)
        {
            ShowWaitDialog(caption, "Please wait ...");
        }

        /// <summary>
        /// Wait Dialog를 보여줍니다.
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="description"></param>
        public void ShowWaitDialog(string caption, string description)
        {
            taskbarAssistant.ProgressMode = TaskbarButtonProgressMode.Indeterminate;
            if (!waitFormManager.IsSplashFormVisible)
            {
                int x = RectangleToScreen(Bounds).Location.X;
                int y = RectangleToScreen(Bounds).Location.Y;
                x = (x + Width - 600) / 2;
                y = (y + Height - 400) / 2;

                Point point = new Point(x, y);
                waitFormManager.SplashFormStartPosition = DevExpress.XtraSplashScreen.SplashFormStartPosition.Manual;
                waitFormManager.SplashFormLocation = point;

                waitFormManager.ShowWaitForm();
            }

            waitFormManager.SetWaitFormCaption(caption);
            waitFormManager.SetWaitFormDescription(description);

            System.Threading.Thread.Sleep(10);
        }

        /// <summary>
        /// Wait Dialog를 닫습니다.
        /// </summary>
        public void CloseWaitDialog()
        {
            if (waitFormManager.IsSplashFormVisible)
                waitFormManager.CloseWaitForm();

            taskbarAssistant.ProgressMode = TaskbarButtonProgressMode.NoProgress;
        }

        #endregion

        #region :: GetCurrentTime :: 시스템의 현재 시간을 가져옵니다.

        /// <summary>
        /// 시스템의 현재 시간을 가져옵니다.
        /// </summary>
        /// <returns></returns>
        protected internal DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }

        /// <summary>
        /// 서버의 현재 시간을 가져옵니다.
        /// </summary>
        /// <returns></returns>
        protected internal DateTime GetServerTime()
        {
            using (SqlBiz sb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                return sb.GetServerTime();
            }
        }

        #endregion

        #region :: ShowAlertMessage :: Alert Message를 보여줍니다.

        /// <summary>
        /// 
        /// </summary>
        private bool pinBtnDown = false;

        /// <summary>
        /// Pin 버튼 강제 클릭을 지정합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void alertControl_FormLoad(object sender, DevExpress.XtraBars.Alerter.AlertFormLoadEventArgs e)
        {
            e.Buttons[1].SetDown(pinBtnDown);
        }

        /// <summary>
        /// Alert Form의 모양을 지정합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void alertControl_BeforeFormShow(object sender, DevExpress.XtraBars.Alerter.AlertFormEventArgs e)
        {
            if (e.AlertForm.AlertInfo.Tag == null)
                e.AlertForm.Width = 350;
            else
                e.AlertForm.Width = 450;
        }

        /// <summary>
        /// 복사 버튼을 클릭하면 Messgage 내용을 복사합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void alertControl_ButtonClick(object sender, DevExpress.XtraBars.Alerter.AlertButtonClickEventArgs e)
        {
            if (e.ButtonName != "btnCopy") return;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(e.Info.Caption);
            sb.AppendLine();
            sb.AppendLine(e.Info.Text);
            Clipboard.SetText(sb.ToString());
        }

        /// <summary>
        /// Alert Message를 보여줍니다.
        /// </summary>
        /// <param name="caption">Alert Control Caption</param>
        /// <param name="text">Alert Message</param>
        /// <param name="hotTrackedText">Hot Tracked Text</param>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        ///
        /// </remarks>
        public void ShowAlertMessage(string caption, string text, string hotTrackedText)
        {
            pinBtnDown = false;
            AlertControlShow(caption, "", text, null, Color.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="subject"></param>
        /// <param name="text"></param>
        /// <param name="idx"></param>
        /// <param name="backColor"></param>
        private void AlertControlShow(string title, string subject, string text, object idx, Color backColor)
        {
            string caption = title + (subject == "" ? "" : String.Format("-{0}", subject));
            string t = Environment.NewLine + text;

            alertControl.Show(this, caption, t, t, null, idx, backColor);
        }

        #endregion

        #region :: ShowFlyoutDialog :: Flyout Dialog를 보여줍니다.

        /// <summary>
        /// Flyout Dialog를 보여줍니다.
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="description"></param>
        protected internal void ShowFlyoutDialog(string caption, string description)
        {
            CloseWaitDialog();

            TaskBarAssist(TaskbarButtonProgressMode.Normal);
            FlyoutAction action = new FlyoutAction() { Caption = caption, Description = description };
            action.Commands.Add(FlyoutCommand.OK);

            FlyoutDialog.Show(this, action);
            taskbarAssistant.ProgressMode = TaskbarButtonProgressMode.NoProgress;
        }

        #endregion

        #region :: ShowMsgBox :: MessageBox를 보여줍니다.

        /// <summary>
        /// MessageBox를 보여줍니다.
        /// </summary>
        /// <param name="text">Message</param>
        /// <returns></returns>
        public DialogResult ShowMsgBox(string text)
        {
            return ShowMsgBox(text, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// MessageBox를 보여줍니다.
        /// </summary>
        /// <param name="text">Message</param>
        /// <param name="caption">Caption</param>
        /// <returns></returns>
        public DialogResult ShowMsgBox(string text, string caption)
        {
            return ShowMsgBox(text, caption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// MessageBox를 보여줍니다.
        /// </summary>
        /// <param name="text">보여질 Message</param>
        /// <param name="caption">MessageBox Caption</param>
        /// <param name="buttons">Button 종류</param>
        /// <returns></returns>
        public DialogResult ShowMsgBox(string text, string caption, MessageBoxButtons buttons)
        {
            return ShowMsgBox(text, caption, buttons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// MessageBox를 보여줍니다.
        /// </summary>
        /// <param name="text">보여질 Message</param>
        /// <param name="caption">MessageBox Caption</param>
        /// <param name="buttons">Button 종류</param>
        /// <param name="icon">Icon 종류</param>
        /// <returns></returns>
        public DialogResult ShowMsgBox(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return ShowMsgBox(text, caption, buttons, icon, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// MessageBox를 보여줍니다.
        /// </summary>
        /// <param name="text">보여질 Message</param>
        /// <param name="caption">MessageBox Caption</param>
        /// <param name="buttons">Button 종류</param>
        /// <param name="icon">Icon 종류</param>
        /// <param name="defaultButton">Default Button</param>
        /// <returns></returns>
        public DialogResult ShowMsgBox(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            CloseWaitDialog();
            TaskBarAssist(TaskbarButtonProgressMode.Indeterminate);

            DialogResult result = MsgBox.Show(this, text, caption, buttons, icon, defaultButton);

            taskbarAssistant.ProgressMode = TaskbarButtonProgressMode.NoProgress;

            return result;
        }

        #endregion

        #region :: ShowExceptionBox :: Exception Box를 보여줍니다.

        /// <summary>
        /// MessageBox를 보여줍니다.
        /// </summary>
        /// <param name="ex">Exception</param>
        public void ShowExceptionBox(Exception ex)
        {
            TaskBarAssist(TaskbarButtonProgressMode.Error);

            CloseWaitDialog();            
            ExceptionBox.Show(this, ex, CurrentUser == null ? false : CurrentUser.ISADMIN);

            taskbarAssistant.ProgressMode = TaskbarButtonProgressMode.NoProgress;
        }

        #endregion

        #region :: lbMessage_DoubleClick :: Message List를 더블클릭하면 해당 Message를 다시 보여줍니다.

        /// <summary>
        /// Message List를 더블클릭하면 해당 Message를 다시 보여줍니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbMessage_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataRowView dr = lbMessage.SelectedItem as DataRowView;

                if (dr == null) return;

                int idx = Convert.ToInt32(dr.Row["IDX"]);
                string title = dr.Row["TITLE"].ToString();
                string subject = dr.Row["SUBJECT"].ToString();
                string text = dr.Row["TEXT"].ToString();
                string date = dr.Row["DATE"].ToString();
                string color = dr.Row["COLOR"].ToString();

                AlertControlShow(title, subject, text, idx, Color.FromName(color));
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Private)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: TaskBarAssist :: Window Task Bar에 알람을 알립니다.

        /// <summary>
        /// Window Task Bar에 알람을 알립니다.
        /// </summary>
        private void TaskBarAssist(TaskbarButtonProgressMode mode)
        {
            string itemCaption = string.Format("Task #{0}", (taskbarAssistant.JumpListTasksCategory.Count + 1).ToString());
            JumpListItemTask taskItem = new JumpListItemTask(itemCaption);
            taskbarAssistant.ProgressMode = mode;
            taskbarAssistant.JumpListTasksCategory.Add(taskItem);
            taskbarAssistant.Refresh();
            Thread.Sleep(10);

            UpdateControls();
            taskbarAssistant.JumpListTasksCategory.Remove(taskItem);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="blinkTaskbarItem"></param>
        private void UpdateControls(bool blinkTaskbarItem = true)
        {
            if (!blinkTaskbarItem) return;
                
            NativeMethods.FlashWindowEx(Handle, NativeMethods.FLASHW.FLASHW_TRAY, 1, 250);
        }

        #endregion

        #region :: SaveMenuExecuteLog :: Database에 Menu 실행 Log를 저장합니다.

        /// <summary>
        /// Database에 Menu 실행 Log를 저장합니다.
        /// </summary>
        /// <param name="menuId">실행한 MENU ID</param>
        private void SaveMenuExecuteLog(string menuId)
        {
            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                const string queryId = @"dbo.MenuExecuteLog_Save";

                string[] paramList = new string[] { "@VENDORCODE",
                                                    "@PLANTCODE",
                                                    "@MENUID",
                                                    "@STARTDTTM",
                                                    "@SIGNINSEQ" };

                object[] valueList = new object[] { CurrentUser.VENDORCODE,
                                                    CurrentUser.PLANTCODE,
                                                    menuId,
                                                    GetCurrentTime(),
                                                    CurrentUser.SIGNINSEQ };

                wb.Tx_ExecuteNonQuery(ConnectionString.LOGDB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            }
        }

        #endregion

        #region :: RegistorFavorites :: 자주 쓰는 메뉴를 등록합니다.

        /// <summary>
        /// 자주 쓰는 메뉴를 등록합니다.
        /// </summary>
        private void RegistorFavorites()
        {
            var uiFrame = ActiveMdiChild as IFrameUI;

            if (uiFrame == null) return;

            if (ShowMsgBox(String.Format("[ {0} ] 를(을) 즐겨 찾기 메뉴로 등록하시겠습니까?", ActiveMdiChild.Text), "즐겨 찾기 메뉴 등록", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                != DialogResult.Yes) return;

            if (RegistorMyMenu(uiFrame.MENUID, "F") > 0)
                ShowMsgBox(String.Format("[ {0} ] 가(이) 즐겨 찾기 메뉴로 등록되었습니다. 등록한 메뉴는 다음 로그인 때 반영됩니다.", ActiveMdiChild.Text), "즐겨 찾기 메뉴 등록");
        }

        /// <summary>
        /// 사용자 메뉴를 등록합니다.
        /// </summary>
        /// <param name="menuId">프로그램 ID</param>
        /// <param name="gubun">구분(F : 즐겨찾기, S : 시작, T : 숏컷)</param>
        private int RegistorMyMenu(string menuId, string gubun)
        {
            int cnt = 0;
            const string queryId = @"dbo.MyMenu_Save";

            string[] paramList = new string[] { "@USERID",
                                                "@MENUID",
                                                "@IPADDRESS",
                                                "@GUBUN" };

            object[] valueList = new object[] { CurrentUser.USERID,
                                                menuId,
                                                CurrentUser.IP,
                                                gubun };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                cnt = wb.Tx_ExecuteNonQuery(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            }

            return cnt;
        }

        #endregion

        #region :: SetBarItemVisible :: ToolBar Item의 Visible을 설정합니다.

        /// <summary>
        /// ToolBar Item의 Visible을 설정합니다.
        /// </summary>
        /// <param name="visible"></param>
        protected void SetBarItemVisible(bool visible)
        {
            BarItemVisibility visibility = visible ? BarItemVisibility.Always : BarItemVisibility.Never;

            iRun.Visibility = visibility;
            siMenuInfo.Visibility = visibility;
            siMenuId.Visibility = visibility;
            siMenuName.Visibility = visibility;
            siDBTime.Visibility = visibility;
            iPlantCode.Visibility = visibility;
            iConnectionType.Visibility = visibility;
        }

        #endregion

        #region :: RegistorStartMenu :: 사용자별 시작 메뉴를 등록합니다.

        /// <summary>
        /// 사용자별 시작 메뉴를 등록합니다.
        /// </summary>
        private void RegistorStartMenu()
        {
            IFrameUI uiFrame = ActiveMdiChild as IFrameUI;

            if (uiFrame == null) return;

            if (ShowMsgBox(String.Format("[ {0} ] 를(을) 시작 메뉴로 등록 하시겠습니까?", ActiveMdiChild.Text), "시작 메뉴 등록", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                != DialogResult.Yes) return;

            if (RegistorMyMenu(uiFrame.MENUID, "S") > 0)
                ShowMsgBox(String.Format("[ {0} ] 가(이) 시작 메뉴로 등록 되었습니다. 등록한 메뉴는 다음 로그인에 반영됩니다.", ActiveMdiChild.Text), "시작 메뉴 등록");
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: OnLoad :: 처음 Loading 때 Skin을 설정합니다.

        /// <summary>
        /// 처음 Loading 때 Skin을 설정합니다.
        /// </summary>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        /// </remarks>
        protected override void OnLoad(EventArgs e)
        {
            RUNMODE = iRun.EditValue.ToString();

            string skinName = Win32Util.GetIniValue(AppConfig.SETTINGFILEPATH, "Skin", "SkinName");
            string paletteName = Win32Util.GetIniValue(AppConfig.SETTINGFILEPATH, "Skin", "PaletteName");
            string compactMode = Win32Util.GetIniValue(AppConfig.SETTINGFILEPATH, "Skin", "CompactMode");

            if (skinName == "")
            {
                UserLookAndFeel.ForceCompactUIMode(true, false);

                UserLookAndFeel.Default.SetSkinStyle("WXI");
            }
            else
            {
                if (compactMode == "True") UserLookAndFeel.ForceCompactUIMode(true, false);

                UserLookAndFeel.Default.SetSkinStyle(skinName, paletteName);
            }

            Text = String.Format("{0} {1}", AppConfig.SYSTEMNAME, DateTime.Now.ToString("yy"));

            if (!DesignMode)
            {
                CheckSystemFont();
                InitMessageControl();

                if (!Environment.OSVersion.VersionString.Contains("Microsoft Windows NT 5.1"))
                {
                    ShowWaitDialog("서버 시간 동기화 중...");
                    Win32Util.ChangeTime(GetServerTime());
                }
            }

            base.OnLoad(e);

            pnlTreeMenu.HideImmediately();
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitMessageControl()
        {
            lbMessage.Items.Clear();
            DataTable dt = new DataTable();
            dt.AddColumn(new string[] { "IDX", "TITLE", "SUBJECT", "TEXT", "DATE", "COLOR" });
            lbMessage.DataSource = dt;
            lbMessage.ValueMember = AppConfig.VALUEMEMBER;
            lbMessage.DisplayMember = AppConfig.DISPLAYMEMBER;
        }

        /// <summary>
        /// 
        /// </summary>
        private void CheckSystemFont()
        {
            //using (Font f = new Font("나눔고딕", 8.75F))
            //{
            //    if (f.Name == "나눔고딕") return;
            //}

            //StringBuilder sb = new StringBuilder();
            ////sb.AppendFormat("[ {0} ] 에서 사용할 폰트가 설치되지 않았습니다", AppConfig.SYSTEMNAME);
            //sb.AppendFormat("[ {0} ] 에서 사용할 폰트가 설치되지 않았습니다", "SEMCO.NET");
            //sb.AppendLine();
            //sb.Append("설치하시겠습니까?");

            //if (DialogResult.Yes == ShowMsgBox(sb.ToString(), "폰트 설치", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
            //{
            //    string fileName = Path.Combine(AppConfig.ASSEMBLYFOLDER, "NanumFontSetup.exe");

            //    ProcessStartInfo pInfo = new ProcessStartInfo() { FileName = fileName };
            //    Process process = Process.Start(pInfo);
            //    process.WaitForExit();
            //    process.Close();

            //    return;
            //}
        }

        #endregion

        #region :: OnLookAndFeelChangedCore :: Skin이 변경되면 메뉴바의 색상도 변경합니다.

        /// <summary>
        /// Skin이 변경되면 메뉴바의 색상도 변경합니다.
        /// </summary>
        protected override void OnLookAndFeelChangedCore()
        {
            base.OnLookAndFeelChangedCore();

            Color pColor = DXSkinColorHelper.GetDXSkinColor(DXSkinColors.FillColors.Primary, GetActiveLookAndFeel());

            barTop.BarAppearance.Hovered.BackColor = pColor;
            barTop.BarAppearance.Pressed.BackColor = pColor;
            
            barDockControlTop.Appearance.BackColor = pColor;

            barMiddle.BarAppearance.Normal.BackColor = pColor;
            barMiddle.BarAppearance.Hovered.BackColor = DXSkinColorHelper.GetDXSkinColor(DXSkinColors.FillColors.Warning, GetActiveLookAndFeel());
            barMiddle.BarAppearance.Pressed.BackColor = DXSkinColorHelper.GetDXSkinColor(DXSkinColors.FillColors.Success, GetActiveLookAndFeel());

            AppConfig.CONDITIONCOLOR = Color.FromArgb(30, DXSkinColorHelper.GetDXSkinColor(DXSkinColors.FillColors.Warning, GetActiveLookAndFeel()));
        }

        #endregion

        #region :: OnFormClosing :: Form이 종료될 때 사용자 설정 내용을 저장합니다.


        /// <summary>
        /// Form이 종료될 때 사용자 설정 내용을 저장합니다.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            Win32Util.SetIniValue(AppConfig.SETTINGFILEPATH, "Skin", "SkinName", UserLookAndFeel.Default.SkinName);
            Win32Util.SetIniValue(AppConfig.SETTINGFILEPATH, "Skin", "PaletteName", UserLookAndFeel.Default.ActiveSvgPaletteName);
            Win32Util.SetIniValue(AppConfig.SETTINGFILEPATH, "Skin", "CompactMode", UserLookAndFeel.Default.CompactUIModeForced.ToString());

            if (!LOGINFLAG) return;

            Win32Util.SetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "VENDORCODE", iVendorCode.EditValue.ToString());
            Win32Util.SetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "PLANTCODE", iPlantCode.EditValue.ToString());
            Win32Util.SetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "LANGUAGE", CURRENTLANGUAGE);
        }

        #endregion

        
    }
}