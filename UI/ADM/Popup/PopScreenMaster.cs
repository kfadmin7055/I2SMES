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
    public partial class PopScreenMaster : EBAP.Win.BaseFrame.PopupFrame
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// 생성자
        /// </summary>
        public PopScreenMaster()
        {
            InitializeComponent();

            AppConfig.CurrentDB = ConnectionString.METADB;
        }

        #endregion


        //////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler(Common Event)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: PopScreenMaster_Load :: 폼이 Load 될 때 초기화 및 사용자 Log를 저장합니다.

        /// <summary>
        /// 폼이 Load 될 때 초기화 및 사용자 Log를 저장합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PopScreenMaster_Load(object sender, EventArgs e)
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

            viewList.InitColumn("SCREENID", "ScreenId", 100, 0, false, true);
            viewList.InitColumn("SCREENNAME", "ScreenName", 200, 0, false, true);
            viewList.InitColumn("DLLNAME", "DllName", 250, 0, false, true);
            viewList.InitColumn("CLASSNAME", "ClassName", 300, 0, false, true);
            //viewList.InitColumn("GRADENAME", "직급명", 80, 0, false, true);
            //viewList.InitColumn("DEPTCODE", "부서코드", 80, 0, false, true);
            //viewList.InitColumn("DEPTNAME", "부서명", 90, 0, false, true);

            viewList.EndInit();
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetPopParams()
        {
            txtScreenId.EditValue = PopParams["SCREENID"];
            txtScreenName.EditValue = PopParams["SCREENNAME"];
        }

        #endregion

        #region :: PopUserInfo_Selection :: 조회 Button을 Click 하면 발생합니다.

        /// <summary>
        /// 조회 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PopScreenMaster_Selection(object sender, EventArgs e)
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
            const string queryId = @"dbo.ScreenMaster_Select";

            ParamCollection param = DatabaseParams;

            param.Add("@DLLNAME", "");
            param.Add("@CLASSNAME", "");
            param.Add("@DESCRIPTION", "");

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, param);
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
