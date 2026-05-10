using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using EBAP.Core.Interface;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace EBAP.Win.ControlLibrary
{
    /// <summary>
    /// DateEdit 입니다.
    /// DevExpress DateEdit를 Wrapping 하여 사용합니다.
    /// </summary>
    /// <remarks>
    /// 2023-02-01 최초생성 : 오인봉
    /// 변경내역
    ///
    /// </remarks>
    [ToolboxItem(true)]
    public partial class PDateEdit : DevExpress.XtraEditors.DateEdit, IInitEditValue, ICheckModified, IDBParams, ILocaleCtrl, IBindings, IValueChangeSelectEvent, IMandatory
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// Date Edit Control을 생성합니다.
        /// </summary>
        public PDateEdit()
        {
            InitializeComponent();
        }

        #endregion

        #region :: 전역변수 ::

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: ToDateControl :: 종료일 Control을 지정합니다.

        /// <summary>
        /// 일괄 초기화 여부를 설정합니다.
        /// </summary>
        [Category("EBAP"), Browsable(true)]
        [Description("To Date를 설정합니다.")]
        public Control ToDateControl
        {
            get;
            set;
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
            this.EditValue = DateTime.Now;
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
            return this.EditValue;
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
            {
                if ((Parent as LayoutControl).GetItemByControl(this).Text == "~") return;

                (Parent as LayoutControl).GetItemByControl(this).Text = (FindForm() as ILocaleConverter).LOCALECONVERTER.GetLocaleString(LocaleEnumClass);
            }
            
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
            DataBindings.Add("EditValue", dt, dataMember, false, DataSourceUpdateMode.OnPropertyChanged, System.DateTime.Now);
        }

        #endregion

        #region IValueChangeSelectEvent 멤버

        private bool _valuechangeselectevent = false;

        /// <summary>
        /// 선택 값이 변경 되었을때 조회이벤트 발생 여부를 설정합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(false), Browsable(true)]
        [Description("선택 값이 변경 되었을때 조회이벤트 발생 여부를 설정합니다.")]
        public bool ValueChangeSelectEvent
        {
            get { return _valuechangeselectevent; }
            set
            {
                _valuechangeselectevent = value;

                if (DesignMode) return;

                BorderStyle = value ? DevExpress.XtraEditors.Controls.BorderStyles.Simple : DevExpress.XtraEditors.Controls.BorderStyles.Default;
                Properties.Appearance.BorderColor = value ? ControlConfig.SELECTEVENTBORDERCOLOR : ControlConfig.EMPTYCOLOR;

                //BackColor = value ? ControlConfig.SELECTEVENTBACKCOLOR : ControlConfig.EMPTYCOLOR;
                //ForeColor = value ? ControlConfig.SELECTEVENTFORECOLOR : ControlConfig.EMPTYCOLOR;
            }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: PDateEdit_ParseEditValue :: EditValue를 변경합니다.

        /// <summary>
        /// EditValue를 변경합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PDateEdit_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (DesignMode || e.Value == null || e.Value.ToString() == "" || Properties.EditFormat.FormatString == "t") return;

            e.Handled = true;

            string txt = Convert.ToDateTime(e.Value).ToString(Properties.EditMask);

            e.Value = Convert.ToDateTime(txt);
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: OnLoaded :: Control이 Load 되면 현재 날짜로 설정합니다.

        /// <summary>
        /// Control이 Load 되면 현재 날짜로 설정합니다.
        /// </summary>
        protected override void OnLoaded()
        {
            base.OnLoaded();

            DateTime = DateTime.Now;
        }

        #endregion

        #region :: OnEditValueChanged :: 종료일 컨트롤이 지정됐을 경우 시작일이 종료일보다 크면 시작일을 종료일로 설정합니다.

        /// <summary>
        /// 종료일 컨트롤이 지정됐을 경우 시작일이 종료일보다 크면 시작일을 종료일로 설정합니다.
        /// </summary>
        protected override void OnEditValueChanged()
        {
            if (FindForm() == null || FindForm().MdiParent == null) return;

            base.OnEditValueChanged();

            if (ToDateControl != null)
            {
                DateEdit de = ToDateControl as DateEdit;

                if (DateTime > de.DateTime)
                    de.DateTime = DateTime;
            }

            if (DesignMode || !ValueChangeSelectEvent || Convert.ToDateTime(OldEditValue).ToString(Properties.EditMask) == Convert.ToDateTime(EditValue).ToString(Properties.EditMask)) return;

            (FindForm() as IRaiseEvent).RaiseSelectEvent();
        }

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
