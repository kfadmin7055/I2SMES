using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraVerticalGrid.Rows;
using EBAP.Core;
using EBAP.Core.Info;
using EBAP.Core.Interface;

namespace EBAP.Win.ControlLibrary
{
    /// <summary>
    /// Vertical Grid Control 입니다.
    /// DevExpress Vertical GridControl을 Wrapping 하여 사용합니다.
    /// </summary>
    /// <remarks>
    /// 2023-02-01 최초생성 : 오인봉
    /// 변경내역
    /// 
    /// </remarks>
    [ToolboxItem(true)]
    public partial class PVGridControl : DevExpress.XtraVerticalGrid.VGridControl, IInitEditValue, IFillData, IInitVerticalRow, IExport, IPrint
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// Vertical Grid Control을 생성합니다.
        /// </summary>
        public PVGridControl()
        {
            InitializeComponent();
        }

        private int ROWHEIGHT = 28;

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
        /// Vertical GridControl의 데이터를 채웁니다.
        /// </summary>
        public void FillData()
        {
            using (DataSet ds = new DataSet())
            {
                DataTable dt = ds.MakeDataTableScheme(GetRowField());
                ds.Tables.Add(dt);

                FillData(ds, ds.Tables[0].TableName);
            }
        }

        /// <summary>
        /// Vertical GridControl의 데이터를 채웁니다.
        /// </summary>
        /// <param name="ds"></param>
        public void FillData(DataSet ds)
        {
            FillData(ds, ds.Tables[0].TableName);
        }

        /// <summary>
        /// Vertical GridControl의 데이터를 채웁니다.
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        public void FillData(DataSet ds, string tableName)
        {
            DataMember = string.Empty;

            DataSource = ds;
            DataMember = tableName;

            foreach (BaseRow row in Rows)
            {
                if (row.Properties.RowEdit is RepositoryItemCheckEdit)
                {
                    if (ds.Tables[tableName].Columns.Contains(row.Properties.FieldName))
                        ds.Tables[tableName].Columns[row.Properties.FieldName].DataType = Type.GetType("System.Boolean");
                    else
                        ds.Tables[tableName].Columns.Add(row.Properties.FieldName, Type.GetType("System.Boolean"));
                }
            }
        }

        #endregion

        #region IInitVerticalRow 멤버

        /// <summary>
        /// Vertical GridControl Row 를 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Field Name</param>
        /// <param name="caption">Row Header Text</param>
        public void InitRow(string fieldName, string caption)
        {
            InitRow(fieldName, caption, 75);
        }

        /// <summary>
        /// Vertical GridControl Row 를 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Field Name</param>
        /// <param name="caption">Row Header Text</param>
        /// <param name="width"></param>
        public void InitRow(string fieldName, string caption, int width)
        {
            InitRow(fieldName, caption, width, false, true);
        }

        /// <summary>
        /// Vertical GridControl Row 를 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Field Name</param>
        /// <param name="caption">Row Header Text</param>
        /// <param name="width"></param>
        /// <param name="allowEdit"></param>
        /// <param name="visible">Row 숨김/보임 여부</param>
        public void InitRow(string fieldName, string caption, int width, bool allowEdit, bool visible)
        {
            InitRow(fieldName, caption, width, allowEdit, visible, DataType.Default);
        }

        /// <summary>
        /// Vertical GridControl Row 를 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Field Name</param>
        /// <param name="caption">Row Header Text</param>
        /// <param name="width"></param>
        /// <param name="allowEdit"></param>
        /// <param name="visible">Row 숨김/보임 여부</param>
        /// <param name="dataType">Row DataType</param>
        public void InitRow(string fieldName, string caption, int width, bool allowEdit, bool visible, DataType dataType)
        {
            InitRow(fieldName, caption, width, 0, allowEdit, visible, dataType, HorzAlign.Default);
        }

        /// <summary>
        /// Vertical GridControl Row 를 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Field Name</param>
        /// <param name="caption">Row Header Text</param>
        /// <param name="width"></param>
        /// <param name="allowEdit"></param>
        /// <param name="visible">Row 숨김/보임 여부</param>
        /// <param name="dataType">Row DataType</param>
        /// <param name="horzAlign">Row Cell 정렬</param>
        public void InitRow(string fieldName, string caption, int width, bool allowEdit, bool visible, DataType dataType, HorzAlign horzAlign)
        {
            InitRow(fieldName, caption, width, 0, allowEdit, visible, dataType, horzAlign);
        }

        /// <summary>
        /// Vertical GridControl Row 를 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Field Name</param>
        /// <param name="caption">Row Header Text</param>
        /// <param name="width"></param>
        /// <param name="decimalPlace">소숫점 길이 수, 기본값 0</param>
        /// <param name="allowEdit"></param>
        /// <param name="visible">Row 숨김/보임 여부</param>
        /// <param name="dataType">Row DataType</param>
        /// <param name="horzAlign">Row Cell 정렬</param>
        public void InitRow(string fieldName, string caption, int width, int decimalPlace, bool allowEdit, bool visible, DataType dataType, HorzAlign horzAlign)
        {
            EBAP.Core.Localization.LocaleConverter locale = (FindForm() as ILocaleConverter).LOCALECONVERTER;

            if (locale == null) return;

            BaseRow gridRow;

            bool existRow = base.Rows[fieldName] == null ? false : true;

            if (existRow)
                gridRow = base.Rows[fieldName];
            else
                gridRow = new EditorRow();

            gridRow.Name = fieldName;
            gridRow.Properties.FieldName = fieldName;
            gridRow.Properties.Caption = locale.GetLocaleString(caption);
            gridRow.Properties.AllowEdit = allowEdit;

            gridRow.Height = ROWHEIGHT;

            if (!existRow)
                Rows.Add(gridRow);

            gridRow.Visible = visible;

            ControlUtil.SetRowType(gridRow, dataType, decimalPlace);

            gridRow.Appearance.Options.UseTextOptions = true;

            switch (horzAlign)
            {
                case HorzAlign.Default:
                    gridRow.Appearance.TextOptions.HAlignment = HorzAlignment.Default;
                    break;
                case HorzAlign.Center:
                    gridRow.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
                    break;
                case HorzAlign.Far:
                    gridRow.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
                    break;
                case HorzAlign.Near:
                    gridRow.Appearance.TextOptions.HAlignment = HorzAlignment.Near;
                    break;
            }
        }
        /// <summary>
        /// Vertical GridControl MultiEditor Row 를 초기화합니다.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="fieldnames">Multi Editor Row Name</param>
        /// <param name="captions">Captions</param>
        public void InitMultiEditorRow(string name, string[] fieldnames, string[] captions)
        {
            bool existRow = existRow = Rows[name] == null ? false : true;
            bool exist = false;
            MultiEditorRow row = existRow ? (Rows[name] as MultiEditorRow) : new MultiEditorRow();
            row.Name = name;

            row.Appearance.TextOptions.HAlignment = HorzAlignment.Center;

            for (int i = 0; i < fieldnames.Length; i++)
            {
                exist = row.PropertiesCollection[fieldnames[i]] == null ? false : true;

                MultiEditorRowProperties rowP = null;

                if (exist)
                    rowP = row.PropertiesCollection[fieldnames[i]];
                else
                    rowP = new MultiEditorRowProperties { Name = fieldnames[i], FieldName = fieldnames[i], Caption = captions[i], Width = 80, AllowEdit = false };

                if (!exist) row.PropertiesCollection.Add(rowP);
            }
            row.Height = ROWHEIGHT;

            if (!existRow) Rows.Add(row);
        }

        /// <summary>
        /// Vertical GridControl Category Row 를 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Field Name</param>
        /// <param name="caption">Caption</param>
        public void InitCategoryRow(string fieldName, string caption)
        {
            CategoryRow row = new CategoryRow { Height = ROWHEIGHT };
            row.Properties.FieldName = fieldName;
            row.Properties.Caption = caption;
            Rows.Add(row);
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


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Private)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: GetRowField :: Row Filed를 가져옵니다.

        /// <summary>
        /// Column Filed를 가져옵니다.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉(msNib)
        /// 변경내역
        /// 
        /// </remarks>
        private string[] GetRowField()
        {
            List<string> rowFileds = new List<string>();

            foreach (BaseRow row in Rows)
            {
                rowFileds.Add(row.Properties.FieldName);
            }

            return rowFileds.ToArray();
        }

        #endregion



        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Control Event Handler
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: PVGridControl_CustomDrawRowHeaderCell :: Header 색을 변경합니다.

        /// <summary>
        /// Header 색을 변경합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PVGridControl_CustomDrawRowHeaderCell(object sender, DevExpress.XtraVerticalGrid.Events.CustomDrawRowHeaderCellEventArgs e)
        {
            try
            {
                if (e.Row == null) return;

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

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: CopyToClipboard :: Ctrl + C 기능을 재정의 합니다.

        /// <summary>
        /// Ctrl + C 기능을 재정의 합니다.
        /// </summary>
        public override void CopyToClipboard()
        {
            OptionsBehavior.CopyToClipboardWithRowHeaders = false;
            base.CopyToClipboard();
        }

        #endregion
    }
}