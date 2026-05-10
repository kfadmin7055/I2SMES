using DevExpress.Utils.Localization;
using EBAP.Core.Info;
using EBAP.Core.Security;
using EBAP.Win.Dialog;
using EBAP.Win.Utility;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace EBAP.Exe.MainUI
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                //string cap = Cryptography.GetMD5Hash(AppConfig.SYSTEMNAME);
                Font defaultFont = new Font("나눔고딕", 8.75F);
                DevExpress.Utils.AppearanceObject.DefaultFont = defaultFont;

                string CONNECTTYPE = AppUtil.CheckConnectType(AppUtil.GetIPAddress());

                if (CONNECTTYPE == "DMZ") AppConfig.WEBSERVICEURL = AppConfig.DMZSERVICEURL;

                if (args.Length > 0 && Cryptography.ValidateSHA256Hash(AppConfig.SYSTEMNAME, args[0]))
                {
                    MakeFolder();
                    MoveUpdateFile();

                    frmMain form;

                    if (args.Length == 1)
                        form = new frmMain();
                    else if (args.Length == 2)
                        form = new frmMain(args[1]);
                    else
                        form = new frmMain();

                    form.Appearance.Font = defaultFont;

                    string targetPath = Path.Combine(AppConfig.ASSEMBLYFOLDER, @"EBAP.Exe.AutoUpdater.exe");

                    AppUtil.MakeShortCut(@"EBAP-CORE", targetPath);

                    //운영 개발 웹서비스 설정하려면 아래 주석을 제거하고 내용을 입력하세요.                    
                    //form.SetWebserviceURL(AppConfig.WEBSERVICEURL, @"http://127.0.0.1/EBAPService/");

                    Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                    //XtraLocalizer.EnableTraceSource();
                    Application.Run(form);
                }
                else
                {
                    MsgBox.Show("잘못된 접근방식입니다. 프로그램이 종료됩니다.", "접근 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                ExceptionBox.Show(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            ExceptionBox.Show(e.Exception);
        }

        /// <summary>
        /// 
        /// </summary>
        static void MakeFolder()
        {
            AppUtil.CreateFolder(AppConfig.ASSEMBLYFOLDER);
            AppUtil.CreateFolder(AppConfig.SETTINGFOLDER);
            AppUtil.CreateFolder(AppConfig.GRIDLAYOUTFOLDER);
            AppUtil.CreateFolder(AppConfig.LOCALEFOLDER);
            AppUtil.CreateFolder(AppConfig.DOWNLOADFOLDER);
        }

        /// <summary>
        /// 
        /// </summary>
        static void MoveUpdateFile()
        {
            const string updaterName = @"EBAP.Exe.AutoUpdater.exe";
            string targetName = Path.Combine(AppConfig.ASSEMBLYFOLDER, updaterName);
            string sourceName = targetName + DateTime.Now.ToString("yyyyMMdd");

            if (!System.IO.File.Exists(sourceName)) return;

            try
            {
                System.IO.File.Delete(targetName);
                System.IO.File.Move(sourceName, targetName);
            }
            catch
            {

            }
        }
    }
}
