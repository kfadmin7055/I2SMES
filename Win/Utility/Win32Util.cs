using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace EBAP.Win.Utility
{
    /// <summary>
    /// Application에서 사용할 Win32 Util Method를 정의합니다.
    /// </summary>
    /// <remarks>
    /// 2016-06-17 최초생성 : 오인봉
    /// 변경내역
    ///
    /// </remarks>
    public class Win32Util
    {
        /// <summary>
        /// RESTORE입니다.
        /// </summary>
        public const int SW_RESTORE = 9;

        /// <summary>
        ///
        /// </summary>
        /// <param name="section"></param>
        /// <param name="keyName"></param>
        /// <param name="value"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern bool WritePrivateProfileString(string section, string keyName, string value, string filePath);

        /// <summary>
        ///
        /// </summary>
        /// <param name="section"></param>
        /// <param name="keyName"></param>
        /// <param name="defaultValue"></param>
        /// <param name="returnString"></param>
        /// <param name="size"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string keyName, string defaultValue, StringBuilder returnString, int size, string filePath);

        [DllImport("kernel32.dll")]
        private static extern bool SetLocalTime(ref SYSTEMTIME time);

        /// <summary>
        /// 
        /// </summary>
        [StructLayoutAttribute(LayoutKind.Sequential)]
        private struct SYSTEMTIME
        {
            public short Year;
            public short Month;
            public short DayOfWeek;
            public short Day;
            public short Hour;
            public short Minute;
            public short Second;
            public short Milliseconds;
        }

        /// <summary>
        /// 시스템 시간을 변경합니다.
        /// </summary>
        /// <param name="dt">변경할 시간</param>
        /// <returns>시스템 시간 변경 여부</returns>
        public static bool ChangeTime(DateTime dt)
        {
            bool bRtv = false;

            SYSTEMTIME st;

            st.Year = (short)dt.Year;
            st.Month = (short)dt.Month;
            st.DayOfWeek = (short)dt.DayOfWeek;       // 0 : 일요일 1 : 월요일 2 : 화요일 3 : 수요일 4 : 목요일 5 : 금요일 6 : 토요일
            st.Day = (short)dt.Day;
            st.Hour = (short)dt.Hour;
            st.Minute = (short)dt.Minute;
            st.Second = (short)dt.Second;
            st.Milliseconds = (short)dt.Millisecond;

            bRtv = SetLocalTime(ref st); ;    // UTC+0 시간을 설정한다.

            return bRtv;
        }

        /// <summary>
        /// 해당 윈도우의 최소화 여부를 리턴합니다.
        /// </summary>
        /// <param name="hWnd">해당 윈도우 핸들</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool IsIconic(IntPtr hWnd);

        /// <summary>
        ///
        /// </summary>
        /// <param name="lpdwFlags"></param>
        /// <param name="dwReserved"></param>
        /// <returns></returns>
        [DllImport("WININET", CharSet = CharSet.Auto)]
        public static extern bool InternetGetConnectedState(ref InternetConnectionState lpdwFlags, int dwReserved);

        /// <summary>
        /// Play Sound
        /// </summary>
        /// <param name="szPath"></param>
        /// <param name="hModule"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        [DllImport("coredll.dll")]
        public static extern int PlaySound(string szPath, IntPtr hModule, int flags);

        /// <summary>
        /// 해당 핸들의 윈도우를 가장 앞으로 설정합니다.
        /// </summary>
        /// <param name="hWnd">윈도우 핸들</param>
        /// <returns>성공 여부</returns>
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// Show Window의 비동기 메서드입니다.
        /// </summary>
        /// <param name="hWnd">윈도우 핸들입니다.</param>
        /// <param name="nCmdShow">ShowWindow 동작입니다.</param>
        /// <returns>성공 여부</returns>
        [DllImport("user32.dll")]
        public static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        /// <summary>
        /// 설정을 Ini 파일에서 가져옵니다.
        /// </summary>
        /// <param name="filePath">파일 경로</param>
        /// <param name="section">Section</param>
        /// <param name="keyName">Key</param>
        /// <returns></returns>
        public static string GetIniValue(string filePath, string section, string keyName)
        {
            return GetIniValue(filePath, section, keyName, string.Empty);
        }

        /// <summary>
        /// 설정을 Ini 파일에서 가져옵니다.
        /// </summary>
        /// <param name="filePath">파일 경로</param>
        /// <param name="section">Section</param>
        /// <param name="keyName">Key</param>
        /// <param name="defautValue">기본값</param>
        /// <returns></returns>
        public static string GetIniValue(string filePath, string section, string keyName, string defautValue)
        {
            var sb = new StringBuilder(255);
            GetPrivateProfileString(section, keyName, defautValue, sb, 255, filePath);

            return sb.ToString().Length < 1 ? defautValue : sb.ToString();
        }

        /// <summary>
        /// 설정을 Ini 파일에 저장합니다.
        /// </summary>
        /// <param name="filePath">파일 경로</param>
        /// <param name="section">Section</param>
        /// <param name="keyName">Key</param>
        /// <param name="value">저장 값</param>
        public static void SetIniValue(string filePath, string section, string keyName, string value)
        {
            WritePrivateProfileString(section, keyName, value, filePath);
        }
    }
}
