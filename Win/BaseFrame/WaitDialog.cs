using DevExpress.XtraWaitForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EBAP.Win.BaseFrame
{
    /// <summary>
    ///
    /// </summary>
    public partial class WaitDialog : WaitForm
    {
        /// <summary>
        ///
        /// </summary>
        public WaitDialog()
        {
            InitializeComponent();
            progressPanel.AutoHeight = true;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="caption"></param>
        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            progressPanel.Caption = caption;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="description"></param>
        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            progressPanel.Description = description;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="arg"></param>
        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        /// <summary>
        ///
        /// </summary>
        public enum WaitFormCommand
        {
        }
    }
}