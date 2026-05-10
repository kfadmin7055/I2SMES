namespace EBAP.UI.ADM.Management
{
    partial class SignLog
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
            this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.deStartEnd = new EBAP.Win.UserControlLibrary.PDateFromToEdit();
            this.txtHostName = new EBAP.Win.ControlLibrary.PTextEdit();
            this.txtUserName = new EBAP.Win.ControlLibrary.PTextEdit();
            this.txtUserId = new EBAP.Win.ControlLibrary.PTextEdit();
            this.cboOperation = new EBAP.Win.ControlLibrary.PComboBoxEdit();
            this.btnSelection = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutFilter = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.gridMenuLog = new EBAP.Win.ControlLibrary.PGridControl();
            this.viewMenuLog = new EBAP.Win.ControlLibrary.PGridView();
            this.gridList = new EBAP.Win.ControlLibrary.PGridControl();
            this.viewList = new EBAP.Win.ControlLibrary.PGridView();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem29 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem2 = new DevExpress.XtraLayout.SplitterItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem30 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHostName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOperation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMenuLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewMenuLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).BeginInit();
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
            this.splitContainerControl.Location = new System.Drawing.Point(0, 31);
            this.splitContainerControl.Name = "splitContainerControl";
            this.splitContainerControl.Panel1.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.splitContainerControl.Panel1.Appearance.Options.UseFont = true;
            this.splitContainerControl.Panel1.Controls.Add(this.layoutControl1);
            this.splitContainerControl.Panel1.Text = "Panel1";
            this.splitContainerControl.Panel2.Controls.Add(this.layoutControl2);
            this.splitContainerControl.Panel2.Text = "Panel2";
            this.splitContainerControl.ShowCaption = true;
            this.splitContainerControl.Size = new System.Drawing.Size(1264, 731);
            this.splitContainerControl.SplitterPosition = 260;
            this.splitContainerControl.TabIndex = 4;
            this.splitContainerControl.Text = "splitContainerControl1";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.deStartEnd);
            this.layoutControl1.Controls.Add(this.txtHostName);
            this.layoutControl1.Controls.Add(this.txtUserName);
            this.layoutControl1.Controls.Add(this.txtUserId);
            this.layoutControl1.Controls.Add(this.cboOperation);
            this.layoutControl1.Controls.Add(this.btnSelection);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(232, 731);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // deStartEnd
            // 
            this.deStartEnd.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.deStartEnd.Appearance.Options.UseFont = true;
            this.deStartEnd.EndDate = new System.DateTime(2018, 4, 10, 0, 0, 0, 0);
            this.deStartEnd.EndParamName = "@ENDTIME";
            this.deStartEnd.LocaleEnumClass = null;
            this.deStartEnd.Location = new System.Drawing.Point(9, 46);
            this.deStartEnd.Margin = new System.Windows.Forms.Padding(0);
            this.deStartEnd.Name = "deStartEnd";
            this.deStartEnd.Size = new System.Drawing.Size(214, 21);
            this.deStartEnd.StartDate = new System.DateTime(2018, 4, 10, 0, 0, 0, 0);
            this.deStartEnd.StartParamName = "@STARTTIME";
            this.deStartEnd.TabIndex = 28;
            // 
            // txtHostName
            // 
            this.txtHostName.AutoSelectLength = 0;
            this.txtHostName.BindingMember = null;
            this.txtHostName.EditValue = "";
            this.txtHostName.EnterKeySelectEvent = true;
            this.txtHostName.EqualControlNextSeq = 0;
            this.txtHostName.EqualTotalControlNextSeq = 0;
            this.txtHostName.LocaleEnumClass = null;
            this.txtHostName.Location = new System.Drawing.Point(58, 119);
            this.txtHostName.Name = "txtHostName";
            this.txtHostName.ParamName = "@HOSTNAME";
            this.txtHostName.Properties.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.txtHostName.Properties.Appearance.Options.UseFont = true;
            this.txtHostName.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtHostName.Size = new System.Drawing.Size(165, 20);
            this.txtHostName.StyleController = this.layoutControl1;
            this.txtHostName.TabIndex = 19;
            // 
            // txtUserName
            // 
            this.txtUserName.AutoSelectLength = 0;
            this.txtUserName.BindingMember = null;
            this.txtUserName.EditValue = "";
            this.txtUserName.EnterKeySelectEvent = true;
            this.txtUserName.EqualControlNextSeq = 0;
            this.txtUserName.EqualTotalControlNextSeq = 0;
            this.txtUserName.LocaleEnumClass = null;
            this.txtUserName.Location = new System.Drawing.Point(58, 95);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ParamName = "@USERNAME";
            this.txtUserName.Properties.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.txtUserName.Properties.Appearance.Options.UseFont = true;
            this.txtUserName.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtUserName.Size = new System.Drawing.Size(165, 20);
            this.txtUserName.StyleController = this.layoutControl1;
            this.txtUserName.TabIndex = 18;
            // 
            // txtUserId
            // 
            this.txtUserId.AutoSelectLength = 0;
            this.txtUserId.BindingMember = null;
            this.txtUserId.EditValue = "";
            this.txtUserId.EnterKeySelectEvent = true;
            this.txtUserId.EqualControlNextSeq = 0;
            this.txtUserId.EqualTotalControlNextSeq = 0;
            this.txtUserId.LocaleEnumClass = null;
            this.txtUserId.Location = new System.Drawing.Point(58, 71);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.ParamName = "@USERID";
            this.txtUserId.Properties.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.txtUserId.Properties.Appearance.Options.UseFont = true;
            this.txtUserId.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtUserId.Size = new System.Drawing.Size(165, 20);
            this.txtUserId.StyleController = this.layoutControl1;
            this.txtUserId.TabIndex = 17;
            // 
            // cboOperation
            // 
            this.cboOperation.BindingMember = null;
            this.cboOperation.EditValue = "";
            this.cboOperation.LocaleEnumClass = "Operation";
            this.cboOperation.Location = new System.Drawing.Point(58, 143);
            this.cboOperation.Name = "cboOperation";
            this.cboOperation.ParamName = null;
            this.cboOperation.Properties.Appearance.Options.UseFont = true;
            this.cboOperation.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboOperation.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.cboOperation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboOperation.Properties.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.cboOperation.Properties.NullText = "";
            this.cboOperation.Size = new System.Drawing.Size(165, 20);
            this.cboOperation.StyleController = this.layoutControl1;
            this.cboOperation.TabIndex = 7;
            this.cboOperation.ValueChangeSelectEvent = true;
            // 
            // btnSelection
            // 
            this.btnSelection.Appearance.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.btnSelection.Appearance.Options.UseFont = true;
            this.btnSelection.ImageOptions.ImageUri.Uri = "Find;GrayScaled";
            this.btnSelection.Location = new System.Drawing.Point(9, 684);
            this.btnSelection.Name = "btnSelection";
            this.btnSelection.Size = new System.Drawing.Size(214, 38);
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(232, 731);
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
            this.layoutControlItem16,
            this.layoutControlItem1,
            this.layoutControlItem3});
            this.layoutFilter.Location = new System.Drawing.Point(0, 0);
            this.layoutFilter.Name = "layoutFilter";
            this.layoutFilter.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutFilter.Size = new System.Drawing.Size(230, 729);
            this.layoutFilter.Text = "조회 조건";
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 138);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(218, 517);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnSelection;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 655);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(218, 42);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.txtUserId;
            this.layoutControlItem14.Location = new System.Drawing.Point(0, 42);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(218, 24);
            this.layoutControlItem14.Text = "사용자 ID";
            this.layoutControlItem14.TextSize = new System.Drawing.Size(46, 14);
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.txtUserName;
            this.layoutControlItem15.Location = new System.Drawing.Point(0, 66);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(218, 24);
            this.layoutControlItem15.Text = "사용자명";
            this.layoutControlItem15.TextSize = new System.Drawing.Size(46, 14);
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.txtHostName;
            this.layoutControlItem16.Location = new System.Drawing.Point(0, 90);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(218, 24);
            this.layoutControlItem16.Text = "Host";
            this.layoutControlItem16.TextSize = new System.Drawing.Size(46, 14);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.cboOperation;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 114);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(218, 24);
            this.layoutControlItem1.Text = "작업";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(46, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.deStartEnd;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(218, 42);
            this.layoutControlItem3.Text = "기간";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(46, 14);
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.layoutControl);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(0, 0);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup3;
            this.layoutControl2.Size = new System.Drawing.Size(1027, 731);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.gridMenuLog);
            this.layoutControl.Controls.Add(this.gridList);
            this.layoutControl.Location = new System.Drawing.Point(5, 5);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(55, -28, 250, 350);
            this.layoutControl.OptionsView.HighlightFocusedItem = true;
            this.layoutControl.Root = this.layoutControlGroup4;
            this.layoutControl.Size = new System.Drawing.Size(1017, 721);
            this.layoutControl.TabIndex = 4;
            this.layoutControl.Text = "layoutControl1";
            // 
            // gridMenuLog
            // 
            this.gridMenuLog.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridMenuLog.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridMenuLog.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridMenuLog.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridMenuLog.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridMenuLog.Location = new System.Drawing.Point(3, 464);
            this.gridMenuLog.MainView = this.viewMenuLog;
            this.gridMenuLog.Name = "gridMenuLog";
            this.gridMenuLog.Size = new System.Drawing.Size(1011, 254);
            this.gridMenuLog.TabIndex = 11;
            this.gridMenuLog.UseEmbeddedNavigator = true;
            this.gridMenuLog.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewMenuLog});
            // 
            // viewMenuLog
            // 
            this.viewMenuLog.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.viewMenuLog.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.viewMenuLog.Appearance.ViewCaption.Options.UseTextOptions = true;
            this.viewMenuLog.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.viewMenuLog.ColumnPanelRowHeight = 30;
            this.viewMenuLog.GridControl = this.gridMenuLog;
            this.viewMenuLog.KeyColumns = null;
            this.viewMenuLog.MandatoryColumns = null;
            this.viewMenuLog.Name = "viewMenuLog";
            this.viewMenuLog.NewRowCopyColumns = null;
            this.viewMenuLog.NewRowEnableColumns = null;
            this.viewMenuLog.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.viewMenuLog.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.viewMenuLog.OptionsView.ShowGroupPanel = false;
            this.viewMenuLog.OptionsView.ShowViewCaption = true;
            this.viewMenuLog.RowHeight = 29;
            this.viewMenuLog.ViewCaption = "Menu Execute Log";
            this.viewMenuLog.ViewCaptionHeight = 25;
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
            this.gridList.Location = new System.Drawing.Point(3, 3);
            this.gridList.MainView = this.viewList;
            this.gridList.Name = "gridList";
            this.gridList.Size = new System.Drawing.Size(1011, 452);
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
            this.viewList.EnableSaveLayout = true;
            this.viewList.GridControl = this.gridList;
            this.viewList.KeyColumns = null;
            this.viewList.MandatoryColumns = null;
            this.viewList.Name = "viewList";
            this.viewList.NewRowCopyColumns = null;
            this.viewList.NewRowEnableColumns = null;
            this.viewList.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.viewList.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.viewList.OptionsSelection.MultiSelect = true;
            this.viewList.OptionsView.ColumnAutoWidth = false;
            this.viewList.OptionsView.ShowGroupPanel = false;
            this.viewList.RowHeight = 29;
            this.viewList.ViewCaptionHeight = 25;
            this.viewList.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.viewList_FocusedRowChanged);
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
            this.layoutControlItem29,
            this.splitterItem2});
            this.layoutControlGroup4.Name = "Root";
            this.layoutControlGroup4.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlGroup4.Size = new System.Drawing.Size(1017, 721);
            this.layoutControlGroup4.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridList;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1015, 456);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem29
            // 
            this.layoutControlItem29.Control = this.gridMenuLog;
            this.layoutControlItem29.Location = new System.Drawing.Point(0, 461);
            this.layoutControlItem29.Name = "layoutControlItem7";
            this.layoutControlItem29.Size = new System.Drawing.Size(1015, 258);
            this.layoutControlItem29.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem29.TextVisible = false;
            // 
            // splitterItem2
            // 
            this.splitterItem2.AllowHotTrack = true;
            this.splitterItem2.Location = new System.Drawing.Point(0, 456);
            this.splitterItem2.Name = "splitterItem2";
            this.splitterItem2.Size = new System.Drawing.Size(1015, 5);
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup3.GroupBordersVisible = false;
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem30});
            this.layoutControlGroup3.Name = "Root";
            this.layoutControlGroup3.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlGroup3.Size = new System.Drawing.Size(1027, 731);
            this.layoutControlGroup3.TextVisible = false;
            // 
            // layoutControlItem30
            // 
            this.layoutControlItem30.Control = this.layoutControl;
            this.layoutControlItem30.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem30.Name = "layoutControlItem30";
            this.layoutControlItem30.Size = new System.Drawing.Size(1021, 725);
            this.layoutControlItem30.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem30.TextVisible = false;
            // 
            // SignLog
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1264, 762);
            this.Controls.Add(this.splitContainerControl);
            this.ISLOADING = true;
            this.Name = "SignLog";
            this.Link += new System.EventHandler(this.SignLog_Link);
            this.Selection += new System.EventHandler(this.SignLog_Selection);
            this.Reload += new System.EventHandler(this.SignLog_Load);
            this.Load += new System.EventHandler(this.SignLog_Load);
            this.Controls.SetChildIndex(this.splitContainerControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtHostName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOperation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMenuLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewMenuLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton btnSelection;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutFilter;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private Win.ControlLibrary.PTextEdit txtHostName;
        private Win.ControlLibrary.PTextEdit txtUserName;
        private Win.ControlLibrary.PTextEdit txtUserId;
        private Win.ControlLibrary.PComboBoxEdit cboOperation;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private Win.ControlLibrary.PGridControl gridMenuLog;
        private Win.ControlLibrary.PGridView viewMenuLog;
        private Win.ControlLibrary.PGridControl gridList;
        private Win.ControlLibrary.PGridView viewList;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem29;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem30;
        private Win.UserControlLibrary.PDateFromToEdit deStartEnd;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.SplitterItem splitterItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;


    }
}
