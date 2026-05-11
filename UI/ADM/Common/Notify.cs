using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using EBAP.Business.WSBiz;
using EBAP.Core;
using EBAP.Core.Info;
using EBAP.Data.CodeUtil;
using System;
using System.Data;

namespace EBAP.UI.ADM.Common
{
    #region :: EBAP.UI.ADM.Common.Notify ::

    /// <summary>
    /// Form의 업무내용을 기술합니다.
    /// </summary>
    /// <remarks>
    /// Comment     : Form 기능 및 특이사항 기록
    ///               1.  
    ///               2. 
    /// History     :
    ///               1. (2018-04-10 오전 11:00:26 - 오인봉 - PC170245) : 최초 생성
    ///               2.
    ///               3.
    /// </remarks>
    public partial class Notify : EBAP.Win.BaseFrame.UIFrame
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// Notify Form을 생성합니다.
        /// </summary>
        public Notify()
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

        #region :: Notify_Load :: Form이 Load 시 발생합니다.

        /// <summary>
        /// Form이 Load 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Notify_Load(object sender, EventArgs e)
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

            viewList.InitColumn(AppConfig.CHECKCOLUMNNAME, "Select", 50, 0, true, true, DataType.CheckEdit);
            viewList.InitColumn("SEQ", "IDX", 40, 0, false, false);
            viewList.InitColumn("TYPE", "Type", 80, 0, true, true);
            viewList.InitColumn("SUBJECT", "Subject", 300, 0, true, true);
            viewList.InitColumn("CONTENTS", "Contents", 400, 0, true, true, DataType.MemoEx);
            viewList.InitColumn("PRIORITY", "Priority", 80, 0, true, true);
            viewList.InitColumn("EXPIREDATE", "ExpireDate", 100, 0, true, true, DataType.Date);
            viewList.InitColumn("CHANGEBY", "ChangeBy", 100, 0, false, true);
            viewList.InitColumn("CHANGEDTTM", "ChangeDttm", 100, 0, false, true, DataType.Date);

            viewList.InitComboBoxColumn("TYPE", AppCode.GetCodeMaster("C$NOTICETYPE", ""));
            viewList.InitComboBoxColumn("PRIORITY", AppCode.GetCodeMaster("C$NOTICEPRIORITY", ""));

            viewList.MandatoryColumns = new string[] { "SUBJECT" };

            viewList.SetStyleFormat("PRIORITY", AppConfig.CONDITIONCOLOR, FormatConditionEnum.Equal, "V");
            viewList.SetStyleFormat("EXPIREDATE", AppConfig.CONDITIONCOLOR, FormatConditionEnum.Less, GetCurrentTime(), true);

            viewList.EndInit();
        }

        /// <summary>
        /// ComboBox Initialize
        /// </summary>
        private void InitComboBox()
        {
            cboType.InitData(AppCode.GetCodeMaster("C$NOTICETYPE", ""));
        }

        /// <summary>
        /// 기타 Control Initialize
        /// </summary>
        private void InitControls()
        {

        }

        #endregion

        #region :: Notify_Link :: Form 간 Data 전송 시 발생합니다.

        /// <summary>
        /// Form 간 Data 전송 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Notify_Link(object sender, EventArgs e)
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

        #region :: Notify_Selection :: MainForm의 조회 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 조회 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Notify_Selection(object sender, EventArgs e)
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
            const string queryId = @"dbo.Notify_Select";

            string[] paramList = new string[] { "@TYPE",
                                                "@SUBJECT",
                                                "@ISADMIN" };

            object[] valueList = new object[] { cboType.EditValue,
                                                txtSubject.EditValue,
                                                CurrentUser.ISADMIN };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            }

            gridList.FillData(ds);

            // 그리드와 컨트롤이 바인딩이 필요하다면 주석을 제거하세요.
            InitDataBindings(ds);
        }

        /// <summary>
        /// 컨트롤과 데이터를 바인딩합니다.
        /// </summary>
        private void InitDataBindings(DataSet ds)
        {
            DataTable dt = ds.Tables[0];

            txtContents.BindingMapping(dt, "CONTENTS");
        }

        #endregion

        #region :: Notify_New :: MainForm의 신규 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 신규 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Notify_New(object sender, EventArgs e)
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
            viewList.AddNewRow("SUBJECT");
        }

        #endregion

        #region :: Notify_Save :: MainForm의 저장 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 저장 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Notify_Save(object sender, EventArgs e)
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
            const string queryId = @"dbo.Notify_Save";

            string[] paramList = new string[] { "@SEQ",
                                                "@TYPE",
                                                "@SUBJECT",
                                                "@CONTENTS",
                                                "@PRIORITY",
                                                "@EXPIREDATE",
                                                "@CHANGEBY" };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                wb.Tx_ExecuteNonQuery(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, viewList.GetAddedModifedData());
            }
        }

        #endregion

        #region :: Notify_Delete :: MainForm의 삭제 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 삭제 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Notify_Delete(object sender, EventArgs e)
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
            const string queryId = @"dbo.Notify_Delete";

            string[] paramList = new string[] { "@SEQ" };

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
                viewList.SetRowCellValue(e.RowHandle, "TYPE", "P");
                viewList.SetRowCellValue(e.RowHandle, "PRIORITY", "N");
                viewList.SetRowCellValue(e.RowHandle, "EXPIREDATE", GetCurrentTime().AddDays(7));
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

        #region :: viewList_FocusedRowChanged :: Master View Focused Row가 변경되면 해당 상세내용을 MemoEdit에 보여줍니다.

        /// <summary>
        /// Master View Focused Row가 변경되면 해당 상세내용을 MemoEdit에 보여줍니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = viewList.GetFocusedDataRow();
            if (dr == null || dr["EXPIREDATE"].ToString() == "") return;

            bool isValidity = Convert.ToDateTime(dr["EXPIREDATE"]) > GetCurrentTime() ? true : false;

            if (e.FocusedRowHandle == 0 && dr["PRIORITY"].ToString() == "V" && isValidity)
            {
                ShowMsgBox(dr["CONTENTS"].ToString(), dr["SUBJECT"].ToString());
            }

            //txtContents.EditValue = dr["CONTENTS"].ToString().Replace("\r\n", Environment.NewLine);
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
            string fieldname = viewList.FocusedColumn.FieldName;

            if (fieldname.In("EXPIREDATE", "isCheck")) return;

            string expiredate = viewList.GetFocusedRowCellValue("EXPIREDATE").ToString();

            if (Convert.ToDateTime(expiredate) < GetCurrentTime())
            {
                e.Cancel = true;
                txtContents.ReadOnly = true;
            }
            else
                txtContents.ReadOnly = false;
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
