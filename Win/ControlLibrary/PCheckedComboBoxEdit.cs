using DevExpress.XtraLayout;
using DevExpress.Utils;
using EBAP.Core.Collections;
using EBAP.Core.Info;
using EBAP.Core.Interface;
using System;
using System.ComponentModel;
using System.Data;

namespace EBAP.Win.ControlLibrary
{
    /// <summary>
    /// CheckEdit 입니다.
    /// DevExpress Checked ComboBox Edit를 Wrapping 하여 사용합니다.
    /// </summary>
    /// <remarks>
    /// 2023-02-01 최초생성 : 오인봉
    /// 변경내역
    ///
    /// </remarks>
    [ToolboxItem(true)]
    public partial class PCheckedComboBoxEdit : DevExpress.XtraEditors.CheckedComboBoxEdit, IInitEditValue, ICheckModified, IDBParams, IInitData, IBindings, ILocaleCtrl, IMandatory, IValueChangeSelectEvent
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// Checked ComboBox Edit Control을 생성합니다.
        /// </summary>
        public PCheckedComboBoxEdit()
        {
            InitializeComponent();
        }

        #endregion

        #region :: 전역변수 ::


        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: SelectAllItemCaption :: '전체선택' Caption을 설정합니다.

        /// <summary>
        /// '전체선택' Caption을 설정합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue("전체선택"), Browsable(true)]
        [Description("'전체선택' Caption을 설정합니다.")]
        public string SelectAllItemCaption
        {
            get { return Properties.SelectAllItemCaption; }
            set { Properties.SelectAllItemCaption = value; }
        }

        #endregion

        #region :: SelectAllItemVisible :: '전체선택' 숨김/보임을 설정합니다.

        /// <summary>
        /// '전체선택' 숨김/보임을 설정합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(true), Browsable(true)]
        [Description("'전체선택' 숨김/보임을 설정합니다.")]
        public bool SelectAllItemVisible
        {
            get { return Properties.SelectAllItemVisible; }
            set { Properties.SelectAllItemVisible = value; }
        }

        #endregion

        #region :: EditText :: EditValue를 Text 형식으로 리턴합니다.

        /// <summary>
        /// EditValue를 Text 형식으로 리턴합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(""), Browsable(false)]
        [Description("EditValue를 Text 형식으로 리턴합니다.")]
        public string EditText
        {
            get { return EditValue == null ? "" : EditValue.ToString(); }
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
            this.RefreshEditValue();
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
                (Parent as LayoutControl).GetItemByControl(this).Text = (FindForm() as ILocaleConverter).LOCALECONVERTER.GetLocaleString(LocaleEnumClass);

            //if (AdvancedMode && Parent is LayoutControl && !(Parent as LayoutControl).GetItemByControl(this).TextVisible)
            //    Properties.AdvancedModeOptions.Label = (FindForm() as ILocaleConverter).LOCALECONVERTER.GetLocaleString(LocaleEnumClass);

            //if (Parent is LayoutControl)
            //    (Parent as LayoutControl).GetItemByControl(this).Text = (FindForm() as ILocaleConverter).LOCALECONVERTER.GetLocaleString(LocaleEnumClass);
        }

        #endregion

        #region IInitData 멤버

        /// <summary>
        /// DataSource를 초기화합니다.
        /// </summary>
        /// <param name="valueList">값으로 사용할 List</param>
        /// <param name="displayList">보여지는 값으로 사용할 List</param>
        public void InitData(object[] valueList, string[] displayList)
        {
            if (valueList.Length != displayList.Length)
                return;

            ILocaleConverter ui = FindForm() as ILocaleConverter;

            using (DataTable dt = new DataTable())
            {
                dt.Columns.Add(AppConfig.VALUEMEMBER);
                dt.Columns.Add(AppConfig.DISPLAYMEMBER);

                for (int idx = 0; idx < valueList.Length; idx++)
                {
                    DataRow dr = dt.NewRow();
                    dr[AppConfig.VALUEMEMBER] = valueList[idx];
                    dr[AppConfig.DISPLAYMEMBER] = ui == null ? displayList[idx] : ui.LOCALECONVERTER.GetLocaleString(displayList[idx]);
                    dt.Rows.Add(dr);
                }
                InitData(dt);
            }
        }

        /// <summary>
        /// DataSource를 초기화합니다.
        /// </summary>
        /// <param name="dt">DataSource</param>
        public void InitData(DataTable dt)
        {
            InitData(dt, AppConfig.VALUEMEMBER, AppConfig.DISPLAYMEMBER);
        }

        /// <summary>
        /// DataSource를 초기화합니다.
        /// </summary>
        /// <param name="dt">DataSource</param>
        /// <param name="valueMember">Value Member</param>
        /// <param name="displayMember">Display Member</param>
        public void InitData(DataTable dt, string valueMember, string displayMember)
        {
            Properties.DataSource = null;

            EditValue = "";
            //Properties.Items.Clear();

            Properties.DataSource = dt;
            Properties.ValueMember = valueMember;
            Properties.DisplayMember = displayMember;

            Refresh();
            RefreshEditValue();
            CalcBestSize();
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
            DataBindings.Add("EditValue", dt, dataMember, false, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, string.Empty);
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
        // Method(Private)
        ///////////////////////////////////////////////////////////////////////////////////////////////



        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: OnEditValueChanged :: EditValue가 변경되면 발생합니다.

        /// <summary>
        /// EditValue가 변경되면 발생합니다.
        /// </summary>
        protected override void OnEditValueChanged()
        {
            base.OnEditValueChanged();

            if (Properties.TextEditStyle == DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor)
                RefreshEditValue();

            //if (!ValueChangeSelectEvent || isKeyDown) return;
            //if (!ValueChangeSelectEvent) return;
            if (!ValueChangeSelectEvent || (FindForm() as IFrameUI).ISLOADING) return;

            (FindForm() as IRaiseEvent).RaiseSelectEvent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buttonInfo"></param>
        protected override void OnClickButton(DevExpress.XtraEditors.Drawing.EditorButtonObjectInfoArgs buttonInfo)
        {
            try
            {
                if (buttonInfo.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)
                {
                    EditValue = "";
                }
                else if (buttonInfo.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Search)
                {
                    ParamCollection param = new ParamCollection();

                    param.Add("VALUE", EditText.Replace(", ", ","));

                    string multiText = (FindForm() as IFrameUI).ExecutePopup("Multi Input", "EBAP.UI.ADM.dll", "EBAP.UI.ADM.Popup.PopMultiInput", param) as string;

                    if (multiText == null) return;

                    EditValue = multiText ?? "";
                }
                base.OnClickButton(buttonInfo);
            }
            catch
            {
                throw;
            }
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
