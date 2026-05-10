using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraPrinting;
using EBAP.Core.Info;
using EBAP.Core.Interface;
using EBAP.Win.ControlLibrary.GridMenu;
using EBAP.Win.ControlLibrary.Repository;
using EBAP.Win.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace EBAP.Win.ControlLibrary
{
    /// <summary>
    ///
    /// </summary>
    public partial class PBandedGridView : DevExpress.XtraGrid.Views.BandedGrid.BandedGridView, IFillData, IInitBandedColumn
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자(+1 Overloading) ::

        /// <summary>
        /// 
        /// </summary>
        public PBandedGridView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grid"></param>
        public PBandedGridView(DevExpress.XtraGrid.GridControl grid)
            : base(grid)
        {
            InitializeComponent();
        }

        #endregion

        #region :: 전역변수 ::

        private int prevRowIndex = -1;
        private int prevFocusedRowIndex = -1;

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
            (GridControl as PGridControl).FillData();
        }

        /// <summary>
        /// GridControl의 데이터를 채웁니다.
        /// </summary>
        /// <param name="ds"></param>
        public void FillData(DataSet ds)
        {
            (GridControl as PGridControl).FillData(ds);
        }

        /// <summary>
        /// GridControl의 데이터를 채웁니다.
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        public void FillData(DataSet ds, string tableName)
        {
            (GridControl as PGridControl).FillData(ds, tableName);
        }

        #endregion

        #region IInitBandedColumn 멤버

        /// <summary>
        /// Grid Band를 초기화합니다.
        /// </summary>
        /// <param name="name">Band 명</param>
        /// <param name="caption">Band Header Text</param>
        public void InitBand(string name, string caption)
        {
            InitBand(name, caption, 2);
        }

        /// <summary>
        /// Grid Band를 초기화합니다.
        /// </summary>
        /// <param name="name">Band 명</param>
        /// <param name="caption">Band Header Text</param>
        /// <param name="rowCount">Header 로우 수</param>
        public void InitBand(string name, string caption, int rowCount)
        {
            EBAP.Core.Localization.LocaleConverter locale = (GridControl.FindForm() as ILocaleConverter).LOCALECONVERTER;

            if (locale == null) return;

            GridBand gBand;
            
            bool existBand = base.Bands[name] == null ? false : true;

            gBand = existBand ? base.Bands[name] : new GridBand();

            gBand.Name = name;
            gBand.Caption = locale.GetLocaleString(caption);

            gBand.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            gBand.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;
            gBand.AppearanceHeader.Options.UseTextOptions = true;
            gBand.AutoFillDown = true;

            if (!existBand) Bands.Add(gBand);
        }

        /// <summary>
        /// Grid Column을 초기화합니다.
        /// </summary>
        /// <param name="bandName">Band 명</param>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="caption">Column Header Text</param>
        public void InitBandedColumn(string bandName, string fieldName, string caption)
        {
            InitBandedColumn(bandName, fieldName, caption, 75, 0, false, true, DataType.Default, HorzAlign.Near);
        }

        /// <summary>
        /// Grid Column을 초기화합니다.
        /// </summary>
        /// <param name="bandName">Band 명</param>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="caption">Column Header Text</param>
        /// <param name="width">Column 너비</param>
        public void InitBandedColumn(string bandName, string fieldName, string caption, int width)
        {
            InitBandedColumn(bandName, fieldName, caption, width, 0, false, true, DataType.Default, HorzAlign.Near);
        }

        /// <summary>
        /// Grid Column을 초기화합니다.
        /// </summary>
        /// <param name="bandName">Band 명</param>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="caption">Column Header Text</param>
        /// <param name="width">Column 너비</param>
        /// <param name="maxLength">Data의 최대 길이, 0이면 설정 안 함</param>
        /// <param name="allowEdit">Column Cell 수정 여부</param>
        /// <param name="visible">Column 숨김/보임 여부</param>
        public void InitBandedColumn(string bandName, string fieldName, string caption, int width, int maxLength, bool allowEdit, bool visible)
        {
            InitBandedColumn(bandName, fieldName, caption, width, maxLength, allowEdit, visible, DataType.Default, HorzAlign.Near);
        }

        /// <summary>
        /// Grid Column을 초기화합니다.
        /// </summary>
        /// <param name="bandName">Band 명</param>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="caption">Column Header Text</param>
        /// <param name="width">Column 너비</param>
        /// <param name="maxLength">Data의 최대 길이, 0이면 설정 안 함</param>
        /// <param name="allowEdit">Column Cell 수정 여부</param>
        /// <param name="visible">Column 숨김/보임 여부</param>
        /// <param name="dataType">Column DataType</param>
        public void InitBandedColumn(string bandName, string fieldName, string caption, int width, int maxLength, bool allowEdit, bool visible, DataType dataType)
        {
            InitBandedColumn(bandName, fieldName, caption, width, maxLength, allowEdit, visible, dataType, HorzAlign.Near);
        }

        /// <summary>
        /// Grid Column을 초기화합니다.
        /// </summary>
        /// <param name="bandName">Band 명</param>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="caption">Column Header Text</param>
        /// <param name="width">Column 너비</param>
        /// <param name="maxLength">Data의 최대 길이, 0이면 설정 안 함</param>
        /// <param name="allowEdit">Column Cell 수정 여부</param>
        /// <param name="visible">Column 숨김/보임 여부</param>
        /// <param name="dataType">Column DataType</param>
        /// <param name="horzAlign">Column Cell 정렬</param>
        public void InitBandedColumn(string bandName, string fieldName, string caption, int width, int maxLength, bool allowEdit, bool visible, DataType dataType, HorzAlign horzAlign)
        {
            InitBandedColumn(bandName, fieldName, caption, width, maxLength, 0, allowEdit, visible, dataType, horzAlign);
        }

        /// <summary>
        /// Grid Column을 초기화합니다.
        /// </summary>
        /// <param name="bandName">Band 명</param>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="caption">Column Header Text</param>
        /// <param name="width">Column 너비</param>
        /// <param name="maxLength">Data의 최대 길이, 0이면 설정 안 함</param>
        /// <param name="decimalPlace">소숫점 길이 수, 기본값 0</param>
        /// <param name="allowEdit">Column Cell 수정 여부</param>
        /// <param name="visible">Column 숨김/보임 여부</param>
        /// <param name="dataType">Column DataType</param>
        /// <param name="horzAlign">Column Cell 정렬</param>
        public void InitBandedColumn(string bandName, string fieldName, string caption, int width, int maxLength, int decimalPlace, bool allowEdit, bool visible, DataType dataType, HorzAlign horzAlign)
        {
            EBAP.Core.Localization.LocaleConverter locale = (GridControl.FindForm() as ILocaleConverter).LOCALECONVERTER;

            if (locale == null) return;

            GridBand gBand = Bands[bandName];

            BandedGridColumn gridColumn;

            bool existColumn = base.Columns[fieldName] == null ? false : true;

            gridColumn = existColumn ? base.Columns[fieldName] : new BandedGridColumn();

            gridColumn.FieldName = fieldName;
            gridColumn.Caption = locale.GetLocaleString(caption);
            gridColumn.OptionsColumn.AllowEdit = allowEdit;
            gridColumn.Width = width;
            gridColumn.AutoFillDown = true;

            if (!existColumn)
            {
                Columns.Add(gridColumn);
                gBand.Columns.Add(gridColumn);
            }

            gridColumn.Visible = visible;

            ControlUtil.SetColumnType(gridColumn, dataType, maxLength, decimalPlace);

            if (gridColumn.ColumnEdit is RepositoryItemMemoExEdit || gridColumn.ColumnEdit is RepositoryItemImageEdit)
            {
                gridColumn.OptionsColumn.AllowEdit = true;
                gridColumn.ColumnEdit.ReadOnly = !allowEdit;
            }

            if (dataType == DataType.Button || dataType == DataType.ButtonEdit || dataType == DataType.Popup)
            {
                if (dataType != DataType.Button) gridColumn.Caption += "...";
                (gridColumn.ColumnEdit as RepositoryItemButtonEdit).ButtonClick += (sender, e) =>
                {
                    if (ButtonEditClick == null) return;
                    CloseEditor(false);
                    ButtonEditClick(sender, e);
                };

                if (dataType == DataType.Popup || dataType == DataType.ButtonEdit)
                {
                    gridColumn.ColumnEdit.KeyDown += (sender, e) =>
                    {
                        if (e.KeyCode != Keys.Enter) return;
                        if (ButtonEditClick == null) return;

                        CloseEditor(false);

                        ButtonEditClick(sender, null);
                    };
                }
            }
            else if (dataType == DataType.CheckEdit)
            {
                gridColumn.OptionsColumn.AllowSort = DefaultBoolean.False;
                gridColumn.OptionsColumn.FixedWidth = true;
            }

            switch (horzAlign)
            {
                case HorzAlign.Default:
                    gridColumn.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Default;
                    break;
                case HorzAlign.Center:
                    gridColumn.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                    break;
                case HorzAlign.Far:
                    gridColumn.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                    break;
                case HorzAlign.Near:
                    gridColumn.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;
                    break;
            }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: EnableSaveLayout :: Layout 저장 여부를 설정합니다.

        /// <summary>
        /// Layout 저장 여부를 설정합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(false), Browsable(true)]
        [Description("Layout 저장 여부를 설정합니다.")]
        public bool EnableSaveLayout
        {
            get;
            set;
        }

        #endregion

        #region :: EnableControlBinding :: 컨트롤과 Binding 여부를 설정합니다.

        /// <summary>
        /// 컨트롤과 Binding 여부를 설정합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(false), Browsable(true)]
        [Description("컨트롤과 Binding 여부를 설정합니다.")]
        public bool EnableControlBinding
        {
            get;
            set;
        }

        #endregion

        #region :: KeyColumns :: Primary Key 컬럼을 정의합니다.

        /// <summary>
        /// Primary Key 컬럼을 정의합니다.
        /// </summary>
        [Category("EBAP"), Browsable(true)]
        [Description("Primary Key 컬럼을 정의합니다.")]
        public string[] KeyColumns
        {
            get;
            set;
        }


        #endregion

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

        #region :: NewRowEnableColumns :: 신규 Row의 Enable 컬럼을 설정합니다.

        /// <summary>
        /// 신규 Row의 Enable 컬럼을 설정합니다.
        /// </summary>
        [Category("EBAP"), Browsable(true)]
        [Description("신규 Row의 Enable 컬럼을 설정합니다.")]
        public string[] NewRowEnableColumns
        {
            get;
            set;
        }

        #endregion

        #region :: NewRowCopyColumns :: 신규 Row 생성 시 이전 컬럼의 값을 복사할 컬럼을 설정합니다.

        /// <summary>
        /// 신규 Row 생성 시 이전 컬럼의 값을 복사할 컬럼을 설정합니다.
        /// </summary>
        [Category("EBAP"), Browsable(true)]
        [Description("신규 Row 생성 시 이전 컬럼의 값을 복사할 컬럼을 설정합니다.")]
        public string[] NewRowCopyColumns
        {
            get;
            set;
        }

        #endregion

        #region :: ButtonEditClick :: Button Edit의 Button 클릭 시에 사용합니다.

        /// <summary>
        /// Button Edit의 Button 클릭 시에 사용합니다.
        /// </summary>
        [Category("EBAP"),
        Browsable(true)]
        [Description("Button Edit의 Button 클릭 시에 사용합니다.")]
        public event ButtonPressedEventHandler ButtonEditClick;

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Custom Event Handler
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: PGridView_MouseDown :: 마우스 오른쪽 버튼을 누르면 ContextMenu를 보여줍니다.

        /// <summary>
        /// 마우스 오른쪽 버튼을 누르면 ContextMenu를 보여줍니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PBandedGridView_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle && IsMultiSelect)
            {
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hitiInfo = CalcHitInfo(e.Location);
                if (hitiInfo.HitTest == DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.Column)
                {
                    FocusedColumn = hitiInfo.Column;
                    SelectCells(0, FocusedColumn, RowCount - 1, FocusedColumn);
                }
            }
            if (e.Button == MouseButtons.Right && EnableSaveLayout)
                DoShowMenu(CalcHitInfo(new Point(e.X, e.Y)));
        }

        /// <summary>
        /// PGridViewColumnButtonMenu 를 보여줍니다.
        /// </summary>
        /// <param name="hi"></param>
        private void DoShowMenu(GridHitInfo hi)
        {
            if (hi.HitTest != GridHitTest.ColumnButton)
                return;

            DevExpress.XtraGrid.Menu.GridViewMenu menu = new PGridViewContextMenu(this);
            menu.Init(hi);
            menu.Show(hi.HitPoint);
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Internal)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: GetColumnFields :: Column Filed를 가져옵니다.

        /// <summary>
        /// Column Filed를 가져옵니다.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public string[] GetColumnField()
        {
            List<string> columnFileds = new List<string>();

            foreach (GridColumn column in Columns)
            {
                columnFileds.Add(column.FieldName);
            }

            return columnFileds.ToArray();
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: AddDataRow :: DataSource에 새로운 Row를 추가합니다.

        /// <summary>
        /// DataSource에 새로운 Row를 추가합니다.
        /// </summary>
        /// <param name="dr">추가할 DataRow</param>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void AddDataRow(DataRow dr)
        {
            DataSet ds = DataSource is DataView ? (DataSource as DataView).DataViewManager.DataSet : base.GridControl.DataSource as DataSet;

            if (ds == null) return;

            ds.Tables[0].Rows.Add(dr);
        }

        #endregion

        #region :: ClearStyleFormat :: 현재 View의 Style을 모두 제거합니다.

        /// <summary>
        /// 현재 View의 Style을 모두 제거합니다.
        /// </summary>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void ClearStyleFormat()
        {
            FormatConditions.Clear();
        }

        #endregion

        #region :: GetCheckedData :: 삭제할 데이터를 가져옵니다.

        /// <summary>
        /// Check 된 데이터를 가져옵니다.(CheckedColumn)
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public DataTable GetCheckedData()
        {
            return GetCheckedData(AppConfig.CHECKCOLUMNNAME, true);
        }

        /// <summary>
        /// Check 된 데이터를 가져옵니다.(CheckedColumn)
        /// </summary>
        /// <param name="columnName">CheckedColumn 컬럼명</param>
        /// <param name="isChecked">선택 여부</param>
        /// <returns></returns>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public DataTable GetCheckedData(string columnName, bool isChecked)
        {
            CloseEditor(true);

            DataSet ds = DataSource is DataView ? (DataSource as DataView).DataViewManager.DataSet : base.GridControl.DataSource as DataSet;

            UpdateCurrentRow();

            if (ds == null) return null;

            DataTable dt = ds.Tables[0].Clone();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr[columnName].Equals(isChecked))
                    dt.ImportRow(dr);
            }

            return dt;
        }

        #endregion

        #region :: GetColumnSummaryText :: SummaryText를 가져옵니다.

        /// <summary>
        /// SummaryText를 가져옵니다.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public string GetColumnSummaryText(string fieldName)
        {
            BandedGridColumn gridColumn = Columns[fieldName];

            if (gridColumn == null) return "";

            return gridColumn.SummaryText;
        }

        #endregion

        #region :: GetDataTableByColumnValue :: 컬럼의 데이터를 Check 하여 같은 값이 있는 Row를 Return합니다.

        /// <summary>
        /// 컬럼의 데이터를 Check 하여 같은 값이 있는 Row를 Return합니다.
        /// </summary>
        /// <param name="colName">컬럼명</param>
        /// <param name="value">비교 값</param>
        /// <returns></returns>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public DataTable GetDataTableByColumnValue(string colName, object value)
        {
            CloseEditor(true);

            DataSet ds = DataSource is DataView ? (DataSource as DataView).DataViewManager.DataSet : base.GridControl.DataSource as DataSet;

            UpdateCurrentRow();

            if (ds == null) return null;

            DataTable dt = ds.Tables[0].Clone();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr[colName].ToString() != value.ToString()) continue;

                dt.ImportRow(dr);
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
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public DataTable GetDataTableByDataSource()
        {
            CloseEditor(true);

            UpdateCurrentRow();
            DataTable dt = (GridControl.DataSource as DataSet).Tables[0];

            return dt ?? null;
        }

        #endregion

        #region :: GetDataTableByRowState :: 정의된 상태의 데이터를 가져옵니다.

        /// <summary>
        /// 정의된 상태의 데이터를 가져옵니다.
        /// </summary>
        /// <param name="state">Row 상태</param>
        /// <returns></returns>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public DataTable GetDataTableByRowState(DataRowState state)
        {
            CloseEditor(true);

            DataSet ds = DataSource is DataView ? (DataSource as DataView).DataViewManager.DataSet : base.GridControl.DataSource as DataSet;

            UpdateCurrentRow();

            if (ds == null) return null;

            DataTable dt = ds.Tables[0].Clone();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr.RowState == state)
                    dt.ImportRow(dr);
            }

            return dt;
        }

        #endregion

        #region :: GetDisplayTextByColumnValue ::

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetDisplayTextByColumnValue(string fieldName, object value)
        {
            BandedGridColumn gridColumn = Columns[fieldName];

            if (gridColumn == null) return "";

            return GetDisplayTextByColumnValue(gridColumn, value);
        }

        #endregion

        #region :: GetFocusedRowCellDisplayText :: Grid의 콤보박스에서 원하는 컬럼의 값을 가져옵니다.

        /// <summary>
        /// Grid의 콤보박스에서 원하는 컬럼의 값을 가져옵니다.
        /// </summary>
        /// <param name="fieldName">컬럼명</param>
        /// <param name="value">선택 값</param>
        /// <param name="columnName">가져올 컬럼명</param>
        /// <returns></returns>
        public string GetFocusedRowCellDisplayText(string fieldName, object value, string columnName)
        {
            BandedGridColumn gridColumn = Columns[fieldName];

            if (gridColumn == null) return "";

            RepositoryItemLookUpEdit edit = gridColumn.ColumnEdit as RepositoryItemLookUpEdit;

            if (edit == null) return "";

            DataTable dt = edit.DataSource as DataTable;

            int idx = edit.GetDataSourceRowIndex(AppConfig.VALUEMEMBER, value);

            return idx < 0 ? "" : dt.Rows[idx][columnName].ToString();
        }

        #endregion

        #region :: InitCheckedComboBoxColumn(+1 Overloading) :: CheckedComboBoxColumn Data를 초기화합니다.

        /// <summary>
        /// CheckedComboBoxColumn Data를 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="valueList">Value가 될 배열</param>
        /// <param name="displayList">Text가 될 배열</param>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void InitCheckedComboBoxColumn(string fieldName, object[] valueList, string[] displayList)
        {
            InitCheckedComboBoxColumn(fieldName, valueList, displayList, false);
        }

        /// <summary>
        /// CheckedComboBoxColumn Data를 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="valueList">Value가 될 배열</param>
        /// <param name="displayList">Text가 될 배열</param>
        /// <param name="selectAllItemVisible">전체선택 숨김/보임</param>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void InitCheckedComboBoxColumn(string fieldName, object[] valueList, string[] displayList, bool selectAllItemVisible)
        {
            if (valueList.Length != displayList.Length)
                return;

            using (DataTable dt = new DataTable())
            {
                dt.Columns.Add(AppConfig.VALUEMEMBER);
                dt.Columns.Add(AppConfig.DISPLAYMEMBER);
                for (int idx = 0; idx < valueList.Length; idx++)
                {
                    DataRow dr = dt.NewRow();
                    dr[AppConfig.VALUEMEMBER] = valueList[idx];
                    dr[AppConfig.DISPLAYMEMBER] = displayList[idx];
                    dt.Rows.Add(dr);
                }

                InitCheckedComboBoxColumn(fieldName, dt, selectAllItemVisible, AppConfig.VALUEMEMBER, AppConfig.DISPLAYMEMBER);
            }
        }

        /// <summary>
        /// CheckedComboBoxColumn Data를 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="dt">Datasource 가 될 DataTable</param>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void InitCheckedComboBoxColumn(string fieldName, DataTable dt)
        {
            InitCheckedComboBoxColumn(fieldName, dt, false, AppConfig.VALUEMEMBER, AppConfig.DISPLAYMEMBER);
        }

        /// <summary>
        /// CheckedComboBoxColumn Data를 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="dt">Datasource 가 될 DataTable</param>
        /// <param name="selectAllItemVisible">전체선택 숨김/보임</param>
        /// <param name="valueMember">ValueMember 명</param>
        /// <param name="displayMember">DisplayMemeber 명</param>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void InitCheckedComboBoxColumn(string fieldName, DataTable dt, bool selectAllItemVisible, string valueMember, string displayMember)
        {
            BandedGridColumn gridColumn = Columns[fieldName];

            if (gridColumn == null) return;

            RepositoryItemCheckedComboBoxEdit edit = RepositoryItemEditor.CheckedComboBoxEdit(dt, selectAllItemVisible, valueMember, displayMember);

            //RepositoryItemCheckedComboBoxEdit edit = new RepositoryItemCheckedComboBoxEdit { SelectAllItemCaption = "전체선택", SelectAllItemVisible = selectAllItemVisible };

            //edit.Appearance.Font = ControlConfig.DEFAULTFONT;
            //edit.AppearanceDropDown.Font = ControlConfig.DEFAULTFONT;
            //edit.NullText = "";

            //edit.DataSource = dt;
            //edit.ValueMember = valueMember;
            //edit.DisplayMember = displayMember;
            //edit.TextEditStyle = TextEditStyles.DisableTextEditor;

            gridColumn.ColumnEdit = edit;
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
        /// 2016-05-17 최초생성 : 오인봉
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
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void InitComboBoxColumn(string fieldName, object[] valueList, string[] displayList, bool selectAllItemVisible, bool showCodeColumn)
        {
            if (valueList.Length != displayList.Length)
                return;

            ILocaleConverter ui = (GridControl.FindForm()) as ILocaleConverter;

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
                InitComboBoxColumn(fieldName, dt, selectAllItemVisible, showCodeColumn);
            }
        }

        /// <summary>
        /// ComboBoxColumn Data를 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="dt">Datasource 가 될 DataTable</param>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
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
        /// 2016-05-17 최초생성 : 오인봉
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
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void InitComboBoxColumn(string fieldName, DataTable dt, bool selectAllItemVisible, bool showCodeColumn, string valueMember, string displayMember)
        {
            BandedGridColumn gridColumn = Columns[fieldName];

            if (gridColumn == null) return;

            RepositoryItemLookUpEdit edit = RepositoryItemEditor.ComboBoxEdit(dt, selectAllItemVisible, showCodeColumn, valueMember, displayMember);

            //RepositoryItemLookUpEdit edit = new RepositoryItemLookUpEdit();

            //DataRow dr;
            //if (selectAllItemVisible)
            //{
            //    dr = dt.NewRow();

            //    if (dt.Columns[valueMember].DataType == Type.GetType("System.String"))
            //        dr[valueMember] = "";
            //    else
            //        dr[valueMember] = -1;

            //    dr[displayMember] = "전체";
            //    dt.Rows.InsertAt(dr, 0);
            //}

            //edit.Appearance.Font = ControlConfig.DEFAULTFONT;
            //edit.AppearanceDropDown.Font = ControlConfig.DEFAULTFONT;
            //edit.AppearanceDropDownHeader.Font = ControlConfig.DEFAULTFONT;
            //edit.NullText = "";
            //edit.DataSource = dt;
            //edit.ValueMember = valueMember;
            //edit.DisplayMember = displayMember;
            ////string[] columns = dt.GetColumnsFromDataTable();
            ////Array.ForEach(columns, column =>
            ////{
            ////    edit.Columns.Add(column == valueMember ? CreateColumn(column, column, 70, HorzAlignment.Center, showCodeColumnVisible) : CreateColumn(column, column, 120, HorzAlignment.Default, true));
            ////});

            //edit.Columns.Add(ControlUtil.CreateLookUpColumn(valueMember, valueMember, 70, HorzAlignment.Center, showCodeColumn));
            //edit.Columns.Add(ControlUtil.CreateLookUpColumn(displayMember, displayMember, 120, HorzAlignment.Default, true));

            //edit.ShowHeader = false;
            //edit.TextEditStyle = TextEditStyles.DisableTextEditor;

            gridColumn.ColumnEdit = edit;
        }

        #endregion

        #region :: InitRadioBoxColumn(+1 Overloading) :: RadioBox Column Data를 초기화합니다.

        /// <summary>
        /// RadioBox Column Data를 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="valueList">Value가 될 배열</param>
        /// <param name="displayList">Text가 될 배열</param>
        /// <remarks>
        /// 2018-02-19 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void InitRadioBoxColumn(string fieldName, object[] valueList, string[] displayList)
        {
            InitRadioBoxColumn(fieldName, valueList, displayList, false, false);
        }

        /// <summary>
        /// RadioBox Column Data를 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="valueList">Value가 될 배열</param>
        /// <param name="displayList">Text가 될 배열</param>
        /// <param name="selectAllItemVisible">전체선택 숨김/보임</param>
        /// <param name="showCodeColumn">Code Column 숨김/보임</param>
        /// <remarks>
        /// 2018-02-19 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void InitRadioBoxColumn(string fieldName, object[] valueList, string[] displayList, bool selectAllItemVisible, bool showCodeColumn)
        {
            if (valueList.Length != displayList.Length)
                return;

            ILocaleConverter ui = (GridControl.FindForm()) as ILocaleConverter;

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
                InitRadioBoxColumn(fieldName, dt, selectAllItemVisible, showCodeColumn);
            }
        }

        /// <summary>
        /// RadioBox Column Data를 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="dt">Datasource 가 될 DataTable</param>
        /// <remarks>
        /// 2018-02-19 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void InitRadioBoxColumn(string fieldName, DataTable dt)
        {
            InitComboBoxColumn(fieldName, dt, false, false, AppConfig.VALUEMEMBER, AppConfig.DISPLAYMEMBER);
        }

        /// <summary>
        /// RadioBox Column Data를 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="dt">Datasource 가 될 DataTable</param>
        /// <param name="selectAllItemVisible">전체선택 숨김/보임</param>
        /// <param name="showCodeColumn">Code Column 숨김/보임</param>
        /// <remarks>
        /// 2018-02-19 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void InitRadioBoxColumn(string fieldName, DataTable dt, bool selectAllItemVisible, bool showCodeColumn)
        {
            InitRadioBoxColumn(fieldName, dt, selectAllItemVisible, showCodeColumn, AppConfig.VALUEMEMBER, AppConfig.DISPLAYMEMBER);
        }

        /// <summary>
        /// RadioBox Column Data를 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="dt">Datasource 가 될 DataTable</param>
        /// <param name="selectAllItemVisible">전체선택 숨김/보임</param>
        /// <param name="showCodeColumn">Code Column 숨김/보임</param>
        /// <param name="valueMember">ValueMember 명</param>
        /// <param name="displayMember">DisplayMemeber 명</param>
        /// <remarks>
        /// 2018-02-19 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void InitRadioBoxColumn(string fieldName, DataTable dt, bool selectAllItemVisible, bool showCodeColumn, string valueMember, string displayMember)
        {
            BandedGridColumn gridColumn = Columns[fieldName];

            if (gridColumn == null) return;

            RepositoryItemRadioGroup edit = RepositoryItemEditor.RadioGroupEdit(dt, selectAllItemVisible, showCodeColumn, valueMember, displayMember);

            //RepositoryItemRadioGroup edit = new RepositoryItemRadioGroup();

            //DataRow dr;

            //if (selectAllItemVisible)
            //{
            //    dr = dt.NewRow();

            //    if (dt.Columns[valueMember].DataType == Type.GetType("System.String"))
            //        dr[valueMember] = "";
            //    else
            //        dr[valueMember] = -1;

            //    dr[displayMember] = "전체";
            //    dt.Rows.InsertAt(dr, 0);
            //}

            //edit.Appearance.Font = ControlConfig.DEFAULTFONT;
            //edit.NullText = "";

            //foreach (DataRow drs in dt.Rows)
            //{
            //    RadioGroupItem rgi = new RadioGroupItem { Value = drs[valueMember], Description = drs[displayMember].ToString() };
            //    edit.Items.Add(rgi);
            //}

            gridColumn.ColumnEdit = edit;
        }

        #endregion

        #region :: InitSpinEditColumn(+1 Overloading) :: SpinEditColumn에 값을 넣습니다.

        /// <summary>
        /// SpinEditColumn에 값을 넣습니다.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="increment"></param>
        /// <param name="maxValue"></param>
        /// <param name="minValue"></param>
        public void InitSpinEditColumn(string fieldName, double increment, double maxValue, double minValue)
        {
            BandedGridColumn gridColumn = Columns[fieldName];

            if (gridColumn == null) return;

            if (!(gridColumn.ColumnEdit is RepositoryItemSpinEdit)) return;

            (gridColumn.ColumnEdit as RepositoryItemSpinEdit).Increment = new decimal(increment);
            (gridColumn.ColumnEdit as RepositoryItemSpinEdit).MaxValue = new decimal(maxValue);
            (gridColumn.ColumnEdit as RepositoryItemSpinEdit).MinValue = new decimal(minValue);
        }

        #endregion

        #region :: NewDataRow :: DataSource에서 새로운 Row를 생성합니다.

        /// <summary>
        /// DataSource에서 새로운 Row를 생성합니다.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public DataRow NewDataRow()
        {
            DataSet ds = DataSource is DataView ? (DataSource as DataView).DataViewManager.DataSet : base.GridControl.DataSource as DataSet;

            if (ds == null) return null;

            return ds.Tables[0].NewRow();
        }

        #endregion

        #region :: RemoveCheckedRow :: Check 된 DataRow를 삭제합니다.

        /// <summary>
        /// Check 된 DataRow를 삭제합니다.
        /// </summary>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void RemoveCheckedRow()
        {
            RemoveCheckedRow(AppConfig.CHECKCOLUMNNAME);
        }

        /// <summary>
        /// Check 된 DataRow를 삭제합니다.
        /// </summary>
        /// <param name="fieldName">CHECK 컬럼명</param>
        public void RemoveCheckedRow(string fieldName)
        {
            DataSet ds = DataSource is DataView ? (DataSource as DataView).DataViewManager.DataSet : base.GridControl.DataSource as DataSet;

            if (ds == null) return;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (!ds.Tables[0].Rows[i][fieldName].Equals(true))
                    continue;

                ds.Tables[0].Rows.Remove(ds.Tables[0].Rows[i]);
                i--;
            }
        }

        #endregion

        #region :: SetCellMerge :: Cell을 Merge 합니다.

        /// <summary>
        /// Cell을 Merge 합니다.
        /// </summary>
        /// <param name="columns">Merge를 실행할 Columns</param>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void SetCellMerge(params string[] columns)
        {
            OptionsView.AllowCellMerge = true;

            foreach (BandedGridColumn gc in Columns)
                gc.OptionsColumn.AllowMerge = DefaultBoolean.False;

            foreach (string column in columns)
                Columns[column].OptionsColumn.AllowMerge = DefaultBoolean.True;
        }

        #endregion

        #region :: SetColumnCaption :: Grid Column Caption을 설정합니다.

        /// <summary>
        /// Grid Column Caption을 설정합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="caption">변경할 Caption</param>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void SetColumnCaption(string fieldName, string caption)
        {
            BandedGridColumn gridColumn = Columns[fieldName];

            gridColumn.Caption = caption;
        }

        #endregion

        #region :: SetColumnCharacterCasing :: Grid Column의 CharacterCasing을 설정합니다.

        /// <summary>
        /// Grid Column의 CharacterCasing을 설정합니다.
        /// </summary>
        /// <param name="cashing">변경할 CharacterCasing</param>
        /// <param name="fieldNames">Column Field 명</param>
        /// <remarks>
        /// 2016-05-20 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void SetColumnCharacterCasing(CharacterCasing cashing, params string[] fieldNames)
        {
            foreach (string fieldName in fieldNames)
            {
                BandedGridColumn gridColumn = base.Columns[fieldName];

                if (gridColumn == null) continue;

                if (!(gridColumn.ColumnEdit is RepositoryItemTextEdit)) continue;

                (gridColumn.ColumnEdit as RepositoryItemTextEdit).CharacterCasing = cashing;
            }
        }

        #endregion

        #region :: SetColumnSummary :: Grid Column의 Summary를 설정합니다.

        /// <summary>
        /// Grid Column의 Summary를 설정합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="type">Summary Type</param>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void SetColumnSummary(string fieldName, SummaryType type)
        {
            BandedGridColumn gridColumn = Columns[fieldName];

            switch (type)
            {
                case SummaryType.Sum:
                    gridColumn.SummaryItem.SummaryType = SummaryItemType.Sum;
                    gridColumn.SummaryItem.DisplayFormat = String.Format("{{0:{0}}}", gridColumn.ColumnEdit.DisplayFormat.FormatString);
                    break;
                case SummaryType.Average:
                    gridColumn.SummaryItem.SummaryType = SummaryItemType.Average;
                    gridColumn.SummaryItem.DisplayFormat = String.Format("Avg : {{0:n{0}}}", gridColumn.ColumnEdit.DisplayFormat.FormatString);
                    break;
                case SummaryType.Count:
                    gridColumn.SummaryItem.SummaryType = SummaryItemType.Count;
                    gridColumn.SummaryItem.DisplayFormat = String.Format("Cnt : {{0:{0}}}", gridColumn.ColumnEdit.DisplayFormat.FormatString);
                    break;
            }

            OptionsView.ShowFooter = true;
        }

        #endregion

        #region :: SetGroupSummary :: Grouping 되었을 때 Summary를 설정합니다.

        /// <summary>
        /// Grouping 되었을 때 Summary를 설정합니다.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="type"></param>
        public void SetGroupSummary(string fieldName, SummaryType type)
        {
            BandedGridColumn showInColumn = Columns[fieldName];

            SummaryItemType itemType = SummaryItemType.None;
            string dispFormat = "";

            switch (type)
            {
                case SummaryType.Sum:
                    itemType = SummaryItemType.Sum;
                    dispFormat = "{0:n0}";
                    break;
                case SummaryType.Average:
                    itemType = SummaryItemType.Average;
                    dispFormat = "Avg : {0:n0}";
                    break;
                case SummaryType.Count:
                    itemType = SummaryItemType.Count;
                    dispFormat = "Cnt : {0:n0}";
                    break;
                case SummaryType.Max:
                    itemType = SummaryItemType.Max;
                    dispFormat = "Max : {0:n0}";
                    break;
                case SummaryType.Min:
                    itemType = SummaryItemType.Min;
                    dispFormat = "Min : {0:n0}";
                    break;
            }

            GroupSummary.Add(itemType, fieldName, showInColumn).DisplayFormat = dispFormat;
        }

        #endregion

        #region :: SetColumnVisible :: Grid Column 숨김/보임 여부를 설정합니다.

        /// <summary>
        /// Grid Column 숨김/보임 여부를 설정합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="visible">숨김/보임 여부</param>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void SetColumnVisible(string fieldName, bool visible)
        {
            BandedGridColumn gridColumn = Columns[fieldName];

            gridColumn.Visible = visible;
        }

        #endregion

        #region :: SetFixedBand(+1 Overloading) :: Fixed Band를 설정합니다.

        /// <summary>
        /// Fixed Band를 설정합니다.
        /// </summary>
        /// <param name="columnName">Fix 할 밴드명</param>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void SetFixedBand(string columnName)
        {
            SetFixedBand(columnName, FixedStyle.Left);
        }

        /// <summary>
        /// Fixed Band를 설정합니다.
        /// </summary>
        /// <param name="bandName">Fix 할 밴드명</param>
        /// <param name="style">Fix Style</param>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void SetFixedBand(string bandName, FixedStyle style)
        {
            GridBand gBand = Bands[bandName];

            if (gBand == null) return;

            gBand.Fixed = style;
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
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void SetStyleFormat(string fieldName, Color backColor, FormatConditionEnum formatCondition, object value1)
        {
            SetStyleFormat(fieldName, backColor, Appearance.Row.ForeColor, ControlConfig.DEFAULTFONT, formatCondition, value1, null);
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
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void SetStyleFormat(string fieldName, Color backColor, FormatConditionEnum formatCondition, object value1, bool applyToRow)
        {
            SetStyleFormat(fieldName, backColor, Appearance.Row.ForeColor, ControlConfig.DEFAULTFONT, formatCondition, value1, null, applyToRow);
        }

        /// <summary>
        /// Grid Column의 Style을 설정합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="backColor">설정할 Back Color</param>
        /// <param name="value1">비교값1</param>
        /// <param name="value2">비교값2</param>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void SetStyleFormat(string fieldName, Color backColor, object value1, object value2)
        {
            SetStyleFormat(fieldName, backColor, Appearance.Row.ForeColor, ControlConfig.DEFAULTFONT, FormatConditionEnum.Between, value1, value2);
        }

        /// <summary>
        /// Grid Column의 Style을 설정합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="backColor">설정할 Back Color</param>
        /// <param name="foreColor">설정할 Fore Color</param>
        /// <param name="font">설정할 Font</param>
        /// <param name="formatCondition">Format Condition</param>
        /// <param name="value1">비교값1</param>
        /// <param name="value2">비교값2</param>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void SetStyleFormat(string fieldName, Color backColor, Color foreColor, Font font, FormatConditionEnum formatCondition, object value1, object value2)
        {
            SetStyleFormat(fieldName, backColor, foreColor, font, formatCondition, value1, value2, false);
        }

        /// <summary>
        /// Grid Column의 Style을 설정합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="backColor">설정할 Back Color</param>
        /// <param name="foreColor">설정할 Fore Color</param>
        /// <param name="font">설정할 Font</param>
        /// <param name="formatCondition">Format Condition</param>
        /// <param name="value1">비교값1</param>
        /// <param name="value2">비교값2</param>
        /// <param name="applyToRow">Row에 색을 표시할지를 설정합니다.</param>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void SetStyleFormat(string fieldName, Color backColor, Color foreColor, Font font, FormatConditionEnum formatCondition, object value1, object value2, bool applyToRow)
        {
            GridColumn gridColumn = Columns[fieldName];

            StyleFormatCondition sfc = new StyleFormatCondition();
            sfc.Appearance.Font = font;
            sfc.Appearance.BackColor = backColor;
            sfc.Appearance.ForeColor = foreColor;

            sfc.Appearance.Options.UseBackColor = true;
            sfc.Appearance.Options.UseForeColor = true;
            sfc.Appearance.Options.UseFont = true;
            sfc.Appearance.Options.HighPriority = false;

            sfc.Column = gridColumn;
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
        public void SetStyleFormatExpression(string fieldName, Color backColor, string expression, bool applyToRow)
        {
            GridColumn gridColumn = Columns[fieldName];

            StyleFormatCondition sfc = new StyleFormatCondition(FormatConditionEnum.Expression);
            sfc.Appearance.Font = ControlConfig.DEFAULTFONT;
            sfc.Appearance.BackColor = backColor;

            sfc.Appearance.Options.UseBackColor = true;
            sfc.Appearance.Options.UseFont = true;
            sfc.Appearance.Options.HighPriority = false;

            sfc.Column = gridColumn;
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
            GridColumn gridColumn = Columns[fieldName];

            StyleFormatCondition sfc = new StyleFormatCondition(FormatConditionEnum.Expression);
            sfc.Appearance.Font = ControlConfig.DEFAULTFONT;
            sfc.Appearance.ForeColor = foreColor;

            sfc.Appearance.Options.UseForeColor = true;
            sfc.Appearance.Options.UseFont = true;
            sfc.Appearance.Options.HighPriority = false;

            sfc.Column = gridColumn;
            sfc.ApplyToRow = applyToRow;

            sfc.Expression = expression;

            FormatConditions.Add(sfc);
        }

        #endregion

        #region :: AcceptChanges :: DataSource의 변경 내용을 COMMIT 합니다.

        /// <summary>
        /// DataSource의 변경 내용을 COMMIT 합니다.
        /// </summary>
        public void AcceptChanges()
        {
            DataTable dt = GetDataTableByDataSource();

            if (dt == null) return;

            dt.AcceptChanges();

            IAuth ui = GridControl.FindForm() as IAuth;

            if (NewRowEnableColumns == null || ui == null || !ui.SaveAuth) return;

            foreach (string column in NewRowEnableColumns) Columns[column].OptionsColumn.AllowEdit = false;
        }

        #endregion

        #region :: AddNewRow :: 새로운 Row를 추가합니다.

        /// <summary>
        /// 새로운 Row를 추가합니다.
        /// </summary>
        /// <param name="colName">컬럼명</param>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void AddNewRow(string colName)
        {
            AddNewRow();
            FocusedColumn = Columns[colName] ?? null;
            //FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle;
            ShowEditor();
        }

        #endregion

        #region :: CopyDataRow :: 대상 ROW를 신규 ROW로 복사합니다.

        /// <summary>
        /// 대상 ROW를 신규 ROW로 복사합니다.
        /// </summary>
        /// <param name="sourceRowHandle">대상 로우 Handle</param>
        public void CopyDataRow(int sourceRowHandle)
        {
            if (GetDataRow(sourceRowHandle) == null) return;

            DataRow dr = GetDataTableByDataSource().NewRow();

            for (int idx = 0; idx < GetDataRow(sourceRowHandle).ItemArray.Length; idx++)
            {
                dr[idx] = GetDataRow(sourceRowHandle).ItemArray[idx];
            }
            AddDataRow(dr);
            dr.AcceptChanges();
        }

        #endregion

        #region :: GetAddedModifedData :: Grid에서 추가 및 수정된 데이터를 가져옵니다.

        /// <summary>
        /// Grid에서 추가 및 수정된 데이터를 가져옵니다.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public DataTable GetAddedModifedData()
        {
            CloseEditor(true);

            DataSet ds = DataSource is DataView ? (DataSource as DataView).DataViewManager.DataSet : base.GridControl.DataSource as DataSet;

            UpdateCurrentRow();

            if (ds == null) return null;

            DataTable dt = ds.Tables[0].Clone();

            //UserInfo user = (GridControl.FindForm() as IUser).CurrentUser;
            IFrameUI uiForm = (GridControl.FindForm() as IFrameUI);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr.RowState == DataRowState.Added || dr.RowState == DataRowState.Modified || dr.RowState == DataRowState.Detached)
                {
                    if (uiForm != null && uiForm.AddCommomParam)
                    {
                        if (dr.Table.Columns.Contains("VENDORCODE") && dr["VENDORCODE"].ToString() == string.Empty)
                            dr["VENDORCODE"] = uiForm.CurrentUser.VENDORCODE;

                        if (dr.Table.Columns.Contains("PLANTCODE") && dr["PLANTCODE"].ToString() == string.Empty)
                            dr["PLANTCODE"] = uiForm.CurrentUser.PLANTCODE;
                    }
                    if (uiForm != null && dr.Table.Columns.Contains(AppConfig.USERCOLUMNNAME))
                        dr[AppConfig.USERCOLUMNNAME] = uiForm.CurrentUser.USERID;

                    if (dr.Table.Columns.Contains(AppConfig.DATECOLUMNNAME))
                        dr[AppConfig.DATECOLUMNNAME] = DateTime.Now;

                    dt.ImportRow(dr);
                }
            }

            return dt;
        }

        #endregion

        #region :: SetColumnAllowEdit :: Grid Column 수정 가능 여부를 설정합니다.

        /// <summary>
        /// Grid Column 수정 가능 여부를 설정합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="allowEdit">수정 가능 여부</param>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void SetColumnAllowEdit(string fieldName, bool allowEdit)
        {
            GridColumn gridColumn = Columns[fieldName];

            //gridColumn.AppearanceHeader.FontStyleDelta = allowEdit ? FontStyle.Bold : FontStyle.Regular;

            gridColumn.OptionsColumn.AllowEdit = allowEdit;
        }

        #endregion

        #region :: SetAutoInsertColumn :: 자동입력 문구를 보여줍니다.

        /// <summary>
        /// 자동입력 문구를 보여줍니다.
        /// </summary>
        /// <param name="fieldName"></param>
        public void SetAutoInsertColumn(string fieldName)
        {
            GridColumn gridColumn = Columns[fieldName];

            gridColumn.RealColumnEdit.NullText = String.Format("[ {0} ]", (GridControl.FindForm() as ILocaleConverter).LOCALECONVERTER.GetLocaleString("AutoCreate"));
        }

        #endregion

        #region :: Validate :: 필수입력 컬럼의 데이터 신뢰성을 검증합니다.

        /// <summary>
        /// 필수입력 컬럼의 데이터 신뢰성을 검증합니다.
        /// </summary>
        /// <param name="value">체크할 값</param>
        /// <param name="check">체크할 값과 같은지 여부</param>
        /// <returns></returns>
        public bool Validate(object value, bool check)
        {
            return Validate(value, check, MandatoryColumns);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="check"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        public bool Validate(object value, bool check, params string[] columns)
        {
            if (columns == null || columns.Length == 0) return true;

            UpdateCurrentRow();

            EBAP.Core.Localization.LocaleConverter locale = (GridControl.FindForm() as ILocaleConverter).LOCALECONVERTER;
            //const string message = "필수입력 항목입니다. 값을 입력 하세요.\r\n작업을 취소하려면 [ESC]를 눌러주세요";
            string message = locale.GetLocaleMessage("IF_EssentialItem");

            for (int i = 0; i < RowCount; i++)
            {
                foreach (string column in columns)
                {
                    if (GetRowCellValue(i, column) == null || (GetRowCellValue(i, column).ToString() == value.ToString()) == check)
                    {
                        //[ {0} ] 은(는) 필수 입력 항목입니다.
                        (GridControl.FindForm() as IDialog).ShowMsgBox(String.Format(message, Columns[column].Caption), locale.GetLocaleString("Confirm2"));
                        return false;
                    }
                }
            }

            return true;
        }

        #endregion

        #region :: SetCheckedColumnDefaultValue :: 체크 컬럼의 기본 값을 설정합니다.

        /// <summary>
        /// 체크 컬럼의 기본 값을 설정합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="valueChecked">체크했을 때 기본값</param>
        /// <param name="valueUnchecked">언체크했을 때 기본값</param>
        /// <remarks>
        /// 2018-02-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void SetCheckedColumnDefaultValue(string fieldName, object valueChecked, object valueUnchecked)
        {
            GridColumn gridColumn = Columns[fieldName];

            var checkEdit = gridColumn.ColumnEdit as RepositoryItemCheckEdit;

            if (checkEdit == null) return;

            checkEdit.ValueChecked = valueChecked;
            checkEdit.ValueUnchecked = valueUnchecked;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="unboundExpression"></param>
        /// <param name="unboundType"></param>
        public void SetUnboundExpression(string fieldName, string unboundExpression, UnboundColumnType unboundType = UnboundColumnType.Bound)
        {
            GridColumn gridColumn = Columns[fieldName];

            if (gridColumn == null) return;

            gridColumn.UnboundType = unboundType;
            gridColumn.UnboundExpression = unboundExpression;

            gridColumn.ShowUnboundExpressionMenu = true;
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Control Event Handler
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: PBandedGridView_PrintInitialize ::


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="System.NotImplementedException"></exception>

        private void PBandedGridView_PrintInitialize(object sender, DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs e)
        {
            PrintingSystemBase pb = e.PrintingSystem as PrintingSystemBase;

            pb.PageSettings.Landscape = true;
            pb.PageSettings.LeftMargin = 20;
            pb.PageSettings.RightMargin = 20;
            pb.PageSettings.TopMargin = 40;
            pb.PageSettings.BottomMargin = 40;
            pb.PageSettings.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A4;
            pb.Document.AutoFitToPagesWidth = 1;

            IFrameUI user = (GridControl.FindForm()) as IFrameUI;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine((GridControl.FindForm()).Text);
            sb.AppendLine();
            sb.AppendLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
            sb.Append(String.Format("{0} - {1}", user.CurrentUser.USERID, user.CurrentUser.USERNAME));

            pb.Watermark.ShowBehind = false;
            pb.Watermark.TextDirection = DevExpress.XtraPrinting.Drawing.DirectionMode.Horizontal;
            pb.Watermark.Text = sb.ToString();
            pb.Watermark.TextTransparency = 180;
            pb.Watermark.Font = new Font("나눔고딕", 40.25F);
        }

        #endregion

        #region :: PBandedGridView_CustomDrawCell :: Cell이 추가/수정/삭제 되면 Color를 변경합니다.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PBandedGridView_CustomDrawBandHeader(object sender, DevExpress.XtraGrid.Views.BandedGrid.BandHeaderCustomDrawEventArgs e)
        {
            try
            {
                if (e.Band == null) return;

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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PBandedGridView_CustomDrawColumnHeader(object sender, DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e)
        {
            try
            {
                if (e.Column == null) return;

                e.Cache.FillRectangle(e.Cache.GetSolidBrush(ControlConfig.HEADERBACKCOLOR), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1));
                e.Appearance.DrawString(e.Cache, e.Info.Caption, e.Info.CaptionRect, e.Cache.GetSolidBrush(ControlConfig.HEADERFORECOLOR));

                foreach (DrawElementInfo info in e.Info.InnerElements)
                {
                    if (!info.Visible) continue;

                    ObjectPainter.DrawObject(e.Cache, info.ElementPainter, info.ElementInfo);
                }

                e.Handled = true;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PBandedGridView_CustomDrawFooter(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            try
            {
                e.Cache.FillRectangle(e.Cache.GetSolidBrush(ControlConfig.FOOTERBACKCOLOR), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1));

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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PBandedGridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.RowHandle < 0) return;

                if (base.GetRow(e.RowHandle) == null) return;

                DataRowView drv = base.GetRow(e.RowHandle) as DataRowView;

                if (drv == null) return;

                DataRow dr = drv.Row;

                switch (dr.RowState)
                {
                    case DataRowState.Added:
                        e.Appearance.ForeColor = ControlConfig.ADDEDROWCOLOR;
                        e.Appearance.Font = ControlConfig.BOLDFONT;
                        break;
                    case DataRowState.Modified:
                        e.Appearance.ForeColor = ControlConfig.MODIFIEDROWCOLOR;
                        e.Appearance.Font = ControlConfig.ITALICFONT;
                        break;
                    default:
                        break;
                }

                PRepositoryItemButtonEdit btnEdit = (e.Column.ColumnEdit as PRepositoryItemButtonEdit);

                if (btnEdit != null && btnEdit.TextEditStyle == TextEditStyles.HideTextEditor)
                {
                    ButtonEditViewInfo editInfo = (ButtonEditViewInfo)((DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo)e.Cell).ViewInfo;

                    if (editInfo.RightButtons.Count != 0 || e.DisplayText != "")
                        editInfo.RightButtons[0].Button.Caption = e.DisplayText;
                }

                if (dr.Table.Columns.Contains(AppConfig.CHECKCOLUMNNAME))
                {
                    if (dr[AppConfig.CHECKCOLUMNNAME] != null && dr[AppConfig.CHECKCOLUMNNAME].ToString() != "" && Convert.ToBoolean(dr[AppConfig.CHECKCOLUMNNAME]))
                    {
                        e.Appearance.ForeColor = ControlConfig.DELETEROWCOLOR;
                        e.Appearance.Font = ControlConfig.DELETEFONT;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region :: PBandedGridView_CustomDrawRowIndicator :: Indicator 에 Row Number를 표시합니다.

        /// <summary>
        /// Indicator 에 Row Number를 표시합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PBandedGridView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (!OptionsView.ShowIndicator || DesignMode) return;

            if (e.RowHandle == GridControl.InvalidRowHandle)
            {
                e.DefaultDraw();
                e.Info.IsDrawOnGlass = true;

                if (EnableSaveLayout)
                    e.Cache.FillRectangle(e.Cache.GetSolidBrush(ControlConfig.SAVELAYOUTCOLOR), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1));
                else
                    e.Cache.FillRectangle(e.Cache.GetSolidBrush(ControlConfig.HEADERBACKCOLOR), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1));
            }

            //if (!e.Info.IsRowIndicator || !UseIndicatorNumber) return;
            //if (e.RowHandle < 0) return;

            //e.Info.DisplayText = Convert.ToString(e.RowHandle + 1);
            //e.Info.Kind = DevExpress.Utils.Drawing.IndicatorKind.Row;
            //e.Info.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            //e.Info.Appearance.TextOptions.HAlignment = HorzAlignment.Far;

            //base.IndicatorWidth = 40;
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: RaiseShowingEditor :: ShowingEdiotor 조건에 만족하지만 MemoEdit일 경우 조건을 강제로 변경합니다.

        /// <summary>
        /// ShowingEdiotor 조건에 만족하지만 MemoEdit일 경우 조건을 강제로 변경합니다.
        /// </summary>
        /// <returns></returns>
        protected override bool RaiseShowingEditor()
        {
            bool val = base.RaiseShowingEditor();
            if (val) return val;

            if (FocusedColumn.ColumnEdit is RepositoryItemMemoExEdit || FocusedColumn.ColumnEdit is RepositoryItemImageEdit)
            {
                FocusedColumn.OptionsColumn.AllowEdit = true;
                FocusedColumn.ColumnEdit.ReadOnly = !val;
                val = true;
            }

            return val;
        }

        #endregion

        #region :: RaiseCustomDrawCell :: Cell이 추가/수정/삭제 되면 Color를 변경합니다.

        ///// <summary>
        ///// Cell이 추가/수정/삭제 되면 Color를 변경합니다.
        ///// </summary>
        ///// <param name="e"></param>
        //protected override void RaiseCustomDrawCell(DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        //{
        //    if (e.RowHandle < 0) return;

        //    if (base.GetRow(e.RowHandle) == null) return;

        //    DataRowView drv = base.GetRow(e.RowHandle) as DataRowView;

        //    if (drv == null) return;

        //    DataRow dr = drv.Row;

        //    switch (dr.RowState)
        //    {
        //        case DataRowState.Added:
        //            e.Appearance.ForeColor = ControlConfig.ADDEDROWCOLOR;
        //            e.Appearance.Font = ControlConfig.DEFAULTFONT;
        //            //e.Appearance.BackColor = DXSystemColors.Info;
        //            break;
        //        case DataRowState.Modified:
        //            e.Appearance.ForeColor = ControlConfig.MODIFIEDROWCOLOR;
        //            e.Appearance.Font = ControlConfig.ITALICFONT;
        //            break;
        //        default:
        //            break;
        //    }

        //    PRepositoryItemButtonEdit btnEdit = (e.Column.ColumnEdit as PRepositoryItemButtonEdit);

        //    if (btnEdit != null && btnEdit.TextEditStyle == TextEditStyles.HideTextEditor)
        //    {
        //        ButtonEditViewInfo editInfo = (ButtonEditViewInfo)((DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo)e.Cell).ViewInfo;

        //        if (editInfo.RightButtons.Count != 0 || e.DisplayText != "")
        //            editInfo.RightButtons[0].Button.Caption = e.DisplayText;
        //    }

        //    if (dr.Table.Columns.Contains(AppConfig.CHECKCOLUMNNAME))
        //    {
        //        if (dr[AppConfig.CHECKCOLUMNNAME] != null && dr[AppConfig.CHECKCOLUMNNAME].ToString() != "" && Convert.ToBoolean(dr[AppConfig.CHECKCOLUMNNAME]))
        //        {
        //            e.Appearance.ForeColor = ControlConfig.DELETEROWCOLOR;
        //            e.Appearance.Font = ControlConfig.DELETEFONT;
        //        }
        //    }

        //    base.RaiseCustomDrawCell(e);
        //}

        #endregion

        #region :: OnDataController_DataSourceChanged :: Datasource가 변경되면 RowCount를 Check하여 MainForm에 정보를 표시합니다.

        /// <summary>
        /// Datasource가 변경되면 RowCount를 Check하여 MainForm에 정보를 표시합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnDataController_DataSourceChanged(object sender, EventArgs e)
        {
            //prevRowIndex = DevExpress.XtraGrid.GridControl.NewItemRowHandle;

            //(GridControl.FindForm()).DataBindings.BindableComponent.DataBindings.Clear();

            RaiseFocusedRowChanged(-1, FocusedRowHandle);

            SetKeyColumns();

            base.OnDataController_DataSourceChanged(sender, e);

            if (DesignMode || !EnableSaveLayout) return;

            IFrameUI ui = GridControl.FindForm() as IFrameUI;
            if (DesignMode || ui == null) return;

            string keyName = String.Format("{0}{1}", ui.MENUID, Name);

            string getValue = Win32Util.GetIniValue(AppConfig.SETTINGFILEPATH, "GridLayout", keyName);

            if (getValue == string.Empty || !File.Exists(getValue)) return;

            RestoreLayoutFromXml(getValue);
        }

        /// <summary>
        /// DataTable의 Primary Key를 설정합니다.
        /// </summary>
        private void SetKeyColumns()
        {
            if (KeyColumns == null) return;

            DataTable dt = GetDataTableByDataSource();

            if (dt == null) return;

            List<DataColumn> dc = new List<DataColumn>();

            foreach (string keycolumn in KeyColumns)
                dc.Add(dt.Columns[keycolumn]);

            dt.PrimaryKey = dc.ToArray();
        }

        #endregion

        #region :: RaiseCellValueChanging :: Cell Value가 변경할 때마다 발생합니다.

        /// <summary>
        /// Cell Value가 변경할 때마다 발생합니다.
        /// </summary>
        /// <param name="e"></param>
        protected override void RaiseCellValueChanging(DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (base.FocusedRowHandle < 0) return;

                if (e.Column.FieldName != AppConfig.CHECKCOLUMNNAME) return;

                base.SetRowCellValue(e.RowHandle, e.Column, e.Value);

                GetFocusedDataRow().AcceptChanges();
            }
            catch
            {
                throw;
            }
            finally
            {
                base.RaiseCellValueChanging(e);
            }
        }

        #endregion

        #region :: RaiseCustomDrawRowIndicator :: Indicator 에 Row Number를 표시합니다.

        ///// <summary>
        ///// Indicator 에 Row Number를 표시합니다.
        ///// </summary>
        ///// <param name="e"></param>
        //protected override void RaiseCustomDrawRowIndicator(RowIndicatorCustomDrawEventArgs e)
        //{
        //    try
        //    {
        //        if (!OptionsView.ShowIndicator) return;

        //        if (e.RowHandle == GridControl.InvalidRowHandle && EnableSaveLayout)
        //        {
        //            e.Handled = true;
        //            e.Painter.DrawObject(e.Info);

        //            Rectangle r = e.Bounds;
        //            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(50, 255, 0, 0)), r);
        //            r.Height--; r.Width--;
        //            e.Graphics.DrawRectangle(Pens.Red, r);
        //        }

        //        //if (!e.Info.IsRowIndicator) return;
        //        //if (e.RowHandle < 0) return;

        //        //e.Info.DisplayText = Convert.ToString(e.RowHandle + 1);
        //        //e.Info.Kind = DevExpress.Utils.Drawing.IndicatorKind.Row;
        //        //e.Info.Appearance.TextOptions.VAlignment = VertAlignment.Center;
        //        //e.Info.Appearance.TextOptions.HAlignment = HorzAlignment.Far;

        //        //base.IndicatorWidth = 40;
        //    }
        //    catch
        //    {
        //        throw;
        //    }

        //    base.RaiseCustomDrawRowIndicator(e);
        //}

        #endregion

        #region :: RaiseInitNewRow :: 신규 Row가 발생할 때 이전 Row의 내용을 신규 Row로 복사합니다.

        /// <summary>
        /// 신규 Row가 발생할 때 이전 Row의 내용을 신규 Row로 복사합니다.
        /// </summary>
        /// <param name="e"></param>
        protected override void RaiseInitNewRow(DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            base.RaiseInitNewRow(e);

            if (NewRowCopyColumns == null || NewRowCopyColumns.Length < 1 || e.RowHandle != DevExpress.XtraGrid.GridControl.NewItemRowHandle) return;

            DataRow dr = GetDataRow(e.RowHandle);
            DataRow sourceDr = GetDataRow(prevRowIndex);

            if (dr == null || sourceDr == null) return;

            foreach (string col in NewRowCopyColumns)
                dr[col] = sourceDr[col];

            UpdateCurrentRow();
        }

        #endregion

        #region :: RaiseInvalidRowException :: 예외가 발생하면 Message를 표시하지 않습니다.

        /// <summary>
        /// 예외가 발생하면 Message를 표시하지 않습니다.
        /// </summary>
        /// <param name="ex"></param>
        protected override void RaiseInvalidRowException(DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs ex)
        {
            ex.ExceptionMode = ExceptionMode.NoAction;

            if (ex.ErrorText != string.Empty)
            {
                if (KeyColumns == null) return;

                foreach (string key in KeyColumns)
                {
                    if (ex.ErrorText.Contains(key))
                        SetColumnError(Columns[key], ex.ErrorText, DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning);
                }
            }

            base.RaiseInvalidRowException(ex);
        }

        #endregion

        #region :: RaiseFocusedRowChanged :: Focused Row가 변경되면 NewRowEnableColumns의 AllowEdit 를 True로 변경합니다.

        /// <summary>
        /// Focused Row가 변경되면 NewRowEnableColumns의 AllowEdit 를 True로 변경합니다.
        /// </summary>
        /// <param name="prevFocused"></param>
        /// <param name="focusedRowHandle"></param>
        protected override void RaiseFocusedRowChanged(int prevFocused, int focusedRowHandle)
        {
            base.RaiseFocusedRowChanged(prevFocused, focusedRowHandle);

            prevRowIndex = prevFocused;
            prevFocusedRowIndex = focusedRowHandle;

            DataRow dr = GetFocusedDataRow();

            if (dr != null && EnableControlBinding && focusedRowHandle > -1)
            {
                (GridControl.FindForm()).BindingContext[GetDataTableByDataSource()].Position = GetFocusedDataSourceRowIndex();
            }

            IAuth ui = GridControl.FindForm() as IAuth;

            if (focusedRowHandle == DevExpress.XtraGrid.GridControl.NewItemRowHandle)
            {
                if (NewRowEnableColumns != null && ui != null && ui.SaveAuth)
                {
                    foreach (string column in NewRowEnableColumns) Columns[column].OptionsColumn.AllowEdit = true;
                }
                return;
            }

            if (dr != null && ui != null)
            {
                if (NewRowEnableColumns != null && ui.SaveAuth && NewRowEnableColumns.Length > 0)
                {
                    if (dr.RowState == DataRowState.Added || dr.RowState == DataRowState.Detached)
                    {
                        foreach (string column in NewRowEnableColumns) Columns[column].OptionsColumn.AllowEdit = true;
                    }
                    else
                    {
                        foreach (string column in NewRowEnableColumns) Columns[column].OptionsColumn.AllowEdit = false;
                    }
                }
            }
        }

        #endregion

        #region :: RaiseValidateRow :: 신규 Row의 필수 입력값을 강제로 정의합니다.

        /// <summary>
        /// 신규 Row의 필수 입력값을 강제로 정의합니다.
        /// </summary>
        /// <param name="e"></param>
        protected override void RaiseValidateRow(DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (MandatoryColumns == null) return;

            List<GridColumn> cList = new List<GridColumn>();

            if (e.Row != null && (e.Row as DataRowView) != null)
            {
                foreach (string column in MandatoryColumns)
                {
                    if ((e.Row as DataRowView).Row[column].ToString() == string.Empty)
                        cList.Add(Columns[column]);
                }
            }

            if (cList.Count > 0)
            {
                EBAP.Core.Localization.LocaleConverter locale = (GridControl.FindForm() as ILocaleConverter).LOCALECONVERTER;
                //const string message = "필수입력 항목입니다. 값을 입력 하세요.\r\n작업을 취소하려면 [ESC]를 눌러주세요";
                string message = locale.GetLocaleMessage("IF_EssentialItemValidate");

                foreach (GridColumn gc in cList)
                    SetColumnError(gc, message, DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning);

                e.Valid = false;
            }

            base.RaiseValidateRow(e);
        }

        #endregion

        #region :: CopyToClipboard :: Ctrl + C 기능을 재정의 합니다.

        private DefaultBoolean CopyColumnHeaders = DefaultBoolean.False;

        /// <summary>
        /// (Override) Ctrl + C 기능을 재정의 합니다.
        /// </summary>
        public override void CopyToClipboard()
        {
            if (IsMultiSelect)
            {
                //OptionsClipboard.CopyColumnHeaders = IsAllRowsSelected ? DefaultBoolean.True : DefaultBoolean.False;
                //OptionsClipboard.CopyColumnHeaders = (GetSelectedCells().Length == RowCount * Columns.Count) ? DefaultBoolean.True : DefaultBoolean.False;

                int length = GetSelectedCells().Length;

                if (length == 0) return;

                if (length == 1)
                {
                    CopyColumnHeaders = OptionsClipboard.CopyColumnHeaders;

                    OptionsClipboard.CopyColumnHeaders = DefaultBoolean.False;

                    string text = GetFocusedDisplayText();

                    Clipboard.SetText(text);

                    //string text = GetFocusedDisplayText();
                    //string value = GetFocusedValue().ToString();
                    //Clipboard.Clear();

                    //if (value == text)
                    //Clipboard.SetText(text);
                    //else
                    //    Clipboard.SetText(String.Format("{0} : {1}", value, text));

                    OptionsClipboard.CopyColumnHeaders = CopyColumnHeaders;
                }
                else
                {
                    CopyColumnHeaders = OptionsClipboard.CopyColumnHeaders;

                    OptionsClipboard.CopyColumnHeaders = (length == RowCount * Columns.Count) ? DefaultBoolean.True : DefaultBoolean.False;
                    base.CopyToClipboard();
                    OptionsClipboard.CopyColumnHeaders = CopyColumnHeaders;
                }
            }
            else
            {
                //string value = GetFocusedValue().ToString();
                //string text = GetFocusedDisplayText();

                //Clipboard.Clear();

                //if (value == text)
                //    Clipboard.SetText(text);
                //else
                //    Clipboard.SetText(String.Format("{0} : {1}", value, text));

                string text = GetFocusedDisplayText();
                Clipboard.SetText(text);
            }
        }

        #endregion

        #region :: AddNewRow :: 신규 Row를 추가합니다.(추가 시 조회를 하지 않았으면 메시지를 출력합니다.)

        /// <summary>
        /// (Override) 신규 Row를 추가합니다.(추가 시 조회를 하지 않았으면 메시지를 출력합니다.)
        /// </summary>
        public override void AddNewRow()
        {
            if (DataSource == null) throw new Exception("조회를 먼저 하세요");

            base.AddNewRow();
        }

        #endregion

        #region :: OnColumnChanged :: 컬럼이 변경되면 수정 여부에 따라 Header 모양을 변경합니다.

        /// <summary>
        /// 컬럼이 변경되면 수정 여부에 따라 Header 모양을 변경합니다.
        /// </summary>
        /// <param name="column"></param>
        protected override void OnColumnChanged(GridColumn column)
        {
            base.OnColumnChanged(column);

            if (column == null || column.ColumnEdit == null) return;

            column.AppearanceHeader.Options.UseFont = true;

            if (column.OptionsColumn.AllowEdit && !column.ColumnEdit.ReadOnly && AppConfig.CHECKCOLUMNNAME != column.FieldName)
                column.AppearanceHeader.Font = ControlConfig.BOLDFONT;
            else
                column.AppearanceHeader.Font = ControlConfig.DEFAULTFONT;
        }

        #endregion
    }
}
