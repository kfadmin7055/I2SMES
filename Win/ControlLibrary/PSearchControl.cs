using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraLayout;
using EBAP.Core.Interface;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace EBAP.Win.ControlLibrary
{
    /// <summary>
    /// SearchControl 입니다.
    /// DevExpress SearchControl을 Wrapping 하여 사용합니다.
    /// </summary>
    [ToolboxItem(true)]
    public partial class PSearchControl : DevExpress.XtraEditors.SearchControl
        , IInitEditValue
        , ICheckModified
        , IDBParams
        , IEnterKeySelectEvent
        , IBindings
        , ILocaleCtrl
        , IMandatory
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// Search Control을 생성합니다.
        /// </summary>
        public PSearchControl()
        {
            InitializeComponent();

            InitControl();
        }

        #endregion

        #region :: 전역변수 ::

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Initialize
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: InitControl ::

        /// <summary>
        /// 기본 설정 초기화
        /// </summary>
        private void InitControl()
        {
            Properties.FindDelay = 100;

            Properties.NullValuePrompt = "검색어 입력";

            Properties.NullValuePromptShowForEmptyValue = true;

            Properties.ShowClearButton = true;

            Properties.ShowSearchButton = true;

            Properties.AllowHtmlDraw = DefaultBoolean.True;
        }

        #endregion

        #region :: SetSearchClient ::

        /// <summary>
        /// SearchControl Client 설정
        /// </summary>
        /// <param name="clientControl"></param>
        public void SetSearchClient(ISearchControlClient clientControl)
        {
            Client = clientControl;
        }

        /// <summary>
        /// SearchControl Client 설정
        /// </summary>
        /// <param name="clientControl"></param>
        /// <param name="promptText"></param>
        /// <param name="findDelay"></param>
        public void SetSearchClient(
            ISearchControlClient clientControl,
            string promptText,
            int findDelay = 100)
        {
            Client = clientControl;

            Properties.FindDelay = findDelay;

            Properties.NullValuePrompt = promptText;
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Interface 구현
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region IInitEditValue 멤버

        /// <summary>
        /// 일괄 초기화 여부를 설정합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(false), Browsable(true)]
        [Description("일괄 초기화 여부를 설정합니다.")]
        public bool IsInitEditValue
        {
            get;
            set;
        }

        /// <summary>
        /// 컨트롤을 초기화 합니다.
        /// </summary>
        public void InitEditValue()
        {
            this.EditValue = "";
        }

        #endregion

        #region IModifiedCheck 멤버

        /// <summary>
        /// EditValue의 변경 Check 여부를 설정합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(false), Browsable(true)]
        [Description("EditValue의 변경 Check 여부를 설정합니다.")]
        public bool CheckModified
        {
            get;
            set;
        }

        #endregion

        #region IMandatory 멤버

        private bool _ismandatoryforsave = false;

        /// <summary>
        /// 필수입력(저장) 체크 여부를 설정합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(false), Browsable(true)]
        [Description("필수입력(저장) 체크 여부를 설정합니다.")]
        public bool IsMandatoryForSave
        {
            get { return _ismandatoryforsave; }
            set
            {
                _ismandatoryforsave = value;

                if (DesignMode)
                    return;

                BorderStyle = value
                    ? DevExpress.XtraEditors.Controls.BorderStyles.Simple
                    : DevExpress.XtraEditors.Controls.BorderStyles.Default;

                Properties.Appearance.BorderColor = value
                    ? ControlConfig.MANDATORYBORDERCOLOR
                    : ControlConfig.EMPTYCOLOR;
            }
        }

        private bool _ismandatoryforselect = false;

        /// <summary>
        /// 필수입력(조회) 체크 여부를 설정합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(false), Browsable(true)]
        [Description("필수입력(조회) 체크 여부를 설정합니다.")]
        public bool IsMandatoryForSelect
        {
            get { return _ismandatoryforselect; }
            set
            {
                _ismandatoryforselect = value;

                if (DesignMode)
                    return;

                BorderStyle = value
                    ? DevExpress.XtraEditors.Controls.BorderStyles.Simple
                    : DevExpress.XtraEditors.Controls.BorderStyles.Default;

                Properties.Appearance.BorderColor = value
                    ? ControlConfig.MANDATORYBORDERCOLOR
                    : ControlConfig.EMPTYCOLOR;
            }
        }

        #endregion

        #region IDBParams 멤버

        /// <summary>
        /// Database Parameter Name 입니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(""), Browsable(true)]
        [Description("Database Parameter Name 입니다.")]
        public string ParamName
        {
            get;
            set;
        }

        /// <summary>
        /// Parameter Value 반환
        /// </summary>
        /// <returns></returns>
        public object GetControlParamValue()
        {
            return EditValue;
        }

        #endregion

        #region IEnterKeySelectEvent 멤버

        private bool _enterkeyselectevent = false;

        /// <summary>
        /// 엔터키를 눌렀을때 조회이벤트 발생 여부를 설정합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(false), Browsable(true)]
        [Description("엔터키를 눌렀을때 조회이벤트 발생 여부를 설정합니다.")]
        public bool EnterKeySelectEvent
        {
            get { return _enterkeyselectevent; }
            set
            {
                _enterkeyselectevent = value;

                if (DesignMode)
                    return;

                BorderStyle = value
                    ? DevExpress.XtraEditors.Controls.BorderStyles.Simple
                    : DevExpress.XtraEditors.Controls.BorderStyles.Default;

                Properties.Appearance.BorderColor = value
                    ? ControlConfig.SELECTEVENTBORDERCOLOR
                    : ControlConfig.EMPTYCOLOR;
            }
        }

        #endregion

        #region ILocaleCtrl 멤버

        /// <summary>
        /// 다국어 ID
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
            if (AdvancedMode && Properties.UseAdvancedMode == DefaultBoolean.True)
            {
                if (Parent is LayoutControl)
                    (Parent as LayoutControl).GetItemByControl(this).TextVisible = false;

                if (LocaleEnumClass == null || LocaleEnumClass == string.Empty)
                {
                    if (Parent is LayoutControl)
                        Properties.AdvancedModeOptions.Label =
                            (Parent as LayoutControl).GetItemByControl(this).Text;
                }
                else
                {
                    Properties.AdvancedModeOptions.Label =
                        (FindForm() as ILocaleConverter)
                        .LOCALECONVERTER
                        .GetLocaleString(LocaleEnumClass);
                }
            }

            if (Parent is LayoutControl)
            {
                (Parent as LayoutControl)
                    .GetItemByControl(this)
                    .Text =
                    (FindForm() as ILocaleConverter)
                    .LOCALECONVERTER
                    .GetLocaleString(LocaleEnumClass);
            }
        }

        #endregion

        #region IBindings 구현

        /// <summary>
        /// 데이터 바인딩 멤버
        /// </summary>
        [Category("EBAP"), DefaultValue(""), Browsable(true)]
        [Description("데이터 바인딩 멤버 입니다.")]
        public string BindingMember
        {
            get;
            set;
        }

        /// <summary>
        /// DataTable과 EditValue를 Mapping 합니다.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dataMember"></param>
        public void BindingMapping(DataTable dt, string dataMember)
        {
            DataBindings.Clear();

            DataBindings.Add(
                "EditValue",
                dt,
                dataMember,
                false,
                DataSourceUpdateMode.OnPropertyChanged,
                ""
            );
        }

        #endregion

        #region :: TrimText ::

        /// <summary>
        /// Trim 된 텍스트를 반환합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(""), Browsable(false)]
        [Description("Trim 된 텍스트를 반환합니다.")]
        public string TrimText
        {
            get
            {
                return EditValue == null
                    ? string.Empty
                    : EditValue.ToString().Trim();
            }
        }

        #endregion

        #region :: AutoSelectLength ::

        /// <summary>
        /// 자동으로 조회되는 길이를 설정합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue("0"), Browsable(true)]
        [Description("자동으로 조회되는 길이를 설정합니다.")]
        public int AutoSelectLength
        {
            get;
            set;
        }

        #endregion

        #region :: EqualControlNextSeq ::

        [Category("EBAP"), DefaultValue(""), Browsable(true)]
        public int EqualControlNextSeq
        {
            get;
            set;
        }

        #endregion

        #region :: EqualTotalControlNextSeq ::

        [Category("EBAP"), DefaultValue(""), Browsable(true)]
        public int EqualTotalControlNextSeq
        {
            get;
            set;
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: SetSuperToolTip ::

        /// <summary>
        /// ToolTip 설정
        /// </summary>
        /// <param name="title"></param>
        /// <param name="contents"></param>
        public void SetSuperToolTip(string title, string contents)
        {
            SuperToolTip sTip = new SuperToolTip();

            ToolTipTitleItem tTitle = new ToolTipTitleItem();

            ToolTipItem tContents = new ToolTipItem();

            tTitle.Text = title;

            tContents.Text = contents;

            tContents.LeftIndent = 6;

            sTip.Items.Add(tTitle);

            sTip.Items.Add(tContents);

            SuperTip = sTip;
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: OnKeyDown ::

        /// <summary>
        /// Enter Key 입력시 조회 이벤트 실행
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (!EnterKeySelectEvent || e.KeyCode != Keys.Enter)
                return;

            (FindForm() as IRaiseEvent).RaiseSelectEvent();
        }

        /// <summary>
        /// Popup 선택 변경시 조회 이벤트 실행
        /// </summary>
        protected override void OnPopupSelectedIndexChanged()
        {
            base.OnPopupSelectedIndexChanged();

            if (!EnterKeySelectEvent)
                return;

            (FindForm() as IRaiseEvent).RaiseSelectEvent();
        }

        #endregion

        #region :: OnLostFocus ::

        /// <summary>
        /// Focus를 잃을 때 수정된 내용이 있으면 MainFrame 에 표시합니다.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            if (!CheckModified || !IsModified)
                return;

            (FindForm() as IFrameUI).ISMODIFIED = true;
        }

        #endregion
    }
}