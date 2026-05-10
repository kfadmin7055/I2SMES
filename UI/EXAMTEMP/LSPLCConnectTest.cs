#region 어셈블리 EBAP.UI.EXAMTEMP, v3.24
// C:\EBAP-CORE.NET\EBAP.UI.EXAMTEMP.dll
// CLR Version :  4.0.30319.42000
#endregion

using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using EBAP.Business.WSBiz;
using EBAP.Core.Collections;
using EBAP.Core.Info;
using EBAP.Data.CodeUtil;
using EBAP.Win.BaseFrame;
using EBAP.Win.Utility.PLC.LS;
using EBAP.Win.Utility.XGCommLib;
using System;
using System.Data;
using System.Diagnostics;
using XGCommLib;

namespace EBAP.UI.EXAMTEMP
{
    #region :: EBAP.UI.EXAMTEMP.LSPLCConnectTest ::

    /// <summary>
    /// Form의 업무내용을 기술합니다.
    /// </summary>
    /// <remarks>
    /// Comment     : Form 기능 및 특이사항 기록
    ///               1.  
    ///               2. 
    /// History     :
    ///               1. (2025-01-10 오전 10:09:52 - easto - KFES) : 최초 생성
    ///               2.
    ///               3.
    /// </remarks>
    public partial class LSPLCConnectTest : EBAP.Win.BaseFrame.UIFrame
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// LSPLCConnectTest Form을 생성합니다.
        /// </summary>
        public LSPLCConnectTest()
        {
            InitializeComponent();
        }

        #endregion

        #region :: 전역변수 ::
        //private XGCommSocket XGComm = new XGCommSocket();
        delegate bool SetTextCallBack(string strLog);

        private long lCountErrorRead = 0;
        private long lCountErrorWrite = 0;
        private long lCountErrorCheck = 0;
        private long lMaxAccessTimeRead = 0;
        private long lMaxAccessTimeWrite = 0;
        LSPLCManager lSPLCManager = new LSPLCManager();

        

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler(LSPLCConnectTest Common Event)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: LSPLCConnectTest_Load :: Form이 Load 시 발생합니다.

        /// <summary>
        /// Form이 Load 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LSPLCConnectTest_Load(object sender, EventArgs e)
        {
            try
            {
                InitLocalization();
                InitGlobalInstance();
                InitComboBox();
                InitGridControl();
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
        private void InitGridControl()
        {
            //viewList.BeginInit();

            // 코드로 컬럼 셋팅
            //viewList.InitColumn(AppConfig.CHECKCOLUMNNAME, "Select", 50, 0, true, true, DataType.CheckEdit);
            //viewList.InitColumn("FIELD", "Caption", 75, 0, false, true, DataType.Default, HorzAlign.Default);
            //viewList.InitColumn("CHANGEBY", "ChangeBy", 80, 0, false, false);
            //viewList.InitColumn("CHANGEDTTM", "ChangeDttm", 130, 0, false, false, DataType.DateTime, HorzAlign.Center);

            // DB에서 컬럼 셋팅
            //viewList.InitColumnFromDB();

            //viewList.EndInit();
        }

        /// <summary>
        /// ComboBox Initialize
        /// </summary>
        private void InitComboBox()
        {
            cboMemoryType.InitData(AppCode.GetCodeMaster("C$PLCMemoryType", ""));
            cboDataType.InitData(AppCode.GetCodeMaster("C$PLCDataType", ""));
        }

        /// <summary>
        /// 기타 Control Initialize
        /// </summary>
        private void InitControls()
        {

        }

        #endregion

        #region Time Event

        private void tmKeepAlive_Tick(object sender, EventArgs e)
        {
            uint uReturn;

            uReturn = XGComm.UpdateKeepAlive();
            if (uReturn == (uint)XGCOMM_FUNC_RESULT.RT_XGCOMM_SUCCESS)
            {
                chkAliveStatus.Checked = true;
            }
            else
            {
                chkAliveStatus.Checked = false;
            }
        }

        private void tmLibTest_Tick(object sender, EventArgs e)
        {
            DoTest();
        }

        private void tmUpdateCtrl_Tick(object sender, EventArgs e)
        {
            txtErrorCountWrite.Text = Convert.ToString(lCountErrorWrite);
            txtErrorCountRead.Text = Convert.ToString(lCountErrorRead);
            txtErrorCountCheck.Text = Convert.ToString(lCountErrorCheck);

            txtMaxTime.Text = string.Format("{0, 3}  :{1, 3}", lMaxAccessTimeWrite, lMaxAccessTimeRead);
        }

        private void DoTest()
        {
            uint uReturn;

            long lSize, lOffset, lCount;

            double dReadTime, dWriteTime;
            string strLog = "", strRead = "", strWrite = "", strHead = "", strFull = "";
            Random rand = new Random();
            Stopwatch stopwatch = new Stopwatch();

            lSize = Convert.ToInt32(txtDataCount.Text);
            lOffset = Convert.ToInt32(txtStartPoint.Text);

            if (lSize <= 0)
                return;

            byte[] byWrite = new byte[lSize];
            byte[] byRead = new byte[lSize];

            for (lCount = 0; lCount < lSize; lCount++)
            {
                byWrite[lCount] = (byte)rand.Next(0, 255); ;
            }

            stopwatch.Start();
            uReturn = XGComm.WriteDataByte((char)cboMemoryType.EditValue, lOffset, lSize, byWrite);
            stopwatch.Stop();

            dWriteTime = stopwatch.ElapsedMilliseconds;
            if (uReturn == (uint)XGCOMM_FUNC_RESULT.RT_XGCOMM_SUCCESS)
            {
                lMaxAccessTimeWrite = Math.Max((long)dWriteTime, lMaxAccessTimeWrite);

                strHead = string.Format("Write Data [{0, 4}][{1, 4}] ->", lSize, (long)dWriteTime);
                for (lCount = 0; lCount < lSize; lCount++)
                {
                    strLog = string.Format((" {0:X2}"), byWrite[lCount]);
                    strWrite += strLog;
                }
                strFull = strHead + strWrite;
                AddLog(strFull);

                stopwatch.Start();
                uReturn = XGComm.ReadDataByte((char)cboMemoryType.EditValue, lOffset, lSize, byRead);
                stopwatch.Stop();

                dReadTime = stopwatch.ElapsedMilliseconds;
                lMaxAccessTimeRead = Math.Max((long)dReadTime, lMaxAccessTimeRead);
                if (uReturn == (uint)XGCOMM_FUNC_RESULT.RT_XGCOMM_SUCCESS)
                {
                    strHead = string.Format("Read  Data [{0, 4}][{1, 4}] <-", lSize, (long)dReadTime);
                    for (lCount = 0; lCount < lSize; lCount++)
                    {
                        strLog = string.Format(" {0:X2}", byRead[lCount]);
                        strRead += strLog;
                    }
                    strFull = strHead + strRead;
                    AddLog(strFull);

                    if (strWrite != strRead)
                    {
                        lCountErrorCheck++;
                        if (chkUseErrorStop.Checked == true)
                        {
                            tmLibTest.Enabled = false;
                            chkTest.Checked = false;
                        }
                    }
                }
                else
                {
                    lCountErrorRead++;
                }
            }
            else
            {
                lCountErrorWrite++;
                AddLog(XGComm.GetReturnCodeString(uReturn));
            }
        }

        #endregion

        #region :: LSPLCConnectTest_Link :: Form 간 Data 전송 시 발생합니다.

        /// <summary>
        /// Form 간 Data 전송 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LSPLCConnectTest_Link(object sender, EventArgs e)
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

        #region :: LSPLCConnectTest_Selection :: MainForm의 조회 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 조회 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LSPLCConnectTest_Selection(object sender, EventArgs e)
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

            //string queryId = Q_TableName.SelectQuery(string reference);

            string[] paramList = new string[] { "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "VENDORCODE",
                                                "PLANTCODE" };

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

            using (OraBiz_CS wb = new OraBiz_CS())
            {
                //ds = wb.NTx_ExecuteDataSet(ConnectionString.KFAT, queryId, AppConfig.COMMANDTEXT, paramList, valueList);
                //ds = wb.NTx_ExecuteDataSet(ConnectionString.KFAT, queryId, AppConfig.COMMANDTEXT, param);
            }

            //gridList.FillData(ds);

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

        #region :: LSPLCConnectTest_New :: MainForm의 신규 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 신규 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LSPLCConnectTest_New(object sender, EventArgs e)
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
            //viewList.AddNewRow("FIELDNAME");
        }

        #endregion

        #region :: LSPLCConnectTest_Save :: MainForm의 저장 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 저장 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LSPLCConnectTest_Save(object sender, EventArgs e)
        {
            try
            {
                SaveData();

                // 저장 후 조회를 실행해야 한다면 주석을 제거하세요.
                //RaiseSelectEvent();

                // 저장 후 DataTable에 변경사항만 처리할 경우 주석을 제거하세요(DB 접속 필요없을 경우)
                //viewList.AcceptChanges();
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
            //string[] queryId = null;

            //DataTable dt = viewList.GetAddedModifedData();

            //string[] paramList = new string[] { "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "",
            //                                    "VENDORCODE",
            //                                    "PLANTCODE", 
            //                                    "CHANGEBY" };

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

            //using (OraBiz_CS wb = new OraBiz_CS())
            //{
            //    wb.Tx_ExecuteNonQuery(ConnectionString.KFAT, queryId, AppConfig.COMMANDTEXT, paramList, valueList);
            //    wb.Tx_ExecuteNonQuery(ConnectionString.KFAT, queryId, AppConfig.COMMANDTEXT, paramList, viewList.GetAddedModifedData());
            //}
        }

        #endregion

        #region :: LSPLCConnectTest_Delete :: MainForm의 삭제 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 삭제 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LSPLCConnectTest_Delete(object sender, EventArgs e)
        {
            try
            {
                DeleteData();

                // 삭제 후 조회를 실행해야 한다면 주석을 제거하세요.
                //RaiseSelectEvent();

                // 삭제 후 Check 된 ROW 만 삭제하려면 주석을 제거하세요(DB 접속 필요없을 경우)
                //viewList.RemoveCheckedRow();
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
            //                                    "VENDORCODE",
            //                                    "PLANTCODE", 
            //                                    "CHANGEBY" };

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

            //using (OraBiz_CS wb = new OraBiz_CS())
            //{
            //    wb.Tx_ExecuteNonQuery(ConnectionString.KFMETA, queryId, AppConfig.COMMANDTEXT, paramList, valueList);
            //    wb.Tx_ExecuteNonQuery(ConnectionString.KFMETA, queryId, AppConfig.COMMANDTEXT, paramList, viewList.GetCheckedData());
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
                //DataRow dr = viewList.GetFocusedDataRow();

                //if (dr == null) return;
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

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (XGComm.Connect(txtPLCIP.Text, Convert.ToInt32(txtPLCPort.Text)) != (uint)XGCOMM_FUNC_RESULT.RT_XGCOMM_SUCCESS)
            {
                AddLog("==> Connect Fail !! \n");
            }
            else
            {
                AddLog("Connect success... (IP: {0}, PORT: {1})", txtPLCIP.Text, txtPLCPort.Text);
            }
        }

        private bool AddLog(string strLog, params object[] values)
        {
            string strValue;

            strValue = string.Format(strLog, values);
            return AddLog(strValue);
        }

        private bool AddLog(string strLog)
        {
            string strTimeLog;

            DateTime dt = DateTime.Now;

            strTimeLog = dt.ToString("[hh:mm:ss.fff] ") + strLog;
            listLog.SelectedIndex = listLog.Items.Count - 1;

            if (listLog.Items.Count > 100)
            {
                listLog.Items.RemoveAt(0);
            }

            if (this.listLog.InvokeRequired)
            {
                SetTextCallBack dele = new SetTextCallBack(AddLog);
                this.Invoke(dele, new object[] { strTimeLog });
            }
            else
            {
                this.listLog.Items.Add(strTimeLog);
                this.listLog.SelectedIndex = this.listLog.Items.Count - 1;
            }

            return true;
        }

        /// <summary>
        /// PLC 쓰기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWrite_Click(object sender, EventArgs e)
        {
            long lSize, lOffset;
            string nDataType;
            char szDeviceType;

            lSize = Convert.ToInt32(txtDataCount.Text);
            lOffset = Convert.ToInt32(txtStartPoint.Text);
            if (lSize <= 0)
                return;

            nDataType = cboDataType.EditValue.ToString();
            szDeviceType = (char)cboMemoryType.EditValue;

            lSPLCManager.WriteDataBit(XGComm, szDeviceType, lSize, lOffset, (int)txtWriteData.EditValue);

            switch (nDataType)
            {
                //case DEF_DATA_TYPE.DATA_TYPE_BIT:
                //    WriteDataBit(szDeviceType, lSize, lOffset);
                //    break;

                //case DEF_DATA_TYPE.DATA_TYPE_BYTE:
                //    WriteDataByte(szDeviceType, lSize, lOffset);
                //    break;

                //case DEF_DATA_TYPE.DATA_TYPE_WORD:
                //    WriteDataWord(szDeviceType, lSize, lOffset);
                //    break;
            }
        }

        /// <summary>
        /// PLC 읽기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRead_Click(object sender, EventArgs e)
        {
            long lSize, lOffset;
            string nDataType;
            char szDeviceType;

            lSize = Convert.ToInt32(txtDataCount.Text);
            lOffset = Convert.ToInt32(txtStartPoint.Text);
            if (lSize <= 0)
                return;

            nDataType = cboDataType.EditValue.ToString();
            szDeviceType = (char)cboMemoryType.EditValue;

            switch (nDataType)
            {
                //case DEF_DATA_TYPE.DATA_TYPE_BIT:
                //    ReadDataBit(szDeviceType, lSize, lOffset);
                //    break;

                //case DEF_DATA_TYPE.DATA_TYPE_BYTE:
                //    ReadDataByte(szDeviceType, lSize, lOffset);
                //    break;

                //case DEF_DATA_TYPE.DATA_TYPE_WORD:
                //    ReadDataWord(szDeviceType, lSize, lOffset);
                //    break;
            }
        }

        private void listLog_DoubleClick(object sender, EventArgs e)
        {
            listLog.Items.Clear();
        }

        private void chkKeepAlive_CheckedChanged(object sender, EventArgs e)
        {
            tmKeepAlive.Enabled = chkKeepAlive.Checked;
        }

        private void chkTest_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTest.Checked == true)
            {
                Int32 lScanTime;

                lCountErrorRead = 0;
                lCountErrorWrite = 0;
                lCountErrorCheck = 0;
                lMaxAccessTimeRead = 0;
                lMaxAccessTimeWrite = 0;

                lScanTime = Convert.ToInt32(txtScanTime.Text);
                lScanTime = (10 > lScanTime) ? 10 : lScanTime;

                tmLibTest.Interval = lScanTime;
                tmLibTest.Enabled = true;
            }
            else
            {
                tmLibTest.Enabled = false;
            }
        }
    }

    #endregion
}
