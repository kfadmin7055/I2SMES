#region 어셈블리 EBAP.UI.MES.BaseInfo, v3.17
// C:\EBAP.NET\EBAP.UI.MES.BaseInfo.dll
// CLR Version : 4.0.30319.36415
#endregion

using DevExpress.XtraGrid.Views.Grid;
using EBAP.Business.WSBiz;
using EBAP.Core.Info;
using EBAP.Data.CodeUtil;
using EBAP.Win.Utility;
using System;
using System.Data;
using System.Windows.Forms;

namespace EBAP.UI.ADM.Common
{
    #region :: EBAP.UI.MES.BaseInfo.UserCell ::

    /// <summary>
    /// Form의 업무내용을 기술합니다.
    /// </summary>
    /// <remarks>
    /// Comment     : Form 기능 및 특이사항 기록
    ///               1.  
    ///               2. 
    /// History     :
    ///               1. (2018-05-14 오전 9:57:36 - 오인봉 - PC170245) : 최초 생성
    ///               2.
    ///               3.
    /// </remarks>
    public partial class UserCell : EBAP.Win.BaseFrame.UIFrame
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// UserCell Form을 생성합니다.
        /// </summary>
        public UserCell()
        {
            InitializeComponent();

            AppConfig.CurrentDB = ConnectionString.METADB;
        }

        #endregion

        #region :: 전역변수 ::

        private bool CHNAGECELL = false;

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler(Common Event)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: UserCell_Load :: Form이 Load 시 발생합니다.

        /// <summary>
        /// Form이 Load 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserCell_Load(object sender, EventArgs e)
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
            cboVendor.InitData(AppCode.GetVendorCode(CurrentUser.USERID));
            cboPlant.InitData(AppCode.GetPlantCode(CurrentUser.USERID));
        }

        /// <summary>
        /// 기타 Control Initialize
        /// </summary>
        private void InitControls()
        {
            txtUserID.ReadOnly = !CurrentUser.ISADMIN;
            txtUserName.ReadOnly = !CurrentUser.ISADMIN;

            txtUserID.EditValue = CurrentUser.USERID;
            txtUserName.EditValue = CurrentUser.USERNAME;
        }

        #endregion

        #region :: UserCell_Link :: Form 간 Data 전송 시 발생합니다.

        /// <summary>
        /// Form 간 Data 전송 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserCell_Link(object sender, EventArgs e)
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

        #region :: UserCell_Selection :: MainForm의 조회 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 조회 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserCell_Selection(object sender, EventArgs e)
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

            const string queryId = @"dbo.UserCell_Select";

            string[] paramList = new string[] { "@USERID", "@IPADDRESS" };

            object[] valueList = new object[] { txtUserID.TrimText, CurrentUser.IP };

            //간단한 조회일 경우
            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            }

            if (ds.Tables[0].Rows.Count == 0)
            {
                cboVendor.EditValue = CurrentUser.VENDORCODE;
                cboPlant.EditValue = CurrentUser.PLANTCODE;
                //cboLine.EditValue = CurrentUser.LINECODE;
                //cboCell.EditValue = CurrentUser.CELLCODE;
                //cboStationGroup.EditValue = CurrentUser.STATIONGROUP;
                //chkMoveWorkList.EditValue = "N";

                return;
            }
            //gridList.FillData(ds);

            // 그리드와 컨트롤이 바인딩이 필요하다면 주석을 제거하세요.
            InitDataBindings(ds);
        }

        /// <summary>
        /// 컨트롤과 데이터를 바인딩합니다.
        /// </summary>
        private void InitDataBindings(DataSet ds)
        {
            DataTable dt = ds.Tables[0];

            cboVendor.BindingMapping(dt, "VENDORCODE");
            cboPlant.BindingMapping(dt, "PLANTCODE");
            //cboLine.BindingMapping(dt, "LINE");
            //cboCell.BindingMapping(dt, "CELL");
            //cboStationGroup.BindingMapping(dt, "STATIONGROUP");

            //string notMove = Win32Util.GetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "MOVEWORKLIST");
            //chkMoveWorkList.EditValue = notMove == "" ? "N" : notMove;

            //string moveDispatch = Win32Util.GetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "MOVEDISPATCH");
            //chkMoveDispatch.EditValue = moveDispatch == "" ? "N" : moveDispatch;
        }

        #endregion

        #region :: UserCell_New :: MainForm의 신규 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 신규 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserCell_New(object sender, EventArgs e)
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

        #region :: UserCell_Save :: MainForm의 저장 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 저장 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserCell_Save(object sender, EventArgs e)
        {
            try
            {
                //SaveData();

                //// 저장 후 조회를 실행해야 한다면 주석을 제거하세요.
                ////RaiseSelectEvent();

                //// 저장 후 DataTable에 변경사항만 처리할 경우 주석을 제거하세요(DB 접속 필요없을 경우)
                ////viewList.AcceptChanges();
                //Win32Util.SetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "LINE", CurrentUser.LINECODE);
                //Win32Util.SetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "CELL", CurrentUser.CELLCODE);
                //Win32Util.SetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "STATIONGROUP", CurrentUser.STATIONGROUP);
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
            const string queryId = @"dbo.UserCell_Save";

            string[] paramList = new string[] { "@USERID",
                                                "@VENDORCODE",
                                                "@PLANTCODE",
                                                "@LINE",
                                                "@CELL",
                                                "@STATIONGROUP",
                                                "@IPADDRESS" };

            object[] valueList = new object[] { txtUserID.TrimText,
                                                cboVendor.EditText,
                                                cboPlant.EditText,
                                                "",
                                                "",
                                                "",
                                                CurrentUser.IP };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                wb.Tx_ExecuteNonQuery(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            }

            CurrentUser.VENDORCODE = cboVendor.EditText;
            CurrentUser.PLANTCODE = cboPlant.EditText;
            CurrentUser.LINECODE = "";
            CurrentUser.CELLCODE = "";
            CurrentUser.STATIONGROUP = "";

            CurrentUser.USERTOKEN = AppCode.GetUserToken(CurrentUser.USERID);
        }

        #endregion

        #region :: UserCell_Delete :: MainForm의 삭제 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 삭제 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserCell_Delete(object sender, EventArgs e)
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
                //string vendor = cboVendor.EditValue.ToString();
                //string plant = cboPlant.EditValue.ToString();

                //if (sender.Equals(cboVendor) || sender.Equals(cboPlant))
                //{
                //    cboLine.InitData(MESCode.GetLine(plant, vendor));
                //}
                //else if (sender.Equals(cboLine))
                //{
                //    cboCell.InitData(MESCode.GetCell(vendor, plant, cboLine.EditValue.ToString()));
                //}
                //else if (sender.Equals(cboCell))
                //{
                //    cboStationGroup.InitData(MESCode.GetStationGroup(vendor, plant, "", cboLine.EditValue.ToString(), cboCell.EditValue.ToString()));
                //}
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveData();

                // 저장 후 조회를 실행해야 한다면 주석을 제거하세요.
                //RaiseSelectEvent();

                // 저장 후 DataTable에 변경사항만 처리할 경우 주석을 제거하세요(DB 접속 필요없을 경우)
                //viewList.AcceptChanges();
                Win32Util.SetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "LINE", "");
                Win32Util.SetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "CELL", "");
                Win32Util.SetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "STATIONGROUP", "");
                Win32Util.SetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "MOVEWORKLIST", "");
                Win32Util.SetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "MOVEDISPATCH", "");

                SaveOperationLog("SAVE", GetCurrentTime());

                CHNAGECELL = true;

                ShowMsgBox("저장되었습니다. 창을 닫습니다.");
            }
            catch
            {
                throw;
            }
            finally
            {
                Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserCell_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            SetVendor(CurrentUser.VENDORCODE);
            SetPlant(CurrentUser.PLANTCODE);

            if (!CHNAGECELL || MdiParent == null) return;

            foreach (Form form in MdiParent.MdiChildren)
            {
                if (form == this) continue;

                form.Close();
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
