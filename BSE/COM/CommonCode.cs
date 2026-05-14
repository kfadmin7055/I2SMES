#region 어셈블리 EBAP.UI.BSE.COM, v3.24
// C:\EBAP-CORE.NET\EBAP.UI.BSE.COM.dll
// CLR Version :  4.0.30319.42000
#endregion

using DevExpress.DataProcessing.InMemoryDataProcessor;
using DevExpress.XtraEditors.Filtering;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraScheduler.Native;
using EBAP.Business.WSBiz;
using EBAP.Core.Info;
using EBAP.Win.ControlLibrary;
using I2S.SQL.COMMON.DATA.OraData.Base;
using System;
using System.Data;

namespace EBAP.UI.BSE.COM
{
    #region :: EBAP.UI.BSE.COM.CommonCode ::

    /// <summary>
    /// Form의 업무내용을 기술합니다.
    /// </summary>
    /// <remarks>
    /// Comment     : Form 기능 및 특이사항 기록
    ///               1.  
    ///               2. 
    /// History     :
    ///               1. (2026-05-11 오전 11:01:52 - easto - KFES) : 최초 생성
    ///               2.
    ///               3.
    /// </remarks>
    public partial class CommonCode : EBAP.Win.BaseFrame.UIFrame
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// TemplateForm Form을 생성합니다.
        /// </summary>
        public CommonCode()
        {
            InitializeComponent();
            AppConfig.CurrentDB = ConnectionString.ORAMESDB;
        }

        #endregion

        #region :: 전역변수 ::


        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler(CommonCode Common Event)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: CommonCode_Load :: Form이 Load 시 발생합니다.

        /// <summary>
        /// Form이 Load 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommonCode_Load(object sender, EventArgs e)
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
        private void InitMainGridControl()
        {
            viewMain.BeginInit();

            // 코드로 컬럼 셋팅
            viewMain.InitColumn(AppConfig.CHECKCOLUMNNAME, "Select", 50, 0, true, true, DataType.CheckEdit);
            viewMain.InitColumn("PCODEVALUE", "CodeValue", 100, 40, false, true, DataType.Default, HorzAlign.Default);
            viewMain.InitColumn("CODEVALUE", "CodeValue", 160, 50, false, false, DataType.Default, HorzAlign.Default);
            viewMain.InitColumn("DISPLAYVALUE", "DisplayValue", 200, 50, true, true, DataType.Memo, HorzAlign.Default);
            viewMain.InitColumn("SORT_NUM", "SortNumber", 200, 50, false, false, DataType.Number, HorzAlign.Far);
            viewMain.InitColumn("USEFLAG", "UseFlag", 200, 50, true, true, DataType.CheckEdit, HorzAlign.Default);
            viewMain.InitColumn("CHANGEBY", "ChangeBy", 80, 0, false, false);
            viewMain.InitColumn("CHANGEDTTM", "ChangeDttm", 130, 0, false, false, DataType.DateTime, HorzAlign.Center);

            // 신규 입력만 가능한 컬럼
            viewMain.NewRowEnableColumns = new string[] { "PCODEVALUE" };

            // 필수 입력 컬럼
            viewMain.MandatoryColumns = new string[] { "PCODEVALUE", "CODEVALUE", "DISPLAYVALUE" };

            viewMain.KeyColumns = new string[] { "PCODEVALUE", "CODEVALUE" };

            // DB에서 컬럼 셋팅
            //viewList.InitColumnFromDB();

            viewMain.EndInit();
        }

        private void InitSubGridControl()
        {
            viewSub.BeginInit();

            // 코드로 컬럼 셋팅
            viewSub.InitColumn(AppConfig.CHECKCOLUMNNAME, "Select", 50, 0, true, true, DataType.CheckEdit);
            viewSub.InitColumn("PCODEVALUE", "Group", 100, 40, false, false, DataType.Default, HorzAlign.Default);
            viewSub.InitColumn("CODEVALUE", "CodeValue", 160, 50, false, true, DataType.Default, HorzAlign.Default);
            viewSub.InitColumn("DISPLAYVALUE", "DisplayValue", 200, 50, true, true, DataType.Default, HorzAlign.Default);
            viewSub.InitColumn("SORT_NUM", "SortNumber", 200, 50, true, true, DataType.Number, HorzAlign.Far);
            viewSub.InitColumn("REF1", "Reference1", 200, 50, true, true, DataType.Default, HorzAlign.Default);
            viewSub.InitColumn("REF1NAME", "ReferenceName1", 200, 50, true, true, DataType.Default, HorzAlign.Default);
            viewSub.InitColumn("REF2", "Reference2", 200, 50, true, true, DataType.Default, HorzAlign.Default);
            viewSub.InitColumn("REF2NAME", "ReferenceName2", 200, 50, true, true, DataType.Default, HorzAlign.Default);
            viewSub.InitColumn("REF3", "Reference3", 200, 50, true, true, DataType.Default, HorzAlign.Default);
            viewSub.InitColumn("REF3NAME", "ReferenceName3", 200, 50, true, true, DataType.Default, HorzAlign.Default);
            viewSub.InitColumn("USEFLAG", "UseFlag", 200, 50, true, true, DataType.CheckEdit, HorzAlign.Default);
            viewSub.InitColumn("CHANGEBY", "ChangeBy", 80, 0, false, false);
            viewSub.InitColumn("CHANGEDTTM", "ChangeDttm", 130, 0, false, false, DataType.DateTime, HorzAlign.Center);

            // 신규 입력만 가능한 컬럼
            viewSub.NewRowEnableColumns = new string[] { "CODEVALUE" };

            // 필수 입력 컬럼
            viewSub.MandatoryColumns = new string[] { "CODEVALUE", "DISPLAYVALUE" };

            viewSub.KeyColumns = new string[] { "PCODEVALUE", "CODEVALUE" };

            // DB에서 컬럼 셋팅
            //viewList.InitColumnFromDB();

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

        #region :: CommonCode_Link :: Form 간 Data 전송 시 발생합니다.

        /// <summary>
        /// Form 간 Data 전송 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommonCode_Link(object sender, EventArgs e)
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

        #region :: CommonCode_Selection :: MainForm의 조회 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 조회 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommonCode_Selection(object sender, EventArgs e)
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

            string queryId = Q_COMMON_CODE.SelectMainQuery("EBAP.UI.BSE.COM.CommonCode");

            string[] paramList = new string[] { "CODEVALUE"
                                                , "DISPLAYVALUE"
                                                , "USEFLAG"
                                                };

            object[] valueList = new object[] { "$COMMON"
                                                ,txtGroup.EditValue
                                                , cboUseFlag.EditValue
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

            //if (viewGroup.RowCount > 0)
            //{
            //    viewGroup.FocusedRowHandle = 0;
            //    viewList_FocusedRowChanged(viewGroup,
            //        new FocusedRowChangedEventArgs(-1, 0));
            //}

            // 그리드와 컨트롤이 바인딩이 필요하다면 주석을 제거하세요.
            //InitDataTableNamedings(ds);
        }

        private void SelectionSubData(string pGroupCode)
        {
            DataSet ds;

            string queryId = Q_COMMON_CODE.SelectSubQuery("EBAP.UI.BSE.COM.CommonCode");

            string[] paramList = new string[] { "PCODEVALUE"
                                                , "DISPLAYVALUE"
                                                , "USEFLAG"
                                                };

            object[] valueList = new object[] { pGroupCode
                                                , txtGroup.EditValue
                                                , cboUseFlag.EditValue
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

        #region :: CommonCode_New :: MainForm의 신규 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 신규 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommonCode_New(object sender, EventArgs e)
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
            const string code = "CODEVALUE";

            if (gridMain.IsFocused || gridMain.ContainsFocus)
                viewMain.AddNewRow(code);
            else if (gridSub.IsFocused || gridSub.ContainsFocus)
                viewSub.AddNewRow(code);
            else
                viewMain.AddNewRow(code);

            //viewList.AddNewRow("FIELDNAME");
        }

        #endregion

        #region :: CommonCode_Save :: MainForm의 저장 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 저장 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommonCode_Save(object sender, EventArgs e)
        {
            try
            {
                SaveData();

                // 저장 후 조회를 실행해야 한다면 주석을 제거하세요.
                RaiseSelectEvent();

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
            DataTable dtMain = viewMain.GetAddedModifedData();
            DataTable dtSub = viewSub.GetAddedModifedData();

            if (dtMain.Rows.Count > 0) SaveMainData(dtMain);
            if (dtSub.Rows.Count > 0) SaveSubData(dtSub);
        }
                
        private void SaveMainData(DataTable dt)
        {
            string[] queryId = null;

            string[] paramList = new string[] { ":CODEVALUE"
                                            , ":DISPLAYVALUE"
                                            , ":PCODEVALUE"
                                            , ":USEFLAG"
                                            , ":CHANGEBY"
                                                };

            queryId = new string[] { Q_COMMON_CODE.MergeMain("EBAP.UI.BSE.COM.CommonCode.SaveMainData") };

            using (OraBiz wb = new OraBiz(AppConfig.WEBSERVICEURL))
            {
                wb.Tx_ExecuteNonQuery(ConnectionString.ORAMESDB, queryId, AppConfig.COMMANDTEXT, paramList, dt);
            }
        }

        private void SaveSubData(DataTable dt)
        {
            string[] queryId = null;

            string[] paramList = new string[] { ":CODEVALUE"
                                            , ":DISPLAYVALUE"
                                            , ":PCODEVALUE"
                                            , ":SORT_NUM"
                                            , ":REF1"
                                            , ":REF1_NAME"
                                            , ":REF2"
                                            , ":REF2_NAME"
                                            , ":REF3"
                                            , ":REF3_NAME"
                                            , ":USEFLAG"
                                            , ":CHANGEBY"
                                                };

            queryId = new string[] { Q_COMMON_CODE.MergeSub("EBAP.UI.BSE.COM.CommonCode.SaveSubData") };

            using (OraBiz wb = new OraBiz(AppConfig.WEBSERVICEURL))
            {
                wb.Tx_ExecuteNonQuery(ConnectionString.ORAMESDB, queryId, AppConfig.COMMANDTEXT, paramList, dt);
            }
        }

        #endregion

        #region :: CommonCode_Delete :: MainForm의 삭제 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 삭제 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommonCode_Delete(object sender, EventArgs e)
        {
            try
            {
                DeleteData();

                // 삭제 후 조회를 실행해야 한다면 주석을 제거하세요.
                RaiseSelectEvent();

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
            DataTable dtMaster = viewMain.GetCheckedData();
            DataTable dtSub = viewSub.GetCheckedData();

            if (dtMaster.Rows.Count > 0) DeleteMainData(dtMaster);
            if (dtSub.Rows.Count > 0) DeleteSubData(dtSub);
        }
        
        /// <summary>
        /// 삭제 처리 Method
        /// </summary>
        private void DeleteMainData(DataTable dt)
        {
            string[] queryId = null;

            string[] paramList = new string[] { ":PCODEVALUE"
                                                };

            queryId = new string[] { Q_COMMON_CODE.DeleteMain("EBAP.UI.BSE.COM.CommonCode") };

            using (OraBiz wb = new OraBiz(AppConfig.WEBSERVICEURL))
            {
                wb.Tx_ExecuteNonQuery(ConnectionString.ORAMESDB, queryId, AppConfig.COMMANDTEXT, paramList, dt);
            }
        }

        private void DeleteSubData(DataTable dt)
        {
            string[] queryId = null;

            string[] paramList = new string[] { ":PCODEVALUE"
                                            , ":CODEVALUE"
                                                };

            queryId = new string[] { Q_COMMON_CODE.DeleteSub("EBAP.UI.BSE.COM.CommonCode") };

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

                if (sender.Equals(viewMain))
                {
                    viewMain.SetRowCellValue(e.RowHandle, "CODEVALUE", "$COMMON");
                    viewMain.SetRowCellValue(e.RowHandle, "SORT_NUM", 0);
                    viewMain.SetRowCellValue(e.RowHandle, "USEFLAG", "1");
                }

                if (sender.Equals(viewSub))
                {
                    viewSub.SetRowCellValue(e.RowHandle, "PCODEVALUE", viewMain.GetFocusedRowCellValue("PCODEVALUE"));
                    viewSub.SetRowCellValue(e.RowHandle, "SORT_NUM", viewSub.RowCount);
                    viewSub.SetRowCellValue(e.RowHandle, "USEFLAG", "1");
                }
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
                DataRow dr = viewMain.GetFocusedDataRow();

                if (dr == null) return;

                viewSub.ViewCaption = $"[ {grpLarge.Text} :          {dr["CODEVALUE"]} - {dr["DISPLAYVALUE"]} ]";
                SelectionSubData(dr["PCODEVALUE"].ToString());
                

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
