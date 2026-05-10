using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using EBAP.Core.Interface;

namespace EBAP.Win.ControlLibrary
{
    /// <summary>
    /// Toggle Switch 입니다.
    /// DevExpress ToggleSwitch를 Wrapping 하여 사용합니다.
    /// </summary>
    /// <remarks>
    /// 2023-02-01 최초생성 : 오인봉
    /// 변경내역
    ///
    /// </remarks>
    [ToolboxItem(true)]
    public partial class PToggleSwitch : DevExpress.XtraEditors.ToggleSwitch, IInitEditValue, ICheckModified, IDBParams, IBindings, ILocaleCtrl
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// Toggle Switch Control을 생성합니다.
        /// </summary>
        public PToggleSwitch()
        {
            InitializeComponent();
        }

        #endregion

        #region :: 전역변수 ::

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: TextOn / Off :: On/Off Text를 설정합니다.

        /// <summary>
        /// On Text를 설정합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue("On"), Browsable(true)]
        [Description("On Text를 설정합니다.")]
        public string TextOn
        {
            get { return Properties.OnText; }
            set { Properties.OnText = value; }
        }

        /// <summary>
        /// Off Text를 설정합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue("Off"), Browsable(true)]
        [Description("On Text를 설정합니다.")]
        public string TextOff
        {
            get { return Properties.OffText; }
            set { Properties.OffText = value; }
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
            this.IsOn = false;
        }

        #endregion

        #region IModifiedCheck 멤버

        /// <summary>
        /// 일괄 초기화 여부를 설정합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(false), Browsable(true)]
        [Description("EditValue의 변경 Check 여부를 설정합니다.")]
        public bool CheckModified
        {
            get;
            set;
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
        /// <returns></returns>
        public object GetControlParamValue()
        {
            return IsOn ? Properties.ValueOn : Properties.ValueOff;
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
            if (LocaleEnumClass == null || LocaleEnumClass == "") return;

            Text = (FindForm() as ILocaleConverter).LOCALECONVERTER.GetLocaleString(LocaleEnumClass);
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
            DataBindings.Add("EditValue", dt, dataMember, false, DataSourceUpdateMode.OnPropertyChanged, string.Empty);
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: OnLostFocus :: Focus를 잃을 때 수정된 내용이 있으면 MainFrame 에 표시합니다.

        /// <summary>
        /// Focus를 잃을 때 수정된 내용이 있으면 MainFrame 에 표시합니다.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            if (!CheckModified || !IsModified) return;

            (FindForm() as IFrameUI).ISMODIFIED = true;
        }

        #endregion
    }
}