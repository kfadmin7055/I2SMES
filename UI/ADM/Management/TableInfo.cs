#region 어셈블리 EBAP.UI.ADM.Management, v3.17
// C:\EBAP.NET\EBAP.UI.ADM.dll
// CLR Version : 4.0.30319.36415
#endregion

using DevExpress.XtraGrid.Views.Grid;
using EBAP.Business.WSBiz;
using EBAP.Core;
using EBAP.Core.Info;
using EBAP.Data.CodeUtil;
using System;
using System.Data;

namespace EBAP.UI.ADM.Management
{
    #region :: EBAP.UI.ADM.Management.TableInfo ::

    /// <summary>
    /// Form의 업무내용을 기술합니다.
    /// </summary>
    /// <remarks>
    /// Comment     : Form 기능 및 특이사항 기록
    ///               1.  
    ///               2. 
    /// History     :
    ///               1. (2018-04-11 오후 3:35:21 - 오인봉 - PC170245) : 최초 생성
    ///               2.
    ///               3.
    /// </remarks>
    public partial class TableInfo : EBAP.Win.BaseFrame.UIFrame
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// TableInfo Form을 생성합니다.
        /// </summary>
        public TableInfo()
        {
            InitializeComponent();
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

        #region :: TableInfo_Load :: Form이 Load 시 발생합니다.

        /// <summary>
        /// Form이 Load 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TableInfo_Load(object sender, EventArgs e)
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

        #region :: TableInfo_Authentication :: 사용자 권한 처리 시 발생합니다.

        /// <summary>
        /// 사용자 권한 처리 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TableInfo_Authentication(object sender, EventArgs e)
        {

        }

        #endregion

        #region :: TableInfo_Link :: Form 간 Data 전송 시 발생합니다.

        /// <summary>
        /// Form 간 Data 전송 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TableInfo_Link(object sender, EventArgs e)
        {
            try
            {
                LinkData();
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        #region :: TableInfo_Selection :: MainForm의 조회 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 조회 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TableInfo_Selection(object sender, EventArgs e)
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

        #region :: TableInfo_New :: MainForm의 신규 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 신규 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TableInfo_New(object sender, EventArgs e)
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

        #region :: TableInfo_Delete :: MainForm의 삭제 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 삭제 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TableInfo_Delete(object sender, EventArgs e)
        {
            try
            {
                DeleteData();

                // 삭제 후 조회를 실행해야 한다면 주석을 제거하세요.
                //RaiseSelectEvent();

                // 삭제 후 Check 된 ROW 만 삭제하려면 주석을 제거하세요(DB 접속 필요없을 경우)
                //viewList.RemoveCheckedRow();
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        #region :: TableInfo_Save :: MainForm의 저장 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 저장 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TableInfo_Save(object sender, EventArgs e)
        {
            try
            {
                SaveData();

                // 저장 후 조회를 실행해야 한다면 주석을 제거하세요.
                //RaiseSelectEvent();

                // 저장 후 DataTable에 변경사항만 처리할 경우 주석을 제거하세요(DB 접속 필요없을 경우)
                //viewList.AcceptChanges();
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        #region :: TableInfo_Print :: MainForm의 인쇄 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 인쇄 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TableInfo_Print(object sender, EventArgs e)
        {
            try
            {
                if (!CheckPrintCondition()) return;

                PrintData();
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        #region :: TableInfo_Chart :: MainForm의 Chart Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 Chart Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TableInfo_Chart(object sender, EventArgs e)
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
                if (sender.Equals(cboServer))
                    cboDatabase.InitData(AppCode.GetDatabaseID(cboServer.EditValue.TryParseInt32()));
                if (sender.Equals(cboDatabase))
                    cboTable.InitData(AppCode.GetTableID(Convert.ToInt32(cboServer.EditValue), Convert.ToInt32(cboDatabase.EditValue)));

                if (sender.Equals(cboTable))
                    txtDesc.EditValue = cboTable.GetColumnValue("DESCRIPTION");
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
                //viewList.SetRowCellValue(e.RowHandle, "VendorCode", CurrentUser.VendorCode);
                //viewList.SetRowCellValue(e.RowHandle, "PlantCode", CurrentUser.PlantCode);
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
            InitColumnGrid();
            InitIndexGrid();
            InitTopRowGrid();
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitColumnGrid()
        {
            viewColumn.BeginInit();

            viewColumn.InitColumn("key_ordinal", "PK", 60, 0, false, true, DataType.Default, HorzAlign.Center);
            viewColumn.InitColumn("ColumnName", "컬럼명", 180);
            viewColumn.InitColumn("TypeName", "데이터 타입", 120);
            viewColumn.InitColumn("Length", "길이", 80, 0, false, true, DataType.Default, HorzAlign.Center);
            viewColumn.InitColumn("is_nullable", "NULL 허용", 80, 0, false, true, DataType.CheckEdit);
            viewColumn.InitColumn("is_identity", "IDENTITY", 80, 0, false, true, DataType.CheckEdit);
            viewColumn.InitColumn("Description", "컬럼 설명", 200, 0, false, true);

            viewColumn.EndInit();
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitIndexGrid()
        {
            viewIndex.BeginInit();

            viewIndex.OptionsView.ShowGroupPanel = false;

            viewIndex.InitColumn("name", "INDEX 명", 180);
            viewIndex.InitColumn("type_desc", "TYPE", 120);
            viewIndex.InitColumn("is_unique", "UNIQUE", 80, 0, false, true, DataType.CheckEdit);
            viewIndex.InitColumn("is_primary_key", "PK", 80, 0, false, true, DataType.CheckEdit);
            viewIndex.InitColumn("fill_factor", "FILL FACTOR", 120);

            viewIndex.EndInit();
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitTopRowGrid()
        {
            viewTopRow.BeginInit();

            viewTopRow.OptionsBehavior.Editable = false;
            viewTopRow.OptionsView.ShowGroupPanel = false;

            viewTopRow.EndInit();
        }

        #endregion

        #region :: InitComboBox :: ComboBox Initialize

        /// <summary>
        /// ComboBox Initialize
        /// </summary>
        private void InitComboBox()
        {
            cboServer.InitData(AppCode.GetServerID());
        }

        #endregion

        #region :: InitControls :: 기타 Control Initialize

        /// <summary>
        /// 기타 Control Initialize
        /// </summary>
        private void InitControls()
        {

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
            cboServer.EditValue = LinkParams["SERVERID"];
            cboDatabase.EditValue = LinkParams["DATABASEID"];
            cboTable.EditValue = LinkParams["TABLEID"];
            txtDesc.EditValue = LinkParams["DESCRIPTION"];
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
            const string queryId = @"dbo.TableInfo_get";

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, DatabaseParams);
            }

            gridColumn.FillData(ds);

            gridIndex.FillData(ds, "Table1");

            viewTopRow.Columns.Clear();
            gridTopRow.FillData(ds, "Table2");
            viewTopRow.BestFitColumns();
        }

        #endregion

        #region :: NewData :: 신규 처리 Method

        /// <summary>
        /// 신규 처리 Method
        /// </summary>
        private void NewData()
        {
            //viewList.AddNewRow();
        }

        #endregion

        #region :: DeleteData :: 삭제 처리 Method

        /// <summary>
        /// 삭제 처리 Method
        /// </summary>
        private void DeleteData()
        {
            //const string queryId = @"NAPS.UI.ADM.Management.TableInfo.deleteTableInfo";

            //string[] paramList = new string[] { "@VendorCode",
            //                                    "@Plant" };

            //object[] valueList = new object[] { CurrentUser.VendorCode,
            //                                    CurrentUser.PlantCode };

            //using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            //{
            //   wb.Tx_ExecuteNonQueryFromQueryId(queryId, paramList, valueList);
            //   wb.Tx_ExecuteNonQueryFromQueryId(queryId, paramList, viewList.GetCheckedData());
            //}
        }

        #endregion

        #region :: SaveData :: 저장 처리 Method

        /// <summary>
        /// 저장 처리 Method
        /// </summary>
        private void SaveData()
        {
            //const string queryId = @"NAPS.UI.ADM.Management.TableInfo.saveTableInfo";

            //string[] paramList = new string[] { "@VendorCode",
            //                                    "@Plant" };

            //object[] valueList = new object[] { CurrentUser.VendorCode,
            //                                    CurrentUser.PlantCode };

            //using (WsBiz wb = new WsBiz(AppConfig.WEBSERVICEURL))
            //{
            //    wb.Tx_ExecuteNonQueryFromQueryId(queryId, paramList, valueList);
            //    wb.Tx_ExecuteNonQueryFromQueryId(queryId, paramList, viewList.GetAddedModifedData());
            //}
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
            return true;
        }

        #endregion

        #region :: CheckPrintCondition :: 인쇄 조건 Check Method

        /// <summary>
        /// 인쇄 조건 Check Method
        /// </summary>
        /// <returns></returns>
        private bool CheckPrintCondition()
        {
            return true;
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
