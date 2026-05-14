using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
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
    /// SearchLookUpEdit Control
    /// </summary>
    [ToolboxItem(true)]
    public partial class PSearchComboBoxEdit : SearchLookUpEdit
        , IInitEditValue
        , ICheckModified
        , IDBParams
        , IInitData
        , IBindings
        , ILocaleCtrl
        , IValueChangeSelectEvent
        , IMandatory
    {
        #region :: 생성자 ::

        public PSearchComboBoxEdit()
        {
            InitializeComponent();

            PopupView.OptionsView.ShowGroupPanel = false;
            PopupView.OptionsView.ShowIndicator = false;
            PopupView.OptionsSelection.EnableAppearanceFocusedCell = false;
            PopupView.FocusRectStyle = DrawFocusRectStyle.RowFocus;

            Properties.PopupFilterMode = PopupFilterMode.Contains;
            Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;

            PopupView.OptionsFind.AlwaysVisible = true;
            PopupView.OptionsFind.FindNullPrompt = "검색";
            PopupView.OptionsFind.HighlightFindResults = true;
        }

        #endregion

        #region :: PopupView ::

        protected GridView PopupView
        {
            get
            {
                return Properties.View as GridView;
            }
        }

        #endregion

        #region :: SelectAllItemCaption ::

        [Category("EBAP"), DefaultValue("전체선택"), Browsable(true)]
        public string SelectAllItemCaption
        {
            get;
            set;
        } = "전체선택";

        #endregion

        #region :: SelectAllItemVisible ::

        [Category("EBAP"), DefaultValue(true), Browsable(true)]
        public bool SelectAllItemVisible
        {
            get;
            set;
        } = true;

        #endregion

        #region :: ShowCodeColumn ::

        [Category("EBAP"), DefaultValue(true), Browsable(true)]
        public bool ShowCodeColumn
        {
            get;
            set;
        } = true;

        #endregion

        #region :: ShowAllColumn ::

        [Category("EBAP"), DefaultValue(false), Browsable(true)]
        public bool ShowAllColumn
        {
            get;
            set;
        }

        #endregion

        #region :: EditText ::

        [Browsable(false)]
        public string EditText
        {
            get { return EditValue == null ? "" : EditValue.ToString(); }
        }

        #endregion

        #region :: IsInitEditValue ::

        [Category("EBAP"), DefaultValue(false), Browsable(true)]
        public bool IsInitEditValue
        {
            get;
            set;
        }

        public void InitEditValue()
        {
            EditValue = string.Empty;
        }

        #endregion

        #region :: CheckModified ::

        [Category("EBAP"), DefaultValue(false), Browsable(true)]
        public bool CheckModified
        {
            get;
            set;
        }

        #endregion

        #region :: ParamName ::

        [Category("EBAP"), DefaultValue(""), Browsable(true)]
        public string ParamName
        {
            get;
            set;
        }

        public object GetControlParamValue()
        {
            return EditValue;
        }

        #endregion

        #region :: Mandatory ::

        private bool _ismandatoryforsave = false;

        [Category("EBAP"), DefaultValue(false), Browsable(true)]
        public bool IsMandatoryForSave
        {
            get { return _ismandatoryforsave; }
            set
            {
                _ismandatoryforsave = value;

                if (DesignMode) return;

                BorderStyle = value
                    ? DevExpress.XtraEditors.Controls.BorderStyles.Simple
                    : DevExpress.XtraEditors.Controls.BorderStyles.Default;

                Properties.Appearance.BorderColor = value
                    ? ControlConfig.MANDATORYBORDERCOLOR
                    : ControlConfig.EMPTYCOLOR;
            }
        }

        private bool _ismandatoryforselect = false;

        [Category("EBAP"), DefaultValue(false), Browsable(true)]
        public bool IsMandatoryForSelect
        {
            get { return _ismandatoryforselect; }
            set
            {
                _ismandatoryforselect = value;

                if (DesignMode) return;

                BorderStyle = value
                    ? DevExpress.XtraEditors.Controls.BorderStyles.Simple
                    : DevExpress.XtraEditors.Controls.BorderStyles.Default;

                Properties.Appearance.BorderColor = value
                    ? ControlConfig.MANDATORYBORDERCOLOR
                    : ControlConfig.EMPTYCOLOR;
            }
        }

        #endregion

        #region :: Locale ::

        [Category("EBAP"), DefaultValue(""), Browsable(true)]
        public string LocaleEnumClass
        {
            get;
            set;
        }

        public void SetLocaleString()
        {
            if (Parent is LayoutControl)
            {
                (Parent as LayoutControl)
                    .GetItemByControl(this)
                    .Text = (FindForm() as ILocaleConverter)
                    .LOCALECONVERTER
                    .GetLocaleString(LocaleEnumClass);
            }
        }

        #endregion

        #region :: InitData ::

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

                    dr[AppConfig.DISPLAYMEMBER] =
                        (ui == null || ui.LOCALECONVERTER == null)
                        ? displayList[idx]
                        : ui.LOCALECONVERTER.GetLocaleString(displayList[idx]);

                    dt.Rows.Add(dr);
                }

                InitData(dt);
            }
        }

        public void InitData(DataTable dt)
        {
            InitData(dt, AppConfig.VALUEMEMBER, AppConfig.DISPLAYMEMBER);
        }

        public void InitData(DataTable dt, string valueMember, string displayMember)
        {
            Properties.DataSource = null;
            Properties.DisplayMember = string.Empty;
            Properties.ValueMember = string.Empty;

            PopupView.Columns.Clear();

            EditValue = "";

            DataRow dr;

            if (SelectAllItemVisible)
            {
                dr = dt.NewRow();

                if (dt.Columns[valueMember].DataType == typeof(string))
                    dr[valueMember] = "";
                else
                    dr[valueMember] = -1;

                dr[displayMember] = SelectAllItemCaption;

                dt.Rows.InsertAt(dr, 0);
            }

            Properties.DataSource = dt;
            Properties.ValueMember = valueMember;
            Properties.DisplayMember = displayMember;

            if (ShowAllColumn)
            {
                string[] columns = dt.GetColumnsFromDataTable();

                foreach (string column in columns)
                {
                    GridColumn gridColumn = PopupView.Columns.AddVisible(column);

                    gridColumn.Caption = column;
                    gridColumn.Visible = true;
                    gridColumn.Width = 100;
                }
            }
            else
            {
                GridColumn colCode = PopupView.Columns.AddVisible(valueMember);

                colCode.Caption = valueMember;
                colCode.Visible = ShowCodeColumn;
                colCode.Width = 80;

                GridColumn colName = PopupView.Columns.AddVisible(displayMember);

                colName.Caption = displayMember;
                colName.Visible = true;
                colName.Width = 150;
            }

            IsModified = dt.Rows.Count > 0;

            EditValue = dt.Rows.Count > 0
                ? dt.Rows[0][valueMember]
                : string.Empty;
        }

        #endregion

        #region :: Binding ::

        [Category("EBAP"), DefaultValue(""), Browsable(true)]
        public string BindingMember
        {
            get;
            set;
        }

        public void BindingMapping(DataTable dt, string dataMember)
        {
            DataBindings.Clear();

            DataBindings.Add(
                "EditValue",
                dt,
                dataMember,
                false,
                DataSourceUpdateMode.OnPropertyChanged,
                string.Empty
            );
        }

        #endregion

        #region :: ValueChangeSelectEvent ::

        private bool _valuechangeselectevent = false;

        [Category("EBAP"), DefaultValue(false), Browsable(true)]
        public bool ValueChangeSelectEvent
        {
            get { return _valuechangeselectevent; }
            set
            {
                _valuechangeselectevent = value;

                if (DesignMode) return;

                BorderStyle = value
                    ? DevExpress.XtraEditors.Controls.BorderStyles.Simple
                    : DevExpress.XtraEditors.Controls.BorderStyles.Default;

                Properties.Appearance.BorderColor = value
                    ? ControlConfig.SELECTEVENTBORDERCOLOR
                    : ControlConfig.EMPTYCOLOR;
            }
        }

        #endregion

        #region :: GetDataTableByDataSource ::

        public DataTable GetDataTableByDataSource()
        {
            return Properties.DataSource as DataTable;
        }

        #endregion

        #region :: GetDisplayText ::

        public string GetDisplayText()
        {
            DataRow dr = GetSelectedDataRow() as DataRow;

            if (dr == null)
                return string.Empty;

            return Convert.ToString(dr[Properties.DisplayMember]);
        }

        #endregion

        #region :: Override ::

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            if (!CheckModified || !IsModified)
                return;

            (FindForm() as IFrameUI).ISMODIFIED = true;
        }

        protected override void OnEditValueChanged()
        {
            Refresh();

            if (!IsModified ||
                (!SelectAllItemVisible &&
                (EditValue == null || EditText == "")))
                return;

            base.OnEditValueChanged();

            if (!ValueChangeSelectEvent ||
                (FindForm() as IFrameUI).ISLOADING)
                return;

            (FindForm() as IRaiseEvent).RaiseSelectEvent();
        }

        #endregion
    }
}