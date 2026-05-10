#region 어셈블리 EBAP.UI.ADM.Management, v3.17
// C:\EBAP.NET\EBAP.UI.ADM.dll
// CLR Version : 4.0.30319.36415
#endregion

using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList.Nodes;
using EBAP.Business.WSBiz;
using EBAP.Core.Collections;
using EBAP.Core.Info;
using EBAP.Data.CodeUtil;
using System;
using System.Data;
using System.Windows.Forms;

namespace EBAP.UI.ADM.Management
{
    #region :: EBAP.UI.ADM.Management.MenuMaster ::

    /// <summary>
    /// Form의 업무내용을 기술합니다.
    /// </summary>
    /// <remarks>
    /// Comment     : Form 기능 및 특이사항 기록
    ///               1.  
    ///               2. 
    /// History     :
    ///               1. (2018-04-11 오후 12:02:02 - 오인봉 - PC170245) : 최초 생성
    ///               2.
    ///               3.
    /// </remarks>
    public partial class MenuMaster : EBAP.Win.BaseFrame.UIFrame
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// MenuMaster Form을 생성합니다.
        /// </summary>
        public MenuMaster()
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

        #region :: MenuMaster_Load :: Form이 Load 시 발생합니다.

        /// <summary>
        /// Form이 Load 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuMaster_Load(object sender, EventArgs e)
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
            tlMenu.BeginInit();

            tlMenu.InitColumn("MENUID", "메뉴ID", 75, 0, false, false);
            tlMenu.InitColumn("MENUNAME_LANG", "메뉴 이름", 250, 100, false, false);
            tlMenu.InitColumn("MENUNAME", "메뉴 이름", 250, 100, false, true);
            tlMenu.InitColumn("LVL", "Level", 50, 50, false, true);
            tlMenu.InitColumn("IDX", "Index", 50, 50, false, true);
            tlMenu.InitColumn("PARENTMENUID", "부모메뉴ID", 75, 0, false, false);
            tlMenu.InitColumn("SCREENID", "ScreenId", 80, 150, false, true);
            tlMenu.InitColumn("SCREENNAME", "ScreenName", 200, 150, false, true);
            tlMenu.InitColumn("DLLNAME", "DLL 파일 이름", 180, 150, false, true);
            tlMenu.InitColumn("CLASSNAME", "Class 이름", 200, 150, false, true);
            tlMenu.InitColumn("HELPURL", "도움말 경로", 150, 150, false, true);
            tlMenu.InitColumn("IMAGEIDX", "Image", 50, 3, false, true);
            tlMenu.InitColumn("SELECTIMAGEIDX", "선택 Image", 50, 3, false, true);
            tlMenu.InitColumn("DESCRIPTION", "메뉴 설명", 200, 350, false, true);
            tlMenu.InitColumn("ISCOMMON", "공통여부", 75, 0, false, false);
            tlMenu.InitColumn("ISMULTIEXECUTE", "중복실행 여부", 75, 0, false, false);
            tlMenu.InitColumn("ISBEGINGROUP", "Begin Group", 75, 0, false, false);
            tlMenu.InitColumn("USEFLAG", "사용유무", 75, 0, false, false);
            tlMenu.InitColumn("CHANGEDTTM", "등록일", 75, 0, false, false);
            tlMenu.InitColumn("CHANGEBY", "등록자", 75, 0, false, false);

            tlMenu.KeyFieldName = "MENUID";
            tlMenu.ParentFieldName = "PARENTMENUID";

            tlMenu.MandatoryColumns = new string[] { "MENUID", "MENUNAME" };

            tlMenu.EndInit();
        }

        /// <summary>
        /// ComboBox Initialize
        /// </summary>
        private void InitComboBox()
        {
            string[] value = new string[] { "0", "1", "2", "3" };
            string[] text = new string[] { "대분류 아이콘", "중분류 아이콘", "기본 아이콘", "선택 기본 아이콘" };

            icboImgIdx.InitData(value, text);
            icboSImgIdx.InitData(value, text);

            cboUseVendor.InitData(AppCode.GetVendorCode(CurrentUser.USERID));
            cboUsePlant.InitData(AppCode.GetCodeMaster("C$PLANTCODE", ""));
        }

        /// <summary>
        /// 기타 Control Initialize
        /// </summary>
        private void InitControls()
        {

        }

        #endregion

        #region :: MenuMaster_Link :: Form 간 Data 전송 시 발생합니다.

        /// <summary>
        /// Form 간 Data 전송 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuMaster_Link(object sender, EventArgs e)
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

        #region :: MenuMaster_Selection :: MainForm의 조회 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 조회 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuMaster_Selection(object sender, EventArgs e)
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

            const string queryId = @"dbo.MenuMaster_Select";

            ParamCollection param = DatabaseParams;
            param.Add("@LANGUAGE", CURRENTLANGUAGE);

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, param);
            }

            tlMenu.FillData(ds);

            InitDataBindings(ds);
        }

        /// <summary>
        /// 컨트롤과 데이터를 바인딩합니다.
        /// </summary>
        private void InitDataBindings(DataSet ds)
        {
            DataTable dt = ds.Tables[0];

            txtMenuId.BindingMapping(dt, "MENUID");
            txtMenuName.BindingMapping(dt, "MENUNAME");
            txtParentMenuId.BindingMapping(dt, "PARENTMENUID");
            txtLVL.BindingMapping(dt, "LVL");
            txtIDX.BindingMapping(dt, "IDX");
            txtScreenId.BindingMapping(dt, "SCREENID");
            txtScreenName.BindingMapping(dt, "SCREENNAME");
            txtDll.BindingMapping(dt, "DLLNAME");
            txtClass.BindingMapping(dt, "CLASSNAME");
            txtHelpPath.BindingMapping(dt, "HELPURL");
            icboImgIdx.BindingMapping(dt, "IMAGEIDX");
            icboSImgIdx.BindingMapping(dt, "SELECTIMAGEIDX");
            chkCommon.BindingMapping(dt, "ISCOMMON");
            chkMultiExecute.BindingMapping(dt, "ISMULTIEXECUTE");
            chkBeginGroup.BindingMapping(dt, "ISBEGINGROUP");
            chkUseFlag.BindingMapping(dt, "USEFLAG");
            txtDescription.BindingMapping(dt, "DESCRIPTION");
            cboUsePlant.BindingMapping(dt, "USEPLANTCODE");
            cboUseVendor.BindingMapping(dt, "USEVENDORCODE");
            leMenuName.BindingMapping(dt, "MENUNAME_LANG", "MENUNAME");
        }

        #endregion

        #region :: MenuMaster_New :: MainForm의 신규 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 신규 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuMaster_New(object sender, EventArgs e)
        {
            try
            {
                NewData();
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        /// <summary>
        /// 신규 처리 Method
        /// </summary>
        private void NewData()
        {
            CreateNewNode(tlMenu.FocusedNode);

            if (tlMenu.FocusedNode.Level < 3)
                txtMenuName.Select();
            else
                txtScreenName.Select();
        }

        /// <summary>
        /// 새로운 Node를 생성합니다.
        /// </summary>
        /// <param name="focusedNode"></param>
        private void CreateNewNode(TreeListNode focusedNode)
        {
            int nodeCount = tlMenu.Nodes.Count;
            TreeListNode pNode = focusedNode ?? null;
            TreeListNode treeListNode = null;

            string menuId = string.Empty;
            string menuName = string.Empty;
            string dllName = string.Empty;
            string className = string.Empty;
            string helpPath = string.Empty;

            int level = 0;
            int index = nodeCount;

            int image_Index = 0;
            int selectedImage_Index = 0;

            bool isCommon = false;
            string usevendor = "";
            string useplant = "";

            if (pNode != null)
            {
                level = pNode.Level + 1;
                index = pNode.Nodes.Count;

                menuId = pNode["MENUID"] + (Convert.ToInt32(index + 1).ToString("00"));
                isCommon = Convert.ToBoolean(pNode["ISCOMMON"]);
                usevendor = pNode["USEVENDORCODE"].ToString();
                useplant = pNode["USEPLANTCODE"].ToString();

                if (pNode.HasChildren)
                {
                    dllName = "";// pNode.LastNode["DLLNAME"].ToString();
                    className = "";//pNode.LastNode["CLASSNAME"].ToString();
                    className = "";//className.LastIndexOf(".") < 0 ? "" : className.Substring(0, className.LastIndexOf("."));
                    helpPath = "";//pNode.LastNode["HELPPATH"].ToString();
                }
                image_Index = level;
                selectedImage_Index = level == 2 ? 3 : level;
            }

            DataRow dr = tlMenu.GetDataTableByDataSource().NewRow();

            dr.ItemArray = new object[] { menuId, "", menuName, level, index, "", "", "", dllName, className, helpPath, image_Index, selectedImage_Index, usevendor, useplant, "", isCommon, false, false, true, GetCurrentTime(), CurrentUser.USERID };

            treeListNode = tlMenu.AppendNode(dr, pNode);
            tlMenu.FocusedNode = treeListNode;
            txtMenuId.Select();
        }

        #endregion

        #region :: MenuMaster_Save :: MainForm의 저장 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 저장 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuMaster_Save(object sender, EventArgs e)
        {
            try
            {
                SaveData();

                // 저장 후 조회를 실행해야 한다면 주석을 제거하세요.
                RaiseSelectEvent();

                // 저장 후 DataTable에 변경사항만 처리할 경우 주석을 제거하세요(DB 접속 필요없을 경우)
                //tlMenu.AcceptChanges();
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
            const string queryId = @"dbo.MenuMaster_Save";

            string[] paramList = new string[] { "@MENUID",
                                                "@MENUNAME_LANG",
                                                "@MENUNAME",
                                                "@LVL",
                                                "@IDX",
                                                "@PARENTMENUID",
                                                "@SCREENID",
                                                "@IMAGEIDX",
                                                "@SELECTIMAGEIDX",
                                                "@ISCOMMON",
                                                "@ISMULTIEXECUTE",
                                                "@ISBEGINGROUP",
                                                "@DESCRIPTION",
                                                "@USEFLAG",
                                                "@USEVENDORCODE",
                                                "@USEPLANTCODE",
                                                "@CHANGEBY" };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                wb.Tx_ExecuteNonQuery(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, tlMenu.GetAddedModifedData());
            }
        }

        #endregion

        #region :: MenuMaster_Delete :: MainForm의 삭제 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 삭제 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuMaster_Delete(object sender, EventArgs e)
        {
            try
            {
                DeleteData();

                // 삭제 후 조회를 실행해야 한다면 주석을 제거하세요.
                //RaiseSelectEvent();

                // 삭제 후 Check 된 ROW 만 삭제하려면 주석을 제거하세요(DB 접속 필요없을 경우)
                tlMenu.Nodes.Remove(tlMenu.FocusedNode);
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
            string queryId = @"dbo.MenuMaster_Delete";

            string[] paramList = new string[] { "@MENUID" };

            object[] valueList = new object[] { txtMenuId.EditValue };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                wb.Tx_ExecuteNonQuery(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList);
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

        #region :: btnChild_Click :: 자식 Menu 를 생성합니다.

        /// <summary>
        /// 자식 Menu 를 생성합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChild_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRoot_Click(object sender, EventArgs e)
        {
            try
            {
                CreateNewNode(null);
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        #endregion

        #region :: tlMenu_FocusedNodeChanged :: TreeList의 Focused Node가 변경되면 메뉴 상세정보에 Data를 보여줍니다.

        /// <summary>
        /// TreeList의 Focused Node가 변경되면 메뉴 상세정보에 Data를 보여줍니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlMenu_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            //if (e.Node == null) return;

            //DataRowView drv = tlMenu.GetDataRecordByNode(e.Node) as DataRowView;

            //if (drv == null) return;

            //if (drv.Row.RowState == DataRowState.Added)
            //    txtMenuId.Properties.ReadOnly = false;
            //else
            //    txtMenuId.Properties.ReadOnly = true;
        }

        #endregion

        #region :: txtScreen_ButtonClick :: 스크린 ID, 스크린명을 클릭하면 스크린 검색 Popup을 실행합니다.

        /// <summary>
        /// 스크린 ID, 스크린명을 클릭하면 스크린 검색 Popup을 실행합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtScreen_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ParamCollection param = new ParamCollection();

            if (sender.Equals(txtScreenId))
            {
                param.Add("SCREENID", txtScreenId.EditValue);
                param.Add("SCREENNAME", "");
            }

            if (sender.Equals(txtScreenName))
            {
                param.Add("SCREENID", "");
                param.Add("SCREENNAME", txtScreenName.EditValue);
            }

            DataRow dr = ExecutePopup("Screen 정보", "EBAP.UI.ADM.dll", "EBAP.UI.ADM.Popup.PopScreenMaster", param) as DataRow;

            if (dr != null)
            {
                txtScreenId.EditValue = dr["SCREENID"];
                txtScreenName.EditValue = dr["SCREENNAME"];
                txtDll.EditValue = dr["DLLNAME"];
                txtClass.EditValue = dr["CLASSNAME"];
                txtHelpPath.EditValue = dr["HELPURL"];

                if (txtMenuName.EditValue.ToString().Trim() == string.Empty)
                    txtMenuName.EditValue = dr["SCREENNAME"];

                tlMenu.Focus();
                tlMenu.EndCurrentEdit();
            }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkCommon_CheckedChanged(object sender, EventArgs e)
        {
            bool chk = chkCommon.Checked;

            cboUsePlant.Enabled = !chk;
            cboUseVendor.Enabled = !chk;
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
            if (tlMenu.FocusedNode == null)
            {
                ShowMsgBox("부모 노드를 먼저 선택해 주세요", "부모 노드 선택");
                return false;
            }
                
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
            if (txtMenuId.Text == "")
            {
                ShowMsgBox("프로그램 ID는 반드시 입력하셔야 합니다.");
                txtMenuId.Select();
                return false;
            }
            if (tlMenu.FocusedNode != null)
            {
                if (tlMenu.FocusedNode.HasChildren)
                {
                    return ShowMsgBox("삭제하려는 메뉴에 하위 메뉴가 있습니다. 상위 메뉴가 삭제되면 하위메뉴도 삭제됩니다. 모두 삭제할까요?", "삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? true : false;
                }
                else
                {
                    return ShowMsgBox(String.Format("[ {0} ] 메뉴를 삭제할까요?", txtMenuName.Text), "삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? true : false;
                }
            }
            else
                return false;
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
