#region 어셈블리 EBAP.UI.ADM.Popup, v3.15
// C:\EBAP.NET\EBAP.UI.ADM.Popup.dll
// CLR Version : 4.0.30319.36460
#endregion

using EBAP.Core;
using EBAP.Core.Info;
using System;
using System.Data;
using System.Windows.Forms;

namespace EBAP.UI.ADM.Popup
{
    #region :: EBAP.UI.ADM.Popup.PopMultiInput ::

    /// <summary>
    /// Form의 업무내용을 기술합니다.
    /// </summary>
    /// <remarks>
    /// Comment     : Popup 기능 및 특이사항 기록
    ///               1.  
    ///               2. 
    /// History     :
    ///               1. (2018-12-10 오전 9:37:36 - 오인봉 - PC170245) : 최초 생성
    ///               2.
    ///               3.
    /// </remarks>
    public partial class PopMultiInput : EBAP.Win.BaseFrame.PopupFrame
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// 생성자
        /// </summary>
        public PopMultiInput()
        {
            InitializeComponent();

            AppConfig.CurrentDB = ConnectionString.METADB;
        }

        #endregion


        //////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler(Common Event)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: PopMultiInput_Load :: 폼이 Load 될 때 초기화 및 사용자 Log를 저장합니다.

        /// <summary>
        /// 폼이 Load 될 때 초기화 및 사용자 Log를 저장합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PopMultiInput_Load(object sender, EventArgs e)
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

            viewList.InitColumn("MULTIVALUE", "Value", 450, 0, true, true, DataType.Default, HorzAlign.Default);
            viewList.SetColumnCharacterCasing(CharacterCasing.Upper, "MULTIVALUE");
            viewList.UseIndicatorNumber = true;

            viewList.EndInit();
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetPopParams()
        {
        }

        #endregion

        #region :: PopMultiInput_Selection :: 조회 Button을 Click 하면 발생합니다.

        /// <summary>
        /// 조회 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PopMultiInput_Selection(object sender, EventArgs e)
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
            var values = PopParams["VALUE"].ToString().Split(",");
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("Table");
            dt.AddColumn("MULTIVALUE");

            for (int i = 0; i < values.Length; i++)
            {
                DataRow dr = dt.NewRow();
                dr["MULTIVALUE"] = values[i];
                dt.Rows.Add(dr);
            }

            for (int i = 0; i < 50 - values.Length; i++)
            {
                DataRow dr = dt.NewRow();
                dr["MULTIVALUE"] = "";
                dt.Rows.Add(dr);
            }

            ds.Tables.Add(dt);

            gridList.FillData(ds);
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PopMultiInput_Confirm(object sender, EventArgs e)
        {
            try
            {
                string multiText = "";

                DataTable dt = viewList.GetDataTableByDataSource();

                string txt = "";

                for (int i = 0; i < viewList.RowCount; i++)
                {
                    txt = dt.Rows[i]["MULTIVALUE"].ToString();

                    if (txt == "") continue;

                    multiText += txt;

                    multiText += ",";
                }
                POPUPVALUE = multiText.Left(multiText.Length - 1);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
            }
        }

        private void PopMultiInput_New(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                ShowExceptionBox(ex);
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
            DialogResult = DialogResult.OK;
        }

        #endregion
    }

    #endregion
}
