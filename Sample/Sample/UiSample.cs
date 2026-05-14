#region 어셈블리 Sample.Sample, v3.24
// C:\EBAP-CORE.NET\Sample.Sample.dll
// CLR Version :  4.0.30319.42000
#endregion

using DevExpress.XtraGrid.Views.Grid;
using EBAP.Business.WSBiz;
using EBAP.Core.Info;
using EBAP.Data.CodeUtil;
using I2S.SQL.COMMON.DATA.OraData.Sample;
using System;
using System.Data;
using System.Security.AccessControl;
using System.Windows.Forms;

namespace EBAP.UI.Sample.Sample
{
    #region :: EBAP.UI.Sample.Sample.UiSample ::

    /// <summary>
    /// Form의 업무내용을 기술합니다.
    /// </summary>
    /// <remarks>
    /// Comment     : Form 기능 및 특이사항 기록
    ///               1.  
    ///               2. 
    /// History     :
    ///               1. (2026-05-14 오후 3:16:56 - easto - KFES) : 최초 생성
    ///               2.
    ///               3.
    /// </remarks>
    public partial class UiSample : Win.BaseFrame.UIFrame
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// TemplateForm Form을 생성합니다.
        /// </summary>
        public UiSample()
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
            this.Save -= UiSample_Save;
            this.Save += UiSample_Save;

            this.Delete -= UiSample_Delete;
            this.Delete += UiSample_Delete;

            this.New -= UiSample_New;
            this.New += UiSample_New;

            //this.viewList.InitNewRow -= new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.viewList_InitNewRow);
            //this.viewList.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.viewList_InitNewRow);

            //this.viewList.FocusedRowChanged -= new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.viewList_FocusedRowChanged);
            //this.viewList.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.viewList_FocusedRowChanged);
        }

        /// <summary>
        /// 이벤트 해제
        /// </summary>
        private void DetachEvents()
        {
            this.Save -= UiSample_Save;
            this.Delete -= UiSample_Delete;
            this.New -= UiSample_New;

            //this.viewList.InitNewRow -= new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.viewList_InitNewRow);
            //this.viewList.FocusedRowChanged -= new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.viewList_FocusedRowChanged);
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
        // Event Handler(UiSample Common Event)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: UiSample_Load :: Form이 Load 시 발생합니다.

        /// <summary>
        /// Form이 Load 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UiSample_Load(object sender, EventArgs e)
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
            viewList.BeginInit();

            // 코드로 컬럼 셋팅
            viewList.InitColumn(AppConfig.CHECKCOLUMNNAME, "Select", 50, 0, true, true, DataType.CheckEdit);
            viewList.InitColumn("ID", "ID", 100, 50, 0, false, true, DataType.Default, HorzAlign.Center);
            viewList.InitColumn("SMALL_NUM", "작은수", 100, 10, 0, true, true, DataType.Number, HorzAlign.Far);
            viewList.InitColumn("LARGE_NUM", "큰수", 120, 20, 0, true, true, DataType.Number, HorzAlign.Far);
            viewList.InitColumn("FIXED_CHAR", "고정문자", 120, 100, 0, true, true, DataType.Default, HorzAlign.Near);
            viewList.InitColumn("VARIABLE_CHAR", "가변문자", 150, 4000, 0, true, true, DataType.Default, HorzAlign.Near);
            viewList.InitColumn("COMBO_TEST", "콤보박스", 120, 50, 0, true, true, DataType.ComboBox, HorzAlign.Near);

            viewList.InitColumn("LONG_STRING", "긴문자열", 250, 4000, 0, true, true, DataType.Memo, HorzAlign.Near);
            viewList.InitColumn("DATE_COL", "날짜", 120, 20, 0, true, true, DataType.Date, HorzAlign.Center);
            viewList.InitColumn("TIMESTAMP_COL", "타임스탬프", 160, 30, 0, true, true, DataType.DateTime, HorzAlign.Center);
            viewList.InitColumn("TIMESTAMPLTZ_COL", "로컬타임존", 180, 30, 0, true, true, DataType.DateTime, HorzAlign.Center);
            viewList.InitColumn("TIMESTAMPTZ_COL", "타임존", 180, 30, 0, true, true, DataType.DateTime, HorzAlign.Center);
            
            viewList.InitColumn("RAW_COL", "RAW데이터", 150, 2000, 0, true, true, DataType.Default, HorzAlign.Near);
            viewList.InitColumn("BLOB_COL", "BLOB", 100, 0, 0, true, true, DataType.Picture, HorzAlign.Center);
            viewList.InitColumn("XML_COL", "XML", 250, 4000, 0, true, true, DataType.MemoEx, HorzAlign.Near);
            viewList.InitColumn("JSON_COL", "JSON", 250, 4000, 0, true, true, DataType.MemoEx, HorzAlign.Near);
            viewList.InitColumn("USEFLAG", "사용여부", 80, 1, 0, true, true, DataType.CheckEdit, HorzAlign.Center);
            viewList.InitColumn("CHANGEBY", "ChangeBy", 80, 0, false, false);
            viewList.InitColumn("CHANGEDTTM", "ChangeDttm", 130, 0, false, false, DataType.DateTime, HorzAlign.Center);

            viewList.InitComboBoxColumn("COMBO_TEST", AppCode.GetMESCommonCode(programId, "ComboTest"));

            // DB에서 컬럼 셋팅
            //viewList.InitColumnFromDB();

            viewList.EndInit();
        }

        /// <summary>
        /// ComboBox Initialize
        /// </summary>
        private void InitComboBox()
        {
            cboComboTest.InitData(AppCode.GetMESCommonCode(programId, "ComboTest"));
            cboCheckCombo.InitData(AppCode.GetMESCommonCode(programId, "ComboTest"));
            searchcbo.InitData(AppCode.GetMESCommonCode(programId, "ComboTest"));

            pListBoxControl1.InitData(AppCode.GetMESCommonCode(programId, "ComboTest"));
            pCheckedListBoxControl1.InitData(AppCode.GetMESCommonCode(programId, "ComboTest"));
        }

        /// <summary>
        /// 기타 Control Initialize
        /// </summary>
        private void InitControls()
        {
            pSearchControl1.SetSearchClient(gridList, "검색할 단어를 입력하세요.", 100);
        }

        #endregion

        #region :: UiSample_Link :: Form 간 Data 전송 시 발생합니다.

        /// <summary>
        /// Form 간 Data 전송 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UiSample_Link(object sender, EventArgs e)
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

        #region :: UiSample_Selection :: MainForm의 조회 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 조회 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UiSample_Selection(object sender, EventArgs e)
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

            string queryId = Q_TableName.SelectQuery(programId);

            //queryId = $@"
            //SELECT E.ID
            //    , E.SMALL_NUM
            //    , E.LARGE_NUM
            //    , E.FIXED_CHAR
            //    , E.VARIABLE_CHAR
            //    , DBMS_LOB.SUBSTR(E.LONG_STRING, 4000, 1) AS LONG_STRING
            //    , E.DATE_COL
            //    , E.TIMESTAMP_COL
            //    , E.TIMESTAMPLTZ_COL
            //    , E.TIMESTAMPTZ_COL
            //    , E.RAW_COL
            //    , E.BLOB_COL
            //    , E.XML_COL
            //    , E.JSON_COL
            //    , E.USEFLAG
            //    , E.INITDTTM
            //    , E.INITBY
            //    , E.UPDTTM
            //    , E.UPBY
            //FROM EXAMTEMP E
            //";

            string[] paramList = new string[] { ""
                                                , ""
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

            gridList.FillData(ds);

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

        #region :: UiSample_New :: MainForm의 신규 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 신규 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UiSample_New(object sender, EventArgs e)
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

        #region :: UiSample_Save :: MainForm의 저장 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 저장 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UiSample_Save(object sender, EventArgs e)
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
            string[] queryId = null;

            DataTable dt = viewList.GetAddedModifedData();

            string[] paramList = new string[] { ":ID"
                                        ,       ":SMALL_NUM"
                                        ,       ":LARGE_NUM"
                                        ,       ":FIXED_CHAR"
                                        ,       ":VARIABLE_CHAR"
                                        ,       ":COMBO_TEST"
                                        ,       ":LONG_STRING"
                                        ,       ":DATE_COL"
                                        ,       ":TIMESTAMP_COL"
                                        ,       ":TIMESTAMPLTZ_COL"
                                        ,       ":TIMESTAMPTZ_COL"
                                        ,       ":RAW_COL"
                                        ,       ":BLOB_COL"
                                        ,       ":XML_COL"
                                        ,       ":JSON_COL"
                                        ,       ":USEFLAG"
                                        ,       ":CHANGEBY"
                                                };

            queryId = new string[] { Q_TableName.Merge(programId) };

            using (OraBiz wb = new OraBiz(AppConfig.WEBSERVICEURL))
            {
                wb.Tx_ExecuteNonQuery(ConnectionString.ORAMESDB, queryId, AppConfig.COMMANDTEXT, paramList, dt);
            }
        }

        #endregion

        #region :: UiSample_Delete :: MainForm의 삭제 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 삭제 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UiSample_Delete(object sender, EventArgs e)
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
            string[] queryId = null;

            DataTable dt = viewList.GetAddedModifedData();

            string[] paramList = new string[] { ":CODE" };

            queryId = new string[] { Q_TableName.Delete(programId) };

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
    }

    #endregion
}
