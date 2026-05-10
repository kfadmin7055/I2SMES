namespace EBAP.Exe.AutoUpdater
{
    partial class Download
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Download));
            this.pbTotal = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.lblIP = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pbCurrent = new System.Windows.Forms.ProgressBar();
            this.lblTotFile = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCurFile = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTotPercent = new System.Windows.Forms.Label();
            this.lblTotBytes = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblCurBytes = new System.Windows.Forms.Label();
            this.lblCurrentName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pbTotal
            // 
            this.pbTotal.ForeColor = System.Drawing.Color.Black;
            this.pbTotal.Location = new System.Drawing.Point(12, 182);
            this.pbTotal.Name = "pbTotal";
            this.pbTotal.Size = new System.Drawing.Size(434, 17);
            this.pbTotal.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("나눔고딕", 15F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(130, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 23);
            this.label1.TabIndex = 39;
            this.label1.Text = "컨텐츠 업데이트 중 입니다.";
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.BackColor = System.Drawing.Color.Transparent;
            this.lblIP.Font = new System.Drawing.Font("나눔고딕", 8.25F);
            this.lblIP.ForeColor = System.Drawing.Color.Black;
            this.lblIP.Location = new System.Drawing.Point(12, 309);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(29, 13);
            this.lblIP.TabIndex = 42;
            this.lblIP.Text = "lblIP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("나눔고딕", 8.25F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(9, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "전체 진행";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("나눔고딕", 8.25F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(9, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "현재 업데이트 진행";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbCurrent
            // 
            this.pbCurrent.ForeColor = System.Drawing.Color.Black;
            this.pbCurrent.Location = new System.Drawing.Point(12, 244);
            this.pbCurrent.Name = "pbCurrent";
            this.pbCurrent.Size = new System.Drawing.Size(434, 17);
            this.pbCurrent.TabIndex = 44;
            this.pbCurrent.Value = 50;
            // 
            // lblTotFile
            // 
            this.lblTotFile.BackColor = System.Drawing.Color.Transparent;
            this.lblTotFile.Font = new System.Drawing.Font("나눔고딕", 8.25F);
            this.lblTotFile.ForeColor = System.Drawing.Color.Black;
            this.lblTotFile.Location = new System.Drawing.Point(133, 164);
            this.lblTotFile.Name = "lblTotFile";
            this.lblTotFile.Size = new System.Drawing.Size(30, 13);
            this.lblTotFile.TabIndex = 48;
            this.lblTotFile.Text = "0";
            this.lblTotFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("나눔고딕", 8.25F);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(116, 164);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 13);
            this.label8.TabIndex = 47;
            this.label8.Text = "/";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCurFile
            // 
            this.lblCurFile.BackColor = System.Drawing.Color.Transparent;
            this.lblCurFile.Font = new System.Drawing.Font("나눔고딕", 8.25F);
            this.lblCurFile.ForeColor = System.Drawing.Color.Black;
            this.lblCurFile.Location = new System.Drawing.Point(80, 164);
            this.lblCurFile.Name = "lblCurFile";
            this.lblCurFile.Size = new System.Drawing.Size(30, 13);
            this.lblCurFile.TabIndex = 46;
            this.lblCurFile.Text = "0";
            this.lblCurFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("나눔고딕", 8.25F);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(397, 164);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 54;
            this.label10.Text = "% 진행)";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotPercent
            // 
            this.lblTotPercent.BackColor = System.Drawing.Color.Transparent;
            this.lblTotPercent.Font = new System.Drawing.Font("나눔고딕", 8.25F);
            this.lblTotPercent.ForeColor = System.Drawing.Color.Black;
            this.lblTotPercent.Location = new System.Drawing.Point(370, 164);
            this.lblTotPercent.Name = "lblTotPercent";
            this.lblTotPercent.Size = new System.Drawing.Size(30, 13);
            this.lblTotPercent.TabIndex = 53;
            this.lblTotPercent.Text = "100";
            this.lblTotPercent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotBytes
            // 
            this.lblTotBytes.BackColor = System.Drawing.Color.Transparent;
            this.lblTotBytes.Font = new System.Drawing.Font("나눔고딕", 8.25F);
            this.lblTotBytes.ForeColor = System.Drawing.Color.Black;
            this.lblTotBytes.Location = new System.Drawing.Point(228, 164);
            this.lblTotBytes.Name = "lblTotBytes";
            this.lblTotBytes.Size = new System.Drawing.Size(100, 13);
            this.lblTotBytes.TabIndex = 52;
            this.lblTotBytes.Text = "0";
            this.lblTotBytes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("나눔고딕", 8.25F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(326, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 51;
            this.label4.Text = "bytes (";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("나눔고딕", 8.25F);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(407, 226);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 56;
            this.label9.Text = "bytes";
            // 
            // lblCurBytes
            // 
            this.lblCurBytes.BackColor = System.Drawing.Color.Transparent;
            this.lblCurBytes.Font = new System.Drawing.Font("나눔고딕", 8.25F);
            this.lblCurBytes.ForeColor = System.Drawing.Color.Black;
            this.lblCurBytes.Location = new System.Drawing.Point(309, 226);
            this.lblCurBytes.Name = "lblCurBytes";
            this.lblCurBytes.Size = new System.Drawing.Size(100, 13);
            this.lblCurBytes.TabIndex = 55;
            this.lblCurBytes.Text = "0";
            this.lblCurBytes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCurrentName
            // 
            this.lblCurrentName.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentName.Font = new System.Drawing.Font("나눔고딕", 8.25F);
            this.lblCurrentName.ForeColor = System.Drawing.Color.Black;
            this.lblCurrentName.Location = new System.Drawing.Point(108, 226);
            this.lblCurrentName.Name = "lblCurrentName";
            this.lblCurrentName.Size = new System.Drawing.Size(195, 13);
            this.lblCurrentName.TabIndex = 57;
            this.lblCurrentName.Text = "0";
            this.lblCurrentName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 75);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(111, 42);
            this.pictureBox1.TabIndex = 58;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("나눔고딕", 8.25F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(195, 296);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(251, 26);
            this.label5.TabIndex = 59;
            this.label5.Text = "© 2013 MSNIB Corporation. All Right reserved.\r\n(Ver. 3.18.2.1)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("나눔고딕", 8.25F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(133, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(301, 13);
            this.label6.TabIndex = 60;
            this.label6.Text = "업데이트가 완료되면 자동으로 실행됩니다. 잠시만 기다려 주세요.";
            // 
            // Download
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(458, 341);
            this.ControlBox = false;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblCurrentName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblCurBytes);
            this.Controls.Add(this.lblTotPercent);
            this.Controls.Add(this.lblTotBytes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTotFile);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblCurFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pbCurrent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbTotal);
            this.Font = new System.Drawing.Font("나눔고딕", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Download";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EBAP Download";
            this.TopMost = true;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Download_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Download_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar pbCurrent;
        private System.Windows.Forms.Label lblTotFile;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCurFile;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblTotPercent;
        private System.Windows.Forms.Label lblTotBytes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblCurBytes;
        private System.Windows.Forms.Label lblCurrentName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}