using DevExpress.XtraSplashScreen;
using System;

namespace EBAP.Win.BaseFrame
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SplashDialog : SplashScreen
    {
        /// <summary>
        /// 
        /// </summary>
        public SplashDialog()
        {
            InitializeComponent();
        }

        #region Overrides

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="arg"></param>
        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public enum SplashScreenCommand
        {
        }
    }
}