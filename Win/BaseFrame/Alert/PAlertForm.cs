using DevExpress.XtraBars.Alerter;

namespace EBAP.Win.BaseFrame
{
    /// <summary>
    /// Alert Form을 지정합니다.
    /// </summary>
    public class PAlertForm : AlertForm
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="control"></param>
        /// <param name="info"></param>
        public PAlertForm(System.Drawing.Point location, IAlertControl control, AlertInfo info)
            : base(location, control, info) { }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: CreatePainter :: 페인터를 지정합니다.

        /// <summary>
        /// 페인터를 지정합니다.
        /// </summary>
        /// <returns></returns>
        protected override AlertPainter CreatePainter()
        {
            return new PAlertPainter(this);
        }

        #endregion
    }
}
