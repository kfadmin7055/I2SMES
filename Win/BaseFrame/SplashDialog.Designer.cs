namespace EBAP.Win.BaseFrame
{
    partial class SplashDialog
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.progressPanel1 = new DevExpress.XtraWaitForm.ProgressPanel();
            this.pLabelEdit4 = new DevExpress.XtraEditors.LabelControl();
            this.marqueeProgressBarControl1 = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.progressPanel1);
            this.groupControl1.Controls.Add(this.pLabelEdit4);
            this.groupControl1.Controls.Add(this.marqueeProgressBarControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.LookAndFeel.SkinName = "WXI";
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(450, 280);
            this.groupControl1.TabIndex = 46;
            // 
            // progressPanel1
            // 
            this.progressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanel1.Appearance.Font = new System.Drawing.Font("나눔고딕", 10F);
            this.progressPanel1.Appearance.Options.UseBackColor = true;
            this.progressPanel1.Appearance.Options.UseFont = true;
            this.progressPanel1.AppearanceCaption.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.progressPanel1.AppearanceCaption.Options.UseFont = true;
            this.progressPanel1.BarAnimationMotionType = DevExpress.Utils.Animation.MotionType.WithAcceleration;
            this.progressPanel1.Caption = "컨텐츠 Load 중...";
            this.progressPanel1.CaptionToDescriptionDistance = 5;
            this.progressPanel1.Description = "잠시만 기다려 주세요.";
            this.progressPanel1.ImageHorzOffset = 10;
            this.progressPanel1.Location = new System.Drawing.Point(12, 67);
            this.progressPanel1.Name = "progressPanel1";
            this.progressPanel1.Size = new System.Drawing.Size(426, 66);
            this.progressPanel1.TabIndex = 60;
            // 
            // pLabelEdit4
            // 
            this.pLabelEdit4.Appearance.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.pLabelEdit4.Appearance.Options.UseFont = true;
            this.pLabelEdit4.Location = new System.Drawing.Point(181, 254);
            this.pLabelEdit4.Name = "pLabelEdit4";
            this.pLabelEdit4.Size = new System.Drawing.Size(257, 14);
            this.pLabelEdit4.TabIndex = 54;
            this.pLabelEdit4.Text = "© 2013 MSNIB Corporation. All Right reserved.";
            // 
            // marqueeProgressBarControl1
            // 
            this.marqueeProgressBarControl1.EditValue = 0;
            this.marqueeProgressBarControl1.Location = new System.Drawing.Point(12, 139);
            this.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1";
            this.marqueeProgressBarControl1.Size = new System.Drawing.Size(426, 10);
            this.marqueeProgressBarControl1.TabIndex = 49;
            // 
            // SplashDialog
            // 
            this.AllowControlsInImageMode = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(450, 280);
            this.Controls.Add(this.groupControl1);
            this.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.Name = "SplashDialog";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.MarqueeProgressBarControl marqueeProgressBarControl1;
        private DevExpress.XtraEditors.LabelControl pLabelEdit4;
        private DevExpress.XtraWaitForm.ProgressPanel progressPanel1;
    }
}
