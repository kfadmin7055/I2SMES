using EBAP.Business.WSBiz;
using EBAP.Core.Collections;
using EBAP.Core.Info;
using System;
using System.Data;
using System.Windows.Forms;

namespace EBAP.UI.ADM.Popup
{
    /// <summary>
    /// 사용자 정보를 보여주는 Popup 입니다.
    /// </summary>
    public partial class PopApprovalStatus : EBAP.Win.BaseFrame.PopupFrame
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// 생성자
        /// </summary>
        public PopApprovalStatus()
        {
            InitializeComponent();

            AppConfig.CurrentDB = ConnectionString.METADB;
        }

        #endregion

        #region :: 전역변수 ::

        private string _intlk_sys_id = "";

        #endregion


        //////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler(Common Event)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: PopApprovalStatus_Load :: 폼이 Load 될 때 초기화 및 사용자 Log를 저장합니다.

        /// <summary>
        /// 폼이 Load 될 때 초기화 및 사용자 Log를 저장합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PopApprovalStatus_Load(object sender, System.EventArgs e)
        {
            try
            {
                InitGridControl();
                SetPopParams();
                RaiseSelectEvent();
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        /// <summary>
        /// Grid Control Initialize
        /// </summary>
        private void InitGridControl()
        {
            viewList.BeginInit();

            viewList.InitColumn("GUBUN", "Gubun", 100, 0, false, true);
            viewList.InitColumn("USERNAME", "UserName", 150, 0, false, true);
            viewList.InitColumn("ACTIONDATE", "처리일시", 130, 0, false, true);
            viewList.InitColumn("DEPTNAME", "DeptName", 120, 0, false, true);
            viewList.InitColumn("OPINION", "의견", 300, 0, false, true, DataType.MemoEx);

            viewList.EndInit();
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetPopParams()
        {
            _intlk_sys_id = PopParams["INTLK_SYS_ID"].ToString();
        }

        #endregion

        #region :: PopApprovalStatus_Selection :: 조회 Button을 Click 하면 발생합니다.

        /// <summary>
        /// 조회 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PopApprovalStatus_Selection(object sender, System.EventArgs e)
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
        /// 데이터를 조회합니다.
        /// </summary>
        /// <returns></returns>
        private void SelectionData()
        {
            DataSet ds;

            const string queryId = @"dbo.ApprovalStatus_Select";

            ParamCollection param = new ParamCollection();
            param.Add("@INTLK_SYS_ID", _intlk_sys_id);

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.LOGDB, queryId, AppConfig.COMMANDSP, param);
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

            txtSubject.BindingMapping(dt, "APPROVAL_TITLE");
            txtContents.BindingMapping(dt, "EXECONTENTS");
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Event
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: viewList_FocusedRowChanged ::

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = viewList.GetFocusedDataRow();

            if (dr == null) return;

            POPUPVALUE = dr;
        }

        #endregion

        #region :: viewList_DoubleClick ::

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewList_DoubleClick(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        #endregion
    }
}
