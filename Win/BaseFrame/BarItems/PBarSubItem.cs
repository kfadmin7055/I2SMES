namespace EBAP.Win.BaseFrame
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PBarSubItem : DevExpress.XtraBars.BarSubItem
    {
        /// <summary>
        /// 
        /// </summary>
        public PBarSubItem()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public string DLLNAME
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string CLASSNAME
        {
            get;
            set;
        }
    }
}
