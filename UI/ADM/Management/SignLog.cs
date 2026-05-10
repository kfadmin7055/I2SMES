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
    #region :: EBAP.UI.ADM.Management.SignLog ::

    /// <summary>
    /// Form의 업무내용을 기술합니다.
    /// </summary>
    /// <remarks>
    /// Comment     : Form 기능 및 특이사항 기록
    ///               1.  
    ///               2. 
    /// History     :
    ///               1. (2018-04-10 오후 5:15:12 - 오인봉 - PC170245) : 최초 생성
    ///               2.
    ///               3.
    /// </remarks>
    public partial class SignLog : EBAP.Win.BaseFrame.UIFrame
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// SignLog Form을 생성합니다.
        /// </summary>
        public SignLog()
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

        #region :: SignLog_Load :: Form이 Load 시 발생합니다.

        /// <summary>
        /// Form이 Load 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SignLog_Load(object sender, EventArgs e)
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
            viewList.BeginInit();

            viewList.InitColumn("USERID", "User", 110, 0, false, true);
            viewList.InitColumn("USERNAME", "UserName", 110, 0, false, true);
            viewList.InitColumn("GRADENAME", "Grade", 120, 0, false, true);
            viewList.InitColumn("DEPTNAME", "DeptName", 160, 0, false, true);
            viewList.InitColumn("SIGNINTIME", "로그인 시간", 140, 0, false, true, DataType.DateTime, HorzAlign.Center);
            viewList.InitColumn("SIGNOFFTIME", "로그아웃 시간", 140, 0, false, true, DataType.DateTime, HorzAlign.Center);
            viewList.InitColumn("DUEMINUTE", "사용시간(분)", 90, 0, false, true, DataType.Number, HorzAlign.Far);
            viewList.InitColumn("LOGONSTATUS", "LOGONSTATUS", 110, 0, false, false);
            viewList.InitColumn("LASTFLAG", "최종버전", 60, 0, false, true, DataType.Default, HorzAlign.Center);
            viewList.InitColumn("HOSTNAME", "Host 명", 120, 0, false, true);
            viewList.InitColumn("OS", "운영체제", 300, 0, false, true);
            viewList.InitColumn("MACADDRESS", "MAC 주소", 120, 0, false, true);
            viewList.InitColumn("IPADDRESS", "IP 주소", 120, 0, false, true);
            //viewList.InitColumn("VENDORCODE", "Vendor", 100, 0, false, true);
            //viewList.InitColumn("PLANTCODE", "Plant", 100, 0, false, true);

            //viewList.InitComboBoxColumn("VENDORCODE", AppCode.GetCodeMaster("C$GBM", ""));
            //viewList.InitComboBoxColumn("PLANTCODE", AppCode.GetOrganizationId(""));

            viewList.SetStyleFormat("LOGONSTATUS", AppConfig.CONDITIONCOLOR, DevExpress.XtraGrid.FormatConditionEnum.Equal, "ON", true);

            viewList.EndInit();

            viewMenuLog.BeginInit();

            viewMenuLog.InitColumn("VENDORCODE", "Vendor", 130, 0, false, true);
            viewMenuLog.InitColumn("PLANTCODE", "Plant", 100, 0, false, false);
            viewMenuLog.InitColumn("MENUID", "Menu", 110, 0, false, true);
            viewMenuLog.InitColumn("MENUNAME", "MenuName", 150, 0, false, true);
            viewMenuLog.InitColumn("EXETIME", "ExeDttm", 135, 0, false, true, DataType.DateTime, HorzAlign.Center);
            viewMenuLog.InitColumn("POPNAME", "Popup", 80, 0, false, true);
            viewMenuLog.InitColumn("OPERATION", "Operation", 70, 0, false, true);
            viewMenuLog.InitColumn("OPERATIONTYPE", "Operation", 70, 0, false, false);
            viewMenuLog.InitColumn("STARTDTTM", "StartDttm", 70, 0, false, true, DataType.Time, HorzAlign.Center);
            viewMenuLog.InitColumn("ENDDTTM", "EndDttm", 70, 0, false, true, DataType.Time, HorzAlign.Center);
            viewMenuLog.InitColumn("INTERVAL", "Interval", 60, 0, 3, false, true, DataType.Number, HorzAlign.Far);
            viewMenuLog.InitColumn("USESEQ", "UseSeq", 60, 0, 3, false, true, DataType.Default, HorzAlign.Far);

            viewMenuLog.InitComboBoxColumn("VENDORCODE", AppCode.GetCodeMaster("C$VENDORCODE", ""));
            viewMenuLog.InitComboBoxColumn("PLANTCODE", AppCode.GetCodeMaster("C$PLANTCODE", ""));
            viewMenuLog.InitComboBoxColumn("OPERATION", AppCode.GetCodeMaster("C$OPERATIONTYPE", ""));

            viewMenuLog.SetStyleFormat("OPERATIONTYPE", AppConfig.CONDITIONCOLOR, DevExpress.XtraGrid.FormatConditionEnum.Equal, 1, true);

            viewMenuLog.SetCellMerge("VENDORCODE", "PLANTCODE", "MENUID", "MENUNAME", "POPNAME", "EXETIME");

            viewMenuLog.EndInit();
        }

        /// <summary>
        /// ComboBox Initialize
        /// </summary>
        private void InitComboBox()
        {
            cboOperation.InitData(AppCode.GetCodeMaster("C$OPERATIONTYPE", ""));
        }

        /// <summary>
        /// 기타 Control Initialize
        /// </summary>
        private void InitControls()
        {
            DateTime date = GetCurrentTime();

            deStartEnd.SetDate(date.AddDays(-7), date.AddDays(+1));
        }

        #endregion

        #region :: SignLog_Link :: Form 간 Data 전송 시 발생합니다.

        /// <summary>
        /// Form 간 Data 전송 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SignLog_Link(object sender, EventArgs e)
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
            deStartEnd.StartDate = GetCurrentTime().AddDays(-360);
            txtUserId.EditValue = LinkParams["USERID"];
            txtUserName.EditValue = LinkParams["USERNAME"];
        }

        #endregion

        #region :: SignLog_Selection :: MainForm의 조회 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 조회 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SignLog_Selection(object sender, EventArgs e)
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
            const string queryId = @"dbo.SignLog_Select";

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.LOGDB, queryId, AppConfig.COMMANDSP, DatabaseParams);
            }

            gridMenuLog.FillData();
            gridList.FillData(ds);

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

        #region :: SignLog_New :: MainForm의 신규 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 신규 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SignLog_New(object sender, EventArgs e)
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
            //viewList.AddNewRow();
            //viewList.AddNewRow("COLUMNID");
        }

        #endregion

        #region :: SignLog_Save :: MainForm의 저장 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 저장 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SignLog_Save(object sender, EventArgs e)
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
            //                                    "@PLANT" };

            //object[] valueList = new object[] { "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    CurrentUser.VENDORCODE,
            //                                    CurrentUser.PLANTCODE };

            //using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            //{
            //    wb.Tx_ExecuteNonQuery(ConnectionString.MESDB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            //    wb.Tx_ExecuteNonQuery(ConnectionString.MESDB, queryId, AppConfig.COMMANDSP, paramList, viewList.GetAddedModifedData());
            //    wb.Tx_ExecuteNonQueryFromQueryId(queryId, paramList, valueList);
            //    wb.Tx_ExecuteNonQueryFromQueryId(queryId, paramList, viewList.GetAddedModifedData());
            //}
        }

        #endregion

        #region :: SignLog_Delete :: MainForm의 삭제 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 삭제 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SignLog_Delete(object sender, EventArgs e)
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
            //                                    "@PLANT" };

            //object[] valueList = new object[] { "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    CurrentUser.VENDORCODE,
            //                                    CurrentUser.PLANTCODE };

            //using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            //{
            //    wb.Tx_ExecuteNonQuery(ConnectionString.MESDB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            //    wb.Tx_ExecuteNonQuery(ConnectionString.MESDB, queryId, AppConfig.COMMANDSP, paramList, viewList.GetCheckedData());
            //    wb.Tx_ExecuteNonQueryFromQueryId(queryId, paramList, valueList);
            //    wb.Tx_ExecuteNonQueryFromQueryId(queryId, paramList, viewList.GetAddedModifedData());
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
                //viewList.SetRowCellValue(e.RowHandle, "COLUMN1", "");
                //viewList.SetRowCellValue(e.RowHandle, "COLUMN2", "");
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
                DataRow dr = viewList.GetFocusedDataRow();

                if (dr == null) return;

                viewMenuLog.ViewCaption = String.Format("[ {0} :          {1} - {2} ]", "Menu execute log", dr["SIGNINSEQ"], dr["USERNAME"]);
                SelectionMenuExecuteLog(dr["SIGNINSEQ"].ToString());
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="signSeq"></param>
        private void SelectionMenuExecuteLog(string signSeq)
        {
            DataSet ds;
            const string queryId = @"dbo.MenuExecuteLog_Select";

            var paramList = new string[] { "@SIGNINSEQ", "@OPERATION" };
            var valueList = new object[] { signSeq, cboOperation.EditText };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.LOGDB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            }

            gridMenuLog.FillData(ds);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMsgKey_Click(object sender, EventArgs e)
        {
            ExecutePopup("MES 메시지 키 생성", "EBAP.UI.ADM.dll", "EBAP.UI.ADM.Popup.PopMsgKey", null);
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
