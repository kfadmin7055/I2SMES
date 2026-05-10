using DevExpress.Spreadsheet;
using EBAP.Core.Info;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;

namespace EBAP.Win.ControlLibrary
{
    /// <summary>
    /// Spread Sheet Control 입니다.
    /// DevExpress SpreadsheetControl을 Wrapping 하여 사용합니다.
    /// </summary>
    /// <remarks>
    /// 2023-02-01 최초생성 : 오인봉
    /// 변경내역
    ///
    /// </remarks>
    [ToolboxItem(true)]
    public partial class PSpreadsheetControl : DevExpress.XtraSpreadsheet.SpreadsheetControl
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// Spreadsheet Control을 생성합니다.
        /// </summary>
        /// 
        public PSpreadsheetControl()
        {
            InitializeComponent();
        }

        #endregion

        /// <summary>
        /// 인덱스로 세팅
        /// </summary>
        /// <param name="sheetNum"></param>
        public Worksheet GetDocument(int sheetNum)
        {
            IWorkbook workbook = Document;

            Worksheet sheet = workbook.Worksheets[sheetNum];

            return sheet;
        }

        /// <summary>
        /// 워크시트명으로 세팅
        /// </summary>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        public Worksheet GetDocument(string sheetName)
        {
            IWorkbook workbook = Document;
            Worksheet sheet = workbook.Worksheets[sheetName];

            return sheet;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="srange"></param>
        /// <param name="sheetNum"></param>
        public void SetDeleteRange(string srange, int sheetNum = 0)
        {
            IWorkbook workbook = Document;
            Worksheet sheet = workbook.Worksheets[sheetNum];

            CellRange range = sheet.Range[srange];

            sheet.DeleteCells(range, DeleteMode.EntireRow);
        }

        /// <summary>
        /// 시트 추가 후 첫번째 시트 복사
        /// </summary>
        /// <param name="sheetNum"></param>
        public void SetAddSheetToCopy(int sheetNum = 0)
        {
            IWorkbook workbook = Document;

            workbook.Worksheets.Add();

            Worksheet sheet = workbook.Worksheets[0];

            Worksheet copysheet = workbook.Worksheets[sheetNum + 1];

            copysheet.CopyFrom(sheet);
        }

        /// <summary>
        /// 시트 추가 후 특정시트 내용 복사 
        /// </summary>
        /// <param name="sheetNum"></param>
        /// <param name="copyFrom"></param>
        /// <param name="addName"></param>
        public void SetAddSheetToCopyPosition(int sheetNum = 0, int copyFrom = 0, int addName = 0)
        {
            IWorkbook workbook = Document;

            //workbook.Worksheets.Add();

            workbook.Worksheets.Insert(sheetNum);

            Worksheet sheet = workbook.Worksheets[copyFrom];

            Worksheet copysheet = workbook.Worksheets[sheetNum];

            copysheet.CopyFrom(sheet);
            copysheet.Name = String.Format("{0}({1})", workbook.Worksheets[copyFrom].Name, addName);
        }

        /// <summary>
        /// 시트 삭제 
        /// </summary>
        /// <param name="sheetNum"></param>
        public void SetRemoveSheet(int sheetNum)
        {
            IWorkbook workbook = Document;

            workbook.Worksheets.RemoveAt(sheetNum);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ds"></param>
        public void FillData(DataSet ds)
        {
            FillData(ds, ds.Tables[0].TableName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        public void FillData(DataSet ds, string tableName)
        {
            FillData(ds, tableName, 1, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        /// <param name="rowIndex"></param>
        /// <param name="colIndex"></param>
        /// <param name="sheetNum"></param>
        public void FillData(DataSet ds, string tableName, int rowIndex, int colIndex, int sheetNum = 0)
        {
            IWorkbook workbook = Document;
            Worksheet sheet = workbook.Worksheets[sheetNum];

            sheet.DataBindings.BindToDataSource(ds.Tables[tableName], rowIndex, colIndex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowOffset"></param>
        /// <param name="colOffset"></param>
        /// <param name="value"></param>
        /// <param name="sheetNum"></param>
        /// <param name="dataType"></param>
        /// <param name="iPoint"></param>
        public void SetCellValue(int rowOffset, int colOffset, object value, int sheetNum = 0, DataType dataType = DataType.Default, int iPoint = 0)
        {
            IWorkbook workbook = Document;
            Worksheet sheet = workbook.Worksheets[sheetNum];

            sheet.Cells[rowOffset, colOffset].SetValue(value);

            if (dataType != DataType.Number)
                return;

            switch (iPoint)
            {
                case 4:
                    sheet.Cells[rowOffset, colOffset].NumberFormat = "0.0000";
                    break;
                case 5:
                    sheet.Cells[rowOffset, colOffset].NumberFormat = "0.00000";
                    break;
                default:
                    sheet.Cells[rowOffset, colOffset].NumberFormat = "0.000";
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sRange"></param>
        /// <param name="value"></param>
        /// <param name="protection"></param>
        /// <param name="sheetNum"></param>
        /// <param name="iPoint"></param>
        /// <param name="dataType"></param>
        public void SetCellValue(string sRange, object value, bool protection = false, int sheetNum = 0, int iPoint = 0, DataType dataType = DataType.Default)
        {
            IWorkbook workbook = Document;
            Worksheet sheet = workbook.Worksheets[sheetNum];
            CellRange range = sheet.Range[sRange];

            if (dataType == DataType.CheckEdit)
            {
                sheet.CustomCellInplaceEditors.Add(range, CustomCellInplaceEditorType.CheckBox);
                range.SetValue(value.ToString().Trim());

                return;
            }

            range.SetValue(value.ToString().Trim());

            if (dataType != DataType.Number)
                return;

            switch (iPoint)
            {
                case 4:
                    range.NumberFormat = "0.0000";
                    break;
                case 5:
                    range.NumberFormat = "0.00000";
                    break;
                default:
                    range.NumberFormat = "0.000";
                    break;
            }

            //if (protection == true)
            //{
            //    Random rnd = new Random();

            //    ProtectedRange protectedRange = null;

            //    protectedRange = sheet.ProtectedRanges.Add(string.Format("A{0}B", rnd.Next(9999).ToString()), range);
            //}
        }

        /// <summary>
        /// Cell Value
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="sheetNum"></param>
        /// <returns></returns>
        public object GetCellValue(int row, int col, int sheetNum = 0)
        {
            IWorkbook workbook = Document;
            Worksheet sheet = workbook.Worksheets[sheetNum];

            return sheet.Cells[row, col].Value;
        }

        /// <summary>
        /// Range 포인트의 값을 가져 옵니다.
        /// </summary>
        /// <param name="sRange"></param>
        /// <param name="sheetNum"></param>
        /// <returns></returns>
        public object GetCellValue(string sRange, int sheetNum = 0)
        {
            IWorkbook workbook = Document;
            Worksheet sheet = workbook.Worksheets[sheetNum];

            CellRange range = sheet.Range[sRange];

            return range.Value;
        }

        /// <summary>
        /// 파일명 생성
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="format"></param>
        public void SetSaveFileName(string fileName, string format = "xlsx")
        {
            IWorkbook workbook = Document;

            DocumentFormat df;

            switch (format)
            {
                case "xlsx":
                    df = DevExpress.Spreadsheet.DocumentFormat.Xlsx;
                    break;
                case "xls":
                    df = DevExpress.Spreadsheet.DocumentFormat.Xls;
                    break;
                default:
                    df = DevExpress.Spreadsheet.DocumentFormat.Xlsx;
                    break;
            }

            workbook.SaveDocument(String.Format("{0}.{1}", fileName, format), df);
        }

        /// <summary>
        /// Range Merge
        /// </summary>
        /// <param name="iColIdx"></param>
        /// <param name="iStart"></param>
        /// <param name="iEnd"></param> 
        /// <param name="sheetNum"></param>
        public void RangeMerge(int iColIdx, int iStart, int iEnd, int sheetNum = 0)
        {
            IWorkbook workbook = Document;
            Worksheet sheet = workbook.Worksheets[sheetNum];

            string sStartRange = String.Format("{0}{1}", sheet.Columns[iColIdx].Heading, iStart + 1);
            string sEndRange = String.Format("{0}{1}", sheet.Columns[iColIdx].Heading, iEnd + 1);

            CellRange range = sheet.Range[String.Format("{0}:{1}", sStartRange, sEndRange)];
            range.Merge();

            range.Style.Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
            range.Style.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Left;
        }

        /// <summary>
        /// 각 Cell 설정
        /// </summary>
        /// <param name="iColIdx"></param>
        /// <param name="caption"></param>
        /// <param name="width"></param>
        /// <param name="sheetNum"></param>
        public void InitColumn(int iColIdx, string caption, int width, int sheetNum = 0)
        {
            IWorkbook workbook = Document;
            Worksheet sheet = workbook.Worksheets[sheetNum];

            // Head 설정
            sheet.Cells[0, iColIdx].SetValue(caption);
            sheet.Cells[0, iColIdx].FillColor = System.Drawing.Color.FromArgb(50, 90, 174, 255);
            sheet.Cells[0, iColIdx].Font.Color = System.Drawing.Color.FromArgb(50, 255, 255, 255);
            sheet.Cells[0, iColIdx].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
            sheet.Cells[0, iColIdx].Style.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
            sheet.Columns[iColIdx].ColumnWidth = width;
            sheet.Columns[iColIdx].RowHeight = 100;

            //sheet.Cells[0, iColIdx].Areas.
        }

        /// <summary>
        /// 각 Cell 설정
        /// </summary>
        /// <param name="sRange"></param>
        /// <param name="caption"></param>
        /// <param name="width"></param>
        /// <param name="sheetNum"></param>
        public void InitColumn(string sRange, string caption, int width, int sheetNum = 0)
        {
            IWorkbook workbook = Document;
            Worksheet sheet = workbook.Worksheets[sheetNum];

            CellRange range = sheet.Range[sRange];

            // Head 설정
            range.SetValue(caption);
            range.FillColor = System.Drawing.Color.FromArgb(50, 90, 174, 255);
            range.Font.Color = System.Drawing.Color.FromArgb(50, 255, 255, 255);
            range.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
            range.Style.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
            range.ColumnWidth = width;

            range.RowHeight = 100;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="iPoint"></param>
        public void setColumnType(DataType dataType, int iPoint)
        {
            switch (dataType)
            {
                case DataType.Number:
                    switch (iPoint)
                    {
                        case 4:

                            break;
                    }
                    break;
            }
        }

        /// <summary>
        /// 인덱스로 해당 Cell 락 설정
        /// </summary>
        /// <param name="iRowIdx"></param>
        /// <param name="iCellIdx"></param>
        /// <param name="bLocked">false : 수정 안되게</param>
        /// <param name="sheetNum"></param>
        public void SetProtectedRowCellIdx(int iRowIdx, int iCellIdx, bool bLocked, int sheetNum = 0)
        {
            IWorkbook workbook = Document;
            Worksheet sheet = workbook.Worksheets[sheetNum];

            //Range range = sheet.Range["A1:A5"];

            //ProtectedRange protectedRange = sheet.ProtectedRanges.Add("", range);

            ////protectedRange.

            //if (!sheet.IsProtected)
            //    sheet.Protect("ABC", WorksheetProtectionPermissions.Default);

            Protection p = sheet.Cells[iRowIdx, iCellIdx].Protection;  // 이건 Range 는 안 됨  

            p.Locked = bLocked;

            if (!sheet.IsProtected)
                sheet.Protect("PassWord", WorksheetProtectionPermissions.Default);
        }

        /// <summary>
        /// 인덱스로 해당 Cell 락 설정
        /// </summary>
        /// <param name="sName"></param>
        /// <param name="startHeading"></param>
        /// <param name="startRowIdx"></param>
        /// <param name="endHeading"></param>
        /// <param name="endRowIdx"></param>
        /// <param name="sheetNum"></param>
        public void SetProtectedRange(string sName, string startHeading, int startRowIdx, string endHeading, int endRowIdx, int sheetNum = 0)
        {
            IWorkbook workbook = Document;
            Worksheet sheet = workbook.Worksheets[sheetNum];

            //Range range = sheet.Range["A1:A5"];

            ProtectedRange protectedRange = sheet.ProtectedRanges.Add(sName, sheet.Range[$"{startHeading}{startRowIdx}:{endHeading}{endRowIdx}"]);

            if (!sheet.IsProtected)
                sheet.Protect("PassWord", WorksheetProtectionPermissions.Default);
        }

        /// <summary>
        /// 엑셀 시트 락 설정
        /// </summary>
        /// <param name="password"></param>
        /// <param name="sheetNum"></param>
        public void SetExcelProtected(int sheetNum = 0, string password = "")
        {
            IWorkbook workbook = Document;
            Worksheet sheet = workbook.Worksheets[sheetNum];

            //if (!workbook.IsProtected) 
            //    workbook.Protect(password, true, true);

            sheet.Cells.Protection.Locked = true;

            if (!sheet.IsProtected)
                ActiveWorksheet.Protect(password, WorksheetProtectionPermissions.Default | WorksheetProtectionPermissions.Objects);
        }

        /// <summary> 
        /// Range 로 배경색 설정
        /// </summary>
        /// <param name="startHeading"></param>
        /// <param name="startRowIdx"></param>
        /// <param name="endHeading"></param>
        /// <param name="endRowIdx"></param>
        /// <param name="color"></param>
        /// <param name="sheetNum"></param>
        public void SetRangeColor(string startHeading, int startRowIdx, string endHeading, int endRowIdx, Color color, int sheetNum = 0)
        {
            IWorkbook workbook = Document;
            Worksheet sheet = workbook.Worksheets[sheetNum];

            CellRange range = sheet.Range[$"{startHeading}{startRowIdx}:{endHeading}{endRowIdx}"];

            range.FillColor = color;
        }

        /// <summary>
        /// 한 Cell 마다 배경색 설정
        /// </summary>
        /// <param name="srange"></param>
        /// <param name="color"></param>
        /// <param name="protection"></param>
        /// <param name="sheetNum"></param>
        public void SetRangeColor(string srange, Color color, bool protection = false, int sheetNum = 0)
        {
            IWorkbook workbook = Document;
            Worksheet sheet = workbook.Worksheets[sheetNum];

            CellRange range = sheet.Range[srange];

            //if (protection == true)
            //{
            //    Random rnd = new Random();

            //    ProtectedRange protectedRange = null;

            //    protectedRange = sheet.ProtectedRanges.Add(string.Format("A{0}B", rnd.Next(9999).ToString()), range);
            //}

            range.FillColor = color;
        }

        /// <summary>
        /// 한 Cell 마다 배경색 설정
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="color"></param>
        /// <param name="sheetNum"></param>
        public void SetRangeColor(int row, int col, Color color, int sheetNum = 0)
        {
            IWorkbook workbook = Document;
            Worksheet sheet = workbook.Worksheets[sheetNum];

            sheet.Cells[row, col].FillColor = color;
        }

        /// <summary>
        /// 고정틀
        /// </summary>
        /// <param name="Range">C : Col, R: Row, P : Panes</param>
        /// <param name="ioffSet"></param>
        /// <param name="sheetNum"></param>
        public void SetFreeze(string Range, int ioffSet, int sheetNum = 0)
        {
            IWorkbook workbook = Document;
            Worksheet sheet = workbook.Worksheets[sheetNum];

            switch (Range)
            {
                case "C":
                    sheet.FreezeColumns(ioffSet);
                    break;

                case "R":
                    sheet.FreezeRows(ioffSet);
                    break;
                case "P":
                    sheet.FreezePanes(0, ioffSet);
                    break;
            }
        }

        ///// <summary>
        ///// Document를 Excel Format 으로 설정합니다.
        ///// </summary>
        ///// <param name="data"></param>
        //public void SetDocumentFromBinary(byte[] data)
        //{
        //    MemoryStream ms = new MemoryStream(data);

        //    IWorkbook workbook = Document;
        //    workbook.LoadDocument(data);
        //}

        /// <summary>
        /// 사용 칸에 Line 설정
        /// </summary>
        /// <param name="startHeading"></param>
        /// <param name="startRowIdx"></param>
        /// <param name="endHeading"></param>
        /// <param name="endRowIdx"></param>
        /// <param name="sheetNum"></param>
        public void SetBordersLine(string startHeading, int startRowIdx, string endHeading, int endRowIdx, int sheetNum = 0)
        {
            IWorkbook workbook = Document;
            Worksheet sheet = workbook.Worksheets[sheetNum];

            CellRange range = sheet.Range[$"{startHeading}{startRowIdx}:{endHeading}{endRowIdx}"];

            range.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin);
        }

        /// <summary>
        /// Sheet 내 전체 Data 초기화
        /// </summary>
        /// <param name="sheetNum"></param>
        public void SheetClear(int sheetNum = 0)
        {
            IWorkbook workbook = Document;
            Worksheet sheet = workbook.Worksheets[sheetNum];

            CellRange range = sheet.Range["A1:XFD1048576"];

            sheet.Clear(range);
        }

        /// <summary>
        /// Sheet 내 Row 삭제
        /// </summary>
        /// <param name="startRow"></param>
        /// <param name="endRow"></param>
        /// <param name="sheetNum"></param>
        public void SheetRowDelete(int startRow, int endRow = 0, int sheetNum = 0)
        {
            if (endRow == 0) endRow = 1048576;

            IWorkbook workbook = Document;
            Worksheet sheet = workbook.Worksheets[sheetNum];

            sheet.Range[$"A{startRow}:XFD{endRow}"].Delete();
        }

        /// <summary>
        /// 사진 첨부
        /// </summary>
        /// <param name="sheetNum"></param>
        /// <param name="image"></param>
        /// <param name="range"></param>
        public void SetPictures(int sheetNum, Image image, string range)
        {
            IWorkbook workbook = Document;
            Worksheet sheet = workbook.Worksheets[sheetNum];

            Cell cell = sheet.Cells[range];

            sheet.Pictures.AddPicture(image, cell);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sheetNum"></param>
        /// <param name="range"></param>
        /// <param name="memo"></param>
        public void SetComment(int sheetNum, string range, string memo)
        {
            IWorkbook workbook = Document;
            Worksheet sheet = workbook.Worksheets[sheetNum];

            Cell cell = sheet.Cells[range];

            sheet.Comments.Add(cell, "system", memo);
        }
    }
}