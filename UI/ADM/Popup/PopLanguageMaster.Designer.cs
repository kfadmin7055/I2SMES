namespace EBAP.UI.ADM.Popup
{
    partial class PopLanguageMaster
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
            this.txtScreenName = new EBAP.Win.ControlLibrary.PTextEdit();
            this.txtScreenId = new EBAP.Win.ControlLibrary.PTextEdit();
            this.gridList = new EBAP.Win.ControlLibrary.PGridControl();
            this.viewList = new EBAP.Win.ControlLibrary.PGridView();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutFilter = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtScreenName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtScreenId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.txtScreenName);
            this.layoutControl.Controls.Add(this.txtScreenId);
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
            // txtScreenName
            // 
            this.txtScreenName.EditValue = "";
            this.txtScreenName.EnterKeySelectEvent = true;
            this.txtScreenName.LocaleEnumClass = null;
            this.txtScreenName.Location = new System.Drawing.Point(301, 29);
            this.txtScreenName.Name = "txtScreenName";
            this.txtScreenName.ParamName = "@CAPTION";
            this.txtScreenName.Properties.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.txtScreenName.Properties.Appearance.Options.UseFont = true;
            this.txtScreenName.Size = new System.Drawing.Size(198, 20);
            this.txtScreenName.StyleController = this.layoutControl;
            this.txtScreenName.TabIndex = 6;
            // 
            // txtScreenId
            // 
            this.txtScreenId.EditValue = "";
            this.txtScreenId.EnterKeySelectEvent = true;
            this.txtScreenId.LocaleEnumClass = null;
            this.txtScreenId.Location = new System.Drawing.Point(55, 29);
            this.txtScreenId.Name = "txtScreenId";
            this.txtScreenId.ParamName = "@ID";
            this.txtScreenId.Properties.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.txtScreenId.Properties.Appearance.Options.UseFont = true;
            this.txtScreenId.Size = new System.Drawing.Size(198, 20);
            this.txtScreenId.StyleController = this.layoutControl;
            this.txtScreenId.TabIndex = 5;
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
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtScreenId;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(246, 24);
            this.layoutControlItem2.Text = "Id";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(41, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtScreenName;
            this.layoutControlItem3.Location = new System.Drawing.Point(246, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(246, 24);
            this.layoutControlItem3.Text = "Caption";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(41, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(492, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(498, 24);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // PopLanguageMaster
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 566);
            this.Controls.Add(this.layoutControl);
            this.Name = "PopLanguageMaster";
            this.Text = "다국어 정보";
            this.Selection += new System.EventHandler(this.PopLanguageMaster_Selection);
            this.Load += new System.EventHandler(this.PopLanguageMaster_Load);
            this.Controls.SetChildIndex(this.layoutControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtScreenName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtScreenId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
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
        private Win.ControlLibrary.PTextEdit txtScreenName;
        private Win.ControlLibrary.PTextEdit txtScreenId;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlGroup layoutFilter;
    }
}