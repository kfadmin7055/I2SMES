using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars.Alerter;

namespace EBAP.Win.BaseFrame
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public class PAlertControl : AlertControl
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// 
        /// </summary>
        public PAlertControl() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        public PAlertControl(System.ComponentModel.IContainer container)
            : base(container) { }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: Show :: Alert Form을 보여줍니다.

        /// <summary>
        /// Alert Form을 보여줍니다.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="caption"></param>
        /// <param name="text"></param>
        /// <param name="hotTrackedText"></param>
        /// <param name="image"></param>
        /// <param name="tag"></param>
        /// <param name="color"></param>
        public void Show(Form owner, string caption, string text, string hotTrackedText, Image image, object tag, Color color)
        {
            base.Show(owner, new PAlertInfo(caption, text, hotTrackedText, image, tag, color));
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: CreateAlertForm :: Alert Form을 생성합니다.

        /// <summary>
        /// Alert Form을 생성합니다.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="control"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override AlertForm CreateAlertForm(System.Drawing.Point location, AlertControl control, AlertInfo info)
        {
            return new PAlertForm(location, control, info);
        }

        #endregion
    }
}
