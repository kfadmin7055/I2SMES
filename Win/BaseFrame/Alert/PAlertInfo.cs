using System.Drawing;
using DevExpress.XtraBars.Alerter;

namespace EBAP.Win.BaseFrame
{
    /// <summary>
    /// Alert Form의 표시 정보를 설정합니다.
    /// </summary>
    public class PAlertInfo : AlertInfo
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="text"></param>
        public PAlertInfo(string caption, string text)
            : base(caption, text) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="text"></param>
        /// <param name="hotTrackedText"></param>
        public PAlertInfo(string caption, string text, string hotTrackedText)
            : base(caption, text, hotTrackedText)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="text"></param>
        /// <param name="image"></param>
        public PAlertInfo(string caption, string text, Image image)
            : base(caption, text, image) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="text"></param>
        /// <param name="hotTrackedText"></param>
        /// <param name="image"></param>
        public PAlertInfo(string caption, string text, string hotTrackedText, Image image)
            : base(caption, text, hotTrackedText, image) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="text"></param>
        /// <param name="hotTrackedText"></param>
        /// <param name="image"></param>
        /// <param name="tag"></param>
        public PAlertInfo(string caption, string text, string hotTrackedText, Image image, object tag)
            : base(caption, text, hotTrackedText, image, tag) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="text"></param>
        /// <param name="hotTrackedText"></param>
        /// <param name="image"></param>
        /// <param name="tag"></param>
        /// <param name="color"></param>
        public PAlertInfo(string caption, string text, string hotTrackedText, Image image, object tag, Color color)
            : base(caption, text, hotTrackedText, image, tag)
        {
            BackColor = color;
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: BackColor :: 배경색

        /// <summary>
        /// 배경색
        /// </summary>
        public Color BackColor
        {
            get;
            set;
        }

        #endregion
    }
}
