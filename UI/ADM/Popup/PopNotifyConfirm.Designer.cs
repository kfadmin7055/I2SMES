namespace EBAP.UI.ADM.Popup
{
    partial class PopNotifyConfirm
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
            this.components = new System.ComponentModel.Container();
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.txtSubject = new EBAP.Win.ControlLibrary.PTextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtContents = new EBAP.Win.ControlLibrary.PMemoEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.chkConfirm = new EBAP.Win.ControlLibrary.PCheckEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnConfirm = new EBAP.Win.ControlLibrary.PButton();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContents.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkConfirm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.btnConfirm);
            this.layoutControl.Controls.Add(this.chkConfirm);
            this.layoutControl.Controls.Add(this.txtContents);
            this.layoutControl.Controls.Add(this.txtSubject);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 31);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.OptionsView.HighlightFocusedItem = true;
            this.layoutControl.Root = this.layoutControlGroup1;
            this.layoutControl.Size = new System.Drawing.Size(1008, 535);
            this.layoutControl.TabIndex = 2;
            this.layoutControl.Text = "layoutControl1";
            // 
            // txtSubject
            // 
            this.txtSubject.AutoSelectLength = 0;
            this.txtSubject.BindingMember = null;
            this.txtSubject.EditValue = "";
            this.txtSubject.EnterKeySelectEvent = true;
            this.txtSubject.EqualControlNextSeq = 0;
            this.txtSubject.EqualTotalControlNextSeq = 0;
            this.txtSubject.LocaleEnumClass = "ID";
            this.txtSubject.Location = new System.Drawing.Point(57, 29);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.ParamName = "@ID";
            this.txtSubject.Properties.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.txtSubject.Properties.Appearance.Options.UseFont = true;
            this.txtSubject.Properties.ReadOnly = true;
            this.txtSubject.Size = new System.Drawing.Size(940, 20);
            this.txtSubject.StyleController = this.layoutControl;
            this.txtSubject.TabIndex = 5;
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
            this.layoutControlGroup2,
            this.layoutControlGroup3});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1008, 535);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlGroup2.Size = new System.Drawing.Size(1002, 54);
            this.layoutControlGroup2.Text = "제목";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtSubject;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(990, 24);
            this.layoutControlItem2.Text = "제목";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(43, 13);
            // 
            // txtContents
            // 
            this.txtContents.BindingMember = null;
            this.txtContents.LocaleEnumClass = null;
            this.txtContents.Location = new System.Drawing.Point(57, 83);
            this.txtContents.Name = "txtContents";
            this.txtContents.ParamName = null;
            this.txtContents.Properties.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.txtContents.Properties.Appearance.Options.UseFont = true;
            this.txtContents.Properties.ReadOnly = true;
            this.txtContents.Size = new System.Drawing.Size(940, 347);
            this.txtContents.StyleController = this.layoutControl;
            this.txtContents.TabIndex = 7;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtContents;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(990, 351);
            this.layoutControlItem4.Text = "공지 내용";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(43, 13);
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.emptySpaceItem1});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 54);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlGroup3.Size = new System.Drawing.Size(1002, 475);
            this.layoutControlGroup3.Text = "공지 내용";
            // 
            // chkConfirm
            // 
            this.chkConfirm.BindingMember = null;
            this.chkConfirm.LocaleEnumClass = null;
            this.chkConfirm.Location = new System.Drawing.Point(513, 434);
            this.chkConfirm.Name = "chkConfirm";
            this.chkConfirm.ParamName = null;
            this.chkConfirm.Properties.Appearance.Font = new System.Drawing.Font("나눔고딕", 14F, System.Drawing.FontStyle.Bold);
            this.chkConfirm.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.chkConfirm.Properties.Appearance.Options.UseFont = true;
            this.chkConfirm.Properties.Appearance.Options.UseForeColor = true;
            this.chkConfirm.Properties.Caption = "이 공지사항을 다시 보지 않습니다.";
            this.chkConfirm.Size = new System.Drawing.Size(317, 25);
            this.chkConfirm.StyleController = this.layoutControl;
            this.chkConfirm.TabIndex = 8;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.chkConfirm;
            this.layoutControlItem1.Location = new System.Drawing.Point(502, 351);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(321, 94);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(321, 94);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(321, 94);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.btnConfirm.Appearance.Options.UseFont = true;
            this.btnConfirm.LocaleEnumClass = null;
            this.btnConfirm.Location = new System.Drawing.Point(834, 434);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.SAVELOG = null;
            this.btnConfirm.Size = new System.Drawing.Size(163, 90);
            this.btnConfirm.StyleController = this.layoutControl;
            this.btnConfirm.TabIndex = 9;
            this.btnConfirm.Text = "확인";
            this.btnConfirm.Click += new System.EventHandler(this.PopNotifyConfirm_Confirm);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnConfirm;
            this.layoutControlItem3.Location = new System.Drawing.Point(823, 351);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(167, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(167, 94);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 351);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(502, 94);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // PopNotifyConfirm
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 566);
            this.Controls.Add(this.layoutControl);
            this.ISLOADING = true;
            this.Name = "PopNotifyConfirm";
            this.Text = "PopNotifyConfirm";
            this.Confirm += new System.EventHandler(this.PopNotifyConfirm_Confirm);
            this.Load += new System.EventHandler(this.PopNotifyConfirm_Load);
            this.Controls.SetChildIndex(this.layoutControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSubject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContents.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkConfirm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private Win.ControlLibrary.PTextEdit txtSubject;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private Win.ControlLibrary.PMemoEdit txtContents;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private Win.ControlLibrary.PCheckEdit chkConfirm;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private Win.ControlLibrary.PButton btnConfirm;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}