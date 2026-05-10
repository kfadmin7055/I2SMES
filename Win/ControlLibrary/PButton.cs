using DevExpress.XtraLayout;
using EBAP.Core.Interface;
using System;
using System.ComponentModel;

namespace EBAP.Win.ControlLibrary
{
    /// <summary>
    /// ButtonEdit 입니다.
    /// DevExpress SimpleButton을 Wrapping 하여 사용합니다.
    /// </summary>
    /// <remarks>
    /// 2023-02-01 최초생성 : 오인봉
    /// 변경내역
    ///
    /// </remarks>
    [ToolboxItem(true)]
    public partial class PButton : DevExpress.XtraEditors.SimpleButton, ILocaleCtrl
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// SimpleButton Control을 생성합니다.
        /// </summary>
        public PButton()
        {
            InitializeComponent();
        }

        #endregion

        #region :: 전역변수 ::

        //ButtonType _buttonType = ButtonType.Default;

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Interface 구현
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region ILocaleCtrl 멤버

        /// <summary>
        /// Database Parameter Name 입니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(""), Browsable(true)]
        [Description("다국어 ID 입니다.")]
        public string LocaleEnumClass
        {
            get;
            set;
        }

        /// <summary>
        /// 컨트롤의 다국어 텍스트를 설정합니다.
        /// </summary>
        public void SetLocaleString()
        {
            if (LocaleEnumClass == null || LocaleEnumClass == "") return;

            Text = (FindForm() as ILocaleConverter).LOCALECONVERTER.GetLocaleString(LocaleEnumClass);
        }

        #endregion

        #region :: IsPopup :: 버튼클릭 시 Popup 창 생성 여부를 설정합니다.

        /// <summary>
        /// 버튼클릭 시 Popup 창 생성 여부를 설정합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(false), Browsable(true)]
        [Description("버튼클릭 시 Popup 창 생성 여부를 설정합니다.")]
        public bool IsPopup
        {
            get;
            set;
        }

        #endregion

        #region :: SaveLog :: 버튼 클릭 시 로그저장 여부를 설정합니다.

        /// <summary>
        /// 일괄 초기화 여부를 설정합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue("SAVELOG"), Browsable(true)]
        [Description("버튼 클릭 시 로그저장 여부를 설정합니다.")]
        public string SAVELOG
        {
            get;
            set;
        }

        #endregion

        #region :: ShowMsgBoxAfterClick :: 클릭이벤트가 정상 처리되었을 때 메시지 처리 여부를 설정합니다.

        /// <summary>
        /// 클릭이벤트가 정상 처리되었을 때 메시지 처리 여부를 설정합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(false), Browsable(true)]
        [Description("클릭이벤트가 정상 처리되었을 때 메시지 처리 여부를 설정합니다.")]
        public bool ShowMsgBoxAfterClick
        {
            get;
            set;
        }

        #endregion

        #region :: ShowMsgBoxAfterClick :: 클릭이벤트가 정상 처리되었을 때 메시지 처리 여부를 설정합니다.

        /// <summary>
        /// 클릭이벤트가 정상 처리되었을 때 메시지 처리 여부를 설정합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(false), Browsable(false)]
        [Description("클릭이벤트가 정상 처리되었을 때 메시지 처리 여부를 설정합니다.")]
        public bool IsValid
        {
            get;
            set;
        }

        /// <summary>
        /// 버튼텍스트에서 ...을 제거하고 텍스트를 보여줍니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(""), Browsable(false)]
        [Description("버튼텍스트에서 ...을 제거하고 텍스트를 보여줍니다.")]
        public string Caption
        {
            get { return Text.Replace("...", ""); }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: OnClick :: 클릭 이벤트 발생 시 Dialog를 보여줍니다.

        /// <summary>
        /// 클릭 이벤트 발생 시 Dialog를 보여줍니다.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClick(EventArgs e)
        {
            IsValid = true;

            DateTime startDttm = DateTime.Now;

            IDialog ui = (FindForm() as IDialog);
            if (ui != null && !IsPopup) ui.ShowWaitDialog(String.Format("[ {0} ] 처리 중입니다.", Caption));

            if (SAVELOG != null && SAVELOG != "") startDttm = (FindForm() as IFrameUI).GetCurrentTime();

            base.OnClick(e);

            if (SAVELOG != null && SAVELOG != "" && IsValid) (FindForm() as IFrameUI).SaveOperationLog(SAVELOG, startDttm);

            if (ui != null && !IsPopup) ui.CloseWaitDialog();

            if (FindForm() == null) return;

            string message = (FindForm() as IFrameUI).OKMESSAGE == "" ? String.Format((FindForm() as ILocaleConverter).LOCALECONVERTER.GetLocaleMessage("OK_WORK"), Caption) : (FindForm() as IFrameUI).OKMESSAGE;

            if (ui != null && ShowMsgBoxAfterClick && IsValid) ui.ShowFlyoutDialog(Caption, message);
        }

        #endregion

        #region :: Text :: IsPopup 이 True 일 경우 ...을 표시합니다.

        //private bool isChanged = false;

        ///// <summary>
        ///// IsPopup 이 True 일 경우 ...을 표시합니다.
        ///// </summary>
        //public override string Text
        //{
        //    get
        //    {
        //        return IsPopup ? this.Text.Replace("...", "") : this.Text;
        //    }
        //    set
        //    {
        //        if (isChanged) return;
        //        base.Text = IsPopup ? string.Format("{0}...", value) : value;
        //        isChanged = true;
        //    }
        //}

        #endregion
    }
}
