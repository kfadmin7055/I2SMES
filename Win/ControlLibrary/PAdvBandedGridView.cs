namespace EBAP.Win.ControlLibrary
{
    /// <summary>
    /// Advanced Banded Grid View
    /// </summary>
    public partial class PAdvBandedGridView : DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    {
        #region :: 생성자(+1 Overloading) ::

        /// <summary>
        /// 
        /// </summary>
        public PAdvBandedGridView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ownerGrid"></param>
        public PAdvBandedGridView(DevExpress.XtraGrid.GridControl ownerGrid)
            : base(ownerGrid)
        {
            InitializeComponent();
        }

        #endregion
    }
}
