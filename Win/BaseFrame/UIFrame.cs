using DevExpress.LookAndFeel;
using DevExpress.Utils.Colors;
using DevExpress.Utils.Drawing.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraLayout;
using EBAP.Business.WSBiz;
using EBAP.Core.Collections;
using EBAP.Core.Info;
using EBAP.Core.Interface;
using EBAP.Core.Localization;
using EBAP.Win.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace EBAP.Win.BaseFrame
{
    /// <summary>
    /// 시스템에서 사용할 UI의 Super Class 입니다.
    /// </summary>
    /// <remarks>
    /// 2016-05-17 최초생성 : 오인봉
    /// 변경내역
    ///
    /// </remarks>
    public partial class UIFrame : DevExpress.XtraEditors.XtraForm, IDialog, IRaiseEvent, ILocaleConverter, IFrameUI, IGridColumnSet, IAuth
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// UI Frame을 생성합니다.
        /// </summary>
        public UIFrame()
        {
            InitializeComponent();
        }

        #endregion

        #region :: 전역변수 ::

        private ParamCollection _dbParams;
        private bool _isModified = false;

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: SELECT, LINK, LOAD 확인용 ::

        /// <summary>
        /// 조회 중
        /// </summary>
        [Browsable(false)]
        public bool ISSELECTING
        {
            get;
            private set;
        }

        /// <summary>
        /// 조회 중
        /// </summary>
        [Browsable(false)]
        public bool ISLINKING
        {
            get;
            private set;
        }

        /// <summary>
        /// LOAD 중
        /// </summary>
        [Browsable(false)]
        public bool ISLOADING
        {
            get;
            set;
        }

        #endregion

        #region :: FRAME :: System MainFrame 입니다.

        /// <summary>
        /// System MainFrame 입니다.
        /// </summary>
        [Browsable(false)]
        protected internal MainFrame FRAME
        {
            get
            {
                return MdiParent != null ? (MdiParent as MainFrame) : (Owner as MainFrame);
            }
        }

        #endregion

        #region :: CurrentUser :: 현재 사용자의 정보를 설정합니다.

        /// <summary>
        /// 현재 사용자의 정보를 설정합니다.
        /// </summary>
        [Browsable(false)]
        public UserInfo CurrentUser
        {
            get { return FRAME == null ? null : FRAME.CurrentUser; }
        }

        /// <summary>
        /// Ribbon의 Vendor을 설정합니다.
        /// </summary>
        /// <param name="vendorCode">업체코드</param>
        protected void SetVendor(string vendorCode)
        {
            FRAME.SetVendor(vendorCode);
        }

        #endregion

        #region :: SetPlant :: Ribbon의 Plant를 설정합니다.

        /// <summary>
        /// Ribbon의 Plant를 설정합니다.
        /// </summary>
        /// <param name="plantCode">사업장코드</param>
        protected void SetPlant(string plantCode)
        {
            FRAME.SetPlant(plantCode);
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
                return _isModified;
            }
            set
            {
                _isModified = value;
                FRAME.ISMODIFIED = value;
            }
        }

        #endregion

        #region :: IsLoadSelectEvent :: LOAD 시 Select Event 발생 여부를 설정합니다.

        /// <summary>
        /// LOAD 시 Select Event 발생 여부를 설정합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(false), Browsable(true)]
        [Description("LOAD 시 Select Event 발생 여부를 설정합니다.")]
        public bool IsLoadSelectEvent
        {
            get;
            set;
        }

        #endregion

        #region :: 다국어 :: 다국어 지원에 사용할 Localizer와 언어를 설정합니다.

        /// <summary>
        /// 다국어 지원에 사용할 Localizer
        /// </summary>
        [Browsable(false)]
        public LocaleConverter LOCALECONVERTER
        {
            get
            {
                return FRAME.LOCALECONVERTER;
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
                return FRAME.CURRENTLANGUAGE;
            }
        }

        #endregion

        #region :: 권한 설정 ::

        /// <summary>
        /// 조회권한을 설정합니다.
        /// </summary>
        [Browsable(false)]
        public bool SelectAuth
        {
            get;
            set;
        }

        /// <summary>
        /// 신규권한을 설정합니다.
        /// </summary>
        [Browsable(false)]
        public bool NewAuth
        {
            get;
            set;
        }

        /// <summary>
        /// 저장권한을 설정합니다.
        /// </summary>
        [Browsable(false)]
        public bool SaveAuth
        {
            get;
            set;
        }

        /// <summary>
        /// 삭제권한을 설정합니다.
        /// </summary>
        [Browsable(false)]
        public bool DelAuth
        {
            get;
            set;
        }

        /// <summary>
        /// 삭제권한을 설정합니다.
        /// </summary>
        [Browsable(false)]
        public bool CopyAuth
        {
            get;
            set;
        }

        #endregion

        #region :: 메뉴 관련 ::

        /// <summary>
        /// UI의 Menu ID 입니다.
        /// </summary>
        [Browsable(false)]
        public string MENUID
        {
            get;
            set;
        }

        /// <summary>
        /// 최상위 메뉴 ID 입니다.
        /// </summary>
        [Browsable(false)]
        public string TOPMENUID
        {
            get;
            set;
        }

        /// <summary>
        /// 중간 메뉴 ID 입니다.
        /// </summary>
        [Browsable(false)]
        public string MIDDLEMENUID
        {
            get;
            set;
        }

        /// <summary>
        /// UI의 Screen ID 입니다.
        /// </summary>
        [Browsable(false)]
        public string SCREENID
        {
            get;
            set;
        }

        /// <summary>
        /// UI의 Class Name 입니다.
        /// </summary>
        [Browsable(false)]
        public string CLASSNAME
        {
            get;
            set;
        }

        /// <summary>
        /// 도움말 파일의 경로입니다.
        /// </summary>
        [Browsable(false)]
        public string HELPPATH
        {
            get;
            set;
        }

        #endregion

        #region :: AddCommomParam :: 공통 Parameter 포함 여부를 설정합니다.

        /// <summary>
        /// 공통 Parameter 포함 여부를 설정합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(true), Browsable(true)]
        [Description("공통 Parameter 포함 여부를 설정합니다.")]
        public bool AddCommomParam
        {
            get;
            set;
        }

        #endregion

        #region :: 사업장 및 공장 정보 ::

        /// <summary>
        /// UI의 VENDOR ID 입니다.
        /// </summary>
        [Browsable(false)]
        public string VENDORCODE
        {
            get;
            set;
        }

        /// <summary>
        /// UI의 PLANT ID 입니다.
        /// </summary>
        [Browsable(false)]
        public string PLANTCODE
        {
            get;
            set;
        }

        #endregion

        #region :: LinkParams :: Form 간 통신 시에 사용할 Parameter

        /// <summary>
        /// Form 간 통신 시에 사용할 Parameter
        /// </summary>
        [Browsable(false)]
        public ParamCollection LinkParams
        {
            get;
            set;
        }

        #endregion

        #region :: ControlParams :: Database 에 사용할 Parameter

        /// <summary>
        /// Database 에 사용할 Parameter
        /// </summary>
        [Browsable(false)]
        protected ParamCollection DatabaseParams
        {
            get
            {
                return GetDatabaseParams();
            }
        }

        #endregion

        /// <summary>
        /// 저장 이상 여부 체크
        /// </summary>
        [Browsable(false)]
        public bool OKSAVE
        {
            get;
            set;
        }

        /// <summary>
        /// 삭제 이상 여부 체크
        /// </summary>
        [Browsable(false)]
        public bool OKDELETE
        {
            get;
            set;
        }

        /// <summary>
        /// 저장 이상 여부 체크
        /// </summary>
        [Browsable(false)]
        public bool OKCOPY
        {
            get;
            set;
        }

        /// <summary>
        /// 저장/삭제 처리 후 보여줄 메시지
        /// </summary>
        [Browsable(false)]
        public string OKMESSAGE
        {
            get;
            set;
        }

        /// <summary>
        /// 저장/삭제 처리 확인 메시지 창 표시 여부
        /// </summary>
        [Browsable(false)]
        public bool ISSHOWFLYOUT
        {
            get;
            set;
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler(Delegate)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 이벤트 Handler 설정 :: 조회, 저장, 삭제 등

        /// <summary>
        /// 사용자 권한 설정 시에 사용합니다.
        /// </summary>
        [Category("EBAP"),
        Browsable(true)]
        [Description("사용자 권한 설정 시에 사용합니다.")]
        public event EventHandler Authentication;

        /// <summary>
        /// Chart 출력 이벤트 발생 시에 사용합니다.
        /// </summary>
        [Category("EBAP"),
        Browsable(true)]
        [Description("Chart 이벤트 발생 시에 사용합니다.")]
        public event EventHandler Chart;

        /// <summary>
        /// 삭제 이벤트 발생 시에 사용합니다.
        /// </summary>
        [Category("EBAP"),
        Browsable(true)]
        [Description("삭제 이벤트 발생 시에 사용합니다.")]
        public event EventHandler Delete;

        /// <summary>
        /// Form간 통신시에 사용합니다.
        /// </summary>
        [Category("EBAP"),
        Browsable(true)]
        [Description("Form간 통신 시에 사용합니다.")]
        public event EventHandler Link;

        /// <summary>
        /// 신규(추가) 이벤트 발생 시에 사용합니다.
        /// </summary>
        [Category("EBAP"),
        Browsable(true)]
        [Description("추가 이벤트 발생 시에 사용합니다.")]
        public event EventHandler New;

        /// <summary>
        /// 저장 이벤트 발생 시에 사용합니다.
        /// </summary>
        [Category("EBAP"),
        Browsable(true)]
        [Description("저장 이벤트 발생 시에 사용합니다.")]
        public event EventHandler Save;

        /// <summary>
        /// 복사 이벤트 발생 시에 사용합니다.
        /// </summary>
        [Category("EBAP"),
        Browsable(true)]
        [Description("복사 이벤트 발생 시에 사용합니다.")]
        public event EventHandler Copy;

        /// <summary>
        /// 조회 이벤트 발생 시에 사용합니다.
        /// </summary>
        [Category("EBAP"),
        Browsable(true)]
        [Description("조회 이벤트 발생 시에 사용합니다.")]
        public event EventHandler Selection;

        /// <summary>
        /// Reload 이벤트 발생 시에 사용합니다.
        /// </summary>
        [Category("EBAP"),
        Browsable(true)]
        [Description("Reload 이벤트 발생 시에 사용합니다.")]
        public event EventHandler Reload;

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Private)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: ExportTo :: Grid Data를 Export 합니다.

        /// <summary>
        /// Grid Data를 Export 합니다.
        /// </summary>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        ///
        /// </remarks>
        private void RaiseCancelEdit()
        {
            List<Control> lists = new List<Control>();

            AppUtil.FindFocusedControl<ICancelEditRow>(lists, this);

            if (lists.Count == 0)
            {
                return;
            }

            ICancelEditRow ctrl = lists[0] as ICancelEditRow;

            ctrl.CancelEditRow();
        }

        #endregion

        #region :: GetDatabaseParams :: UI Form의 Database Parameter로 사용할 Control을 찾아서 반환 합니다.

        /// <summary>
        /// UI Form의 Database Parameter로 사용할 Control을 찾아서 반환 합니다.
        /// </summary>
        /// <returns></returns>
        private ParamCollection GetDatabaseParams()
        {
            _dbParams = new ParamCollection();

            _dbParams.Clear();

            GetDatabaseParams(this);

            if (AddCommomParam)
            {
                _dbParams.Add("@VENDORCODE", VENDORCODE);
                _dbParams.Add("@PLANTCODE", PLANTCODE);
            }

            return _dbParams;
        }

        /// <summary>
        /// UI Form의 Database Parameter로 사용할 Control을 찾아서 반환 합니다.
        /// </summary>
        /// <param name="control"></param>
        private void GetDatabaseParams(Control control)
        {
            if (control.HasChildren)
            {
                foreach (Control ctrl in control.Controls)
                {
                    if (ctrl is IDBParams && (ctrl as IDBParams).ParamName != null && (ctrl as IDBParams).ParamName != string.Empty)
                    {
                        _dbParams.Add((ctrl as IDBParams).ParamName, (ctrl as IDBParams).GetControlParamValue());
                    }
                    GetDatabaseParams(ctrl);
                }
            }
            else
            {
                return;
            }
        }

        #endregion

        #region :: ExportTo :: Grid Data를 Export 합니다.

        /// <summary>
        /// Grid Data를 Export 합니다.
        /// </summary>
        /// <param name="eType"></param>
        /// <param name="control"></param>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        ///
        /// </remarks>
        private void ExportTo(ExportType eType, Control control)
        {
            List<Control> lists = new List<Control>();

            AppUtil.FindFocusedControl<IExport>(lists, control);

            if (lists.Count == 0)
            {
                //ShowInfoMessage("오류", "Grid 선택", "Export 작업을 처리할 Grid를 찾지 못했습니다.");
                ShowAlertMessage("[ 내보내기 ] 작업을 처리할 컨트롤을 찾지 못했습니다. 컨트롤을 선택하세요.", "내보내기 오류");

                return;
            }

            IExport ctrl = lists[0] as IExport;

            if (ctrl == null || (ctrl.DisableExport && !CurrentUser.ISADMIN))
            {
                ShowAlertMessage("[ 내보내기 ] 불가능한 데이터 입니다. 관리자에게 문의하세요.", "내보내기 불가");
                return;
            }

            string folderPath = Path.Combine(AppConfig.ASSEMBLYFOLDER, "ExportFiles");

            AppUtil.CreateFolder(folderPath);

            string fileName = String.Format("{0}({1:yyyy-MM-dd_HHmmss})", control.Text.Replace(" / ", string.Empty), DateTime.Now);

            fileName = Path.Combine(folderPath, fileName);

            switch (eType)
            {
                case ExportType.Excel:
                    fileName += ".xlsx";
                    ctrl.ExportXlsx(fileName);
                    break;
                case ExportType.Pdf:
                    fileName += ".pdf";
                    ctrl.ExportPdf(fileName);
                    break;
                default:
                    break;
            }

            AppUtil.OpenFile(fileName, false);
        }

        #endregion

        #region :: PreviewData :: Grid Data를 Export 합니다.

        /// <summary>
        /// Grid Data를 Export 합니다.
        /// </summary>
        /// <param name="control"></param>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        ///
        /// </remarks>
        private void PreviewData(Control control)
        {
            List<Control> gridList = new List<Control>();

            AppUtil.FindFocusedControl<IPrint>(gridList, control);

            if (gridList.Count == 0)
            {
                //ShowInfoMessage("오류", "Grid 선택", "Export 작업을 처리할 Grid를 찾지 못했습니다.");
                ShowAlertMessage("[ 미리보기 ] 작업을 처리할 컨트롤을 찾지 못했습니다. 컨트롤을 선택하세요.", "미리보기 오류");

                return;
            }

            IPrint previewControl = gridList[0] as IPrint;

            if (previewControl == null) return;

            previewControl.PrintPreview();
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Internal)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: Raise Event :: 강제 이벤트 발생

        /// <summary>
        /// 
        /// </summary>
        internal void RaiseLoadEvent()
        {
            OnLoad(new EventArgs());
        }

        /// <summary>
        /// Authentication Event를 강제로 발생시킵니다.
        /// </summary>
        internal void RaiseAuthEvent()
        {
            if (Authentication == null) return;

            try
            {
                Authentication(this, new EventArgs());
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Link Event를 강제로 발생시킵니다.
        /// </summary>
        internal void RaiseLinkEvent()
        {
            if (Link == null || LinkParams == null) return;

            try
            {
                ISLINKING = true;

                DateTime startDttm = GetCurrentTime();

                Link(this, new EventArgs());

                SaveOperationLog("LINK", startDttm);

                ISLINKING = false;

                RaiseSelectEvent();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Link Event를 강제로 발생시킵니다.
        /// </summary>
        internal void RaiseReloadEvent()
        {
            if (Reload == null) return;

            ISLOADING = true;

            ShowWaitDialog(String.Format("현재 화면 [ {0} ] 을 초기화 합니다.", Text));

            Reload(this, new EventArgs());

            ISLOADING = false;
            ISMODIFIED = false;
            CloseWaitDialog();
        }

        bool selectCheck = true;
        /// <summary>
        /// 조회 Event를 강제로 발생시킵니다.
        /// </summary>
        public void RaiseSelectEvent()
        {
            selectCheck = true;
            OKMESSAGE = "";

            if (!SelectAuth || Selection == null || ISSELECTING || ISLOADING || ISLINKING || !CheckMandatoryForSelect() || !CheckSelectionCondition()) return;

            if (ISMODIFIED)
            {
                if (ShowMsgBox(LOCALECONVERTER.GetLocaleMessage("CF_S_CONTINUE"), Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    != System.Windows.Forms.DialogResult.Yes) return;
            }
            ISSELECTING = true;

            try
            {
                string message = LOCALECONVERTER.GetLocaleMessage("DO_Inquired");

                ShowWaitDialog(message);

                DateTime startDttm = GetCurrentTime();

                Selection(this, new EventArgs());

                DateTime endDttm = GetCurrentTime();

                SaveOperationLog("SELECT", startDttm, endDttm);

                message = LOCALECONVERTER.GetLocaleMessage("OK_SELECT");

                FRAME.SetSiDBTime(String.Format("{0:N0} ㎳", (endDttm - startDttm).TotalSeconds * 1000));
                FRAME.SetSiMessage(message);
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
            finally
            {
                ISMODIFIED = false;
                ISSELECTING = false;
                CloseWaitDialog();
            }
        }

        /// <summary>
        /// 차트 Event를 강제로 발생시킵니다.
        /// </summary>
        public void RaiseChartEvent()
        {
            //if (SelectAuth && Selection != null && CheckSelectionCondition())
            if (Chart == null || !CheckChartCondition()) return;

            try
            {
                ShowWaitDialog(LOCALECONVERTER.GetLocaleMessage("DO_Inquired"));

                DateTime startDttm = GetCurrentTime();

                Selection(this, new EventArgs());

                DateTime endDttm = GetCurrentTime();

                SaveOperationLog("CHART", startDttm, endDttm);

                FRAME.SetSiDBTime(String.Format("{0:N0} ㎳", (endDttm - startDttm).TotalSeconds * 1000));
                FRAME.SetSiMessage(LOCALECONVERTER.GetLocaleMessage("OK_PROCESS"));
            }
            catch
            {
                throw;
            }
            finally
            {
                ISMODIFIED = false;
                CloseWaitDialog();
            }
        }

        /// <summary>
        /// 신규 Event를 강제로 발생시킵니다.
        /// </summary>
        public void RaiseNewEvent()
        {
            if (!NewAuth || New == null || !CheckNewCondition()) return;

            if (ISMODIFIED)
            {
                if (ShowMsgBox(LOCALECONVERTER.GetLocaleMessage("CF_S_CONTINUE"), Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    != System.Windows.Forms.DialogResult.Yes) return;
            }

            try
            {
                DateTime startDttm = GetCurrentTime();

                New(this, new EventArgs());

                ISMODIFIED = false;

                SaveOperationLog("NEW", startDttm);
            }
            catch
            {
                throw;
            }
        }

        bool saveCheck = true;

        /// <summary>
        /// Save Event를 강제로 발생시킵니다.
        /// </summary>
        public void RaiseSaveEvent()
         {
            saveCheck = true;
            OKSAVE = true;
            ISSHOWFLYOUT = true;
            OKMESSAGE = "";

            if (!SaveAuth || Save == null || !CheckControlValidate(this) || !CheckMandatoryForSave() || !CheckSaveCondition()) return;

            try
            {
                string message = LOCALECONVERTER.GetLocaleMessage("DO_Save");
                ShowWaitDialog(message);

                DateTime startDttm = GetCurrentTime();

                Save(this, new EventArgs());

                if (!OKSAVE) return;

                DateTime endDttm = GetCurrentTime();

                SaveOperationLog("SAVE", startDttm, endDttm);

                ISMODIFIED = false;

                message = OKMESSAGE != "" ? OKMESSAGE : LOCALECONVERTER.GetLocaleMessage("OK_SAVE");

                FRAME.SetSiDBTime(String.Format("{0:N0} ㎳", (endDttm - startDttm).TotalSeconds * 1000));
                FRAME.SetSiMessage(message);

                if (!ISSHOWFLYOUT)
                {
                    ShowAlertMessage(message, LOCALECONVERTER.GetLocaleString("Save"));
                    return;
                }
                    
                ShowFlyoutDialog(LOCALECONVERTER.GetLocaleString("Save"), message);
            }
            catch
            {
                OKSAVE = false;
                throw;
            }
            finally
            {
                CloseWaitDialog();
            }
        }

        /// <summary>
        /// 삭제 Event를 강제로 발생시킵니다.
        /// </summary>
        public void RaiseDeleteEvent()
        {
            OKDELETE = true;
            OKMESSAGE = "";
            ISSHOWFLYOUT = true;

            if (!DelAuth || Delete == null || !CheckDeleteCondition()) return;

            try
            {
                string message = LOCALECONVERTER.GetLocaleMessage("DO_Delete");

                ShowWaitDialog(message);

                DateTime startDttm = GetCurrentTime();

                Delete(this, new EventArgs());

                if (!OKDELETE) return;

                DateTime endDttm = GetCurrentTime();

                SaveOperationLog("DELETE", startDttm, endDttm);

                message = OKMESSAGE != "" ? OKMESSAGE : LOCALECONVERTER.GetLocaleMessage("OK_DELETE");

                FRAME.SetSiDBTime(String.Format("{0:N0} ㎳", (endDttm - startDttm).TotalSeconds * 1000));
                FRAME.SetSiMessage(message);

                if (!ISSHOWFLYOUT)
                {
                    ShowAlertMessage(message, LOCALECONVERTER.GetLocaleString("Delete"));
                    return;
                }

                ShowFlyoutDialog(LOCALECONVERTER.GetLocaleString("Delete"), message);
            }
            catch
            {
                OKDELETE = false;
                throw;
            }
            finally
            {
                CloseWaitDialog();
            }
        }

        bool copyCheck = true;

        /// <summary>
        /// Copy Event를 강제로 발생시킵니다.
        /// </summary>
        public void RaiseCopyEvent()
        {
            copyCheck = true;
            OKCOPY = true;
            ISSHOWFLYOUT = true;
            OKMESSAGE = "";

            if (!CopyAuth || Copy == null || !CheckControlValidate(this) || !CheckMandatoryForSave() || !CheckCopyCondition()) return;

            try
            {
                string message = LOCALECONVERTER.GetLocaleMessage("DO_Copy");
                ShowWaitDialog(message);

                DateTime startDttm = GetCurrentTime();

                Copy(this, new EventArgs());

                if (!OKCOPY) return;

                DateTime endDttm = GetCurrentTime();

                SaveOperationLog("COPY", startDttm, endDttm);

                ISMODIFIED = false;

                message = OKMESSAGE != "" ? OKMESSAGE : LOCALECONVERTER.GetLocaleMessage("OK_COPY");

                FRAME.SetSiDBTime(String.Format("{0:N0} ㎳", (endDttm - startDttm).TotalSeconds * 1000));
                FRAME.SetSiMessage(message);

                if (!ISSHOWFLYOUT)
                {
                    ShowAlertMessage(message, LOCALECONVERTER.GetLocaleString("Copy"));
                    return;
                }

                ShowFlyoutDialog(LOCALECONVERTER.GetLocaleString("Copy"), message);
            }
            catch
            {
                OKCOPY = false;
                throw;
            }
            finally
            {
                CloseWaitDialog();
            }
        }

        #endregion

        #region :: SetRibbonBarButtonEnabled :: 이벤트와 권한에 따라 Ribbon Button Enabled 설정하기

        /// <summary>
        /// 이벤트와 권한에 따라 Ribbon Button Enabled 설정하기
        /// </summary>
        protected internal void SetRibbonBarButtonEnabled()
        {
            bool selectEnable = (Selection != null && SelectAuth);
            bool newEnable = (New != null && NewAuth);
            bool saveEnable = (Save != null && SaveAuth);
            bool deleteEnable = (Delete != null && DelAuth);
            bool copyEnable = (Copy != null && CopyAuth);
            bool reloadEnable = (Reload != null);
            //bool chartEnable = (Chart != null);
            bool helpEnable = HELPPATH != "";

            //FRAME.Ribbon.Items["iSelect"].Enabled = selectEnable;
            //FRAME.Ribbon.Items["iNew"].Enabled = newEnable;
            //FRAME.Ribbon.Items["iSave"].Enabled = saveEnable;
            //FRAME.Ribbon.Items["iDelete"].Enabled = deleteEnable;
            //FRAME.Ribbon.Items["iChart"].Enabled = chartEnable;
            //FRAME.Ribbon.Items["iReload"].Enabled = (Reload != null);

            //FRAME.Ribbon.Items["iPrint"].Enabled = true;
            //FRAME.Ribbon.Items["iCapture"].Enabled = true;
            //FRAME.Ribbon.Items["iExport"].Enabled = true;

            iSelect.Enabled = selectEnable;
            iNew.Enabled = newEnable;
            iCancelEdit.Enabled = (saveEnable || newEnable);
            iSave.Enabled = saveEnable;
            iDelete.Enabled = deleteEnable;
            iCopy.Enabled = copyEnable;
            iHelp.Enabled = helpEnable;
            iReload.Enabled = reloadEnable;
        }

        #endregion

        #region :: SetToolBarVisible :: Docking/Floating 여부에 따라 툴바의 Visible을 설정합니다.

        /// <summary>
        /// Docking/Floating 여부에 따라 툴바의 Visible을 설정합니다.
        /// </summary>
        /// <param name="visible"></param>
        internal void SetToolBarVisible(bool visible)
        {
            toolbar.Visible = visible;
        }

        #endregion

        #region :: OnRibbonItemClick :: UI Form의 툴바를 클릭하면 발생합니다.

        /// <summary>
        /// UI Form의 툴바를 클릭하면 발생합니다.
        /// </summary>
        /// <param name="itemName"></param>
        internal void OnRibbonItemClick(string itemName)
        {
            try
            {
                FRAME.SetSiDBTime(string.Empty);

                switch (itemName)
                {
                    case "iSelect":
                        RaiseSelectEvent();
                        break;
                    case "iNew":
                        RaiseNewEvent();
                        break;
                    case "iCancelEdit":
                        RaiseCancelEdit();
                        break;
                    case "iSave":
                        RaiseSaveEvent();
                        break;
                    case "iDelete":
                        RaiseDeleteEvent();
                        break;
                    case "iCopy":
                        RaiseCopyEvent();
                        break;
                    case "iChart":
                        RaiseChartEvent();
                        break;
                    case "iReload":
                        RaiseReloadEvent();
                        break;
                    case "iCapture":
                        FRAME.CaptureImage();
                        //ShowInfoMessage("캡쳐", "완료", $"{Text} 화면이 캡쳐되었습니다. 편집기에 붙여 넣으세요." );
                        ShowAlertMessage($"[ {Text} ] 화면이 캡쳐되었습니다. 편집기에 붙여 넣으세요.", "캡쳐 완료");
                        break;
                    case "iExcel":
                        ExportTo(ExportType.Excel, this);
                        SaveOperationLog("EXPORT", GetCurrentTime());
                        break;
                    case "iPrint":
                        PreviewData(this);
                        SaveOperationLog("PRINT", GetCurrentTime());
                        break;
                    case "iHelp":
                        ExecuteHelp();
                        break;
                    case "iClose":
                        Close();
                        break;
                    case "iCopyMenuPath":
                        Clipboard.SetText(siMenuPath.Caption);
                        break;
                }
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
        /// <param name="menuPath"></param>
        internal void SetMenuPath(string menuPath)
        {
            siMenuPath.Caption = menuPath;
        }

        #endregion

        #region :: ExecuteHelp :: 도움말 문서를 실행합니다.

        /// <summary>
        /// 도움말 문서를 실행합니다.
        /// </summary>
        private void ExecuteHelp()
        {
            if (HELPPATH == "") return;

            ProcessStartInfo pInfo = new ProcessStartInfo() { FileName = "IExplore.exe", CreateNoWindow = true, WindowStyle = ProcessWindowStyle.Hidden, Arguments = HELPPATH };
            Process process = Process.Start(pInfo);
            process.Close();
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Protected)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: CheckMandatoryControl :: UI Form의 필수 입력항목을 검사하여 검사결과를 반환 합니다.

        /// <summary>
        /// UI Form의 Control을 초기화 합니다.
        /// </summary>
        /// <param name="control">컨트롤</param>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        ///
        /// </remarks>
        protected bool CheckControlValidate(Control control)
        {
            if (control.HasChildren)
            {
                foreach (Control ctrl in control.Controls)
                {
                    if(ctrl is GridControl)
                    {
                        ((ctrl as GridControl).DefaultView as IMandatoryColumns).CheckMandatoryColumns();
                    
                        saveCheck = !((ctrl as GridControl).DefaultView as DevExpress.XtraGrid.Views.Base.ColumnView).HasColumnErrors;

                        if (!saveCheck)
                        {
                            string msg = "[ 필수 입력 항목 ] 이 입력되지 않았어요. 확인하세요. 입력 내용을 취소하려면 [ 조회 - F5 ]를 눌러주세요.";
                            //ShowInfoMessage("데이터 입력", "필수 입력 항목", msg);
                            ShowAlertMessage(msg, "필수 입력 항목 확인");

                            return false;
                        }
                   
                        break;
                    }

                    CheckControlValidate(ctrl);
                }
            }

            return saveCheck;
        }

        /// <summary>
        ///  UI Form의 필수 입력항목을 검사하여 검사결과를 반환 합니다.
        /// </summary>
        /// <returns></returns>
        protected bool CheckMandatoryForSave()
        {
            saveCheck = true;
            return CheckMandatoryForSave(this);
        }

        /// <summary>
        ///  UI Form의 필수 입력항목을 검사하여 검사결과를 반환 합니다.
        /// </summary>
        /// <param name="control"></param>
        protected bool CheckMandatoryForSave(Control control)
        {
            if (control.HasChildren)
            {
                foreach (Control ctrl in control.Controls)
                {
                    if (ctrl.GetType().ToString() == "DevExpress.XtraLayout.LayoutControl")
                    {
                        foreach (DevExpress.XtraLayout.BaseLayoutItem bi in (ctrl as DevExpress.XtraLayout.LayoutControl).Items)
                        {
                            DevExpress.XtraLayout.LayoutControlItem lcItem = bi as DevExpress.XtraLayout.LayoutControlItem;

                            if (lcItem == null) continue;

                            IDBParams param = lcItem.Control as IDBParams;

                            if (param == null) continue;

                            IMandatory mandatory = lcItem.Control as IMandatory;

                            if (mandatory == null) continue;

                            if (!mandatory.IsMandatoryForSave) continue;

                            if ((lcItem.Control as IDBParams).GetControlParamValue().ToString().Trim() == "")
                            {
                                string itemType = lcItem.Control.GetType().ToString();
                                string caption = "";
                                switch (itemType)
                                {
                                    case "EBAP.Win.ControlLibrary.PButton":
                                    case "EBAP.Win.ControlLibrary.PCheckEdit":
                                        caption = lcItem.Control.Text;
                                        break;
                                    default:
                                        caption = bi.Text;
                                        break;
                                }
                                ShowMsgBox(String.Format(LOCALECONVERTER.GetLocaleMessage("IF_EssentialItem"), caption));
                                lcItem.Control.Focus();
                                saveCheck = false;
                                return false;
                            }
                        }
                    }

                    CheckMandatoryForSave(ctrl);
                }
            }
            return saveCheck;
        }

        /// <summary>
        ///  UI Form의 필수 입력항목을 검사하여 검사결과를 반환 합니다.
        /// </summary>
        /// <returns></returns>
        protected bool CheckMandatoryForSelect()
        {
            return CheckMandatoryForSelect(this);
        }

        /// <summary>
        ///  UI Form의 필수 입력항목을 검사하여 검사결과를 반환 합니다.
        /// </summary>
        /// <param name="control"></param>
        protected bool CheckMandatoryForSelect(Control control)
        {
            if (control.HasChildren)
            {
                foreach (Control ctrl in control.Controls)
                {
                    if (ctrl.GetType().ToString() == "DevExpress.XtraLayout.LayoutControl")
                    {
                        foreach (DevExpress.XtraLayout.BaseLayoutItem bi in (ctrl as DevExpress.XtraLayout.LayoutControl).Items)
                        {
                            DevExpress.XtraLayout.LayoutControlItem lcItem = bi as DevExpress.XtraLayout.LayoutControlItem;

                            if (lcItem == null) continue;

                            IDBParams param = lcItem.Control as IDBParams;

                            if (param == null) continue;

                            IMandatory mandatory = lcItem.Control as IMandatory;

                            if (mandatory == null) continue;

                            if (!mandatory.IsMandatoryForSelect) continue;

                            object value = (lcItem.Control as IDBParams).GetControlParamValue();

                            if (value == null) continue;

                            if (value.ToString() == "")
                            {
                                string itemType = lcItem.Control.GetType().ToString();
                                string caption = "";
                                switch (itemType)
                                {
                                    case "EBAP.Win.ControlLibrary.PButton":
                                    case "EBAP.Win.ControlLibrary.PCheckEdit":
                                        caption = lcItem.Control.Text;
                                        break;
                                    default:
                                        caption = bi.Text;
                                        break;
                                }
                                ShowMsgBox(String.Format(LOCALECONVERTER.GetLocaleMessage("IF_EssentialInquiry"), caption));
                                lcItem.Control.Focus();
                                selectCheck = false;
                                return false;
                            }
                        }
                    }

                    CheckMandatoryForSelect(ctrl);
                }
            }
            return selectCheck;
        }

        #endregion

        #region :: GetCurrentTime :: 시스템의 현재 시간을 가져옵니다.

        /// <summary>
        /// 시스템의 현재 시간을 가져옵니다.
        /// </summary>
        /// <returns></returns>
        public DateTime GetCurrentTime()
        {
            return FRAME.GetCurrentTime();
        }

        /// <summary>
        /// 서버의 현재 시간을 가져옵니다.
        /// </summary>
        /// <returns></returns>
        public DateTime GetServerTime()
        {
            return FRAME.GetServerTime();
        }

        #endregion

        #region :: ExecuteUI :: UI를 실행합니다.

        /// <summary>
        /// UI를 실행합니다.
        /// </summary>
        /// <param name="menuID">MENU ID</param>
        /// <param name="linkParams">Link Event Parameters</param>
        protected void ExecuteUI(object menuID, ParamCollection linkParams)
        {
            FRAME.ExecuteUI(menuID, linkParams);
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
            return FRAME.ExecutePopup(text, dllPath, className, popParams);
        }

        #endregion

        #region :: SaveOperationLog :: Database에 실행 Log를 저장합니다.

        /// <summary>
        /// Database에 실행 Log를 저장합니다.
        /// </summary>
        /// <param name="opertion"></param>
        /// <param name="dtStart"></param>
        public void SaveOperationLog(string opertion, DateTime dtStart)
        {
            SaveOperationLog(opertion, dtStart, GetCurrentTime());
        }

        /// <summary>
        /// Database에 실행 Log를 저장합니다.
        /// </summary>
        /// <param name="opertion"></param>
        /// <param name="dtStart"></param>
        /// <param name="dtEnd"></param>
        public void SaveOperationLog(string opertion, DateTime dtStart, DateTime dtEnd)
        {
            const string queryId = @"dbo.OperationLog_Save";

            string[] paramList = new string[] { "@MENUID",
                                                "@POPNAME",
                                                "@OPERATION",
                                                "@SIGNINSEQ",
                                                "@STARTDTTM",
                                                "@ENDDTTM" };
            object[] valueList = new object[] { MENUID,
                                                "",
                                                opertion,
                                                CurrentUser.SIGNINSEQ,
                                                dtStart,
                                                dtEnd };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                wb.Tx_ExecuteNonQuery(ConnectionString.LOGDB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            }
        }

        #endregion

        #region :: 조건 Check Method ::

        /// <summary>
        /// 신규 조건 Check Method
        /// </summary>
        /// <returns></returns>
        protected virtual bool CheckNewCondition()
        {
            return true;
        }

        /// <summary>
        /// 조회 조건 Check Method
        /// </summary>
        /// <returns></returns>
        protected virtual bool CheckSelectionCondition()
        {
            return true;
        }

        /// <summary>
        /// 삭제 조건 Check Method
        /// </summary>
        /// <returns></returns>
        protected virtual bool CheckDeleteCondition()
        {
            return CheckDeleteCondition(null);
        }

        /// <summary>
        /// 삭제 조건 Check Method
        /// </summary>
        /// <param name="dt">Check할 Data</param>
        /// <returns></returns>
        protected virtual bool CheckDeleteCondition(DataTable dt)
        {
            return showCheckMessage(MsgType.Delete, dt);
        }

        /// <summary>
        /// 저장 조건 Check Method
        /// </summary>
        /// <returns></returns>
        protected virtual bool CheckSaveCondition()
        {
            return CheckSaveCondition(null);
        }

        /// <summary>
        /// 저장 조건 Check Method
        /// </summary>
        /// <param name="dt">Check할 Data</param>
        /// <returns></returns>
        protected virtual bool CheckSaveCondition(DataTable dt)
        {
            return showCheckMessage(MsgType.Save, dt);
        }

        /// <summary>
        /// 복사 조건 Check Method
        /// </summary>
        /// <returns></returns>
        private bool CheckCopyCondition()
        {
            return CheckCopyCondition(null);
        }

        /// <summary>
        /// 복사 조건 Check Method
        /// </summary>
        /// <param name="dt">Check할 Data</param>
        /// <returns></returns>
        protected virtual bool CheckCopyCondition(DataTable dt)
        {
            return showCheckMessage(MsgType.Copy, dt);
        }

        /// <summary>
        /// Chart 조회 조건 Check Method
        /// </summary>
        /// <returns></returns>
        protected virtual bool CheckChartCondition()
        {
            return true;
        }

        #region :: Check Method :: 저장/삭제 시 메시지를 처리합니다.

        /// <summary>
        /// 저장 삭제 시 메시지를 보여줍니다.
        /// </summary>
        /// <param name="msgType">Message Type</param>
        /// <returns></returns>
        private bool showCheckMessage(MsgType msgType)
        {
            return showCheckMessage(msgType, null);
        }

        /// <summary>
        /// 저장 삭제 시 메시지를 보여줍니다.
        /// </summary>
        /// <param name="msgType">Message Type</param>
        /// <param name="dt">체크할 DataTable</param>
        /// <returns></returns>
        private bool showCheckMessage(MsgType msgType, DataTable dt)
        {
            string message = string.Empty;
            switch (msgType)
            {
                case MsgType.Save:
                    message = LOCALECONVERTER.GetLocaleString("Save");
                    break;
                case MsgType.Delete:
                    message = LOCALECONVERTER.GetLocaleString("Delete");
                    break;
                case MsgType.Copy:
                    message = LOCALECONVERTER.GetLocaleString("Copy");
                    break;
            }
            if (dt != null && dt.Rows.Count < 1)
            {
                ShowMsgBox(String.Format(LOCALECONVERTER.GetLocaleMessage("IF_NoData"), message), message);
                return false;
            }
            return DialogResult.Yes == ShowMsgBox(String.Format(LOCALECONVERTER.GetLocaleMessage("CF_Do"), message),
                                    message, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        #endregion

        #endregion

        #region :: SetBindingMapping :: Control을 데이터와 바인딩합니다.

        /// <summary>
        /// Control을 데이터와 바인딩합니다.
        /// </summary>
        /// <param name="ds"></param>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        ///
        /// </remarks>
        protected void SetBindingMapping(DataSet ds)
        {
            SetBindingMapping(this, ds);
        }

        /// <summary>
        /// Control을 데이터와 바인딩합니다.
        /// </summary>
        /// <param name="control">컨트롤</param>
        /// <param name="ds"></param>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        ///
        /// </remarks>
        protected void SetBindingMapping(Control control, DataSet ds)
        {
            if (control.HasChildren)
            {
                foreach (Control ctrl in control.Controls)
                {
                    if ((ctrl is IBindings) && (ctrl as IBindings).BindingMember != null && (ctrl as IBindings).BindingMember != "")
                        (ctrl as IBindings).BindingMapping(ds.Tables[0], (ctrl as IBindings).BindingMember);

                    SetBindingMapping(ctrl, ds);
                }
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Control을 데이터와 바인딩합니다.
        /// </summary>
        /// <param name="group">Layout Group</param>
        /// <param name="ds"></param>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        ///
        /// </remarks>
        protected void SetBindingMapping(LayoutControlGroup group, DataSet ds)
        {
            LayoutControl control = new LayoutControl();

            foreach (DevExpress.XtraLayout.BaseLayoutItem bi in group.Items)
            {
                if (bi is LayoutControlGroup)
                    SetBindingMapping(bi as LayoutControlGroup, ds);

                DevExpress.XtraLayout.LayoutControlItem lcItem = bi as DevExpress.XtraLayout.LayoutControlItem;

                if (lcItem == null) continue;

                IBindings bindingControl = lcItem.Control as IBindings;

                if (bindingControl == null || bindingControl.BindingMember == null || bindingControl.BindingMember == "") continue;

                bindingControl.BindingMapping(ds.Tables[0], bindingControl.BindingMember);
            }
        }

        #endregion

        #region :: InitEditValue :: UI Form의 Control을 초기화 합니다.

        /// <summary>
        /// UI Form의 Control을 초기화 합니다.
        /// </summary>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        ///
        /// </remarks>
        protected void InitEditValue()
        {
            InitEditValue(this);
        }

        /// <summary>
        /// UI Form의 Control을 초기화 합니다.
        /// </summary>
        /// <param name="control">컨트롤</param>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        ///
        /// </remarks>
        protected void InitEditValue(Control control)
        {
            if (control.HasChildren)
            {
                foreach (Control ctrl in control.Controls)
                {
                    if ((ctrl is IInitEditValue) && (ctrl as IInitEditValue).IsInitEditValue)
                        (ctrl as IInitEditValue).InitEditValue();

                    InitEditValue(ctrl);
                }
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// UI Form의 Control을 초기화 합니다.
        /// </summary>
        /// <param name="group">Layout Group</param>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        ///
        /// </remarks>
        protected void InitEditValue(LayoutControlGroup group)
        {
            foreach (DevExpress.XtraLayout.BaseLayoutItem bi in group.Items)
            {
                if (bi is LayoutControlGroup)
                    InitEditValue(bi as LayoutControlGroup);

                DevExpress.XtraLayout.LayoutControlItem lcItem = bi as DevExpress.XtraLayout.LayoutControlItem;

                if (lcItem == null) continue;

                IInitEditValue initValue = lcItem.Control as IInitEditValue;

                if (initValue == null) continue;

                if (!initValue.IsInitEditValue) continue;

                initValue.InitEditValue();
            }
        }

        #endregion

        #region :: Show Close WaitDialog :: Wait Dialog를 보여주거나 닫습니다.

        /// <summary>
        /// Wait Dialog를 보여줍니다.
        /// </summary>
        /// <param name="caption"></param>
        public void ShowWaitDialog(string caption)
        {
            FRAME.ShowWaitDialog(caption);
        }

        /// <summary>
        /// Wait Dialog를 보여줍니다.
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="description"></param>
        public void ShowWaitDialog(string caption, string description)
        {
            FRAME.ShowWaitDialog(caption, description);
        }

        /// <summary>
        /// Wait Dialog를 닫습니다.
        /// </summary>
        public void CloseWaitDialog()
        {
            if (FRAME == null) return;

            FRAME.CloseWaitDialog();
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
            return FRAME.ShowMsgBox(text, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// MessageBox를 보여줍니다.
        /// </summary>
        /// <param name="text">Message</param>
        /// <param name="caption">Caption</param>
        /// <returns></returns>
        public DialogResult ShowMsgBox(string text, string caption)
        {
            return FRAME.ShowMsgBox(text, caption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
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
            return FRAME.ShowMsgBox(text, caption, buttons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
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
            return FRAME.ShowMsgBox(text, caption, buttons, icon, MessageBoxDefaultButton.Button1);
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
            return FRAME.ShowMsgBox(text, caption, buttons, icon, defaultButton);
        }

        #endregion

        #region :: ShowExceptionBox :: Exception Box를 보여줍니다.

        /// <summary>
        /// Exception Box를 보여줍니다.
        /// </summary>
        /// <param name="ex">Exception</param>
        public void ShowExceptionBox(Exception ex)
        {
            FRAME.ShowExceptionBox(ex);
        }

        #endregion

        #region :: ShowFlyoutDialog :: Flyout Dialog를 보여줍니다.

        /// <summary>
        /// Flyout Dialog를 보여줍니다.
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="description"></param>
        public void ShowFlyoutDialog(string caption, string description)
        {
            FRAME.ShowFlyoutDialog(caption, description);
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: GetGridColumnSet :: Database에서 컬럼 정보를 가져옵니다.

        /// <summary>
        /// Database에서 컬럼 정보를 가져옵니다.
        /// </summary>
        /// <param name="gridName"></param>
        public DataSet GetGridColumnSet(string gridName)
        {
            return GetGridColumnSet(SCREENID, gridName);
        }

        /// <summary>
        /// Database에서 컬럼 정보를 가져옵니다.
        /// </summary>
        /// <param name="screenId"></param>
        /// <param name="gridName"></param>
        public DataSet GetGridColumnSet(string screenId, string gridName)
        {
            DataSet ds;
            const string queryId = @"dbo.ScreenColumnSetInfo_Get";

            string[] paramList = new string[] { "@SCREENID",
                                                "@GRIDNAME" };
            object[] valueList = new object[] { screenId,
                                                gridName };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            }

            return ds;
        }

        #endregion

        #region :: ShowInfoMessage :: Alert Message를 보여줍니다.

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
        public void ShowInfoMessage(string caption, string text, string hotTrackedText)
        {
            FRAME.ShowInfoMessage(caption, text, hotTrackedText);
        }

        /// <summary>
        /// Alert Message를 보여줍니다.
        /// </summary>
        /// <param name="caption">Alert Control Caption</param>
        /// <param name="text">Alert Message</param>
        /// <param name="hotTrackedText">Hot Tracked Text</param>
        /// <param name="color">색 지정</param>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        ///
        /// </remarks>
        public void ShowInfoMessage(string caption, string text, string hotTrackedText, Color color)
        {
            FRAME.ShowInfoMessage(caption, text, hotTrackedText, color);
        }

        #endregion

        #region :: ShowAlertMessage :: Alert Message를 보여줍니다.

        /// <summary>
        /// Alert Message를 보여줍니다.
        /// </summary>
        /// <param name="text">Alert Message</param>
        /// <param name="caption">Alert Control Caption</param>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        ///
        /// </remarks>
        public void ShowAlertMessage(string text, string caption)
        {
            FRAME.ShowAlertMessage(caption, text, "");
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
            FRAME.ShowAlertMessage(caption, text, hotTrackedText);
        }

        #endregion

        #region :: RemoveInfoMessage :: Alert Message를 삭제 합니다.

        /// <summary>
        /// 메세지 삭제 합니다.
        /// </summary>
        /// <param name="text"></param>
        public void RemoveAlertMessage(string text)
        {
            FRAME.RemoveMessage(text);
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Control Event
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: barManager_ItemClick :: UI Form의 툴바를 클릭하면 발생합니다.

        /// <summary>
        /// UI Form의 툴바를 클릭하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barManager_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                OnRibbonItemClick(e.Item.Name);
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: OnActivated :: Form 이 Activated 되면 MainFrame의 Button을 재설정합니다.

        /// <summary>
        /// Form 이 Activated 되면 MainFrame의 Button을 재설정합니다.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            if (MdiParent == null || Controls.Count == 0)
                return;

            SetRibbonBarButtonEnabled();

            //SetToolBarVisible(true);
        }

        #endregion

        #region :: OnLoad :: Popup 창이 로드될 때 버튼권한을 설정합니다.

        /// <summary>
        /// UI Form이 로드될 때 버튼권한을 설정합니다.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            DateTime startDttm = DateTime.Now;

            if (!DesignMode) startDttm = GetCurrentTime();
            ISLOADING = true;
            base.OnLoad(e);

            if (DesignMode || LOCALECONVERTER == null) return;

            SaveOperationLog("LOAD", startDttm);

            iSelect.Caption = LOCALECONVERTER.GetLocaleString("Inquiry");
            iNew.Caption = LOCALECONVERTER.GetLocaleString("New");
            iCancelEdit.Caption = LOCALECONVERTER.GetLocaleString("Cancel");
            iSave.Caption = LOCALECONVERTER.GetLocaleString("Save");
            iDelete.Caption = LOCALECONVERTER.GetLocaleString("Delete");
            iCopy.Caption = LOCALECONVERTER.GetLocaleString("Copy");
            iClose.Caption = LOCALECONVERTER.GetLocaleString("Close");
            iReload.Caption = LOCALECONVERTER.GetLocaleString("Refresh");
            iHelp.Caption = LOCALECONVERTER.GetLocaleString("Help");
            iCapture.Caption = LOCALECONVERTER.GetLocaleString("CaptureScreen");
            iExcel.Caption = LOCALECONVERTER.GetLocaleString("Export");

            InitLocaleString(this);
            ISLOADING = false;

            //SetSplitPanelProperty();
            SetSelectionButtonEvent();
            //SetFilterProperty();

            if (IsLoadSelectEvent) RaiseSelectEvent();
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetSplitPanelProperty()
        {
            //List<Control> controls = new List<Control>();
            //AppUtil.FindControl(controls, this, "DevExpress.XtraEditors.SplitGroupPanel");

            //if (controls.Count > 0)
            //{
            //    SplitGroupPanel ctrl = controls[1] as SplitGroupPanel;

            //    if (ctrl == null) return;

            //    ctrl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            //    ctrl.ShowCaption = true;
            //    ctrl.AppearanceCaption.Font = new System.Drawing.Font("나눔고딕", 8.75F, FontStyle.Bold);
            //    ctrl.AppearanceCaption.ForeColor = DXSkinColors.FillColors.Primary;

            //    ctrl.Text = $"[{MENUID}] {Text}";
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetSelectionButtonEvent()
        {
            List<Control> controls = new List<Control>();

            AppUtil.FindControl<SimpleButton>(controls, this);

            if (controls.Count > 0)
            {
                SimpleButton btn = null;
                foreach (Control control in controls)
                {
                    if (control.Name == "btnSelection")
                    {
                        btn = control as SimpleButton;
                        break;
                    }
                }

                if (btn != null)
                {
                    btn.Click += (sender, args) =>
                    {
                        RaiseSelectEvent();
                    };
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetFilterProperty()
        {
            List<BaseLayoutItem> controls = new List<BaseLayoutItem>();

            FindLayoutGroup(controls, this, "layoutFilter");

            if (controls.Count > 0)
            {
                DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton btnLeftSplit = new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton();

                LayoutControlGroup group = controls[0] as LayoutControlGroup;
                group.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;

                btnLeftSplit.UseCaption = false;
                btnLeftSplit.Style = DevExpress.XtraBars.Docking2010.ButtonStyle.CheckButton;
                btnLeftSplit.UseImage = true;
                btnLeftSplit.ImageOptions.ImageUri.Uri = "AlignVerticalLeft;Size16x16;GrayScaled";
                btnLeftSplit.CheckedChanged += (sender, args) =>
                {
                    CollapsedPanel();
                };

                group.CustomHeaderButtons.Add(btnLeftSplit);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void CollapsedPanel()
        {
            List<Control> controls = new List<Control>();

            AppUtil.FindControl<SplitContainerControl>(controls, this);

            if (controls.Count > 0)
            {
                bool collapsed = (controls[0] as SplitContainerControl).Collapsed;
                (controls[0] as SplitContainerControl).Collapsed = !collapsed;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="ctrls"></param>
        /// <param name="controlName"></param>
        private void FindLayoutGroup(List<BaseLayoutItem> list, Control ctrls, string controlName)
        {
            if (ctrls.HasChildren)
            {
                foreach (Control ctrl in ctrls.Controls)
                {
                    if (ctrl.GetType().ToString() == "DevExpress.XtraLayout.LayoutControl")
                    {
                        foreach (DevExpress.XtraLayout.BaseLayoutItem bi in (ctrl as DevExpress.XtraLayout.LayoutControl).Items)
                        {
                            if (bi.Name == controlName)
                                list.Add(bi);
                        }
                    }

                    FindLayoutGroup(list, ctrl, controlName);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctrls"></param>
        private void InitLocaleString(Control ctrls)
        {
            if (ctrls.HasChildren)
            {
                foreach (Control ctrl in ctrls.Controls)
                {
                    if (ctrl is LayoutControl)
                    {
                        foreach (BaseLayoutItem bi in (ctrl as LayoutControl).Items)
                        {
                            LayoutControlItem lcItem = bi as LayoutControlItem;

                            if (lcItem == null) continue;

                            ILocaleCtrl localeCtrl = lcItem.Control as ILocaleCtrl;

                            //if (localeCtrl == null || localeCtrl.LocaleEnumClass == null || localeCtrl.LocaleEnumClass == string.Empty) continue;
                            if (localeCtrl == null) continue;

                            bool useLayoutText = !(lcItem.Control is SimpleButton || lcItem.Control is CheckEdit || lcItem.Control is LabelControl || lcItem.Control is ToggleSwitch);

                            if ((localeCtrl.LocaleEnumClass == null || localeCtrl.LocaleEnumClass == string.Empty) && useLayoutText)
                                localeCtrl.LocaleEnumClass = bi.Text;

                            localeCtrl.SetLocaleString();
                            //string itemType = lcItem.Control.GetType().ToString();
                            //switch (itemType)
                            //{
                            //    case "EBAP.Win.ControlLibrary.PButton":
                            //    case "EBAP.Win.ControlLibrary.PCheckEdit":
                            //        lcItem.Control.Text = LANGCONVERTER.GetLanguageString(localeCtrl.LocaleEnumClass);
                            //        break;
                            //    default:
                            //        bi.Text = LANGCONVERTER.GetLanguageString(localeCtrl.LocaleEnumClass);
                            //        break;
                            //}
                        }
                    }

                    InitLocaleString(ctrl);
                }
            }
        }

        #endregion

        #region :: OnClosed :: Form이 Close 되면 MainFrame의 Button을 재설정합니다.

        /// <summary>
        /// Form이 Close 되면 MainFrame의 Button을 재설정합니다.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            if (FRAME == null || MdiParent == null) return;

            FRAME.SetMenuPath("", "");

            if (FRAME.MdiChildren.Length != 1) return;

            //FRAME.InitRibbonControl();
        }

        #endregion
    }
}