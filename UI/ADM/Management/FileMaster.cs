#region 어셈블리 EBAP.UI.ADM.Management, v3.17
// C:\EBAP.NET\EBAP.UI.ADM.dll
// CLR Version : 4.0.30319.36415
#endregion

using DevExpress.XtraGrid.Views.Grid;
using EBAP.Business.WSBiz;
using EBAP.Core;
using EBAP.Core.Collections;
using EBAP.Core.Info;
using EBAP.Data.CodeUtil;
using EBAP.Win.Utility;
using System;
using System.Data;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace EBAP.UI.ADM.Management
{
    #region :: EBAP.UI.ADM.Management.FileMaster ::

    /// <summary>
    /// Form의 업무내용을 기술합니다.
    /// </summary>
    /// <remarks>
    /// Comment     : Form 기능 및 특이사항 기록
    ///               1.  
    ///               2. 
    /// History     :
    ///               1. (2018-04-11 오전 9:28:46 - 오인봉 - PC170245) : 최초 생성
    ///               2.
    ///               3.
    /// </remarks>
    public partial class FileMaster : EBAP.Win.BaseFrame.UIFrame
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// FileMaster Form을 생성합니다.
        /// </summary>
        public FileMaster()
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

        #region :: FileMaster_Load :: Form이 Load 시 발생합니다.

        /// <summary>
        /// Form이 Load 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileMaster_Load(object sender, EventArgs e)
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
            viewMaster.BeginInit();

            viewMaster.InitColumn(AppConfig.CHECKCOLUMNNAME, "Select", 50, 0, true, true, DataType.CheckEdit);
            viewMaster.InitColumn("FILEID", "ID", 90, 0, false, true, DataType.Default, HorzAlign.Center);
            viewMaster.InitColumn("FILENAME", "FileName", 250, 0, true, true);
            viewMaster.InitColumn("FILETYPE", "파일종류", 90, 0, true, true);
            viewMaster.InitColumn("DEPLOYCOUNT", "배포 횟수", 80, 0, false, true, DataType.LinkButton, HorzAlign.Far);
            viewMaster.InitColumn("LASTUPDTTM", "최종배포 일자", 135, 0, false, true, DataType.DateTime);
            viewMaster.InitColumn("DESCRIPTION", "Description", 350, 0, true, true);
            viewMaster.InitColumn("DOWNLOAD", "다운로드", 80, 0, true, true, DataType.Button, HorzAlign.Center);
            viewMaster.InitColumn("CHANGEBY", "ChangeBy", 80, 0, false, false, DataType.Default);
            viewMaster.InitColumn("CHANGEDTTM", "ChangeDttm", 130, 0, false, false, DataType.DateTime);

            viewMaster.NewRowEnableColumns = new string[] { "FILEID" };
            viewMaster.MandatoryColumns = new string[] { "FILENAME" };
            viewMaster.SetAutoInsertColumn("FILEID");

            viewMaster.InitComboBoxColumn("FILETYPE", AppCode.GetCodeMaster("C$FILETYPE", ""));

            viewMaster.EndInit();

            viewList.BeginInit();

            viewList.InitColumn(AppConfig.CHECKCOLUMNNAME, "Select", 50, 0, true, true, DataType.CheckEdit);
            viewList.InitColumn("FILEID", "ID", 110, 0, false, true, DataType.Default, HorzAlign.Center);
            viewList.InitColumn("FILEPATH", "Path", 300, 0, false, true);
            viewList.InitColumn("FILENAME", "FileName", 250, 0, false, true);
            viewList.InitColumn("SIZE", "Size", 100, 0, false, true, DataType.Number, HorzAlign.Far);
            viewList.InitColumn("FILEMODIFIEDDATE", "최종 수정일", 130, 0, false, true, DataType.DateTime);
            viewList.InitColumn("SUBDIR", "하위 폴더", 150, 0, false, false);
            viewList.InitColumn("REASON", "배포 사유", 250, 0, true, true);
            viewList.InitColumn("RESULT", "전송결과", 150, 0, false, false, DataType.MarqueeProgress);
            viewList.InitColumn("CHANGEBY", "배포자", 60, 0, false, false);
            viewList.InitColumn("IPADDRESS", "IP", 100, 0, false, false);

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
            btnUpload.Enabled = SaveAuth;
            btnFile.Enabled = SaveAuth;
            btnDelete.Enabled = SaveAuth;
        }

        #endregion

        #region :: FileMaster_Link :: Form 간 Data 전송 시 발생합니다.

        /// <summary>
        /// Form 간 Data 전송 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileMaster_Link(object sender, EventArgs e)
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

        #region :: FileMaster_Selection :: MainForm의 조회 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 조회 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileMaster_Selection(object sender, EventArgs e)
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
            const string queryId = @"dbo.FileMaster_Select";

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.FILEDB, queryId, AppConfig.COMMANDSP, DatabaseParams);
            }

            gridMaster.FillData(ds);

            gridList.FillData();

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

        #region :: FileMaster_New :: MainForm의 신규 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 신규 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileMaster_New(object sender, EventArgs e)
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
            viewMaster.AddNewRow("FILENAME");
        }

        #endregion

        #region :: FileMaster_Save :: MainForm의 저장 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 저장 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileMaster_Save(object sender, EventArgs e)
        {
            try
            {
                SaveData();

                // 저장 후 조회를 실행해야 한다면 주석을 제거하세요.
                RaiseSelectEvent();

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
            const string queryId = @"dbo.FileMaster_Save";

            string[] paramList = new string[] { "@FILEID",
                                                "@FILENAME",
                                                "@FILETYPE",
                                                "@DESCRIPTION",
                                                "@CHANGEBY" };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                wb.Tx_ExecuteNonQuery(ConnectionString.FILEDB, queryId, AppConfig.COMMANDSP, paramList, viewMaster.GetAddedModifedData());
            }
        }

        #endregion

        #region :: FileMaster_Delete :: MainForm의 삭제 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 삭제 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileMaster_Delete(object sender, EventArgs e)
        {
            try
            {
                DeleteData();

                // 삭제 후 조회를 실행해야 한다면 주석을 제거하세요.
                //RaiseSelectEvent();

                // 삭제 후 Check 된 ROW 만 삭제하려면 주석을 제거하세요(DB 접속 필요없을 경우)
                viewMaster.RemoveCheckedRow();
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
            const string queryId = @"dbo.FileMaster_Delete";

            string[] paramList = new string[] { "@FILEID" };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                wb.Tx_ExecuteNonQuery(ConnectionString.FILEDB, queryId, AppConfig.COMMANDSP, paramList, viewMaster.GetCheckedData());
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

        #region :: viewMaster_InitNewRow :: 신규로 생성되는 Row의 기본값을 정의합니다.

        /// <summary>
        /// 신규로 생성되는 Row의 기본값을 정의합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewMaster_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                viewMaster.SetRowCellValue(e.RowHandle, "ASSEMBLYNAME", "");
                viewMaster.SetRowCellValue(e.RowHandle, "DEPLOYCOUNT", 0);
                viewMaster.SetRowCellValue(e.RowHandle, "ISCOMMON", 0);
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        #region :: viewMaster_DoubleClick :: 배포 횟수를 더블클릭하면 배포 이력 화면으로 이동합니다.

        /// <summary>
        /// 배포 횟수를 더블클릭하면 배포 이력 화면으로 이동합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewMaster_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = viewMaster.GetFocusedDataRow();

                string fieldName = viewMaster.FocusedColumn.FieldName;

                if (dr == null || fieldName != "DEPLOYCOUNT") return;

                if (Convert.ToInt32(dr["DEPLOYCOUNT"]) < 1) return;

                ParamCollection linkParam = new ParamCollection();
                linkParam.Add("FILEID", dr["FILEID"]);

                ExecuteUI("SYS060202", linkParam);
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

        #region :: btnFile_Click :: Upload할 파일을 찾습니다.

        /// <summary>
        /// Upload할 파일을 찾습니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFile_Click(object sender, EventArgs e)
        {
            try
            {
                SetUploadAssembly();
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        /// <summary>
        /// Upload Assembly List에 선택한 파일을 추가합니다.
        /// </summary>
        private void SetUploadAssembly()
        {
            using (OpenFileDialog ofd = new OpenFileDialog
            {
                Multiselect = true,
                Title = "파일 찾기",
                InitialDirectory = Environment.CurrentDirectory
                ,
                Filter = "모든 파일(*.*)|*.*"
            })
            {
                if (ofd.ShowDialog(this) != DialogResult.OK) return;

                foreach (string fileName in ofd.FileNames)
                {
                    FileInfo fileInfo = new FileInfo(fileName);
                    string fileId = "";
                    string filePath = fileInfo.FullName.Substring(0, fileInfo.FullName.LastIndexOf(@"\") + 1);

                    if (!CheckFileList(fileInfo, ref fileId))
                        continue;

                    if (CheckUploadList(fileInfo.Name))
                        continue;

                    DataRow dr = viewList.NewDataRow();

                    dr[AppConfig.CHECKCOLUMNNAME] = false;
                    dr["FILEID"] = fileId;
                    dr["FILEPATH"] = filePath;
                    dr["FILENAME"] = fileInfo.Name;
                    dr["SIZE"] = fileInfo.Length;
                    dr["FILEMODIFIEDDATE"] = fileInfo.LastWriteTime.ToString(AppConfig.DEFAULTDATETIMEFORMAT);
                    dr["SUBDIR"] = "";
                    dr["CHANGEBY"] = CurrentUser.USERID;
                    dr["IPADDRESS"] = CurrentUser.IP;
                    dr["REASON"] = "";
                    dr["RESULT"] = "준비";

                    viewList.AddDataRow(dr);
                    dr.AcceptChanges();
                }
            }
        }

        /// <summary>
        /// File List에 파일명이 있는 지 Check합니다.
        /// </summary>
        /// <param name="fileInfo">Check 할 파일명</param>
        /// <param name="fileID">FILE ID를 저장할 string</param>
        /// <returns></returns>
        private bool CheckFileList(FileInfo fileInfo, ref string fileID)
        {
            DataRow[] drs = viewMaster.GetDataTableByDataSource().Select(String.Format("FILENAME = '{0}'", fileInfo.Name));

            if (drs.Length <= 0) return false;

            fileID = drs[0]["FILEID"].ToString();

            return true;
        }

        /// <summary>
        /// Upload Assembly List에 파일명이 있는지 Check합니다.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private bool CheckUploadList(string fileName)
        {
            DataRow[] drs = viewList.GetDataTableByDataSource().Select(String.Format("FILENAME = '{0}'", fileName));

            return drs.Length > 0 ? true : false;
        }

        #endregion

        #region :: btnUpload_Click ::

        /// <summary>
        /// 배포 List를 UPLOAD 합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                btnUpload.IsValid = CheckUploadCondition();

                if (!btnUpload.IsValid) return;

                viewList.SetColumnVisible("RESULT", true);

                FileUpload();

                viewList.SetColumnVisible("RESULT", false);

                txtReason.Text = string.Empty;
                gridList.FillData();
            }
            catch (Exception ex)
            {
                btnUpload.IsValid = false;
                ShowExceptionBox(ex);
            }
        }

        /// <summary>
        /// Upload 할 Assembly가 있는지 확인합니다.
        /// </summary>
        /// <returns></returns>
        private bool CheckUploadCondition()
        {
            if (viewList.RowCount == 0)
            {
                ShowMsgBox("Upload 할 파일을 선택하세요", "파일확인");
                return false;
            }

            if (txtReason.TrimText == "")
            {
                ShowMsgBox(String.Format(LOCALECONVERTER.GetLocaleMessage("IF_EssentialItem"), layoutControlItem29.Text));
                return false;
            }

            foreach (DataRow dr in viewList.GetDataTableByDataSource().Rows)
            {
                if (dr["REASON"].ToString().Trim() != "") continue;

                dr["REASON"] = txtReason.TrimText;
            }

            return ShowMsgBox("파일을 Upload 하시겠습니까?", "Upload 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? true : false;
        }

        /// <summary>
        /// 파일을 배포하고 Log를 Database에 저장합니다. 
        /// </summary>
        private void FileUpload()
        {
            int idx = 0;

            foreach (DataRow dr in viewList.GetDataTableByDataSource().Rows)
            {
                dr["RESULT"] = "파일 전송중...";
                Application.DoEvents();

                try
                {
                    const string queryId = @"dbo.FileDeployHistory_Save";

                    string[] paramList = new string[] { "@FILEID",
                                                        "@SIZE",
                                                        "@FILECONTENT",
                                                        "@REASON",
                                                        "@CHANGEBY",
                                                        "@IPADDRESS" };

                    object[] valueList = new object[] { dr["FILEID"],
                                                        dr["SIZE"],
                                                        AppUtil.GetBinaryFromFile(Path.Combine(dr["FILEPATH"].ToString(), dr["FILENAME"].ToString())),
                                                        dr["REASON"],
                                                        dr["CHANGEBY"],
                                                        dr["IPADDRESS"] };

                    using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
                    {
                        wb.Tx_ExecuteNonQuery(ConnectionString.FILEDB, queryId, AppConfig.COMMANDSP, paramList, valueList);
                    }
                    idx++;

                    viewList.FocusedRowHandle = idx;

                    dr["RESULT"] = "성공!";
                    dr.AcceptChanges();
                    Thread.Sleep(10);
                    Application.DoEvents();
                }
                catch
                {
                    btnUpload.IsValid = false;
                    dr["RESULT"] = "전송 실패!";
                    throw;
                }
            }
        }

        #endregion

        #region :: btnDelete_Click :: 선택한 배포 List를 제외합니다.

        /// <summary>
        /// 선택한 배포 List를 제외합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteList();
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        /// <summary>
        /// 선택한 Upload Assembly List를 삭제합니다.
        /// </summary>
        private void DeleteList()
        {
            viewList.RemoveCheckedRow();
        }

        #endregion


        #region :: viewMaster_ButtonEditClick ::

        private void viewMaster_ButtonEditClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                DataRow dr = viewMaster.GetFocusedDataRow();

                if (dr == null) return;

                if (dr["DEPLOYCOUNT"].TryParseInt32() < 1) return;

                string fileId = dr["FILEID"].ToString();
                string fileName = dr["FILENAME"].ToString();

                using (SaveFileDialog fd = new SaveFileDialog { Title = "파일 다운로드", FileName = fileName, Filter = "모든 파일|*.*" })
                {
                    if (fd.ShowDialog(this) != DialogResult.OK) return;

                    AppUtil.SaveFile(fd.OpenFile(), GetFileContent(fileId) as byte[]);
                    AppUtil.OpenFile(fd.FileName);
                }
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        private object GetFileContent(string fileId)
        {
            object obj;

            const string queryId = "dbo.FileContent_Get";

            string[] paramList = new string[] { "@FILEID" };

            object[] valueList = new object[] { fileId };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                obj = wb.NTx_ExecuteScalar(ConnectionString.FILEDB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            }

            return obj;
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

            //return base.CheckSaveCondition();
            return base.CheckSaveCondition(viewMaster.GetAddedModifedData());
        }

        #endregion
    }

    #endregion
}
