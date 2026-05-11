#region 어셈블리 EBAP.UI.ADM.Popup, v3.15
// C:\EBAP.NET\EBAP.UI.ADM.Popup.dll
// CLR Version : 4.0.30319.36415
#endregion

using EBAP.Business.WSBiz;
using EBAP.Core.Collections;
using EBAP.Core.Info;
using System;
using System.Data;
using System.Windows.Forms;

namespace EBAP.UI.ADM.Popup
{
    #region :: EBAP.UI.ADM.Popup.PopMsgKey ::

    /// <summary>
    /// Form의 업무내용을 기술합니다.
    /// </summary>
    /// <remarks>
    /// Comment     : Popup 기능 및 특이사항 기록
    ///               1.  
    ///               2. 
    /// History     :
    ///               1. (2018-10-24 오후 4:45:25 - 오인봉 - PC170245) : 최초 생성
    ///               2.
    ///               3.
    /// </remarks>
    public partial class PopMsgKey : EBAP.Win.BaseFrame.PopupFrame
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// 생성자
        /// </summary>
        public PopMsgKey()
        {
            InitializeComponent();

            AppConfig.CurrentDB = ConnectionString.METADB;
        }

        #endregion


        //////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler(Common Event)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: PopMsgKey_Load :: 폼이 Load 될 때 초기화 및 사용자 Log를 저장합니다.

        /// <summary>
        /// 폼이 Load 될 때 초기화 및 사용자 Log를 저장합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PopMsgKey_Load(object sender, EventArgs e)
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

            viewList.InitColumn("USERID", "사용자 ID", 100, 0, false, true, DataType.Default, HorzAlign.Default);
            viewList.InitColumn("USERNAME", "사용자명", 150, 0, false, true, DataType.Default, HorzAlign.Default);
            viewList.InitColumn("VENDORCODE", "업체코드", 100, 0, false, true, DataType.Default, HorzAlign.Default);
            viewList.InitColumn("VENDORNAME", "업체코드", 200, 0, false, true, DataType.Default, HorzAlign.Default);
            viewList.InitColumn("IPADDRESS", "IP 주소", 150, 0, false, true, DataType.Default, HorzAlign.Default);

            viewList.EndInit();
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetPopParams()
        {
        }

        #endregion

        #region :: PopMsgKey_Selection :: 조회 Button을 Click 하면 발생합니다.

        /// <summary>
        /// 조회 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PopMsgKey_Selection(object sender, EventArgs e)
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
            const string queryId = @"dbo.MESMsgKey_Needs";

            //간단한 조회일 경우
            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.LOGDB, queryId, AppConfig.COMMANDSP, null, null);
            }

            gridList.FillData(ds);
        }

        #endregion

        private void PopMsgKey_Save(object sender, EventArgs e)
        {
            try
            {
                if (!CheckSaveCondition()) return;

                SaveData();

                RaiseSelectEvent();

                if (viewList.GetDataTableByDataSource().Rows.Count != 0) return;

                if (ShowMsgBox("등록할 대상이 없어요. 창을 닫으시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    Close();
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        private bool CheckSaveCondition()
        {
            return ShowMsgBox("[ 저장 ] 하시겠습니까?", "저장", MessageBoxButtons.YesNo) == DialogResult.Yes;
        }

        /// <summary>
        /// 조회 처리 Method
        /// </summary>
        private void SaveData()
        {
            const string queryId = @"dbo.MESMsgKey_Create";

            //간단한 조회일 경우
            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                wb.Tx_ExecuteNonQuery(ConnectionString.LOGDB, queryId, AppConfig.COMMANDSP, new ParamCollection());
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Event
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: viewList_FocusedRowChanged :: 선택한 Row가 변경되면 발생합니다.

        /// <summary>
        /// 선택한 Row가 변경되면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
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
        }

        #endregion
    }

    #endregion
}
