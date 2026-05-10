#region 어셈블리 EBAP.UI.PRD.Product, v3.24
// C:\I2S\EBAP.UI.PRD.Product.dll
// CLR Version :  4.0.30319.42000
#endregion

using DevExpress.Data;
using DevExpress.Schedule;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using EBAP.Business.WSBiz;
using EBAP.Core.Info;
using I2S.SQL.COMMON.DATA.OraData.Dosing;
using I2S.SQL.COMMON.DATA.OraData.ProductInfo;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EBAP.UI.PRD.Product
{
    #region :: EBAP.UI.PRD.Product.DosingWorkPlan ::

    /// <summary>
    /// Form의 업무내용을 기술합니다.
    /// </summary>
    /// <remarks>
    /// Comment     : Form 기능 및 특이사항 기록
    ///               1.  
    ///               2. 
    /// History     :
    ///               1. (2026-04-23 오후 1:44:19 - easto - KFES) : 최초 생성
    ///               2.
    ///               3.
    /// </remarks>
    public partial class DosingWorkPlan : Win.BaseFrame.UIFrame
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// DosingWorkPlan Form을 생성합니다.
        /// </summary>
        public DosingWorkPlan()
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
        // Event Handler(DosingWorkPlan Common Event)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: DosingWorkPlan_Load :: Form이 Load 시 발생합니다.

        /// <summary>
        /// Form이 Load 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DosingWorkPlan_Load(object sender, EventArgs e)
        {
            try
            {
                InitLocalization();
                InitGlobalInstance();
                InitComboBox();
                InitMainGridControl();
                InitSubGridControl();
                InitControls();

                //Form Load 후 조회를 실행해야 한다면 주석을 제거하세요.
                //IsLoadSelectEvent = true;
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
        /// 전역변수 Initialize
        /// </summary>
        private void InitGlobalInstance()
        {
        }

        /// <summary>
        /// Grid Control Initialize
        /// </summary>
        private void InitMainGridControl()
        {
            viewList.BeginInit();

            // 코드로 컬럼 셋팅
            viewList.InitColumn(AppConfig.CHECKCOLUMNNAME, "Select", 50, 0, true, true, DataType.CheckEdit);
            viewList.InitColumn("PLANT_CODE", "Plant", 75, 0, false, false, DataType.Default, HorzAlign.Default);
            viewList.InitColumn("PROCESS_CODE", "Process", 75, 1, false, false, DataType.Default, HorzAlign.Default);
            viewList.InitColumn("LINE_CODE", "Line", 75, 2, false, false, DataType.Default, HorzAlign.Default);
            viewList.InitColumn("WORK_DATE", "WorkDate", 90, 3, false, false, DataType.DateTime, HorzAlign.Center);
            viewList.InitColumn("WORK_NUM", "WorkNum", 75, 4, false, true, DataType.Default, HorzAlign.Center);
            viewList.InitColumn("PRODUCT_CODE", "Material", 100, 5, false, true, DataType.Default, HorzAlign.Default);
            viewList.InitColumn("RECIPE_VER", "Recipe Ver", 75, 6, false, true, DataType.Default, HorzAlign.Center);
            viewList.InitColumn("BATCH_QTY", "BatchQty", 90, 7, false, true, DataType.Number, HorzAlign.Far);
            viewList.InitColumn("BATCH_CNT", "BatchCnt", 75, 8, false, true, DataType.Number, HorzAlign.Far);
            viewList.InitColumn("REPROCESS_YN", "ReProcess", 75, 9, false, true, DataType.Default, HorzAlign.Center);
            viewList.InitColumn("TAGET_BIN", "TagetBin", 90, 10, false, true, DataType.Default, HorzAlign.Default);
            viewList.InitColumn("TAGET_BIN2", "TagetBin2", 90, 11, false, true, DataType.Default, HorzAlign.Default);
            viewList.InitColumn("RUN_BATCH", "RunBatch", 90, 12, false, true, DataType.Number, HorzAlign.Far);
            viewList.InitColumn("SHIFT_CODE", "Shift", 75, 13, false, true, DataType.Default, HorzAlign.Center);
            viewList.InitColumn("WORKER", "Worker", 100, 14, false, true, DataType.Default, HorzAlign.Default);
            viewList.InitColumn("ORDER_QTY", "OrderQty", 100, 15, false, true, DataType.Number, HorzAlign.Far);
            viewList.InitColumn("PROD_QTY", "ProdQty", 100, 16, false, true, DataType.Number, HorzAlign.Far);
            viewList.InitColumn("WORK_STATE", "WorkState", 80, 17, false, true, DataType.Default, HorzAlign.Center);
            viewList.InitColumn("START_TIME", "StartTime", 120, 21, false, true, DataType.DateTime, HorzAlign.Center);
            viewList.InitColumn("END_TIME", "EndTime", 120, 18, false, true, DataType.DateTime, HorzAlign.Center);
            viewList.InitColumn("REMARKS", "Remarks", 150, 19, false, true, DataType.Default, HorzAlign.Default);
            viewList.InitColumn("DELFLAG", "DelFlag", 60, 20, false, true, DataType.Default, HorzAlign.Center);
            viewList.InitColumn("CHANGE_DTTM", "ChangeDTTM", 120, 10, false, false, DataType.DateTime, HorzAlign.Center);
            viewList.InitColumn("CHANGE_USER", "ChangeUser", 120, 11, false, false, DataType.DateTime, HorzAlign.Center);

            // DB에서 컬럼 셋팅
            viewList.InitColumnFromDB();

            viewList.EndInit();
        }

        private void InitSubGridControl()
        {
            viewResult.BeginInit();

            viewResult.InitColumn("PLANT_CODE", "Plant", 75, 0, false, false, DataType.Default, HorzAlign.Default);
            viewResult.InitColumn("PROCESS_CODE", "Process", 75, 1, false, false, DataType.Default, HorzAlign.Default);
            viewResult.InitColumn("LINE_CODE", "Line", 75, 2, false, false, DataType.Default, HorzAlign.Default);
            viewResult.InitColumn("WORK_DATE", "WorkDate", 90, 3, false, false, DataType.DateTime, HorzAlign.Center);
            viewResult.InitColumn("WORK_NUM", "WorkNum", 75, 4, false, false, DataType.Default, HorzAlign.Center);
            viewResult.InitColumn("SCALE_CODE", "Scale", 90, 5, false, true, DataType.Default, HorzAlign.Default);
            viewResult.InitColumn("BIN_CODE", "Bin", 90, 6, false, true, DataType.Default, HorzAlign.Default);
            viewResult.InitColumn("MATERIAL_CODE", "Material", 120, 7, false, true, DataType.Default, HorzAlign.Default);
            viewResult.InitColumn("MIX_QTY", "MixQty", 100, 8, 3, false, true, DataType.Number, HorzAlign.Far);
            viewResult.InitColumn("MIX_RATIO", "MixRatio", 90, 9, 3, false, true, DataType.Number, HorzAlign.Far);
            viewResult.InitColumn("CHANGE_DTTM", "ChangeDTTM", 120, 10, false, false, DataType.DateTime, HorzAlign.Center);
            viewResult.InitColumn("CHANGE_USER", "ChangeUser", 120, 11, false, false, DataType.DateTime, HorzAlign.Center);

            viewResult.OptionsView.ShowGroupPanel = false;
            viewResult.OptionsView.ShowFooter = true;
            viewResult.OptionsBehavior.AutoExpandAllGroups = true;

            viewResult.SetColumnSummary("MIX_QTY", SummaryType.Sum);
            viewResult.SetColumnSummary("MIX_RATIO", SummaryType.Sum);

            viewResult.Columns["SCALE_CODE"].GroupIndex = 0;

            // DB에서 컬럼 셋팅
            viewResult.InitColumnFromDB();

            // 🔥 Summary
            viewResult.GroupSummary.Add(SummaryItemType.Count, "SCALE_CODE", null);

            GridGroupSummaryItem custom = new GridGroupSummaryItem();
            custom.FieldName = "RESULTVALUE";
            custom.SummaryType = SummaryItemType.Custom;
            viewResult.GroupSummary.Add(custom);

            pColorLegend.Controls.Add(CreateLegend("정상 ≤20", Color.Honeydew, 10));
            pColorLegend.Controls.Add(CreateLegend("주의 ≤40", Color.LightYellow, 120));
            pColorLegend.Controls.Add(CreateLegend("경고 ≤60", Color.Moccasin, 230));
            pColorLegend.Controls.Add(CreateLegend("위험 ≤80", Color.LightCoral, 340));
            pColorLegend.Controls.Add(CreateLegend("심각 ≤100", Color.IndianRed, 450));
            pColorLegend.Controls.Add(CreateLegend("오류 >100", Color.Black, 560));

            viewResult.EndInit();
        }

        private Control CreateLegend(string text, Color color, int left)
        {
            Panel container = new Panel();
            container.Width = 110;
            container.Height = 25;

            container.Left = left;
            container.Top = 0;

            Panel box = new Panel();
            box.BackColor = color;
            box.Width = 15;
            box.Height = 15;
            box.Left = 0;
            box.Top = 5;

            Label lbl = new Label();
            lbl.Text = text;
            lbl.Left = 20;
            lbl.Top = 3;
            lbl.AutoSize = true;

            container.Controls.Add(box);
            container.Controls.Add(lbl);

            return container;
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

        #region :: DosingWorkPlan_Link :: Form 간 Data 전송 시 발생합니다.

        /// <summary>
        /// Form 간 Data 전송 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DosingWorkPlan_Link(object sender, EventArgs e)
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

        #region :: DosingWorkPlan_Selection :: MainForm의 조회 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 조회 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DosingWorkPlan_Selection(object sender, EventArgs e)
        {
            try
            {
                SetFormLayout();
                SetGridLayout();
                SelectionMainData();
                SelectionSubData();
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
        private void SelectionMainData()
        {
            DataSet ds;

            string queryId = Q_WORK_ORDER.SelectQuery("EBAP.UI.PRD.Product.DosingWorkPlan");

            string[] paramList = new string[] { "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "@VENDORCODE",
                                                "@PLANTCODE" };

            object[] valueList = new object[] { "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                CurrentUser.VENDORCODE,
                                                CurrentUser.PLANTCODE };

            //컨트롤에서 파라미터를 생성할 경우 사용하세요.
            //ParamCollection param = DatabaseParams;
            //param.Add("", "");

            using (OraBiz wb = new OraBiz(AppConfig.WEBSERVICEURL))
            {
                

                ds = wb.NTx_ExecuteDataSet(ConnectionString.ORAMETADB, queryId, AppConfig.COMMANDSP, paramList, valueList);
                //ds = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, param);
            }

            gridList.FillData(ds);

            // 그리드와 컨트롤이 바인딩이 필요하다면 주석을 제거하세요.
            //InitDataBindings(ds);
        }

        /// <summary>
        /// 조회 처리 Method
        /// </summary>
        private void SelectionSubData(string plant = "", string process = "", string line = "", string workDate = "", string workNum = "")
        {
            DataSet ds;
            DataTable dt;

            // 기존 컬럼 초기화
            viewResult.Columns.Clear();

            // 데이터 초기화
            gridResult.DataSource = null;

            InitSubGridControl();

            string query = Q_MIX_RESULT.SelectBatchQuery("EBAP.UI.PRD.Product.DosingWorkPlan");

            string[] paramList = new string[] {
                                                "PLANT_CODE"
                                                , "PROCESS_CODE"
                                                , "LINE_CODE"
                                                , "WORK_DATE"
                                                , "WORK_NUM"
                                            };

            object[] valueList = new object[] {
                                                plant
                                                , process
                                                , line
                                                , workDate
                                                , workNum
                                                };

            using (OraBiz_CS wb = new OraBiz_CS())
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.ORAMETADB, query, AppConfig.COMMANDSP, paramList, valueList);
                //ds = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, param);
            }

            if (ds != null)
            {
                dt = ds.Tables[0];

                int maxBatch = dt.AsEnumerable()
                                .Where(r => r["BATCH_NUM"] != DBNull.Value)
                                .Select(r => Convert.ToInt32(r["BATCH_NUM"]))
                                .DefaultIfEmpty(0)
                                .Max();

                Color[] batchColors =
                                    {
                                        Color.LightCyan,
                                        Color.MistyRose,
                                        Color.Honeydew,
                                        Color.LavenderBlush,
                                        Color.LightYellow
                                    };

                for (int i = 0; i < maxBatch; i++)
                {
                    int colorIndex = i % 5;

                    // 계량
                    GridColumn colQty = viewResult.Columns.AddField($"MIX_VALUE{i + 1}");
                    colQty.Caption = $"{i + 1}배치 계량";
                    colQty.Visible = true;
                    colQty.VisibleIndex = viewResult.Columns.Count;
                    colQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    colQty.DisplayFormat.FormatString = "n3";

                    colQty.AppearanceCell.BackColor = batchColors[colorIndex];
                    colQty.AppearanceHeader.BackColor = batchColors[colorIndex];

                    viewResult.SetColumnSummary($"MIX_VALUE{i + 1}", SummaryType.Sum);

                    // 편차
                    GridColumn colDiff = viewResult.Columns.AddField($"MIX_DIFF{i + 1}");
                    colDiff.Caption = $"{i + 1}배치 편차";
                    colDiff.Visible = true;
                    colDiff.VisibleIndex = viewResult.Columns.Count;
                    colDiff.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    colDiff.DisplayFormat.FormatString = "n3";

                    colDiff.AppearanceCell.BackColor = batchColors[colorIndex];
                    colDiff.AppearanceHeader.BackColor = batchColors[colorIndex];

                    viewResult.SetColumnSummary($"MIX_DIFF{i + 1}", SummaryType.Sum);

                    // 시간
                    GridColumn colTime = viewResult.Columns.AddField($"MIX_TIME{i + 1}");
                    colTime.Caption = $"{i + 1}배치 시간";
                    colTime.Visible = true;
                    colTime.VisibleIndex = viewResult.Columns.Count;
                    colTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    colTime.DisplayFormat.FormatString = "n0";

                    colTime.AppearanceCell.BackColor = batchColors[colorIndex];
                    colTime.AppearanceHeader.BackColor = batchColors[colorIndex];

                    viewResult.SetColumnSummary($"MIX_TIME{i + 1}", SummaryType.Sum);
                }
            }

            string queryId = SelectResultQuery("EBAP.UI.PRD.Product.DosingWorkPlan", ds.Tables[0]);

            //컨트롤에서 파라미터를 생성할 경우 사용하세요.
            //ParamCollection param = DatabaseParams;
            //param.Add("", "");

            using (OraBiz_CS wb = new OraBiz_CS())
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.ORAMETADB, queryId, AppConfig.COMMANDSP, paramList, valueList);
                //ds = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, param);
            }

            gridResult.FillData(ds);
            
            // 그리드와 컨트롤이 바인딩이 필요하다면 주석을 제거하세요.
            //InitDataBindings(ds);
        }

        /// <summary>
        /// 계량 설정값과 실적을 조회
        /// </summary>
        /// <param name="reference"></param>
        /// <returns></returns>
        public static string SelectResultQuery(string reference, DataTable dt)
        {
            string queryText = string.Empty;

            StringBuilder sb = new StringBuilder();

            foreach (DataRow dr in dt.Rows)
            {
                string batch = dr["BATCH_NUM"].ToString();

                sb.AppendLine($@"
                    , SUM(CASE WHEN mr.BATCH_NUM = {batch} AND mr.BIN_CODE = ms.BIN_CODE
                            THEN mr.RESULT_QTY_ACT 
                            ELSE 0
                            END) AS MIX_VALUE{batch}

                    , SUM(CASE WHEN mr.BATCH_NUM = {batch} AND mr.BIN_CODE = ms.BIN_CODE
                            THEN NVL(mr.RESULT_QTY_SET, 0) - NVL(mr.RESULT_QTY_ACT, 0)
                            ELSE 0
                            END) AS MIX_DIFF{batch}

                    , SUM(CASE WHEN mr.BATCH_NUM = {batch} AND mr.BIN_CODE = ms.BIN_CODE
                            THEN NVL(mr.MIX_TIME, 0)
                            ELSE 0
                            END) AS MIX_TIME{batch}");
            }

            queryText = $@"
            /* {reference} */
            SELECT ms.PLANT_CODE
                , ms.PROCESS_CODE
                , ms.LINE_CODE
                , ms.WORK_DATE
                , ms.WORK_NUM
                , ms.SCALE_CODE
                , ms.BIN_CODE
                , ms.MATERIAL_CODE
                , ms.MIX_QTY
                , ms.MIX_RATIO
                {sb}
            FROM MIX_SETTING ms
                LEFT JOIN MIX_SETTING_HISTORY msh ON msh.PLANT_CODE = ms.PLANT_CODE
                                                            AND msh.PROCESS_CODE = ms.PROCESS_CODE
                                                            AND msh.LINE_CODE = ms.LINE_CODE
                                                            AND msh.WORK_DATE = ms.WORK_DATE
                                                            AND msh.WORK_NUM = ms.WORK_NUM
                                                            AND msh.OLD_BIN_CODE = ms.BIN_CODE
                LEFT JOIN MIX_RESULT mr ON mr.PLANT_CODE = ms.PLANT_CODE
                                                            AND mr.PROCESS_CODE = ms.PROCESS_CODE
                                                            AND mr.LINE_CODE = ms.LINE_CODE
                                                            AND mr.WORK_DATE = ms.WORK_DATE
                                                            AND mr.WORK_NUM = ms.WORK_NUM
                                                            AND mr.BIN_CODE = NVL(msh.NEW_BIN_CODE, ms.BIN_CODE)
                LEFT JOIN MATERIAL M ON m.MATERIAL_CODE = mr.MATERIAL_CODE
            WHERE (:PLANT_CODE IS NULL OR ms.PLANT_CODE = :PLANT_CODE)
                AND (:PROCESS_CODE IS NULL OR ms.PROCESS_CODE = :PROCESS_CODE)
                AND (:LINE_CODE IS NULL OR ms.LINE_CODE = :LINE_CODE)
                AND (:WORK_DATE IS NULL OR ms.WORK_DATE = :WORK_DATE)
                AND (:WORK_NUM IS NULL OR ms.WORK_NUM = :WORK_NUM)
            GROUP BY ms.PLANT_CODE
                , ms.PROCESS_CODE
                , ms.LINE_CODE
                , ms.WORK_DATE
                , ms.WORK_NUM
                , ms.SCALE_CODE
                , ms.BIN_CODE
                , ms.MATERIAL_CODE
                , ms.MIX_QTY
                , ms.MIX_RATIO
            ";

            return queryText;
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

        #region :: DosingWorkPlan_New :: MainForm의 신규 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 신규 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DosingWorkPlan_New(object sender, EventArgs e)
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
            viewList.AddNewRow();
            //viewList.AddNewRow("FIELDNAME");
        }

        #endregion

        #region :: DosingWorkPlan_Save :: MainForm의 저장 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 저장 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DosingWorkPlan_Save(object sender, EventArgs e)
        {
            try
            {
                SaveData();

                // 저장 후 조회를 실행해야 한다면 주석을 제거하세요.
                //RaiseSelectEvent();

                // 저장 후 DataTable에 변경사항만 처리할 경우 주석을 제거하세요(DB 접속 필요없을 경우)
                viewList.AcceptChanges();
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
            //const string queryId = @"dbo.";

            //string[] paramList = new string[] { "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "@VENDORCODE",
            //                                    "@PLANTCODE", 
            //                                    "@CHANGEBY" };

            //object[] valueList = new object[] { "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    CurrentUser.VENDORCODE,
            //                                    CurrentUser.PLANTCODE,
            //                                    CurrentUser.USERID };

            //using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            //{
            //    wb.Tx_ExecuteNonQuery(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            //    wb.Tx_ExecuteNonQuery(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, viewList.GetAddedModifedData());
            //}
        }

        #endregion

        #region :: DosingWorkPlan_Delete :: MainForm의 삭제 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 삭제 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DosingWorkPlan_Delete(object sender, EventArgs e)
        {
            try
            {
                DeleteData();

                // 삭제 후 조회를 실행해야 한다면 주석을 제거하세요.
                //RaiseSelectEvent();

                // 삭제 후 Check 된 ROW 만 삭제하려면 주석을 제거하세요(DB 접속 필요없을 경우)
                viewList.RemoveCheckedRow();
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
            //const string queryId = @"dbo.";

            //string[] paramList = new string[] { "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "@VENDORCODE",
            //                                    "@PLANTCODE", 
            //                                    "@CHANGEBY" };

            //object[] valueList = new object[] { "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    CurrentUser.VENDORCODE,
            //                                    CurrentUser.PLANTCODE,
            //                                    CurrentUser.USERID };

            //using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            //{
            //    wb.Tx_ExecuteNonQuery(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            //    wb.Tx_ExecuteNonQuery(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, viewList.GetCheckedData());
            //}
        }

        #endregion

        #region :: DosingWorkPlan_Save :: MainForm의 저장 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 저장 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DosingWorkPlan_Copy(object sender, EventArgs e)
        {
            try
            {
                CopyData();

                // 저장 후 조회를 실행해야 한다면 주석을 제거하세요.
                //RaiseSelectEvent();

                // 저장 후 DataTable에 변경사항만 처리할 경우 주석을 제거하세요(DB 접속 필요없을 경우)
                viewList.AcceptChanges();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 저장 처리 Method
        /// </summary>
        private void CopyData()
        {
            //const string queryId = @"dbo.";

            //string[] paramList = new string[] { "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "@VENDORCODE",
            //                                    "@PLANTCODE", 
            //                                    "@CHANGEBY" };

            //object[] valueList = new object[] { "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    CurrentUser.VENDORCODE,
            //                                    CurrentUser.PLANTCODE,
            //                                    CurrentUser.USERID };

            //using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            //{
            //    wb.Tx_ExecuteNonQuery(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            //    wb.Tx_ExecuteNonQuery(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, viewList.GetAddedModifedData());
            //}
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
                //viewList.SetRowCellValue(e.RowHandle, "COLUMN", "");
                //viewList.SetRowCellValue(e.RowHandle, "COLUMN", "");
                //viewList.SetRowCellValue(e.RowHandle, "COLUMN", "");
                //viewList.SetRowCellValue(e.RowHandle, "COLUMN", "");
                //viewList.SetRowCellValue(e.RowHandle, "COLUMN", "");
                //viewList.SetRowCellValue(e.RowHandle, "COLUMN", "");
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

                //e.RepositoryItem = ControlUtil.MakeComboBoxCell(AppCode.GetCodeMaster("C$", ""));
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        #region :: viewList_DoubleClick :: 더블 클릭하면 해당 이벤트를 발생합니다. 

        /// <summary>
        /// 더블 클릭하면 해당 이벤트를 발생합니다. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //DataRow dr = viewList.GetFocusedDataRow();

                //string fieldName = viewList.FocusedColumn.FieldName;

                //if (dr == null) return;

                //if (fieldName != "fieldName") return;

                //if (Convert.ToInt32(dr["CNT"]) < 1) return;

                //ParamCollection linkParam = new ParamCollection();
                //linkParam.Add("PARAMNAME", dr["PARAMCOLUMN"]);

                //ExecuteUI("SYS0101", linkParam);
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        #region :: viewList_ButtonEditClick :: Button, ButtonEdit 컬럼을 클릭하면 발생합니다.

        /// <summary>
        /// Button, ButtonEdit 컬럼을 클릭하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewList_ButtonEditClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                //string fieldName = viewList.FocusedColumn.FieldName;

                //DataRow fdr = viewList.GetFocusedDataRow();

                //if (fdr == null) return;

                //if (fieldName == "EQUIPIMG")//이미지 등록 눌렀을 때
                //{
                //    ParamCollection param = new ParamCollection();
                //    param.Add("PARAMNAME", "");
                //    param.Add("PARAMNAME", "");
                //    param.Add("PARAMNAME", "");
                //    param.Add("EQUIPMODEL", fdr["PARAMCOLUMN"]);

                //    ExecutePopup("이미지 등록", "EBAP.UI.ITMS.dll", "EBAP.UI.ITMS.Popup.PopEquipImage", param);
                //}

                //if (fieldName == "EQUIPMODEL")//모델 검색 눌렀을 때
                //{
                //    ParamCollection param = new ParamCollection();
                //    param.Add("PARAMNAME", "");
                //    param.Add("PARAMNAME", "");
                //    param.Add("PARAMNAME", "");
                //    param.Add("EQUIPMODEL", fdr["PARAMCOLUMN"]);

                //    DataRow dr = ExecutePopup("장비 모델 정보", "EBAP.UI.ITMS.dll", "EBAP.UI.ITMS.Popup.PopEquipModel", param) as DataRow;

                //    if (dr == null)
                //    {
                //        ShowMsgBox("입력한 장비 모델 정보가 없습니다. 확인하세요", "모델 확인");
                //        viewList.CancelUpdateCurrentRow();
                //    }
                //    else
                //    {
                //        string[] popColumns = new string[] { "EQUIPMODEL", "EQUIPVENDOR", "EQUIPTYPE", "TENGFLAG", "ONEGUTPFLAG", "WIRETYPE" };

                //        foreach (string pop in popColumns)
                //        {
                //            viewList.SetFocusedRowCellValue(pop, dr[pop]);
                //        }
                //    }
                //}
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

        #region :: viewList_FocusedRowChanged :: 선택한 Row가 변경되면 발생합니다.

        /// <summary>
        /// 선택한 Row가 변경되면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                DataSet ds = null;
                DataTable dt = null;
                DataRow dr = viewList.GetFocusedDataRow();

                if (dr == null) return;

                string plant = Convert.ToString(viewList.GetFocusedRowCellValue("PLANT_CODE"));
                string process = Convert.ToString(viewList.GetFocusedRowCellValue("PROCESS_CODE"));
                string line = Convert.ToString(viewList.GetFocusedRowCellValue("LINE_CODE"));
                string date = Convert.ToString(viewList.GetFocusedRowCellValue("WORK_DATE"));
                string num = Convert.ToString(viewList.GetFocusedRowCellValue("WORK_NUM"));

                SelectionSubData(plant, process, line, date, num);
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
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

        #region :: viewResult_CustomDrawGroupRow :: 그룹 행을 그립니다.
        /// <summary>
        /// viewResult 그룹 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewResult_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            var info = e.Info as DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo;
            if (info == null) return;

            GridView view = sender as GridView;
            if (!view.IsGroupRow(e.RowHandle)) return;

            string scaleCode = Convert.ToString(view.GetGroupRowValue(e.RowHandle));
            int count = view.GetChildRowCount(e.RowHandle);

            decimal sumSet = 0;   // 설정값
            decimal sumAct = 0;   // 계량값

            for (int i = 0; i < count; i++)
            {
                int childRowHandle = view.GetChildRowHandle(e.RowHandle, i);

                foreach (GridColumn col in view.Columns)
                {
                    object val = view.GetRowCellValue(childRowHandle, col);

                    if (val == null || val == DBNull.Value)
                        continue;

                    if (!decimal.TryParse(val.ToString(), out decimal num))
                        continue;

                    // 🔥 설정값 합계
                    if (col.FieldName.StartsWith("MIX_VALUE"))
                        sumSet += num;

                    // 🔥 계량값 합계
                    if (col.FieldName.StartsWith("RESULT_VALUE"))
                        sumAct += num;
                }
            }

            decimal diff = Math.Abs(sumSet - sumAct);

            // 🔥 그룹 텍스트
            info.GroupText = $"▶ SCALE {scaleCode} | 원료 {count}건 | 설정 {sumSet:n0} / 계량 {sumAct:n0} / 편차 {diff:n0}";

            // 🔥 색상 단계 적용 ⭐⭐⭐
            if (diff <= 20)
            {
                info.Appearance.BackColor = Color.Honeydew;
                info.Appearance.ForeColor = Color.DarkGreen;
            }
            else if (diff <= 40)
            {
                info.Appearance.BackColor = Color.LightYellow;
                info.Appearance.ForeColor = Color.Goldenrod;
            }
            else if (diff <= 60)
            {
                info.Appearance.BackColor = Color.Moccasin;
                info.Appearance.ForeColor = Color.DarkOrange;
            }
            else if (diff <= 80)
            {
                info.Appearance.BackColor = Color.LightCoral;
                info.Appearance.ForeColor = Color.DarkRed;
            }
            else if (diff <= 100)
            {
                info.Appearance.BackColor = Color.IndianRed;
                info.Appearance.ForeColor = Color.White;
            }
            else
            {
                info.Appearance.BackColor = Color.Black;
                info.Appearance.ForeColor = Color.White;
            }

            // 폰트
            info.Appearance.Font = new Font("맑은 고딕", 9F, FontStyle.Bold);
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

        /// <summary>
        /// 작업시작 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWorkStart_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 작업 강제종료 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWorkEnd_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// viewResult 모두 펼치기, 접기 토글 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToggle_Click(object sender, EventArgs e)
        {
            bool isAnyExpanded = viewResult.GetRowExpanded(viewResult.FocusedRowHandle);

            if (isAnyExpanded)
            {
                viewResult.CollapseAllGroups();
                btnToggle.Text = "모두 펼치기";
            }
            else
            {
                viewResult.ExpandAllGroups();
                btnToggle.Text = "모두 접기";
            }
        }
    }

    #endregion
}
