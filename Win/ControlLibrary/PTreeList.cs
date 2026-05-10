using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList.StyleFormatConditions;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using EBAP.Core.Info;
using EBAP.Core.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using DevExpress.XtraGrid;

namespace EBAP.Win.ControlLibrary
{
    /// <summary>
    /// TreeList 입니다.
    /// DevExpress TreeList를 Wrapping 하여 사용합니다.
    /// </summary>
    /// <remarks>
    /// 2023-02-01 최초생성 : 오인봉
    /// 변경내역
    /// 
    /// </remarks>
    [ToolboxItem(true)]
    public partial class PTreeList : DevExpress.XtraTreeList.TreeList, IFillData, IInitColumn, IExport, IPrint, ICancelEditRow
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// TreeList를 생성합니다.
        /// </summary>
        public PTreeList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// TreeList를 생성합니다.
        /// </summary>
        /// <param name="ignore"></param>
        protected PTreeList(object ignore)
            : base(ignore)
        {
            InitializeComponent();
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Interface 구현
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region IFillData 멤버

        /// <summary>
        /// GridControl의 데이터를 채웁니다.
        /// </summary>
        public void FillData()
        {
            DataSource = null;
        }

        /// <summary>
        /// GridControl의 데이터를 채웁니다.
        /// </summary>
        /// <param name="ds"></param>
        public void FillData(DataSet ds)
        {
            FillData(ds, ds.Tables[0].TableName);
        }

        /// <summary>
        /// GridControl의 데이터를 채웁니다.
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        public void FillData(DataSet ds, string tableName)
        {
            DataMember = string.Empty;

            DataSource = ds;
            DataMember = tableName;
        }

        #endregion

        #region IInitColumn 멤버

        /// <summary>
        /// Column을 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="caption">Column Header Text</param>
        public void InitColumn(string fieldName, string caption)
        {
            InitColumn(fieldName, caption, 75, 0, false, true, DataType.Default, HorzAlign.Near);
        }

        /// <summary>
        /// Grid Column을 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="caption">Column Header Text</param>
        /// <param name="width">Column 너비</param>
        public void InitColumn(string fieldName, string caption, int width)
        {
            InitColumn(fieldName, caption, width, 0, false, true, DataType.Default, HorzAlign.Near);
        }

        /// <summary>
        /// Grid Column을 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="caption">Column Header Text</param>
        /// <param name="width">Column 너비</param>
        /// <param name="maxLength">Data의 최대 길이, 0이면 설정 안 함</param>
        /// <param name="allowEdit">Column Cell 수정 여부</param>
        /// <param name="visible">Column 숨김/보임 여부</param>
        public void InitColumn(string fieldName, string caption, int width, int maxLength, bool allowEdit, bool visible)
        {
            InitColumn(fieldName, caption, width, maxLength, allowEdit, visible, DataType.Default, HorzAlign.Near);
        }

        /// <summary>
        /// Grid Column을 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="caption">Column Header Text</param>
        /// <param name="width">Column 너비</param>
        /// <param name="maxLength">Data의 최대 길이, 0이면 설정 안 함</param>
        /// <param name="allowEdit">Column Cell 수정 여부</param>
        /// <param name="visible">Column 숨김/보임 여부</param>
        /// <param name="dataType">Column DataType</param>
        public void InitColumn(string fieldName, string caption, int width, int maxLength, bool allowEdit, bool visible, DataType dataType)
        {
            InitColumn(fieldName, caption, width, maxLength, allowEdit, visible, dataType, HorzAlign.Near);
        }

        /// <summary>
        /// Grid Column을 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="caption">Column Header Text</param>
        /// <param name="width">Column 너비</param>
        /// <param name="maxLength">Data의 최대 길이, 0이면 설정 안 함</param>
        /// <param name="allowEdit">Column Cell 수정 여부</param>
        /// <param name="visible">Column 숨김/보임 여부</param>
        /// <param name="dataType">Column DataType</param>
        /// <param name="horzAlign">Column Cell 정렬</param>
        public void InitColumn(string fieldName, string caption, int width, int maxLength, bool allowEdit, bool visible, DataType dataType, HorzAlign horzAlign)
        {
            InitColumn(fieldName, caption, width, maxLength, 0, allowEdit, visible, dataType, horzAlign);
        }

        /// <summary>
        /// Grid Column을 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="caption">Column Header Text</param>
        /// <param name="width">Column 너비</param>
        /// <param name="maxLength">Data의 최대 길이, 0이면 설정 안 함</param>
        /// <param name="decimalPlace">소숫점 길이 수, 기본값 0</param>
        /// <param name="allowEdit">Column Cell 수정 여부</param>
        /// <param name="visible">Column 숨김/보임 여부</param>
        /// <param name="dataType">Column DataType</param>
        /// <param name="horzAlign">Column Cell 정렬</param>
        public void InitColumn(string fieldName, string caption, int width, int maxLength, int decimalPlace, bool allowEdit, bool visible, DataType dataType, HorzAlign horzAlign)
        {
            EBAP.Core.Localization.LocaleConverter locale = (FindForm() as ILocaleConverter).LOCALECONVERTER;

            if (locale == null) return;

            TreeListColumn column;

            bool existColumn = base.Columns[fieldName] == null ? false : true;

            column = existColumn ? base.Columns[fieldName] : new TreeListColumn();

            column.FieldName = fieldName;
            column.Caption = locale.GetLocaleString(caption);
            column.OptionsColumn.AllowEdit = allowEdit;

            column.Width = width;

            if (!existColumn) Columns.AddRange(new TreeListColumn[] { column });

            if (!existColumn) column.VisibleIndex = base.Columns.Count - 1;

            column.Visible = visible;

            ControlUtil.SetColumnType(column, dataType, maxLength, decimalPlace);

            if (column.ColumnEdit != null)
            {
                if (column.ColumnEdit.EditorTypeName == "CheckEdit")
                {
                    column.OptionsColumn.AllowSort = false;
                    column.OptionsColumn.FixedWidth = true;
                }
            }

            switch (horzAlign)
            {
                case HorzAlign.Default:
                    column.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Default;
                    break;
                case HorzAlign.Center:
                    column.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                    break;
                case HorzAlign.Far:
                    column.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                    break;
                case HorzAlign.Near:
                    column.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;
                    break;
            }
        }

        #endregion

        #region IExport 멤버

        /// <summary>
        /// Export를 비활성화 합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(false), Browsable(true)]
        [Description("Export를 비활성화 합니다.")]
        public bool DisableExport
        {
            get;
            set;
        }

        /// <summary>
        /// Excel로 Export 합니다.
        /// </summary>
        /// <param name="filePath"></param>
        public void ExportXlsx(string filePath)
        {
            DevExpress.Export.ExportSettings.DefaultExportType = DevExpress.Export.ExportType.WYSIWYG;

            DevExpress.XtraPrinting.XlsxExportOptions option = new DevExpress.XtraPrinting.XlsxExportOptions() { ExportHyperlinks = false };

            base.ExportToXlsx(filePath, option);
        }

        /// <summary>
        /// PDF로 Export 합니다.
        /// </summary>
        /// <param name="filePath"></param>
        public void ExportPdf(string filePath)
        {
            DevExpress.Export.ExportSettings.DefaultExportType = DevExpress.Export.ExportType.WYSIWYG;
            base.ExportToPdf(filePath);
        }

        #endregion

        #region IPrint 멤버

        /// <summary>
        /// 
        /// </summary>
        public void PrintPreview()
        {
            base.ShowRibbonPrintPreview();
        }

        #endregion

        #region ICancelEditRow 멤버

        /// <summary>
        /// 행 추가/수정을 취소합니다.
        /// </summary>
        public void CancelEditRow()
        {
            DataRow dr = GetFocusedDataRow();

            if (dr == null) return;

            if (dr.RowState == DataRowState.Modified)
            {
                dr.RejectChanges();
                RefreshEditor(true);
            }

            if (dr.RowState == DataRowState.Added)
            {
                DeleteNode(FocusedNode);
            }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: MandatoryColumns :: 필수입력항목 컬럼을 정의합니다.

        /// <summary>
        /// 필수입력항목 컬럼을 정의합니다.
        /// </summary>
        [Category("EBAP"), Browsable(true)]
        [Description("필수입력항목 컬럼을 정의합니다.")]
        public string[] MandatoryColumns
        {
            get;
            set;
        }

        #endregion

        #region :: EnableControlBinding :: Layout 저장 여부를 설정합니다.

        /// <summary>
        /// Layout 저장 여부를 설정합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(false), Browsable(true)]
        [Description("Layout 저장 여부를 설정합니다.")]
        public bool EnableControlBinding
        {
            get;
            set;
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: AddNewRow :: 새로운 Row를 추가합니다.

        /// <summary>
        /// 새로운 Row를 추가합니다.
        /// </summary>
        /// <param name="colName">컬럼명</param>
        /// <param name="pNode">부모노드</param>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void AddNewRow(string colName = "", TreeListNode pNode = null)
        {
            RaiseInitNewRow(AppendNode("", pNode), pNode);
            FocusedColumn = Columns[colName] ?? null;
            //FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle;
            ShowEditor();
        }

        #endregion

        #region :: AcceptChanges :: DataSource의 변경 내용을 COMMIT 합니다.

        /// <summary>
        /// DataSource의 변경 내용을 COMMIT 합니다.
        /// </summary>
        public void AcceptChanges()
        {
            GetDataTableByDataSource().AcceptChanges();
        }

        #endregion

        #region :: GetAddedModifedData :: Grid에서 추가 및 수정된 데이터를 가져옵니다.

        /// <summary>
        /// Grid에서 추가 및 수정된 데이터를 가져옵니다.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public DataTable GetAddedModifedData()
        {
            CloseEditor(true);
            //CheckValidateFocusNode();
            UpdateSelectNode();
            EndCurrentEdit();

            DataSet ds = DataSource is DataView ? (DataSource as DataView).DataViewManager.DataSet : DataSource as DataSet;

            if (ds == null) return null;

            DataTable dt = ds.Tables[DataMember].Clone();

            foreach (DataRow dr in ds.Tables[DataMember].Rows)
            {
                if (dr.RowState == DataRowState.Added || dr.RowState == DataRowState.Modified || dr.RowState == DataRowState.Detached)
                {
                    if (dr.Table.Columns.Contains(AppConfig.USERCOLUMNNAME))
                        dr[AppConfig.USERCOLUMNNAME] = (FindForm() as IFrameUI).CurrentUser.USERID;

                    if (dr.Table.Columns.Contains(AppConfig.DATECOLUMNNAME))
                        dr[AppConfig.DATECOLUMNNAME] = DateTime.Now;

                    dt.ImportRow(dr);
                }
            }

            return dt;
        }

        #endregion

        #region :: GetDataTableByDataSource :: DataSource를 DataTable로 반환합니다.

        /// <summary>
        /// DataSource를 DataTable로 반환합니다..
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public DataTable GetDataTableByDataSource()
        {
            CloseEditor(true);

            DataSet ds = DataSource is DataView ? (DataSource as DataView).DataViewManager.DataSet : DataSource as DataSet;

            if (ds == null) return null;

            return ds.Tables[DataMember] ?? null;
        }

        #endregion

        #region :: InitComboBoxColumn(+1 Overloading) :: ComboBoxColumn Data를 초기화합니다.

        /// <summary>
        /// ComboBoxColumn Data를 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="valueList">Value가 될 배열</param>
        /// <param name="displayList">Text가 될 배열</param>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void InitComboBoxColumn(string fieldName, object[] valueList, string[] displayList)
        {
            InitComboBoxColumn(fieldName, valueList, displayList, false, false);
        }

        /// <summary>
        /// ComboBoxColumn Data를 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="valueList">Value가 될 배열</param>
        /// <param name="displayList">Text가 될 배열</param>
        /// <param name="selectAllItemVisible">전체선택 숨김/보임</param>
        /// <param name="showCodeColumn">Code Column 숨김/보임</param>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void InitComboBoxColumn(string fieldName, object[] valueList, string[] displayList, bool selectAllItemVisible, bool showCodeColumn)
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
                    dr[AppConfig.VALUEMEMBER] = valueList[idx].ToString().Trim();
                    dr[AppConfig.DISPLAYMEMBER] = ui == null ? displayList[idx] : ui.LOCALECONVERTER.GetLocaleString(displayList[idx]);
                    dt.Rows.Add(dr);
                }
                InitComboBoxColumn(fieldName, dt, selectAllItemVisible, showCodeColumn, AppConfig.VALUEMEMBER, AppConfig.DISPLAYMEMBER);
            }
        }

        /// <summary>
        /// ComboBoxColumn Data를 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="dt">Datasource 가 될 DataTable</param>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void InitComboBoxColumn(string fieldName, DataTable dt)
        {
            InitComboBoxColumn(fieldName, dt, false, false, AppConfig.VALUEMEMBER, AppConfig.DISPLAYMEMBER);
        }

        /// <summary>
        /// ComboBoxColumn Data를 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="dt">Datasource 가 될 DataTable</param>
        /// <param name="selectAllItemVisible">전체선택 숨김/보임</param>
        /// <param name="showCodeColumn">Code Column 숨김/보임</param>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void InitComboBoxColumn(string fieldName, DataTable dt, bool selectAllItemVisible, bool showCodeColumn)
        {
            InitComboBoxColumn(fieldName, dt, selectAllItemVisible, showCodeColumn, AppConfig.VALUEMEMBER, AppConfig.DISPLAYMEMBER);
        }

        /// <summary>
        /// ComboBoxColumn Data를 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="dt">Datasource 가 될 DataTable</param>
        /// <param name="selectAllItemVisible">전체선택 숨김/보임</param>
        /// <param name="showCodeColumn">Code Column 숨김/보임</param>
        /// <param name="valueMember">ValueMember 명</param>
        /// <param name="displayMember">DisplayMemeber 명</param>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void InitComboBoxColumn(string fieldName, DataTable dt, bool selectAllItemVisible, bool showCodeColumn, string valueMember, string displayMember)
        {
            TreeListColumn column = Columns[fieldName];

            if (column == null) return;

            RepositoryItemLookUpEdit edit = new RepositoryItemLookUpEdit();

            DataRow dr;
            if (selectAllItemVisible)
            {
                dr = dt.NewRow();

                if (dt.Columns[valueMember].DataType == Type.GetType("System.String"))
                    dr[valueMember] = "";
                else
                    dr[valueMember] = -1;

                dr[displayMember] = "전체";
                dt.Rows.InsertAt(dr, 0);
            }

            edit.Appearance.Font = ControlConfig.DEFAULTFONT;
            edit.NullText = "";
            edit.DataSource = dt;
            edit.ValueMember = valueMember;
            edit.DisplayMember = displayMember;
            //string[] columns = dt.GetColumnsFromDataTable();
            //Array.ForEach(columns, column =>
            //{
            //    edit.Columns.Add(column == valueMember ? CreateColumn(column, column, 70, HorzAlignment.Center, showCodeColumnVisible) : CreateColumn(column, column, 120, HorzAlignment.Default, true));
            //});

            edit.Columns.Add(ControlUtil.CreateLookUpColumn(valueMember, valueMember, 70, HorzAlignment.Center, showCodeColumn));
            edit.Columns.Add(ControlUtil.CreateLookUpColumn(displayMember, displayMember, 120, HorzAlignment.Default, true));

            edit.ShowHeader = false;
            edit.TextEditStyle = TextEditStyles.DisableTextEditor;
            column.ColumnEdit = edit;
        }

        #endregion

        #region :: SetStyleFormat(+4 Overloading) :: Grid Column의 Style을 설정합니다.

        /// <summary>
        /// Grid Column의 Style을 설정합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="backColor">설정할 Back Color</param>
        /// <param name="formatCondition">Format Condition</param>
        /// <param name="value1">비교값1</param>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void SetStyleFormat(string fieldName, Color backColor, FormatConditionEnum formatCondition, object value1)
        {
            SetStyleFormat(fieldName, backColor, Appearance.Row.ForeColor, formatCondition, value1, null);
        }

        /// <summary>
        /// Grid Column의 Style을 설정합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="backColor">설정할 Back Color</param>
        /// <param name="formatCondition">Format Condition</param>
        /// <param name="value1">비교값1</param>
        /// <param name="applyToRow">Row에 색을 표시할지를 설정합니다.</param>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void SetStyleFormat(string fieldName, Color backColor, FormatConditionEnum formatCondition, object value1, bool applyToRow)
        {
            SetStyleFormat(fieldName, backColor, Appearance.Row.ForeColor, formatCondition, value1, null, applyToRow);
        }

        /// <summary>
        /// Grid Column의 Style을 설정합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="backColor">설정할 Back Color</param>
        /// <param name="value1">비교값1</param>
        /// <param name="value2">비교값2</param>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void SetStyleFormat(string fieldName, Color backColor, object value1, object value2)
        {
            SetStyleFormat(fieldName, backColor, Appearance.Row.ForeColor, FormatConditionEnum.Between, value1, value2);
        }

        /// <summary>
        /// Grid Column의 Style을 설정합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="backColor">설정할 Back Color</param>
        /// <param name="foreColor">설정할 Fore Color</param>
        /// <param name="formatCondition">Format Condition</param>
        /// <param name="value1">비교값1</param>
        /// <param name="value2">비교값2</param>
        /// <param name="applyToRow">Row에 색을 표시할지를 설정합니다.</param>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void SetStyleFormat(string fieldName, Color backColor, Color foreColor, FormatConditionEnum formatCondition, object value1, object value2, bool applyToRow = false)
        {
            TreeListColumn column = Columns[fieldName];

            DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition sfc = new DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition();
            sfc.Appearance.BackColor = backColor;
            sfc.Appearance.ForeColor = foreColor;

            sfc.Appearance.Options.UseBackColor = true;
            sfc.Appearance.Options.UseForeColor = true;
            
            sfc.Column = column;
            sfc.ApplyToRow = applyToRow;
            sfc.Condition = formatCondition;
            sfc.Value1 = value1;
            sfc.Value2 = value2;

            FormatConditions.Add(sfc);
        }

        #endregion

        #region :: SetStyleFormatExpression :: Expression으로 Grid Column의 Style을 설정합니다.

        /// <summary>
        /// Expression으로 Grid Column의 Style을 설정합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="backColor">설정할 Back Color</param>
        /// <param name="expression">Expression</param>
        /// <param name="applyToRow">Row에 색을 표시할지를 설정합니다.</param>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void SetStyleFormatExpression(string fieldName, Color backColor, string expression, bool applyToRow = false)
        {
            SetStyleFormatExpression(fieldName, backColor, Appearance.Row.ForeColor, expression, applyToRow);
        }

        /// <summary>
        /// Expression으로 Grid Column의 Style을 설정합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="backColor">설정할 Back Color</param>
        /// <param name="foreColor">설정할 Fore Color</param>
        /// <param name="expression">Expression</param>
        /// <param name="applyToRow">Row에 색을 표시할지를 설정합니다.</param>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void SetStyleFormatExpression(string fieldName, Color backColor, Color foreColor, string expression, bool applyToRow = false)
        {
            TreeListColumn column = Columns[fieldName];

            DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition sfc = new DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition(FormatConditionEnum.Expression);
            sfc.Appearance.BackColor = backColor;
            sfc.Appearance.ForeColor = foreColor;

            sfc.Appearance.Options.UseBackColor = true;
            sfc.Appearance.Options.UseForeColor = true;
            sfc.Appearance.Options.HighPriority = false;

            sfc.Column = column;
            sfc.ApplyToRow = applyToRow;

            sfc.Expression = expression;

            FormatConditions.Add(sfc);
        }

        /// <summary>
        /// Expression으로 Grid Column의 Style을 설정합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="foreColor">설정할 Fore Color</param>
        /// <param name="expression">Expression</param>
        /// <param name="applyToRow">Row에 색을 표시할지를 설정합니다.</param>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void SetStyleFormatExpressionForeColor(string fieldName, Color foreColor, string expression, bool applyToRow)
        {
            TreeListColumn column = Columns[fieldName];

            DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition sfc = new DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition(FormatConditionEnum.Expression);
            //sfc.Appearance.Font = ControlConfig.DEFAULTFONT;
            sfc.Appearance.ForeColor = foreColor;

            sfc.Appearance.Options.UseForeColor = true;
            //sfc.Appearance.Options.UseFont = true;
            //sfc.Appearance.Options.HighPriority = false;

            sfc.Column = column;
            sfc.ApplyToRow = applyToRow;

            sfc.Expression = expression;

            FormatConditions.Add(sfc);
        }

        /// <summary>
        /// Expression으로 Grid Column의 Style을 설정합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="backColor">설정할 Back Color</param>
        /// <param name="expression">Expression</param>
        /// <param name="applyToRow">Row에 색을 표시할지를 설정합니다.</param>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void SetStyleFormatExpressionBackColor(string fieldName, Color backColor, string expression, bool applyToRow)
        {
            TreeListColumn column = Columns[fieldName];

            DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition sfc = new DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition(FormatConditionEnum.Expression);
            //sfc.Appearance.Font = ControlConfig.DEFAULTFONT;
            sfc.Appearance.BackColor = backColor;

            sfc.Appearance.Options.UseBackColor = true;
            //sfc.Appearance.Options.UseFont = true;
            sfc.Appearance.Options.HighPriority = false;

            sfc.Column = column;
            sfc.ApplyToRow = applyToRow;

            sfc.Expression = expression;

            FormatConditions.Add(sfc);
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: RaiseCustomDrawNodeCell :: Cell이 추가/수정/삭제 되면 Color를 변경합니다.


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PTreeList_CustomDrawColumnHeader(object sender, DevExpress.XtraTreeList.CustomDrawColumnHeaderEventArgs e)
        {
            try
            {
                if (e.Column == null) return;

                e.DefaultDraw();
                e.Info.IsDrawOnGlass = true;

                e.Cache.FillRectangle(e.Cache.GetSolidBrush(ControlConfig.HEADERBACKCOLOR), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1));
                e.Appearance.DrawString(e.Cache, e.Info.Caption, e.Info.CaptionRect, e.Cache.GetSolidBrush(ControlConfig.HEADERFORECOLOR));

                e.Handled = true;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Cell이 추가/수정/삭제 되면 Color를 변경합니다.
        /// </summary>
        /// <param name="e"></param>
        protected override void RaiseCustomDrawNodeCell(DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
            DataRowView drv = base.GetDataRecordByNode(e.Node) as DataRowView;

            if (drv != null)
            {
                switch (drv.Row.RowState)
                {
                    case DataRowState.Added:
                        e.Appearance.ForeColor = ControlConfig.ADDEDROWCOLOR;
                        e.Appearance.Font = ControlConfig.BOLDFONT;
                        //e.Appearance.BackColor = DXSystemColors.Info;
                        break;
                    case DataRowState.Modified:
                        e.Appearance.ForeColor = ControlConfig.MODIFIEDROWCOLOR;
                        e.Appearance.Font = ControlConfig.ITALICFONT;
                        break;
                    default:
                        break;
                }
            }
            base.RaiseCustomDrawNodeCell(e);
        }

        #endregion

        #region :: RaiseInvalidNodeException :: 예외가 발생하면 Message를 표시하지 않습니다.

        /// <summary>
        /// 예외가 발생하면 Message를 표시하지 않습니다.
        /// </summary>
        /// <param name="ex"></param>
        protected override void RaiseInvalidNodeException(DevExpress.XtraTreeList.InvalidNodeExceptionEventArgs ex)
        {
            ex.ExceptionMode = ExceptionMode.NoAction;
            base.RaiseInvalidNodeException(ex);
        }

        #endregion

        #region :: RaiseValidateNode :: 신규 Node 의 필수 입력값을 강제로 정의합니다.

        /// <summary>
        /// 신규 Row의 필수 입력값을 강제로 정의합니다.
        /// </summary>
        /// <param name="e"></param>
        protected override void RaiseValidateNode(DevExpress.XtraTreeList.ValidateNodeEventArgs e)
        {
            if (MandatoryColumns == null) return;

            List<TreeListColumn> cList = new List<TreeListColumn>();

            if (e.Node != null)
            {
                foreach (string column in MandatoryColumns)
                {
                    if ((GetDataRecordByNode(e.Node) as DataRowView).Row[column].ToString() == string.Empty)
                        cList.Add(Columns[column]);
                }
            }

            if (cList.Count > 0)
            {
                const string message = "필수입력 항목입니다. 값을 입력 하세요.\r\n작업을 취소하려면 [ESC]를 눌러주세요";
                cList.ForEach(gc => SetColumnError(gc, message, DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning));
                e.Valid = false;
            }

            base.RaiseValidateNode(e);
        }

        #endregion

        #region :: RaiseFocusedNodeChanged :: Focused Node가 변경되면 BindingContext 의 Position을 변경합니다.

        /// <summary>
        /// Focused Node가 변경되면 BindingContext 의 Position을 변경합니다.
        /// </summary>
        /// <param name="oldNode"></param>
        /// <param name="newNode"></param>
        protected override void RaiseFocusedNodeChanged(TreeListNode oldNode, TreeListNode newNode)
        {
            base.RaiseFocusedNodeChanged(oldNode, newNode);

            DataRowView dr = GetDataRecordByNode(newNode) as DataRowView;

            if (dr == null || !EnableControlBinding) return;

            if (GetDataTableByDataSource() == null) return;

            (FindForm()).BindingContext[GetDataTableByDataSource()].Position = newNode.Id;
        }

        #endregion

        #region :: OnColumnChanged :: 컬럼이 변경되면 수정 여부에 따라 Header 모양을 변경합니다.

        /// <summary>
        /// 컬럼이 변경되면 수정 여부에 따라 Header 모양을 변경합니다.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="notifyOwner"></param>
        protected override void OnColumnChanged(TreeListColumn column, bool notifyOwner = true)
        {
            base.OnColumnChanged(column, notifyOwner);

            if (column == null) return;

            column.AppearanceHeader.Options.UseFont = true;

            if (column.OptionsColumn.AllowEdit && AppConfig.CHECKCOLUMNNAME != column.FieldName)
                column.AppearanceHeader.FontStyleDelta = FontStyle.Bold;
            else
                column.AppearanceHeader.FontStyleDelta = FontStyle.Regular;
        }

        #endregion
    }
}
