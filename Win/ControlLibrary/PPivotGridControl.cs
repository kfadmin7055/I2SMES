using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using DevExpress.Data;
using DevExpress.Data.PivotGrid;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid;
using DevExpress.XtraPivotGrid;
using EBAP.Core;
using EBAP.Core.Collections;
using EBAP.Core.Info;
using EBAP.Core.Interface;
using EBAP.Win.Utility;

namespace EBAP.Win.ControlLibrary
{
    /// <summary>
    /// Pivot Grid Control 입니다.
    /// DevExpress PivotGridControl 을 Wrapping 하여 사용합니다.
    /// </summary>
    /// <remarks>
    /// 2023-02-01 최초생성 : 오인봉
    /// 변경내역
    /// 
    /// </remarks>
    [ToolboxItem(true)]
    public partial class PPivotGridControl : DevExpress.XtraPivotGrid.PivotGridControl, IInitEditValue, IFillData, IExport, IPrint
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자(+1 Overloading) ::

        /// <summary>
        /// PivotGridControl 을 생성합니다.
        /// </summary>
        public PPivotGridControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewInfoData"></param>
        protected PPivotGridControl(DevExpress.XtraPivotGrid.Data.PivotGridViewInfoData viewInfoData)
            : base(viewInfoData)
        {
            InitializeComponent();
        }


        #endregion

        #region :: 전역변수 ::

        private string[] _runningTotalField;

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
            DataSource = null;
        }

        #endregion

        #region IFillData 멤버

        /// <summary>
        /// GridControl의 데이터를 채웁니다.
        /// </summary>
        public void FillData()
        {
            DataSource = null;
        }

        /// <summary>
        /// GridControl의 데이터를 채웁니다.
        /// </summary>
        /// <param name="ds"></param>
        public void FillData(DataSet ds)
        {
            FillData(ds, ds.Tables[0].TableName);
        }

        /// <summary>
        /// GridControl의 데이터를 채웁니다.
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        public void FillData(DataSet ds, string tableName)
        {
            DataMember = string.Empty;

            DataSource = ds;
            DataMember = tableName;
        }

        #endregion

        #region IExport 멤버

        /// <summary>
        /// Export를 비활성화 합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(false), Browsable(true)]
        [Description("Export를 비활성화 합니다.")]
        public bool DisableExport
        {
            get;
            set;
        }

        /// <summary>
        /// Excel로 Export 합니다.
        /// </summary>
        /// <param name="filePath"></param>
        public void ExportXlsx(string filePath)
        {
            DevExpress.Export.ExportSettings.DefaultExportType = DevExpress.Export.ExportType.WYSIWYG;

            base.ExportToXlsx(filePath);
        }

        /// <summary>
        /// PDF로 Export 합니다.
        /// </summary>
        /// <param name="filePath"></param>
        public void ExportPdf(string filePath)
        {
            DevExpress.Export.ExportSettings.DefaultExportType = DevExpress.Export.ExportType.WYSIWYG;

            base.ExportToPdf(filePath);
        }

        #endregion

        #region IPrint 멤버

        /// <summary>
        /// 
        /// </summary>
        public void PrintPreview()
        {
            base.ShowRibbonPrintPreview();
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: RunningTotalField :: RunningTotal Field를 정의합니다.

        /// <summary>
        /// RunningTotal Field를 정의합니다.
        /// </summary>
        [Category("EBAP"), Browsable(true)]
        [Description("RunningTotal Field를 정의합니다.")]
        public string[] RunningTotalField
        {
            get { return _runningTotalField; }
            set
            {
                _runningTotalField = value;
                SetRunningTotal();
            }
        }

        /// <summary>
        /// Running Total Field를 설정합니다.
        /// </summary>
        private void SetRunningTotal()
        {
            if (_runningTotalField == null || _runningTotalField.Length == 0) return;

            foreach (PivotGridField field in Fields)
            {
                foreach (string runningTotal in _runningTotalField)
                {
                    if (field.FieldName != runningTotal) continue;

                    field.RunningTotal = true;
                }
            }
        }

        #endregion

        #region :: UseFieldCustomize :: Field Customize 사용 여부를 정의합니다.

        /// <summary>
        /// Field Customize 사용 여부를 정의합니다.
        /// </summary>
        [Category("EBAP"), Browsable(true), DefaultValue(false)]
        [Description("Field Customize 사용 여부를 정의합니다.")]
        public bool UseFieldCustomize
        {
            get;
            set;
        }

        #endregion

        #region :: REDVALUE / BLUEVALUE :: 빨간색 / 파란색 표시값을 설정합니다.

        /// <summary>
        /// 빨간색 표시값을 설정합니다.
        /// </summary>
        [Category("EBAP"), Browsable(true)]
        [Description("이 값보다 작으면 붉은 색으로 표현합니다.")]
        public decimal REDVALUE
        {
            get;
            set;
        }

        /// <summary>
        /// 파란색 표시값을 설정합니다.
        /// </summary>
        [Category("EBAP"), Browsable(true)]
        [Description("이 값보다 크면 파란 색으로 표현합니다.")]
        public decimal BLUEVALUE
        {
            get;
            set;
        }

        #endregion

        #region :: ViewEvidence :: 더블클릭시 데이터 상세 사용 여부를 정의합니다.

        /// <summary>
        /// Field Customize 사용 여부를 정의합니다.
        /// </summary>
        [Category("EBAP"), Browsable(true), DefaultValue(false)]
        [Description("더블클릭시 데이터 상세 사용 여부를 정의합니다.")]
        public bool ViewEvidence
        {
            get;
            set;
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: InitColumn(+3 Overloading) :: Grid Field를 초기화합니다.

        /// <summary>
        /// Grid Field을 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Field Field 명</param>
        /// <param name="caption">Field Header Text</param>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void InitColumn(string fieldName, string caption)
        {
            InitColumn(fieldName, caption, 75, PivotArea.FilterArea);
        }

        /// <summary>
        /// Grid Column을 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="caption">Column Header Text</param>
        /// <param name="width">너비</param>
        /// <param name="area">Field 위치</param>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void InitColumn(string fieldName, string caption, int width, PivotArea area)
        {
            InitColumn(fieldName, caption, width, area, DataType.Default);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="caption">Column Header Text</param>
        /// <param name="width">너비</param>
        /// <param name="area">Field 위치</param>
        /// <param name="dataType">Data Type</param>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void InitColumn(string fieldName, string caption, int width, PivotArea area, DataType dataType)
        {
            InitColumn(fieldName, caption, width, 0, area, dataType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="caption">Column Header Text</param>
        /// <param name="width">너비</param>
        /// <param name="decimalPlace">소숫점 자리수</param>
        /// <param name="area">Field 위치</param>
        /// <param name="dataType">Data Type</param>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void InitColumn(string fieldName, string caption, int width, int decimalPlace, PivotArea area, DataType dataType)
        {
            InitColumn(fieldName, caption, width, decimalPlace, area, dataType, PivotSummaryType.Sum);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="caption">Column Header Text</param>
        /// <param name="width">너비</param>
        /// <param name="decimalPlace">소숫점 자리수</param>
        /// <param name="area">Field 위치</param>
        /// <param name="dataType">Data Type</param>
        /// <param name="summaryType">Summary Type</param>
        /// 2016-06-17 최초생성 : 오인봉
        /// <remarks>
        /// 변경내역
        /// 
        /// </remarks>
        public void InitColumn(string fieldName, string caption, int width, int decimalPlace, PivotArea area, DataType dataType, PivotSummaryType summaryType)
        {
            EBAP.Core.Localization.LocaleConverter locale = (FindForm() as ILocaleConverter).LOCALECONVERTER;

            if (locale == null) return;

            PivotGridField gridField;

            bool existField = base.Fields[fieldName] == null ? false : true;

            gridField = existField ? base.Fields[fieldName] : new PivotGridField();

            gridField.FieldName = fieldName;
            gridField.Caption = locale.GetLocaleString(caption);
            gridField.SummaryType = summaryType;
            gridField.Options.AllowEdit = false;

            if (!existField)
            {
                Fields.Add(gridField);
                //gridField.AreaIndex = base.Fields.Count - 1;
            }

            ControlUtil.SetColumnType(gridField, dataType, 0, decimalPlace);

            gridField.Width = width;
            //gridField.UseNativeFormat = DevExpress.Utils.DefaultBoolean.True;

            gridField.Area = area;

            //switch (area)
            //{
            //    case PivotArea.RowArea:
            //        gridField.Appearance.Value.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            //        break;
            //}
        }

        #endregion

        #region :: SetStyleFormat(+4 Overloading) :: Grid Column의 Style을 설정합니다.

        /// <summary>
        /// Grid Column의 Style을 설정합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="backColor">설정할 Back Color</param>
        /// <param name="formatCondition">Format Condition</param>
        /// <param name="value1">비교값1</param>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void SetStyleFormat(string fieldName, Color backColor, FormatConditionEnum formatCondition, object value1)
        {
            SetStyleFormat(fieldName, backColor, Appearance.FieldValue.ForeColor, ControlConfig.DEFAULTFONT, formatCondition, value1, null);
        }

        /// <summary>
        /// Grid Column의 Style을 설정합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="backColor">설정할 Back Color</param>
        /// <param name="formatCondition">Format Condition</param>
        /// <param name="value1">비교값1</param>
        /// <param name="applyToRow">Row에 색을 표시할지를 설정합니다.</param>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void SetStyleFormat(string fieldName, Color backColor, FormatConditionEnum formatCondition, object value1, bool applyToRow)
        {
            SetStyleFormat(fieldName, backColor, Appearance.FieldValue.ForeColor, ControlConfig.DEFAULTFONT, formatCondition, value1, null, applyToRow);
        }

        /// <summary>
        /// Grid Column의 Style을 설정합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="backColor">설정할 Back Color</param>
        /// <param name="value1">비교값1</param>
        /// <param name="value2">비교값2</param>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void SetStyleFormat(string fieldName, Color backColor, object value1, object value2)
        {
            SetStyleFormat(fieldName, backColor, Appearance.FieldValue.ForeColor, ControlConfig.DEFAULTFONT, FormatConditionEnum.Between, value1, value2);
        }

        /// <summary>
        /// Grid Column의 Style을 설정합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="backColor">설정할 Back Color</param>
        /// <param name="foreColor">설정할 Fore Color</param>
        /// <param name="font">설정할 Font</param>
        /// <param name="formatCondition">Format Condition</param>
        /// <param name="value1">비교값1</param>
        /// <param name="value2">비교값2</param>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void SetStyleFormat(string fieldName, Color backColor, Color foreColor, Font font, FormatConditionEnum formatCondition, object value1, object value2)
        {
            SetStyleFormat(fieldName, backColor, foreColor, font, formatCondition, value1, value2, false);
        }

        /// <summary>
        /// Grid Column의 Style을 설정합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="backColor">설정할 Back Color</param>
        /// <param name="foreColor">설정할 Fore Color</param>
        /// <param name="font">설정할 Font</param>
        /// <param name="formatCondition">Format Condition</param>
        /// <param name="value1">비교값1</param>
        /// <param name="value2">비교값2</param>
        /// <param name="applyToRow">Row에 색을 표시할지를 설정합니다.</param>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void SetStyleFormat(string fieldName, Color backColor, Color foreColor, Font font, FormatConditionEnum formatCondition, object value1, object value2, bool applyToRow)
        {
            PivotGridField gridField = base.Fields[fieldName];

            StyleFormatCondition sfc = new StyleFormatCondition();
            sfc.Appearance.Font = font;
            sfc.Appearance.BackColor = backColor;
            sfc.Appearance.ForeColor = foreColor;

            sfc.Appearance.Options.UseBackColor = true;
            sfc.Appearance.Options.UseForeColor = true;
            sfc.Appearance.Options.UseFont = true;

            sfc.ApplyToRow = applyToRow;
            sfc.Condition = formatCondition;
            sfc.Value1 = value1;
            sfc.Value2 = value2;

            FormatConditions.Add(sfc);
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="summaryType"></param>
        public void SetFieldSummaryType(string fieldName, PivotSummaryType summaryType)
        {
            PivotGridField gridField = base.Fields[fieldName];

            if (gridField == null) return;

            gridField.SummaryType = summaryType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="unboundExpression"></param>
        /// <param name="unboundType"></param>
        /// <param name="expressionMode"></param>
        public void SetUnboundExpression(string fieldName, string unboundExpression, UnboundColumnType unboundType = UnboundColumnType.Bound, UnboundExpressionMode expressionMode = UnboundExpressionMode.Default)
        {
            PivotGridField gridField = base.Fields[fieldName];

            if (gridField == null) return;

            gridField.UnboundFieldName = fieldName;
            gridField.UnboundType = unboundType;
            gridField.UnboundExpressionMode = expressionMode;
            gridField.UnboundExpression = unboundExpression;
        }

        #region :: GetFieldValue :: 해당 Index의 Field 값을 리턴합니다.

        /// <summary>
        /// 해당 Index의 Field 값을 리턴합니다.
        /// </summary>
        /// <param name="fieldName">Field 명</param>
        /// <returns></returns>
        public object GetFieldValue(string fieldName)
        {
            return Cells == null ? "" : GetFieldValue(fieldName, Cells.FocusedCell.Y);
        }

        /// <summary>
        /// 해당 Index의 Field 값을 리턴합니다.
        /// </summary>
        /// <param name="fieldName">Field 명</param>
        /// <param name="lastLevelIndex">Index</param>
        /// <returns></returns>
        public object GetFieldValue(string fieldName, int lastLevelIndex)
        {
            PivotGridField field = Fields[fieldName];

            if (field == null) return null;

            object obj = GetFieldValue(field, lastLevelIndex);

            return obj == null ? "" : obj;
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Private)
        ///////////////////////////////////////////////////////////////////////////////////////////////



        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Control Event Handler
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: PPivotGridControl_CustomDrawCell :: 값에 따라 색을 표시합니다.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PPivotGridControl_CustomDrawFieldHeader(object sender, DevExpress.XtraPivotGrid.PivotCustomDrawFieldHeaderEventArgs e)
        {
            try
            {
                if (e.Field == null) return;

                //e.DefaultDraw();
                //e.Info.IsDrawOnGlass = true;

                e.GraphicsCache.FillRectangle(e.GraphicsCache.GetSolidBrush(ControlConfig.HEADERBACKCOLOR), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1));
                e.Appearance.DrawString(e.GraphicsCache, e.Info.Caption, e.Info.CaptionRect, e.GraphicsCache.GetSolidBrush(ControlConfig.HEADERFORECOLOR));

                foreach (DrawElementInfo info in e.Info.InnerElements)
                {
                    if (!info.Visible) continue;

                    ObjectPainter.DrawObject(e.GraphicsCache, info.ElementPainter, info.ElementInfo);
                }

                e.Handled = true;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PPivotGridControl_CustomDrawFieldValue(object sender, DevExpress.XtraPivotGrid.PivotCustomDrawFieldValueEventArgs e)
        {
            try
            {
                if (e.Area == PivotArea.RowArea) return;

                e.DefaultDraw();
                e.Info.IsDrawOnGlass = true;

                e.GraphicsCache.FillRectangle(e.GraphicsCache.GetSolidBrush(ControlConfig.HEADERBACKCOLOR), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1));
                e.Appearance.DrawString(e.GraphicsCache, e.Info.Caption, e.Info.CaptionRect, e.GraphicsCache.GetSolidBrush(ControlConfig.HEADERFORECOLOR));

                e.Handled = true;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 값에 따라 색을 표시합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PPivotGridControl_CustomDrawCell(object sender, DevExpress.XtraPivotGrid.PivotCustomDrawCellEventArgs e)
        {
            if (e.Value == null || e.Value.ToString() == "Error" || e.Value.TryParseInt32() == 0) return;

            bool isred = Convert.ToDecimal(e.Value) < REDVALUE ? true : false;
            bool isblue = Convert.ToDecimal(e.Value) >= BLUEVALUE ? true : false;

            if (isred) e.Appearance.ForeColor = ControlConfig.DELETEROWCOLOR; //Color.FromArgb(169, 7, 7);
            if (isblue) e.Appearance.ForeColor = ControlConfig.MODIFIEDROWCOLOR; //Color.FromArgb(39, 63, 133);
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: OnEnter :: UseFieldCustomize 에 따라 Customize Dock을 보여줍니다.

        /// <summary>
        /// UseFieldCustomize 에 따라 Customize Dock을 보여줍니다.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);

            if (DesignMode || !UseFieldCustomize) return;

            if (CustomizationForm != null)
            {
                CustomizationForm.Show();
                return;
            }
            FieldsCustomization();
            //FieldsCustomization((FindForm() as EBAP.Win.BaseFrame.UIFrame).GetFiledCustomizeDock());

            CustomizationForm.Leave += CustomizationForm_Leave;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomizationForm_Leave(object sender, EventArgs e)
        {
            if (DesignMode || CustomizationForm == null || !UseFieldCustomize || ContainsFocus) return;

            CustomizationForm.Hide();
            //(FindForm() as EBAP.Win.BaseFrame.UIFrame).SetFiledCustomizeDockVisible(false);
        }

        #endregion

        #region :: OnLeave :: UseFieldCustomize 에 따라 Customize Dock을 숨깁니다.

        /// <summary>
        /// UseFieldCustomize 에 따라 Customize Dock을 숨깁니다.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);

            if (DesignMode || CustomizationForm == null || !UseFieldCustomize || CustomizationForm.ContainsFocus) return;

            CustomizationForm.Hide();
            //(FindForm() as EBAP.Win.BaseFrame.UIFrame).SetFiledCustomizeDockVisible(false);
        }

        #endregion

        #region :: RaisePopupMenuShowing :: Layout 저장 메뉴 아이템을 추가합니다.

        /// <summary>
        /// Layout 저장 메뉴 아이템을 추가합니다.
        /// </summary>
        /// <param name="e"></param>
        protected override void RaisePopupMenuShowing(PopupMenuShowingEventArgs e)
        {
            base.RaisePopupMenuShowing(e);

            IFrameUI uiForm = FindForm() as IFrameUI;

            if (uiForm == null || e.HitInfo.HitTest.ToString() != "HeadersArea") return;

            string keyName = String.Format("{0}{1}", uiForm.MENUID, Name);
            string getValue = Win32Util.GetIniValue(AppConfig.SETTINGFILEPATH, "GridLayout", keyName);

            bool menuEnable = getValue != string.Empty && File.Exists(getValue);

            e.Menu.Items.BeginUpdate();

            DXMenuItem menu;

            menu = new DXMenuItem("맞춤", OnMenuItemClick);
            menu.BeginGroup = true;
            menu.Enabled = true;
            menu.Tag = "BestFit";
            e.Menu.Items.Add(menu);

            string rowGrandTotalCaption = OptionsView.ShowRowGrandTotals ? "Row 전체 합계 숨김" : "Row 전체 합계 보임";

            menu = new DXMenuItem(rowGrandTotalCaption, OnMenuItemClick);
            menu.BeginGroup = true;
            menu.Enabled = true;
            menu.Tag = "RowTotal";
            e.Menu.Items.Add(menu);

            string rowTotalCaption = OptionsView.ShowRowTotals ? "Row 합계 숨김" : "Row 합계 보임";

            menu = new DXMenuItem(rowTotalCaption, OnMenuItemClick);
            menu.BeginGroup = false;
            menu.Enabled = true;
            menu.Tag = "RowSum";
            e.Menu.Items.Add(menu);

            string colGrandTotalCaption = OptionsView.ShowColumnGrandTotals ? "컬럼 전체 합계 숨김" : "컬럼 전체 합계 보임";

            menu = new DXMenuItem(colGrandTotalCaption, OnMenuItemClick);
            menu.BeginGroup = true;
            menu.Enabled = true;
            menu.Tag = "ColTotal";
            e.Menu.Items.Add(menu);

            string colTotalCaption = OptionsView.ShowColumnTotals ? "컬럼 합계 숨김" : "컬럼 합계 보임";

            menu = new DXMenuItem(colTotalCaption, OnMenuItemClick);
            menu.BeginGroup = false;
            menu.Enabled = true;
            menu.Tag = "ColSum";
            e.Menu.Items.Add(menu);

            menu = new DXMenuItem("컬럼 Layout 불러오기", OnMenuItemClick);
            menu.BeginGroup = true;
            menu.Enabled = menuEnable;
            menu.Tag = "LayoutLoad";
            e.Menu.Items.Add(menu);

            menu = new DXMenuItem("컬럼 Layout 저장", OnMenuItemClick);
            menu.BeginGroup = false;
            menu.Enabled = true;
            menu.Tag = "LayoutSave";
            e.Menu.Items.Add(menu);

            menu = new DXMenuItem("컬럼 Layout 삭제", OnMenuItemClick);
            menu.BeginGroup = false;
            menu.Enabled = menuEnable;
            menu.Tag = "LayoutDelete";
            e.Menu.Items.Add(menu);

            e.Menu.Items.EndUpdate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMenuItemClick(object sender, EventArgs e)
        {
            DXMenuItem item = sender as DXMenuItem;
            IFrameUI uiForm = FindForm() as IFrameUI;

            if (item == null || item.Tag == null || uiForm == null) return;

            string keyName = String.Format("{0}{1}", uiForm.MENUID, Name);

            string itemTag = item.Tag.ToString();

            if (itemTag == "LayoutLoad")
            {
                try
                {
                    string getValue = Win32Util.GetIniValue(AppConfig.SETTINGFILEPATH, "GridLayout", keyName);
                    RestoreLayoutFromXml(getValue, OptionsLayoutBase.FullLayout);
                }
                catch (Exception ex)
                {
                    Win32Util.SetIniValue(AppConfig.SETTINGFILEPATH, "GridLayout", keyName, "");
                    (FindForm() as IDialog).ShowExceptionBox(ex);
                }
            }
            else if (itemTag == "BestFit")
            {
                BestFit();
            }
            else if (itemTag == "LayoutSave")
            {
                AppUtil.CreateFolder(AppConfig.GRIDLAYOUTFOLDER);

                string path = Path.Combine(AppConfig.GRIDLAYOUTFOLDER, String.Format("{0}.xml", keyName));
                SaveLayoutToXml(path, OptionsLayoutBase.FullLayout);
                //SaveLayoutToXml(path);

                Win32Util.SetIniValue(AppConfig.SETTINGFILEPATH, "GridLayout", keyName, path);
                (FindForm() as IDialog).ShowAlertMessage("Layout 저장 완료", String.Format("{0}{1}Layout이 저장되었습니다.", path, Environment.NewLine), "");
            }
            else if (itemTag == "LayoutDelete")
            {
                //if ((FindForm() as IDialog).ShowMsgBox("이전 저장된 Layout을 삭제할까요?", "삭제 확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                //{
                Win32Util.SetIniValue(AppConfig.SETTINGFILEPATH, "GridLayout", keyName, "");
                (FindForm() as IDialog).ShowAlertMessage("Layout 삭제 완료", String.Format("{0}{1}Layout이 삭제되었습니다.", keyName, Environment.NewLine), "");
                //}
            }
            else if (itemTag == "RowTotal")
            {
                OptionsView.ShowRowGrandTotals = !OptionsView.ShowRowGrandTotals;
            }
            else if (itemTag == "RowSum")
            {
                OptionsView.ShowRowTotals = !OptionsView.ShowRowTotals;
            }
            else if (itemTag == "ColTotal")
            {
                OptionsView.ShowColumnGrandTotals = !OptionsView.ShowColumnGrandTotals;
            }
            else if (itemTag == "ColSum")
            {
                OptionsView.ShowColumnTotals = !OptionsView.ShowColumnTotals;
            }
        }

        #endregion

        #region :: OnDoubleClick :: 더블클릭하면 상세 데이터 팝업을 보여줍니다.

        /// <summary>
        /// 더블클릭하면 상세 데이터 팝업을 보여줍니다.
        /// </summary>
        /// <param name="ee"></param>
        protected override void OnDoubleClick(EventArgs ee)
        {
            base.OnDoubleClick(ee);

            if (!ViewEvidence) return;

            ParamCollection param = new ParamCollection();

            if (FocusedCell == null)
                param.Add("EVIDENCEDATA", CreateDrillDownDataSource());
            else
                param.Add("EVIDENCEDATA", CreateDrillDownDataSource(FocusedCell.X, FocusedCell.Y));

            (FindForm() as IFrameUI).ExecutePopup("DATA 상세", "EBAP.UI.ADM.dll", "EBAP.UI.ADM.Popup.PopViewEvidence", param);
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        protected override void RaiseDataSourceChanged()
        {
            base.RaiseDataSourceChanged();

            IFrameUI ui = FindForm() as IFrameUI;

            if (DesignMode || ui == null) return;

            string keyName = String.Format("{0}{1}", ui.MENUID, Name);

            string getValue = Win32Util.GetIniValue(AppConfig.SETTINGFILEPATH, "GridLayout", keyName);

            if (getValue == string.Empty || !File.Exists(getValue) || DataSource == null) return;

            //RestoreLayoutFromXml(getValue, OptionsLayoutBase.FullLayout);
            OptionsLayoutBase oBase = new OptionsLayoutBase();

            RestoreLayoutFromXml(getValue, oBase);
        }
    }
}