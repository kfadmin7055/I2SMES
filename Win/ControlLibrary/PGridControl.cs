using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using EBAP.Core;
using EBAP.Core.Info;
using EBAP.Core.Interface;
using EBAP.Win.ControlLibrary.GridInfoHandler;
using EBAP.Win.ControlLibrary.Repository;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace EBAP.Win.ControlLibrary
{
    /// <summary>
    /// Grid Control 입니다.
    /// DevExpress GridControl을 Wrapping 하여 사용합니다.
    /// </summary>
    /// <remarks>
    /// 2023-02-01 최초생성 : 오인봉
    /// 변경내역
    ///
    /// </remarks>
    [ToolboxItem(true)]
    public partial class PGridControl : DevExpress.XtraGrid.GridControl, IInitEditValue, IFillData, IExport, IPrint, ICancelEditRow
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// Grid Control을 생성합니다.
        /// </summary>
        public PGridControl()
        {
            InitializeComponent();
        }

        #endregion

        #region :: 전역변수 ::

        private bool _checkAll = false;

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
            FillData();
        }

        #endregion

        #region IFillData 멤버

        /// <summary>
        /// GridControl의 데이터를 채웁니다.
        /// </summary>
        public void FillData()
        {
            //DefaultView.ViewCaption = DefaultView.ViewCaption == "" ? " " : DefaultView.ViewCaption;
            if(!FixViewCaption) DefaultView.ViewCaption = " ";

            using (DataSet ds = new DataSet())
            {
                DataTable dt = null;

                if (DefaultView is PGridView)
                    dt = ds.MakeDataTableScheme((DefaultView as PGridView).GetColumnField());
                else if (DefaultView is PBandedGridView)
                    dt = ds.MakeDataTableScheme((DefaultView as PBandedGridView).GetColumnField());

                if (dt == null) return;

                ds.Tables.Add(dt);

                FillData(ds, ds.Tables[0].TableName);
            }
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
        public void TrimFillData(DataSet ds)
        {
            TrimFillData(ds, ds.Tables[0].TableName);
        }

        /// <summary>
        /// GridControl의 데이터를 채웁니다.
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        public void TrimFillData(DataSet ds, string tableName)
        {
            ds.Tables[tableName].TrimColumnData();
            FillData(ds, ds.Tables[tableName].TableName);
        }

        /// <summary>
        /// GridControl의 데이터를 채웁니다.
        /// </summary>
        /// <param name="ds"></param>
        public void FillDataReSize(DataSet ds)
        {
            TrimFillData(ds, ds.Tables[0].TableName);
            ColumnsResize();
        }

        /// <summary>
        /// GridControl의 데이터를 채웁니다.
        /// </summary>
        /// <param name="dt"></param>
        public void FillData(DataTable dt)
        {
            DataSet ds = dt.DataSet;

            if (ds == null)
            {
                ds = new DataSet();
                ds.Tables.Add(dt);
            }
            FillData(ds, dt.TableName);
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

            _checkAll = false;

            foreach (GridColumn column in (DefaultView as GridView).Columns)
            {
                if (ds.Tables[tableName].Columns.Contains(column.FieldName) || column.UnboundExpression != "")
                    continue;

                ds.Tables[tableName].Columns.Add(column.FieldName, column.ColumnType);
            }
            ds.AcceptChanges();

            if (IsMoveLast) (DefaultView as GridView).MoveLast();
        }

        /// <summary>
        /// Columns을 사이즈를 변경한다.
        /// </summary>
        public void ColumnsResize()
        {
            foreach (GridColumn col in (DefaultView as GridView).Columns)
                col.Width = col.GetBestWidth();
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
            DataRow dr = (DefaultView as GridView).GetFocusedDataRow();

            if (dr == null) return;

            if(dr.RowState == DataRowState.Modified)
            {
                dr.RejectChanges();
                (DefaultView as GridView).RefreshEditor(true);
            }

            if (dr.RowState == DataRowState.Added)
            {
                (DefaultView as GridView).DeleteRow((DefaultView as GridView).FocusedRowHandle);
            }
        }

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: IsMoveLast :: 마지막 Row 이동 여부를 설정합니다.

        /// <summary>
        /// 마지막 Row 이동 여부를 설정합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(false), Browsable(true)]
        [Description("마지막 Row 이동 여부를 설정합니다.")]
        public bool IsMoveLast
        {
            get;
            set;
        }

        #endregion

        #region :: FixViewCaption :: 설정된 ViewCaption을 변경하지 않습니다.

        /// <summary>
        /// 설정된 ViewCaption을 변경하지 않습니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(false), Browsable(true)]
        [Description("설정된 ViewCaption을 변경하지 않습니다.")]
        public bool FixViewCaption
        {
            get;
            set;
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: OnKeyDown :: 저장, 삭제, 신규에 대한 단축키를 정의합니다.

        /// <summary>
        /// 저장, 삭제, 신규에 대한 단축키를 정의합니다.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            //if (!e.Control) return;

            //switch (e.KeyCode)
            //{
            //    case Keys.S:
            //        (FindForm() as IRaiseEvent).RaiseSaveEvent();
            //        break;
            //    case Keys.D:
            //        (FindForm() as IRaiseEvent).RaiseDeleteEvent();
            //        break;
            //    case Keys.N:
            //        (FindForm() as IRaiseEvent).RaiseNewEvent();
            //        break;
            //}
        }

        #endregion

        #region :: CreateDefaultView :: Default GridView를 생성합니다.

        /// <summary>
        /// Default GridView를 생성합니다.
        /// </summary>
        /// <returns></returns>
        protected override DevExpress.XtraGrid.Views.Base.BaseView CreateDefaultView()
        {
            return CreateView("PGridView");
        }

        #endregion

        #region :: OnClick :: 그리드의 Check Column 클릭했을 때 발생시킵니다.

        /// <summary>
        /// 그리드의 Check Column 클릭했을 때 발생시킵니다.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClick(EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi =
                (DefaultView as GridView).CalcHitInfo((this as Control).PointToClient(Control.MousePosition));

            GridColumn focusedColumn = hi.Column;

            if (focusedColumn == null || focusedColumn.ColumnEdit == null || DefaultView.RowCount == 0 || !focusedColumn.OptionsColumn.AllowEdit
                || focusedColumn.ColumnEdit.EditorTypeName != "CheckEdit") return;

            GridView defaultView = DefaultView as GridView;

            if (defaultView == null) return;

            RepositoryItemCheckEdit edit = focusedColumn.ColumnEdit as RepositoryItemCheckEdit;

            object val = _checkAll ? edit.ValueUnchecked : edit.ValueChecked;

            //if (focusedColumn.FieldName == AppConfig.CHECKCOLUMNNAME && hi.RowHandle < 0)
            if (hi.HitTest == DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.Column && hi.RowHandle < 0)
            {
                focusedColumn.SortOrder = DevExpress.Data.ColumnSortOrder.None;

                for (int rowHandle = 0; rowHandle < DefaultView.RowCount; rowHandle++)
                {
                    if (defaultView.GetRowCellValue(rowHandle, focusedColumn.FieldName) == null) continue;
                    if (defaultView.GetRowCellValue(rowHandle, focusedColumn.FieldName).ToString() == val.ToString()) continue;

                    defaultView.SetRowCellValue(rowHandle, focusedColumn.FieldName, val);

                    if (defaultView.GetDataRow(rowHandle) == null) continue;

                    if (focusedColumn.FieldName == AppConfig.CHECKCOLUMNNAME) defaultView.GetDataRow(rowHandle).AcceptChanges();
                }

                _checkAll = !_checkAll;
            }

            base.OnClick(e);
        }

        #endregion

        #region :: RegisterAvailableViewsCore :: GridView 정보를 등록합니다.

        /// <summary>
        /// GridView 정보를 등록합니다.
        /// </summary>
        /// <param name="collection"></param>
        protected override void RegisterAvailableViewsCore(DevExpress.XtraGrid.Registrator.InfoCollection collection)
        {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new PGridViewInfoRegistrator());
            collection.Add(new PBandedGridViewInfoRegistrator());
            collection.Add(new PAdvBandedGridViewInfoRegistrator());
        }

        #endregion
    }
}
