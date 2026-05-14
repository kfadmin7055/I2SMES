#region 어셈블리 EBAP.UI.ITM.Product, v3.24
// C:\EBAP-CORE.NET\EBAP.UI.ITM.Product.dll
// CLR Version :  4.0.30319.42000
#endregion

using DevExpress.XtraGrid.Views.Grid;
using EBAP.Business.WSBiz;
using EBAP.Core.Info;
using I2S.SQL.COMMON.DATA.OraData.Item;
using System;
using System.Data;
using System.Windows.Forms;

namespace EBAP.UI.ITM.Product
{
    #region :: EBAP.UI.ITM.Product.MixingRecipe ::

    /// <summary>
    /// Form의 업무내용을 기술합니다.
    /// </summary>
    /// <remarks>
    /// Comment     : Form 기능 및 특이사항 기록
    ///               1.  
    ///               2. 
    /// History     :
    ///               1. (2026-05-14 오전 8:45:19 - easto - KFES) : 최초 생성
    ///               2.
    ///               3.
    /// </remarks>
    public partial class MixingRecipe : EBAP.Win.BaseFrame.UIFrame
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// TemplateForm Form을 생성합니다.
        /// </summary>
        public MixingRecipe()
        {
            InitializeComponent();

            AppConfig.CurrentDB = ConnectionString.ORAMESDB;

            AttachEvents();

            programId = GetType().FullName;
        }

        /// <summary>
        /// 이벤트 생성
        /// </summary>
        private void AttachEvents()
        {
            this.Save -= MixingRecipe_Save;
            this.Save += MixingRecipe_Save;

            this.Delete -= MixingRecipe_Delete;
            this.Delete += MixingRecipe_Delete;

            this.New -= MixingRecipe_New;
            this.New += MixingRecipe_New;

            this.viewMain.InitNewRow -= new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.viewMain_InitNewRow);
            this.viewMain.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.viewMain_InitNewRow);

            this.viewMain.FocusedRowChanged -= new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.viewMain_FocusedRowChanged);
            this.viewMain.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.viewMain_FocusedRowChanged);
        }

        /// <summary>
        /// 이벤트 해제
        /// </summary>
        private void DetachEvents()
        {
            //this.Save -= MixingRecipe_Save;
            //this.Delete -= MixingRecipe_Delete;
            //this.New -= MixingRecipe_New;

            //this.viewMain.InitNewRow -= new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.viewMain_InitNewRow);
            //this.viewMain.FocusedRowChanged -= new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.viewMain_FocusedRowChanged);
        }

        /// <summary>
        /// 폼닫을 때 이벤트
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            DetachEvents();

            base.OnFormClosed(e);
        }

        #endregion

        #region :: 전역변수 ::

        private readonly string programId;

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler(MixingRecipe Common Event)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: MixingRecipe_Load :: Form이 Load 시 발생합니다.

        /// <summary>
        /// Form이 Load 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MixingRecipe_Load(object sender, EventArgs e)
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
            viewMain.BeginInit();

            // 코드로 컬럼 셋팅
            viewMain.InitColumn(AppConfig.CHECKCOLUMNNAME, "Select", 50, 0, true, true, DataType.CheckEdit);
            viewMain.InitColumn("PLANT_CODE", "공장코드", 100, 20, 0, false, true, DataType.Default, HorzAlign.Center);
            viewMain.InitColumn("PRODUCT_CODE", "제품코드", 120, 50, 0, false, true, DataType.Default, HorzAlign.Center);
            viewMain.InitColumn("PRODUCT_NAME", "제품명", 200, 200, 0, false, true, DataType.Default, HorzAlign.Near);
            viewMain.InitColumn("RECIPE_VER", "배합비버전", 100, 20, 0, false, true, DataType.Default, HorzAlign.Center);
            viewMain.InitColumn("VALID_FROM_DATE", "유효시작일", 120, 20, 0, false, true, DataType.DateTime, HorzAlign.Center);
            
            viewMain.InitColumn("VALIE_TO_DATE", "유효종료일", 120, 20, 0, false, true, DataType.DateTime, HorzAlign.Center);
            viewMain.InitColumn("MIX_STAGE", "배합단계", 100, 10, 0, false, true, DataType.ComboBox, HorzAlign.Center);
            viewMain.InitColumn("CONFIRM_YN", "확정여부", 80, 1, 0, true, true, DataType.CheckEdit, HorzAlign.Center);
            viewMain.InitColumn("CHANGEBY", "ChangeBy", 80, 0, false, false);
            viewMain.InitColumn("CHANGEDTTM", "ChangeDttm", 130, 0, false, false, DataType.DateTime, HorzAlign.Center);

            // DB에서 컬럼 셋팅
            //viewMain.InitColumnFromDB();

            viewMain.EndInit();
        }

        private void InitSubGridControl()
        {
            viewSub.BeginInit();

            // 코드로 컬럼 셋팅
            viewSub.InitColumn(AppConfig.CHECKCOLUMNNAME, "Select", 50, 0, true, true, DataType.CheckEdit);

            viewSub.InitColumn("PLANT_CODE", "공장코드", 100, 20, 0, false, false, DataType.Default, HorzAlign.Center);
            viewSub.InitColumn("PRODUCT_CODE", "제품코드", 120, 50, 0, false, false, DataType.Default, HorzAlign.Center);
            viewSub.InitColumn("RECIPE_VER", "배합비버전", 100, 20, 0, false, false, DataType.Default, HorzAlign.Center);
            viewSub.InitColumn("MixingRecipe_CODE", "원료코드", 120, 50, 0, false, true, DataType.Default, HorzAlign.Center);
            
            viewSub.InitColumn("MIX_MixingRecipe_UOM", "배합단위", 100, 20, 0, false, true, DataType.Default, HorzAlign.Center);
            viewSub.InitColumn("VALID_FROM_DATE", "유효시작일", 120, 20, 0, false, true, DataType.Date, HorzAlign.Center);
            viewSub.InitColumn("VALIE_TO_DATE", "유효종료일", 120, 20, 0, false, true, DataType.Date, HorzAlign.Center);
            viewSub.InitColumn("RATIO", "배합비율", 100, 10, 3, false, true, DataType.Number, HorzAlign.Far);
            viewSub.InitColumn("SORT_SEQ", "정렬순서", 80, 10, 0, false, true, DataType.Number, HorzAlign.Center);

            viewSub.InitColumn("CHANGEBY", "ChangeBy", 80, 0, false, false);
            viewSub.InitColumn("CHANGEDTTM", "ChangeDttm", 130, 0, false, false, DataType.DateTime, HorzAlign.Center);

            // DB에서 컬럼 셋팅
            //viewMain.InitColumnFromDB();

            viewSub.EndInit();
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

        #region :: MixingRecipe_Link :: Form 간 Data 전송 시 발생합니다.

        /// <summary>
        /// Form 간 Data 전송 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MixingRecipe_Link(object sender, EventArgs e)
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

        #region :: MixingRecipe_Selection :: MainForm의 조회 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 조회 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MixingRecipe_Selection(object sender, EventArgs e)
        {
            try
            {
                SetFormLayout();
                SetGridLayout();
                SelectionMainData();
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

            string queryId = Q_MIXING_RECIPE.SelectQuery(programId);

            string[] paramList = new string[] { "PRODUCT_CODE"
                                                , "PLANT_CODE"
                                                , "RECIPE_VER"
                                                };

            object[] valueList = new object[] { pTextEdit1.EditValue
                                                , CurrentUser.PLANTCODE
                                                , pTextEdit2.EditValue
                                                };

            //컨트롤에서 파라미터를 생성할 경우 사용하세요.
            //ParamCollection param = DatabaseParams;
            //param.Add("", "");

            using (OraBiz wb = new OraBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.ORAMESDB, queryId, AppConfig.COMMANDTEXT, paramList, valueList);
                //ds = wb.NTx_ExecuteDataSet(ConnectionString.KFAT, queryId, AppConfig.COMMANDTEXT, param);
            }

            gridMain.FillData(ds);

            // 그리드와 컨트롤이 바인딩이 필요하다면 주석을 제거하세요.
            //InitDataTableNamedings(ds);
        }

        /// <summary>
        /// 레시피 조회 처리 Method
        /// </summary>
        private void SelectionSubData()
        {
            DataSet ds;

            string queryId = Q_MIXING_RECIPE_DETAIL.SelectQuery(programId);

            string[] paramList = new string[] { "PRODUCT_CODE"
                                                , "RECIPE_VER"
                                                , ""
                                                , ""
                                                , ""
                                                , "COMPANY_CODE"
                                                , "PLANT_CODE"
                                                , "PROCESS_CODE"
                                                , "LINE_CODE"
                                                };

            object[] valueList = new object[] { ""
                                                , ""
                                                , ""
                                                , ""
                                                , ""
                                                , CurrentUser.COMPANY
                                                , CurrentUser.PLANTCODE
                                                , ""
                                                , ""
                                                };

            //컨트롤에서 파라미터를 생성할 경우 사용하세요.
            //ParamCollection param = DatabaseParams;
            //param.Add("", "");

            using (OraBiz wb = new OraBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.ORAMESDB, queryId, AppConfig.COMMANDTEXT, paramList, valueList);
                //ds = wb.NTx_ExecuteDataSet(ConnectionString.KFAT, queryId, AppConfig.COMMANDTEXT, param);
            }

            gridSub.FillData(ds);

            // 그리드와 컨트롤이 바인딩이 필요하다면 주석을 제거하세요.
            //InitDataTableNamedings(ds);
        }

        /// <summary>
        /// 컨트롤과 데이터를 바인딩합니다.
        /// </summary>
        private void InitDataTableNamedings(DataSet ds)
        {
            //DataTable dt = ds.Tables[0];

            //txtUserId.TableNamedingMapping(dt,"USERID");
            //txtUserName.TableNamedingMapping(dt,"USERNAME");
            //txtEmpNo.TableNamedingMapping(dt, "EMPNO");
        }

        #endregion

        #region :: MixingRecipe_New :: MainForm의 신규 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 신규 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MixingRecipe_New(object sender, EventArgs e)
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
            //viewMain.AddNewRow();
            //viewMain.AddNewRow("FIELDNAME");
        }

        #endregion

        #region :: MixingRecipe_Save :: MainForm의 저장 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 저장 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MixingRecipe_Save(object sender, EventArgs e)
        {
            try
            {
                SaveData();

                // 저장 후 조회를 실행해야 한다면 주석을 제거하세요.
                //RaiseSelectEvent();

                // 저장 후 DataTable에 변경사항만 처리할 경우 주석을 제거하세요(DB 접속 필요없을 경우)
                viewMain.AcceptChanges();
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
            DataTable dtMaster = viewMain.GetAddedModifedData();
            DataTable dtDetail = viewSub.GetAddedModifedData();

            if (dtMaster.Rows.Count > 0) SaveMainData(dtMaster);
            if (dtDetail.Rows.Count > 0) SaveSubData(dtDetail);
        }

        private void SaveMainData(DataTable dt)
        {
            string[] queryId = null;

            string[] paramList = new string[] {  ":PLANT_CODE"
                                        ,        ":PRODUCT_CODE"
                                        ,        ":RECIPE_VER"
                                        ,        ":VALID_FROM_DATE"
                                        ,        ":VALIE_TO_DATE"
                                        ,        ":MIX_STAGE"
                                        ,        ":CONFIRM_YN"
                                        ,        ":CHANGEBY"
                                                };

            queryId = new string[] { Q_MIXING_RECIPE.Merge(programId) };

            using (OraBiz wb = new OraBiz(AppConfig.WEBSERVICEURL))
            {
                wb.Tx_ExecuteNonQuery(ConnectionString.ORAMESDB, queryId, AppConfig.COMMANDTEXT, paramList, dt);
            }
        }

        private void SaveSubData(DataTable dt)
        {
            string[] queryId = null;

            string[] paramList = new string[] {  ":PLANT_CODE"
                                        ,        ":PRODUCT_CODE"
                                        ,        ":RECIPE_VER"
                                        ,        ":MATERIAL_CODE"
                                        ,        ":MIX_MATERIAL_UOM"
                                        ,        ":VALID_FROM_DATE"
                                        ,        ":VALIE_TO_DATE"
                                        ,        ":RATIO"
                                        ,        ":SORT_SEQ"
                                        ,        ":CHANGEBY"
                                                };

            queryId = new string[] { Q_MIXING_RECIPE.Merge(programId) };

            using (OraBiz wb = new OraBiz(AppConfig.WEBSERVICEURL))
            {
                wb.Tx_ExecuteNonQuery(ConnectionString.ORAMESDB, queryId, AppConfig.COMMANDTEXT, paramList, dt);
            }
        }

        #endregion

        #region :: MixingRecipe_Delete :: MainForm의 삭제 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 삭제 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MixingRecipe_Delete(object sender, EventArgs e)
        {
            try
            {
                DeleteData();

                // 삭제 후 조회를 실행해야 한다면 주석을 제거하세요.
                //RaiseSelectEvent();

                // 삭제 후 Check 된 ROW 만 삭제하려면 주석을 제거하세요(DB 접속 필요없을 경우)
                viewMain.RemoveCheckedRow();
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
            string[] queryId = null;

            DataTable dt = viewMain.GetAddedModifedData();

            string[] paramList = new string[] { ":CODE" };

            queryId = new string[] { Q_MIXING_RECIPE.Delete(programId) };

            using (OraBiz wb = new OraBiz(AppConfig.WEBSERVICEURL))
            {
                wb.Tx_ExecuteNonQuery(ConnectionString.ORAMESDB, queryId, AppConfig.COMMANDTEXT, paramList, dt);
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

        #region :: viewMain_InitNewRow :: 신규로 생성되는 Row의 기본값을 정의합니다.

        /// <summary>
        /// 신규로 생성되는 Row의 기본값을 정의합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewMain_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                //viewMain.SetRowCellValue(e.RowHandle, "COLUMN", "");
                //viewMain.SetRowCellValue(e.RowHandle, "COLUMN", "");
                //viewMain.SetRowCellValue(e.RowHandle, "COLUMN", "");
                //viewMain.SetRowCellValue(e.RowHandle, "COLUMN", "");
                //viewMain.SetRowCellValue(e.RowHandle, "COLUMN", "");
                //viewMain.SetRowCellValue(e.RowHandle, "COLUMN", "");
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        #region :: viewMain_CustomRowCellEditForEditing :: 클릭하면 해당 CELL을 Combo로 표시합니다.

        /// <summary>
        /// 클릭하면 해당 CELL을 Combo로 표시합니다. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewMain_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            try
            {
                //DataRow dr = viewMain.GetFocusedDataRow();

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

        #region :: viewMain_DoubleClick :: 더블 클릭하면 해당 이벤트를 발생합니다. 

        /// <summary>
        /// 더블 클릭하면 해당 이벤트를 발생합니다. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewMain_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //DataRow dr = viewMain.GetFocusedDataRow();

                //string fieldName = viewMain.FocusedColumn.FieldName;

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

        #region :: viewMain_ButtonEditClick :: Button, ButtonEdit 컬럼을 클릭하면 발생합니다.

        /// <summary>
        /// Button, ButtonEdit 컬럼을 클릭하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewMain_ButtonEditClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                //string fieldName = viewMain.FocusedColumn.FieldName;

                //DataRow fdr = viewMain.GetFocusedDataRow();

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
                //        viewMain.CancelUpdateCurrentRow();
                //    }
                //    else
                //    {
                //        string[] popColumns = new string[] { "EQUIPMODEL", "EQUIPVENDOR", "EQUIPTYPE", "TENGFLAG", "ONEGUTPFLAG", "WIRETYPE" };

                //        foreach (string pop in popColumns)
                //        {
                //            viewMain.SetFocusedRowCellValue(pop, dr[pop]);
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

        #region :: viewMain_ShowingEditor :: 조건에 따라 셀 수정 여부를 지정합니다.

        /// <summary>
        /// 조건에 따라 셀 수정 여부를 지정합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewMain_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                //if (viewMain.FocusedColumn.FieldName != "COLUMNNAME") return;

                //string status = viewMain.GetFocusedRowCellValue("STATUS").ToString();

                //if (status == "FN") e.Cancel = true;
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        #region :: viewMain_FocusedRowChanged :: 선택한 Row가 변경되면 발생합니다.

        /// <summary>
        /// 선택한 Row가 변경되면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewMain_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                //DataRow dr = viewMain.GetFocusedDataRow();

                //if (dr == null) return;
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        #region :: viewMain_CellValueChanged :: Grid 값이 변경되면 발생합니다.

        /// <summary>
        /// Grid 값이 변경되면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewMain_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                //string fieldName = e.Column.FieldName;
                //if (fieldName == "FIELDNAME")
                //{
                //    DateTime birthDate = Convert.ToDateTime(e.Value);

                //    viewMain.SetFocusedRowCellValue("AGE", (GetServerTime().Year - birthDate.Year) + 1);
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
            //return base.CheckDeleteCondition(viewMain.GetCheckedData());
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
            //return base.CheckSaveCondition(viewMain.GetAddedModifedData());
        }

        #endregion

        /// <summary>
        /// 레시피 버전 추가
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecipeAdd_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 버전 변경 이력 조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVerChangeHis_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 선택배합비 전체 확정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectedRecipeConfirm_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 배합비 확정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecipeConfirm_Click(object sender, EventArgs e)
        {

        }
    }

    #endregion
}
