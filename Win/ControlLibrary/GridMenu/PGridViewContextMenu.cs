using System;
using System.IO;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Menu;
using EBAP.Core.Info;
using EBAP.Core.Interface;
using EBAP.Win.Utility;

namespace EBAP.Win.ControlLibrary.GridMenu
{
    /// <summary>
    /// Grid에서 사용할 ContextMenu 입니다.
    /// </summary>
    internal class PGridViewContextMenu : GridViewMenu
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// PGridViewContextMenu를 생성합니다.
        /// </summary>
        /// <param name="view"></param>
        public PGridViewContextMenu(DevExpress.XtraGrid.Views.Grid.GridView view)
            : base(view)
        {

        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: CreateItems :: Menu Item을 생성합니다.

        /// <summary>
        /// Menu Item을 생성합니다.
        /// </summary>
        protected override void CreateItems()
        {
            Items.Clear();
            string keyName = String.Format("{0}{1}", (View.GridControl.FindForm() as IFrameUI).MENUID, View.Name);

            string getValue = Win32Util.GetIniValue(AppConfig.SETTINGFILEPATH, "GridLayout", keyName);

            DXSubMenuItem columnsItem = new DXSubMenuItem("Columns") { Image = GridMenuImages.Column.Images[4] };

            Items.Add(columnsItem);
            Items.Add(CreateMenuItem("컬럼 사용자지정", GridMenuImages.Column.Images[5], "Customization", true));

            System.Drawing.Image img = null;

            Items.Add(CreateMenuItem("컬럼 Layout 불러오기", img, "LayoutLoad", getValue == string.Empty || !File.Exists(getValue) ? false : true, true));
            Items.Add(CreateMenuItem("컬럼 Layout 저장", img, "LayoutSave", true));
            Items.Add(CreateMenuItem("컬럼 Layout 삭제", img, "LayoutDelete", getValue == string.Empty || !File.Exists(getValue) ? false : true));

            foreach (GridColumn column in View.Columns)
            {
                if (column.OptionsColumn.ShowInCustomizationForm)
                    columnsItem.Items.Add(CreateMenuCheckItem(column.GetTextCaption(), column.VisibleIndex >= 0, null, column, true));
            }
        }

        #endregion

        #region :: OnMenuItemClick :: MenuItem Click Event를 정의합니다.

        /// <summary>
        /// Menu Item Click Event를 정의합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnMenuItemClick(object sender, EventArgs e)
        {
            if (RaiseClickEvent(sender, null)) return;
            DXMenuItem item = sender as DXMenuItem;
            string keyName = String.Format("{0}{1}", (View.GridControl.FindForm() as IFrameUI).MENUID, View.Name);

            if (item.Tag == null) return;
            if (item.Tag is GridColumn)
            {
                GridColumn column = item.Tag as GridColumn;
                column.VisibleIndex = column.VisibleIndex >= 0 ? -1 : View.VisibleColumns.Count;
            }
            else if (item.Tag.ToString() == "Customization") View.ColumnsCustomization();
            else if (item.Tag.ToString() == "LayoutLoad")
            {
                try
                {
                    View.RestoreLayoutFromXml(Win32Util.GetIniValue(AppConfig.SETTINGFILEPATH, "GridLayout", keyName));
                }
                catch (Exception ex)
                {
                    Win32Util.SetIniValue(AppConfig.SETTINGFILEPATH, "GridLayout", keyName, "");
                    (View.GridControl.FindForm() as IDialog).ShowExceptionBox(ex);
                }
            }
            else if (item.Tag.ToString() == "LayoutSave")
            {
                AppUtil.CreateFolder(AppConfig.GRIDLAYOUTFOLDER);
                string path = Path.Combine(AppConfig.GRIDLAYOUTFOLDER, String.Format("{0}.xml", keyName));
                View.SaveLayoutToXml(path);
                Win32Util.SetIniValue(AppConfig.SETTINGFILEPATH, "GridLayout", keyName, path);
                (View.GridControl.FindForm() as IDialog).ShowAlertMessage("Layout 저장 완료", String.Format("{0}{1}Layout이 저장되었습니다.", path, Environment.NewLine), "");
            }
            else if (item.Tag.ToString() == "LayoutDelete")
            {
                //if ((View.GridControl.FindForm() as IDialog).ShowMsgBox("이전 저장된 Layout을 삭제할까요?", "삭제 확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                //{
                Win32Util.SetIniValue(AppConfig.SETTINGFILEPATH, "GridLayout", keyName, "");
                (View.GridControl.FindForm() as IDialog).ShowAlertMessage("Layout 삭제 완료", String.Format("{0}{1}Layout이 삭제되었습니다.", keyName, Environment.NewLine), "");
                //}
            }
        }

        #endregion
    }
}
