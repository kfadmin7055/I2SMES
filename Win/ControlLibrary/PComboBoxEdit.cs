using DevExpress.Utils;
using DevExpress.XtraLayout;
using EBAP.Core;
using EBAP.Core.Info;
using EBAP.Core.Interface;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace EBAP.Win.ControlLibrary
{
    /// <summary>
    /// ComboBox Edit 입니다.
    /// DevExpress LookUpEdit을 Wrapping 하여 사용합니다.
    /// </summary>
    /// <remarks>
    /// 2023-02-01 최초생성 : 오인봉
    /// 변경내역
    ///
    /// </remarks>
    [ToolboxItem(true)]
    public partial class PComboBoxEdit : DevExpress.XtraEditors.LookUpEdit, IInitEditValue, ICheckModified, IDBParams, IInitData, IBindings, ILocaleCtrl, IValueChangeSelectEvent, IMandatory
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// ComboBox Control을 생성합니다.
        /// </summary>
        public PComboBoxEdit()
        {
            InitializeComponent();
        }

        #endregion

        #region :: 전역변수 ::

        //private bool ISINIT = false;

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

        #region :: ShowCodeColumn :: Code Column 숨김/보임을 설정합니다.

        /// <summary>
        /// Code Column 숨김/보임을 설정합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(true), Browsable(true),]
        [Description("Code Column 숨김/보임을 설정합니다.")]
        public bool ShowCodeColumn
        {
            get;
            set;
        }

        #endregion

        #region :: ShowAllColumn :: DataSource의 전체 컬럼 숨김/보임을 설정합니다. False 일 경우 Value, Display 값만 보여줍니다.

        /// <summary>
        /// DataSource의 전체 컬럼을 숨김/보임 설정합니다. False 일 경우 Value, Display 값만 보여줍니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(false), Browsable(true)]
        [Description("DataSource의 전체 컬럼을 숨김/보임 설정합니다. False 일 경우 Value, Display 값만 보여줍니다.")]
        public bool ShowAllColumn
        {
            get;
            set;
        }

        #endregion

        #region :: EditText :: EditValue를 Text 형식으로 리턴합니다.

        /// <summary>
        /// EditValue를 Text 형식으로 리턴합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(true), Browsable(false)]
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
            return EditValue;
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
                    dr[AppConfig.DISPLAYMEMBER] = (ui == null || ui.LOCALECONVERTER == null) ? displayList[idx] : ui.LOCALECONVERTER.GetLocaleString(displayList[idx]);
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
            //ISINIT = true;

            Properties.Columns.Clear();
            EditValue = "";

            DataRow dr;

            if (SelectAllItemVisible)
            {
                dr = dt.NewRow();

                if (dt.Columns[valueMember].DataType == Type.GetType("System.String"))
                    dr[valueMember] = "";
                else
                    dr[valueMember] = -1;

                dr[displayMember] = SelectAllItemCaption;
                dt.Rows.InsertAt(dr, 0);
            }

            Properties.DataSource = dt;
            Properties.ValueMember = valueMember;
            Properties.DisplayMember = displayMember;
            Properties.ShowHeader = ShowAllColumn;

            //ShowCodeColumn = true;
            Properties.ShowLines = true;

            //Properties.DropDownItemHeight = 17;

            if (ShowAllColumn)
            {
                string[] columns = dt.GetColumnsFromDataTable();

                foreach (string column in columns)
                {
                    Properties.Columns.Add(ControlUtil.CreateLookUpColumn(column, column, 70, HorzAlignment.Default, true));
                }
            }
            else
            {
                Properties.Columns.Add(ControlUtil.CreateLookUpColumn(valueMember, valueMember, 70, HorzAlignment.Default, ShowCodeColumn));
                Properties.Columns.Add(ControlUtil.CreateLookUpColumn(displayMember, displayMember, 120, HorzAlignment.Default, true));
            }

            IsModified = dt.Rows.Count > 0 ? true : false;

            EditValue = dt.Rows.Count > 0 ? dt.Rows[0][valueMember] : string.Empty;


            //ISINIT = false;
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
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: GetDataTableByDataSource :: DataSource를 DataTable로 반환합니다.

        /// <summary>
        /// DataSource를 DataTable로 반환합니다..
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public DataTable GetDataTableByDataSource()
        {
            DataTable dt = Properties.DataSource as DataTable;

            return dt ?? null;
        }

        #endregion

        #region :: GetDisplayText :: 현재 선택된 값의 텍스트를 가져옵니다.

        /// <summary>
        /// 현재 선택된 값의 텍스트를 가져옵니다.
        /// </summary>
        /// <returns></returns>
        public string GetDisplayText()
        {
            return GetColumnValue(Properties.DisplayMember).ToString();
        }

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: GetColumnValue :: 컬럼 값을 가져올때 NULL 이면 ""을 리턴 하도록 합니다.

        /// <summary>
        /// 컬럼 값을 가져올때 NULL 이면 "" 을 리턴 하도록 합니다.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public override object GetColumnValue(string fieldName)
        {
            if (base.GetColumnValue(fieldName) == null) return "";

            return base.GetColumnValue(fieldName);
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

        #region :: OnEditValueChanged :: 선택 값이 변경되면 조회 이벤트를 실행합니다.

        /// <summary>
        /// 선택 값이 변경되면 조회 이벤트를 실행합니다.
        /// </summary>
        protected override void OnEditValueChanged()
        {
            Refresh();
            //RefreshEditValue();

            if (!IsModified || (!SelectAllItemVisible && (EditValue == null || EditText == ""))) return;

            base.OnEditValueChanged();

            //if (!ValueChangeSelectEvent || isKeyDown) return;
            if (!ValueChangeSelectEvent || (FindForm() as IFrameUI).ISLOADING) return;
            //if (!ValueChangeSelectEvent) return;

            //if (FindForm() is UIFrame_MES)
            //    if ((FindForm() as UIFrame_MES).ISLOADING) return;

            //if(FindForm() is PopupFrame)
            //    if ((FindForm() as PopupFrame).ISLOADING) return;


            (FindForm() as IRaiseEvent).RaiseSelectEvent();
        }

        #endregion
    }
}
