namespace EBAP.Win.BaseFrame
{
    partial class UIFrame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIFrame));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.toolbar = new DevExpress.XtraBars.Bar();
            this.iCopyMenuPath = new DevExpress.XtraBars.BarButtonItem();
            this.siMenuPath = new DevExpress.XtraBars.BarStaticItem();
            this.iSelect = new DevExpress.XtraBars.BarButtonItem();
            this.iNew = new DevExpress.XtraBars.BarButtonItem();
            this.iCancelEdit = new DevExpress.XtraBars.BarButtonItem();
            this.iSave = new DevExpress.XtraBars.BarButtonItem();
            this.iDelete = new DevExpress.XtraBars.BarButtonItem();
            this.iReload = new DevExpress.XtraBars.BarButtonItem();
            this.iExcel = new DevExpress.XtraBars.BarButtonItem();
            this.iPrint = new DevExpress.XtraBars.BarButtonItem();
            this.iCapture = new DevExpress.XtraBars.BarButtonItem();
            this.iHelp = new DevExpress.XtraBars.BarButtonItem();
            this.iClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.iCopy = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.toolbar});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.iSelect,
            this.iSave,
            this.iDelete,
            this.iClose,
            this.iNew,
            this.iCopyMenuPath,
            this.siMenuPath,
            this.iReload,
            this.iExcel,
            this.iHelp,
            this.iCapture,
            this.iPrint,
            this.iCancelEdit,
            this.iCopy});
            this.barManager.MaxItemId = 21;
            this.barManager.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barManager_ItemClick);
            // 
            // toolbar
            // 
            this.toolbar.BarName = "Tools";
            this.toolbar.DockCol = 0;
            this.toolbar.DockRow = 0;
            this.toolbar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.toolbar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.iCopyMenuPath, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.siMenuPath, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.iSelect, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.iNew, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.iCancelEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.iCopy),
            new DevExpress.XtraBars.LinkPersistInfo(this.iSave, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.iDelete, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.iReload, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.iExcel),
            new DevExpress.XtraBars.LinkPersistInfo(this.iPrint),
            new DevExpress.XtraBars.LinkPersistInfo(this.iCapture, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.iHelp),
            new DevExpress.XtraBars.LinkPersistInfo(this.iClose, true)});
            this.toolbar.OptionsBar.AllowQuickCustomization = false;
            this.toolbar.OptionsBar.DisableClose = true;
            this.toolbar.OptionsBar.DisableCustomization = true;
            this.toolbar.OptionsBar.DrawBorder = false;
            this.toolbar.OptionsBar.DrawDragBorder = false;
            this.toolbar.OptionsBar.MinHeight = -1;
            this.toolbar.OptionsBar.UseWholeRow = true;
            this.toolbar.Text = "Tools";
            // 
            // iCopyMenuPath
            // 
            this.iCopyMenuPath.Caption = "메뉴경로 복사";
            this.iCopyMenuPath.Id = 12;
            this.iCopyMenuPath.ImageOptions.ImageIndex = 20;
            this.iCopyMenuPath.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("iCopyMenuPath.ImageOptions.SvgImage")));
            this.iCopyMenuPath.ItemAppearance.Normal.Font = new System.Drawing.Font("나눔고딕", 8.25F, System.Drawing.FontStyle.Bold);
            this.iCopyMenuPath.ItemAppearance.Normal.Options.UseFont = true;
            this.iCopyMenuPath.Name = "iCopyMenuPath";
            // 
            // siMenuPath
            // 
            this.siMenuPath.Id = 13;
            this.siMenuPath.ItemAppearance.Normal.Font = new System.Drawing.Font("나눔고딕", 8.25F);
            this.siMenuPath.ItemAppearance.Normal.Options.UseFont = true;
            this.siMenuPath.Name = "siMenuPath";
            // 
            // iSelect
            // 
            this.iSelect.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.iSelect.Caption = "조회";
            this.iSelect.Id = 0;
            this.iSelect.ImageOptions.ImageIndex = 0;
            this.iSelect.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("iSelect.ImageOptions.SvgImage")));
            this.iSelect.ItemAppearance.Normal.Font = new System.Drawing.Font("나눔고딕", 8.25F, System.Drawing.FontStyle.Bold);
            this.iSelect.ItemAppearance.Normal.Options.UseFont = true;
            this.iSelect.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.iSelect.Name = "iSelect";
            this.iSelect.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // iNew
            // 
            this.iNew.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.iNew.Caption = "신규";
            this.iNew.Id = 7;
            this.iNew.ImageOptions.ImageIndex = 1;
            this.iNew.ImageOptions.LargeImageIndex = 0;
            this.iNew.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("iNew.ImageOptions.SvgImage")));
            this.iNew.ItemAppearance.Normal.Font = new System.Drawing.Font("나눔고딕", 8.25F, System.Drawing.FontStyle.Bold);
            this.iNew.ItemAppearance.Normal.Options.UseFont = true;
            this.iNew.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F3);
            this.iNew.Name = "iNew";
            this.iNew.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // iCancelEdit
            // 
            this.iCancelEdit.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.iCancelEdit.Caption = "취소";
            this.iCancelEdit.Id = 19;
            this.iCancelEdit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("iCancelEdit.ImageOptions.SvgImage")));
            this.iCancelEdit.ItemAppearance.Normal.Font = new System.Drawing.Font("나눔고딕", 8.25F, System.Drawing.FontStyle.Bold);
            this.iCancelEdit.ItemAppearance.Normal.Options.UseFont = true;
            this.iCancelEdit.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U));
            this.iCancelEdit.Name = "iCancelEdit";
            this.iCancelEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // iSave
            // 
            this.iSave.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.iSave.Caption = "저장";
            this.iSave.Id = 2;
            this.iSave.ImageOptions.ImageIndex = 2;
            this.iSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("iSave.ImageOptions.SvgImage")));
            this.iSave.ItemAppearance.Normal.Font = new System.Drawing.Font("나눔고딕", 8.25F, System.Drawing.FontStyle.Bold);
            this.iSave.ItemAppearance.Normal.Options.UseFont = true;
            this.iSave.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.iSave.Name = "iSave";
            this.iSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // iDelete
            // 
            this.iDelete.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.iDelete.Caption = "삭제";
            this.iDelete.Id = 3;
            this.iDelete.ImageOptions.ImageIndex = 3;
            this.iDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("iDelete.ImageOptions.SvgImage")));
            this.iDelete.ItemAppearance.Normal.Font = new System.Drawing.Font("나눔고딕", 8.25F, System.Drawing.FontStyle.Bold);
            this.iDelete.ItemAppearance.Normal.Options.UseFont = true;
            this.iDelete.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D));
            this.iDelete.Name = "iDelete";
            this.iDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // iReload
            // 
            this.iReload.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.iReload.Caption = "초기화";
            this.iReload.Id = 14;
            this.iReload.ImageOptions.ImageIndex = 4;
            this.iReload.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("iReload.ImageOptions.SvgImage")));
            this.iReload.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R));
            this.iReload.Name = "iReload";
            // 
            // iExcel
            // 
            this.iExcel.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.iExcel.Caption = "Excel";
            this.iExcel.Id = 15;
            this.iExcel.ImageOptions.ImageIndex = 5;
            this.iExcel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("iExcel.ImageOptions.SvgImage")));
            this.iExcel.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L));
            this.iExcel.Name = "iExcel";
            // 
            // iPrint
            // 
            this.iPrint.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.iPrint.Caption = "Print";
            this.iPrint.Id = 18;
            this.iPrint.ImageOptions.ImageIndex = 6;
            this.iPrint.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("iPrint.ImageOptions.SvgImage")));
            this.iPrint.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P));
            this.iPrint.Name = "iPrint";
            // 
            // iCapture
            // 
            this.iCapture.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.iCapture.Caption = "캡쳐";
            this.iCapture.Id = 17;
            this.iCapture.ImageOptions.ImageIndex = 7;
            this.iCapture.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("iCapture.ImageOptions.SvgImage")));
            this.iCapture.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T));
            this.iCapture.Name = "iCapture";
            // 
            // iHelp
            // 
            this.iHelp.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.iHelp.Caption = "도움말";
            this.iHelp.Id = 16;
            this.iHelp.ImageOptions.ImageIndex = 8;
            this.iHelp.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("iHelp.ImageOptions.SvgImage")));
            this.iHelp.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F1);
            this.iHelp.Name = "iHelp";
            // 
            // iClose
            // 
            this.iClose.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.iClose.Caption = "닫기";
            this.iClose.Id = 4;
            this.iClose.ImageOptions.ImageIndex = 9;
            this.iClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("iClose.ImageOptions.SvgImage")));
            this.iClose.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W));
            this.iClose.Name = "iClose";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Size = new System.Drawing.Size(1264, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 867);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(1264, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 843);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1264, 24);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 843);
            // 
            // iCopy
            // 
            this.iCopy.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.iCopy.Caption = "복사";
            this.iCopy.Id = 20;
            this.iCopy.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("iCopy.ImageOptions.SvgImage")));
            this.iCopy.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                | System.Windows.Forms.Keys.D));
            this.iCopy.Name = "iCopy";
            this.iCopy.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // UIFrame
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1264, 867);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("UIFrame.IconOptions.SvgImage")));
            this.Name = "UIFrame";
            this.Text = "UIFrame";
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar toolbar;
        private DevExpress.XtraBars.BarButtonItem iSelect;
        private DevExpress.XtraBars.BarButtonItem iNew;
        private DevExpress.XtraBars.BarButtonItem iSave;
        private DevExpress.XtraBars.BarButtonItem iDelete;
        private DevExpress.XtraBars.BarButtonItem iClose;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem iCopyMenuPath;
        private DevExpress.XtraBars.BarStaticItem siMenuPath;
        private DevExpress.XtraBars.BarButtonItem iExcel;
        private DevExpress.XtraBars.BarButtonItem iReload;
        private DevExpress.XtraBars.BarButtonItem iHelp;
        private DevExpress.XtraBars.BarButtonItem iCapture;
        private DevExpress.XtraBars.BarButtonItem iPrint;
        private DevExpress.XtraBars.BarButtonItem iCancelEdit;
        private DevExpress.XtraBars.BarButtonItem iCopy;
    }
}