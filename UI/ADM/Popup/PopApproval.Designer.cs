namespace EBAP.UI.ADM.Popup
{
    partial class PopApproval
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.txtUserName = new EBAP.Win.ControlLibrary.PButtonEdit();
            this.rgLine = new EBAP.Win.ControlLibrary.PRadioGroup();
            this.txtContents = new EBAP.Win.ControlLibrary.PHtmlEditControl();
            this.gridLine = new EBAP.Win.ControlLibrary.PGridControl();
            this.viewLine = new EBAP.Win.ControlLibrary.PGridView();
            this.btnSearch = new EBAP.Win.ControlLibrary.PButton();
            this.btnDelete = new EBAP.Win.ControlLibrary.PButton();
            this.btnDown = new EBAP.Win.ControlLibrary.PButton();
            this.btnUp = new EBAP.Win.ControlLibrary.PButton();
            this.txtSubject = new EBAP.Win.ControlLibrary.PTextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgLine.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.txtUserName);
            this.layoutControl.Controls.Add(this.rgLine);
            this.layoutControl.Controls.Add(this.txtContents);
            this.layoutControl.Controls.Add(this.gridLine);
            this.layoutControl.Controls.Add(this.btnSearch);
            this.layoutControl.Controls.Add(this.btnDelete);
            this.layoutControl.Controls.Add(this.btnDown);
            this.layoutControl.Controls.Add(this.btnUp);
            this.layoutControl.Controls.Add(this.txtSubject);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Font = new System.Drawing.Font("나눔고딕", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControl.Location = new System.Drawing.Point(0, 31);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.OptionsView.HighlightFocusedItem = true;
            this.layoutControl.Root = this.layoutControlGroup1;
            this.layoutControl.Size = new System.Drawing.Size(1274, 741);
            this.layoutControl.TabIndex = 1;
            // 
            // txtUserName
            // 
            this.txtUserName.EditValue = "";
            this.txtUserName.EnterKeyClickEvent = true;
            this.txtUserName.LocaleEnumClass = null;
            this.txtUserName.Location = new System.Drawing.Point(388, 40);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ParamName = null;
            this.txtUserName.Properties.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.txtUserName.Properties.Appearance.Options.UseFont = true;
            this.txtUserName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.txtUserName.PairButtonEdit = null;
            this.txtUserName.Size = new System.Drawing.Size(706, 22);
            this.txtUserName.StyleController = this.layoutControl;
            this.txtUserName.TabIndex = 24;
            this.txtUserName.ViewDeleteButton = false;
            this.txtUserName.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtUserName_ButtonClick);
            // 
            // rgLine
            // 
            this.rgLine.LocaleEnumClass = null;
            this.rgLine.Location = new System.Drawing.Point(79, 40);
            this.rgLine.Name = "rgLine";
            this.rgLine.ParamName = null;
            this.rgLine.Properties.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.rgLine.Properties.Appearance.Options.UseFont = true;
            this.rgLine.SelectAllItemVisible = false;
            this.rgLine.Size = new System.Drawing.Size(305, 22);
            this.rgLine.StyleController = this.layoutControl;
            this.rgLine.TabIndex = 23;
            // 
            // txtContents
            // 
            this.txtContents.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft;
            this.txtContents.Appearance.Text.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.txtContents.Appearance.Text.Options.UseFont = true;
            this.txtContents.Location = new System.Drawing.Point(79, 281);
            this.txtContents.Name = "txtContents";
            this.txtContents.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            this.txtContents.Options.VerticalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            this.txtContents.ParamName = null;
            this.txtContents.Size = new System.Drawing.Size(1183, 448);
            this.txtContents.TabIndex = 21;
            // 
            // gridLine
            // 
            this.gridLine.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gridLine.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridLine.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridLine.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridLine.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gridLine.Location = new System.Drawing.Point(79, 66);
            this.gridLine.MainView = this.viewLine;
            this.gridLine.Name = "gridLine";
            this.gridLine.Size = new System.Drawing.Size(1015, 211);
            this.gridLine.TabIndex = 20;
            this.gridLine.UseEmbeddedNavigator = true;
            this.gridLine.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewLine});
            // 
            // viewLine
            // 
            this.viewLine.Appearance.FilterPanel.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.viewLine.Appearance.FilterPanel.Options.UseFont = true;
            this.viewLine.Appearance.FooterPanel.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.viewLine.Appearance.FooterPanel.Options.UseFont = true;
            this.viewLine.Appearance.GroupButton.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.viewLine.Appearance.GroupButton.Options.UseFont = true;
            this.viewLine.Appearance.GroupPanel.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.viewLine.Appearance.GroupPanel.Options.UseFont = true;
            this.viewLine.Appearance.GroupRow.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.viewLine.Appearance.GroupRow.Options.UseFont = true;
            this.viewLine.Appearance.HeaderPanel.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.viewLine.Appearance.HeaderPanel.Options.UseFont = true;
            this.viewLine.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.viewLine.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.viewLine.Appearance.Row.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.viewLine.Appearance.Row.Options.UseFont = true;
            this.viewLine.Appearance.TopNewRow.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.viewLine.Appearance.TopNewRow.Options.UseFont = true;
            this.viewLine.Appearance.ViewCaption.Font = new System.Drawing.Font("나눔고딕", 8.75F, System.Drawing.FontStyle.Bold);
            this.viewLine.Appearance.ViewCaption.Options.UseFont = true;
            this.viewLine.Appearance.ViewCaption.Options.UseTextOptions = true;
            this.viewLine.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.viewLine.ColumnPanelRowHeight = 30;
            this.viewLine.GridControl = this.gridLine;
            this.viewLine.KeyColumns = null;
            this.viewLine.MandatoryColumns = null;
            this.viewLine.Name = "viewLine";
            this.viewLine.NewRowCopyColumns = null;
            this.viewLine.NewRowEnableColumns = null;
            this.viewLine.OptionsBehavior.AutoExpandAllGroups = true;
            this.viewLine.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.viewLine.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.viewLine.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.viewLine.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.viewLine.OptionsView.ColumnAutoWidth = false;
            this.viewLine.OptionsView.ShowGroupPanel = false;
            this.viewLine.RowHeight = 29;
            this.viewLine.ViewCaptionHeight = 25;
            this.viewLine.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.viewLine_ShowingEditor);
            this.viewLine.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.viewLine_ValidatingEditor);
            // 
            // btnSearch
            // 
            this.btnSearch.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.ImageIndex = 13;
            this.btnSearch.LocaleEnumClass = "Search";
            this.btnSearch.Location = new System.Drawing.Point(1098, 40);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.SAVELOG = null;
            this.btnSearch.Size = new System.Drawing.Size(164, 22);
            this.btnSearch.StyleController = this.layoutControl;
            this.btnSearch.TabIndex = 19;
            this.btnSearch.Text = "검색";
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.ImageIndex = 6;
            this.btnDelete.LocaleEnumClass = "Delete";
            this.btnDelete.Location = new System.Drawing.Point(1098, 255);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.SAVELOG = null;
            this.btnDelete.Size = new System.Drawing.Size(164, 22);
            this.btnDelete.StyleController = this.layoutControl;
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Text = "삭제";
            this.btnDelete.Click += new System.EventHandler(this.btnApproval_Click);
            // 
            // btnDown
            // 
            this.btnDown.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.btnDown.Appearance.Options.UseFont = true;
            this.btnDown.ImageIndex = 35;
            this.btnDown.LocaleEnumClass = null;
            this.btnDown.Location = new System.Drawing.Point(1098, 229);
            this.btnDown.Name = "btnDown";
            this.btnDown.SAVELOG = null;
            this.btnDown.Size = new System.Drawing.Size(164, 22);
            this.btnDown.StyleController = this.layoutControl;
            this.btnDown.TabIndex = 17;
            this.btnDown.Text = "Down";
            this.btnDown.Click += new System.EventHandler(this.btnApproval_Click);
            // 
            // btnUp
            // 
            this.btnUp.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.btnUp.Appearance.Options.UseFont = true;
            this.btnUp.ImageIndex = 36;
            this.btnUp.LocaleEnumClass = null;
            this.btnUp.Location = new System.Drawing.Point(1098, 203);
            this.btnUp.Name = "btnUp";
            this.btnUp.SAVELOG = null;
            this.btnUp.Size = new System.Drawing.Size(164, 22);
            this.btnUp.StyleController = this.layoutControl;
            this.btnUp.TabIndex = 16;
            this.btnUp.Text = "Up";
            this.btnUp.Click += new System.EventHandler(this.btnApproval_Click);
            // 
            // txtSubject
            // 
            this.txtSubject.EditValue = "";
            this.txtSubject.LocaleEnumClass = null;
            this.txtSubject.Location = new System.Drawing.Point(79, 12);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.ParamName = null;
            this.txtSubject.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubject.Properties.Appearance.Options.UseFont = true;
            this.txtSubject.Size = new System.Drawing.Size(1183, 24);
            this.txtSubject.StyleController = this.layoutControl;
            this.txtSubject.TabIndex = 7;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AppearanceGroup.Font = new System.Drawing.Font("나눔고딕", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlGroup1.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup1.AppearanceItemCaption.Font = new System.Drawing.Font("나눔고딕", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlGroup1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlGroup1.AppearanceTabPage.Header.Font = new System.Drawing.Font("나눔고딕", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlGroup1.AppearanceTabPage.Header.Options.UseFont = true;
            this.layoutControlGroup1.AppearanceTabPage.HeaderActive.Font = new System.Drawing.Font("나눔고딕", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlGroup1.AppearanceTabPage.HeaderActive.Options.UseFont = true;
            this.layoutControlGroup1.AppearanceTabPage.HeaderDisabled.Font = new System.Drawing.Font("나눔고딕", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlGroup1.AppearanceTabPage.HeaderDisabled.Options.UseFont = true;
            this.layoutControlGroup1.AppearanceTabPage.HeaderHotTracked.Font = new System.Drawing.Font("나눔고딕", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlGroup1.AppearanceTabPage.HeaderHotTracked.Options.UseFont = true;
            this.layoutControlGroup1.AppearanceTabPage.PageClient.Font = new System.Drawing.Font("나눔고딕", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlGroup1.AppearanceTabPage.PageClient.Options.UseFont = true;
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem11,
            this.layoutControlItem12,
            this.layoutControlItem7,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem8,
            this.layoutControlItem5,
            this.layoutControlItem6});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1274, 741);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtSubject;
            this.layoutControlItem1.CustomizationFormText = "제 목";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1254, 28);
            this.layoutControlItem1.Text = "제 목";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(64, 15);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(1086, 54);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(168, 137);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.btnUp;
            this.layoutControlItem11.Location = new System.Drawing.Point(1086, 191);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(168, 26);
            this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem11.TextVisible = false;
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.btnDown;
            this.layoutControlItem12.Location = new System.Drawing.Point(1086, 217);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(168, 26);
            this.layoutControlItem12.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem12.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnDelete;
            this.layoutControlItem7.Location = new System.Drawing.Point(1086, 243);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(168, 26);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridLine;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 54);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1086, 215);
            this.layoutControlItem2.Text = "결재 경로";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(64, 15);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtContents;
            this.layoutControlItem4.CustomizationFormText = "메일 본문";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 269);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(1254, 452);
            this.layoutControlItem4.Text = "메일 본문";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(64, 15);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnSearch;
            this.layoutControlItem8.Location = new System.Drawing.Point(1086, 28);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(168, 26);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.rgLine;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 28);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(376, 26);
            this.layoutControlItem5.Text = "결재자 추가";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(64, 15);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtUserName;
            this.layoutControlItem6.Location = new System.Drawing.Point(376, 28);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(710, 26);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // PopApproval
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(1274, 772);
            this.Controls.Add(this.layoutControl);
            this.Name = "PopApproval";
            this.Text = "PopApproval";
            this.Confirm += new System.EventHandler(this.PopApproval_Confirm);
            this.Load += new System.EventHandler(this.PopApproval_Load);
            this.Controls.SetChildIndex(this.layoutControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgLine.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private Win.ControlLibrary.PTextEdit txtSubject;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private Win.ControlLibrary.PButton btnDown;
        private Win.ControlLibrary.PButton btnUp;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private Win.ControlLibrary.PButton btnSearch;
        private Win.ControlLibrary.PButton btnDelete;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private Win.ControlLibrary.PGridControl gridLine;
        private Win.ControlLibrary.PGridView viewLine;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private Win.ControlLibrary.PHtmlEditControl txtContents;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private Win.ControlLibrary.PRadioGroup rgLine;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private Win.ControlLibrary.PButtonEdit txtUserName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}