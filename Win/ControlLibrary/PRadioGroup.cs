using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout;
using EBAP.Core.Info;
using EBAP.Core.Interface;
using System;
using System.ComponentModel;
using System.Data;

namespace EBAP.Win.ControlLibrary
{
    /// <summary>
    /// Radio Group 입니다.
    /// DevExpress PRadioGroup을 Wrapping 하여 사용합니다.
    /// </summary>
    /// <remarks>
    /// 2023-02-01 최초생성 : 오인봉
    /// 변경내역
    /// 
    /// </remarks>
    [ToolboxItem(true)]
    public partial class PRadioGroup : DevExpress.XtraEditors.RadioGroup, IInitEditValue, ICheckModified, IDBParams, IInitData, ILocaleCtrl, IMandatory, IValueChangeSelectEvent
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// RadioGroup Control을 생성합니다.
        /// </summary>
        public PRadioGroup()
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
            get;
            set;
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
            get;
            set;
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
            this.EditValue = string.Empty;
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
            if (Parent is LayoutControl)
                (Parent as LayoutControl).GetItemByControl(this).Text = (FindForm() as ILocaleConverter).LOCALECONVERTER.GetLocaleString(LocaleEnumClass);
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
            Properties.Items.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                RadioGroupItem rgi = new RadioGroupItem { Value = dr[valueMember], Description = dr[displayMember].ToString() };
                Properties.Items.Add(rgi);
            }

            if (SelectAllItemVisible)
            {
                RadioGroupItem rgi = new RadioGroupItem { Value = "", Description = SelectAllItemCaption };
                Properties.Items.Insert(0, rgi);
            }

            SelectedIndex = Properties.Items.Count > 0 ? 0 : -1;
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
        // Method(public)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: GetDisplayText :: 선택된 텍스트를 가져옵니다.

        /// <summary>
        /// 선택된 텍스트를 가져옵니다.
        /// </summary>
        /// <returns></returns>
        public string GetDisplayText()
        {
            return Properties.Items[SelectedIndex].Description;
        }

        #endregion

        #region :: SetItemEnable :: 아이템의 Enable을 설정합니다.

        /// <summary>
        /// 아이템의 Enable을 설정합니다.
        /// </summary>
        /// <param name="enabled"></param>
        /// <param name="idxs"></param>
        public void SetItemEnable(bool enabled, params int[] idxs)
        {
            foreach (int idx in idxs)
            {
                Properties.Items[idx].Enabled = enabled;
            }
        }

        /// <summary>
        /// 아이템의 Enable을 설정합니다.
        /// </summary>
        /// <param name="enabled"></param>
        /// <param name="values"></param>
        public void SetItemEnable(bool enabled, params string[] values)
        {
            foreach (RadioGroupItem rgi in Properties.Items)
            {
                foreach (string value in values)
                {
                    if (rgi.Value.ToString() == value)
                        rgi.Enabled = enabled;
                }
            }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: OnLostFocus :: Focus를 잃을 때 현재값과 이전값을 비교한다.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            if (!CheckModified || !IsModified) return;

            (FindForm() as IFrameUI).ISMODIFIED = true;
        }

        #endregion

        #region :: OnEditValueChanged :: 선택 값이 변경되면 조회 이벤트를 실행합니다.

        /// <summary>
        /// 선택 값이 변경되면 조회 이벤트를 실행합니다.
        /// </summary>
        protected override void OnEditValueChanged()
        {
            base.OnEditValueChanged();

            //if (!ValueChangeSelectEvent || isKeyDown) return;
            //if (!ValueChangeSelectEvent) return;
            if (!ValueChangeSelectEvent || (FindForm() as IFrameUI).ISLOADING) return;

            (FindForm() as IRaiseEvent).RaiseSelectEvent();
        }

        #endregion
    }
}