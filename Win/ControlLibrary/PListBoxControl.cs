using EBAP.Core.Info;
using EBAP.Core.Interface;
using System.ComponentModel;
using System.Data;

namespace EBAP.Win.ControlLibrary
{
    /// <summary>
    /// ListBoxControl 입니다.
    /// DevExpress ListBoxControl를 Wrapping 하여 사용합니다.
    /// </summary>
    /// <remarks>
    /// 2023-02-01 최초생성 : 오인봉
    /// 변경내역
    /// 
    /// </remarks>
    [ToolboxItem(true)]
    public partial class PListBoxControl : DevExpress.XtraEditors.ListBoxControl, IInitEditValue, IInitData
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// ListBox Control을 생성합니다.
        /// </summary>
        public PListBoxControl()
        {
            InitializeComponent();
        }

        #endregion

        #region :: 전역변수 ::

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Interface 구현
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region IInitEditValue 멤버

        /// <summary>
        /// 일괄 초기화 여부를 설정합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(false), Browsable(true)]
        [Description("일괄 초기화 여부를 설정합니다.")]
        public bool IsInitEditValue
        {
            get;
            set;
        }

        /// <summary>
        /// 컨트롤을 초기화 합니다.
        /// </summary>
        public void InitEditValue()
        {
            if (Items.Count > 0) Items.Clear();

            this.DataSource = null;
        }

        #endregion

        #region IInitData 멤버

        /// <summary>
        /// DataSource를 초기화합니다.
        /// </summary>
        /// <param name="valueList">값으로 사용할 List</param>
        /// <param name="displayList">보여지는 값으로 사용할 List</param>
        public void InitData(object[] valueList, string[] displayList)
        {
            if (valueList.Length != displayList.Length)
                return;

            ILocaleConverter ui = FindForm() as ILocaleConverter;

            using (DataTable dt = new DataTable())
            {
                dt.Columns.Add(AppConfig.VALUEMEMBER);
                dt.Columns.Add(AppConfig.DISPLAYMEMBER);

                for (int idx = 0; idx < valueList.Length; idx++)
                {
                    DataRow dr = dt.NewRow();
                    dr[AppConfig.VALUEMEMBER] = valueList[idx];
                    dr[AppConfig.DISPLAYMEMBER] = ui == null ? displayList[idx] : ui.LOCALECONVERTER.GetLocaleString(displayList[idx]);
                    dt.Rows.Add(dr);
                }
                InitData(dt);
            }
        }

        /// <summary>
        /// DataSource를 초기화합니다.
        /// </summary>
        /// <param name="dt">DataSource</param>
        public void InitData(DataTable dt)
        {
            InitData(dt, AppConfig.VALUEMEMBER, AppConfig.DISPLAYMEMBER);
        }

        /// <summary>
        /// DataSource를 초기화합니다.
        /// </summary>
        /// <param name="dt">DataSource</param>
        /// <param name="valueMember">Value Member</param>
        /// <param name="displayMember">Display Member</param>
        public void InitData(DataTable dt, string valueMember, string displayMember)
        {
            DataSource = dt;
            ValueMember = valueMember;
            DisplayMember = displayMember;
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: GetDataTableByDataSource :: DataSource를 DataTable로 반환합니다.

        /// <summary>
        /// DataSource를 DataTable로 반환합니다..
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public DataTable GetDataTableByDataSource()
        {
            DataTable dt = DataSource as DataTable;

            return dt ?? null;
        }

        #endregion

        #region :: GetFocusedDataRow :: 선택된 Datarow를 반환합니다.

        /// <summary>
        /// 선택된 Datarow를 반환합니다.
        /// </summary>
        /// <returns></returns>
        public DataRow GetFocusedDataRow()
        {
            DataRowView view = SelectedItem as DataRowView;

            if (view == null) return null;

            return view.Row;
        }

        #endregion
    }
}