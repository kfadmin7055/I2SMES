using DevExpress.XtraEditors.Repository;

namespace EBAP.Win.ControlLibrary.Repository
{
    /// <summary>
    /// 
    /// </summary>
    internal class PRepositoryItemButtonEdit : RepositoryItemButtonEdit
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override DevExpress.XtraEditors.ViewInfo.BaseEditViewInfo CreateViewInfo()
        {
            return new PRepositoryItemButtonEditViewInfo(this);
        }
    }
}
