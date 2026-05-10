using DevExpress.Utils;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraLayout;
using EBAP.Core.Collections;
using EBAP.Core.Interface;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

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
    public partial class PButtonEdit : DevExpress.XtraEditors.ButtonEdit, IInitEditValue, IDBParams, IEnterKeySelectEvent, IBindings, ILocaleCtrl, IMandatory, ICheckModified
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// SimpleButton Control을 생성합니다.
        /// </summary>
        public PButtonEdit()
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
            this.EditValue = string.Empty;
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
            return this.TrimText;
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

        #region :: EnterKeyClickEvent :: 엔터키를 눌렀을 때 클릭이벤트 발생 여부를 설정합니다.

        /// <summary>
        /// 엔터키를 눌렀을 때 팝업이벤트 발생 여부를 설정합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(false), Browsable(true)]
        [Description("엔터키를 눌렀을 때 클릭이벤트 발생 여부를 설정합니다.")]
        public bool EnterKeyClickEvent
        {
            get;
            set;
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
            DataBindings.Add("EditValue", dt, dataMember, false, DataSourceUpdateMode.OnPropertyChanged, string.Empty);
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: ButtonType :: 버튼의 타입을 설정합니다.

        private bool _viewDeleteButton = false;
        /// <summary>
        /// 버튼의 타입을 설정합니다.
        /// </summary>
        [Category("EBAP")]
        [Description("버튼의 타입을 설정합니다."), Browsable(true)]
        public bool ViewDeleteButton
        {
            get { return _viewDeleteButton; }
            set
            {
                _viewDeleteButton = value;

                if (Properties.Buttons.Count == 1) return;

                Properties.Buttons[1].Visible = _viewDeleteButton;
            }
        }

        #endregion

        #region :: PairButtonEdit :: 페어 Button을 설정합니다.

        /// <summary>
        /// 세트 Button을 설정합니다.
        /// </summary>
        [Category("EBAP"), Browsable(true)]
        [Description("페어 Button을 설정합니다.")]
        public PButtonEdit PairButtonEdit
        {
            get;
            set;
        }

        #endregion

        #region :: IsMultiInput :: 멀티 INPUT 타입을 설정합니다.

        /// <summary>
        /// 멀티 INPUT 타입을 설정합니다.
        /// </summary>
        [Category("EBAP"), Browsable(true)]
        [Description("멀티 INPUT 타입을 설정합니다.")]
        public bool IsMultiInput
        {
            get;
            set;
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
            get { return EditValue == null ? "" : EditValue.ToString().Trim(); }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Override)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: OnKeyDown :: Enter Key를 입력하면 조회 이벤트를 실행합니다.

        /// <summary>
        /// Enter Key를 입력하면 조회 이벤트를 실행합니다.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode != Keys.Enter) return;

            if (EnterKeyClickEvent)
            {
                AppearanceObject apprence = new AppearanceObject();

                EditorButtonObjectInfoArgs buttonInfo = new EditorButtonObjectInfoArgs(Properties.Buttons[0], apprence);
                OnClickButton(buttonInfo);
            }

            if (!EnterKeySelectEvent || EditValue == null) return;

            (FindForm() as IRaiseEvent).RaiseSelectEvent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buttonInfo"></param>
        protected override void OnClickButton(EditorButtonObjectInfoArgs buttonInfo)
        {
            try
            {
                if (buttonInfo.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)
                {
                    EditValue = "";
                    if (PairButtonEdit == null) return;

                    (PairButtonEdit as PButtonEdit).EditValue = "";

                    return;
                }
                if (IsMultiInput)
                {
                    ParamCollection param = new ParamCollection();

                    param.Add("VALUE", Text);

                    string multiText = (FindForm() as IFrameUI).ExecutePopup("Multi Input", "EBAP.UI.ADM.dll", "EBAP.UI.ADM.Popup.PopMultiInput", param) as string;

                    if (multiText == null) return;

                    EditValue = multiText ?? "";
                }
                base.OnClickButton(buttonInfo);

                if (!EnterKeySelectEvent) return;

                (FindForm() as IRaiseEvent).RaiseSelectEvent();
            }
            catch
            {
                throw;
            }
        }

        #endregion
    }
}
