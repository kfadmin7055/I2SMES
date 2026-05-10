using System;
using System.Windows.Forms;

namespace EBAP.Core.Interface
{
    /// <summary>
    /// 메시지 박스와 Exception 박스를 설정하는 Interface 입니다.
    /// </summary>
    public interface IDialog
    {
        /// <summary>
        /// Exception Box를 보여줍니다.
        /// </summary>
        /// <param name="ex">Exception</param>
        void ShowExceptionBox(Exception ex);

        /// <summary>
        /// Wait Dialog를 보여줍니다.
        /// </summary>
        /// <param name="caption"></param>
        void ShowWaitDialog(string caption);

        /// <summary>
        /// Wait Dialog를 보여줍니다.
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="description"></param>
        void ShowWaitDialog(string caption, string description);

        /// <summary>
        /// Alert Message를 보여줍니다.
        /// </summary>
        /// <param name="caption">Alert Control Caption</param>
        /// <param name="text">Alert Message</param>
        /// <param name="hotTrackedText">Hot Tracked Text</param>
        void ShowAlertMessage(string caption, string text, string hotTrackedText);

        /// <summary>
        /// Wait Dialog를 닫습니다.
        /// </summary>
        void CloseWaitDialog();

        /// <summary>
        /// Flyout Dialog를 보여줍니다.
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="description"></param>
        void ShowFlyoutDialog(string caption, string description);

        /// <summary>
        /// MessageBox를 보여줍니다.
        /// </summary>
        /// <param name="text">Message</param>
        /// <returns></returns>
        DialogResult ShowMsgBox(string text);

        /// <summary>
        /// MessageBox를 보여줍니다.
        /// </summary>
        /// <param name="text">Message</param>
        /// <param name="caption">Caption</param>
        /// <returns></returns>
        DialogResult ShowMsgBox(string text, string caption);

        /// <summary>
        /// MessageBox를 보여줍니다.
        /// </summary>
        /// <param name="text">보여질 Message</param>
        /// <param name="caption">MessageBox Caption</param>
        /// <param name="buttons">Button 종류</param>
        /// <returns></returns>
        DialogResult ShowMsgBox(string text, string caption, MessageBoxButtons buttons);

        /// <summary>
        /// MessageBox를 보여줍니다.
        /// </summary>
        /// <param name="text">보여질 Message</param>
        /// <param name="caption">MessageBox Caption</param>
        /// <param name="buttons">Button 종류</param>
        /// <param name="icon">Icon 종류</param>
        /// <returns></returns>
        DialogResult ShowMsgBox(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon);

        /// <summary>
        /// MessageBox를 보여줍니다.
        /// </summary>
        /// <param name="text">보여질 Message</param>
        /// <param name="caption">MessageBox Caption</param>
        /// <param name="buttons">Button 종류</param>
        /// <param name="icon">Icon 종류</param>
        /// <param name="defaultButton">Default Button</param>
        /// <returns></returns>
        DialogResult ShowMsgBox(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton);
    }
}
