namespace EBAP.Win.ControlLibrary
{
    partial class PBandedGridView
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
            components = new System.ComponentModel.Container();

            this.MouseDown += PBandedGridView_MouseDown;
            this.CustomDrawCell += PBandedGridView_CustomDrawCell;
            this.CustomDrawBandHeader += PBandedGridView_CustomDrawBandHeader;
            this.CustomDrawColumnHeader += PBandedGridView_CustomDrawColumnHeader;
            this.CustomDrawRowIndicator += PBandedGridView_CustomDrawRowIndicator;
            this.CustomDrawFooter += PBandedGridView_CustomDrawFooter;
            this.PrintInitialize += PBandedGridView_PrintInitialize;

            this.BandPanelRowHeight = 25;
            this.ColumnPanelRowHeight = 25;
            this.ViewCaptionHeight = 25;
            this.RowHeight = 29;
            this.UserCellPadding = new System.Windows.Forms.Padding(1, 4, 1, 4);

            this.OptionsBehavior.AutoExpandAllGroups = true;
            this.OptionsBehavior.AllowPartialGroups = DevExpress.Utils.DefaultBoolean.Default;
            this.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.OptionsDetail.AllowZoomDetail = true;
            this.OptionsFind.ShowSearchNavButtons = true;
            this.OptionsFind.Behavior = DevExpress.XtraEditors.FindPanelBehavior.Default;
            //this.OptionsSelection.MultiSelect = false;
            this.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            //this.OptionsSelection.EnableAppearanceFocusedCell = false;
            //this.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.OptionsSelection.EnableAppearanceHotTrackedRow = DevExpress.Utils.DefaultBoolean.True;
            this.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.OptionsPrint.AutoWidth = false;
            this.OptionsNavigation.AutoMoveRowFocus = false;
            this.OptionsScrollAnnotations.ShowFocusedRow = DevExpress.Utils.DefaultBoolean.True;
            this.OptionsView.ColumnAutoWidth = false;
            this.OptionsView.ShowGroupPanel = false;
            this.OptionsView.ShowGroupPanelColumnsAsSingleRow = true;

            this.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Appearance.HeaderPanel.Font = ControlConfig.DEFAULTFONT;
            this.Appearance.HeaderPanel.Options.UseFont = true;
            this.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.Appearance.TopNewRow.Font = ControlConfig.DEFAULTFONT;
            this.Appearance.FooterPanel.Font = ControlConfig.DEFAULTFONT;
            this.Appearance.FilterPanel.Font = ControlConfig.DEFAULTFONT;
            this.Appearance.GroupRow.Font = ControlConfig.DEFAULTFONT;
            this.Appearance.GroupRow.Options.UseFont = true;
            this.Appearance.GroupPanel.Font = ControlConfig.DEFAULTFONT;
            this.Appearance.GroupButton.Font = ControlConfig.DEFAULTFONT;
            this.Appearance.FilterPanel.Font = ControlConfig.DEFAULTFONT;
            this.Appearance.Row.Font = ControlConfig.DEFAULTFONT;
            this.Appearance.ViewCaption.Font = ControlConfig.BOLDFONT;
            this.Appearance.ViewCaption.ForeColor = ControlConfig.VIEWCAPTIONFORECOLOR;
            this.Appearance.ViewCaption.Options.UseFont = true;
            this.Appearance.ViewCaption.Options.UseTextOptions = true;
            this.Appearance.ViewCaption.Options.UseForeColor = true;
            this.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            //this.Appearance.HotTrackedRow.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Warning;
            //this.Appearance.HotTrackedRow.Options.UseForeColor = true;
            this.Appearance.HotTrackedRow.BackColor = System.Drawing.Color.FromArgb(10, DevExpress.LookAndFeel.DXSkinColors.ForeColors.Information);
            this.Appearance.HotTrackedRow.Options.UseBackColor = true;

            //this.Appearance.SelectedRow.BackColor = ControlConfig.FOCUSEDROWCOLOR;
            //this.Appearance.FocusedRow.BackColor = ControlConfig.FOCUSEDROWCOLOR;
        }

        #endregion
    }
}
