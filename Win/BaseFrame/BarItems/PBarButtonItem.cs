namespace EBAP.Win.BaseFrame
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PBarButtonItem : DevExpress.XtraBars.BarButtonItem
    {
        /// <summary>
        /// 
        /// </summary>
        public PBarButtonItem()
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
