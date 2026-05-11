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
using System.Windows.Forms;

namespace EBAP.UI.ADM.Management
{
    #region :: EBAP.UI.ADM.Management.DBManagement ::

    /// <summary>
    /// Form의 업무내용을 기술합니다.
    /// </summary>
    /// <remarks>
    /// Comment     : Form 기능 및 특이사항 기록
    ///               1.  
    ///               2. 
    /// History     :
    ///               1. (2018-04-11 오전 10:59:34 - 오인봉 - PC170245) : 최초 생성
    ///               2.
    ///               3.
    /// </remarks>
    public partial class DBManagement : EBAP.Win.BaseFrame.UIFrame
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// DBManagement Form을 생성합니다.
        /// </summary>
        public DBManagement()
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

        #region :: DBManagement_Load :: Form이 Load 시 발생합니다.

        /// <summary>
        /// Form이 Load 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DBManagement_Load(object sender, EventArgs e)
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
            cboServer.InitData(AppCode.GetServerID());
        }

        /// <summary>
        /// 기타 Control Initialize
        /// </summary>
        private void InitControls()
        {

        }

        #endregion

        #region :: DBManagement_Link :: Form 간 Data 전송 시 발생합니다.

        /// <summary>
        /// Form 간 Data 전송 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DBManagement_Link(object sender, EventArgs e)
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

        #region :: DBManagement_Selection :: MainForm의 조회 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 조회 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DBManagement_Selection(object sender, EventArgs e)
        {

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

            const string queryId = @"dbo.";

            string[] paramList = new string[] { "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "@VENDORCODE",
                                                "@PLANT" };

            object[] valueList = new object[] { "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                CurrentUser.VENDORCODE,
                                                CurrentUser.PLANTCODE };

            //간단한 조회일 경우
            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.MESDB, queryId, AppConfig.COMMANDSP, paramList, valueList);
                //ds = wb.NTx_ExecuteDataSetFromQueryId(queryId, DatabaseParams);
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

        #region :: DBManagement_New :: MainForm의 신규 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 신규 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DBManagement_New(object sender, EventArgs e)
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

        #region :: DBManagement_Save :: MainForm의 저장 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 저장 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DBManagement_Save(object sender, EventArgs e)
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

        #region :: DBManagement_Delete :: MainForm의 삭제 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 삭제 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DBManagement_Delete(object sender, EventArgs e)
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
            if (sender.Equals(cboServer))
                cboDatabase.InitData(AppCode.GetDatabaseID(cboServer.EditValue.TryParseInt32()));
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

        #region :: Button_Click :: 데이터베이스를 백업 / 복원 합니다.

        /// <summary>
        /// 데이터베이스를 백업합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                string databasename = cboDatabase.Text;
                if (DialogResult.Yes != ShowMsgBox(String.Format("[ {0} ] 을(를) 백업 하시겠습니까?", databasename)
                                                  , "데이터베이스 백업", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) return;

                using (SaveFileDialog fd = new SaveFileDialog { Title = "데이터베이스 백업", FileName = String.Format("{0}_{1}", databasename, DateTime.Today.ToShortDateString()), Filter = "백업 파일|*.bak" })
                {
                    if (fd.ShowDialog(this) != DialogResult.OK) return;

                    string query = String.Format(@"BACKUP DATABASE [{0}] TO DISK = N'{1}' WITH NOFORMAT, NOINIT, NAME = N'{2}-Full Database Backup', SKIP, NOREWIND, NOUNLOAD, STATS = 10", databasename, fd.FileName, databasename);

                    using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
                    {
                        wb.NTx_ExecuteDataSet(ConnectionString.METADB, query, AppConfig.COMMANDTEXT, null, null);
                    }
                }
                ShowFlyoutDialog("백업 성공", String.Format("{0} 데이터베이스가 정상 백업 되었습니다.", databasename));
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        /// <summary>
        /// 데이터베이스를 복원합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                string databasename = cboDatabase.Text;

                if (DialogResult.Yes != ShowMsgBox(String.Format("[ {0} ] 을(를) 복원 하시겠습니까?", databasename)
                                                  , "데이터베이스 복원", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) return;

                using (OpenFileDialog ofd = new OpenFileDialog { Multiselect = true, Title = "백업 파일 찾기", FileName = "", Filter = "백업 파일(*.bak;*.trn;*.log)|*.bak;*.trn;*.log|모든 파일|*.*;", InitialDirectory = Environment.CurrentDirectory })
                {
                    if (ofd.ShowDialog(this) != DialogResult.OK) return;

                    string query = String.Format(@"USE MASTER RESTORE DATABASE [{0}] FROM DISK = N'{1}' WITH FILE = 1, NOUNLOAD, STATS = 10", databasename, ofd.FileName);

                    using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
                    {
                        wb.NTx_ExecuteDataSet(ConnectionString.METADB, query, AppConfig.COMMANDTEXT, null, null);
                    }
                }
                ShowFlyoutDialog("복원 성공", String.Format("{0} 데이터베이스가 정상 복원되었습니다.", databasename));
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
