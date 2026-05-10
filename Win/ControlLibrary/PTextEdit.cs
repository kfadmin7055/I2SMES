using DevExpress.Utils;
using DevExpress.XtraLayout;
using EBAP.Core.Interface;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace EBAP.Win.ControlLibrary
{
    /// <summary>
    /// TextEdit 입니다.
    /// DevExpress TextEdit를 Wrapping 하여 사용합니다.
    /// </summary>
    /// <remarks>
    /// 2023-02-01 최초생성 : 오인봉
    /// 변경내역
    /// 
    /// </remarks>
    [ToolboxItem(true)]
    public partial class PTextEdit : DevExpress.XtraEditors.TextEdit, IInitEditValue, ICheckModified, IDBParams, IEnterKeySelectEvent, IBindings, ILocaleCtrl, IMandatory
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance & Interface Implement
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// TextEdit Control을 생성합니다.
        /// </summary>
        public PTextEdit()
        {
            InitializeComponent();
        }

        #endregion

        #region :: 전역변수 ::

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
        /// 일괄 초기화 여부를 설정합니다.
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

                if (DesignMode) return;

                //BackColor = value ? ControlConfig.MANDATORYBACKCOLOR : ControlConfig.EMPTYCOLOR;
                //ForeColor = value ? ControlConfig.SELECTEVENTFORECOLOR : ControlConfig.EMPTYCOLOR;

                BorderStyle = value ? DevExpress.XtraEditors.Controls.BorderStyles.Simple : DevExpress.XtraEditors.Controls.BorderStyles.Default;
                Properties.Appearance.BorderColor = value ? ControlConfig.MANDATORYBORDERCOLOR : ControlConfig.EMPTYCOLOR;
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

                if (DesignMode) return;

                BorderStyle = value ? DevExpress.XtraEditors.Controls.BorderStyles.Simple : DevExpress.XtraEditors.Controls.BorderStyles.Default;
                Properties.Appearance.BorderColor = value ? ControlConfig.MANDATORYBORDERCOLOR : ControlConfig.EMPTYCOLOR;
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
        /// 
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

                if (DesignMode) return;

                BorderStyle = value ? DevExpress.XtraEditors.Controls.BorderStyles.Simple : DevExpress.XtraEditors.Controls.BorderStyles.Default;
                Properties.Appearance.BorderColor = value ? ControlConfig.SELECTEVENTBORDERCOLOR : ControlConfig.EMPTYCOLOR;

                //BackColor = value ? ControlConfig.SELECTEVENTBACKCOLOR : ControlConfig.EMPTYCOLOR;
                //ForeColor = value ? ControlConfig.SELECTEVENTFORECOLOR : ControlConfig.EMPTYCOLOR;
            }
        }

        #endregion

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
            if (AdvancedMode && Properties.UseAdvancedMode == DefaultBoolean.True)
            {
                if (Parent is LayoutControl) (Parent as LayoutControl).GetItemByControl(this).TextVisible = false;

                if (LocaleEnumClass == null || LocaleEnumClass == string.Empty)
                {
                    if (Parent is LayoutControl) Properties.AdvancedModeOptions.Label = (Parent as LayoutControl).GetItemByControl(this).Text;
                }
                else
                    Properties.AdvancedModeOptions.Label = (FindForm() as ILocaleConverter).LOCALECONVERTER.GetLocaleString(LocaleEnumClass);
            }

            if (Parent is LayoutControl)
                (Parent as LayoutControl).GetItemByControl(this).Text = (FindForm() as ILocaleConverter).LOCALECONVERTER.GetLocaleString(LocaleEnumClass);

            //if (AdvancedMode && Parent is LayoutControl && !(Parent as LayoutControl).GetItemByControl(this).TextVisible)
            //    Properties.AdvancedModeOptions.Label = (FindForm() as ILocaleConverter).LOCALECONVERTER.GetLocaleString(LocaleEnumClass);

            //if (Parent is LayoutControl)
            //    (Parent as LayoutControl).GetItemByControl(this).Text = (FindForm() as ILocaleConverter).LOCALECONVERTER.GetLocaleString(LocaleEnumClass);
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
            DataBindings.Add("EditValue", dt, dataMember, false, DataSourceUpdateMode.OnPropertyChanged, "");
        }

        #endregion

        #region :: TrimText :: Trim 된 텍스트를 반환합니다.

        /// <summary>
        /// Trim 된 텍스트를 반환합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(""), Browsable(false)]
        [Description("Trim 된 텍스트를 반환합니다.")]
        public string TrimText
        {
            get { return EditValue.ToString().Trim(); }
        }

        #endregion

        #region :: AutoSelectLength :: 자동으로 조회되는 길이를 설정합니다.

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

        #region :: EqualControlNextSeq :: 동일한 Type의 컨트롤 다음 Seq를 반환합니다.

        /// <summary>
        /// 동일한 Type의 컨트롤 다음 Seq를 반환합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(""), Browsable(true)]
        [Description("동일한 Type의 컨트롤 다음 Seq를 반환합니다.")]
        public int EqualControlNextSeq
        {
            get;
            set;
        }

        #endregion

        #region :: EqualTotalControlNextSeq :: 종속된 상위 컨트롤내에서 동일한 Type의 컨트롤 다음 Seq를 반환합니다.

        /// <summary>
        /// 종속된 상위 컨트롤내에서 동일한 Type의 컨트롤 다음 Seq를 반환합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(""), Browsable(true)]
        [Description("종속된 상위 컨트롤내에서 동일한 Type의 컨트롤 다음 Seq를 반환합니다.")]
        public int EqualTotalControlNextSeq
        {
            get;
            set;
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: SetSuperToolTip :: ToolTip을 설정합니다.

        /// <summary>
        /// ToolTip을 설정합니다.
        /// </summary>
        /// <param name="title">ToolTip 제목</param>
        /// <param name="contents">내용</param>
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
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: OnKeyDown :: Enter Key를 입력하면 조회 이벤트를 실행합니다.

        /// <summary>
        /// Enter Key를 입력하면 조회 이벤트를 실행합니다.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (!EnterKeySelectEvent || e.KeyCode != Keys.Enter) return;

            (FindForm() as IRaiseEvent).RaiseSelectEvent();
        }

        ///// <summary>
        ///// 
        ///// </summary>
        //protected override void OnEditValueChanged()
        //{
        //    base.OnEditValueChanged();

        //    if (AutoSelectLength == 0 || TrimText.Length < AutoSelectLength) return;

        //    (FindForm() as IRaiseEvent).RaiseSelectEvent();
        //}

        #endregion

        #region :: OnLostFocus :: Focus를 잃을 때 수정된 내용이 있으면 MainFrame 에 표시합니다.

        /// <summary>
        /// Focus를 잃을 때 수정된 내용이 있으면 MainFrame 에 표시합니다.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            if (!CheckModified || !IsModified) return;

            (FindForm() as IFrameUI).ISMODIFIED = true;
        }

        #endregion
    }
}
