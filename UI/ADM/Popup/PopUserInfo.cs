using EBAP.Business.WSBiz;
using EBAP.Core.Info;
using System;
using System.Data;
using System.Windows.Forms;

namespace EBAP.UI.ADM.Popup
{
    /// <summary>
    /// 사용자 정보를 보여주는 Popup 입니다.
    /// </summary>
    public partial class PopUserInfo : EBAP.Win.BaseFrame.PopupFrame
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// 생성자
        /// </summary>
        public PopUserInfo()
        {
            InitializeComponent();
        }

        #endregion


        //////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler(Common Event)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: PopUserInfo_Load :: 폼이 Load 될 때 초기화 및 사용자 Log를 저장합니다.

        /// <summary>
        /// 폼이 Load 될 때 초기화 및 사용자 Log를 저장합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PopUserInfo_Load(object sender, System.EventArgs e)
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

            viewList.InitColumn("USERID", "ID", 90, 0, false, true);
            viewList.InitColumn("USERNAME", "UserName", 80, 0, false, true);
            viewList.InitColumn("DEPTCODE", "DeptCode", 120, 0, false, true);
            viewList.InitColumn("DEPTNAME", "DeptName", 200, 0, false, true);
            viewList.InitColumn("GRADECODE", "GradeCode", 80, 0, false, true);
            viewList.InitColumn("GRADENAME", "Grade", 120, 0, false, true);

            viewList.EndInit();
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetPopParams()
        {
            txtUserId.EditValue = PopParams["USERID"];
            txtUserName.EditValue = PopParams["USERNAME"];
        }

        #endregion

        #region :: PopUserInfo_Selection :: 조회 Button을 Click 하면 발생합니다.

        /// <summary>
        /// 조회 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PopUserInfo_Selection(object sender, System.EventArgs e)
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

            const string queryId = @"dbo.UserInfo_Get";

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, DatabaseParams);
            }

            gridList.FillData(ds);

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
