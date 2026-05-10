using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;

namespace EBAP.Win.ControlLibrary.Repository
{
    /// <summary>
    /// 
    /// </summary>
    internal class PRepositoryItemButtonEditViewInfo : ButtonEditViewInfo
    {
        public PRepositoryItemButtonEditViewInfo(RepositoryItem item)
            : base(item)
        {
        }

        protected override DevExpress.XtraEditors.Drawing.EditorButtonObjectInfoArgs CreateButtonInfo(EditorButton button, int index)
        {
            return base.CreateButtonInfo(new PEditorButton(), index);
        }
    }
}
