using DevExpress.XtraEditors;
using EBAP.Business.WSBiz;
using EBAP.Core.Collections;
using EBAP.Core.Info;
using EBAP.Core.Interface;
using EBAP.Core.Localization;
using EBAP.Win.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace EBAP.Win.BaseFrame
{
    /// <summary>
    /// PopUp Form의 기본이 되는 Frame 입니다.
    /// </summary>
    /// <remarks>
    /// 2016-07-06 최초생성 : 오인봉
    /// 변경내역
    ///
    /// </remarks>
    public partial class PopupFrame : DevExpress.XtraEditors.XtraForm, IRaiseEvent, ILocaleConverter, IFrameUI, IDialog
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// Popup Frame을 생성합니다.
        /// </summary>
        public PopupFrame()
        {
            InitializeComponent();
        }

        #endregion

        #region :: 전역변수 ::

        private ParamCollection _dbParams;
        private bool _isModified = false;
        private bool SELECTAUTH = true;
        private bool NEWAUTH = true;
        private bool SAVEAUTH = true;
        private bool DELETEAUTH = true;

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
        internal MainFrame FRAME
        {
            get { return (Owner as MainFrame); }
        }

        #endregion

        #region :: CurrentUser :: 현재 사용자의 정보를 설정합니다.

        /// <summary>
        /// 현재 사용자의 정보를 설정합니다.
        /// </summary>
        [Browsable(false)]
        public UserInfo CurrentUser
        {
            get { return FRAME.CurrentUser; }
        }

        #endregion

        #region :: 다국어 :: 다국어 지원에 사용할 언어를 설정합니다.

        /// <summary>
        /// 다국어 지원에 사용할 언어
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
        protected internal string LANGUAGE
        {
            get
            {
                return FRAME.CURRENTLANGUAGE;
            }
        }

        #endregion

        #region :: POPUPVALUE :: Popup의 Return 값(명시적으로 형변환하여 사용해야 합니다.)

        /// <summary>
        /// Popup의 Return 값(명시적으로 형변환하여 사용해야 합니다.)
        /// </summary>
        public object POPUPVALUE
        {
            get;
            set;
        }

        #endregion

        #region :: PopParams :: Popup 실행 시에 사용할 Parameter

        /// <summary>
        /// Popup 실행 시에 사용할 Parameter
        /// </summary>
        [Browsable(false)]
        public ParamCollection PopParams
        {
            get;
            set;
        }

        #endregion

        #region :: DatabaseParams :: Database 에 사용할 Parameter

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

        #region :: GetServerTime :: 시스템의 현재 시간을 가져옵니다.

        /// <summary>
        /// 시스템의 현재 시간을 가져옵니다.
        /// </summary>
        /// <returns></returns>
        public DateTime GetCurrentTime()
        {
            return FRAME.GetCurrentTime();
        }

        #endregion

        #region :: ConfirmCaption :: 확인 버튼의 Caption을 설정합니다.

        /// <summary>
        /// 확인 버튼의 Caption을 설정합니다.
        /// </summary>
        protected string ConfirmCaption
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
        /// 저장/삭제 처리 후 보여줄 메시지
        /// </summary>
        [Browsable(false)]
        public string OKMESSAGE
        {
            get;
            set;
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler(Delegate)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 이벤트 Handler 설정 :: 조회, 저장, 삭제 등

        /// <summary>
        /// 삭제 이벤트 발생 시에 사용합니다.
        /// </summary>
        [Category("EBAP"),
        Browsable(true)]
        [Description("삭제 이벤트 발생 시에 사용합니다.")]
        public event EventHandler Delete;

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
        /// 조회 이벤트 발생 시에 사용합니다.
        /// </summary>
        [Category("EBAP"),
        Browsable(true)]
        [Description("조회 이벤트 발생 시에 사용합니다.")]
        public event EventHandler Selection;

        /// <summary>
        /// 확인 이벤트 발생 시에 사용합니다.
        /// </summary>
        [Category("EBAP"),
        Browsable(true)]
        [Description("확인 이벤트 발생 시에 사용합니다.")]
        public event EventHandler Confirm;

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Protected)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: CheckMandatoryControl :: UI Form의 필수 입력항목을 검사하여 검사결과를 반환 합니다.

        /// <summary>
        ///  UI Form의 필수 입력항목을 검사하여 검사결과를 반환 합니다.
        /// </summary>
        /// <returns></returns>
        protected bool CheckMandatoryForSave()
        {
            return CheckMandatoryForSave(this);
        }

        /// <summary>
        ///  UI Form의 필수 입력항목을 검사하여 검사결과를 반환 합니다.
        /// </summary>
        /// <param name="control"></param>
        protected bool CheckMandatoryForSave(Control control)
        {
            bool check = true;

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

                            if ((lcItem.Control as IDBParams).GetControlParamValue().ToString() == "")
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
                                ShowMsgBox(String.Format(LOCALECONVERTER.GetLocaleString("IF_EssentialInquery"), caption));
                                lcItem.Control.Focus();
                                return false;
                            }
                        }
                    }

                    CheckMandatoryForSave(ctrl);
                }
            }
            return check;
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
            bool check = true;

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

                            if ((lcItem.Control as IDBParams).GetControlParamValue().ToString() == "")
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
                                return false;
                            }
                        }
                    }

                    CheckMandatoryForSelect(ctrl);
                }
            }
            return check;
        }

        #endregion

        #region :: SetToolBarVisible :: 툴바의 Visible을 설정합니다.

        /// <summary>
        /// 툴바의 Visible을 설정합니다.
        /// </summary>
        /// <param name="visible"></param>
        protected void SetToolBarVisible(bool visible)
        {
            toolbar.Visible = visible;
        }

        #endregion

        #region :: SetToolBarButtonEnable :: SetToolBarButtonEnable

        /// <summary>
        /// 버튼 Enable을 설정합니다.
        /// </summary>
        /// <param name="selectAuth"></param>
        /// <param name="newAuth"></param>
        /// <param name="saveAuth"></param>
        /// <param name="deleteAuth"></param>
        protected void SetToolBarButtonEnable(bool selectAuth, bool newAuth, bool saveAuth, bool deleteAuth)
        {
            SELECTAUTH = selectAuth;
            NEWAUTH = newAuth;
            SAVEAUTH = saveAuth;
            DELETEAUTH = deleteAuth;
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
            object[] valueList = new object[] { FRAME.ActiveMdiChild == null ? "SIGN" : (FRAME.ActiveMdiChild as IFrameUI).MENUID,
                                                Name,
                                                opertion,
                                                CurrentUser.SIGNINSEQ,
                                                dtStart,
                                                GetCurrentTime() };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                wb.Tx_ExecuteNonQuery(ConnectionString.LOGDB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            }
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

        #region :: ShowExceptionBox :: Exception Box를 보여줍니다.

        /// <summary>
        /// MessageBox를 보여줍니다.
        /// </summary>
        /// <param name="ex">Exception</param>
        public void ShowExceptionBox(Exception ex)
        {
            FRAME.ShowExceptionBox(ex);
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
            FRAME.CloseWaitDialog();
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: Raise Event :: 이벤트 강제 발생

        /// <summary>
        /// 조회 Event를 강제로 발생시킵니다.
        /// </summary>
        public void RaiseSelectEvent()
        {
            OKMESSAGE = "";

            if (!SELECTAUTH || Selection == null || !CheckMandatoryForSelect()) return;

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

                SaveOperationLog("SELECT", startDttm);
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
        /// 신규 Event를 강제로 발생시킵니다.
        /// </summary>
        public void RaiseNewEvent()
        {
            if (!NEWAUTH || New == null) return;

            if (ISMODIFIED)
            {
                if (ShowMsgBox(LOCALECONVERTER.GetLocaleMessage("CF_S_CONTINUE"), Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    != System.Windows.Forms.DialogResult.Yes) return;
            }

            DateTime startDttm = GetCurrentTime();

            New(this, new EventArgs());

            ISMODIFIED = false;

            SaveOperationLog("NEW", startDttm);
        }

        /// <summary>
        /// Save Event를 강제로 발생시킵니다.
        /// </summary>
        public void RaiseSaveEvent()
        {
            OKSAVE = true;
            OKMESSAGE = "";

            if (!SAVEAUTH || Save == null || !CheckMandatoryForSave()) return;

            try
            {
                string message = LOCALECONVERTER.GetLocaleMessage("DO_Save");
                ShowWaitDialog(message);

                DateTime startDttm = GetCurrentTime();

                Save(this, new EventArgs());
                
                if (!OKSAVE) return;

                ISMODIFIED = false;

                message = OKMESSAGE != "" ? OKMESSAGE : LOCALECONVERTER.GetLocaleMessage("OK_SAVE");

                SaveOperationLog("SAVE", startDttm);

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

            if (!DELETEAUTH || Delete == null) return;

            try
            {
                DateTime startDttm = GetCurrentTime();

                Delete(this, new EventArgs());

                if (!OKDELETE) return;

                SaveOperationLog("DELETE", startDttm);

                ShowFlyoutDialog(LOCALECONVERTER.GetLocaleString("Delete"), OKMESSAGE != "" ? OKMESSAGE : LOCALECONVERTER.GetLocaleMessage("OK_DELETE"));
            }
            catch (Exception)
            {
                OKDELETE =false;
                throw;
            }
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
        // Control Event
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: barManager_ItemClick :: Bar Item을 Click 하면 해당 Event를 발생시킵니다.

        /// <summary>
        /// Bar Item을 Click 하면 해당 Event를 발생시킵니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barManager_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                switch (e.Item.Name)
                {
                    case "iSelect":
                        RaiseSelectEvent();
                        break;
                    case "iNew":
                        RaiseNewEvent();
                        break;
                    case "iSave":
                        RaiseSaveEvent();
                        break;
                    case "iDelete":
                        RaiseDeleteEvent();
                        break;
                    case "iConfirm":
                        if (Confirm != null)
                            Confirm(this, new EventArgs());
                        else
                            DialogResult = System.Windows.Forms.DialogResult.OK;
                        break;
                    case "iClose":
                        Close();
                        break;
                    case "iExcel":
                        ExportTo(ExportType.Excel, this);
                        break;
                    case "iCancel":
                        DialogResult = System.Windows.Forms.DialogResult.Cancel;
                        break;
                }
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
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
                //FRAME.ShowInfoMessage("작업 오류", "Export 작업을 처리할 Grid를 찾지 못했습니다.", "Grid를 선택해야 합니다.");
                ShowAlertMessage("[ 내보내기 ] 작업을 처리할 컨트롤을 찾지 못했습니다. 컨트롤을 선택하세요.", "내보내기 오류");
                return;
            }

            IExport ctrl = lists[0] as IExport;

            if (ctrl == null || (ctrl.DisableExport && !CurrentUser.ISADMIN))
            {
                ShowAlertMessage("[ 내보내기 ] 불가능한 데이터 입니다. 관리자에게 문의하세요.", "내보내기 불가");
                return;
            }

            // PopParams 에 관리번호가 있을 시 엑셀 파일이름 앞에 관리번호 추가
            string managementCode = string.Format("{0}", PopParams.Contains("ManagementCode") ? PopParams["ManagementCode"].ToString() + " " : string.Empty);

            string folderPath = Path.Combine(AppConfig.ASSEMBLYFOLDER, "ExportFiles");

            AppUtil.CreateFolder(folderPath);

            string fileName = String.Format("{2}{0}({1:yyyy-MM-dd_HHmmss})", control.Text.Replace(" / ", string.Empty), DateTime.Now, managementCode);

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


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: OnLoad :: Popup 창이 로드될 때 버튼권한을 설정합니다.

        /// <summary>
        /// Popup 창이 로드될 때 버튼권한을 설정합니다.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            ConfirmCaption = "Confirm2";

            DateTime startDttm = DateTime.Now;
            if (!DesignMode) startDttm = GetCurrentTime();
            ISLOADING = true;

            base.OnLoad(e);

            iSelect.Enabled = (Selection != null && SELECTAUTH);
            iNew.Enabled = (New != null && NEWAUTH);
            iDelete.Enabled = (Delete != null && DELETEAUTH);
            iSave.Enabled = (Save != null && SAVEAUTH);

            if (DesignMode || LOCALECONVERTER == null) return;

            SaveOperationLog("LOAD", startDttm);

            iSelect.Caption = LOCALECONVERTER.GetLocaleString("Inquiry");
            iNew.Caption = LOCALECONVERTER.GetLocaleString("New");
            iSave.Caption = LOCALECONVERTER.GetLocaleString("Save");
            iDelete.Caption = LOCALECONVERTER.GetLocaleString("Delete");
            iClose.Caption = LOCALECONVERTER.GetLocaleString("Close");
            iConfirm.Caption = LOCALECONVERTER.GetLocaleString(ConfirmCaption);
            InitLocaleString(this);

            ISLOADING = false;
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
                    if (ctrl.GetType().ToString() == "DevExpress.XtraLayout.LayoutControl")
                    {
                        foreach (DevExpress.XtraLayout.BaseLayoutItem bi in (ctrl as DevExpress.XtraLayout.LayoutControl).Items)
                        {
                            DevExpress.XtraLayout.LayoutControlItem lcItem = bi as DevExpress.XtraLayout.LayoutControlItem;

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
                            //        lcItem.Control.Text = LOCALECONVERTER.GetLocaleString(locales.LocaleEnumClass);
                            //        break;
                            //    default:
                            //        bi.Text = LOCALECONVERTER.GetLocaleString(locales.LocaleEnumClass);
                            //        break;
                            //}
                        }
                    }

                    InitLocaleString(ctrl);
                }
            }
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
    }
}