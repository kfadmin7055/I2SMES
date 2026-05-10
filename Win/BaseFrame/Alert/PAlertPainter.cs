using System.Drawing;
using DevExpress.XtraBars.Alerter;

namespace EBAP.Win.BaseFrame
{
    /// <summary>
    /// Alert Form Painter
    /// </summary>
    public class PAlertPainter : AlertPainter
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// 
        /// </summary>
        /// <param name="form"></param>
        public PAlertPainter(AlertFormCore form)
            : base(form)
        {
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: DrawContent :: 콘텐츠를 그립니다.

        /// <summary>
        /// 콘텐츠를 그립니다.
        /// </summary>
        /// <param name="graphicsCache"></param>
        /// <param name="skin"></param>
        protected override void DrawContent(DevExpress.Utils.Drawing.GraphicsCache graphicsCache, DevExpress.Skins.Skin skin)
        {
            base.DrawContent(graphicsCache, skin);

            PAlertInfo alertInfo = Owner.Info as PAlertInfo;

            if (alertInfo == null) return;

            Color backColor = alertInfo.BackColor;

            //Rectangle rect = new Rectangle(Owner.ClientRectangle.Location, Owner.ClientRectangle.Size);
            Rectangle rect = new Rectangle(Owner.ClientRectangle.Location.X, Owner.ClientRectangle.Location.Y, Owner.ClientRectangle.Size.Width, 10);
            rect.Inflate(-2, -2);
            using (SolidBrush brush = new SolidBrush(backColor))
                graphicsCache.Graphics.FillRectangle(brush, rect);
        }

        #endregion
    }
}
