using EBAP.Exe.AutoUpdater.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EBAP.Exe.AutoUpdater
{
    internal class UpdateInfo
    {
        #region :: 전역변수 ::

        /// <summary>
        /// 사내, 외주를 구분합니다.
        /// </summary>
        internal static string CONNECTTYPE = string.Empty;
        /// <summary>
        /// IP를 저장합니다.
        /// </summary>
        internal static string IP = string.Empty;
        /// <summary>
        /// Dll이 저장될 Folder입니다.
        /// </summary>
        //internal static string assemblyFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), Settings.Default.SystemName);
        internal static string assemblyFolder = Path.Combine(Environment.GetLogicalDrives()[0], Settings.Default.SystemName);
        /// <summary>
        /// Download 이력을 저장할 XML 파일 위치입니다.
        /// </summary>
        internal static string xmlPath = Path.Combine(assemblyFolder, Settings.Default.XmlFileName);

        #endregion

        #region :: GetConnectType :: IP Address가 10. 일 경우 IntraNet 아닐 경우 DMZ로 구분

        /// <summary>
        /// IP Address가 192 일 경우 IntraNet 아닐 경우 DMZ로 구분
        /// </summary>
        /// <param name="ip">IP Address</param>
        /// <returns>사내일 경우 IntraNet, 사외일 경우 DMZ</returns>
        internal static string CheckConnectType(string ip)
        {
            if (ip.Length > 4)
            {
                if (ip.Substring(0, 5) == "10.8.")
                    CONNECTTYPE = "IntraNet";
                else
                    CONNECTTYPE = "DMZ";
            }
            else
                CONNECTTYPE = "";

            return CONNECTTYPE;
        }

        #endregion

        #region :: GetSHA256Hash :: 암호화 된 SHA5 Text를 가져옵니다.

        /// <summary>
        /// 암호화 된 MD5 Text를 가져옵니다..
        /// </summary>
        /// <param name="input">입력값</param>
        /// <returns></returns>
        internal static string GetSHA256Hash(string input)
        {
            SHA256Managed sha256 = new SHA256Managed();
            byte[] data = sha256.ComputeHash(Encoding.Default.GetBytes(input));

            StringBuilder sb = new StringBuilder();

            for (int idx = 0; idx < data.Length; idx++)
                sb.Append(data[idx].ToString("x2"));

            return sb.ToString();
        }

        #endregion
    }
}
