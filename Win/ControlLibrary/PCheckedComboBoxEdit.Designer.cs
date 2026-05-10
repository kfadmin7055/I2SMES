namespace EBAP.Win.ControlLibrary
{
    partial class PCheckedComboBoxEdit
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

            searchButton = new DevExpress.XtraEditors.Controls.EditorButton();
            searchButton.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Search;

            defaultButton = new DevExpress.XtraEditors.Controls.EditorButton();
            defaultButton.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Combo;

            clearButton = new DevExpress.XtraEditors.Controls.EditorButton();
            clearButton.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear;

            this.Properties.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.Properties.IncrementalSearch = true;
            this.Properties.NullText = "";
            this.EditValue = "";
            this.SelectAllItemCaption = "전체선택";
            this.Properties.NullText = "전체선택";
            this.SelectAllItemVisible = true;
            this.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { defaultButton, searchButton, clearButton });

            this.Properties.AppearanceDropDown.Font = ControlConfig.DROPDOWNFONT;
            this.Properties.AppearanceFocused.Font = ControlConfig.DROPDOWNFONT;
            this.Font = ControlConfig.DROPDOWNFONT;
        }

        DevExpress.XtraEditors.Controls.EditorButton searchButton;
        DevExpress.XtraEditors.Controls.EditorButton defaultButton;
        DevExpress.XtraEditors.Controls.EditorButton clearButton;

        #endregion
    }
}
