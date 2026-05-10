namespace EBAP.UI.ADM.Management
{
    partial class MenuOperationLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuOperationLog));
            this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.cboVendor = new EBAP.Win.ControlLibrary.PComboBoxEdit();
            this.cboOperation = new EBAP.Win.ControlLibrary.PCheckedComboBoxEdit();
            this.deStartEnd = new EBAP.Win.UserControlLibrary.PDateFromToEdit();
            this.pTextEdit4 = new EBAP.Win.ControlLibrary.PTextEdit();
            this.pTextEdit3 = new EBAP.Win.ControlLibrary.PTextEdit();
            this.pTextEdit2 = new EBAP.Win.ControlLibrary.PTextEdit();
            this.pTextEdit1 = new EBAP.Win.ControlLibrary.PTextEdit();
            this.btnSelection = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutFilter = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.gridList = new EBAP.Win.ControlLibrary.PGridControl();
            this.viewList = new EBAP.Win.ControlLibrary.PGridView();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl.Panel1)).BeginInit();
            this.splitContainerControl.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl.Panel2)).BeginInit();
            this.splitContainerControl.Panel2.SuspendLayout();
            this.splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboVendor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOperation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pTextEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pTextEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pTextEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pTextEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
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
            this.layoutControl1.Controls.Add(this.cboVendor);
            this.layoutControl1.Controls.Add(this.cboOperation);
            this.layoutControl1.Controls.Add(this.deStartEnd);
            this.layoutControl1.Controls.Add(this.pTextEdit4);
            this.layoutControl1.Controls.Add(this.pTextEdit3);
            this.layoutControl1.Controls.Add(this.pTextEdit2);
            this.layoutControl1.Controls.Add(this.pTextEdit1);
            this.layoutControl1.Controls.Add(this.btnSelection);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(260, 738);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // cboVendor
            // 
            this.cboVendor.BindingMember = null;
            this.cboVendor.EditValue = "";
            this.cboVendor.LocaleEnumClass = "Vendor";
            this.cboVendor.Location = new System.Drawing.Point(67, 73);
            this.cboVendor.Name = "cboVendor";
            this.cboVendor.ParamName = "@VENDORCODE";
            this.cboVendor.Properties.Appearance.Options.UseFont = true;
            this.cboVendor.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboVendor.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.cboVendor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboVendor.Properties.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.cboVendor.Properties.NullText = "";
            this.cboVendor.ShowCodeColumn = false;
            this.cboVendor.Size = new System.Drawing.Size(184, 20);
            this.cboVendor.StyleController = this.layoutControl1;
            this.cboVendor.TabIndex = 30;
            // 
            // cboOperation
            // 
            this.cboOperation.BindingMember = null;
            this.cboOperation.EditValue = "";
            this.cboOperation.LocaleEnumClass = null;
            this.cboOperation.Location = new System.Drawing.Point(67, 193);
            this.cboOperation.Name = "cboOperation";
            this.cboOperation.ParamName = "@OPERATION";
            this.cboOperation.Properties.Appearance.Options.UseFont = true;
            this.cboOperation.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboOperation.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboOperation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboOperation.Properties.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.cboOperation.Properties.IncrementalSearch = true;
            this.cboOperation.Properties.NullText = "전체선택";
            this.cboOperation.Properties.SelectAllItemCaption = "전체선택";
            this.cboOperation.Size = new System.Drawing.Size(184, 20);
            this.cboOperation.StyleController = this.layoutControl1;
            this.cboOperation.TabIndex = 29;
            // 
            // deStartEnd
            // 
            this.deStartEnd.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.deStartEnd.Appearance.Options.UseFont = true;
            this.deStartEnd.EndDate = new System.DateTime(2018, 12, 4, 0, 0, 0, 0);
            this.deStartEnd.EndParamName = "@ENDTIME";
            this.deStartEnd.LocaleEnumClass = null;
            this.deStartEnd.Location = new System.Drawing.Point(9, 47);
            this.deStartEnd.Margin = new System.Windows.Forms.Padding(0);
            this.deStartEnd.Name = "deStartEnd";
            this.deStartEnd.Size = new System.Drawing.Size(242, 22);
            this.deStartEnd.StartDate = new System.DateTime(2018, 12, 4, 0, 0, 0, 0);
            this.deStartEnd.StartParamName = "@STARTTIME";
            this.deStartEnd.TabIndex = 28;
            // 
            // pTextEdit4
            // 
            this.pTextEdit4.AutoSelectLength = 0;
            this.pTextEdit4.BindingMember = null;
            this.pTextEdit4.EditValue = "";
            this.pTextEdit4.EnterKeySelectEvent = true;
            this.pTextEdit4.EqualControlNextSeq = 0;
            this.pTextEdit4.EqualTotalControlNextSeq = 0;
            this.pTextEdit4.LocaleEnumClass = null;
            this.pTextEdit4.Location = new System.Drawing.Point(67, 169);
            this.pTextEdit4.Name = "pTextEdit4";
            this.pTextEdit4.ParamName = "@MENUNAME";
            this.pTextEdit4.Properties.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.pTextEdit4.Properties.Appearance.Options.UseFont = true;
            this.pTextEdit4.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.pTextEdit4.Size = new System.Drawing.Size(184, 20);
            this.pTextEdit4.StyleController = this.layoutControl1;
            this.pTextEdit4.TabIndex = 20;
            // 
            // pTextEdit3
            // 
            this.pTextEdit3.AutoSelectLength = 0;
            this.pTextEdit3.BindingMember = null;
            this.pTextEdit3.EditValue = "";
            this.pTextEdit3.EnterKeySelectEvent = true;
            this.pTextEdit3.EqualControlNextSeq = 0;
            this.pTextEdit3.EqualTotalControlNextSeq = 0;
            this.pTextEdit3.LocaleEnumClass = null;
            this.pTextEdit3.Location = new System.Drawing.Point(67, 145);
            this.pTextEdit3.Name = "pTextEdit3";
            this.pTextEdit3.ParamName = "@MENUID";
            this.pTextEdit3.Properties.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.pTextEdit3.Properties.Appearance.Options.UseFont = true;
            this.pTextEdit3.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.pTextEdit3.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.pTextEdit3.Size = new System.Drawing.Size(184, 20);
            this.pTextEdit3.StyleController = this.layoutControl1;
            this.pTextEdit3.TabIndex = 19;
            // 
            // pTextEdit2
            // 
            this.pTextEdit2.AutoSelectLength = 0;
            this.pTextEdit2.BindingMember = null;
            this.pTextEdit2.EditValue = "";
            this.pTextEdit2.EnterKeySelectEvent = true;
            this.pTextEdit2.EqualControlNextSeq = 0;
            this.pTextEdit2.EqualTotalControlNextSeq = 0;
            this.pTextEdit2.LocaleEnumClass = null;
            this.pTextEdit2.Location = new System.Drawing.Point(67, 121);
            this.pTextEdit2.Name = "pTextEdit2";
            this.pTextEdit2.ParamName = "@USERNAME";
            this.pTextEdit2.Properties.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.pTextEdit2.Properties.Appearance.Options.UseFont = true;
            this.pTextEdit2.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.pTextEdit2.Size = new System.Drawing.Size(184, 20);
            this.pTextEdit2.StyleController = this.layoutControl1;
            this.pTextEdit2.TabIndex = 18;
            // 
            // pTextEdit1
            // 
            this.pTextEdit1.AutoSelectLength = 0;
            this.pTextEdit1.BindingMember = null;
            this.pTextEdit1.EditValue = "";
            this.pTextEdit1.EnterKeySelectEvent = true;
            this.pTextEdit1.EqualControlNextSeq = 0;
            this.pTextEdit1.EqualTotalControlNextSeq = 0;
            this.pTextEdit1.LocaleEnumClass = null;
            this.pTextEdit1.Location = new System.Drawing.Point(67, 97);
            this.pTextEdit1.Name = "pTextEdit1";
            this.pTextEdit1.ParamName = "@USERID";
            this.pTextEdit1.Properties.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.pTextEdit1.Properties.Appearance.Options.UseFont = true;
            this.pTextEdit1.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.pTextEdit1.Size = new System.Drawing.Size(184, 20);
            this.pTextEdit1.StyleController = this.layoutControl1;
            this.pTextEdit1.TabIndex = 17;
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
            this.layoutControlItem13,
            this.layoutControlItem14,
            this.layoutControlItem15,
            this.layoutControlItem16,
            this.layoutControlItem17,
            this.layoutControlItem3,
            this.layoutControlItem1});
            this.layoutFilter.Location = new System.Drawing.Point(0, 0);
            this.layoutFilter.Name = "layoutFilter";
            this.layoutFilter.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutFilter.Size = new System.Drawing.Size(258, 736);
            this.layoutFilter.Text = "조회 조건";
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 187);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(246, 476);
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
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.deStartEnd;
            this.layoutControlItem13.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(246, 43);
            this.layoutControlItem13.Text = "기간";
            this.layoutControlItem13.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem13.TextSize = new System.Drawing.Size(46, 14);
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.pTextEdit1;
            this.layoutControlItem14.Location = new System.Drawing.Point(0, 67);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(246, 24);
            this.layoutControlItem14.Text = "사용자 ID";
            this.layoutControlItem14.TextSize = new System.Drawing.Size(46, 14);
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.pTextEdit2;
            this.layoutControlItem15.Location = new System.Drawing.Point(0, 91);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(246, 24);
            this.layoutControlItem15.Text = "사용자명";
            this.layoutControlItem15.TextSize = new System.Drawing.Size(46, 14);
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.pTextEdit3;
            this.layoutControlItem16.Location = new System.Drawing.Point(0, 115);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(246, 24);
            this.layoutControlItem16.Text = "메뉴 ID";
            this.layoutControlItem16.TextSize = new System.Drawing.Size(46, 14);
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.Control = this.pTextEdit4;
            this.layoutControlItem17.Location = new System.Drawing.Point(0, 139);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new System.Drawing.Size(246, 24);
            this.layoutControlItem17.Text = "메뉴명";
            this.layoutControlItem17.TextSize = new System.Drawing.Size(46, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.cboOperation;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 163);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(246, 24);
            this.layoutControlItem3.Text = "작업";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(46, 14);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.cboVendor;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 43);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(246, 24);
            this.layoutControlItem1.Text = "업체";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(46, 14);
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.gridList);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(0, 0);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup3;
            this.layoutControl2.Size = new System.Drawing.Size(994, 738);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // gridList
            // 
            this.gridList.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridList.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridList.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridList.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridList.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridList.Location = new System.Drawing.Point(5, 5);
            this.gridList.MainView = this.viewList;
            this.gridList.Name = "gridList";
            this.gridList.Size = new System.Drawing.Size(984, 728);
            this.gridList.TabIndex = 4;
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
            this.viewList.Appearance.TopNewRow.Options.UseFont = true;
            this.viewList.Appearance.ViewCaption.Font = new System.Drawing.Font("나눔고딕", 8.75F, System.Drawing.FontStyle.Bold);
            this.viewList.Appearance.ViewCaption.Options.UseFont = true;
            this.viewList.Appearance.ViewCaption.Options.UseForeColor = true;
            this.viewList.Appearance.ViewCaption.Options.UseTextOptions = true;
            this.viewList.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.viewList.ColumnPanelRowHeight = 30;
            this.viewList.EnableSaveLayout = true;
            this.viewList.GridControl = this.gridList;
            this.viewList.KeyColumns = null;
            this.viewList.MandatoryColumns = null;
            this.viewList.Name = "viewList";
            this.viewList.NewRowCopyColumns = null;
            this.viewList.NewRowEnableColumns = null;
            this.viewList.OptionsBehavior.AutoExpandAllGroups = true;
            this.viewList.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.viewList.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.viewList.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.viewList.OptionsView.ColumnAutoWidth = false;
            this.viewList.OptionsView.ShowGroupPanel = false;
            this.viewList.RowHeight = 29;
            this.viewList.ViewCaptionHeight = 25;
            this.viewList.DoubleClick += new System.EventHandler(this.viewList_DoubleClick);
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup3.GroupBordersVisible = false;
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.layoutControlGroup3.Name = "Root";
            this.layoutControlGroup3.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlGroup3.Size = new System.Drawing.Size(994, 738);
            this.layoutControlGroup3.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridList;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(988, 732);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // MenuOperationLog
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1264, 762);
            this.Controls.Add(this.splitContainerControl);
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("MenuOperationLog.IconOptions.SvgImage")));
            this.ISLOADING = true;
            this.Name = "MenuOperationLog";
            this.Selection += new System.EventHandler(this.MenuOperationLog_Selection);
            this.Reload += new System.EventHandler(this.MenuOperationLog_Load);
            this.Load += new System.EventHandler(this.MenuOperationLog_Load);
            this.Controls.SetChildIndex(this.splitContainerControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl.Panel1)).EndInit();
            this.splitContainerControl.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl.Panel2)).EndInit();
            this.splitContainerControl.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboVendor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOperation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pTextEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pTextEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pTextEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pTextEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
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
        private Win.ControlLibrary.PTextEdit pTextEdit4;
        private Win.ControlLibrary.PTextEdit pTextEdit3;
        private Win.ControlLibrary.PTextEdit pTextEdit2;
        private Win.ControlLibrary.PTextEdit pTextEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private Win.ControlLibrary.PGridControl gridList;
        private Win.ControlLibrary.PGridView viewList;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private Win.UserControlLibrary.PDateFromToEdit deStartEnd;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private Win.ControlLibrary.PCheckedComboBoxEdit cboOperation;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private Win.ControlLibrary.PComboBoxEdit cboVendor;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}
