using System;
using System.Windows.Forms;

namespace EBAP.Win.Dialog
{
    /// <summary>
    /// Exception Dialog를 생성합니다.
    /// </summary>
    /// <remarks>
    /// 2023-02-01 최초생성 : 오인봉
    /// 변경내역
    /// 
    /// </remarks>
    public class ExceptionBox
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Static Member & Function & Interop - Define
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: Show :: Exception Form을 보여줍니다.

        /// <summary>
        /// Exception Form을 보여줍니다.
        /// </summary>
        /// <param name="ex"></param>
        public static void Show(Exception ex)
        {
            Show(null, ex);
        }

        /// <summary>
        /// Exception Form을 보여줍니다.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="ex"></param>
        public static void Show(Form owner, Exception ex)
        {
            Show(owner, ex, false);
        }

        /// <summary>
        /// Exception Form을 보여줍니다.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="ex"></param>
        /// <param name="isAdmin"></param>
        public static void Show(Form owner, Exception ex, bool isAdmin)
        {
            using (ExceptionDialog exForm = new ExceptionDialog())
            {
                try
                {
                    exForm.Except = ex;
                    exForm.Owner = owner;
                    exForm.IsAdmin = isAdmin;

                    DialogResult result = exForm.ShowDialog();

                    if (result == DialogResult.Abort)
                        Application.Exit();
                }
                finally
                {
                    exForm.Close();
                }
            }
        }

        #endregion
    }
}
