namespace EBAP.Win.ControlLibrary
{
    partial class PTreeList
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

            this.CustomDrawColumnHeader += PTreeList_CustomDrawColumnHeader;

            this.OptionsView.AutoWidth = false;

            this.ColumnPanelRowHeight =30;
            this.RowHeight = 29;

            //this.Appearance.SelectedRow.BackColor = ControlConfig.FOCUSEDROWCOLOR;
            //this.OptionsSelection.EnableAppearanceFocusedCell = false;
            //this.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.OptionsSelection.EnableAppearanceHotTrackedRow = DevExpress.Utils.DefaultBoolean.True;

            this.OptionsFind.Behavior = DevExpress.XtraEditors.FindPanelBehavior.Search;
            //this.OptionsView.ShowHorzLines = false;
            //this.OptionsView.ShowVertLines = false;
            //this.OptionsView.ShowIndicator = false;
            this.OptionsView.AutoWidth = false;

            this.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Appearance.HeaderPanel.Font = ControlConfig.DEFAULTFONT;
            this.Appearance.FooterPanel.Font = ControlConfig.DEFAULTFONT;
            this.Appearance.Row.Font = ControlConfig.DEFAULTFONT;
            //this.Appearance.HotTrackedRow.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Warning;
            //this.Appearance.HotTrackedRow.Options.UseForeColor = true;
            this.Appearance.HotTrackedRow.BackColor = System.Drawing.Color.FromArgb(10, DevExpress.LookAndFeel.DXSkinColors.ForeColors.Information);
            this.Appearance.HotTrackedRow.Options.UseBackColor = true;
        }

        #endregion
    }
}