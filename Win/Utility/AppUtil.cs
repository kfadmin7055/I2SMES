using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using EBAP.Core;
using EBAP.Core.Info;
using EBAP.Win.Dialog;
using IWshRuntimeLibrary;

namespace EBAP.Win.Utility
{
    /// <summary>
    /// Application에서 사용할 Util Method를 정의합니다.
    /// </summary>
    /// <remarks>
    /// 2023-02-01 최초생성 : 오인봉
    /// 변경내역
    ///
    /// </remarks>
    public static class AppUtil
    {

        /// <summary>
        /// T를 생성합니다.
        /// </summary>
        /// <param name="dllPath">DLL 명</param>
        /// <param name="className">Class 명</param>
        /// <returns></returns>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        ///
        /// </remarks>
        public static T CreateInstance<T>(string dllPath, string className)
        {
            var assemblyFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dllPath);

            var assembly = Assembly.LoadFrom(assemblyFile);
            var formType = assembly.GetType(className);

            return (T)Activator.CreateInstance(formType);
        }

        /// <summary>
        /// Form의 Method를 실행합니다.
        /// </summary>
        /// <param name="form">Form</param>
        /// <param name="methodName">Method 이름</param>
        /// <returns></returns>
        public static object ExecuteMethod(Form form, string methodName)
        {
            return ExecuteMethod(form, methodName, null);
        }

        /// <summary>
        /// Form의 Method를 실행합니다.
        /// </summary>
        /// <param name="form">Form</param>
        /// <param name="methodName">Method 이름</param>
        /// <param name="methodParam">Method Parameters</param>
        /// <returns></returns>
        public static object ExecuteMethod(Form form, string methodName, object[] methodParam)
        {
            object obj;
            var mInfo = form.GetType().GetMethod(methodName);

            if (mInfo != null)
            {
                obj = mInfo.Invoke(form, methodParam);
            }
            else
            {
                obj = null;
            }
            return obj;
        }

        /// <summary>
        /// 지정한 형식의 Control을 찾습니다.
        /// </summary>
        /// <param name="ctrlList"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        public static void FindFocusedControl<T>(List<Control> ctrlList, Control control)
        {
            if (control.HasChildren)
            {
                foreach (Control ctrl in control.Controls)
                {
                    if ((ctrl is T) && (ctrl.Focused || ctrl.ContainsFocus))
                    {
                        ctrlList.Add(ctrl);
                        break;
                    }
                    FindFocusedControl<T>(ctrlList, ctrl);
                }
            }
        }

        /// <summary>
        /// 지정한 형식의 Control을 찾습니다.
        /// </summary>
        /// <param name="ctrlList"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        public static void FindControl<T>(List<Control> ctrlList, Control control)
        {
            if (control.HasChildren)
            {
                foreach (Control ctrl in control.Controls)
                {
                    if (ctrl is T)
                    {
                        ctrlList.Add(ctrl);
                    }
                    FindControl<T>(ctrlList, ctrl);
                }
            }
        }

        #region :: RemoveDataRow :: DataTable의 Columns에서 같은 값을 찾아 있으면 해당 Row를 삭제합니다.

        /// <summary>
        /// DataTable의 Columns에서 같은 값을 찾아 있으면 해당 Row를 삭제합니다.
        /// </summary>
        /// <param name="dt">해당 DataTable</param>
        /// <param name="column">해당 컬럼</param>
        /// <param name="value">찾을 값</param>
        public static void RemoveDataRow(DataTable dt, string column, object value)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (dr[column].ToString() == value.ToString())
                    dr.Delete();
            }
            dt.AcceptChanges();
        }

        #endregion

        /// <summary>
        /// File에서 Binary를 가져옵니다.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        ///
        /// </remarks>
        public static byte[] GetBinaryFromFile(string path)
        {
            try
            {
                byte[] fByte = null;

                using (var fStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    var bReader = new BinaryReader(fStream);
                    fByte = bReader.ReadBytes(Convert.ToInt32(fStream.Length));
                }

                return fByte;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// IP Address가 10. 으로 시작할 경우 IntraNet 아닐 경우 DMZ로 구분
        /// </summary>
        /// <param name="ip">IP Address</param>
        /// <returns>IntraNet, DMZ</returns>
        public static string CheckConnectType(string ip)
        {
            if (ip.Length > 4)
            {
                if (ip.Substring(0, 5).In("10.8.", "16.10"))
                    return "IntraNet";
                else
                    return "DMZ";
            }
            else
                return "";
        }

        /// <summary>
        /// Image를 가져옵니다.
        /// </summary>
        /// <param name="rootPath">Root Path</param>
        /// <param name="subPath">Sub Path</param>
        /// <param name="fileName">File 명</param>
        /// <returns></returns>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        ///
        /// </remarks>
        public static Image GetWebImage(string rootPath, string subPath, string fileName)
        {
            Image image = null;

            try
            {
                using (var webClient = new WebClient())
                {
                    var stream = webClient.OpenRead($"{rootPath}{subPath}/{fileName}");
                    image = Image.FromStream(stream);
                    stream.Dispose();
                }
            }
            catch
            {
                throw;
            }

            return image;
        }

        /// <summary>
        /// Image를 가져옵니다.
        /// </summary>
        /// <param name="fileName">File 명</param>
        /// <returns></returns>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        ///
        /// </remarks>
        public static Image GetImage(string fileName)
        {
            Image image = Image.FromFile(fileName);

            return image;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="form"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static Image FormToBitmap(Control form, Size size)
        {
            Size formSize = form.Size;
            Rectangle rect = new Rectangle(new Point(0, 0), formSize);

            Bitmap bitmap = new Bitmap(formSize.Width, formSize.Height);
            form.DrawToBitmap(bitmap, rect);

            Bitmap result = new Bitmap(size.Width, size.Height);
            Graphics g = Graphics.FromImage(result);
            rect.Size = size;
            g.DrawImage(bitmap, rect);

            return result;
        }

        /// <summary>
        /// Image를 가져옵니다.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Image GetImageFromBinary(byte[] data)
        {
            if (data == null || data.Length == 0) return null;

            MemoryStream ms = new MemoryStream(data);

            Image image = Image.FromStream(ms);

            return image;
        }

        /// <summary>
        /// Image를 가져옵니다.
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static Image GetImageFromStream(Stream stream)
        {
            if (stream == null) return null;

            Image image = Image.FromStream(stream);

            return image;
        }

        /// <summary>
        /// 빈공간의 파라미터를 만들때 사용합니다.
        /// </summary>
        /// <param name="length">파라미터 길이</param>
        /// <returns></returns>
        public static string GetBlankParam(int length)
        {
            var sb = new StringBuilder(length);

            for (var i = 0; i < length; i++)
                sb.Insert(i, "X");

            return sb.ToString();
        }

        /// <summary>
        /// 로컬 컴퓨터의 IP를 가져옵니다.
        /// </summary>
        /// <returns></returns>
        public static string GetIPAddress()
        {
            //Regex regex = new Regex(@"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$");

            string ip = "";
            foreach (IPAddress address in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    ip = address.ToString();

                    if (ip.Substring(0, 3) == "16.") return ip;
                }

                //if (regex.IsMatch(address.ToString()))
                //    return address.ToString();
            }

            return ip;
        }

        /// <summary>
        /// 로컬 컴퓨터의 MAC Address를 가져옵니다.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        ///
        /// </remarks>
        public static string GetMacAddress()
        {
            string macAddr = string.Empty;

            try
            {
                macAddr = NetworkInterface.GetAllNetworkInterfaces()[0].GetPhysicalAddress().ToString();
            }
            catch
            {
                macAddr = string.Empty;
            }

            return macAddr;
        }

        /// <summary>
        /// Folder Path를 확인하여 없으면 Folder를 만듭니다.
        /// </summary>
        /// <param name="path"></param>
        public static void CreateFolder(string path)
        {
            var dInfo = new DirectoryInfo(path);

            if (dInfo.Exists) return;

            dInfo.Create();
        }


        /// <summary>
        /// 파일 저장
        /// </summary>
        /// <param name="fStream"></param>
        /// <param name="fileContent"></param>
        public static void SaveFile(Stream fStream, byte[] fileContent)
        {
            fStream.Write(fileContent, 0, fileContent.Length);

            fStream.Close();
        }

        /// <summary>
        /// 파일 실행
        /// </summary>
        /// <param name="fileName">파일명</param>
        /// <param name="checkExecute">실행여부 확인</param>
        public static void OpenFile(string fileName, bool checkExecute = true)
        {
            if (checkExecute && MsgBox.Show("이 파일을 실행 하시겠습니까?", "File 실행 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = fileName;
                    process.StartInfo.Verb = "Open";
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                    process.Start();
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 파일 실행
        /// </summary>
        /// <param name="fileName">파일명</param>
        /// <param name="byteArray">파일 바이너리</param>
        public static void OpenFile(string fileName, byte[] byteArray)
        {
            fileName = Path.Combine(AppConfig.DOWNLOADFOLDER, fileName.Trim());

            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                fs.Write(byteArray, 0, byteArray.Length);
                fs.Close();
            }

            using (Process process = new Process())
            {
                process.StartInfo.FileName = fileName;
                process.StartInfo.Verb = "Open";
                process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                process.Start();
            }
        }

        /// <summary>
        /// Excel에서 DataTable을 추출합니다.
        /// </summary>
        /// <param name="sheetName">Sheet 이름(대소문자 구분 필수)</param>
        /// <returns></returns>
        /// <remarks>
        /// 2017-10-17 최초생성 : 오인봉
        /// 변경내역
        ///
        /// </remarks>
        public static DataTable GetExcelUploadData(string sheetName)
        {
            try
            {
                DataTable dataTable = new DataTable();

                //using (XtraOpenFileDialog ofd = new XtraOpenFileDialog { Title = "업로드 파일 찾기" })
                using (OpenFileDialog ofd = new OpenFileDialog { Title = "업로드(Excel) 파일 찾기" })
                {
                    if (ofd.ShowDialog() != DialogResult.OK) return null;

                    string connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", ofd.FileName);

                    OleDbConnection xlsCon = new OleDbConnection(connectionString);

                    if (xlsCon.State == ConnectionState.Open) xlsCon.Close();

                    xlsCon.Open();

                    OleDbDataAdapter adapter = new OleDbDataAdapter(String.Format("SELECT * FROM [{0}$]", sheetName), xlsCon);
                    adapter.Fill(dataTable);

                    if (xlsCon.State == ConnectionState.Open) xlsCon.Close();
                }

                return dataTable;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// CVS에서 DataTable을 추출합니다.
        /// </summary>
        /// <param name="filePath">파일 경로</param>
        /// <param name="isFirstRowHeader">첫번째 행 이름 사용 여부</param>
        /// 
        /// <returns></returns>
        /// <remarks>
        /// 2017-10-17 최초생성 : 오인봉
        /// 변경내역
        ///
        /// </remarks>
        public static DataTable GetCVSUploadData(string filePath, bool isFirstRowHeader = true)
        {
            try
            {
                DataTable dataTable = new DataTable();

                string directoryName = Path.GetDirectoryName(filePath);
                string fileName = Path.GetFileName(filePath);
                string hdr = isFirstRowHeader ? "Yes" : "No";

                string connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0}; Extended Properties=\"Text;HDR={1}\"", directoryName, hdr);

                OleDbConnection cvsCon = new OleDbConnection(connectionString);

                if (cvsCon.State == ConnectionState.Open) cvsCon.Close();

                cvsCon.Open();

                OleDbDataAdapter adapter = new OleDbDataAdapter(String.Format(@"SELECT * FROM [{0}]", fileName), cvsCon);
                adapter.Fill(dataTable);

                if (cvsCon.State == ConnectionState.Open) cvsCon.Close();

                return dataTable;
            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// 바탕화면에 바로가기를 만듭니다.
        /// </summary>
        /// <param name="shortcutName">바로가기 이름</param>
        /// <param name="targetPath">바로가기 경로(전체)</param>
        public static void MakeShortCut(string shortcutName, string targetPath)
        {
            string desktopDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string shortCutFileName = Path.Combine(desktopDir, $"{shortcutName}.lnk");
            FileInfo shortcutFile = new FileInfo(shortCutFileName);

            if (shortcutFile.Exists) return;

            try
            {
                WshShell wsh = new WshShell();
                IWshShortcut link = wsh.CreateShortcut(shortcutFile.FullName);
                //link.TargetPath = Path.Combine(AppConfig.ASSEMBLYFOLDER, @"EBAP.Exe.AutoUpdater.exe");
                link.TargetPath = targetPath;

                link.Save();
            }
            catch
            {

            }
        }


        /// <summary>
        /// 숫자를 한글로 변환합니다.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string N2H(long number)
        {
            string numToKor = "";

            string[] numHans = new string[] { "", "일", "이", "삼", "사", "오", "육", "칠", "팔", "구" };
            string[] levels = new string[] { "", "십", "백", "천" };
            string[] decimals = new string[] { "", "만", "억", "조", "경" };

            string minusHan = "";

            if (number < 0) minusHan = "마이너스 ";

            string strVal = string.Format("{0}", number);
            bool useDecimal = false;

            if (number == 0) return "영";

            for (int i = 0; i < strVal.Length; i++)
            {
                int lvl = strVal.Length - i;

                if (strVal.Substring(i, 1) != "0")
                {
                    useDecimal = true;
                    if ((lvl - 1) % 4 == 0)
                    {
                        if (decimals[(lvl - 1) % 4] != string.Empty && strVal.Substring(i, 1) == "1")
                            numToKor += decimals[(lvl - 1) / 4];
                        else
                            numToKor += numHans[Convert.ToInt32(strVal.Substring(i, 1))] + decimals[(lvl - 1) / 4];

                        useDecimal = false;
                    }
                    else
                    {
                        if (strVal.Substring(i, 1) == "1")
                            numToKor += levels[(lvl - 1) % 4];
                        else
                            numToKor += numHans[Convert.ToInt32(strVal.Substring(i, 1))] + levels[(lvl - 1) % 4];
                    }
                }
                else
                {
                    if (lvl % 4 == 0 && useDecimal)
                    {
                        numToKor += decimals[lvl / 4];
                        useDecimal = false;
                    }
                }
            }

            return minusHan + numToKor;
        }

        /// <summary>
        /// 인터넷 시간 동기화
        /// 클라이언트에 W32Time 서비스가 실행되지 않을 때 실행되지 않음
        /// 확인 방법 필요함
        /// </summary>
        public static void TimeSynchronize()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo() { FileName = "net", Arguments = "start w32time", CreateNoWindow = true, UseShellExecute = false };

            Process process = Process.Start(startInfo);
            process.WaitForExit();
            process.Close();

            startInfo.FileName = "net";
            startInfo.Arguments = @"time /setsntp:time.nuri.net";

            process = Process.Start(startInfo);
            process.WaitForExit();
            process.Close();

            startInfo.FileName = "w32tm";
            startInfo.Arguments = "/resync";

            process = Process.Start(startInfo);
            process.WaitForExit();
            process.Close();
        }

        /// <summary>
        /// 문자 증가
        /// </summary>
        /// <param name="ichar"></param>
        /// <param name="sValue"></param> 
        /// /// <param name="endSeq"></param>
        /// <returns></returns>
        public static string GetASCValue(int ichar, string sValue = "A", int endSeq = 0)
        {
            string returnValue = null;

            if (endSeq > 0 && ichar > endSeq)
            {
                return "";
            }

            int iDec = (char)(Convert.ToChar(sValue) + ichar);

            // Z 초과 시 returnValue 에 A 부터 증가
            if (iDec > 90)
            {
                decimal dValue = ichar / 26;
                int iCuttingValue = (int)Math.Floor(dValue);

                returnValue = ((char)(64 + iCuttingValue)).ToString();

                ichar = ichar - (26 * iCuttingValue);
            }

            returnValue += ((char)(Convert.ToChar(sValue) + ichar)).ToString();

            return returnValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="e"></param>
        /// <returns></returns>
        public static T StringToEnum<T>(string e)
        {
            return (T)Enum.Parse(typeof(T), e);
        }
    }
}
