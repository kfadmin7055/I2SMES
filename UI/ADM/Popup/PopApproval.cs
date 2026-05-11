#region 어셈블리 EBAP.UI.ADM.Popup, v3.15
// C:\EBAP.NET\EBAP.UI.ADM.Popup.dll
// CLR Version : 4.0.30319.36415
#endregion

using EBAP.Business.WSBiz;
using EBAP.Core.Collections;
using EBAP.Core.Info;
using EBAP.Win.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace EBAP.UI.ADM.Popup
{
    #region :: EBAP.UI.ADM.Popup.PopApproval ::

    /// <summary>
    /// Form의 업무내용을 기술합니다.
    /// </summary>
    /// <remarks>
    /// Comment     : Popup 기능 및 특이사항 기록
    ///               1.  
    ///               2. 
    /// History     :
    ///               1. (2018-02-13 오후 4:43:50 - 오인봉 - PC170245) : 최초 생성
    ///               2.
    ///               3.
    /// </remarks>
    public partial class PopApproval : EBAP.Win.BaseFrame.PopupFrame
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// 생성자
        /// </summary>
        public PopApproval()
        {
            InitializeComponent();

            AppConfig.CurrentDB = ConnectionString.METADB;
        }

        #endregion


        //////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler(Common Event)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: PopApproval_Load :: 폼이 Load 될 때 초기화 및 사용자 Log를 저장합니다.

        /// <summary>
        /// 폼이 Load 될 때 초기화 및 사용자 Log를 저장합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PopApproval_Load(object sender, EventArgs e)
        {
            try
            {
                if (!CheckCurrentUser()) Close();

                InitControl();
                InitContents();
                InitGridControl();
                InitAppovalLine();
                SetPopParams();
                //RaiseSelectEvent();
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        private bool CheckCurrentUser()
        {
            if (!CurrentUser.ISSSO)
            {
                ShowMsgBox("Knox 사용자만 사용할 수 있는 기능입니다.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Control Initialize
        /// </summary>
        private void InitControl()
        {
            ConfirmCaption = "Submit";

            object[] _approvalTypeValues = new object[] { "1", "2", "9" };
            string[] _approvalTypeCaptions = new string[] { LOCALECONVERTER.GetLocaleString("Approval"), LOCALECONVERTER.GetLocaleString("Consent"), LOCALECONVERTER.GetLocaleString("Notification") };

            rgLine.InitData(_approvalTypeValues, _approvalTypeCaptions);
        }

        /// <summary>
        /// Contents Initialize
        /// </summary>
        private void InitContents()
        {
            object obj;
            const string queryId = @"dbo.HtmlContents_Get";

            string[] paramList = new string[] { "@HTMLID" };
            object[] valueList = new object[] { PopParams["HTMLID"] };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                //obj = wb.NTx_ExecuteScalarFromQueryId(queryId, paramList, valueList);
                obj = wb.NTx_ExecuteScalar(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            }

            object[] args = PopParams["HTMLPARAM"] as object[];

            string html = obj.ToString();

            if (args != null)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    html = html.Replace("{" + i + "}", args[i].ToString());
                }
            }

            txtContents.HtmlText = html;
        }

        /// <summary>
        /// Grid Control Initialize
        /// </summary>
        private void InitGridControl()
        {
            viewLine.BeginInit();

            //코드로 컬럼 셋팅
            viewLine.InitColumn("APPROVALTYPE", "Approval", 200, 0, true, true, DataType.Default);
            viewLine.InitColumn("LOGINID", "ID", 120, 0, false, true, DataType.Default);
            viewLine.InitColumn("EMPNO", "EmpNo", 75, 0, false, false);
            viewLine.InitColumn("USERNAME", "UserName", 120, 0, false, true, DataType.Default);
            viewLine.InitColumn("USERID", "ID", 75, 0, false, false);
            viewLine.InitColumn("USER_TYPE", "사용자구분", 75, 0, false, false);
            viewLine.InitColumn("USER_GROUP_CODE", "권한그룹", 75, 0, false, false);
            viewLine.InitColumn("GROUP_NAME", "권한그룹명", 75, 0, false, false);
            viewLine.InitColumn("DESCRIPTION", "권한그룹설명", 75, 0, false, false);
            viewLine.InitColumn("DEPTCODE", "부서코드", 75, 0, false, false);
            viewLine.InitColumn("DEPTNAME", "DeptName", 120, 0, false, true, DataType.Default);
            viewLine.InitColumn("GRADECODE", "직급코드", 75, 0, false, false);
            viewLine.InitColumn("GRADENAME", "Grade", 120, 0, false, true, DataType.Default);
            viewLine.InitColumn("EMAILADDRESS", "메일주소", 75, 0, false, false);
            viewLine.InitColumn("USEDFLAG", "사용유무", 75, 0, false, false);
            viewLine.InitColumn("MYSINGLEUSEYN", "싱글사용유무", 75, 0, false, false);

            object[] _approvalTypeValues = new object[] { "0", "1", "2", "9" };
            string[] _approvalTypeCaptions = new string[] { "Draft", "Approval", "Consent", "Notification" };

            viewLine.InitRadioBoxColumn("APPROVALTYPE", _approvalTypeValues, _approvalTypeCaptions);

            viewLine.EndInit();
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitAppovalLine()
        {
            viewLine.FillData();

            DataRow dr = viewLine.NewDataRow();

            dr["APPROVALTYPE"] = "0";
            dr["LOGINID"] = CurrentUser.LOGINID;
            dr["EMPNO"] = CurrentUser.EMPLOYEENUM;
            dr["USERNAME"] = CurrentUser.USERNAME;
            dr["DEPTNAME"] = CurrentUser.DEPARTMENTNAME;
            dr["GRADENAME"] = CurrentUser.GRADENAME;

            viewLine.AddDataRow(dr);
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetPopParams()
        {
            //txtId.EditValue = PopParams["ID"];
            //txtName.EditValue = PopParams["NAME"];
            txtSubject.EditValue = PopParams["SUBJECT"];
        }

        #endregion

        #region :: PopApproval_Selection :: 조회 Button을 Click 하면 발생합니다.

        /// <summary>
        /// 조회 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PopApproval_Selection(object sender, EventArgs e)
        {
            try
            {
                SelectionData();
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        /// <summary>
        /// 조회 처리 Method
        /// </summary>
        private void SelectionData()
        {
            DataSet ds;
            const string queryId = @"EBAP.UI.ADM.Popup.PopApproval.selectPopApproval";

            //간단한 조회일 경우
            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSetFromQueryId(queryId, DatabaseParams);
            }

            //gridList.FillData(ds);

            int rowCnt = ds.Tables[0].Rows.Count;

            switch (rowCnt)
            {
                case 0:
                    POPUPVALUE = null;
                    break;
                case 1:
                    POPUPVALUE = ds.Tables[0].Rows[0];
                    DialogResult = DialogResult.OK;
                    break;
            }
        }

        #endregion

        #region :: PopApproval_Confirm :: 확인 Button을 Click 하면 발생합니다.

        /// <summary>
        /// 확인 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PopApproval_Confirm(object sender, EventArgs e)
        {
            try
            {
                if (!CheckSubmitCondition()) return;

                ShowWaitDialog("결재 상신 중입니다.");

                string subject = txtSubject.EditValue.ToString();
                string message = txtContents.HtmlText;
                string requesterID = CurrentUser.LOGINID;
                string mailKey = SaveESBLog();

                List<ApprovalRoute> route = GetApprovalRoute();

                string approvalMsg = ESBUtil.ApprovalSend(subject, message, requesterID, route, mailKey);

                CloseWaitDialog();

                ShowFlyoutDialog(String.Format("상신 완료 - [ {0} ]", mailKey), "상신 되었습니다. Knox 포탈을 확인하세요.");

                POPUPVALUE = mailKey;

                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        /// <summary>
        /// ESB Log Save
        /// </summary>
        private string SaveESBLog()
        {
            object obj;

            const string queryId = @"dbo.ESBLog_Save";

            string[] paramList = new string[] { "@SEQ", "@ESBTYPE", "@TYPEID", "@INTLK_SYS_ID", "@EXEBY", "@EXECONTENTS" };
            object[] valueList = new object[] { 0, "A", PopParams["HTMLID"], "", CurrentUser.USERID, txtContents.HtmlText };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                obj = wb.NTx_ExecuteScalar(ConnectionString.LOGDB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            }

            return obj.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<ApprovalRoute> GetApprovalRoute()
        {
            List<ApprovalRoute> route = new List<ApprovalRoute>();
            int idx = 1;
            foreach (DataRow dr in viewLine.GetDataTableByDataSource().Rows)
            {
                ApprovalRoute r = new ApprovalRoute();
                r.requesterID = dr["LOGINID"].ToString();
                r.AppType = dr["APPROVALTYPE"].ToString();
                r.AppSeq = idx++;

                route.Add(r);
            }

            return route;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool CheckSubmitCondition()
        {
            if (CheckSubject() && CheckApprovalLine())
            {
                string message = LOCALECONVERTER.GetLocaleString("Submit");

                return DialogResult.Yes == ShowMsgBox(String.Format(LOCALECONVERTER.GetLocaleMessage("CF_Do"), message),
                                        message, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

            return false;
        }

        private bool CheckSubject()
        {
            if (txtSubject.EditValue.ToString().Trim() == "")
            {
                ShowMsgBox("제목을 입력하세요.");
                txtSubject.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool CheckApprovalLine()
        {
            int draftCnt = 0;               //기안자 Count
            int approvalCnt = 0;            //결재자 Count

            foreach (DataRow dr in viewLine.GetDataTableByDataSource().Rows)
            {
                switch (dr["APPROVALTYPE"].ToString())
                {
                    case "0":
                        draftCnt++;
                        break;
                    case "1":
                        approvalCnt++;
                        break;
                }
            }

            if (draftCnt == 0 || approvalCnt == 0)
            {
                ShowMsgBox("결재자가 누락되었습니다.");
                return false;
            }

            return true;
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Event
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: txtUserName_ButtonClick :: 검색을 클릭하면 SSO 사용자를 검색합니다.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUserName_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ParamCollection param = new ParamCollection();
            param.Add("USERID", "");
            param.Add("USERNAME", txtUserName.EditValue);
            DataRow dr = ExecutePopup("User Info", "EBAP.UI.ADM.dll", "EBAP.UI.ADM.Popup.PopSSOUserInfo", param) as DataRow;

            if (dr == null)
            {
                ShowMsgBox("입력한 결재자 정보가 없어요. 확인하세요", "사용자 확인");
            }
            else
            {
                foreach (DataRow drs in viewLine.GetDataTableByDataSource().Rows)
                {
                    if (drs["LOGINID"].ToString() == dr["LOGINID"].ToString())
                    {
                        ShowMsgBox(String.Format("[ {0} ] 중복된 사용자는 입력되지 않습니다.", dr["USERNAME"]));
                        return;
                    }
                }

                DataRow newLine = viewLine.NewDataRow();
                newLine["APPROVALTYPE"] = rgLine.EditValue;
                newLine["LOGINID"] = dr["LOGINID"];
                newLine["USERID"] = dr["USERID"];
                newLine["USERNAME"] = dr["USERNAME"];
                newLine["DEPTNAME"] = dr["DEPTNAME"];
                newLine["GRADENAME"] = dr["GRADENAME"];

                viewLine.AddDataRow(newLine);

                txtUserName.EditValue = "";
            }
        }

        #endregion

        #region :: btnApproval_Click :: Up, Down, 삭제 버튼을 Click 하면 발생합니다.

        /// <summary>
        /// Up, Down, 삭제 버튼을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApproval_Click(object sender, EventArgs e)
        {
            if (sender.Equals(btnDelete))
            {
                string appType = viewLine.GetFocusedRowCellValue("APPROVALTYPE").ToString();

                if (appType == "0")
                {
                    ShowMsgBox("기안자는 삭제할 수 없어요.");
                    return;
                }
                viewLine.DeleteSelectedRows();
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
            //DataRow dr = viewList.GetFocusedDataRow();

            //if (dr == null) return;

            //POPUPVALUE = dr;
        }

        #endregion

        #region :: viewList_DoubleClick :: 더블클릭하면 DialogResult를 리턴합니다.

        /// <summary>
        /// 더블클릭하면 DialogResult를 리턴합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewList_DoubleClick(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        #endregion

        #region :: viewLine_ShowingEditor :: 결재 구분이 기안자이면 변경 불가하도록 합니다.

        /// <summary>
        /// 결재 구분이 기안자이면 변경 불가하도록 합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewLine_ShowingEditor(object sender, CancelEventArgs e)
        {
            string fieldName = viewLine.FocusedColumn.FieldName;

            if (fieldName != "APPROVALTYPE") return;

            DataRow dr = viewLine.GetFocusedDataRow();

            if (dr == null) return;

            string approvalType = dr["APPROVALTYPE"].ToString();

            if (approvalType == "0") e.Cancel = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewLine_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            string fieldName = viewLine.FocusedColumn.FieldName;

            if (fieldName != "APPROVALTYPE") return;

            e.ErrorText = "결재자에서 기안자로 변경 불가합니다.";

            if (e.Value.ToString() == "0")
                e.Valid = false;
            else
                e.Valid = true;
        }

        #endregion
    }

    #endregion
}
