namespace EBAP.UI.ADM.Popup
{
    partial class PopUserInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.txtUserName = new EBAP.Win.ControlLibrary.PTextEdit();
            this.txtUserId = new EBAP.Win.ControlLibrary.PTextEdit();
            this.gridList = new EBAP.Win.ControlLibrary.PGridControl();
            this.viewList = new EBAP.Win.ControlLibrary.PGridView();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutFilter = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.txtUserName);
            this.layoutControl.Controls.Add(this.txtUserId);
            this.layoutControl.Controls.Add(this.gridList);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 31);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.OptionsView.HighlightFocusedItem = true;
            this.layoutControl.Root = this.layoutControlGroup1;
            this.layoutControl.Size = new System.Drawing.Size(1008, 535);
            this.layoutControl.TabIndex = 2;
            this.layoutControl.Text = "layoutControl1";
            // 
            // txtUserName
            // 
            this.txtUserName.EditValue = "";
            this.txtUserName.EnterKeySelectEvent = true;
            this.txtUserName.LocaleEnumClass = "UserName";
            this.txtUserName.Location = new System.Drawing.Point(290, 29);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ParamName = "@USERNAME";
            this.txtUserName.Properties.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.txtUserName.Properties.Appearance.Options.UseFont = true;
            this.txtUserName.Size = new System.Drawing.Size(209, 20);
            this.txtUserName.StyleController = this.layoutControl;
            this.txtUserName.TabIndex = 6;
            // 
            // txtUserId
            // 
            this.txtUserId.EditValue = "";
            this.txtUserId.EnterKeySelectEvent = true;
            this.txtUserId.LocaleEnumClass = "ID";
            this.txtUserId.Location = new System.Drawing.Point(44, 29);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.ParamName = "@USERID";
            this.txtUserId.Properties.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.txtUserId.Properties.Appearance.Options.UseFont = true;
            this.txtUserId.Size = new System.Drawing.Size(209, 20);
            this.txtUserId.StyleController = this.layoutControl;
            this.txtUserId.TabIndex = 5;
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
            this.gridList.Location = new System.Drawing.Point(5, 59);
            this.gridList.MainView = this.viewList;
            this.gridList.Name = "gridList";
            this.gridList.Size = new System.Drawing.Size(998, 471);
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
            this.viewList.Appearance.ViewCaption.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.viewList.Appearance.ViewCaption.Options.UseFont = true;
            this.viewList.ColumnPanelRowHeight = 30;
            this.viewList.GridControl = this.gridList;
            this.viewList.KeyColumns = null;
            this.viewList.MandatoryColumns = null;
            this.viewList.Name = "viewList";
            this.viewList.NewRowCopyColumns = null;
            this.viewList.NewRowEnableColumns = null;
            this.viewList.OptionsView.ColumnAutoWidth = false;
            this.viewList.OptionsView.ShowGroupPanel = false;
            this.viewList.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.viewList_FocusedRowChanged);
            this.viewList.DoubleClick += new System.EventHandler(this.viewList_DoubleClick);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AppearanceGroup.Font = new System.Drawing.Font("나눔고딕", 8.75F, System.Drawing.FontStyle.Bold);
            this.layoutControlGroup1.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup1.AppearanceItemCaption.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.layoutControlGroup1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlGroup1.AppearanceTabPage.Header.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.layoutControlGroup1.AppearanceTabPage.Header.Options.UseFont = true;
            this.layoutControlGroup1.AppearanceTabPage.HeaderActive.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.layoutControlGroup1.AppearanceTabPage.HeaderActive.Options.UseFont = true;
            this.layoutControlGroup1.AppearanceTabPage.HeaderDisabled.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.layoutControlGroup1.AppearanceTabPage.HeaderDisabled.Options.UseFont = true;
            this.layoutControlGroup1.AppearanceTabPage.HeaderHotTracked.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.layoutControlGroup1.AppearanceTabPage.HeaderHotTracked.Options.UseFont = true;
            this.layoutControlGroup1.AppearanceTabPage.PageClient.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.layoutControlGroup1.AppearanceTabPage.PageClient.Options.UseFont = true;
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutFilter});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1008, 535);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridList;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 54);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1002, 475);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtUserId;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(246, 24);
            this.layoutControlItem2.Text = "ID";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(30, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtUserName;
            this.layoutControlItem3.Location = new System.Drawing.Point(246, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(246, 24);
            this.layoutControlItem3.Text = "사용자";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(30, 13);
            // 
            // layoutFilter
            // 
            this.layoutFilter.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1});
            this.layoutFilter.Location = new System.Drawing.Point(0, 0);
            this.layoutFilter.Name = "layoutFilter";
            this.layoutFilter.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutFilter.Size = new System.Drawing.Size(1002, 54);
            this.layoutFilter.Text = "조회 조건";
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(492, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(498, 24);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // PopUserInfo
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 566);
            this.Controls.Add(this.layoutControl);
            this.Name = "PopUserInfo";
            this.Text = "사용자 정보";
            this.Selection += new System.EventHandler(this.PopUserInfo_Selection);
            this.Load += new System.EventHandler(this.PopUserInfo_Load);
            this.Controls.SetChildIndex(this.layoutControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private Win.ControlLibrary.PGridControl gridList;
        private Win.ControlLibrary.PGridView viewList;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private Win.ControlLibrary.PTextEdit txtUserName;
        private Win.ControlLibrary.PTextEdit txtUserId;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlGroup layoutFilter;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}