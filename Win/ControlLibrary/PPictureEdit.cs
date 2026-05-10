using DevExpress.XtraLayout;
using EBAP.Core.Interface;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace EBAP.Win.ControlLibrary
{
    /// <summary>
    /// PictureEdit 입니다.
    /// DevExpress PictureEdit을 Wrapping 하여 사용합니다.
    /// </summary>
    /// <remarks>
    /// 2023-02-01 최초생성 : 오인봉
    /// 변경내역
    /// 
    /// </remarks>
    [ToolboxItem(true)]
    public partial class PPictureEdit : DevExpress.XtraEditors.PictureEdit, IInitEditValue, ICheckModified, IDBParams, IBindings, ILocaleCtrl, IMandatory
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// PictureEdit Control을 생성합니다.
        /// </summary>
        public PPictureEdit()
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
            this.EditValue = null;
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

                if (DesignMode) return;

                //BackColor = value ? ControlConfig.MANDATORYBACKCOLOR : ControlConfig.EMPTYCOLOR;
                //ForeColor = value ? ControlConfig.SELECTEVENTFORECOLOR : ControlConfig.EMPTYCOLOR;

                BorderStyle = value ? DevExpress.XtraEditors.Controls.BorderStyles.Simple : DevExpress.XtraEditors.Controls.BorderStyles.Default;
                Properties.Appearance.BorderColor = value ? ControlConfig.MANDATORYBORDERCOLOR : ControlConfig.EMPTYCOLOR;
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

                if (DesignMode) return;

                BorderStyle = value ? DevExpress.XtraEditors.Controls.BorderStyles.Simple : DevExpress.XtraEditors.Controls.BorderStyles.Default;
                Properties.Appearance.BorderColor = value ? ControlConfig.MANDATORYBORDERCOLOR : ControlConfig.EMPTYCOLOR;
            }
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
            return this.EditValue;
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
            DataBindings.Add("EditValue", dt, dataMember, false, DataSourceUpdateMode.OnPropertyChanged, string.Empty);
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: ViewDblClick :: Double Click 시에 Popup 생성여부를 설정합니다.

        /// <summary>
        /// Double Click 시에 Popup 생성여부를 설정합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(false), Browsable(true)]
        [Description("Double Click 시에 Popup 생성여부를 설정합니다.")]
        public bool ViewDblClick
        {
            get;
            set;
        }

        #endregion

        #region :: UseDefaultSize :: 기본 크기(1024X768) 사용여부를 설정합니다.

        /// <summary>
        /// Double Click 시에 Popup 생성여부를 설정합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(false), Browsable(true)]
        [Description("기본 크기(1024X768) 사용여부를 설정합니다.")]
        public bool UseDefaultSize
        {
            get;
            set;
        }

        #endregion

        #region :: EqualControlNextSeq :: 동일한 Type의 컨트롤 다음 Seq를 반환합니다.

        /// <summary>
        /// 동일한 Type의 컨트롤 다음 Seq를 반환합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(""), Browsable(true)]
        [Description("동일한 Type의 컨트롤 다음 Seq를 반환합니다.")]
        public int EqualControlNextSeq
        {
            get;
            set;
        }

        #endregion

        #region :: EqualTotalControlNextSeq :: 종속된 상위 컨트롤내에서 동일한 Type의 컨트롤 다음 Seq를 반환합니다.

        /// <summary>
        /// 종속된 상위 컨트롤내에서 동일한 Type의 컨트롤 다음 Seq를 반환합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(""), Browsable(true)]
        [Description("종속된 상위 컨트롤내에서 동일한 Type의 컨트롤 다음 Seq를 반환합니다.")]
        public int EqualTotalControlNextSeq
        {
            get;
            set;
        }

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: OnDoubleClick :: 더블클릭하면 이미지 원본을 보여줍니다.

        /// <summary>
        /// 더블클릭하면 이미지 원본을 보여줍니다.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDoubleClick(EventArgs e)
        {
            if (ViewDblClick && base.EditValue != null)
            {
                using (ImageForm imgForm = new ImageForm { Text = "Image Viewer", ImageData = EditValue })
                {
                    System.Drawing.Image img = Image;

                    if (img != null)
                    {
                        imgForm.Height = UseDefaultSize ? 768 : img.Height + 50;
                        imgForm.Width = UseDefaultSize ? 1024 : img.Width + 20;
                    }
                    imgForm.ShowDialog(this);
                }
            }
            base.OnDoubleClick(e);
        }

        #endregion

        #region :: EditValue :: Gets or sets editor's value

        /// <summary>
        /// Gets or sets editor's value
        /// </summary>
        public override object EditValue
        {
            get
            {
                return base.EditValue ?? new byte[] { };
            }
            set
            {
                base.EditValue = value;
            }
        }

        #endregion

        #region :: OnLostFocus :: Focus를 잃을 때 현재값과 이전값을 비교한다.

        /// <summary>
        /// 
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