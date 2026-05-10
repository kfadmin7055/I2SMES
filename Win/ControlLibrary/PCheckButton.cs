using DevExpress.XtraLayout;
using EBAP.Core.Interface;
using System.ComponentModel;

namespace EBAP.Win.ControlLibrary
{
    /// <summary>
    /// CheckButton 입니다.
    /// DevExpress CheckButton을 Wrapping 하여 사용합니다.
    /// </summary>
    /// <remarks>
    /// 2023-02-01 최초생성 : 오인봉
    /// 변경내역
    ///
    /// </remarks>
    [ToolboxItem(true)]
    public partial class PCheckButton : DevExpress.XtraEditors.CheckButton, ILocaleCtrl
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// Check Button Control을 생성합니다.
        /// </summary>
        /// <param name="check"></param>
        public PCheckButton(bool check)
            : base(check)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Check Button Control을 생성합니다.
        /// </summary>
        public PCheckButton()
        {
            InitializeComponent();
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
    }
}
