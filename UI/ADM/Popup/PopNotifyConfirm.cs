#region 어셈블리 EBAP.UI.ADM.Popup, v3.15
// C:\EBAP.NET\EBAP.UI.ADM.Popup.dll
// CLR Version : 4.0.30319.42000
#endregion

using EBAP.Business.WSBiz;
using EBAP.Core.Info;
using System;
using System.Windows.Forms;

namespace EBAP.UI.ADM.Popup
{
    #region :: EBAP.UI.ADM.Popup.PopNotifyConfirm ::

    /// <summary>
    /// Form의 업무내용을 기술합니다.
    /// </summary>
    /// <remarks>
    /// Comment     : Popup 기능 및 특이사항 기록
    ///               1.  
    ///               2. 
    /// History     :
    ///               1. (2020-11-23 오후 5:25:15 - user - DESKTOP-7JQVRP4) : 최초 생성
    ///               2.
    ///               3.
    /// </remarks>
    public partial class PopNotifyConfirm : EBAP.Win.BaseFrame.PopupFrame
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// 생성자
        /// </summary>
        public PopNotifyConfirm()
        {
            InitializeComponent();
        }

        #endregion


        //////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler(Common Event)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: PopNotifyConfirm_Load :: 폼이 Load 될 때 초기화 및 사용자 Log를 저장합니다.

        /// <summary>
        /// 폼이 Load 될 때 초기화 및 사용자 Log를 저장합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PopNotifyConfirm_Load(object sender, EventArgs e)
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
            //viewList.BeginInit();

            // 코드로 컬럼 셋팅
            //viewList.InitColumn(AppConfig.CHECKCOLUMNNAME, "Select", 50, 0, true, true, DataType.CheckEdit);
            //viewList.InitColumn("FIELD", "Caption", 75, 0, false, true, DataType.Default, HorzAlign.Default);
            //viewList.InitColumn("CHANGEBY", "ChangeBy", 80, 0, false, false);
            //viewList.InitColumn("CHANGEDTTM", "ChangeDttm", 130, 0, false, false, DataType.DateTime, HorzAlign.Center);

            //viewList.EndInit();
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetPopParams()
        {
            txtSubject.EditValue = PopParams["SUBJECT"];
            txtContents.EditValue = PopParams["CONTENTS"];
        }

        #endregion

        #region :: PopNotifyConfirm_Selection :: 조회 Button을 Click 하면 발생합니다.

        /// <summary>
        /// 조회 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PopNotifyConfirm_Selection(object sender, EventArgs e)
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

        }

        #endregion


        private void PopNotifyConfirm_Confirm(object sender, EventArgs e)
        {
            try
            {
                if (!CheckConfirmCondition()) return;

                if (chkConfirm.Checked) SaveNotifyConfirmData();

                Close();
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        private bool CheckConfirmCondition()
        {
            return ShowMsgBox("공지사항을 [ 확인 ] 하셨습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes;
        }

        /// <summary>
        /// 조회 처리 Method
        /// </summary>
        private void SaveNotifyConfirmData()
        {
            const string queryId = @"dbo.NotifyConfirm_Save";

            string[] paramList = new string[] { "@NOTIFYSEQ", "@USERID", "@CONFIRMVALUE" };
            object[] valueList = new object[] { PopParams["NOTIFYSEQ"], CurrentUser.USERID, "" };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                wb.Tx_ExecuteNonQuery(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList);
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
    }

    #endregion
}
