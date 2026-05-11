#region 어셈블리 EBAP.UI.ADM.Management, v3.17
// C:\EBAP.NET\EBAP.UI.ADM.dll
// CLR Version : 4.0.30319.36415
#endregion

using DevExpress.XtraGrid.Views.Grid;
using EBAP.Business.WSBiz;
using EBAP.Core.Info;
using EBAP.Core.Localization;
using EBAP.Data.CodeUtil;
using System;
using System.Data;
using System.Windows.Forms;

namespace EBAP.UI.ADM.Management
{
    #region :: EBAP.UI.ADM.Management.QueryMaster ::

    /// <summary>
    /// Form의 업무내용을 기술합니다.
    /// </summary>
    /// <remarks>
    /// Comment     : Form 기능 및 특이사항 기록
    ///               1.  
    ///               2. 
    /// History     :
    ///               1. (2018-04-11 오후 1:26:51 - 오인봉 - PC170245) : 최초 생성
    ///               2.
    ///               3.
    /// </remarks>
    public partial class QueryMaster : EBAP.Win.BaseFrame.UIFrame
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// QueryMaster Form을 생성합니다.
        /// </summary>
        public QueryMaster()
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

        #region :: QueryMaster_Load :: Form이 Load 시 발생합니다.

        /// <summary>
        /// Form이 Load 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QueryMaster_Load(object sender, EventArgs e)
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

        #region :: QueryMaster_Authentication :: 사용자 권한 처리 시 발생합니다.

        /// <summary>
        /// 사용자 권한 처리 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QueryMaster_Authentication(object sender, EventArgs e)
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

        #region :: QueryMaster_Link :: Form 간 Data 전송 시 발생합니다.

        /// <summary>
        /// Form 간 Data 전송 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QueryMaster_Link(object sender, EventArgs e)
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

        #region :: QueryMaster_Selection :: MainForm의 조회 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 조회 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QueryMaster_Selection(object sender, EventArgs e)
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

        #region :: QueryMaster_New :: MainForm의 신규 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 신규 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QueryMaster_New(object sender, EventArgs e)
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

        #region :: QueryMaster_Delete :: MainForm의 삭제 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 삭제 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QueryMaster_Delete(object sender, EventArgs e)
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

        #region :: QueryMaster_Save :: MainForm의 저장 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 저장 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QueryMaster_Save(object sender, EventArgs e)
        {
            try
            {
                SaveData();

                // 저장 후 조회를 실행해야 한다면 주석을 제거하세요.
                //RaiseSelectEvent();

                // 저장 후 DataTable에 변경사항만 처리할 경우 주석을 제거하세요(DB 접속 필요없을 경우)
                viewList.AcceptChanges();
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
                string group = cboSearchGroup.EditValue.ToString() == string.Empty ? "ADM" : cboSearchGroup.EditValue.ToString();

                //if (group == string.Empty)
                //    group = "ADM";

                viewList.SetRowCellValue(e.RowHandle, "SQLGROUP", group);
                viewList.SetRowCellValue(e.RowHandle, "QUERYID", group);
                viewList.SetRowCellValue(e.RowHandle, "QUERYTYPE", "StoredProcedure");
                viewList.SetRowCellValue(e.RowHandle, "DBID", "METADB");
                viewList.SetRowCellValue(e.RowHandle, "IDX", 1);
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

        #region :: viewList_FocusedRowChanged :: 쿼리 정보를 클릭하면 쿼리 원본 정보와 복사 정보를 생성합니다.

        /// <summary>
        /// 쿼리 정보를 클릭하면 쿼리 원본 정보와 복사 정보를 생성합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = viewList.GetFocusedDataRow();

            if (dr == null || dr.RowState != DataRowState.Unchanged) return;

            cboOrgSqlGroup.EditValue = dr["SQLGROUP"];
            cboCopySqlGroup.EditValue = dr["SQLGROUP"];

            string orgUIName = dr["QUERYID"].ToString().Replace(dr["SQLGROUP"].ToString(), "");
            string[] sptUIName = orgUIName.Split('.');

            txtOrgUIName.EditValue = sptUIName[1];
            txtCopyUIName.EditValue = sptUIName[1];

            string subject = dr["SUBJECT"].ToString().Replace("저장", "").Replace("삭제", "").Replace("조회", "").Trim();

            txtOrgSubject.EditValue = subject;
            txtCopySubject.EditValue = subject;

            SelectionQuerySource();
            gridCopyList.FillData();
        }

        /// <summary>
        /// 
        /// </summary>
        private void SelectionQuerySource()
        {
            DataSet ds;
            const string queryId = @"dbo.QueryMaster_CopySource_Select";

            string[] paramList = new string[] { "@SQLGROUP", "@UINAME" };
            object[] valueList = new object[] { cboOrgSqlGroup.EditValue, txtOrgUIName.EditValue };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            }

            gridOrgList.FillData(ds);
        }

        #endregion

        #region :: btnPreview_Click ::

        /// <summary>
        /// 미리보기를 클릭하면 복사할 쿼리 정보를 보여줍니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                SelectionQueryCopyData();
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void SelectionQueryCopyData()
        {
            DataSet ds;

            const string queryId = @"dbo.QueryMaster_CopyData_Select";

            string[] paramList = new string[] { "@SQLGROUP", "@UINAME", "@SUBJECT", "@CHGSQLGROUP", "@CHGUINAME", "@CHGSUBJECT", "@DBID" };

            object[] valueList = new object[] { cboOrgSqlGroup.EditValue
                                              , txtOrgUIName.EditValue
                                              , txtOrgSubject.EditValue
                                              , cboCopySqlGroup.EditValue
                                              , txtCopyUIName.EditValue
                                              , txtCopySubject.EditValue
                                              , cboCopyDBId.EditValue };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            }

            gridCopyList.FillData(ds);
        }

        #endregion

        #region :: btnCopy_Click :: 쿼리 ID를 복사합니다.

        /// <summary>
        /// 쿼리 ID를 복사합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                btnCopy.IsValid = CheckCopyCondition();

                if (!btnCopy.IsValid) return;

                CopyQueryId();

                RaiseSelectEvent();
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool CheckCopyCondition()
        {
            DataTable dt = viewCopyList.GetDataTableByDataSource();

            if (dt.Rows.Count == 0)
            {
                ShowMsgBox("복사할 쿼리가 없어요. 미리보기를 클릭하거나 정확하게 입력해 주세요.");
                return false;
            }

            DataTable dupdt = viewCopyList.GetCheckedData("CHECKDUP", "1");

            if (dupdt.Rows.Count > 0)
            {
                ShowMsgBox("중복된 쿼리 ID가 있습니다. 확인하세요");
                return false;
            }

            string message = LOCALECONVERTER.GetLocaleString("Copy");

            return DialogResult.Yes == ShowMsgBox(String.Format(LOCALECONVERTER.GetLocaleMessage("CF_Do"), message),
                                    message, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        /// <summary>
        /// 
        /// </summary>
        private void CopyQueryId()
        {
            const string queryId = @"dbo.QueryMaster_Copy";

            string[] paramList = new string[] { "@SQLGROUP",
                                                "@UINAME",
                                                "@SUBJECT",
                                                "@CHGSQLGROUP",
                                                "@CHGUINAME",
                                                "@CHGSUBJECT",
                                                "@DBID" };

            object[] valueList = new object[] { cboSqlGroup.EditValue,
                                                txtOrgUIName.EditValue,
                                                txtOrgSubject.EditValue,
                                                cboCopySqlGroup.EditValue,
                                                txtCopyUIName.EditValue,
                                                txtCopySubject.EditValue,
                                                cboCopyDBId.EditValue };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                wb.Tx_ExecuteNonQuery(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            }
        }

        #endregion


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
            viewList.InitColumn("SQLGROUP", "Group", 150, 0, false, true, DataType.Default, HorzAlign.Default);
            viewList.InitColumn("QUERYID", "Query ID", 350, 0, false, true, DataType.Default, HorzAlign.Default);
            viewList.InitColumn("SUBJECT", "쿼리 설명", 200, 0, true, true, DataType.Default, HorzAlign.Default);
            viewList.InitColumn("IDX", "IDX", 0, 0, false, false, DataType.Default, HorzAlign.Default);
            viewList.InitColumn("QUERYTYPE", "Query 구분", 0, 0, false, false, DataType.Default, HorzAlign.Default);
            viewList.InitColumn("QUERYTEXT", "Query Text", 0, 0, false, false);
            viewList.InitColumn("DBID", "DB ID", 0, 0, false, false, DataType.Default, HorzAlign.Default);
            viewList.InitComboBoxColumn("SQLGROUP", AppCode.GetCodeMaster("C$SQLGROUP", ""));

            viewList.NewRowEnableColumns = new string[] { "SQLGROUP", "QUERYID" };
            viewList.MandatoryColumns = new string[] { "SQLGROUP", "QUERYID", "IDX" };

            viewList.EndInit();

            viewOrgList.BeginInit();

            viewOrgList.InitColumn("QUERYID", "Query ID", 350, 0, false, true, DataType.Default, HorzAlign.Default);
            viewOrgList.InitColumn("SUBJECT", "쿼리 설명", 200, 0, false, false, DataType.Default, HorzAlign.Default);
            viewOrgList.InitColumn("QUERYTEXT", "Query Text", 150, 0, false, true);

            viewOrgList.EndInit();

            viewCopyList.BeginInit();

            viewCopyList.InitColumn("QUERYID", "Query ID", 350, 0, false, true, DataType.Default, HorzAlign.Default);
            viewCopyList.InitColumn("DESCRIPTION", "쿼리 설명", 200, 0, false, true, DataType.Default, HorzAlign.Default);
            viewCopyList.InitColumn("QUERYTEXT", "Query Text", 150, 0, false, true);
            viewCopyList.InitColumn("CHECKDUP", "중복", 60, 0, false, true, DataType.CheckEdit);

            viewCopyList.EndInit();
        }

        #endregion

        #region :: InitComboBox :: ComboBox Initialize

        /// <summary>
        /// ComboBox Initialize
        /// </summary>
        private void InitComboBox()
        {
            DataTable dtSqlGroup = AppCode.GetCodeMaster("C$SQLGROUP", "");
            DataTable dtDBId = AppCode.GetCodeMaster("C$DBID", "");

            cboSearchGroup.InitData(AppCode.GetCodeMaster("C$SQLGROUP", ""));

            cboSqlGroup.InitData(dtSqlGroup);
            cboOrgSqlGroup.InitData(dtSqlGroup);
            cboCopySqlGroup.InitData(dtSqlGroup);

            cboQueryType.InitData(AppCode.GetCodeMaster("C$QUERYTYPE", ""));

            cboDBId.InitData(dtDBId);
            cboCopyDBId.InitData(dtDBId);
        }

        #endregion

        #region :: InitControls :: 기타 Control Initialize

        /// <summary>
        /// 기타 Control Initialize
        /// </summary>
        private void InitControls()
        {
            btnCopy.Enabled = SaveAuth;
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
            const string queryId = @"dbo.QueryMaster_Select";

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, DatabaseParams);
            }

            gridList.FillData(ds);

            InitDataBindings(ds);
        }

        /// <summary>
        /// 컨트롤과 데이터를 바인딩합니다.
        /// </summary>
        private void InitDataBindings(DataSet ds)
        {
            DataTable dt = ds.Tables[0];

            cboSqlGroup.BindingMapping(dt, "SQLGROUP");
            txtQueryId.BindingMapping(dt, "QUERYID");
            txtSubject.BindingMapping(dt, "SUBJECT");
            cboDBId.BindingMapping(dt, "DBID");
            txtIdx.BindingMapping(dt, "IDX");
            cboQueryType.BindingMapping(dt, "QUERYTYPE");
            txtQueryText.BindingMapping(dt, "QUERYTEXT");
        }

        #endregion

        #region :: NewData :: 신규 처리 Method

        /// <summary>
        /// 신규 처리 Method
        /// </summary>
        private void NewData()
        {
            viewList.AddNewRow("QUERYID");
        }

        #endregion

        #region :: DeleteData :: 삭제 처리 Method

        /// <summary>
        /// 삭제 처리 Method
        /// </summary>
        private void DeleteData()
        {
            const string queryId = @"dbo.QueryMaster_Delete";

            string[] paramList = new string[] { "@QUERYID",
                                                "@IDX" };

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
            const string queryId = @"dbo.QueryMaster_Save";

            string[] paramList = new string[] { "@SQLGROUP",
                                                "@QUERYID",
                                                "@SUBJECT",
                                                "@QUERYTYPE",
                                                "@QUERYTEXT",
                                                "@DBID",
                                                "@IDX",
                                                "@CHANGEBY" };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                wb.Tx_ExecuteNonQuery(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, viewList.GetAddedModifedData());
            }
        }

        #endregion

        #region :: PrintData :: 인쇄 처리 Method

        /// <summary>
        /// 인쇄 처리 Method
        /// </summary>
        private void PrintData()
        {
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
            return base.CheckDeleteCondition(viewList.GetCheckedData());
        }

        #endregion

        #region :: CheckSaveCondition :: 저장 조건 Check Method

        /// <summary>
        /// 저장 조건 Check Method
        /// </summary>
        /// <returns></returns>
        protected override bool CheckSaveCondition()
        {
            return base.CheckSaveCondition(viewList.GetAddedModifedData());
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
