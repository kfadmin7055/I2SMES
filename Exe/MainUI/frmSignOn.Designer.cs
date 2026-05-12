namespace EBAP.Exe.MainUI
{
    partial class frmSignOn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSignOn));
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.pLabelEdit4 = new DevExpress.XtraEditors.LabelControl();
            this.chkSaveID = new EBAP.Win.ControlLibrary.PCheckEdit();
            this.lblLogin = new EBAP.Win.ControlLibrary.PLabelEdit();
            this.btnCancel = new EBAP.Win.ControlLibrary.PButton();
            this.btnSignOn = new EBAP.Win.ControlLibrary.PButton();
            this.txtPWD = new EBAP.Win.ControlLibrary.PTextEdit();
            this.txtID = new EBAP.Win.ControlLibrary.PTextEdit();
            this.cboLanguage = new EBAP.Win.ControlLibrary.PComboBoxEdit();
            this.dxValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSaveID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPWD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLanguage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.pLabelEdit4);
            this.groupControl1.Controls.Add(this.chkSaveID);
            this.groupControl1.Controls.Add(this.lblLogin);
            this.groupControl1.Controls.Add(this.btnCancel);
            this.groupControl1.Controls.Add(this.btnSignOn);
            this.groupControl1.Controls.Add(this.txtPWD);
            this.groupControl1.Controls.Add(this.txtID);
            this.groupControl1.Controls.Add(this.cboLanguage);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 33);
            this.groupControl1.LookAndFeel.SkinName = "WXI";
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(480, 367);
            this.groupControl1.TabIndex = 71;
            // 
            // pLabelEdit4
            // 
            this.pLabelEdit4.Appearance.Font = new System.Drawing.Font("나눔고딕", 8F);
            this.pLabelEdit4.Appearance.Options.UseFont = true;
            this.pLabelEdit4.Location = new System.Drawing.Point(216, 370);
            this.pLabelEdit4.Name = "pLabelEdit4";
            this.pLabelEdit4.Size = new System.Drawing.Size(244, 13);
            this.pLabelEdit4.TabIndex = 89;
            this.pLabelEdit4.Text = "© 2013 MSNIB Corporation. All Right reserved.";
            // 
            // chkSaveID
            // 
            this.chkSaveID.BindingMember = null;
            this.chkSaveID.EditValue = true;
            this.chkSaveID.LocaleEnumClass = null;
            this.chkSaveID.Location = new System.Drawing.Point(20, 251);
            this.chkSaveID.Name = "chkSaveID";
            this.chkSaveID.ParamName = null;
            this.chkSaveID.Properties.Appearance.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSaveID.Properties.Appearance.Options.UseFont = true;
            this.chkSaveID.Properties.Caption = "아이디 / 비밀번호 저장";
            this.chkSaveID.Size = new System.Drawing.Size(193, 23);
            this.chkSaveID.TabIndex = 83;
            // 
            // lblLogin
            // 
            this.lblLogin.Appearance.Font = new System.Drawing.Font("나눔고딕", 20.25F);
            this.lblLogin.Appearance.Options.UseFont = true;
            this.lblLogin.BindingMember = null;
            this.lblLogin.EditValue = null;
            this.lblLogin.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLogin.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("lblLogin.ImageOptions.SvgImage")));
            this.lblLogin.LocaleEnumClass = null;
            this.lblLogin.Location = new System.Drawing.Point(12, 27);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(123, 32);
            this.lblLogin.TabIndex = 81;
            this.lblLogin.Text = "      로그인";
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("나눔고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.LocaleEnumClass = null;
            this.btnCancel.Location = new System.Drawing.Point(445, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.SAVELOG = null;
            this.btnCancel.Size = new System.Drawing.Size(30, 30);
            this.btnCancel.TabIndex = 78;
            this.btnCancel.Text = "X";
            // 
            // btnSignOn
            // 
            this.btnSignOn.Appearance.Font = new System.Drawing.Font("나눔고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignOn.Appearance.Options.UseFont = true;
            this.btnSignOn.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSignOn.ImageOptions.SvgImage")));
            this.btnSignOn.ImageOptions.SvgImageSize = new System.Drawing.Size(24, 24);
            this.btnSignOn.LocaleEnumClass = null;
            this.btnSignOn.Location = new System.Drawing.Point(20, 309);
            this.btnSignOn.Name = "btnSignOn";
            this.btnSignOn.SAVELOG = null;
            this.btnSignOn.Size = new System.Drawing.Size(440, 40);
            this.btnSignOn.TabIndex = 77;
            this.btnSignOn.Text = "로그인";
            this.btnSignOn.Click += new System.EventHandler(this.btnSignOn_Click);
            // 
            // txtPWD
            // 
            this.txtPWD.AutoSelectLength = 0;
            this.txtPWD.BindingMember = null;
            this.txtPWD.EditValue = "";
            this.txtPWD.EqualControlNextSeq = 0;
            this.txtPWD.EqualTotalControlNextSeq = 0;
            this.txtPWD.LocaleEnumClass = null;
            this.txtPWD.Location = new System.Drawing.Point(20, 195);
            this.txtPWD.Name = "txtPWD";
            this.txtPWD.ParamName = null;
            this.txtPWD.Properties.AdvancedModeOptions.Label = "비밀번호";
            this.txtPWD.Properties.Appearance.Font = new System.Drawing.Font("나눔고딕", 12.75F);
            this.txtPWD.Properties.Appearance.Options.UseFont = true;
            this.txtPWD.Properties.AutoHeight = false;
            this.txtPWD.Properties.ContextImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("txtPWD.Properties.ContextImageOptions.SvgImage")));
            this.txtPWD.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtPWD.Properties.UseSystemPasswordChar = true;
            this.txtPWD.Size = new System.Drawing.Size(440, 50);
            this.txtPWD.TabIndex = 76;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "비밀번호를 입력하세요.";
            this.dxValidationProvider.SetValidationRule(this.txtPWD, conditionValidationRule1);
            this.txtPWD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPWD_KeyDown);
            this.txtPWD.Validated += new System.EventHandler(this.txtID_Validated);
            // 
            // txtID
            // 
            this.txtID.AutoSelectLength = 0;
            this.txtID.BindingMember = null;
            this.txtID.EditValue = "";
            this.txtID.EqualControlNextSeq = 0;
            this.txtID.EqualTotalControlNextSeq = 0;
            this.txtID.LocaleEnumClass = null;
            this.txtID.Location = new System.Drawing.Point(20, 139);
            this.txtID.Name = "txtID";
            this.txtID.ParamName = null;
            this.txtID.Properties.AdvancedModeOptions.Label = "아이디";
            this.txtID.Properties.Appearance.Font = new System.Drawing.Font("나눔고딕", 12.75F);
            this.txtID.Properties.Appearance.Options.UseFont = true;
            this.txtID.Properties.AutoHeight = false;
            this.txtID.Properties.ContextImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("txtID.Properties.ContextImageOptions.SvgImage")));
            this.txtID.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtID.Size = new System.Drawing.Size(440, 50);
            this.txtID.TabIndex = 75;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "아이디를 입력하세요.";
            this.dxValidationProvider.SetValidationRule(this.txtID, conditionValidationRule2);
            this.txtID.Validated += new System.EventHandler(this.txtID_Validated);
            // 
            // cboLanguage
            // 
            this.cboLanguage.BindingMember = null;
            this.cboLanguage.EditValue = "";
            this.cboLanguage.LocaleEnumClass = null;
            this.cboLanguage.Location = new System.Drawing.Point(20, 83);
            this.cboLanguage.Name = "cboLanguage";
            this.cboLanguage.ParamName = null;
            this.cboLanguage.Properties.Appearance.Font = new System.Drawing.Font("나눔고딕", 12.75F);
            this.cboLanguage.Properties.Appearance.Options.UseFont = true;
            this.cboLanguage.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboLanguage.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.cboLanguage.Properties.AutoHeight = false;
            this.cboLanguage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLanguage.Properties.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.cboLanguage.Properties.NullText = "";
            this.cboLanguage.SelectAllItemVisible = false;
            this.cboLanguage.ShowCodeColumn = false;
            this.cboLanguage.Size = new System.Drawing.Size(440, 50);
            this.cboLanguage.TabIndex = 74;
            // 
            // frmSignOn
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(480, 400);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.ShowIcon = false;
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("frmSignOn.IconOptions.SvgImage")));
            this.ISLOADING = true;
            this.Name = "frmSignOn";
            this.Text = "frmSignin";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmSignOn_Load);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSaveID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPWD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLanguage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private Win.ControlLibrary.PButton btnCancel;
        private Win.ControlLibrary.PButton btnSignOn;
        private Win.ControlLibrary.PTextEdit txtPWD;
        private Win.ControlLibrary.PTextEdit txtID;
        private Win.ControlLibrary.PComboBoxEdit cboLanguage;
        private Win.ControlLibrary.PLabelEdit lblLogin;
        private Win.ControlLibrary.PCheckEdit chkSaveID;
        private DevExpress.XtraEditors.LabelControl pLabelEdit4;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider;
    }
}