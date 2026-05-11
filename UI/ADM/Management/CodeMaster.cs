#region 어셈블리 EBAP.UI.ADM.Management, v3.17
// C:\EBAP.NET\EBAP.UI.ADM.dll
// CLR Version : 4.0.30319.36415
#endregion

using DevExpress.XtraGrid.Views.Grid;
using EBAP.Business.WSBiz;
using EBAP.Core.Info;
using EBAP.Data.CodeUtil;
using System;
using System.Data;

namespace EBAP.UI.ADM.Management
{
    #region :: EBAP.UI.ADM.Management.CodeMaster ::

    /// <summary>
    /// Form의 업무내용을 기술합니다.
    /// </summary>
    /// <remarks>
    /// Comment     : Form 기능 및 특이사항 기록
    ///               1.  
    ///               2. 
    /// History     :
    ///               1. (2018-04-11 오전 10:20:02 - 오인봉 - PC170245) : 최초 생성
    ///               2.
    ///               3.
    /// </remarks>
    public partial class CodeMaster : EBAP.Win.BaseFrame.UIFrame
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// CodeMaster Form을 생성합니다.
        /// </summary>
        public CodeMaster()
        {
            InitializeComponent();

            AppConfig.CurrentDB = ConnectionString.METADB;
        }

        #endregion

        #region :: 전역변수 ::

        private string DATABASE = ConnectionString.METADB;

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler(Common Event)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: CodeMaster_Load :: Form이 Load 시 발생합니다.

        /// <summary>
        /// Form이 Load 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CodeMaster_Load(object sender, EventArgs e)
        {
            try
            {
                InitLocalization();
                InitDatabaseConnection();
                InitGlobalInstance();
                InitComboBox();
                InitGridControl();
                InitControls();

                //Form Load 후 조회를 실행해야 한다면 주석을 제거하세요.
                IsLoadSelectEvent = true;
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        /// <summary>
        /// 다국어 Initialize
        /// </summary>
        private void InitLocalization()
        {
            // localizer 를 사용하세요.
            // grpOption.Text = LANGCONVERTER.GetLanguageString("InquiryOption");
        }

        /// <summary>
        /// 업무 화면에 따라 Database 설정을 변경합니다.
        /// </summary>
        private void InitDatabaseConnection()
        {
            string commonCodeMgmt = LOCALECONVERTER.GetLocaleString("CommonCodeManagement");
            if (MENUID.Contains("MES"))
            {
                DATABASE = ConnectionString.MESDB;
                Text = $"{commonCodeMgmt} (생산관리 - MES)";
            }
            else
            {
                DATABASE = ConnectionString.METADB;
                Text = $"{commonCodeMgmt} ({AppConfig.SYSTEMNAME})";
            }
        }

        /// <summary>
        /// 전역변수 Initialize
        /// </summary>
        private void InitGlobalInstance()
        {
        }

        /// <summary>
        /// Grid Control Initialize
        /// </summary>
        private void InitGridControl()
        {
            InitViewMaster();
            InitViewDetail();
        }

        private void InitViewMaster()
        {
            viewMaster.BeginInit();

            viewMaster.InitColumn(AppConfig.CHECKCOLUMNNAME, "Select", 60, 0, true, true, DataType.CheckEdit);
            //viewMaster.InitColumn("CODEVALUE", "CodeValue", 150, 0, false, true);
            //viewMaster.InitColumn("DISPLAYVALUE", "DisplayValue", 200, 0, true, true);
            //viewMaster.InitColumn("IDX", "IDX", 60, 0, false, false, DataType.Number);
            //viewMaster.InitColumn("CHANGEBY", "ChangeBy", 80, 0, false, false);

            viewMaster.InitColumnFromDB();            

            viewMaster.NewRowEnableColumns = new string[] { "CODEVALUE" };
            viewMaster.MandatoryColumns = new string[] { "CODEVALUE", "DISPLAYVALUE" };
            //viewMaster.InitColumnFromDB();

            viewMaster.EndInit();
        }

        private void InitViewDetail()
        {
            viewDetail.BeginInit();

            viewDetail.InitColumn(AppConfig.CHECKCOLUMNNAME, "Select", 60, 0, true, true, DataType.CheckEdit);
            //viewDetail.InitColumn("CODEVALUE", "CodeValue", 150, 0, false, true);
            //viewDetail.InitColumn("DISPLAYVALUE", "DisplayValue", 200, 0, true, true);
            //viewDetail.InitColumn("PCODEVALUE", "", 50, 0, false, false);
            //viewDetail.InitColumn("IDX", "IDX", 60, 0, true, true, DataType.Number, HorzAlign.Far);
            //viewDetail.InitColumn("REF1", "REF1", 110, 0, true, true);
            //viewDetail.InitColumn("REF2", "REF2", 110, 0, true, true);
            //viewDetail.InitColumn("REF3", "REF3", 110, 0, true, true);
            //viewDetail.InitColumn("USEFLAG", "UseFlag", 60, 0, true, true, DataType.CheckEdit);
            //viewDetail.InitColumn("CHANGEBY", "ChangeBy", 80, 0, false, false);
            //viewDetail.InitColumn("CHANGEDTTM", "ChangeDttm", 150, 0, false, true, DataType.DateTime);

            viewDetail.InitColumnFromDB();

            viewDetail.NewRowEnableColumns = new string[] { "CODEVALUE" };
            viewDetail.MandatoryColumns = new string[] { "CODEVALUE", "DISPLAYVALUE" };
            viewDetail.KeyColumns = new string[] { "PCODEVALUE", "CODEVALUE" };

            viewDetail.InitCheckedComboBoxColumn("REF3", AppCode.GetCodeMaster("C$PLANTCODE", ""), true, AppConfig.VALUEMEMBER, AppConfig.DISPLAYMEMBER);

            viewDetail.EndInit();
        }

        /// <summary>
        /// ComboBox Initialize
        /// </summary>
        private void InitComboBox()
        {

        }

        /// <summary>
        /// 기타 Control Initialize
        /// </summary>
        private void InitControls()
        {

        }

        #endregion

        #region :: CodeMaster_Link :: Form 간 Data 전송 시 발생합니다.

        /// <summary>
        /// Form 간 Data 전송 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CodeMaster_Link(object sender, EventArgs e)
        {
            try
            {
                LinkData();

                // Link 후 조회를 실행해야 한다면 주석을 제거하세요.
                //RaiseSelectEvent();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Form 간 Data 전송 처리
        /// </summary>
        private void LinkData()
        {
        }

        #endregion

        #region :: CodeMaster_Selection :: MainForm의 조회 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 조회 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CodeMaster_Selection(object sender, EventArgs e)
        {
            try
            {
                SetFormLayout();
                SetGridLayout();
                SelectionData();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Form의 Layout을 변경합니다.
        /// </summary>
        private void SetFormLayout()
        {
        }

        /// <summary>
        /// Grid의 Layout을 변경합니다.
        /// </summary>
        private void SetGridLayout()
        {
        }

        /// <summary>
        /// 조회 처리 Method
        /// </summary>
        private void SelectionData()
        {
            gridDetail.FillData();

            DataSet ds;

            const string queryId = @"dbo.CodeMaster_Select"; //String.Format("{0}.Management.CodeMaster.selectCodeMaster", MODULE);

            string[] paramList = new string[] { "@DISPLAYVALUE" };

            object[] valueList = new object[] { txtDisplayValue.EditValue };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(DATABASE, queryId, AppConfig.COMMANDSP, paramList, valueList);
            }

            gridMaster.FillData(ds);

            // 그리드와 컨트롤이 바인딩이 필요하다면 주석을 제거하세요.
            //InitDataBindings(ds);
        }

        /// <summary>
        /// 컨트롤과 데이터를 바인딩합니다.
        /// </summary>
        private void InitDataBindings(DataSet ds)
        {
            //DataTable dt = ds.Tables[0];

            //txtUserId.BindingMapping(dt,"USERID");
            //txtUserName.BindingMapping(dt,"USERNAME");
            //txtEmpNo.BindingMapping(dt, "EMPNO");
        }

        #endregion

        #region :: CodeMaster_New :: MainForm의 신규 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 신규 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CodeMaster_New(object sender, EventArgs e)
        {
            try
            {
                NewData();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 신규 처리 Method
        /// </summary>
        private void NewData()
        {
            const string code = "CODEVALUE";

            if (gridMaster.IsFocused || gridMaster.ContainsFocus)
                viewMaster.AddNewRow(code);
            else if (gridDetail.IsFocused || gridDetail.ContainsFocus)
                viewDetail.AddNewRow(code);
            else
                viewMaster.AddNewRow(code);
        }

        #endregion

        #region :: CodeMaster_Save :: MainForm의 저장 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 저장 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CodeMaster_Save(object sender, EventArgs e)
        {
            try
            {
                SaveData();

                // 저장 후 조회를 실행해야 한다면 주석을 제거하세요.
                //RaiseSelectEvent();

                // 저장 후 DataTable에 변경사항만 처리할 경우 주석을 제거하세요(DB 접속 필요없을 경우)
                viewMaster.AcceptChanges();
                viewDetail.AcceptChanges();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 저장 처리 Method
        /// </summary>
        private void SaveData()
        {
            DataTable dtMaster = viewMaster.GetAddedModifedData();
            DataTable dtDetail = viewDetail.GetAddedModifedData();

            if (dtMaster.Rows.Count > 0) SaveMasterData(dtMaster);
            if (dtDetail.Rows.Count > 0) SaveDetailData(dtDetail);

        }

        /// <summary>
        /// 마스터 데이터를 저장합니다.
        /// </summary>
        /// <param name="dt"></param>
        private void SaveMasterData(DataTable dt)
        {
            const string queryId = @"dbo.CodeMaster_Save";

            string[] paramList = new string[] { "@CODEVALUE",
                                                "@DISPLAYVALUE",
                                                "@IDX",
                                                "@CHANGEBY" };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                wb.Tx_ExecuteNonQuery(DATABASE, queryId, AppConfig.COMMANDSP, paramList, dt);
            }
        }

        /// <summary>
        /// 디테일 데이터를 저장합니다.
        /// </summary>
        /// <param name="dt"></param>
        private void SaveDetailData(DataTable dt)
        {
            const string queryId = @"dbo.CodeMasterDetail_Save";

            string[] paramList = new string[] { "@CODEVALUE",
                                                "@DISPLAYVALUE",
                                                "@PCODEVALUE",
                                                "@IDX",
                                                "@REF1",
                                                "@REF2",
                                                "@REF3",
                                                "@USEFLAG",
                                                "@CHANGEBY" };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                wb.Tx_ExecuteNonQuery(DATABASE, queryId, AppConfig.COMMANDSP, paramList, dt);
            }
        }

        #endregion

        #region :: CodeMaster_Delete :: MainForm의 삭제 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 삭제 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CodeMaster_Delete(object sender, EventArgs e)
        {
            try
            {
                DeleteData();

                // 삭제 후 조회를 실행해야 한다면 주석을 제거하세요.
                //RaiseSelectEvent();

                // 삭제 후 Check 된 ROW 만 삭제하려면 주석을 제거하세요(DB 접속 필요없을 경우)
                viewMaster.RemoveCheckedRow();
                viewDetail.RemoveCheckedRow();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 삭제 처리 Method
        /// </summary>
        private void DeleteData()
        {
            DataTable dtMaster = viewMaster.GetCheckedData();
            DataTable dtDetail = viewDetail.GetCheckedData();

            if (dtMaster.Rows.Count > 0) DeleteMasterData(dtMaster);
            if (dtDetail.Rows.Count > 0) DeleteDetailData(dtDetail);
        }

        /// <summary>
        /// 마스터 데이터를 삭제합니다.
        /// </summary>
        /// <param name="dt"></param>
        private void DeleteMasterData(DataTable dt)
        {
            const string queryId = @"dbo.CodeMaster_Delete";

            string[] paramList = new string[] { "@CODEVALUE" };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                wb.Tx_ExecuteNonQuery(DATABASE, queryId, AppConfig.COMMANDSP, paramList, dt);
            }
        }

        /// <summary>
        /// 디테일 데이터를 삭제합니다.
        /// </summary>
        /// <param name="dt"></param>
        private void DeleteDetailData(DataTable dt)
        {
            const string queryId = @"dbo.CodeMasterDetail_Delete";

            string[] paramList = new string[] { "@CODEVALUE",
                                                "@PCODEVALUE" };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                wb.Tx_ExecuteNonQuery(DATABASE, queryId, AppConfig.COMMANDSP, paramList, dt);
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

        #region :: viewList_InitNewRow :: 신규로 생성되는 Row의 기본값을 정의합니다.

        /// <summary>
        /// 신규로 생성되는 Row의 기본값을 정의합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewList_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                if (sender.Equals(viewMaster))
                {
                    viewMaster.SetRowCellValue(e.RowHandle, "CODEVALUE", "");
                    viewMaster.SetRowCellValue(e.RowHandle, "DISPLAYVALUE", "");
                    viewMaster.SetRowCellValue(e.RowHandle, "IDX", 0);
                    //viewMaster.SetRowCellValue(e.RowHandle, "CHANGEBY", CurrentUser.UserID);
                    gridDetail.FillData();
                }

                if (sender.Equals(viewDetail))
                {
                    viewDetail.SetRowCellValue(e.RowHandle, "CODEVALUE", "");
                    viewDetail.SetRowCellValue(e.RowHandle, "DISPLAYVALUE", "");
                    viewDetail.SetRowCellValue(e.RowHandle, "PCODEVALUE", viewMaster.GetFocusedRowCellValue("CODEVALUE"));
                    viewDetail.SetRowCellValue(e.RowHandle, "IDX", viewDetail.RowCount);
                    viewDetail.SetRowCellValue(e.RowHandle, "REF1", "");
                    viewDetail.SetRowCellValue(e.RowHandle, "REF2", "");
                    viewDetail.SetRowCellValue(e.RowHandle, "REF3", "");
                    viewDetail.SetRowCellValue(e.RowHandle, "USEFLAG", true);
                    //viewDetail.SetRowCellValue(e.RowHandle, "CHANGEBY", CurrentUser.UserID);
                }
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
            try
            {
                //DataRow dr = viewList.GetFocusedDataRow();

                //if (dr == null || e.Column.FieldName != "COLUMNNAME") return;

                //string siteId = dr["COLUMN"].ToString();

                //e.RepositoryItem = ControlUtil.MakeComboBoxCell(MESCode.GetCodeMaster("C$", ""));
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        #region :: viewList_ShowingEditor :: 조건에 따라 셀 수정 여부를 지정합니다.

        /// <summary>
        /// 조건에 따라 셀 수정 여부를 지정합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewList_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                //if (viewList.FocusedColumn.FieldName != "COLUMNNAME") return;

                //string status = viewList.GetFocusedRowCellValue("STATUS").ToString();

                //if (status == "FN") e.Cancel = true;
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        #region :: viewMaster_FocusedRowChanged :: 선택한 Row가 변경되면 발생합니다.

        /// <summary>
        /// 선택한 Row가 변경되면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewMaster_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow dr = viewMaster.GetFocusedDataRow();

                if (dr == null) return;

                InitDatabaseConnection();

                viewDetail.ViewCaption = $"[ {grpLarge.Text} :          {dr["CODEVALUE"]} - {dr["DISPLAYVALUE"]} ]";
                SelectionDetailData(dr["CODEVALUE"].ToString());
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        /// <summary>
        /// 상세 데이터 조회 처리 Method
        /// </summary>
        private void SelectionDetailData(string pCodeValue)
        {
            DataSet ds;
            const string queryId = @"dbo.CodeMasterDetail_Select";

            string[] paramList = new string[] { "@PCODEVALUE" };

            object[] valueList = new object[] { pCodeValue };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(DATABASE, queryId, AppConfig.COMMANDSP, paramList, valueList);
            }

            gridDetail.FillData(ds);
        }

        #endregion

        #region :: viewList_CellValueChanged :: Grid 값이 변경되면 발생합니다.

        /// <summary>
        /// Grid 값이 변경되면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewList_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                //string fieldName = e.Column.FieldName;
                //if (fieldName == "FIELDNAME")
                //{
                //    DateTime birthDate = Convert.ToDateTime(e.Value);

                //    viewList.SetFocusedRowCellValue("AGE", (GetServerTime().Year - birthDate.Year) + 1);
                //}
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////



        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Private)
        ///////////////////////////////////////////////////////////////////////////////////////////////

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
            //return base.CheckDeleteCondition(viewList.GetCheckedData());
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
            //return base.CheckSaveCondition(viewList.GetAddedModifedData());
        }

        #endregion
    }

    #endregion
}
