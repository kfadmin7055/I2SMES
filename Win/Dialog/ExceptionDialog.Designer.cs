namespace EBAP.Win.Dialog
{
    partial class ExceptionDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExceptionDialog));
            this.picException = new DevExpress.XtraEditors.PictureEdit();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnResize = new DevExpress.XtraEditors.SimpleButton();
            this.btnReport = new DevExpress.XtraEditors.SimpleButton();
            this.btnCopy = new DevExpress.XtraEditors.SimpleButton();
            this.txtDetail = new DevExpress.XtraEditors.MemoEdit();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnDetail = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtDesc = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.picException.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDetail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // picException
            // 
            this.picException.EditValue = ((object)(resources.GetObject("picException.EditValue")));
            this.picException.Location = new System.Drawing.Point(12, 12);
            this.picException.Name = "picException";
            this.picException.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picException.Properties.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.picException.Properties.Appearance.Options.UseBackColor = true;
            this.picException.Properties.Appearance.Options.UseFont = true;
            this.picException.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picException.Properties.ShowMenu = false;
            this.picException.Size = new System.Drawing.Size(100, 132);
            this.picException.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.Location = new System.Drawing.Point(494, 531);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.TabIndex = 15;
            this.btnExit.Text = "종료";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnResize
            // 
            this.btnResize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResize.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.btnResize.Appearance.Options.UseFont = true;
            this.btnResize.Location = new System.Drawing.Point(575, 531);
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(75, 25);
            this.btnResize.TabIndex = 14;
            this.btnResize.Text = "크게";
            this.btnResize.Click += new System.EventHandler(this.btnResize_Click);
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReport.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.btnReport.Appearance.Options.UseFont = true;
            this.btnReport.Location = new System.Drawing.Point(12, 531);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(132, 25);
            this.btnReport.TabIndex = 13;
            this.btnReport.Text = "서버로 전송(DB 저장)";
            this.btnReport.Visible = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.btnCopy.Appearance.Options.UseFont = true;
            this.btnCopy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCopy.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCopy.ImageOptions.SvgImage")));
            this.btnCopy.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnCopy.Location = new System.Drawing.Point(656, 531);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(129, 25);
            this.btnCopy.TabIndex = 12;
            this.btnCopy.Text = "클립보드에 복사";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // txtDetail
            // 
            this.txtDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDetail.EditValue = "";
            this.txtDetail.Location = new System.Drawing.Point(11, 181);
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.Properties.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.txtDetail.Properties.Appearance.Options.UseFont = true;
            this.txtDetail.Properties.ReadOnly = true;
            this.txtDetail.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDetail.Properties.WordWrap = false;
            this.txtDetail.Size = new System.Drawing.Size(774, 344);
            this.txtDetail.TabIndex = 18;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnOK.ImageOptions.SvgImage")));
            this.btnOK.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnOK.Location = new System.Drawing.Point(691, 150);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(95, 25);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "확인";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnDetail
            // 
            this.btnDetail.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.btnDetail.Appearance.Options.UseFont = true;
            this.btnDetail.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDetail.ImageOptions.SvgImage")));
            this.btnDetail.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnDetail.Location = new System.Drawing.Point(12, 150);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(95, 25);
            this.btnDetail.TabIndex = 11;
            this.btnDetail.Text = "자세히 >>";
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(117, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(541, 56);
            this.labelControl1.TabIndex = 17;
            this.labelControl1.Text = "프로그램에서 예상하지 못한 오류가 발생하였습니다.\r\n오류 메시지는 다음과 같습니다.";
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.EditValue = "";
            this.txtDesc.Location = new System.Drawing.Point(117, 44);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Properties.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.txtDesc.Properties.Appearance.Options.UseFont = true;
            this.txtDesc.Properties.ReadOnly = true;
            this.txtDesc.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDesc.Size = new System.Drawing.Size(668, 100);
            this.txtDesc.TabIndex = 16;
            // 
            // ExceptionDialog
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(798, 568);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnResize);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.txtDetail);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnDetail);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.picException);
            this.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ExceptionDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "예외발생";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmException_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picException.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDetail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit picException;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnResize;
        private DevExpress.XtraEditors.SimpleButton btnReport;
        private DevExpress.XtraEditors.SimpleButton btnCopy;
        private DevExpress.XtraEditors.MemoEdit txtDetail;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnDetail;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit txtDesc;
    }
}