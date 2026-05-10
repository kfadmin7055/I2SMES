using EBAP.Business.WSBiz;
using EBAP.Core.Collections;
using EBAP.Core.Info;
using System;
using System.Data;
using System.Windows.Forms;

namespace EBAP.UI.ADM.Popup
{
    /// <summary>
    /// 다국어 정보를 보여주는 Popup 입니다.
    /// </summary>
    public partial class PopLanguageMaster : EBAP.Win.BaseFrame.PopupFrame
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// 생성자
        /// </summary>
        public PopLanguageMaster()
        {
            InitializeComponent();
        }

        #endregion


        //////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler(Common Event)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: PopLanguageMaster_Load :: 폼이 Load 될 때 초기화 및 사용자 Log를 저장합니다.

        /// <summary>
        /// 폼이 Load 될 때 초기화 및 사용자 Log를 저장합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PopLanguageMaster_Load(object sender, EventArgs e)
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

            viewList.InitColumn("STRINGID", "ID", 80, 0, false, true, DataType.Default, HorzAlign.Center);
            viewList.InitColumn("KOKR", "한국어", 200, 0, false, true);
            viewList.InitColumn("ENUS", "English", 250, 0, false, true);
            viewList.InitColumn("ZHCHS", "中國語", 100, 0, false, false);
            viewList.InitColumn("ENUMCLASS", "C# Enum Class", 180, 0, false, true);
            //viewList.InitColumn("ISEXPORT", "XML 배포", 80, 0, true, true, DataType.CheckEdit);
            //viewList.InitColumn("CHANGEBY", "등록자", 80, 0, false, true);
            //viewList.InitColumn("CHANGEDTTM", "변경일시", 130, 0, false, true, DataType.DateTime, HorzAlign.Center);

            viewList.EndInit();
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetPopParams()
        {
            txtScreenId.EditValue = PopParams["ID"];
            txtScreenName.EditValue = PopParams["CAPTION"];
        }

        #endregion

        #region :: PopUserInfo_Selection :: 조회 Button을 Click 하면 발생합니다.

        /// <summary>
        /// 조회 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PopLanguageMaster_Selection(object sender, EventArgs e)
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
            const string queryId = @"dbo.PopLanguageMaster_Select";

            ParamCollection param = DatabaseParams;

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
