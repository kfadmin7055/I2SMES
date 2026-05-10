namespace EBAP.UI.ADM.Management
{
    partial class DBManagement
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
            this.cboDatabase = new EBAP.Win.ControlLibrary.PComboBoxEdit();
            this.cboServer = new EBAP.Win.ControlLibrary.PComboBoxEdit();
            this.btnSelection = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutFilter = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.btnRestore = new EBAP.Win.ControlLibrary.PButton();
            this.btnBackup = new EBAP.Win.ControlLibrary.PButton();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem25 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem26 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem27 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDatabase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).BeginInit();
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
            this.splitContainerControl.Location = new System.Drawing.Point(0, 28);
            this.splitContainerControl.Name = "splitContainerControl";
            this.splitContainerControl.Panel1.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.splitContainerControl.Panel1.Appearance.Options.UseFont = true;
            this.splitContainerControl.Panel1.Controls.Add(this.layoutControl1);
            this.splitContainerControl.Panel1.Text = "Panel1";
            this.splitContainerControl.Panel2.Controls.Add(this.layoutControl2);
            this.splitContainerControl.Panel2.Text = "Panel2";
            this.splitContainerControl.ShowCaption = true;
            this.splitContainerControl.Size = new System.Drawing.Size(1264, 734);
            this.splitContainerControl.SplitterPosition = 260;
            this.splitContainerControl.TabIndex = 4;
            this.splitContainerControl.Text = "splitContainerControl1";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.cboDatabase);
            this.layoutControl1.Controls.Add(this.cboServer);
            this.layoutControl1.Controls.Add(this.btnSelection);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(302, 734);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // cboDatabase
            // 
            this.cboDatabase.EditValue = "";
            this.cboDatabase.LocaleEnumClass = null;
            this.cboDatabase.Location = new System.Drawing.Point(62, 58);
            this.cboDatabase.Name = "cboDatabase";
            this.cboDatabase.ParamName = null;
            this.cboDatabase.Properties.Appearance.Options.UseFont = true;
            this.cboDatabase.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboDatabase.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.cboDatabase.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDatabase.Properties.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.cboDatabase.Properties.NullText = "";
            this.cboDatabase.SelectAllItemVisible = false;
            this.cboDatabase.Size = new System.Drawing.Size(231, 20);
            this.cboDatabase.StyleController = this.layoutControl1;
            this.cboDatabase.TabIndex = 13;
            // 
            // cboServer
            // 
            this.cboServer.EditValue = "";
            this.cboServer.LocaleEnumClass = null;
            this.cboServer.Location = new System.Drawing.Point(62, 34);
            this.cboServer.Name = "cboServer";
            this.cboServer.ParamName = null;
            this.cboServer.Properties.Appearance.Options.UseFont = true;
            this.cboServer.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboServer.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.cboServer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboServer.Properties.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.cboServer.Properties.NullText = "";
            this.cboServer.SelectAllItemVisible = false;
            this.cboServer.Size = new System.Drawing.Size(231, 20);
            this.cboServer.StyleController = this.layoutControl1;
            this.cboServer.TabIndex = 7;
            this.cboServer.EditValueChanged += new System.EventHandler(this.ComboBox_EditValueChanged);
            // 
            // btnSelection
            // 
            this.btnSelection.Appearance.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.btnSelection.Appearance.Options.UseFont = true;
            this.btnSelection.ImageOptions.ImageUri.Uri = "Find;GrayScaled";
            this.btnSelection.Location = new System.Drawing.Point(9, 689);
            this.btnSelection.Name = "btnSelection";
            this.btnSelection.Size = new System.Drawing.Size(284, 36);
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(302, 734);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutFilter
            // 
            this.layoutFilter.AppearanceGroup.Font = new System.Drawing.Font("나눔고딕", 10F, System.Drawing.FontStyle.Bold);
            this.layoutFilter.AppearanceGroup.Options.UseFont = true;
            this.layoutFilter.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlItem7,
            this.layoutControlItem1,
            this.layoutControlItem9});
            this.layoutFilter.Location = new System.Drawing.Point(0, 0);
            this.layoutFilter.Name = "layoutFilter";
            this.layoutFilter.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutFilter.Size = new System.Drawing.Size(300, 732);
            this.layoutFilter.Text = "조회 조건";
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 48);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(288, 607);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnSelection;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 655);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(288, 40);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.cboServer;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(288, 24);
            this.layoutControlItem1.Text = "Server";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(50, 14);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.cboDatabase;
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(288, 24);
            this.layoutControlItem9.Text = "Database";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(50, 14);
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.layoutControl);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(0, 0);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup3;
            this.layoutControl2.Size = new System.Drawing.Size(952, 734);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup3.GroupBordersVisible = false;
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem27});
            this.layoutControlGroup3.Name = "Root";
            this.layoutControlGroup3.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlGroup3.Size = new System.Drawing.Size(952, 734);
            this.layoutControlGroup3.TextVisible = false;
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.btnRestore);
            this.layoutControl.Controls.Add(this.btnBackup);
            this.layoutControl.Location = new System.Drawing.Point(5, 5);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.OptionsView.HighlightFocusedItem = true;
            this.layoutControl.Root = this.layoutControlGroup4;
            this.layoutControl.Size = new System.Drawing.Size(942, 724);
            this.layoutControl.TabIndex = 4;
            this.layoutControl.Text = "layoutControl1";
            // 
            // btnRestore
            // 
            this.btnRestore.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.btnRestore.Appearance.Options.UseFont = true;
            this.btnRestore.ImageOptions.ImageIndex = 44;
            this.btnRestore.IsPopup = true;
            this.btnRestore.LocaleEnumClass = null;
            this.btnRestore.Location = new System.Drawing.Point(87, 3);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.SAVELOG = null;
            this.btnRestore.Size = new System.Drawing.Size(79, 22);
            this.btnRestore.StyleController = this.layoutControl;
            this.btnRestore.TabIndex = 9;
            this.btnRestore.Text = "복원";
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.btnBackup.Appearance.Options.UseFont = true;
            this.btnBackup.ImageOptions.ImageIndex = 5;
            this.btnBackup.IsPopup = true;
            this.btnBackup.LocaleEnumClass = null;
            this.btnBackup.Location = new System.Drawing.Point(3, 3);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.SAVELOG = null;
            this.btnBackup.Size = new System.Drawing.Size(80, 22);
            this.btnBackup.StyleController = this.layoutControl;
            this.btnBackup.TabIndex = 8;
            this.btnBackup.Text = "백업";
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
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
            this.emptySpaceItem3,
            this.layoutControlItem25,
            this.layoutControlItem26,
            this.emptySpaceItem4});
            this.layoutControlGroup4.Name = "layoutControlGroup1";
            this.layoutControlGroup4.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlGroup4.Size = new System.Drawing.Size(942, 724);
            this.layoutControlGroup4.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(167, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem2";
            this.emptySpaceItem3.Size = new System.Drawing.Size(773, 26);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem25
            // 
            this.layoutControlItem25.Control = this.btnBackup;
            this.layoutControlItem25.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem25.Name = "layoutControlItem4";
            this.layoutControlItem25.Size = new System.Drawing.Size(84, 26);
            this.layoutControlItem25.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem25.TextVisible = false;
            // 
            // layoutControlItem26
            // 
            this.layoutControlItem26.Control = this.btnRestore;
            this.layoutControlItem26.Location = new System.Drawing.Point(84, 0);
            this.layoutControlItem26.Name = "layoutControlItem5";
            this.layoutControlItem26.Size = new System.Drawing.Size(83, 26);
            this.layoutControlItem26.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem26.TextVisible = false;
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(0, 26);
            this.emptySpaceItem4.Name = "emptySpaceItem3";
            this.emptySpaceItem4.Size = new System.Drawing.Size(940, 696);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem27
            // 
            this.layoutControlItem27.Control = this.layoutControl;
            this.layoutControlItem27.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem27.Name = "layoutControlItem27";
            this.layoutControlItem27.Size = new System.Drawing.Size(946, 728);
            this.layoutControlItem27.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem27.TextVisible = false;
            // 
            // DBManagement
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1264, 762);
            this.Controls.Add(this.splitContainerControl);
            this.Name = "DBManagement";
            this.Reload += new System.EventHandler(this.DBManagement_Load);
            this.Load += new System.EventHandler(this.DBManagement_Load);
            this.Controls.SetChildIndex(this.splitContainerControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboDatabase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).EndInit();
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
        private Win.ControlLibrary.PComboBoxEdit cboDatabase;
        private Win.ControlLibrary.PComboBoxEdit cboServer;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private Win.ControlLibrary.PButton btnRestore;
        private Win.ControlLibrary.PButton btnBackup;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem25;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem26;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem27;


    }
}
