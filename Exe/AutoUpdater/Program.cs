using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;
using EBAP.Exe.AutoUpdater.Properties;

namespace EBAP.Exe.AutoUpdater
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MakeFolder();

            foreach (IPAddress address in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    UpdateInfo.IP = address.ToString();
                    break;
                }
            }

            UpdateInfo.CONNECTTYPE = UpdateInfo.CheckConnectType(UpdateInfo.IP);

            if (UpdateInfo.IP == string.Empty)
            {
                MessageBox.Show("IP 주소가 잘못되었습니다. 프로그램이 종료됩니다.");
                return;
            }

            if (UpdateInfo.CONNECTTYPE == "DMZ")
                Settings.Default.WebServiceURL = Settings.Default.DMZServiceURL;

            try
            {
                Process[] mainF = Process.GetProcessesByName(Settings.Default.ExeFile.Replace(".exe", ""));

                foreach (Process m in mainF)
                {
                    m.CloseMainWindow();
                    m.Kill();
                }

                using (Download down = new Download())
                {
                    if (down.checkDownloadAssembly() > 0)
                    {
                        down.Show();
                        down.Refresh();
                        down.DownloadAssembly();
                    }
                }

                string fileName = Path.Combine(UpdateInfo.assemblyFolder, Settings.Default.ExeFile);
                string arguments = UpdateInfo.GetSHA256Hash(Settings.Default.SystemName);

                ProcessStartInfo pInfo = new ProcessStartInfo() { FileName = fileName, Arguments = arguments };
                Process.Start(pInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception throw", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        static void MakeFolder()
        {
            DirectoryInfo dInfo = new DirectoryInfo(UpdateInfo.assemblyFolder);

            if (!dInfo.Exists)
                dInfo.Create();
        }
    }
}
