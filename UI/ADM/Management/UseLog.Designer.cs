namespace EBAP.UI.ADM.Management
{
    partial class UseLog
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UseLog));
            this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.deStartEnd = new EBAP.Win.UserControlLibrary.PDateFromToEdit();
            this.txtQueryId = new EBAP.Win.ControlLibrary.PTextEdit();
            this.txtMethodName = new EBAP.Win.ControlLibrary.PTextEdit();
            this.btnSelection = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutFilter = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.pPivotGridControl1 = new EBAP.Win.ControlLibrary.PPivotGridControl();
            this.chartList = new EBAP.Win.ControlLibrary.PChart();
            this.gridList = new EBAP.Win.ControlLibrary.PGridControl();
            this.viewList = new EBAP.Win.ControlLibrary.PGridView();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem27 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem28 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem29 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl.Panel1)).BeginInit();
            this.splitContainerControl.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl.Panel2)).BeginInit();
            this.splitContainerControl.Panel2.SuspendLayout();
            this.splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQueryId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMethodName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pPivotGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl
            // 
            this.splitContainerControl.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.splitContainerControl.Appearance.Options.UseFont = true;
            this.splitContainerControl.AppearanceCaption.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.splitContainerControl.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl.CaptionLocation = DevExpress.Utils.Locations.Top;
            this.splitContainerControl.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel1;
            this.splitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl.Location = new System.Drawing.Point(0, 24);
            this.splitContainerControl.Name = "splitContainerControl";
            // 
            // splitContainerControl.Panel1
            // 
            this.splitContainerControl.Panel1.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.splitContainerControl.Panel1.Appearance.Options.UseFont = true;
            this.splitContainerControl.Panel1.Controls.Add(this.layoutControl1);
            this.splitContainerControl.Panel1.Text = "Panel1";
            // 
            // splitContainerControl.Panel2
            // 
            this.splitContainerControl.Panel2.Controls.Add(this.layoutControl2);
            this.splitContainerControl.Panel2.Text = "Panel2";
            this.splitContainerControl.ShowCaption = true;
            this.splitContainerControl.Size = new System.Drawing.Size(1264, 738);
            this.splitContainerControl.SplitterPosition = 260;
            this.splitContainerControl.TabIndex = 4;
            this.splitContainerControl.Text = "splitContainerControl1";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.deStartEnd);
            this.layoutControl1.Controls.Add(this.txtQueryId);
            this.layoutControl1.Controls.Add(this.txtMethodName);
            this.layoutControl1.Controls.Add(this.btnSelection);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(260, 738);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // deStartEnd
            // 
            this.deStartEnd.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.deStartEnd.Appearance.Options.UseFont = true;
            this.deStartEnd.EndDate = new System.DateTime(2018, 4, 10, 0, 0, 0, 0);
            this.deStartEnd.EndParamName = "@ENDDTTM";
            this.deStartEnd.LocaleEnumClass = null;
            this.deStartEnd.Location = new System.Drawing.Point(9, 47);
            this.deStartEnd.Margin = new System.Windows.Forms.Padding(0);
            this.deStartEnd.Name = "deStartEnd";
            this.deStartEnd.Size = new System.Drawing.Size(242, 22);
            this.deStartEnd.StartDate = new System.DateTime(2018, 4, 10, 0, 0, 0, 0);
            this.deStartEnd.StartParamName = "@STARTDTTM";
            this.deStartEnd.TabIndex = 28;
            // 
            // txtQueryId
            // 
            this.txtQueryId.AutoSelectLength = 0;
            this.txtQueryId.BindingMember = null;
            this.txtQueryId.EditValue = "";
            this.txtQueryId.EnterKeySelectEvent = true;
            this.txtQueryId.EqualControlNextSeq = 0;
            this.txtQueryId.EqualTotalControlNextSeq = 0;
            this.txtQueryId.LocaleEnumClass = null;
            this.txtQueryId.Location = new System.Drawing.Point(63, 97);
            this.txtQueryId.Name = "txtQueryId";
            this.txtQueryId.ParamName = "@QUERYID";
            this.txtQueryId.Properties.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.txtQueryId.Properties.Appearance.Options.UseFont = true;
            this.txtQueryId.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtQueryId.Size = new System.Drawing.Size(188, 20);
            this.txtQueryId.StyleController = this.layoutControl1;
            this.txtQueryId.TabIndex = 18;
            // 
            // txtMethodName
            // 
            this.txtMethodName.AutoSelectLength = 0;
            this.txtMethodName.BindingMember = null;
            this.txtMethodName.EditValue = "";
            this.txtMethodName.EnterKeySelectEvent = true;
            this.txtMethodName.EqualControlNextSeq = 0;
            this.txtMethodName.EqualTotalControlNextSeq = 0;
            this.txtMethodName.LocaleEnumClass = null;
            this.txtMethodName.Location = new System.Drawing.Point(63, 73);
            this.txtMethodName.Name = "txtMethodName";
            this.txtMethodName.ParamName = "@METHODNAME";
            this.txtMethodName.Properties.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.txtMethodName.Properties.Appearance.Options.UseFont = true;
            this.txtMethodName.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtMethodName.Size = new System.Drawing.Size(188, 20);
            this.txtMethodName.StyleController = this.layoutControl1;
            this.txtMethodName.TabIndex = 17;
            // 
            // btnSelection
            // 
            this.btnSelection.Appearance.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.btnSelection.Appearance.Options.UseFont = true;
            this.btnSelection.ImageOptions.ImageUri.Uri = "Find;GrayScaled";
            this.btnSelection.Location = new System.Drawing.Point(9, 693);
            this.btnSelection.Name = "btnSelection";
            this.btnSelection.Size = new System.Drawing.Size(242, 36);
            this.btnSelection.StyleController = this.layoutControl1;
            this.btnSelection.TabIndex = 6;
            this.btnSelection.Text = "조회 [F5]";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutFilter});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlGroup1.Size = new System.Drawing.Size(260, 738);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutFilter
            // 
            this.layoutFilter.AppearanceGroup.Font = new System.Drawing.Font("나눔고딕", 10F, System.Drawing.FontStyle.Bold);
            this.layoutFilter.AppearanceGroup.Options.UseFont = true;
            this.layoutFilter.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlItem7,
            this.layoutControlItem14,
            this.layoutControlItem15,
            this.layoutControlItem13});
            this.layoutFilter.Location = new System.Drawing.Point(0, 0);
            this.layoutFilter.Name = "layoutFilter";
            this.layoutFilter.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutFilter.Size = new System.Drawing.Size(258, 736);
            this.layoutFilter.Text = "조회 조건";
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 91);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(246, 572);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnSelection;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 663);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(246, 40);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.txtMethodName;
            this.layoutControlItem14.Location = new System.Drawing.Point(0, 43);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(246, 24);
            this.layoutControlItem14.Text = "Method";
            this.layoutControlItem14.TextSize = new System.Drawing.Size(42, 14);
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.txtQueryId;
            this.layoutControlItem15.Location = new System.Drawing.Point(0, 67);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(246, 24);
            this.layoutControlItem15.Text = "Query";
            this.layoutControlItem15.TextSize = new System.Drawing.Size(42, 14);
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.deStartEnd;
            this.layoutControlItem13.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(246, 43);
            this.layoutControlItem13.Text = "기간";
            this.layoutControlItem13.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem13.TextSize = new System.Drawing.Size(42, 14);
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.layoutControl);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(0, 0);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup3;
            this.layoutControl2.Size = new System.Drawing.Size(994, 738);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.pPivotGridControl1);
            this.layoutControl.Controls.Add(this.chartList);
            this.layoutControl.Controls.Add(this.gridList);
            this.layoutControl.Location = new System.Drawing.Point(3, 3);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.OptionsView.HighlightFocusedItem = true;
            this.layoutControl.Root = this.layoutControlGroup4;
            this.layoutControl.Size = new System.Drawing.Size(988, 732);
            this.layoutControl.TabIndex = 4;
            this.layoutControl.Text = "layoutControl1";
            // 
            // pPivotGridControl1
            // 
            this.pPivotGridControl1.Appearance.Cell.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.pPivotGridControl1.Appearance.Cell.Options.UseFont = true;
            this.pPivotGridControl1.Appearance.ColumnHeaderArea.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.pPivotGridControl1.Appearance.ColumnHeaderArea.Options.UseFont = true;
            this.pPivotGridControl1.Appearance.ColumnHeaderArea.Options.UseTextOptions = true;
            this.pPivotGridControl1.Appearance.ColumnHeaderArea.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.pPivotGridControl1.Appearance.DataHeaderArea.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.pPivotGridControl1.Appearance.DataHeaderArea.Options.UseFont = true;
            this.pPivotGridControl1.Appearance.DataHeaderArea.Options.UseTextOptions = true;
            this.pPivotGridControl1.Appearance.DataHeaderArea.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.pPivotGridControl1.Appearance.FieldHeader.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.pPivotGridControl1.Appearance.FieldHeader.Options.UseFont = true;
            this.pPivotGridControl1.Appearance.FieldHeader.Options.UseTextOptions = true;
            this.pPivotGridControl1.Appearance.FieldHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.pPivotGridControl1.Appearance.FieldValue.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.pPivotGridControl1.Appearance.FieldValue.Options.UseFont = true;
            this.pPivotGridControl1.Appearance.FieldValue.Options.UseTextOptions = true;
            this.pPivotGridControl1.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.pPivotGridControl1.Appearance.FieldValueGrandTotal.Options.UseFont = true;
            this.pPivotGridControl1.Appearance.FieldValueGrandTotal.Options.UseTextOptions = true;
            this.pPivotGridControl1.Appearance.FieldValueGrandTotal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.pPivotGridControl1.Appearance.FieldValueTotal.Options.UseTextOptions = true;
            this.pPivotGridControl1.Appearance.FieldValueTotal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.pPivotGridControl1.Appearance.FilterHeaderArea.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.pPivotGridControl1.Appearance.FilterHeaderArea.Options.UseFont = true;
            this.pPivotGridControl1.Appearance.HeaderArea.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.pPivotGridControl1.Appearance.HeaderArea.Options.UseFont = true;
            this.pPivotGridControl1.Appearance.HeaderArea.Options.UseTextOptions = true;
            this.pPivotGridControl1.Appearance.HeaderArea.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.pPivotGridControl1.Appearance.RowHeaderArea.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.pPivotGridControl1.Appearance.RowHeaderArea.Options.UseFont = true;
            this.pPivotGridControl1.Appearance.RowHeaderArea.Options.UseTextOptions = true;
            this.pPivotGridControl1.Appearance.RowHeaderArea.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.pPivotGridControl1.Appearance.SelectedCell.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.pPivotGridControl1.Appearance.SelectedCell.Options.UseFont = true;
            this.pPivotGridControl1.BLUEVALUE = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.pPivotGridControl1.Location = new System.Drawing.Point(496, 3);
            this.pPivotGridControl1.Name = "pPivotGridControl1";
            this.pPivotGridControl1.OptionsView.ColumnTotalsLocation = DevExpress.XtraPivotGrid.PivotTotalsLocation.Near;
            this.pPivotGridControl1.OptionsView.RowTotalsLocation = DevExpress.XtraPivotGrid.PivotRowTotalsLocation.Near;
            this.pPivotGridControl1.REDVALUE = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.pPivotGridControl1.RunningTotalField = null;
            this.pPivotGridControl1.Size = new System.Drawing.Size(489, 262);
            this.pPivotGridControl1.TabIndex = 11;
            this.pPivotGridControl1.UseFieldCustomize = true;
            this.pPivotGridControl1.ViewEvidence = true;
            // 
            // chartList
            // 
            this.chartList.Legend.LegendID = -1;
            this.chartList.Legend.Name = "Default Legend";
            this.chartList.Location = new System.Drawing.Point(3, 3);
            this.chartList.Name = "chartList";
            this.chartList.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartList.Size = new System.Drawing.Size(489, 262);
            this.chartList.TabIndex = 10;
            // 
            // gridList
            // 
            this.gridList.EmbeddedNavigator.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.gridList.EmbeddedNavigator.Appearance.Options.UseFont = true;
            this.gridList.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridList.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridList.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridList.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridList.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridList.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.gridList.Location = new System.Drawing.Point(3, 269);
            this.gridList.MainView = this.viewList;
            this.gridList.Name = "gridList";
            this.gridList.Size = new System.Drawing.Size(982, 460);
            this.gridList.TabIndex = 5;
            this.gridList.UseEmbeddedNavigator = true;
            this.gridList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewList});
            // 
            // viewList
            // 
            this.viewList.Appearance.FilterPanel.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.viewList.Appearance.FilterPanel.Options.UseFont = true;
            this.viewList.Appearance.FooterPanel.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.viewList.Appearance.FooterPanel.Options.UseFont = true;
            this.viewList.Appearance.GroupButton.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.viewList.Appearance.GroupButton.Options.UseFont = true;
            this.viewList.Appearance.GroupPanel.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.viewList.Appearance.GroupPanel.Options.UseFont = true;
            this.viewList.Appearance.GroupRow.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.viewList.Appearance.GroupRow.Options.UseFont = true;
            this.viewList.Appearance.HeaderPanel.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.viewList.Appearance.HeaderPanel.Options.UseFont = true;
            this.viewList.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.viewList.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.viewList.Appearance.Row.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.viewList.Appearance.Row.Options.UseFont = true;
            this.viewList.Appearance.TopNewRow.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.viewList.Appearance.ViewCaption.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.viewList.ColumnPanelRowHeight = 30;
            this.viewList.GridControl = this.gridList;
            this.viewList.KeyColumns = null;
            this.viewList.MandatoryColumns = null;
            this.viewList.Name = "viewList";
            this.viewList.NewRowCopyColumns = null;
            this.viewList.NewRowEnableColumns = null;
            this.viewList.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.viewList.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.viewList.OptionsView.ColumnAutoWidth = false;
            this.viewList.OptionsView.ShowGroupPanel = false;
            this.viewList.RowHeight = 29;
            this.viewList.ViewCaptionHeight = 25;
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.AppearanceGroup.Font = new System.Drawing.Font("나눔고딕", 8.75F, System.Drawing.FontStyle.Bold);
            this.layoutControlGroup4.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup4.AppearanceItemCaption.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.layoutControlGroup4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlGroup4.AppearanceTabPage.Header.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.layoutControlGroup4.AppearanceTabPage.Header.Options.UseFont = true;
            this.layoutControlGroup4.AppearanceTabPage.HeaderActive.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.layoutControlGroup4.AppearanceTabPage.HeaderActive.Options.UseFont = true;
            this.layoutControlGroup4.AppearanceTabPage.HeaderDisabled.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.layoutControlGroup4.AppearanceTabPage.HeaderDisabled.Options.UseFont = true;
            this.layoutControlGroup4.AppearanceTabPage.HeaderHotTracked.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.layoutControlGroup4.AppearanceTabPage.HeaderHotTracked.Options.UseFont = true;
            this.layoutControlGroup4.AppearanceTabPage.PageClient.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.layoutControlGroup4.AppearanceTabPage.PageClient.Options.UseFont = true;
            this.layoutControlGroup4.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup4.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup4.GroupBordersVisible = false;
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem27,
            this.layoutControlItem28});
            this.layoutControlGroup4.Name = "layoutControlGroup1";
            this.layoutControlGroup4.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlGroup4.Size = new System.Drawing.Size(988, 732);
            this.layoutControlGroup4.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridList;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 266);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(986, 464);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem27
            // 
            this.layoutControlItem27.Control = this.chartList;
            this.layoutControlItem27.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem27.Name = "layoutControlItem6";
            this.layoutControlItem27.Size = new System.Drawing.Size(493, 266);
            this.layoutControlItem27.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem27.TextVisible = false;
            // 
            // layoutControlItem28
            // 
            this.layoutControlItem28.Control = this.pPivotGridControl1;
            this.layoutControlItem28.Location = new System.Drawing.Point(493, 0);
            this.layoutControlItem28.Name = "layoutControlItem7";
            this.layoutControlItem28.Size = new System.Drawing.Size(493, 266);
            this.layoutControlItem28.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem28.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup3.GroupBordersVisible = false;
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem29});
            this.layoutControlGroup3.Name = "Root";
            this.layoutControlGroup3.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlGroup3.Size = new System.Drawing.Size(994, 738);
            this.layoutControlGroup3.TextVisible = false;
            // 
            // layoutControlItem29
            // 
            this.layoutControlItem29.Control = this.layoutControl;
            this.layoutControlItem29.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem29.Name = "layoutControlItem29";
            this.layoutControlItem29.Size = new System.Drawing.Size(992, 736);
            this.layoutControlItem29.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem29.TextVisible = false;
            // 
            // UseLog
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1264, 762);
            this.Controls.Add(this.splitContainerControl);
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("UseLog.IconOptions.SvgImage")));
            this.ISLOADING = true;
            this.Name = "UseLog";
            this.Selection += new System.EventHandler(this.UseLog_Selection);
            this.Reload += new System.EventHandler(this.UseLog_Load);
            this.Load += new System.EventHandler(this.UseLog_Load);
            this.Controls.SetChildIndex(this.splitContainerControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl.Panel1)).EndInit();
            this.splitContainerControl.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl.Panel2)).EndInit();
            this.splitContainerControl.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtQueryId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMethodName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pPivotGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton btnSelection;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutFilter;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private Win.ControlLibrary.PTextEdit txtQueryId;
        private Win.ControlLibrary.PTextEdit txtMethodName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private Win.UserControlLibrary.PDateFromToEdit deStartEnd;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private Win.ControlLibrary.PPivotGridControl pPivotGridControl1;
        private Win.ControlLibrary.PChart chartList;
        private Win.ControlLibrary.PGridControl gridList;
        private Win.ControlLibrary.PGridView viewList;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem27;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem28;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem29;
    }
}
