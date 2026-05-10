namespace EBAP.UI.ADM.Popup
{
    partial class PopMultiInput
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
            this.gridList = new EBAP.Win.ControlLibrary.PGridControl();
            this.viewList = new EBAP.Win.ControlLibrary.PGridView();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.gridList);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 28);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.OptionsView.HighlightFocusedItem = true;
            this.layoutControl.Root = this.layoutControlGroup1;
            this.layoutControl.Size = new System.Drawing.Size(527, 538);
            this.layoutControl.TabIndex = 2;
            this.layoutControl.Text = "layoutControl1";
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
            this.gridList.Location = new System.Drawing.Point(5, 5);
            this.gridList.MainView = this.viewList;
            this.gridList.Name = "gridList";
            this.gridList.Size = new System.Drawing.Size(517, 528);
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
            this.viewList.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.viewList.OptionsClipboard.PasteMode = DevExpress.Export.PasteMode.Update;
            this.viewList.OptionsSelection.MultiSelect = true;
            this.viewList.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.viewList.OptionsView.ColumnAutoWidth = false;
            this.viewList.OptionsView.ShowGroupPanel = false;
            this.viewList.RowHeight = 29;
            this.viewList.ViewCaptionHeight = 25;
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
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlGroup1.Size = new System.Drawing.Size(527, 538);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridList;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(521, 532);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // PopMultiInput
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 566);
            this.Controls.Add(this.layoutControl);
            this.Name = "PopMultiInput";
            this.Text = "PopMultiInput";
            this.New += new System.EventHandler(this.PopMultiInput_New);
            this.Selection += new System.EventHandler(this.PopMultiInput_Selection);
            this.Confirm += new System.EventHandler(this.PopMultiInput_Confirm);
            this.Load += new System.EventHandler(this.PopMultiInput_Load);
            this.Controls.SetChildIndex(this.layoutControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private Win.ControlLibrary.PGridControl gridList;
        private Win.ControlLibrary.PGridView viewList;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}