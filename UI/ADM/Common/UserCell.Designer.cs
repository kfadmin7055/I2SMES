namespace EBAP.UI.ADM.Common
{
    partial class UserCell
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserCell));
            this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtUserName = new EBAP.Win.ControlLibrary.PTextEdit();
            this.txtUserID = new EBAP.Win.ControlLibrary.PTextEdit();
            this.btnSelection = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutFilter = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.btnSave = new EBAP.Win.ControlLibrary.PButton();
            this.cboPlant = new EBAP.Win.ControlLibrary.PComboBoxEdit();
            this.cboVendor = new EBAP.Win.ControlLibrary.PComboBoxEdit();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl.Panel1)).BeginInit();
            this.splitContainerControl.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl.Panel2)).BeginInit();
            this.splitContainerControl.Panel2.SuspendLayout();
            this.splitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlant.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVendor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
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
            this.layoutControl1.Controls.Add(this.txtUserName);
            this.layoutControl1.Controls.Add(this.txtUserID);
            this.layoutControl1.Controls.Add(this.btnSelection);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(260, 738);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtUserName
            // 
            this.txtUserName.AutoSelectLength = 0;
            this.txtUserName.BindingMember = null;
            this.txtUserName.EditValue = "";
            this.txtUserName.EqualControlNextSeq = 0;
            this.txtUserName.EqualTotalControlNextSeq = 0;
            this.txtUserName.LocaleEnumClass = null;
            this.txtUserName.Location = new System.Drawing.Point(67, 54);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ParamName = null;
            this.txtUserName.Properties.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.txtUserName.Properties.Appearance.Options.UseFont = true;
            this.txtUserName.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtUserName.Size = new System.Drawing.Size(184, 20);
            this.txtUserName.StyleController = this.layoutControl1;
            this.txtUserName.TabIndex = 18;
            // 
            // txtUserID
            // 
            this.txtUserID.AutoSelectLength = 0;
            this.txtUserID.BindingMember = null;
            this.txtUserID.EditValue = "";
            this.txtUserID.EqualControlNextSeq = 0;
            this.txtUserID.EqualTotalControlNextSeq = 0;
            this.txtUserID.LocaleEnumClass = null;
            this.txtUserID.Location = new System.Drawing.Point(67, 30);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.ParamName = null;
            this.txtUserID.Properties.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.txtUserID.Properties.Appearance.Options.UseFont = true;
            this.txtUserID.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtUserID.Size = new System.Drawing.Size(184, 20);
            this.txtUserID.StyleController = this.layoutControl1;
            this.txtUserID.TabIndex = 17;
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
            this.layoutControlItem15});
            this.layoutFilter.Location = new System.Drawing.Point(0, 0);
            this.layoutFilter.Name = "layoutFilter";
            this.layoutFilter.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutFilter.Size = new System.Drawing.Size(258, 736);
            this.layoutFilter.Text = "조회 조건";
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 48);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(246, 615);
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
            this.layoutControlItem14.Control = this.txtUserID;
            this.layoutControlItem14.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(246, 24);
            this.layoutControlItem14.Text = "사용자 ID";
            this.layoutControlItem14.TextSize = new System.Drawing.Size(46, 14);
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.txtUserName;
            this.layoutControlItem15.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(246, 24);
            this.layoutControlItem15.Text = "사용자명";
            this.layoutControlItem15.TextSize = new System.Drawing.Size(46, 14);
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.btnSave);
            this.layoutControl2.Controls.Add(this.cboPlant);
            this.layoutControl2.Controls.Add(this.cboVendor);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(0, 0);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup3;
            this.layoutControl2.Size = new System.Drawing.Size(994, 738);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.ImageIndex = 49;
            this.btnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSave.ImageOptions.SvgImage")));
            this.btnSave.LocaleEnumClass = "Save";
            this.btnSave.Location = new System.Drawing.Point(836, 53);
            this.btnSave.Name = "btnSave";
            this.btnSave.SAVELOG = null;
            this.btnSave.Size = new System.Drawing.Size(153, 83);
            this.btnSave.StyleController = this.layoutControl2;
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "저장";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cboPlant
            // 
            this.cboPlant.BindingMember = null;
            this.cboPlant.EditValue = "";
            this.cboPlant.LocaleEnumClass = "Plant";
            this.cboPlant.Location = new System.Drawing.Point(47, 29);
            this.cboPlant.Name = "cboPlant";
            this.cboPlant.ParamName = null;
            this.cboPlant.Properties.Appearance.Options.UseFont = true;
            this.cboPlant.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboPlant.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.cboPlant.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPlant.Properties.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.cboPlant.Properties.NullText = "";
            this.cboPlant.SelectAllItemVisible = false;
            this.cboPlant.Size = new System.Drawing.Size(942, 20);
            this.cboPlant.StyleController = this.layoutControl2;
            this.cboPlant.TabIndex = 5;
            this.cboPlant.EditValueChanged += new System.EventHandler(this.ComboBox_EditValueChanged);
            // 
            // cboVendor
            // 
            this.cboVendor.BindingMember = null;
            this.cboVendor.EditValue = "";
            this.cboVendor.LocaleEnumClass = "Vendor";
            this.cboVendor.Location = new System.Drawing.Point(47, 5);
            this.cboVendor.Name = "cboVendor";
            this.cboVendor.ParamName = null;
            this.cboVendor.Properties.Appearance.Options.UseFont = true;
            this.cboVendor.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboVendor.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.cboVendor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboVendor.Properties.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.cboVendor.Properties.NullText = "";
            this.cboVendor.SelectAllItemVisible = false;
            this.cboVendor.Size = new System.Drawing.Size(942, 20);
            this.cboVendor.StyleController = this.layoutControl2;
            this.cboVendor.TabIndex = 4;
            this.cboVendor.EditValueChanged += new System.EventHandler(this.ComboBox_EditValueChanged);
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup3.GroupBordersVisible = false;
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem2,
            this.layoutControlItem2,
            this.layoutControlItem6,
            this.emptySpaceItem3});
            this.layoutControlGroup3.Name = "Root";
            this.layoutControlGroup3.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlGroup3.Size = new System.Drawing.Size(994, 738);
            this.layoutControlGroup3.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.cboVendor;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(988, 24);
            this.layoutControlItem1.Text = "업체";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(30, 14);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 135);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(988, 597);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.cboPlant;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(988, 24);
            this.layoutControlItem2.Text = "사업장";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(30, 14);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnSave;
            this.layoutControlItem6.Location = new System.Drawing.Point(831, 48);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(33, 26);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(157, 87);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 48);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(831, 87);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // UserCell
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1264, 762);
            this.Controls.Add(this.splitContainerControl);
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("UserCell.IconOptions.SvgImage")));
            this.ISLOADING = true;
            this.Name = "UserCell";
            this.Selection += new System.EventHandler(this.UserCell_Selection);
            this.Reload += new System.EventHandler(this.UserCell_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserCell_FormClosed);
            this.Load += new System.EventHandler(this.UserCell_Load);
            this.Controls.SetChildIndex(this.splitContainerControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl.Panel1)).EndInit();
            this.splitContainerControl.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl.Panel2)).EndInit();
            this.splitContainerControl.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboPlant.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVendor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
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
        private Win.ControlLibrary.PTextEdit txtUserName;
        private Win.ControlLibrary.PTextEdit txtUserID;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private Win.ControlLibrary.PComboBoxEdit cboPlant;
        private Win.ControlLibrary.PComboBoxEdit cboVendor;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private Win.ControlLibrary.PButton btnSave;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
    }
}