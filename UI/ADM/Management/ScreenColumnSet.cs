#region 어셈블리 EBAP.UI.ADM.Management, v3.17
// C:\EBAP.NET\EBAP.UI.ADM.dll
// CLR Version : 4.0.30319.36415
#endregion

using DevExpress.XtraGrid.Views.Grid;
using EBAP.Business.WSBiz;
using EBAP.Core.Info;
using EBAP.Data.CodeUtil;
using System;
using System.Collections.Generic;
using System.Data;

namespace EBAP.UI.ADM.Management
{
    #region :: EBAP.UI.ADM.Management.ScreenColumnSet ::

    /// <summary>
    /// Form의 업무내용을 기술합니다.
    /// </summary>
    /// <remarks>
    /// Comment     : Form 기능 및 특이사항 기록
    ///               1.  
    ///               2. 
    /// History     :
    ///               1. (2018-04-11 오후 2:42:58 - 오인봉 - PC170245) : 최초 생성
    ///               2.
    ///               3.
    /// </remarks>
    public partial class ScreenColumnSet : EBAP.Win.BaseFrame.UIFrame
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// ScreenColumnSet Form을 생성합니다.
        /// </summary>
        public ScreenColumnSet()
        {
            InitializeComponent();

            AppConfig.CurrentDB = ConnectionString.METADB;
        }

        #endregion

        #region :: 전역변수 ::


        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler(Common Event)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: ScreenColumnSet_Load :: Form이 Load 시 발생합니다.

        /// <summary>
        /// Form이 Load 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenColumnSet_Load(object sender, EventArgs e)
        {
            try
            {
                InitLocalization();
                InitGlobalInstance();
                InitGridControl();
                InitComboBox();
                InitControls();

                // Form Load 후 조회를 실행해야 한다면 주석을 제거하세요.
                IsLoadSelectEvent = true;
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        #region :: ScreenColumnSet_Authentication :: 사용자 권한 처리 시 발생합니다.

        /// <summary>
        /// 사용자 권한 처리 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenColumnSet_Authentication(object sender, EventArgs e)
        {
            try
            {
                UserAuthProcess();
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        #region :: ScreenColumnSet_Link :: Form 간 Data 전송 시 발생합니다.

        /// <summary>
        /// Form 간 Data 전송 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenColumnSet_Link(object sender, EventArgs e)
        {
            try
            {
                LinkData();

                // Link 후 조회를 실행해야 한다면 주석을 제거하세요.
                //RaiseSelectEvent();
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        #region :: ScreenColumnSet_Selection :: MainForm의 조회 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 조회 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenColumnSet_Selection(object sender, EventArgs e)
        {
            try
            {
                SetFormLayout();
                SetGridLayout();
                SelectionData();
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        #region :: ScreenColumnSet_New :: MainForm의 신규 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 신규 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenColumnSet_New(object sender, EventArgs e)
        {
            try
            {
                NewData();
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        #region :: ScreenColumnSet_Delete :: MainForm의 삭제 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 삭제 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenColumnSet_Delete(object sender, EventArgs e)
        {
            try
            {
                DeleteData();

                // 삭제 후 조회를 실행해야 한다면 주석을 제거하세요.
                //RaiseSelectEvent();

                // 삭제 후 Check 된 ROW 만 삭제하려면 주석을 제거하세요(DB 접속 필요없을 경우)
                viewList.RemoveCheckedRow();
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        #region :: ScreenColumnSet_Save :: MainForm의 저장 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 저장 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenColumnSet_Save(object sender, EventArgs e)
        {
            try
            {
                SaveData();
                SaveDetailData();

                // 저장 후 조회를 실행해야 한다면 주석을 제거하세요.
                //RaiseSelectEvent();
                DataRow dr = (tlMenu.GetDataRecordByNode(tlMenu.FocusedNode) as DataRowView).Row;
                string screenId = dr["SCREENID"].ToString();

                SelectionGridData(screenId);


                // 저장 후 DataTable에 변경사항만 처리할 경우 주석을 제거하세요(DB 접속 필요없을 경우)
                //viewList.AcceptChanges();
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        #region :: ScreenColumnSet_Chart :: MainForm의 Chart Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 Chart Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenColumnSet_Chart(object sender, EventArgs e)
        {
            try
            {
                ChartData();
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler(Control Event)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: ComboBox_EditValueChanged :: ComboBox 값을 변경하면 발생합니다.

        /// <summary>
        /// ComboBox 값을 변경하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                // 여기에 코드를 입력합니다.
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        #region :: GridView_InitNewRow :: 신규로 생성되는 Row의 기본값을 정의합니다.

        /// <summary>
        /// 신규로 생성되는 Row의 기본값을 정의합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                DataRow dr = (tlMenu.GetDataRecordByNode(tlMenu.FocusedNode) as DataRowView).Row;

                viewList.SetRowCellValue(e.RowHandle, "SCREENID", dr["SCREENID"]);
                viewList.SetRowCellValue(e.RowHandle, "SCREENNAME", dr["SCREENNAME"]);
                viewList.SetRowCellValue(e.RowHandle, "GRIDNAME", "viewList");
                viewList.SetRowCellValue(e.RowHandle, "IDX", viewList.RowCount);
                viewList.SetRowCellValue(e.RowHandle, "WIDTH", 90);
                viewList.SetRowCellValue(e.RowHandle, "MAXLENGTH", 0);
                viewList.SetRowCellValue(e.RowHandle, "DECIMALPLACE", 0);
                viewList.SetRowCellValue(e.RowHandle, "ALLOWEDIT", false);
                viewList.SetRowCellValue(e.RowHandle, "VISIBLE", true);
                viewList.SetRowCellValue(e.RowHandle, "DATATYPE", "Default");
                viewList.SetRowCellValue(e.RowHandle, "HORIZONALIGN", "Default");
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        #region :: viewList_CustomRowCellEditForEditing :: 클릭하면 해당 CELL을 Combo로 표시합니다.

        /// <summary>
        /// 클릭하면 해당 CELL을 Combo로 표시합니다. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewList_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            //DataRow dr = viewList.GetFocusedDataRow();

            //if (dr == null || e.Column.FieldName != "COLUMNNAME") return;

            //string siteId = dr["COLUMN"].ToString();

            //e.RepositoryItem = ControlUtil.MakeComboBoxCell(FPCode.GetResourceName(GBM, ORGANIZATIONID, siteId));
        }

        #endregion

        #region :: tlMenu_FocusedNodeChanged :: 메뉴의 Focused Node가 변경되면 해당 MENU의 컬럼을 보여줍니다.

        /// <summary>
        /// 메뉴의 Focused Node가 변경되면 해당 MENU의 컬럼을 보여줍니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlMenu_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            viewList.ViewCaption = "컬럼을 설정할 메뉴를 클릭하세요";

            if (e.OldNode == null) return;

            viewPreview.Columns.Clear();

            DataRow dr = (tlMenu.GetDataRecordByNode(e.Node) as DataRowView).Row;
            string screenId = dr["SCREENID"].ToString();
            string className = dr["CLASSNAME"].ToString();

            if (className == string.Empty)
            {
                viewList.ViewCaption = "Class가 등록되지 않은 메뉴는 등록할 수 없어요.";
                gridList.Enabled = false;
                return;
            }
            else
            {
                viewList.ViewCaption = String.Format("SCREEN ID : [ {0} ] - SCREEN 명 : [ {1} ]", dr["SCREENID"], dr["SCREENNAME"]);
                gridList.Enabled = true;
            }
            InitEditValue();

            SelectionGridData(screenId);
        }

        /// <summary>
        /// 조회 처리 Method
        /// </summary>
        private void SelectionGridData(string screenId)
        {
            DataSet ds;
            const string queryId = @"dbo.ScreenColumnSet_Select";

            string[] paramList = new string[] { "@SCREENID" };

            object[] valueList = new object[] { screenId };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            }

            gridList.FillData(ds);

            //InitDataBindings(ds);
        }

        ///// <summary>
        ///// 컨트롤과 데이터를 바인딩합니다.
        ///// </summary>
        //private void InitDataBindings(DataSet ds)
        //{
        //    //DataTable dt = ds.Tables[0];

        //    //chkSelect.BindingMapping(dt, "USESELECTCOLUMN");
        //    //cboKeyColumn.BindingMapping(dt, "KEYCOLUMNS");
        //    //cboMandatoryColumn.BindingMapping(dt, "MANDATORYCOLUMNS");
        //    //cboNewRowEnableColumn.BindingMapping(dt, "NEWROWENABLECOLUMNS");
        //    //cboNewRowCopyColumn.BindingMapping(dt, "NEWROWCOPYCOLUMNS");
        //}

        #endregion

        #region :: viewMaster_FocusedRowChanged :: Master View Focused Row가 변경되면 Preview의 Grid를 Setting 합니다.

        /// <summary>
        /// Master View Focused Row가 변경되면 Preview의 Grid를 Setting 합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                viewPreview.ViewCaption = String.Format("미리보기 컨트롤 : [ {0} ] ", string.Empty);
                DataRow dr = viewList.GetFocusedDataRow();
                if (dr == null) return;

                viewPreview.ViewCaption = String.Format("미리보기 컨트롤 : [ {0} ] ", dr["GRIDNAME"]);
                //layoutControlGroup3.Text = String.Format("Detail 설정 : [ {0} ] ", dr["SCREENID"], dr["SCREENNAME"], dr["GRIDNAME"]);

                layoutControlGroup3.Text = String.Format("Detail 설정 - 메뉴 ID : [ {0} ] - SCREEN 명 : [ {1} ] - 컨트롤 이름 : [ {2} ]",
                                                                                    dr["SCREENID"], dr["SCREENNAME"], dr["GRIDNAME"]);
                //InitDatabaseConnection();
                //SelectionDetailData(dr["CODEVALUE"].ToString());

                DataRow[] drs = viewList.GetDataTableByDataSource().Select(String.Format("GRIDNAME = '{0}'", dr["GRIDNAME"]));

                List<object> valueList = new List<object>();
                List<string> displayList = new List<string>();

                foreach (DataRow col in drs)
                {
                    valueList.Add(col["FIELDNAME"]);
                    displayList.Add(col["FIELDNAME"].ToString());
                }
                chkSelect.EditValue = false;
                cboKeyColumn.InitData(valueList.ToArray(), displayList.ToArray());
                cboMandatoryColumn.InitData(valueList.ToArray(), displayList.ToArray());
                cboNewRowCopyColumn.InitData(valueList.ToArray(), displayList.ToArray());
                cboNewRowEnableColumn.InitData(valueList.ToArray(), displayList.ToArray());

                SelectionDetailGridData(dr["SCREENID"].ToString(), dr["GRIDNAME"].ToString());
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        /// <summary>
        /// 조회 처리 Method
        /// </summary>
        private void SelectionDetailGridData(string menuId, string gridName)
        {
            DataSet ds;
            const string queryId = @"dbo.ScreenColumnSetDetail_Select";

            string[] paramList = new string[] { "@SCREENID", "@GRIDNAME" };

            object[] valueList = new object[] { menuId, gridName };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            }

            if (ds.Tables[0].Rows.Count == 0) return;

            DataRow dr = ds.Tables[0].Rows[0];

            chkSelect.EditValue = dr["USESELECTCOLUMN"];
            cboKeyColumn.EditValue = dr["KEYCOLUMNS"];
            cboMandatoryColumn.EditValue = dr["MANDATORYCOLUMNS"];
            cboNewRowEnableColumn.EditValue = dr["NEWROWENABLECOLUMNS"];
            cboNewRowCopyColumn.EditValue = dr["NEWROWCOPYCOLUMNS"];
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (viewList.RowCount == 0) return;

            DataRow fdr = viewList.GetFocusedDataRow();

            if (fdr == null) return;

            string gridName = fdr["GRIDNAME"].ToString();

            viewPreview.Columns.Clear();

            viewPreview.BeginInit();

            if (chkSelect.Checked)
                viewPreview.InitColumn(AppConfig.CHECKCOLUMNNAME, "Select", 60, 0, true, true, DataType.CheckEdit);

            foreach (DataRow dr in viewList.GetDataTableByDataSource().Rows)
            {
                if (gridName != dr["GRIDNAME"].ToString()) continue;

                string fieldName = dr["FIELDNAME"].ToString();
                string caption = dr["CAPTION"].ToString();
                int width = Convert.ToInt32(dr["WIDTH"]);
                int maxlength = Convert.ToInt32(dr["MAXLENGTH"]);
                bool allowEdit = Convert.ToBoolean(dr["ALLOWEDIT"]);
                bool visible = Convert.ToBoolean(dr["VISIBLE"]);

                viewPreview.InitColumn(fieldName, caption, width, maxlength, allowEdit, visible);
            }

            viewPreview.EndInit();
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////



        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Private)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        // Initialize 관련 Method

        #region :: InitLocalization :: 다국어 Initialize

        /// <summary>
        /// 다국어 Initialize
        /// </summary>
        private void InitLocalization()
        {
            // localizer 를 사용하세요.
            // grpOption.Text = localizer.GetLocalizedString(StrId.InquiryOption);
        }

        #endregion

        #region :: InitGlobalInstance :: 전역변수 Initialize

        /// <summary>
        /// 전역변수 Initialize
        /// </summary>
        private void InitGlobalInstance()
        {
        }

        #endregion

        #region :: InitGridControl :: Grid Control Initialize

        /// <summary>
        /// Grid Control Initialize
        /// </summary>
        private void InitGridControl()
        {
            viewList.BeginInit();

            viewList.InitColumn(AppConfig.CHECKCOLUMNNAME, "Select", 60, 0, true, true, DataType.CheckEdit);

            viewList.InitColumn("SCREENID", "ScreenId", 75, 0, false, true, DataType.Default, HorzAlign.Default);
            viewList.InitColumn("SCREENNAME", "ScreenName", 120, 0, false, true, DataType.Default, HorzAlign.Default);
            viewList.InitColumn("GRIDNAME", "ControlName", 120, 0, false, true, DataType.Default, HorzAlign.Default);
            viewList.InitColumn("IDX", "IDX", 60, 0, true, true, DataType.Number, HorzAlign.Center);
            viewList.InitColumn("FIELDNAME", "FieldName", 150, 0, false, true, DataType.Default, HorzAlign.Default);
            viewList.InitColumn("CAPTION", "Header Text", 150, 0, true, true, DataType.Default, HorzAlign.Default);
            viewList.InitColumn("WIDTH", "Width", 75, 0, true, true, DataType.Number, HorzAlign.Far);
            viewList.InitColumn("MAXLENGTH", "Length", 75, 0, true, true, DataType.Number, HorzAlign.Far);
            viewList.InitColumn("DECIMALPLACE", "DecimalPoint", 75, 0, true, true, DataType.Number, HorzAlign.Far);
            viewList.InitColumn("ALLOWEDIT", "Edit", 55, 0, true, true, DataType.CheckEdit, HorzAlign.Default);
            viewList.InitColumn("VISIBLE", "Visible", 55, 0, true, true, DataType.CheckEdit, HorzAlign.Default);
            viewList.InitColumn("DATATYPE", "DataType", 100, 0, true, true, DataType.ComboBox, HorzAlign.Default);
            viewList.InitColumn("HORIZONALIGN", "HorizonAlign", 100, 0, true, true, DataType.ComboBox, HorzAlign.Default);
            viewList.InitColumn("CHANGEDTTM", "ChangeDttm", 75, 0, false, true, DataType.Default, HorzAlign.Default);
            viewList.InitColumn("CHANGEBY", "ChangeBy", 75, 0, false, true, DataType.Default, HorzAlign.Default);

            viewList.SetCellMerge("SCREENID", "SCREENNAME", "GRIDNAME");

            viewList.NewRowEnableColumns = new string[] { "GRIDNAME", "FIELDNAME" };
            viewList.NewRowCopyColumns = new string[] { "SCREENID", "SCREENNAME", "GRIDNAME" };

            viewList.InitComboBoxColumn("HORIZONALIGN", AppCode.GetCodeMaster("C$COLUMNALIGN", ""));
            viewList.InitComboBoxColumn("DATATYPE", AppCode.GetCodeMaster("C$COLUMNDATATYPE", ""));

            viewList.EndInit();
        }

        #endregion

        #region :: InitComboBox :: ComboBox Initialize

        /// <summary>
        /// ComboBox Initialize
        /// </summary>
        private void InitComboBox()
        {

        }

        #endregion

        #region :: InitControls :: 기타 Control Initialize

        /// <summary>
        /// 기타 Control Initialize
        /// </summary>
        private void InitControls()
        {
            tlMenu.BeginInit();

            tlMenu.InitColumn("MENUID", "MenuId", 75, 0, false, false);
            tlMenu.InitColumn("MENUNAME", "MenuName", 190, 0, false, true);
            tlMenu.InitColumn("PARENTMENUID", "부모메뉴ID", 75, 0, false, false);
            tlMenu.InitColumn("CLASSNAME", "Class 이름", 200, 0, false, false);
            tlMenu.InitColumn("USESET", "셋팅 사용", 60, 0, false, true, DataType.CheckEdit);

            tlMenu.KeyFieldName = "MENUID";
            tlMenu.ParentFieldName = "PARENTMENUID";

            tlMenu.EndInit();

            viewList.ViewCaption = string.Empty;
        }

        #endregion

        // 사용자 권한 처리 Method

        #region :: UserAuthProcess :: 사용자 권한 처리

        /// <summary>
        /// 사용자 권한 처리
        /// </summary>
        private void UserAuthProcess()
        {
        }

        #endregion

        // Form 간 Data 전송 처리 Method

        #region :: LinkData :: Form 간 Data 전송 처리

        /// <summary>
        /// Form 간 Data 전송 처리
        /// </summary>
        private void LinkData()
        {
        }

        #endregion

        // Common Event 처리 Method

        #region :: SelectionData :: 조회 처리 Method

        /// <summary>
        /// 조회 처리 Method
        /// </summary>
        private void SelectionData()
        {
            DataSet ds;
            const string queryId = @"dbo.ScreenColumnSetMenu_Select";

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, DatabaseParams);
            }

            tlMenu.FillData(ds);
            gridList.FillData();

            tlMenu.ExpandAll();
        }

        #endregion

        #region :: NewData :: 신규 처리 Method

        /// <summary>
        /// 신규 처리 Method
        /// </summary>
        private void NewData()
        {
            //viewList.AddNewRow();
            viewList.AddNewRow("FIELDNAME");
        }

        #endregion

        #region :: DeleteData :: 삭제 처리 Method

        /// <summary>
        /// 삭제 처리 Method
        /// </summary>
        private void DeleteData()
        {
            const string queryId = @"dbo.ScreenColumnSet_Delete";

            string[] paramList = new string[] { "@SCREENID",
                                                "@GRIDNAME",
                                                "@FIELDNAME" };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                wb.Tx_ExecuteNonQuery(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, viewList.GetCheckedData());
            }
        }

        #endregion

        #region :: SaveData :: 저장 처리 Method

        /// <summary>
        /// 저장 처리 Method
        /// </summary>
        private void SaveData()
        {
            const string queryId = @"dbo.ScreenColumnSet_Save";

            string[] paramList = new string[] { "@SCREENID",
                                                "@GRIDNAME",
                                                "@IDX",
                                                "@FIELDNAME",
                                                "@CAPTION",
                                                "@WIDTH",
                                                "@MAXLENGTH",
                                                "@DECIMALPLACE",
                                                "@ALLOWEDIT",
                                                "@VISIBLE",
                                                "@DATATYPE",
                                                "@HORIZONALIGN",
                                                "@CHANGEBY" };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                wb.Tx_ExecuteNonQuery(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, viewList.GetAddedModifedData());
            }
        }

        /// <summary>
        /// 저장 처리 Method
        /// </summary>
        private void SaveDetailData()
        {
            DataRow dr = viewList.GetFocusedDataRow();

            if (dr == null) return;

            const string queryId = @"dbo.ScreenColumnSetDetail_Save";

            string[] paramList = new string[] { "@SCREENID",
                                                "@GRIDNAME",
                                                "@USESELECTCOLUMN",
                                                "@KEYCOLUMNS",
                                                "@MANDATORYCOLUMNS",
                                                "@NEWROWENABLECOLUMNS",
                                                "@NEWROWCOPYCOLUMNS",
                                                "@CHANGEBY" };

            object[] valueList = new object[] { dr["SCREENID"],
                                                dr["GRIDNAME"],
                                                chkSelect.EditValue,
                                                cboKeyColumn.EditValue,
                                                cboMandatoryColumn.EditValue,
                                                cboNewRowEnableColumn.EditValue,
                                                cboNewRowCopyColumn.EditValue,
                                                CurrentUser.USERID };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                wb.Tx_ExecuteNonQuery(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            }
        }

        #endregion

        #region :: ChartData :: Chart 처리 Method

        /// <summary>
        /// Chart 처리 Method
        /// </summary>
        private void ChartData()
        {
        }

        #endregion


        // Common Event 처리 Method 조건 Check

        #region :: CheckSelectionCondition :: 조회 조건 Check Method

        /// <summary>
        /// 조회 조건 Check Method
        /// </summary>
        /// <returns></returns>
        protected override bool CheckSelectionCondition()
        {
            return base.CheckSelectionCondition();
        }

        #endregion

        #region :: CheckNewCondition :: 신규 조건 Check Method

        /// <summary>
        /// 신규 조건 Check Method
        /// </summary>
        /// <returns></returns>
        protected override bool CheckNewCondition()
        {
            return base.CheckNewCondition();
        }

        #endregion

        #region :: CheckDeleteCondition :: 삭제 조건 Check Method

        /// <summary>
        /// 삭제 조건 Check Method
        /// </summary>
        /// <returns></returns>
        protected override bool CheckDeleteCondition()
        {
            //return true;

            return base.CheckDeleteCondition();
        }

        #endregion

        #region :: CheckSaveCondition :: 저장 조건 Check Method

        /// <summary>
        /// 저장 조건 Check Method
        /// </summary>
        /// <returns></returns>
        protected override bool CheckSaveCondition()
        {
            //return true;

            return base.CheckSaveCondition();
        }

        #endregion

        #region :: CheckChartCondition :: Chart 조건 Check Method

        /// <summary>
        /// Chart 조건 Check Method
        /// </summary>
        /// <returns></returns>
        protected override bool CheckChartCondition()
        {
            return base.CheckChartCondition();
        }

        #endregion


        // 기타 Control Event 처리 Method는 아래에 기술하세요.

        #region :: SetFormLayout :: Form의 Layout을 변경합니다.

        /// <summary>
        /// Form의 Layout을 변경합니다.
        /// </summary>
        private void SetFormLayout()
        {
        }

        #endregion

        #region :: SetGridLayout :: Grid의 Layout을 변경합니다.

        /// <summary>
        /// Grid의 Layout을 변경합니다.
        /// </summary>
        private void SetGridLayout()
        {
        }

        #endregion
    }

    #endregion
}
