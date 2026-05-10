using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout;
using EBAP.Core.Interface;
using EBAP.Win.Utility;
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace EBAP.Win.ControlLibrary
{
    /// <summary>
    /// File Up / Download를 지원하는 Text Edit 입니다.
    /// </summary>
    [ToolboxItem(true)]
    public partial class PFileEdit : DevExpress.XtraEditors.ButtonEdit, IInitEditValue, IDBParams, IEnterKeySelectEvent, IBindings, ILocaleCtrl, ICheckModified, IMandatory
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// TextButtonEdit Control을 생성합니다.
        /// </summary>
        public PFileEdit()
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
            this.EditValue = string.Empty;
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

        #region IModifiedCheck 멤버

        /// <summary>
        /// 일괄 초기화 여부를 설정합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(false), Browsable(true)]
        [Description("EditValue의 변경 Check 여부를 설정합니다.")]
        public bool ModifiedCheck
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

                if (DesignMode) return;

                BorderStyle = value ? DevExpress.XtraEditors.Controls.BorderStyles.Simple : DevExpress.XtraEditors.Controls.BorderStyles.Default;
                Properties.Appearance.BorderColor = value ? ControlConfig.SELECTEVENTBORDERCOLOR : ControlConfig.EMPTYCOLOR;

                //BackColor = value ? ControlConfig.SELECTEVENTBACKCOLOR : ControlConfig.EMPTYCOLOR;
                //ForeColor = value ? ControlConfig.SELECTEVENTFORECOLOR : ControlConfig.EMPTYCOLOR;
            }
        }

        #endregion

        #region :: EnterKeyClickEvent :: 엔터키를 눌렀을 때 클릭이벤트 발생 여부를 설정합니다.

        /// <summary>
        /// 엔터키를 눌렀을 때 팝업이벤트 발생 여부를 설정합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(false), Browsable(true)]
        [Description("엔터키를 눌렀을 때 클릭이벤트 발생 여부를 설정합니다.")]
        public bool EnterKeyClickEvent
        {
            get;
            set;
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
            if (AdvancedMode && Properties.UseAdvancedMode == DefaultBoolean.True)
            {
                if (Parent is LayoutControl) (Parent as LayoutControl).GetItemByControl(this).TextVisible = false;

                if (LocaleEnumClass == null || LocaleEnumClass == string.Empty)
                {
                    if (Parent is LayoutControl) Properties.AdvancedModeOptions.Label = (Parent as LayoutControl).GetItemByControl(this).Text;
                }
                else
                    Properties.AdvancedModeOptions.Label = (FindForm() as ILocaleConverter).LOCALECONVERTER.GetLocaleString(LocaleEnumClass);
            }

            if (Parent is LayoutControl)
                (Parent as LayoutControl).GetItemByControl(this).Text = (FindForm() as ILocaleConverter).LOCALECONVERTER.GetLocaleString(LocaleEnumClass);

            //if (AdvancedMode && Parent is LayoutControl && !(Parent as LayoutControl).GetItemByControl(this).TextVisible)
            //    Properties.AdvancedModeOptions.Label = (FindForm() as ILocaleConverter).LOCALECONVERTER.GetLocaleString(LocaleEnumClass);

            //if (Parent is LayoutControl)
            //    (Parent as LayoutControl).GetItemByControl(this).Text = (FindForm() as ILocaleConverter).LOCALECONVERTER.GetLocaleString(LocaleEnumClass);
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

        #region :: FileData :: 파일 데이터를 설정합니다.

        private object _fileData = null;

        /// <summary>
        /// 파일 데이터를 설정합니다.
        /// </summary>
        [Category("EBAP")]
        [Description("파일 데이터를 설정합니다."), Browsable(false)]
        public object FileData
        {
            get { return _fileData; }
            set
            {
                _fileData = value;
            }
        }

        #endregion

        #region :: FileName :: 파일명을 설정합니다.

        private string _fileName = string.Empty;

        /// <summary>
        /// 파일명을 설정합니다.
        /// </summary>
        [Category("EBAP")]
        [Description("파일명을 설정합니다."), Browsable(false)]
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Event Delegate
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: FileSave :: 파일 다운로드 시에 사용합니다.

        /// <summary>
        /// 파일 다운로드 시에 사용합니다.
        /// </summary>
        [Category("EBAP")]
        [Description("파일 다운로드 시에 사용합니다."), Browsable(true)]
        public event EventHandler FileSave;

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Private)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: OpenFile :: 파일을 찾습니다.

        /// <summary>
        /// 파일을 찾습니다.
        /// </summary>
        private void OpenFile()
        {
            using (OpenFileDialog ofd = new OpenFileDialog { Multiselect = false, InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fileInfo = new FileInfo(ofd.FileName);

                    EditValue = ofd.FileName;
                    _fileName = fileInfo.Name;
                    _fileData = AppUtil.GetBinaryFromFile(ofd.FileName);
                }
            }
        }

        #endregion

        #region :: OnFileSave :: FileDownload Event를 강제로 발생시킵니다.

        /// <summary>
        /// FileDownload Event를 강제로 발생시킵니다.
        /// </summary>
        private void OnFileSave()
        {
            if (FileSave != null) { FileSave(this, new EventArgs()); }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: OnEditValueChanged :: EditValue가 변경되면 발생합니다.

        /// <summary>
        /// EditValue가 변경되면 발생합니다.
        /// </summary>
        protected override void OnEditValueChanged()
        {
            if (Properties.Buttons.Count < 3) return;

            if (EditValue == null || EditValue.ToString() != string.Empty)
            {
                Properties.Buttons[1].Enabled = true;
                Properties.Buttons[2].Enabled = true;
            }
            else
            {
                Properties.Buttons[1].Enabled = false;
                Properties.Buttons[2].Enabled = false;
            }

            Refresh();
        }

        #endregion

        #region :: OnCreateControl :: PFileEdit가 생성될 때 버튼을 만듭니다.

        /// <summary>
        /// PFileEdit가 생성될 때 버튼을 만듭니다.
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            if (Properties.Buttons.Count > 0) Properties.Buttons.Clear();

            EditorButton eb1 = new EditorButton { ToolTip = "파일찾기..." };
            Properties.Buttons.Add(eb1);
            EditorButton eb2 = new EditorButton { Kind = ButtonPredefines.Plus, ToolTip = "파일 다운로드..." };
            Properties.Buttons.Add(eb2);
            EditorButton eb3 = new EditorButton { Kind = ButtonPredefines.Delete, ToolTip = "파일 삭제..." };
            Properties.Buttons.Add(eb3);

            EditValue = string.Empty;
        }

        #endregion

        #region :: OnClickButton :: 버튼을 클릭하면 발생합니다.

        /// <summary>
        /// 버튼을 클릭하면 발생합니다.
        /// </summary>
        /// <param name="buttonInfo"></param>
        protected override void OnClickButton(DevExpress.XtraEditors.Drawing.EditorButtonObjectInfoArgs buttonInfo)
        {
            switch (buttonInfo.Button.Index)
            {
                case 0:
                    OpenFile();
                    break;
                case 1:
                    OnFileSave();
                    break;
                case 2:
                    EditValue = string.Empty;
                    _fileName = "";
                    _fileData = null;
                    break;
            }
            base.OnClickButton(buttonInfo);
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
