using DevExpress.Utils;
using DevExpress.XtraLayout;
using EBAP.Core.Collections;
using EBAP.Core.Interface;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace EBAP.Win.UserControlLibrary
{
    /// <summary>
    /// Language Edit 입니다.
    /// MultiLanguage를 설정할 때 사용합니다.
    /// </summary>
    /// <remarks>
    /// 2023-02-01 최초생성 : 오인봉
    /// 변경내역
    ///
    /// </remarks>
    [ToolboxItem(true)]
    public partial class PCustomerEdit : DevExpress.XtraEditors.XtraUserControl, IEnterKeySelectEvent, ILocaleCtrl, IMandatory, IInitEditValue
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// 
        /// </summary>
        public PCustomerEdit()
        {
            InitializeComponent();
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
            txtId.EditValue = "";
            txtName.EditValue = "";
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
        /// DataTable과 EditValue를 Mapping 합니다.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="id"></param>
        /// <param name="caption"></param>
        public void BindingMapping(DataTable dt, string id, string caption)
        {
            if (id != "") txtId.BindingMapping(dt, id);
            if (caption != "") txtName.BindingMapping(dt, caption);
        }

        #endregion

        #region IEnterKeySelectEvent 멤버

        private bool _enterkeyselectevent = false;

        /// <summary>
        /// 엔터키를 눌렀을때 조회이벤트 발생 여부를 설정합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(false), Browsable(true)]
        [Description("엔터키를 눌렀을때 조회이벤트 발생 여부를 설정합니다.")]
        public bool EnterKeySelectEvent
        {
            get { return _enterkeyselectevent; }
            set
            {
                _enterkeyselectevent = value;
                txtId.EnterKeySelectEvent = value;
                txtName.EnterKeySelectEvent = value;
            }
        }

        #endregion

        #region IMandatory 멤버

        private bool _ismandatoryforsave = false;

        /// <summary>
        /// 필수입력(저장) 체크 여부를 설정합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(false), Browsable(true)]
        [Description("필수입력(저장) 체크 여부를 설정합니다.")]
        public bool IsMandatoryForSave
        {
            get { return _ismandatoryforsave; }
            set
            {
                _ismandatoryforsave = value;
                txtId.IsMandatoryForSave = value;
                txtName.IsMandatoryForSave = value;
            }
        }

        private bool _ismandatoryforselect = false;

        /// <summary>
        /// 필수입력(조회) 체크 여부를 설정합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(false), Browsable(true)]
        [Description("필수입력(조회) 체크 여부를 설정합니다.")]
        public bool IsMandatoryForSelect
        {
            get { return _ismandatoryforselect; }
            set
            {
                _ismandatoryforselect = value;
                txtId.IsMandatoryForSelect = value;
                txtName.IsMandatoryForSelect = value;
            }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: Id :: ID를 설정합니다.

        /// <summary>
        /// ID를 설정합니다.
        /// </summary>
        [Category("EBAP"), Browsable(false)]
        [Description("ID를 설정합니다.")]
        public object Id
        {
            get { return txtId.EditValue; }
            set { txtId.EditValue = value; }
        }

        #endregion

        #region :: CustomerName :: CustomerName을 설정합니다.

        /// <summary>
        /// CustomerName을 설정합니다.
        /// </summary>
        [Category("EBAP"), Browsable(false)]
        [Description("CustomerName을 설정합니다.")]
        public object CustomerName
        {
            get { return txtName.EditValue; }
            set { txtName.EditValue = value; }
        }

        #endregion

        #region :: IdParamName :: Id의 Parameter 명을 설정합니다.

        /// <summary>
        /// Id의 Parameter 명을 설정합니다.
        /// </summary>
        [Category("EBAP"), Browsable(true)]
        [Description("Id의 Parameter 명을 설정합니다.")]
        public string IdParamName
        {
            get { return txtId.ParamName; }
            set { txtId.ParamName = value; }
        }

        #endregion

        #region :: CaptionParamName :: Caption의 Parameter 명을 설정합니다.

        /// <summary>
        /// Caption의 Parameter 명을 설정합니다.
        /// </summary>
        [Category("EBAP"), Browsable(true)]
        [Description("Caption의 Parameter 명을 설정합니다.")]
        public string CaptionParamName
        {
            get { return txtName.ParamName; }
            set { txtName.ParamName = value; }
        }

        #endregion

        #region :: UseAdvancedMode :: Advanced 모드 사용 여부를 설정합니다.

        private bool _useAdvancedMode = false;

        /// <summary>
        /// Advanced 모드 사용 여부를 설정합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(false), Browsable(true)]
        [Description("Advanced 모드 사용 여부를 설정합니다.")]
        public bool UseAdvancedMode
        {
            get { return _useAdvancedMode; }
            set
            {
                _useAdvancedMode = value;
                txtId.Properties.UseAdvancedMode = _useAdvancedMode ? DefaultBoolean.True : DefaultBoolean.False;
                txtName.Properties.UseAdvancedMode = _useAdvancedMode ? DefaultBoolean.True : DefaultBoolean.False;
            }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: Edit_KeyDown :: Enter Key를 입력하면 조회 이벤트를 실행합니다.

        /// <summary>
        /// Enter Key를 입력하면 조회 이벤트를 실행합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Edit_KeyDown(object sender, KeyEventArgs e)
        {
            if (!EnterKeySelectEvent || e.KeyCode != Keys.Enter) return;

            (FindForm() as IRaiseEvent).RaiseSelectEvent();
        }

        #endregion

        /// <summary>
        /// ID, CAPTION을 클릭하면 다국어 검색 Popup을 실행합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ParamCollection param = new ParamCollection();

            if (sender.Equals(txtId))
            {
                param.Add("CUSTOMERID", txtId.EditValue);
                param.Add("CUSTOMERNAME", "");
            }

            if (sender.Equals(txtName))
            {
                param.Add("CUSTOMERID", "");
                param.Add("CUSTOMERNAME", txtName.EditValue);
            }

            DataRow dr = (FindForm() as IFrameUI).ExecutePopup("Customer Info", "EBAP.UI.ADM.dll", "EBAP.UI.ADM.Popup.PopCustomerInfo", param) as DataRow;

            if (dr == null)
            {
                txtId.EditValue = "";
                txtName.EditValue = "";
                return;
            }

            txtId.EditValue = dr["CUSTOMERID"];
            txtName.EditValue = dr["CUSTOMERNAME"];
        }
    }
}
