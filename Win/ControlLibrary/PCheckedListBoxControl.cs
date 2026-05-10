using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using DevExpress.XtraLayout;
using EBAP.Core;
using EBAP.Core.Info;
using EBAP.Core.Interface;

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
    public partial class PCheckedListBoxControl : DevExpress.XtraEditors.CheckedListBoxControl, IInitEditValue, IInitData, IBindings, ILocaleCtrl, IDBParams
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// ListBox Control을 생성합니다.
        /// </summary>
        public PCheckedListBoxControl()
        {
            InitializeComponent();
        }

        #endregion

        #region :: 전역변수 ::

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: EditText :: EditValue를 Text 형식으로 리턴합니다.

        /// <summary>
        /// EditValue를 Text 형식으로 리턴합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(""), Browsable(false)]
        [Description("EditValue를 Text 형식으로 리턴합니다.")]
        public string EditText
        {
            get { return EditValue == null ? "" : EditValue.ToString(); }
        }

        /// <summary>
        /// 
        /// </summary>
        public string OrderText()
        {
            string editVal = EditValue.ToString();

            string[] vals = editVal.Split(',');

            var orderVal = from val in vals
                           orderby val
                           select val;

            editVal = "";
            foreach (string v in orderVal)
            {
                editVal += String.Format("{0},", v);
            }

            return editVal.Left(editVal.Length - 1);
        }

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

        #region ILocaleCtrl 멤버

        /// <summary>
        /// Database Parameter Name 입니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(""), Browsable(true)]
        [Description("다국어 ID 입니다.")]
        public string LocaleEnumClass
        {
            get;
            set;
        }

        /// <summary>
        /// 컨트롤의 다국어 텍스트를 설정합니다.
        /// </summary>
        public void SetLocaleString()
        {
            if (Parent is LayoutControl)
                (Parent as LayoutControl).GetItemByControl(this).Text = (FindForm() as ILocaleConverter).LOCALECONVERTER.GetLocaleString(LocaleEnumClass);
        }

        #endregion

        #region IBindings 구현

        /// <summary>
        /// 데이터 바인딩 멤버
        /// </summary>
        [Category("EBAP"), DefaultValue(""), Browsable(true)]
        [Description("데이터 바인딩 멤버 입니다.")]
        public string BindingMember
        {
            get;
            set;
        }

        /// <summary>
        /// DataTable과 EditValue를 Mapping 합니다.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dataMember"></param>
        public void BindingMapping(DataTable dt, string dataMember)
        {
            DataBindings.Clear();
            DataBindings.Add("CheckMember", dt, dataMember, false, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, string.Empty);
        }

        #endregion

        #region IDBParams 멤버

        /// <summary>
        /// Database Parameter Name 입니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(""), Browsable(true)]
        [Description("Database Parameter Name 입니다.")]
        public string ParamName
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public object EditValue
        {
            get
            {
                return GetControlParamValue();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object GetControlParamValue()
        {
            string val = "";

            for (int i = 0; i < CheckedItems.Count; i++)
            {
                val += CheckedItems[i].ToString();

                if (i >= CheckedItems.Count - 1) continue;

                val += ",";
            }

            return val;
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

        /// <summary>
        /// Check 된 데이터를 가져옵니다.(CheckedColumn)
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public DataTable GetCheckedData()
        {
            DataTable dtSource = DataSource as DataTable;

            if (dtSource == null) return null;

            DataTable dt = dtSource.Clone();

            foreach (object obj in CheckedItems)
            {
                dt.ImportRow((obj as DataRowView).Row);
            }

            return dt;
        }
    }
}
