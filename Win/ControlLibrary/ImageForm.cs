using System;
using System.Drawing;

namespace EBAP.Win.ControlLibrary
{
    /// <summary>
    /// Image 원본을 보여주는 Form 입니다.
    /// </summary>
    /// <remarks>
    /// (2016-06-17) 최초생성 : 오인봉
    /// 변경내역
    ///
    /// </remarks>
    internal partial class ImageForm : DevExpress.XtraEditors.XtraForm
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// ImageForm Form을 생성합니다.
        /// </summary>
        internal ImageForm()
        {
            InitializeComponent();
        }

        #endregion

        #region :: 전역변수 ::

        #endregion

        #region :: ImageData :: Viewer 에서 사용할 ImageData

        /// <summary>
        /// Viewer 에서 사용할 ImageData
        /// </summary>
        public object ImageData
        {
            get;
            set;
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler(Common Event)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: ImageForm_Load :: Form이 Load 시 발생합니다.

        /// <summary>
        /// Form이 Load 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageForm_Load(object sender, EventArgs e)
        {
            try
            {
                InitControls();
            }
            catch
            {
                throw;
            }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler(Control Event)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: imgViewer_Click :: Image를 Click 하면 Form을 닫습니다.

        /// <summary>
        /// Image를 Click 하면 Form을 닫습니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imgViewer_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Image GetImage()
        {
            return imgViewer.Image;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Private)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: InitControls :: 기타 Control Initialize

        /// <summary>
        /// 기타 Control Initialize
        /// </summary>
        private void InitControls()
        {
            if (ImageData == null) return;

            imgViewer.EditValue = ImageData;
        }

        #endregion
    }
}
