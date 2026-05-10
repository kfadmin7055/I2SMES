using System;
using DevExpress.XtraEditors.Repository;

namespace EBAP.Win.ControlLibrary.Repository
{
    internal class PRepositoryItemMemoExEdit : RepositoryItemMemoExEdit
    {
        internal PRepositoryItemMemoExEdit()
        {
            ParseEditValue += PRepositoryItemMemoExEdit_ParseEditValue;
        }

        private void PRepositoryItemMemoExEdit_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            e.Handled = true;
            string txt = e.Value.ToString().Replace("\r", "").Replace("\n", Environment.NewLine);

            e.Value = txt;
        }
    }
}
