using DevExpress.XtraEditors.Controls;

namespace EBAP.Win.ControlLibrary.Repository
{
    /// <summary>
    /// GridView에서 사용할 EditorButton을 만듭니다.
    /// </summary>
    internal class PEditorButton : EditorButton
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// 
        /// </summary>
        public PEditorButton()
            : this(string.Empty)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        public PEditorButton(string caption)
        {
            this.cap = caption;

            Kind = ButtonPredefines.Glyph;
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: Caption :: 버튼 캡션을 재정의합니다.

        private string cap = "";

        /// <summary>
        /// 버튼 캡션을 재정의합니다.
        /// </summary>
        public override string Caption
        {
            get
            {
                return cap;
            }
            set
            {
                cap = value;
            }
        }

        #endregion
    }
}
