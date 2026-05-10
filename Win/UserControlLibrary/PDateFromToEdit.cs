using DevExpress.Utils;
using DevExpress.XtraLayout;
using EBAP.Core.Interface;
using EBAP.Win.ControlLibrary;
using System;
using System.ComponentModel;
using System.Data;

namespace EBAP.Win.UserControlLibrary
{
    /// <summary>
    /// From To DateEdit 입니다.
    /// DevExpress DateEdit를 Wrapping 하여 사용합니다.
    /// </summary>
    /// <remarks>
    /// 2023-02-01 최초생성 : 오인봉
    /// 변경내역
    ///
    /// </remarks>
    [ToolboxItem(true)]
    public partial class PDateFromToEdit : DevExpress.XtraEditors.XtraUserControl, IValueChangeSelectEvent, ILocaleCtrl, IMandatory
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// 
        /// </summary>
        public PDateFromToEdit()
        {
            InitializeComponent();
        }

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Interface 구현
        ///////////////////////////////////////////////////////////////////////////////////////////////

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
        /// <param name="startMember"></param>
        /// <param name="endMember"></param>
        public void BindingMapping(DataTable dt, string startMember, string endMember)
        {
            if (startMember != "") deFrom.BindingMapping(dt, startMember);
            if (endMember != "") deTo.BindingMapping(dt, endMember);
        }

        #endregion

        #region IValueChangeSelectEvent 멤버

        private bool _valuechangeselectevent = false;

        /// <summary>
        /// 선택 값이 변경 되었을때 조회이벤트 발생 여부를 설정합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(false), Browsable(true)]
        [Description("선택 값이 변경 되었을때 조회이벤트 발생 여부를 설정합니다.")]
        public bool ValueChangeSelectEvent
        {
            get { return _valuechangeselectevent; }
            set
            {
                _valuechangeselectevent = value;
                deFrom.ValueChangeSelectEvent = value;
                deTo.ValueChangeSelectEvent = value;
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
                deFrom.IsMandatoryForSave = value;
                deTo.IsMandatoryForSave = value;
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
                deFrom.IsMandatoryForSelect = value;
                deTo.IsMandatoryForSelect = value;
            }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: StartDate :: 시작일자를 설정합니다.

        /// <summary>
        /// 시작일자를 설정합니다.
        /// </summary>
        [Category("EBAP"), Browsable(false)]
        [Description("시작일자를 설정합니다.")]
        public object StartDate
        {
            get { return deFrom.EditValue; }
            set { deFrom.EditValue = value; }
        }

        #endregion

        #region :: EndDate :: 종료일자를 설정합니다.

        /// <summary>
        /// 종료일자를 설정합니다.
        /// </summary>
        [Category("EBAP"), Browsable(false)]
        [Description("종료일자를 설정합니다.")]
        public object EndDate
        {
            get { return deTo.EditValue; }
            set { deTo.EditValue = value; }
        }

        #endregion

        #region :: StartParamName :: 시작일자의 Parameter 명을 설정합니다.

        /// <summary>
        /// 시작일자의 Parameter 명을 설정합니다.
        /// </summary>
        [Category("EBAP"), Browsable(true)]
        [Description("시작일자의 Parameter 명을 설정합니다.")]
        public string StartParamName
        {
            get { return deFrom.ParamName; }
            set { deFrom.ParamName = value; }
        }

        #endregion

        #region :: EndParamName :: 종료일자의 Parameter 명을 설정합니다.

        /// <summary>
        /// 종료일자의 Parameter 명을 설정합니다.
        /// </summary>
        [Category("EBAP"), Browsable(true)]
        [Description("종료일자의 Parameter 명을 설정합니다.")]
        public string EndParamName
        {
            get { return deTo.ParamName; }
            set { deTo.ParamName = value; }
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
                deFrom.Properties.UseAdvancedMode = _useAdvancedMode ? DefaultBoolean.True : DefaultBoolean.False;
                deTo.Properties.UseAdvancedMode = _useAdvancedMode ? DefaultBoolean.True : DefaultBoolean.False;
            }
        }

        #endregion

        #region :: MaximumDays ::

        private int _maximumDays = 0;

        /// <summary>
        /// 시작일자와 종료일자의 최대 일수를 지정합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(0), Browsable(true)]
        [Description("시작일자와 종료일자의 최대 일수를 지정합니다.")]
        public int MaximumDays
        {
            get { return _maximumDays; }
            set { _maximumDays = value; }
        }


        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: SetDate :: 시작/종료 일자를 설정합니다.

        /// <summary>
        /// 시작/종료 일자를 설정합니다.
        /// </summary>
        /// <param name="start">시작일자</param>
        /// <param name="end">종료일자</param>
        public void SetDate(object start, object end)
        {
            StartDate = start;
            EndDate = end;

            deFrom.Refresh();
            deTo.Refresh();
        }

        #endregion

        #region :: SetFullMonthDate :: 일자에 해당하는 월의 시작일과 종료일을 설정합니다.

        /// <summary>
        /// 일자에 해당하는 월의 시작일과 종료일을 설정합니다.
        /// </summary>
        /// <param name="now">일자</param>
        public void SetFullMonthDate(DateTime now)
        {
            StartDate = now.ToString("yyyy-MM-01");
            EndDate = now.ToString($"yyyy-MM-{DateTime.DaysInMonth(now.Year, now.Month)}");

            deFrom.Refresh();
            deTo.Refresh();
        }

        #endregion

        #region :: SetFullMonthDate :: 일자에 해당하는 주의 시작일과 종료일을 설정합니다.

        /// <summary>
        /// 일자에 해당하는 주의 시작일과 종료일을 설정합니다.
        /// </summary>
        /// <param name="now">일자</param>
        public void SetWeekDate(DateTime now)
        {
            StartDate = now.AddDays(Convert.ToInt32(DayOfWeek.Sunday) - Convert.ToInt32(now.DayOfWeek));
            EndDate = now.AddDays(Convert.ToInt32(DayOfWeek.Saturday) - Convert.ToInt32(now.DayOfWeek));

            deFrom.Refresh();
            deTo.Refresh();
        }

        #endregion

        #region :: SetFullMonthDate :: 일자에 해당하는 주의 근무 시작일과 종료일을 설정합니다.

        /// <summary>
        /// 일자에 해당하는 주의 근무 시작일과 종료일을 설정합니다.
        /// </summary>
        /// <param name="now">일자</param>
        public void SetWorkWeekDate(DateTime now)
        {
            StartDate = now.AddDays(Convert.ToInt32(DayOfWeek.Monday) - Convert.ToInt32(now.DayOfWeek));
            EndDate = now.AddDays(Convert.ToInt32(DayOfWeek.Friday) - Convert.ToInt32(now.DayOfWeek));

            deFrom.Refresh();
            deTo.Refresh();
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: DateEdit_EditValueChanged :: EditValue가 변경되면 조회 이벤트를 실행합니다.

        /// <summary>
        /// EditValue가 변경되면 조회 이벤트를 실행합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateEdit_EditValueChanged(object sender, EventArgs e)
        {
            PDateEdit edit = sender as PDateEdit;

            if (sender.Equals(deTo))
            {
                if (deTo.DateTime < deFrom.DateTime)
                    deFrom.DateTime = deTo.DateTime;
            }

            if (MaximumDays > 0)
            {
                if ((deTo.DateTime - deFrom.DateTime).Days >= MaximumDays)
                {
                    (FindForm() as IDialog).ShowMsgBox(String.Format("최대로 지정할 수 있는 날짜 수는 [ {0} 일 ] 입니다.", MaximumDays));
                    edit.EditValue = edit.OldEditValue;
                }
            }

            if (DesignMode || edit == null || !ValueChangeSelectEvent || Convert.ToDateTime(edit.OldEditValue).ToString(edit.Properties.EditMask) == Convert.ToDateTime(edit.EditValue).ToString(edit.Properties.EditMask)) return;

            (FindForm() as IRaiseEvent).RaiseSelectEvent();
        }

        #endregion
    }
}
