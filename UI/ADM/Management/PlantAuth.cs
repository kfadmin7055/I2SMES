#region 어셈블리 EBAP.UI.ADM.Management, v3.17
// C:\EBAP.NET\EBAP.UI.ADM.dll
// CLR Version : 4.0.30319.36415
#endregion

using DevExpress.XtraGrid.Views.Grid;
using EBAP.Business.WSBiz;
using EBAP.Core.Collections;
using EBAP.Core.Info;
using EBAP.Win.Utility;
using System;
using System.Data;

namespace EBAP.UI.ADM.Management
{
    #region :: EBAP.UI.ADM.Management.PlantAuth ::

    /// <summary>
    /// Form의 업무내용을 기술합니다.
    /// </summary>
    /// <remarks>
    /// Comment     : Form 기능 및 특이사항 기록
    ///               1.  
    ///               2. 
    /// History     :
    ///               1. (2018-04-11 오후 1:15:50 - 오인봉 - PC170245) : 최초 생성
    ///               2.
    ///               3.
    /// </remarks>
    public partial class PlantAuth : EBAP.Win.BaseFrame.UIFrame
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// PlantAuth Form을 생성합니다.
        /// </summary>
        public PlantAuth()
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

        #region :: PlantAuth_Load :: Form이 Load 시 발생합니다.

        /// <summary>
        /// Form이 Load 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlantAuth_Load(object sender, EventArgs e)
        {
            try
            {
                InitLocalization();
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
            viewPlant.BeginInit();

            viewPlant.InitColumn("CODEVALUE", "PlantCode", 120, 0, false, true);
            viewPlant.InitColumn("DISPLAYVALUE", "Plant", 250, 0, false, true);

            viewPlant.EndInit();

            viewList.BeginInit();

            viewList.InitColumn(AppConfig.CHECKCOLUMNNAME, "Select", 50, 0, true, true, DataType.CheckEdit);
            viewList.InitColumn("PLANTCODE", "Plant", 80, 0, false, false);
            viewList.InitColumn("USERID", "ID", 150, 0, false, true, DataType.Default);
            viewList.InitColumn("USERNAME", "UserName", 100, 0, false, true, DataType.Popup);
            viewList.InitColumn("DEPTNAME", "DeptName", 170, 0, false, true, DataType.Default);
            viewList.InitColumn("EXPIREDATE", "ExpireDate", 110, 0, true, true, DataType.Date, HorzAlign.Center);
            viewList.InitColumn("ISDELEGATE", "권한위임", 70, 0, CurrentUser.ISADMIN, CurrentUser.ISADMIN, DataType.CheckEdit);
            viewList.InitColumn("CHANGEBY", "ChangeBy", 80, 0, false, false, DataType.Default);
            viewList.InitColumn("CHANGEDTTM", "ChangeDttm", 130, 0, false, false, DataType.DateTime);

            //// 신규입력할 때만 UserName입력가능하게 변경
            viewList.NewRowEnableColumns = new string[] { "USERNAME" };
            viewList.MandatoryColumns = new string[] { "PLANTCODE", "USERID" };

            viewList.EndInit();
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

        #region :: PlantAuth_Link :: Form 간 Data 전송 시 발생합니다.

        /// <summary>
        /// Form 간 Data 전송 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlantAuth_Link(object sender, EventArgs e)
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

        #region :: PlantAuth_Selection :: MainForm의 조회 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 조회 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlantAuth_Selection(object sender, EventArgs e)
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
            DataSet ds;
            const string queryId = @"dbo.PlantList_Select";

            ParamCollection param = DatabaseParams;
            param.Add("USERID", CurrentUser.USERID);

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, param);
            }

            gridList.FillData();
            gridPlant.FillData(ds);

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

        #region :: PlantAuth_New :: MainForm의 신규 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 신규 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlantAuth_New(object sender, EventArgs e)
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
            viewList.AddNewRow("USERNAME");
        }

        #endregion

        #region :: PlantAuth_Save :: MainForm의 저장 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 저장 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlantAuth_Save(object sender, EventArgs e)
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
            const string queryId = @"dbo.PlantAuth_Save";

            string[] paramList = new string[] { "@PLANTCODE",
                                                "@USERID",
                                                "@EXPIREDATE",
                                                "@ISDELEGATE",
                                                "@CHANGEBY" };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                wb.Tx_ExecuteNonQuery(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, viewList.GetAddedModifedData());
            }
        }

        #endregion

        #region :: PlantAuth_Delete :: MainForm의 삭제 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 삭제 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlantAuth_Delete(object sender, EventArgs e)
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
            const string queryId = @"dbo.PlantAuth_Delete";

            string[] paramList = new string[] { "@PLANTCODE",
                                                "@USERID" };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                wb.Tx_ExecuteNonQuery(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, viewList.GetCheckedData());
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
                viewList.SetRowCellValue(e.RowHandle, "PLANTCODE", viewPlant.GetFocusedRowCellValue("CODEVALUE"));
                viewList.SetRowCellValue(e.RowHandle, "EXPIREDATE", "2050-12-31 00:00:00");
                viewList.SetRowCellValue(e.RowHandle, "ISDELEGATE", 0);
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

                //e.RepositoryItem = ControlUtil.MakeComboBoxCell(FPCode.GetResourceName(GBM, ORGANIZATIONID, siteId));
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

        #region :: viewPlant_FocusedRowChanged :: 선택한 Row가 변경되면 발생합니다.

        /// <summary>
        /// 선택한 Row가 변경되면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewPlant_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow dr = viewPlant.GetFocusedDataRow();

                if (dr == null) return;

                viewList.ViewCaption = $"사업장 권한 - [ {dr["CODEVALUE"]} : {dr["DISPLAYVALUE"]} ]";

                SelectionPlantAuthData(dr["CODEVALUE"].ToString());
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plantCode"></param>
        private void SelectionPlantAuthData(string plantCode)
        {
            DataSet ds;
            const string queryId = @"dbo.PlantAuth_Select";

            ParamCollection param = new ParamCollection();
            param.Add("@PLANTCODE", plantCode);
            param.Add("@USERNAME", txtUserName.EditValue);

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, param);
            }

            gridList.FillData(ds);
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

        #region :: viewList_ButtonEditClick :: 사용자 명 입력시 사용자 사번, 부서명 가져오는 이벤트

        /// <summary>
        /// 사용자 명 입력시 사용자 사번, 부서명 가져오는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewList_ButtonEditClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                string fieldName = viewList.FocusedColumn.FieldName;

                if (fieldName != "USERNAME") return;

                ParamCollection param = new ParamCollection();
                param.Add("USERID", string.Empty);
                param.Add("USERNAME", viewList.GetFocusedRowCellValue(fieldName));
                DataRow dr = ExecutePopup("User Info", "EBAP.UI.ADM.dll", "EBAP.UI.ADM.Popup.PopUserInfo", param) as DataRow;

                if (dr == null)
                {
                    ShowMsgBox("입력한 사용자 정보가 없어요. 확인하세요", "사용자 확인");
                    viewList.CancelUpdateCurrentRow();
                }
                else
                {
                    viewList.SetFocusedRowCellValue("USERID", dr["USERID"]);
                    viewList.SetFocusedRowCellValue("USERNAME", dr["USERNAME"]);
                    viewList.SetFocusedRowCellValue("DEPTNAME", dr["DEPTNAME"]);
                }
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcelUpload_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable edt = AppUtil.GetExcelUploadData("Sheet1");

                if (edt == null) return;

                gridList.FillData();

                DataTable dt = viewList.GetDataTableByDataSource();

                DataRow dr = null;
                ShowWaitDialog("엑셀데이터 복사 중입니다.");
                int i = 1;
                foreach (DataRow edr in edt.Rows)
                {
                    ShowWaitDialog("엑셀데이터 복사 중입니다.", string.Format("{0} 번째 데이터", i++));
                    dr = dt.NewRow();

                    dr["PLANTCODE"] = edr[0];
                    dr["USERID"] = edr[1];
                    dr["USERNAME"] = edr[2];

                    viewList.AddDataRow(dr);
                }
                CloseWaitDialog();
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }


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
