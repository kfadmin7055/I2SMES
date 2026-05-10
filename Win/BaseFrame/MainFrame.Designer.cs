namespace EBAP.Win.BaseFrame
{
    partial class MainFrame
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
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::EBAP.Win.BaseFrame.SplashDialog), true, true);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrame));
            DevExpress.XtraEditors.TableLayout.ItemTemplateBase itemTemplateBase1 = new DevExpress.XtraEditors.TableLayout.ItemTemplateBase();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition1 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition2 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition3 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition4 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TemplatedItemElement templatedItemElement1 = new DevExpress.XtraEditors.TableLayout.TemplatedItemElement();
            DevExpress.XtraEditors.TableLayout.TemplatedItemElement templatedItemElement2 = new DevExpress.XtraEditors.TableLayout.TemplatedItemElement();
            DevExpress.XtraEditors.TableLayout.TemplatedItemElement templatedItemElement3 = new DevExpress.XtraEditors.TableLayout.TemplatedItemElement();
            DevExpress.XtraEditors.TableLayout.TemplatedItemElement templatedItemElement4 = new DevExpress.XtraEditors.TableLayout.TemplatedItemElement();
            DevExpress.XtraEditors.TableLayout.TemplatedItemElement templatedItemElement5 = new DevExpress.XtraEditors.TableLayout.TemplatedItemElement();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition1 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition2 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition3 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition4 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition5 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableSpan tableSpan1 = new DevExpress.XtraEditors.TableLayout.TableSpan();
            DevExpress.XtraEditors.TableLayout.TableSpan tableSpan2 = new DevExpress.XtraEditors.TableLayout.TableSpan();
            DevExpress.XtraEditors.TableLayout.TableSpan tableSpan3 = new DevExpress.XtraEditors.TableLayout.TableSpan();
            DevExpress.XtraBars.Alerter.AlertButton alertButton1 = new DevExpress.XtraBars.Alerter.AlertButton();
            this.dockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.hideContainerLeft = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.pnlTreeMenu = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.tlMenu = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn6 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn7 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn8 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn9 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn10 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn15 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imgMenu = new DevExpress.Utils.ImageCollection(this.components);
            this.hideContainerRight = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.pnlMessage = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.lbMessage = new DevExpress.XtraEditors.ListBoxControl();
            this.barManagerStatus = new DevExpress.XtraBars.BarManager(this.components);
            this.barStatus = new DevExpress.XtraBars.Bar();
            this.siMessage = new DevExpress.XtraBars.BarHeaderItem();
            this.siModified = new DevExpress.XtraBars.BarStaticItem();
            this.siMenuName = new DevExpress.XtraBars.BarStaticItem();
            this.siMenuId = new DevExpress.XtraBars.BarStaticItem();
            this.iLinkMenu = new DevExpress.XtraBars.BarSubItem();
            this.iSkinList = new DevExpress.XtraBars.SkinDropDownButtonItem();
            this.iSkinPalette = new DevExpress.XtraBars.SkinPaletteDropDownButtonItem();
            this.iStartMenu = new DevExpress.XtraBars.BarButtonItem();
            this.iFavorites = new DevExpress.XtraBars.BarButtonItem();
            this.mdiList = new DevExpress.XtraBars.BarMdiChildrenListItem();
            this.siDBTime = new DevExpress.XtraBars.BarStaticItem();
            this.iConnectionType = new DevExpress.XtraBars.BarStaticItem();
            this.iRun = new DevExpress.XtraBars.BarEditItem();
            this.cboRun = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.iPrivacy = new DevExpress.XtraBars.BarEditItem();
            this.cboPrivacy = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.barDockControl9 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl10 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl11 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl12 = new DevExpress.XtraBars.BarDockControl();
            this.siMenuInfo = new DevExpress.XtraBars.BarStaticItem();
            this.iTabClose = new DevExpress.XtraBars.BarButtonItem();
            this.iTabCloseDiff = new DevExpress.XtraBars.BarButtonItem();
            this.iTabCloseAll = new DevExpress.XtraBars.BarButtonItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.pnlTop = new DevExpress.XtraEditors.PanelControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl7 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl8 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl6 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl5 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl15 = new DevExpress.XtraBars.BarDockControl();
            this.barManagerTop = new DevExpress.XtraBars.BarManager(this.components);
            this.barTop = new DevExpress.XtraBars.Bar();
            this.iLoadMenu = new DevExpress.XtraBars.BarButtonItem();
            this.barBtn_MainPLC = new DevExpress.XtraBars.BarButtonItem();
            this.barBtn_SubPLC = new DevExpress.XtraBars.BarButtonItem();
            this.iVendorCode = new DevExpress.XtraBars.BarEditItem();
            this.cboVendorCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.iPlantCode = new DevExpress.XtraBars.BarEditItem();
            this.cboPlantCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.iUserConfig = new DevExpress.XtraBars.BarSubItem();
            this.iUser = new DevExpress.XtraBars.BarButtonItem();
            this.iCellInfo = new DevExpress.XtraBars.BarButtonItem();
            this.iLogout = new DevExpress.XtraBars.BarButtonItem();
            this.iNotify = new DevExpress.XtraBars.BarButtonItem();
            this.iLanguage = new DevExpress.XtraBars.BarEditItem();
            this.cboLanguage = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.barDockControl13 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl14 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl16 = new DevExpress.XtraBars.BarDockControl();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemHypertextLabel1 = new DevExpress.XtraEditors.Repository.RepositoryItemHypertextLabel();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.xtraTabbedMdiManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.waitFormManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::EBAP.Win.BaseFrame.WaitDialog), true, true);
            this.taskbarAssistant = new DevExpress.Utils.Taskbar.TaskbarAssistant();
            this.alertControl = new EBAP.Win.BaseFrame.PAlertControl(this.components);
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barLinkContainerItem1 = new DevExpress.XtraBars.BarLinkContainerItem();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pnlMiddle = new DevExpress.XtraEditors.PanelControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barManagerMiddle = new DevExpress.XtraBars.BarManager(this.components);
            this.barMiddle = new DevExpress.XtraBars.Bar();
            this.iNavigator = new DevExpress.XtraBars.BarEditItem();
            this.txtNavigator = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.iUpdate = new DevExpress.XtraBars.BarButtonItem();
            this.iNotice = new DevExpress.XtraBars.BarButtonItem();
            this.iVisible = new DevExpress.XtraBars.BarButtonItem();
            this.iCloseAll = new DevExpress.XtraBars.BarButtonItem();
            this.iMdi = new DevExpress.XtraBars.BarMdiChildrenListItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemLookUpEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.pnlMenu = new DevExpress.XtraEditors.PanelControl();
            this.barDockControl19 = new DevExpress.XtraBars.BarDockControl();
            this.barManagerMenu = new DevExpress.XtraBars.BarManager(this.components);
            this.barMenu = new DevExpress.XtraBars.Bar();
            this.iFMenu = new DevExpress.XtraBars.BarSubItem();
            this.barDockControl17 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl18 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl20 = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem10 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem11 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem12 = new DevExpress.XtraBars.BarButtonItem();
            this.repositoryItemLookUpEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.popMenuTab = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
            this.hideContainerLeft.SuspendLayout();
            this.pnlTreeMenu.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgMenu)).BeginInit();
            this.hideContainerRight.SuspendLayout();
            this.pnlMessage.SuspendLayout();
            this.controlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPrivacy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVendorCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLanguage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHypertextLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddle)).BeginInit();
            this.pnlMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerMiddle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNavigator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMenu)).BeginInit();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popMenuTab)).BeginInit();
            this.SuspendLayout();
            // 
            // dockManager
            // 
            this.dockManager.AutoHideContainers.AddRange(new DevExpress.XtraBars.Docking.AutoHideContainer[] {
            this.hideContainerLeft,
            this.hideContainerRight});
            this.dockManager.Form = this;
            this.dockManager.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl",
            "DevExpress.XtraEditors.PanelControl"});
            // 
            // hideContainerLeft
            // 
            this.hideContainerLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.hideContainerLeft.Controls.Add(this.pnlTreeMenu);
            this.hideContainerLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.hideContainerLeft.Location = new System.Drawing.Point(0, 166);
            this.hideContainerLeft.Name = "hideContainerLeft";
            this.hideContainerLeft.Size = new System.Drawing.Size(34, 418);
            // 
            // pnlTreeMenu
            // 
            this.pnlTreeMenu.Appearance.Options.UseFont = true;
            this.pnlTreeMenu.Controls.Add(this.dockPanel1_Container);
            this.pnlTreeMenu.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.pnlTreeMenu.FloatSize = new System.Drawing.Size(300, 200);
            this.pnlTreeMenu.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.pnlTreeMenu.ID = new System.Guid("6b016d9e-cf63-42f2-900e-8f762350f3cd");
            this.pnlTreeMenu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("pnlTreeMenu.ImageOptions.SvgImage")));
            this.pnlTreeMenu.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.pnlTreeMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlTreeMenu.Name = "pnlTreeMenu";
            this.pnlTreeMenu.Options.AllowFloating = false;
            this.pnlTreeMenu.Options.FloatOnDblClick = false;
            this.pnlTreeMenu.Options.ShowCloseButton = false;
            this.pnlTreeMenu.Options.ShowMaximizeButton = false;
            this.pnlTreeMenu.OriginalSize = new System.Drawing.Size(254, 200);
            this.pnlTreeMenu.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.pnlTreeMenu.SavedIndex = 0;
            this.pnlTreeMenu.Size = new System.Drawing.Size(254, 458);
            this.pnlTreeMenu.Text = "All Menu";
            this.pnlTreeMenu.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.tlMenu);
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 26);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(247, 429);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // tlMenu
            // 
            this.tlMenu.Appearance.FocusedRow.Font = new System.Drawing.Font("나눔고딕", 8.75F, System.Drawing.FontStyle.Bold);
            this.tlMenu.Appearance.FocusedRow.Options.UseFont = true;
            this.tlMenu.Appearance.Row.Options.UseFont = true;
            this.tlMenu.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2,
            this.treeListColumn3,
            this.treeListColumn4,
            this.treeListColumn5,
            this.treeListColumn6,
            this.treeListColumn7,
            this.treeListColumn8,
            this.treeListColumn9,
            this.treeListColumn10,
            this.treeListColumn15});
            this.tlMenu.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlMenu.KeyFieldName = "MENUID";
            this.tlMenu.Location = new System.Drawing.Point(0, 0);
            this.tlMenu.Name = "tlMenu";
            this.tlMenu.OptionsBehavior.Editable = false;
            this.tlMenu.OptionsFind.Behavior = DevExpress.XtraEditors.FindPanelBehavior.Search;
            this.tlMenu.OptionsSelection.EnableAppearanceHotTrackedRow = DevExpress.Utils.DefaultBoolean.True;
            this.tlMenu.OptionsView.ShowColumns = false;
            this.tlMenu.OptionsView.ShowHorzLines = false;
            this.tlMenu.OptionsView.ShowIndicator = false;
            this.tlMenu.OptionsView.ShowVertLines = false;
            this.tlMenu.ParentFieldName = "PARENTMENUID";
            this.tlMenu.RowHeight = 29;
            this.tlMenu.SelectImageList = this.imgMenu;
            this.tlMenu.Size = new System.Drawing.Size(247, 429);
            this.tlMenu.StateImageList = this.imgMenu;
            this.tlMenu.TabIndex = 6;
            this.tlMenu.GetSelectImage += new DevExpress.XtraTreeList.GetSelectImageEventHandler(this.tlMenu_GetSelectImage);
            this.tlMenu.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tlMenu_FocusedNodeChanged);
            this.tlMenu.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tlMenu_MouseDoubleClick);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "MenuName";
            this.treeListColumn1.FieldName = "MENUNAME";
            this.treeListColumn1.MinWidth = 52;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "DllName";
            this.treeListColumn2.FieldName = "DLLNAME";
            this.treeListColumn2.Name = "treeListColumn2";
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.Caption = "ClassName";
            this.treeListColumn3.FieldName = "CLASSNAME";
            this.treeListColumn3.Name = "treeListColumn3";
            // 
            // treeListColumn4
            // 
            this.treeListColumn4.Caption = "HelpPath";
            this.treeListColumn4.FieldName = "HELPURL";
            this.treeListColumn4.Name = "treeListColumn4";
            // 
            // treeListColumn5
            // 
            this.treeListColumn5.Caption = "ImageIdx";
            this.treeListColumn5.FieldName = "IMAGEIDX";
            this.treeListColumn5.Name = "treeListColumn5";
            // 
            // treeListColumn6
            // 
            this.treeListColumn6.Caption = "SelectImageIdx";
            this.treeListColumn6.FieldName = "SELECTIMAGEIDX";
            this.treeListColumn6.Name = "treeListColumn6";
            // 
            // treeListColumn7
            // 
            this.treeListColumn7.Caption = "SelectAuth";
            this.treeListColumn7.FieldName = "SELECTAUTH";
            this.treeListColumn7.Name = "treeListColumn7";
            // 
            // treeListColumn8
            // 
            this.treeListColumn8.Caption = "NewAuth";
            this.treeListColumn8.FieldName = "NEWAUTH";
            this.treeListColumn8.Name = "treeListColumn8";
            // 
            // treeListColumn9
            // 
            this.treeListColumn9.Caption = "SaveAuth";
            this.treeListColumn9.FieldName = "SAVEAUTH";
            this.treeListColumn9.Name = "treeListColumn9";
            // 
            // treeListColumn10
            // 
            this.treeListColumn10.Caption = "DelAuth";
            this.treeListColumn10.FieldName = "DELAUTH";
            this.treeListColumn10.Name = "treeListColumn10";
            // 
            // treeListColumn15
            // 
            this.treeListColumn15.Caption = "IsPopup";
            this.treeListColumn15.FieldName = "ISCOMMON";
            this.treeListColumn15.Name = "treeListColumn15";
            // 
            // imgMenu
            // 
            this.imgMenu.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgMenu.ImageStream")));
            this.imgMenu.Images.SetKeyName(0, "packageproduct_16x16.png");
            this.imgMenu.Images.SetKeyName(1, "product_16x16.png");
            this.imgMenu.Images.SetKeyName(2, "products_16x16.png");
            this.imgMenu.Images.SetKeyName(3, "productshipments_16x16.png");
            this.imgMenu.Images.SetKeyName(4, "feature_16x16.png");
            // 
            // hideContainerRight
            // 
            this.hideContainerRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.hideContainerRight.Controls.Add(this.pnlMessage);
            this.hideContainerRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.hideContainerRight.Location = new System.Drawing.Point(1284, 166);
            this.hideContainerRight.Name = "hideContainerRight";
            this.hideContainerRight.Size = new System.Drawing.Size(34, 418);
            // 
            // pnlMessage
            // 
            this.pnlMessage.Controls.Add(this.controlContainer1);
            this.pnlMessage.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.pnlMessage.ID = new System.Guid("d848ed14-859b-46a4-8c59-acd1ae57dda5");
            this.pnlMessage.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("pnlMessage.ImageOptions.SvgImage")));
            this.pnlMessage.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.pnlMessage.Location = new System.Drawing.Point(0, 0);
            this.pnlMessage.Name = "pnlMessage";
            this.pnlMessage.Options.AllowFloating = false;
            this.pnlMessage.Options.FloatOnDblClick = false;
            this.pnlMessage.Options.ShowCloseButton = false;
            this.pnlMessage.OriginalSize = new System.Drawing.Size(227, 200);
            this.pnlMessage.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.pnlMessage.SavedIndex = 0;
            this.pnlMessage.Size = new System.Drawing.Size(227, 450);
            this.pnlMessage.Text = "Message List";
            this.pnlMessage.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // controlContainer1
            // 
            this.controlContainer1.Controls.Add(this.lbMessage);
            this.controlContainer1.Location = new System.Drawing.Point(4, 26);
            this.controlContainer1.Name = "controlContainer1";
            this.controlContainer1.Size = new System.Drawing.Size(220, 421);
            this.controlContainer1.TabIndex = 0;
            // 
            // lbMessage
            // 
            this.lbMessage.Appearance.Options.UseFont = true;
            this.lbMessage.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMessage.HotTrackItems = true;
            this.lbMessage.ItemHeight = 110;
            this.lbMessage.Location = new System.Drawing.Point(0, 0);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(220, 421);
            this.lbMessage.TabIndex = 6;
            tableColumnDefinition1.Length.Value = 172D;
            tableColumnDefinition2.Length.Value = 42D;
            tableColumnDefinition3.Length.Value = 18D;
            tableColumnDefinition4.Length.Value = 15D;
            itemTemplateBase1.Columns.Add(tableColumnDefinition1);
            itemTemplateBase1.Columns.Add(tableColumnDefinition2);
            itemTemplateBase1.Columns.Add(tableColumnDefinition3);
            itemTemplateBase1.Columns.Add(tableColumnDefinition4);
            templatedItemElement1.Appearance.Normal.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            templatedItemElement1.Appearance.Normal.Options.UseFont = true;
            templatedItemElement1.FieldName = "TITLE";
            templatedItemElement1.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement1.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            templatedItemElement1.Text = "TITLE";
            templatedItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            templatedItemElement2.Appearance.Normal.Options.UseFont = true;
            templatedItemElement2.FieldName = "TEXT";
            templatedItemElement2.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement2.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            templatedItemElement2.RowIndex = 3;
            templatedItemElement2.Text = "TEXT";
            templatedItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            templatedItemElement3.Appearance.Normal.Font = new System.Drawing.Font("나눔고딕", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            templatedItemElement3.Appearance.Normal.Options.UseFont = true;
            templatedItemElement3.FieldName = "SUBJECT";
            templatedItemElement3.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement3.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            templatedItemElement3.RowIndex = 1;
            templatedItemElement3.Text = "SUBJECT";
            templatedItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            templatedItemElement4.Appearance.Normal.Options.UseFont = true;
            templatedItemElement4.ColumnIndex = 1;
            templatedItemElement4.FieldName = "DATE";
            templatedItemElement4.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement4.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            templatedItemElement4.Text = "DATE";
            templatedItemElement4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleRight;
            templatedItemElement5.ColumnIndex = 3;
            templatedItemElement5.FieldName = "COLOR";
            templatedItemElement5.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement5.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            templatedItemElement5.RowIndex = 1;
            templatedItemElement5.Text = "COLOR";
            templatedItemElement5.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleRight;
            itemTemplateBase1.Elements.Add(templatedItemElement1);
            itemTemplateBase1.Elements.Add(templatedItemElement2);
            itemTemplateBase1.Elements.Add(templatedItemElement3);
            itemTemplateBase1.Elements.Add(templatedItemElement4);
            itemTemplateBase1.Elements.Add(templatedItemElement5);
            itemTemplateBase1.Name = "MessgeTemplate";
            tableRowDefinition1.Length.Value = 21D;
            tableRowDefinition2.Length.Value = 18D;
            tableRowDefinition3.Length.Value = 3D;
            tableRowDefinition4.Length.Value = 25D;
            tableRowDefinition5.Length.Value = 3D;
            itemTemplateBase1.Rows.Add(tableRowDefinition1);
            itemTemplateBase1.Rows.Add(tableRowDefinition2);
            itemTemplateBase1.Rows.Add(tableRowDefinition3);
            itemTemplateBase1.Rows.Add(tableRowDefinition4);
            itemTemplateBase1.Rows.Add(tableRowDefinition5);
            tableSpan1.ColumnIndex = 1;
            tableSpan1.ColumnSpan = 3;
            tableSpan2.ColumnIndex = 1;
            tableSpan2.ColumnSpan = 3;
            tableSpan2.RowIndex = 1;
            tableSpan3.ColumnSpan = 4;
            tableSpan3.RowIndex = 3;
            itemTemplateBase1.Spans.Add(tableSpan1);
            itemTemplateBase1.Spans.Add(tableSpan2);
            itemTemplateBase1.Spans.Add(tableSpan3);
            this.lbMessage.Templates.Add(itemTemplateBase1);
            this.lbMessage.DoubleClick += new System.EventHandler(this.lbMessage_DoubleClick);
            // 
            // barManagerStatus
            // 
            this.barManagerStatus.AllowCustomization = false;
            this.barManagerStatus.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barStatus});
            this.barManagerStatus.DockControls.Add(this.barDockControl9);
            this.barManagerStatus.DockControls.Add(this.barDockControl10);
            this.barManagerStatus.DockControls.Add(this.barDockControl11);
            this.barManagerStatus.DockControls.Add(this.barDockControl12);
            this.barManagerStatus.DockManager = this.dockManager;
            this.barManagerStatus.Form = this;
            this.barManagerStatus.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.iLinkMenu,
            this.siDBTime,
            this.iPrivacy,
            this.mdiList,
            this.iFavorites,
            this.iStartMenu,
            this.siMenuInfo,
            this.iRun,
            this.iConnectionType,
            this.iSkinPalette,
            this.siModified,
            this.siMessage,
            this.siMenuId,
            this.siMenuName,
            this.iSkinList,
            this.iTabClose,
            this.iTabCloseDiff,
            this.iTabCloseAll});
            this.barManagerStatus.MaxItemId = 24;
            this.barManagerStatus.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cboPrivacy,
            this.cboRun});
            this.barManagerStatus.StatusBar = this.barStatus;
            this.barManagerStatus.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barManagerStatus_ItemClick);
            // 
            // barStatus
            // 
            this.barStatus.BarAppearance.Hovered.Font = new System.Drawing.Font("나눔고딕", 8.25F);
            this.barStatus.BarAppearance.Hovered.Options.UseFont = true;
            this.barStatus.BarAppearance.Normal.Font = new System.Drawing.Font("나눔고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barStatus.BarAppearance.Normal.Options.UseFont = true;
            this.barStatus.BarAppearance.Pressed.Font = new System.Drawing.Font("나눔고딕", 8.25F);
            this.barStatus.BarAppearance.Pressed.Options.UseFont = true;
            this.barStatus.BarName = "Status bar";
            this.barStatus.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.barStatus.DockCol = 0;
            this.barStatus.DockRow = 0;
            this.barStatus.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.barStatus.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.siMessage),
            new DevExpress.XtraBars.LinkPersistInfo(this.siModified),
            new DevExpress.XtraBars.LinkPersistInfo(this.siMenuName),
            new DevExpress.XtraBars.LinkPersistInfo(this.siMenuId),
            new DevExpress.XtraBars.LinkPersistInfo(this.iLinkMenu),
            new DevExpress.XtraBars.LinkPersistInfo(this.iSkinList, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.iSkinPalette),
            new DevExpress.XtraBars.LinkPersistInfo(this.iStartMenu, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.iFavorites),
            new DevExpress.XtraBars.LinkPersistInfo(this.mdiList, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.siDBTime),
            new DevExpress.XtraBars.LinkPersistInfo(this.iConnectionType),
            new DevExpress.XtraBars.LinkPersistInfo(this.iRun),
            new DevExpress.XtraBars.LinkPersistInfo(this.iPrivacy)});
            this.barStatus.OptionsBar.AllowQuickCustomization = false;
            this.barStatus.OptionsBar.DisableClose = true;
            this.barStatus.OptionsBar.DisableCustomization = true;
            this.barStatus.OptionsBar.DrawDragBorder = false;
            this.barStatus.OptionsBar.UseWholeRow = true;
            this.barStatus.Text = "Status bar";
            // 
            // siMessage
            // 
            this.siMessage.Id = 16;
            this.siMessage.Name = "siMessage";
            // 
            // siModified
            // 
            this.siModified.Id = 15;
            this.siModified.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("siModified.ImageOptions.SvgImage")));
            this.siModified.Name = "siModified";
            this.siModified.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.siModified.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // siMenuName
            // 
            this.siMenuName.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.siMenuName.Id = 18;
            this.siMenuName.Name = "siMenuName";
            // 
            // siMenuId
            // 
            this.siMenuId.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.siMenuId.Id = 17;
            this.siMenuId.Name = "siMenuId";
            // 
            // iLinkMenu
            // 
            this.iLinkMenu.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.iLinkMenu.Caption = "Link Menu";
            this.iLinkMenu.Id = 1;
            this.iLinkMenu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("iLinkMenu.ImageOptions.SvgImage")));
            this.iLinkMenu.Name = "iLinkMenu";
            this.iLinkMenu.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // iSkinList
            // 
            this.iSkinList.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.iSkinList.Id = 20;
            this.iSkinList.Name = "iSkinList";
            this.iSkinList.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // iSkinPalette
            // 
            this.iSkinPalette.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.iSkinPalette.Id = 14;
            this.iSkinPalette.Name = "iSkinPalette";
            this.iSkinPalette.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // iStartMenu
            // 
            this.iStartMenu.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.iStartMenu.Caption = "시작메뉴 등록";
            this.iStartMenu.Id = 7;
            this.iStartMenu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("iStartMenu.ImageOptions.SvgImage")));
            this.iStartMenu.Name = "iStartMenu";
            // 
            // iFavorites
            // 
            this.iFavorites.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.iFavorites.Caption = "즐겨찾기 등록";
            this.iFavorites.Id = 6;
            this.iFavorites.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("iFavorites.ImageOptions.SvgImage")));
            this.iFavorites.Name = "iFavorites";
            // 
            // mdiList
            // 
            this.mdiList.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.mdiList.Id = 4;
            this.mdiList.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("mdiList.ImageOptions.SvgImage")));
            this.mdiList.Name = "mdiList";
            this.mdiList.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // siDBTime
            // 
            this.siDBTime.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.siDBTime.Id = 2;
            this.siDBTime.Name = "siDBTime";
            // 
            // iConnectionType
            // 
            this.iConnectionType.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.iConnectionType.Id = 10;
            this.iConnectionType.Name = "iConnectionType";
            // 
            // iRun
            // 
            this.iRun.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.iRun.Edit = this.cboRun;
            this.iRun.EditValue = "운영";
            this.iRun.EditWidth = 60;
            this.iRun.Id = 9;
            this.iRun.Name = "iRun";
            this.iRun.EditValueChanged += new System.EventHandler(this.iRun_EditValueChanged);
            // 
            // cboRun
            // 
            this.cboRun.AutoHeight = false;
            this.cboRun.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboRun.Items.AddRange(new object[] {
            "운영",
            "개발"});
            this.cboRun.Name = "cboRun";
            this.cboRun.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // iPrivacy
            // 
            this.iPrivacy.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.iPrivacy.Edit = this.cboPrivacy;
            this.iPrivacy.EditValue = "개인정보 보호정책";
            this.iPrivacy.EditWidth = 120;
            this.iPrivacy.Id = 3;
            this.iPrivacy.Name = "iPrivacy";
            // 
            // cboPrivacy
            // 
            this.cboPrivacy.AutoHeight = false;
            this.cboPrivacy.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPrivacy.Items.AddRange(new object[] {
            "개인정보 보호정책"});
            this.cboPrivacy.Name = "cboPrivacy";
            this.cboPrivacy.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // barDockControl9
            // 
            this.barDockControl9.CausesValidation = false;
            this.barDockControl9.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl9.Location = new System.Drawing.Point(0, 0);
            this.barDockControl9.Manager = this.barManagerStatus;
            this.barDockControl9.Size = new System.Drawing.Size(1318, 0);
            // 
            // barDockControl10
            // 
            this.barDockControl10.CausesValidation = false;
            this.barDockControl10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl10.Location = new System.Drawing.Point(0, 584);
            this.barDockControl10.Manager = this.barManagerStatus;
            this.barDockControl10.Size = new System.Drawing.Size(1318, 35);
            // 
            // barDockControl11
            // 
            this.barDockControl11.CausesValidation = false;
            this.barDockControl11.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl11.Location = new System.Drawing.Point(0, 0);
            this.barDockControl11.Manager = this.barManagerStatus;
            this.barDockControl11.Size = new System.Drawing.Size(0, 584);
            // 
            // barDockControl12
            // 
            this.barDockControl12.CausesValidation = false;
            this.barDockControl12.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl12.Location = new System.Drawing.Point(1318, 0);
            this.barDockControl12.Manager = this.barManagerStatus;
            this.barDockControl12.Size = new System.Drawing.Size(0, 584);
            // 
            // siMenuInfo
            // 
            this.siMenuInfo.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.siMenuInfo.Id = 8;
            this.siMenuInfo.Name = "siMenuInfo";
            // 
            // iTabClose
            // 
            this.iTabClose.Caption = "닫기";
            this.iTabClose.Id = 21;
            this.iTabClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("iTabClose.ImageOptions.SvgImage")));
            this.iTabClose.Name = "iTabClose";
            // 
            // iTabCloseDiff
            // 
            this.iTabCloseDiff.Caption = "다른 탭 닫기";
            this.iTabCloseDiff.Id = 22;
            this.iTabCloseDiff.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("iTabCloseDiff.ImageOptions.SvgImage")));
            this.iTabCloseDiff.Name = "iTabCloseDiff";
            // 
            // iTabCloseAll
            // 
            this.iTabCloseAll.Caption = "모든 탭 닫기";
            this.iTabCloseAll.Id = 23;
            this.iTabCloseAll.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("iTabCloseAll.ImageOptions.SvgImage")));
            this.iTabCloseAll.Name = "iTabCloseAll";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // pnlTop
            // 
            this.pnlTop.AutoSize = true;
            this.pnlTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlTop.Controls.Add(this.barDockControl3);
            this.pnlTop.Controls.Add(this.barDockControl4);
            this.pnlTop.Controls.Add(this.barDockControl2);
            this.pnlTop.Controls.Add(this.barDockControl1);
            this.pnlTop.Controls.Add(this.barDockControl7);
            this.pnlTop.Controls.Add(this.barDockControl8);
            this.pnlTop.Controls.Add(this.barDockControl6);
            this.pnlTop.Controls.Add(this.barDockControl5);
            this.pnlTop.Controls.Add(this.barDockControl15);
            this.pnlTop.Controls.Add(this.barDockControl16);
            this.pnlTop.Controls.Add(this.barDockControl14);
            this.pnlTop.Controls.Add(this.barDockControl13);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 41);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1318, 49);
            this.pnlTop.TabIndex = 8;
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(0, 49);
            this.barDockControl3.Manager = null;
            this.barDockControl3.Size = new System.Drawing.Size(0, 0);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(1318, 49);
            this.barDockControl4.Manager = null;
            this.barDockControl4.Size = new System.Drawing.Size(0, 0);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(0, 49);
            this.barDockControl2.Manager = null;
            this.barDockControl2.Size = new System.Drawing.Size(1318, 0);
            // 
            // barDockControl1
            // 
            this.barDockControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.barDockControl1.Appearance.Options.UseBackColor = true;
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 49);
            this.barDockControl1.Manager = null;
            this.barDockControl1.Size = new System.Drawing.Size(1318, 0);
            // 
            // barDockControl7
            // 
            this.barDockControl7.CausesValidation = false;
            this.barDockControl7.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl7.Location = new System.Drawing.Point(0, 49);
            this.barDockControl7.Manager = null;
            this.barDockControl7.Size = new System.Drawing.Size(0, 0);
            // 
            // barDockControl8
            // 
            this.barDockControl8.CausesValidation = false;
            this.barDockControl8.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl8.Location = new System.Drawing.Point(1318, 49);
            this.barDockControl8.Manager = null;
            this.barDockControl8.Size = new System.Drawing.Size(0, 0);
            // 
            // barDockControl6
            // 
            this.barDockControl6.Appearance.BackColor = System.Drawing.Color.White;
            this.barDockControl6.Appearance.Options.UseBackColor = true;
            this.barDockControl6.Appearance.Options.UseFont = true;
            this.barDockControl6.CausesValidation = false;
            this.barDockControl6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl6.Location = new System.Drawing.Point(0, 49);
            this.barDockControl6.Manager = null;
            this.barDockControl6.Size = new System.Drawing.Size(1318, 0);
            // 
            // barDockControl5
            // 
            this.barDockControl5.Appearance.BackColor = System.Drawing.Color.White;
            this.barDockControl5.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.barDockControl5.Appearance.Options.UseBackColor = true;
            this.barDockControl5.Appearance.Options.UseForeColor = true;
            this.barDockControl5.CausesValidation = false;
            this.barDockControl5.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl5.Location = new System.Drawing.Point(0, 49);
            this.barDockControl5.Manager = null;
            this.barDockControl5.Size = new System.Drawing.Size(1318, 0);
            // 
            // barDockControl15
            // 
            this.barDockControl15.CausesValidation = false;
            this.barDockControl15.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl15.Location = new System.Drawing.Point(0, 49);
            this.barDockControl15.Manager = this.barManagerTop;
            this.barDockControl15.Size = new System.Drawing.Size(0, 0);
            // 
            // barManagerTop
            // 
            this.barManagerTop.AllowCustomization = false;
            this.barManagerTop.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barTop});
            this.barManagerTop.DockControls.Add(this.barDockControl13);
            this.barManagerTop.DockControls.Add(this.barDockControl14);
            this.barManagerTop.DockControls.Add(this.barDockControl15);
            this.barManagerTop.DockControls.Add(this.barDockControl16);
            this.barManagerTop.Form = this.pnlTop;
            this.barManagerTop.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.iLoadMenu,
            this.iPlantCode,
            this.iLogout,
            this.iUser,
            this.iLanguage,
            this.iVendorCode,
            this.iCellInfo,
            this.iUserConfig,
            this.iNotify,
            this.barBtn_MainPLC,
            this.barBtn_SubPLC});
            this.barManagerTop.MainMenu = this.barTop;
            this.barManagerTop.MaxItemId = 26;
            this.barManagerTop.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1,
            this.cboPlantCode,
            this.repositoryItemHypertextLabel1,
            this.repositoryItemTextEdit3,
            this.cboLanguage,
            this.repositoryItemTextEdit4,
            this.cboVendorCode});
            this.barManagerTop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barManagerTop_ItemClick);
            // 
            // barTop
            // 
            this.barTop.BarAppearance.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.barTop.BarAppearance.Hovered.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.barTop.BarAppearance.Hovered.ForeColor = System.Drawing.Color.White;
            this.barTop.BarAppearance.Hovered.Options.UseBackColor = true;
            this.barTop.BarAppearance.Hovered.Options.UseFont = true;
            this.barTop.BarAppearance.Hovered.Options.UseForeColor = true;
            this.barTop.BarAppearance.Normal.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.barTop.BarAppearance.Normal.Options.UseFont = true;
            this.barTop.BarAppearance.Pressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.barTop.BarAppearance.Pressed.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.barTop.BarAppearance.Pressed.ForeColor = System.Drawing.Color.White;
            this.barTop.BarAppearance.Pressed.Options.UseBackColor = true;
            this.barTop.BarAppearance.Pressed.Options.UseFont = true;
            this.barTop.BarAppearance.Pressed.Options.UseForeColor = true;
            this.barTop.BarItemHorzIndent = 15;
            this.barTop.BarName = "Tools";
            this.barTop.DockCol = 0;
            this.barTop.DockRow = 0;
            this.barTop.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTop.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.iLoadMenu),
            new DevExpress.XtraBars.LinkPersistInfo(this.iVendorCode),
            new DevExpress.XtraBars.LinkPersistInfo(this.iPlantCode),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtn_MainPLC),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtn_SubPLC),
            new DevExpress.XtraBars.LinkPersistInfo(this.iUserConfig, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.iLanguage, true)});
            this.barTop.OptionsBar.AllowQuickCustomization = false;
            this.barTop.OptionsBar.DisableClose = true;
            this.barTop.OptionsBar.DisableCustomization = true;
            this.barTop.OptionsBar.DrawBorder = false;
            this.barTop.OptionsBar.DrawDragBorder = false;
            this.barTop.OptionsBar.MinHeight = 40;
            this.barTop.OptionsBar.UseWholeRow = true;
            this.barTop.Text = "Tools";
            // 
            // iLoadMenu
            // 
            this.iLoadMenu.Id = 4;
            this.iLoadMenu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("iLoadMenu.ImageOptions.Image")));
            this.iLoadMenu.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.iLoadMenu.Name = "iLoadMenu";
            // 
            // barBtn_MainPLC
            // 
            this.barBtn_MainPLC.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barBtn_MainPLC.Caption = "1번 PLC";
            this.barBtn_MainPLC.ContentHorizontalAlignment = DevExpress.XtraBars.BarItemContentAlignment.Near;
            this.barBtn_MainPLC.Id = 24;
            this.barBtn_MainPLC.LargeWidth = 50;
            this.barBtn_MainPLC.Name = "barBtn_MainPLC";
            this.barBtn_MainPLC.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barBtn_SubPLC
            // 
            this.barBtn_SubPLC.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barBtn_SubPLC.Caption = "2번 PLC";
            this.barBtn_SubPLC.Id = 25;
            this.barBtn_SubPLC.Name = "barBtn_SubPLC";
            this.barBtn_SubPLC.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // iVendorCode
            // 
            this.iVendorCode.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.iVendorCode.Edit = this.cboVendorCode;
            this.iVendorCode.Id = 20;
            this.iVendorCode.Name = "iVendorCode";
            this.iVendorCode.Size = new System.Drawing.Size(200, 0);
            this.iVendorCode.EditValueChanged += new System.EventHandler(this.iVendorCode_EditValueChanged);
            // 
            // cboVendorCode
            // 
            this.cboVendorCode.AutoHeight = false;
            this.cboVendorCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboVendorCode.Name = "cboVendorCode";
            this.cboVendorCode.NullText = "Vendor";
            // 
            // iPlantCode
            // 
            this.iPlantCode.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.iPlantCode.Edit = this.cboPlantCode;
            this.iPlantCode.Id = 6;
            this.iPlantCode.Name = "iPlantCode";
            this.iPlantCode.Size = new System.Drawing.Size(100, 0);
            this.iPlantCode.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.iPlantCode.EditValueChanged += new System.EventHandler(this.iPlantCode_EditValueChanged);
            // 
            // cboPlantCode
            // 
            this.cboPlantCode.AutoHeight = false;
            this.cboPlantCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPlantCode.Name = "cboPlantCode";
            this.cboPlantCode.NullText = "Plant";
            // 
            // iUserConfig
            // 
            this.iUserConfig.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.iUserConfig.Caption = "사용자 정보";
            this.iUserConfig.Id = 22;
            this.iUserConfig.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("iUserConfig.ImageOptions.SvgImage")));
            this.iUserConfig.ImageOptions.SvgImageSize = new System.Drawing.Size(24, 24);
            this.iUserConfig.ItemAppearance.Hovered.BackColor = System.Drawing.Color.Transparent;
            this.iUserConfig.ItemAppearance.Hovered.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.iUserConfig.ItemAppearance.Hovered.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Warning;
            this.iUserConfig.ItemAppearance.Hovered.Options.UseBackColor = true;
            this.iUserConfig.ItemAppearance.Hovered.Options.UseFont = true;
            this.iUserConfig.ItemAppearance.Hovered.Options.UseForeColor = true;
            this.iUserConfig.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.iUserConfig.ItemAppearance.Normal.Options.UseFont = true;
            this.iUserConfig.ItemAppearance.Pressed.BackColor = System.Drawing.Color.Transparent;
            this.iUserConfig.ItemAppearance.Pressed.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.iUserConfig.ItemAppearance.Pressed.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Warning;
            this.iUserConfig.ItemAppearance.Pressed.Options.UseBackColor = true;
            this.iUserConfig.ItemAppearance.Pressed.Options.UseFont = true;
            this.iUserConfig.ItemAppearance.Pressed.Options.UseForeColor = true;
            this.iUserConfig.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.iUser),
            new DevExpress.XtraBars.LinkPersistInfo(this.iCellInfo, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.iLogout, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.iNotify, true)});
            this.iUserConfig.Name = "iUserConfig";
            this.iUserConfig.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // iUser
            // 
            this.iUser.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.iUser.Caption = "내 정보";
            this.iUser.Id = 10;
            this.iUser.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("iUser.ImageOptions.SvgImage")));
            this.iUser.Name = "iUser";
            // 
            // iCellInfo
            // 
            this.iCellInfo.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.iCellInfo.Caption = "Store 설정";
            this.iCellInfo.Id = 21;
            this.iCellInfo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("iCellInfo.ImageOptions.SvgImage")));
            this.iCellInfo.Name = "iCellInfo";
            // 
            // iLogout
            // 
            this.iLogout.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.iLogout.Caption = "사용자 로그인";
            this.iLogout.Id = 9;
            this.iLogout.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("iLogout.ImageOptions.SvgImage")));
            this.iLogout.Name = "iLogout";
            // 
            // iNotify
            // 
            this.iNotify.Caption = "공지사항";
            this.iNotify.Id = 23;
            this.iNotify.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("iNotify.ImageOptions.SvgImage")));
            this.iNotify.Name = "iNotify";
            // 
            // iLanguage
            // 
            this.iLanguage.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.iLanguage.Edit = this.cboLanguage;
            this.iLanguage.EditValue = "한국어";
            this.iLanguage.EditWidth = 70;
            this.iLanguage.Id = 18;
            this.iLanguage.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("iLanguage.ImageOptions.SvgImage")));
            this.iLanguage.Name = "iLanguage";
            this.iLanguage.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu;
            this.iLanguage.EditValueChanged += new System.EventHandler(this.iLanguage_EditValueChanged);
            // 
            // cboLanguage
            // 
            this.cboLanguage.AutoHeight = false;
            this.cboLanguage.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLanguage.Items.AddRange(new object[] {
            "한국어",
            "English"});
            this.cboLanguage.Name = "cboLanguage";
            this.cboLanguage.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // barDockControl13
            // 
            this.barDockControl13.CausesValidation = false;
            this.barDockControl13.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl13.Location = new System.Drawing.Point(0, 0);
            this.barDockControl13.Manager = this.barManagerTop;
            this.barDockControl13.Size = new System.Drawing.Size(1318, 49);
            // 
            // barDockControl14
            // 
            this.barDockControl14.CausesValidation = false;
            this.barDockControl14.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl14.Location = new System.Drawing.Point(0, 49);
            this.barDockControl14.Manager = this.barManagerTop;
            this.barDockControl14.Size = new System.Drawing.Size(1318, 0);
            // 
            // barDockControl16
            // 
            this.barDockControl16.CausesValidation = false;
            this.barDockControl16.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl16.Location = new System.Drawing.Point(1318, 49);
            this.barDockControl16.Manager = this.barManagerTop;
            this.barDockControl16.Size = new System.Drawing.Size(0, 0);
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // repositoryItemHypertextLabel1
            // 
            this.repositoryItemHypertextLabel1.Name = "repositoryItemHypertextLabel1";
            // 
            // repositoryItemTextEdit3
            // 
            this.repositoryItemTextEdit3.AutoHeight = false;
            this.repositoryItemTextEdit3.Name = "repositoryItemTextEdit3";
            // 
            // repositoryItemTextEdit4
            // 
            this.repositoryItemTextEdit4.AutoHeight = false;
            this.repositoryItemTextEdit4.Name = "repositoryItemTextEdit4";
            // 
            // xtraTabbedMdiManager
            // 
            this.xtraTabbedMdiManager.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(169)))), ((int)(((byte)(254)))));
            this.xtraTabbedMdiManager.Appearance.Options.UseBorderColor = true;
            this.xtraTabbedMdiManager.Appearance.Options.UseFont = true;
            this.xtraTabbedMdiManager.AppearancePage.Header.Options.UseFont = true;
            this.xtraTabbedMdiManager.AppearancePage.HeaderActive.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.xtraTabbedMdiManager.AppearancePage.HeaderActive.Options.UseFont = true;
            this.xtraTabbedMdiManager.AppearancePage.PageClient.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(169)))), ((int)(((byte)(254)))));
            this.xtraTabbedMdiManager.AppearancePage.PageClient.Options.UseBorderColor = true;
            this.xtraTabbedMdiManager.AppearancePage.PageClient.Options.UseFont = true;
            this.xtraTabbedMdiManager.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPagesAndTabControlHeader;
            this.xtraTabbedMdiManager.FloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            this.xtraTabbedMdiManager.FloatOnDrag = DevExpress.Utils.DefaultBoolean.True;
            this.xtraTabbedMdiManager.HeaderButtons = ((DevExpress.XtraTab.TabButtons)(((DevExpress.XtraTab.TabButtons.Prev | DevExpress.XtraTab.TabButtons.Next) 
            | DevExpress.XtraTab.TabButtons.Close)));
            this.xtraTabbedMdiManager.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom;
            this.xtraTabbedMdiManager.MdiParent = this;
            this.xtraTabbedMdiManager.PinPageButtonShowMode = DevExpress.XtraTab.PinPageButtonShowMode.InActiveTabPageHeader;
            this.xtraTabbedMdiManager.SelectedPageChanged += new System.EventHandler(this.xtraTabbedMdiManager_SelectedPageChanged);
            this.xtraTabbedMdiManager.MouseDown += new System.Windows.Forms.MouseEventHandler(this.xtraTabbedMdiManager_MouseDown);
            this.xtraTabbedMdiManager.MouseMove += new System.Windows.Forms.MouseEventHandler(this.xtraTabbedMdiManager_MouseMove);
            // 
            // taskbarAssistant
            // 
            this.taskbarAssistant.ParentControl = this;
            // 
            // alertControl
            // 
            this.alertControl.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.alertControl.AppearanceCaption.Options.UseFont = true;
            this.alertControl.AppearanceHotTrackedText.Font = new System.Drawing.Font("나눔고딕", 8.75F);
            this.alertControl.AppearanceHotTrackedText.Options.UseFont = true;
            this.alertControl.AppearanceText.Options.UseFont = true;
            this.alertControl.AutoFormDelay = 6000;
            this.alertControl.AutoHeight = true;
            alertButton1.Hint = "Message 내용을 복사 합니다.";
            alertButton1.ImageOptions.ImageUri.Uri = "Copy;Size16x16;Office2013";
            alertButton1.Name = "btnCopy";
            this.alertControl.Buttons.Add(alertButton1);
            this.alertControl.ButtonClick += new DevExpress.XtraBars.Alerter.AlertButtonClickEventHandler(this.alertControl_ButtonClick);
            this.alertControl.BeforeFormShow += new DevExpress.XtraBars.Alerter.AlertFormEventHandler(this.alertControl_BeforeFormShow);
            this.alertControl.FormLoad += new DevExpress.XtraBars.Alerter.AlertFormLoadEventHandler(this.alertControl_FormLoad);
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.barLinkContainerItem1,
            this.barEditItem1});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 4;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit5});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.ribbonControl1.Size = new System.Drawing.Size(1318, 41);
            // 
            // barLinkContainerItem1
            // 
            this.barLinkContainerItem1.Caption = "barLinkContainerItem1";
            this.barLinkContainerItem1.Id = 2;
            this.barLinkContainerItem1.Name = "barLinkContainerItem1";
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "barEditItem1";
            this.barEditItem1.Edit = this.repositoryItemTextEdit5;
            this.barEditItem1.Id = 3;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemTextEdit5
            // 
            this.repositoryItemTextEdit5.AutoHeight = false;
            this.repositoryItemTextEdit5.Name = "repositoryItemTextEdit5";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.AutoSize = true;
            this.pnlMiddle.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlMiddle.Controls.Add(this.barDockControlLeft);
            this.pnlMiddle.Controls.Add(this.barDockControlRight);
            this.pnlMiddle.Controls.Add(this.barDockControlBottom);
            this.pnlMiddle.Controls.Add(this.barDockControlTop);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMiddle.Location = new System.Drawing.Point(0, 90);
            this.pnlMiddle.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(1318, 39);
            this.pnlMiddle.TabIndex = 14;
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 39);
            this.barDockControlLeft.Manager = this.barManagerMiddle;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 0);
            // 
            // barManagerMiddle
            // 
            this.barManagerMiddle.AllowCustomization = false;
            this.barManagerMiddle.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barMiddle});
            this.barManagerMiddle.DockControls.Add(this.barDockControlTop);
            this.barManagerMiddle.DockControls.Add(this.barDockControlBottom);
            this.barManagerMiddle.DockControls.Add(this.barDockControlLeft);
            this.barManagerMiddle.DockControls.Add(this.barDockControlRight);
            this.barManagerMiddle.Form = this.pnlMiddle;
            this.barManagerMiddle.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.iMdi,
            this.iVisible,
            this.iNavigator,
            this.iCloseAll,
            this.iUpdate,
            this.iNotice});
            this.barManagerMiddle.MainMenu = this.barMiddle;
            this.barManagerMiddle.MaxItemId = 16;
            this.barManagerMiddle.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit2,
            this.repositoryItemTextEdit2,
            this.repositoryItemLookUpEdit5,
            this.repositoryItemImageEdit1,
            this.repositoryItemPictureEdit1,
            this.txtNavigator});
            this.barManagerMiddle.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barManagerMiddle_ItemClick);
            // 
            // barMiddle
            // 
            this.barMiddle.BarAppearance.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(115)))), ((int)(((byte)(160)))));
            this.barMiddle.BarAppearance.Hovered.Font = new System.Drawing.Font("나눔고딕", 8.75F, System.Drawing.FontStyle.Bold);
            this.barMiddle.BarAppearance.Hovered.ForeColor = System.Drawing.Color.White;
            this.barMiddle.BarAppearance.Hovered.Options.UseBackColor = true;
            this.barMiddle.BarAppearance.Hovered.Options.UseFont = true;
            this.barMiddle.BarAppearance.Hovered.Options.UseForeColor = true;
            this.barMiddle.BarAppearance.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.barMiddle.BarAppearance.Normal.BorderColor = System.Drawing.Color.Black;
            this.barMiddle.BarAppearance.Normal.Font = new System.Drawing.Font("나눔고딕", 8.75F, System.Drawing.FontStyle.Bold);
            this.barMiddle.BarAppearance.Normal.ForeColor = System.Drawing.Color.White;
            this.barMiddle.BarAppearance.Normal.Options.UseBackColor = true;
            this.barMiddle.BarAppearance.Normal.Options.UseBorderColor = true;
            this.barMiddle.BarAppearance.Normal.Options.UseFont = true;
            this.barMiddle.BarAppearance.Normal.Options.UseForeColor = true;
            this.barMiddle.BarAppearance.Pressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(115)))), ((int)(((byte)(160)))));
            this.barMiddle.BarAppearance.Pressed.Font = new System.Drawing.Font("나눔고딕", 8.75F, System.Drawing.FontStyle.Bold);
            this.barMiddle.BarAppearance.Pressed.ForeColor = System.Drawing.Color.White;
            this.barMiddle.BarAppearance.Pressed.Options.UseBackColor = true;
            this.barMiddle.BarAppearance.Pressed.Options.UseFont = true;
            this.barMiddle.BarAppearance.Pressed.Options.UseForeColor = true;
            this.barMiddle.BarItemHorzIndent = 15;
            this.barMiddle.BarName = "Tools";
            this.barMiddle.DockCol = 0;
            this.barMiddle.DockRow = 0;
            this.barMiddle.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMiddle.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.iNavigator),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.iUpdate, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.iNotice),
            new DevExpress.XtraBars.LinkPersistInfo(this.iVisible),
            new DevExpress.XtraBars.LinkPersistInfo(this.iCloseAll),
            new DevExpress.XtraBars.LinkPersistInfo(this.iMdi)});
            this.barMiddle.OptionsBar.AllowQuickCustomization = false;
            this.barMiddle.OptionsBar.DisableClose = true;
            this.barMiddle.OptionsBar.DisableCustomization = true;
            this.barMiddle.OptionsBar.DrawBorder = false;
            this.barMiddle.OptionsBar.DrawDragBorder = false;
            this.barMiddle.OptionsBar.MinHeight = 32;
            this.barMiddle.OptionsBar.MultiLine = true;
            this.barMiddle.OptionsBar.RotateWhenVertical = false;
            this.barMiddle.OptionsBar.UseWholeRow = true;
            this.barMiddle.Text = "Tools";
            // 
            // iNavigator
            // 
            this.iNavigator.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.iNavigator.Edit = this.txtNavigator;
            this.iNavigator.EditWidth = 200;
            this.iNavigator.Id = 12;
            this.iNavigator.Name = "iNavigator";
            this.iNavigator.EditValueChanged += new System.EventHandler(this.iNavigator_EditValueChanged);
            // 
            // txtNavigator
            // 
            this.txtNavigator.AutoHeight = false;
            this.txtNavigator.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNavigator.ContextImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("txtNavigator.ContextImageOptions.SvgImage")));
            this.txtNavigator.ContextImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.txtNavigator.Name = "txtNavigator";
            this.txtNavigator.NullValuePrompt = "  찾을 메뉴명을 입력하세요.";
            // 
            // iUpdate
            // 
            this.iUpdate.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.iUpdate.Caption = "Update";
            this.iUpdate.Id = 14;
            this.iUpdate.ImageOptions.ImageUri.Uri = "NavigationBar;GrayScaled";
            this.iUpdate.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("iUpdate.ImageOptions.SvgImage")));
            this.iUpdate.Name = "iUpdate";
            this.iUpdate.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // iNotice
            // 
            this.iNotice.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.iNotice.Caption = "공지사항";
            this.iNotice.Id = 15;
            this.iNotice.ImageOptions.ImageUri.Uri = "InLineWithText;GrayScaled";
            this.iNotice.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("iNotice.ImageOptions.SvgImage")));
            this.iNotice.Name = "iNotice";
            // 
            // iVisible
            // 
            this.iVisible.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.iVisible.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.iVisible.Caption = "접기";
            this.iVisible.Id = 11;
            this.iVisible.ImageOptions.ImageUri.Uri = "AlignHorizontalTop;GrayScaled";
            this.iVisible.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("iVisible.ImageOptions.SvgImage")));
            this.iVisible.Name = "iVisible";
            // 
            // iCloseAll
            // 
            this.iCloseAll.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.iCloseAll.Caption = "Close All";
            this.iCloseAll.Id = 13;
            this.iCloseAll.ImageOptions.ImageUri.Uri = "Close;GrayScaled";
            this.iCloseAll.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("iCloseAll.ImageOptions.SvgImage")));
            this.iCloseAll.Name = "iCloseAll";
            // 
            // iMdi
            // 
            this.iMdi.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.iMdi.Id = 10;
            this.iMdi.ImageOptions.ImageUri.Uri = "ListBullets;GrayScaled";
            this.iMdi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("iMdi.ImageOptions.SvgImage")));
            this.iMdi.Name = "iMdi";
            this.iMdi.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.barDockControlTop.Appearance.Options.UseBackColor = true;
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManagerMiddle;
            this.barDockControlTop.Size = new System.Drawing.Size(1318, 39);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Appearance.BackColor = System.Drawing.Color.White;
            this.barDockControlBottom.Appearance.Options.UseBackColor = true;
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 39);
            this.barDockControlBottom.Manager = this.barManagerMiddle;
            this.barDockControlBottom.Size = new System.Drawing.Size(1318, 0);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Appearance.BackColor = System.Drawing.Color.White;
            this.barDockControlRight.Appearance.Options.UseBackColor = true;
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1318, 39);
            this.barDockControlRight.Manager = this.barManagerMiddle;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 0);
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // repositoryItemLookUpEdit5
            // 
            this.repositoryItemLookUpEdit5.AutoHeight = false;
            this.repositoryItemLookUpEdit5.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit5.Name = "repositoryItemLookUpEdit5";
            // 
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            // 
            // pnlMenu
            // 
            this.pnlMenu.AutoSize = true;
            this.pnlMenu.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlMenu.Controls.Add(this.barDockControl19);
            this.pnlMenu.Controls.Add(this.barDockControl20);
            this.pnlMenu.Controls.Add(this.barDockControl18);
            this.pnlMenu.Controls.Add(this.barDockControl17);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Location = new System.Drawing.Point(0, 129);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(1318, 37);
            this.pnlMenu.TabIndex = 22;
            // 
            // barDockControl19
            // 
            this.barDockControl19.CausesValidation = false;
            this.barDockControl19.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl19.Location = new System.Drawing.Point(0, 37);
            this.barDockControl19.Manager = this.barManagerMenu;
            this.barDockControl19.Size = new System.Drawing.Size(0, 0);
            // 
            // barManagerMenu
            // 
            this.barManagerMenu.AllowCustomization = false;
            this.barManagerMenu.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barMenu});
            this.barManagerMenu.DockControls.Add(this.barDockControl17);
            this.barManagerMenu.DockControls.Add(this.barDockControl18);
            this.barManagerMenu.DockControls.Add(this.barDockControl19);
            this.barManagerMenu.DockControls.Add(this.barDockControl20);
            this.barManagerMenu.Form = this.pnlMenu;
            this.barManagerMenu.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem9,
            this.barButtonItem10,
            this.barButtonItem11,
            this.barButtonItem12,
            this.iFMenu});
            this.barManagerMenu.MainMenu = this.barMenu;
            this.barManagerMenu.MaxItemId = 12;
            this.barManagerMenu.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemLookUpEdit3,
            this.repositoryItemLookUpEdit4});
            this.barManagerMenu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barManagerMenu_ItemClick);
            // 
            // barMenu
            // 
            this.barMenu.BarAppearance.Hovered.Font = new System.Drawing.Font("나눔고딕", 8.75F, System.Drawing.FontStyle.Bold);
            this.barMenu.BarAppearance.Hovered.Options.UseFont = true;
            this.barMenu.BarAppearance.Normal.Options.UseFont = true;
            this.barMenu.BarAppearance.Pressed.Font = new System.Drawing.Font("나눔고딕", 8.75F, System.Drawing.FontStyle.Bold);
            this.barMenu.BarAppearance.Pressed.Options.UseFont = true;
            this.barMenu.BarItemHorzIndent = 10;
            this.barMenu.BarName = "Main menu";
            this.barMenu.DockCol = 0;
            this.barMenu.DockRow = 0;
            this.barMenu.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMenu.FloatLocation = new System.Drawing.Point(1364, 325);
            this.barMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.iFMenu)});
            this.barMenu.OptionsBar.AllowQuickCustomization = false;
            this.barMenu.OptionsBar.DisableClose = true;
            this.barMenu.OptionsBar.DisableCustomization = true;
            this.barMenu.OptionsBar.DrawBorder = false;
            this.barMenu.OptionsBar.DrawDragBorder = false;
            this.barMenu.OptionsBar.MinHeight = 30;
            this.barMenu.OptionsBar.UseWholeRow = true;
            this.barMenu.Text = "Main menu";
            // 
            // iFMenu
            // 
            this.iFMenu.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.iFMenu.Caption = "즐겨찾는 메뉴";
            this.iFMenu.Id = 11;
            this.iFMenu.ImageOptions.ImageUri.Uri = "AlignJustify;GrayScaled";
            this.iFMenu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("iFMenu.ImageOptions.SvgImage")));
            this.iFMenu.Name = "iFMenu";
            this.iFMenu.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barDockControl17
            // 
            this.barDockControl17.CausesValidation = false;
            this.barDockControl17.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl17.Location = new System.Drawing.Point(0, 0);
            this.barDockControl17.Manager = this.barManagerMenu;
            this.barDockControl17.Size = new System.Drawing.Size(1318, 37);
            // 
            // barDockControl18
            // 
            this.barDockControl18.Appearance.BackColor = System.Drawing.Color.White;
            this.barDockControl18.Appearance.Options.UseBackColor = true;
            this.barDockControl18.Appearance.Options.UseFont = true;
            this.barDockControl18.CausesValidation = false;
            this.barDockControl18.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl18.Location = new System.Drawing.Point(0, 37);
            this.barDockControl18.Manager = this.barManagerMenu;
            this.barDockControl18.Size = new System.Drawing.Size(1318, 0);
            // 
            // barDockControl20
            // 
            this.barDockControl20.CausesValidation = false;
            this.barDockControl20.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl20.Location = new System.Drawing.Point(1318, 37);
            this.barDockControl20.Manager = this.barManagerMenu;
            this.barDockControl20.Size = new System.Drawing.Size(0, 0);
            // 
            // barButtonItem9
            // 
            this.barButtonItem9.Caption = "LOT 변경";
            this.barButtonItem9.Id = 1;
            this.barButtonItem9.Name = "barButtonItem9";
            // 
            // barButtonItem10
            // 
            this.barButtonItem10.Caption = "barButtonItem10";
            this.barButtonItem10.Id = 2;
            this.barButtonItem10.Name = "barButtonItem10";
            // 
            // barButtonItem11
            // 
            this.barButtonItem11.Caption = "barButtonItem11";
            this.barButtonItem11.Id = 3;
            this.barButtonItem11.Name = "barButtonItem11";
            // 
            // barButtonItem12
            // 
            this.barButtonItem12.Caption = "barButtonItem12";
            this.barButtonItem12.Id = 4;
            this.barButtonItem12.Name = "barButtonItem12";
            // 
            // repositoryItemLookUpEdit3
            // 
            this.repositoryItemLookUpEdit3.AutoHeight = false;
            this.repositoryItemLookUpEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit3.Name = "repositoryItemLookUpEdit3";
            // 
            // repositoryItemLookUpEdit4
            // 
            this.repositoryItemLookUpEdit4.AutoHeight = false;
            this.repositoryItemLookUpEdit4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit4.Name = "repositoryItemLookUpEdit4";
            // 
            // popMenuTab
            // 
            this.popMenuTab.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.iTabClose),
            new DevExpress.XtraBars.LinkPersistInfo(this.iTabCloseDiff, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.iTabCloseAll, true)});
            this.popMenuTab.Manager = this.barManagerStatus;
            this.popMenuTab.Name = "popMenuTab";
            // 
            // MainFrame
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1318, 619);
            this.Controls.Add(this.hideContainerLeft);
            this.Controls.Add(this.hideContainerRight);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlMiddle);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.barDockControl11);
            this.Controls.Add(this.barDockControl12);
            this.Controls.Add(this.barDockControl10);
            this.Controls.Add(this.barDockControl9);
            this.Font = new System.Drawing.Font("나눔고딕", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("MainFrame.IconOptions.SvgImage")));
            this.IsMdiContainer = true;
            this.Name = "MainFrame";
            this.Ribbon = this.ribbonControl1;
            this.RibbonVisibility = DevExpress.XtraBars.Ribbon.RibbonVisibility.Hidden;
            this.Text = "EBAP.NET";
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
            this.hideContainerLeft.ResumeLayout(false);
            this.pnlTreeMenu.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgMenu)).EndInit();
            this.hideContainerRight.ResumeLayout(false);
            this.pnlMessage.ResumeLayout(false);
            this.controlContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPrivacy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVendorCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLanguage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHypertextLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMiddle)).EndInit();
            this.pnlMiddle.ResumeLayout(false);
            this.pnlMiddle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerMiddle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNavigator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMenu)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popMenuTab)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager;
        private DevExpress.XtraSplashScreen.SplashScreenManager waitFormManager;
        private DevExpress.XtraBars.Docking.DockManager dockManager;
        private DevExpress.XtraBars.Docking.DockPanel pnlTreeMenu;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraTreeList.TreeList tlMenu;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn5;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn6;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn7;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn8;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn9;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn10;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn15;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerLeft;
        private DevExpress.Utils.Taskbar.TaskbarAssistant taskbarAssistant;
        private PAlertControl alertControl;
        private DevExpress.XtraBars.Docking.DockPanel pnlMessage;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer1;
        private DevExpress.XtraEditors.ListBoxControl lbMessage;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerRight;
        private DevExpress.XtraBars.BarDockControl barDockControl11;
        private DevExpress.XtraBars.BarManager barManagerStatus;
        private DevExpress.XtraBars.Bar barStatus;
        private DevExpress.XtraBars.BarDockControl barDockControl9;
        private DevExpress.XtraBars.BarDockControl barDockControl10;
        private DevExpress.XtraBars.BarDockControl barDockControl12;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraEditors.PanelControl pnlTop;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControl7;
        private DevExpress.XtraBars.BarDockControl barDockControl8;
        private DevExpress.XtraBars.BarDockControl barDockControl6;
        private DevExpress.XtraBars.BarDockControl barDockControl5;
        private DevExpress.XtraBars.BarDockControl barDockControl13;
        private DevExpress.XtraBars.BarManager barManagerTop;
        private DevExpress.XtraBars.Bar barTop;
        private DevExpress.XtraBars.BarButtonItem iLoadMenu;
        private DevExpress.XtraBars.BarEditItem iPlantCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cboPlantCode;
        private DevExpress.XtraBars.BarButtonItem iUser;
        private DevExpress.XtraBars.BarButtonItem iLogout;
        private DevExpress.XtraBars.BarDockControl barDockControl14;
        private DevExpress.XtraBars.BarDockControl barDockControl15;
        private DevExpress.XtraBars.BarDockControl barDockControl16;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHypertextLabel repositoryItemHypertextLabel1;
        private DevExpress.XtraBars.BarEditItem iLanguage;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cboLanguage;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
        private DevExpress.XtraEditors.PanelControl pnlMiddle;
        private DevExpress.XtraEditors.PanelControl pnlMenu;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarManager barManagerMiddle;
        private DevExpress.XtraBars.Bar barMiddle;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit5;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraBars.BarDockControl barDockControl19;
        private DevExpress.XtraBars.BarManager barManagerMenu;
        private DevExpress.XtraBars.Bar barMenu;
        private DevExpress.XtraBars.BarButtonItem barButtonItem9;
        private DevExpress.XtraBars.BarButtonItem barButtonItem10;
        private DevExpress.XtraBars.BarButtonItem barButtonItem11;
        private DevExpress.XtraBars.BarDockControl barDockControl17;
        private DevExpress.XtraBars.BarDockControl barDockControl18;
        private DevExpress.XtraBars.BarDockControl barDockControl20;
        private DevExpress.XtraBars.BarButtonItem barButtonItem12;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit4;
        private DevExpress.XtraBars.BarSubItem iLinkMenu;
        private DevExpress.XtraBars.BarStaticItem siDBTime;
        private DevExpress.XtraBars.BarEditItem iPrivacy;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cboPrivacy;
        private DevExpress.XtraBars.BarMdiChildrenListItem mdiList;
        private DevExpress.XtraBars.BarButtonItem iFavorites;
        private DevExpress.XtraBars.BarButtonItem iStartMenu;
        private DevExpress.XtraBars.BarButtonItem iVisible;
        private DevExpress.XtraBars.BarMdiChildrenListItem iMdi;
        private DevExpress.XtraBars.BarStaticItem siMenuInfo;
        private DevExpress.XtraBars.BarEditItem iNavigator;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtNavigator;
        private DevExpress.XtraBars.BarButtonItem iCloseAll;
        private DevExpress.XtraBars.BarButtonItem iUpdate;
        private DevExpress.XtraBars.BarEditItem iVendorCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cboVendorCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit4;
        private DevExpress.XtraBars.BarEditItem iRun;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cboRun;
        private DevExpress.XtraBars.BarStaticItem iConnectionType;
        private DevExpress.XtraBars.BarSubItem iFMenu;
        private DevExpress.XtraBars.BarButtonItem iCellInfo;
        private DevExpress.XtraBars.BarButtonItem iNotice;
        private DevExpress.Utils.ImageCollection imgMenu;
        private DevExpress.XtraBars.BarStaticItem siModified;
        private DevExpress.XtraBars.SkinPaletteDropDownButtonItem iSkinPalette;
        private DevExpress.XtraBars.BarSubItem iUserConfig;
        private DevExpress.XtraBars.BarButtonItem iNotify;
        private DevExpress.XtraBars.BarHeaderItem siMessage;
        private DevExpress.XtraBars.BarStaticItem siMenuName;
        private DevExpress.XtraBars.BarStaticItem siMenuId;
        private DevExpress.XtraBars.SkinDropDownButtonItem iSkinList;
        private DevExpress.XtraBars.BarButtonItem iTabClose;
        private DevExpress.XtraBars.BarButtonItem iTabCloseDiff;
        private DevExpress.XtraBars.BarButtonItem iTabCloseAll;
        private DevExpress.XtraBars.PopupMenu popMenuTab;
        private DevExpress.XtraBars.BarButtonItem barBtn_MainPLC;
        private DevExpress.XtraBars.BarButtonItem barBtn_SubPLC;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit5;
        private DevExpress.XtraBars.BarLinkContainerItem barLinkContainerItem1;
    }
}