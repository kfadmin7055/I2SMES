#region 어셈블리 EBAP.UI.ADM.Popup, v3.15
// C:\EBAP.NET\EBAP.UI.ADM.Popup.dll
// CLR Version : 4.0.30319.36415
#endregion

using DevExpress.XtraPivotGrid;
using EBAP.Core.Info;
using System;

namespace EBAP.UI.ADM.Popup
{
    #region :: EBAP.UI.ADM.Popup.PopViewEvidence ::

    /// <summary>
    /// Form의 업무내용을 기술합니다.
    /// </summary>
    /// <remarks>
    /// Comment     : Popup 기능 및 특이사항 기록
    ///               1.  
    ///               2. 
    /// History     :
    ///               1. (2018-10-19 오후 4:01:11 - 오인봉 - PC170245) : 최초 생성
    ///               2.
    ///               3.
    /// </remarks>
    public partial class PopViewEvidence : EBAP.Win.BaseFrame.PopupFrame
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// 생성자
        /// </summary>
        public PopViewEvidence()
        {
            InitializeComponent();

            AppConfig.CurrentDB = ConnectionString.METADB;
        }

        #endregion

        #region :: 전역변수 ::

        private PivotDrillDownDataSource evidenceData;

        #endregion


        //////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler(Common Event)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: PopViewEvidence_Load :: 폼이 Load 될 때 초기화 및 사용자 Log를 저장합니다.

        /// <summary>
        /// 폼이 Load 될 때 초기화 및 사용자 Log를 저장합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PopViewEvidence_Load(object sender, EventArgs e)
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

            viewList.OptionsBehavior.Editable = false;

            viewList.EndInit();
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetPopParams()
        {
            evidenceData = PopParams["EVIDENCEDATA"] as PivotDrillDownDataSource;
        }

        #endregion

        #region :: PopViewEvidence_Selection :: 조회 Button을 Click 하면 발생합니다.

        /// <summary>
        /// 조회 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PopViewEvidence_Selection(object sender, EventArgs e)
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
            gridList.DataSource = evidenceData;
            viewList.BestFitColumns();
        }

        #endregion


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
            //DialogResult = DialogResult.OK;
        }

        #endregion
    }

    #endregion
}
