using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace EBAP.Win.Dialog
{
    /// <summary>
    /// MessageBox를 만듭니다.
    /// </summary>
    /// <remarks>
    /// 2023-02-01 최초생성 : 오인봉
    /// 변경내역
    /// 
    /// </remarks>
    public static class MsgBox
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 전역변수 ::

        const string DefaultCaption = "";
        const IWin32Window DefaultOwner = null;
        const MessageBoxButtons DefaultButtons = MessageBoxButtons.OK;
        const MessageBoxIcon DefaultIcon = MessageBoxIcon.None;
        const MessageBoxDefaultButton DefaultDefButton = MessageBoxDefaultButton.Button1;

        #endregion

        #region :: Show(+11 Overloading) :: MessageBox를 보여줍니다.

        /// <summary>
        /// MessageBox를 보여줍니다.
        /// </summary>
        /// <param name="text">보여질 Message</param>
        /// <returns></returns>
        public static DialogResult Show(string text)
        {
            return Show(DefaultOwner, text, DefaultCaption, DefaultButtons, DefaultIcon, DefaultDefButton);
        }

        /// <summary>
        /// MessageBox를 보여줍니다.
        /// </summary>
        /// <param name="text">보여질 Message</param>
        /// <param name="caption">MessageBox Caption</param>
        /// <returns></returns>
        public static DialogResult Show(string text, string caption)
        {
            return Show(DefaultOwner, text, caption, DefaultButtons, DefaultIcon, DefaultDefButton);
        }

        /// <summary>
        /// MessageBox를 보여줍니다.
        /// </summary>
        /// <param name="text">보여질 Message</param>
        /// <param name="caption">MessageBox Caption</param>
        /// <param name="buttons">Button 종류</param>
        /// <returns></returns>
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons)
        {
            return Show(DefaultOwner, text, caption, buttons, DefaultIcon, DefaultDefButton);
        }

        /// <summary>
        /// MessageBox를 보여줍니다.
        /// </summary>
        /// <param name="text">보여질 Message</param>
        /// <param name="caption">MessageBox Caption</param>
        /// <param name="buttons">Button 종류</param>
        /// <param name="icon">Icon 종류</param>
        /// <returns></returns>
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return Show(DefaultOwner, text, caption, buttons, icon, DefaultDefButton);
        }

        /// <summary>
        /// MessageBox를 보여줍니다.
        /// </summary>
        /// <param name="text">보여질 Message</param>
        /// <param name="caption">MessageBox Caption</param>
        /// <param name="buttons">Button 종류</param>
        /// <param name="icon">Icon 종류</param>
        /// <param name="defaultButton">처음에 Focuse를 가질 Button</param>
        /// <returns></returns>
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            return Show(DefaultOwner, text, caption, buttons, icon, defaultButton);
        }

        /// <summary>
        /// MessageBox를 보여줍니다.
        /// </summary>
        /// <param name="owner">Owner Form</param>
        /// <param name="text">보여질 Message</param>
        /// <param name="caption">MessageBox Caption</param>
        /// <param name="buttons">Button 종류</param>
        /// <param name="icon">Icon 종류</param>
        /// <param name="defaultButton">처음에 Focuse를 가질 Button</param>
        /// <returns></returns>
        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            return Show(null, owner, text, caption, MessageBoxButtonsToDialogResults(buttons), MessageBoxIconToIcon(icon), MessageBoxDefaultButtonToInt(defaultButton));
        }

        /// <summary>
        /// MessageBox를 보여줍니다.
        /// </summary>
        /// <param name="lookAndFeel"></param>
        /// <param name="owner">Owner Form</param>
        /// <param name="text">보여질 Message</param>
        /// <param name="caption">MessageBox Caption</param>
        /// <param name="buttons">Button 종류</param>
        /// <param name="icon">Icon 종류</param>
        /// <param name="defaultButton">처음에 Focuse를 가질 Button</param>
        /// <returns></returns>
        private static DialogResult Show(UserLookAndFeel lookAndFeel, IWin32Window owner, string text, string caption, DialogResult[] buttons, Icon icon, int defaultButton)
        {
            //AppearanceObject.DefaultFont = new Font("나눔고딕", 8.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            //XtraMessageBoxForm form = new XtraMessageBoxForm();
            //form.Appearance.Font = new Font("나눔고딕", 8.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            //if (caption == string.Empty) caption = AppConfig.SYSTEMNAME;
            if (caption == string.Empty) caption = "I2S";

            if (icon == null) icon = MessageBoxIconToIcon(MessageBoxIcon.Information);

            //return form.ShowMessageBoxDialog(new XtraMessageBoxArgs(lookAndFeel, owner, text, caption, buttons, icon, defaultButton));
            return XtraMessageBox.Show(new XtraMessageBoxArgs(lookAndFeel, owner, text, caption, buttons, icon, defaultButton));
        }

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: MessageBoxButtonsToDialogResults

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buttons"></param>
        /// <returns></returns>
        static DialogResult[] MessageBoxButtonsToDialogResults(MessageBoxButtons buttons)
        {
            if (!Enum.IsDefined(typeof(MessageBoxButtons), buttons))
            {
                throw new InvalidEnumArgumentException("buttons", (int)buttons, typeof(DialogResult));
            }
            switch (buttons)
            {
                case MessageBoxButtons.OK:
                    return new DialogResult[] { DialogResult.OK };
                case MessageBoxButtons.OKCancel:
                    return new DialogResult[] { DialogResult.OK, DialogResult.Cancel };
                case MessageBoxButtons.AbortRetryIgnore:
                    return new DialogResult[] { DialogResult.Abort, DialogResult.Retry, DialogResult.Ignore };
                case MessageBoxButtons.RetryCancel:
                    return new DialogResult[] { DialogResult.Retry, DialogResult.Cancel };
                case MessageBoxButtons.YesNo:
                    return new DialogResult[] { DialogResult.Yes, DialogResult.No };
                case MessageBoxButtons.YesNoCancel:
                    return new DialogResult[] { DialogResult.Yes, DialogResult.No, DialogResult.Cancel };
                default:
                    throw new ArgumentException("buttons");
            }
        }

        #endregion

        #region :: MessageBoxIconToIcon ::

        /// <summary>
        /// 
        /// </summary>
        /// <param name="icon"></param>
        /// <returns></returns>
        static Icon MessageBoxIconToIcon(MessageBoxIcon icon)
        {
            if (!Enum.IsDefined(typeof(MessageBoxIcon), icon))
            {
                throw new InvalidEnumArgumentException("icon", (int)icon, typeof(DialogResult));
            }
            switch (icon)
            {
                case MessageBoxIcon.None:
                    return null;
                case MessageBoxIcon.Error:
                    return SystemIcons.Error;
                case MessageBoxIcon.Exclamation:
                    return SystemIcons.Exclamation;
                case MessageBoxIcon.Information:
                    return SystemIcons.Information;
                case MessageBoxIcon.Question:
                    return SystemIcons.Question;
                default:
                    throw new ArgumentException("icon");
            }
        }

        #endregion

        #region :: MessageBoxDefaultButtonToInt ::

        /// <summary>
        /// 
        /// </summary>
        /// <param name="defButton"></param>
        /// <returns></returns>
        static int MessageBoxDefaultButtonToInt(MessageBoxDefaultButton defButton)
        {
            if (!Enum.IsDefined(typeof(MessageBoxDefaultButton), defButton))
            {
                throw new InvalidEnumArgumentException("defaultButton", (int)defButton, typeof(DialogResult));
            }
            switch (defButton)
            {
                case MessageBoxDefaultButton.Button1:
                    return 0;
                case MessageBoxDefaultButton.Button2:
                    return 1;
                case MessageBoxDefaultButton.Button3:
                    return 2;
                default:
                    throw new ArgumentException("defaultButton");
            }
        }

        #endregion
    }
}
