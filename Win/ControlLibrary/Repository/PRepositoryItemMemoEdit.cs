using System;
using DevExpress.XtraEditors.Repository;

namespace EBAP.Win.ControlLibrary.Repository
{
    /// <summary>
    /// 
    /// </summary>
    internal class PRepositoryItemMemoEdit : RepositoryItemMemoEdit
    {
        internal PRepositoryItemMemoEdit()
        {
            ParseEditValue += PRepositoryItemMemoEdit_ParseEditValue;
        }

        private void PRepositoryItemMemoEdit_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            e.Handled = true;
            string txt = e.Value.ToString().Replace("\r", "").Replace("\n", Environment.NewLine);

            e.Value = txt;
        }
    }
}
