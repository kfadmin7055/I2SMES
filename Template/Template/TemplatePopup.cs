#region 어셈블리 $rootnamespace$, v3.24
// C:\I2S\$rootnamespace$.dll
// CLR Version :  $clrversion$
#endregion

using EBAP.Business.WSBiz;
using EBAP.Core.Info;
using System;
using System.Data;
using System.Windows.Forms;

namespace Template
{
    #region :: $rootnamespace$.$safeitemname$ ::

    /// <summary>
    /// Popup의 업무내용을 기술합니다.
    /// </summary>
    /// <remarks>
    /// Comment     : Popup 기능 및 특이사항 기록
    ///               1.  
    ///               2. 
    /// History     :
    ///               1. ($time$ - $username$ - $machinename$) : 최초 생성
    ///               2.
    ///               3.
    /// </remarks>
    public partial class TemplatePopup : EBAP.Win.BaseFrame.PopupFrame
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// 생성자
        /// </summary>
        public TemplatePopup()
        {
            InitializeComponent();
        }

        #endregion

        #region :: 전역변수 ::


        #endregion


        //////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler(Common Event)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: $safeitemname$_Load :: 폼이 Load 될 때 초기화 및 사용자 Log를 저장합니다.

        /// <summary>
        /// 폼이 Load 될 때 초기화 및 사용자 Log를 저장합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void $safeitemname$_Load(object sender, EventArgs e)
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
            txtId.EditValue = PopParams["ID"];
            txtName.EditValue = PopParams["NAME"];
        }

        #endregion

        #region :: $safeitemname$_Selection :: 조회 Button을 Click 하면 발생합니다.

        /// <summary>
        /// 조회 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void $safeitemname$_Selection(object sender, EventArgs e)
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

            const string queryId = @"dbo.";

            string[] paramList = new string[] { "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "@VENDORCODE",
                                                "@PLANTCODE" };

            object[] valueList = new object[] { "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                "",
                                                CurrentUser.VENDORCODE,
                                                CurrentUser.PLANTCODE };

            //컨트롤에서 파라미터를 생성할 경우 사용하세요.
            //ParamCollection param = DatabaseParams;
            //param.Add("", "");

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList);
                //ds = wb.NTx_ExecuteDataSetFromQueryId(queryId, DatabaseParams);
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
        // Event Handler(Focus, Click Event)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: viewList_FocusedRowChanged :: 선택한 Row가 변경되면 발생합니다.

        /// <summary>
        /// 선택한 Row가 변경되면 발생합니다.
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

        #region :: viewList_DoubleClick :: 더블 클릭하면 DialogResult를 리턴합니다.

        /// <summary>
        /// 더블 클릭하면 DialogResult를 리턴합니다.
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
