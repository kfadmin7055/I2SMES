using DevExpress.XtraPrinting.Preview;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBAP.Win.ControlLibrary
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(true)]
    public partial class PPrintControl : DevExpress.XtraPrinting.Control.PrintControl
    {
        /// <summary>
        /// 
        /// </summary>
        public PrintBarManager fPrintBarManager;

        /// <summary>
        /// 
        /// </summary>
        public PPrintControl()
        {
            InitializeComponent();
            fPrintBarManager = CreatePrintBarManager();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private PrintBarManager CreatePrintBarManager()
        {
            PrintBarManager pManager = new PrintBarManager
            {
                Form = this
            };
            pManager.Initialize(this);
            pManager.MainMenu.Visible = false;
            pManager.AllowCustomization = false;
            return pManager;
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="report"></param>
        //public void CreateReport(XtraReport report)
        //{
        //    report.PrintingSystem.ClearContent();
        //    Invalidate();
        //    Update();
        //    PrintingSystem = report.PrintingSystem;
        //    report.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ClosePreview, DevExpress.XtraPrinting.CommandVisibility.None);
        //    report.CreateDocument(true);
        //}

    }
}
