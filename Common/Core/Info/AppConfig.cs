using System;
using System.Drawing;
using System.IO;

namespace EBAP.Core.Info
{
    /// <summary>
    /// System에서 공통으로 사용할 Configuration을 담당하는 Class 입니다.
    /// </summary>
    /// <remarks>
    /// 2023-02-01 최초생성 : 오인봉
    /// 변경내역
    /// 
    /// </remarks>
    public static class AppConfig
    {
        #region :: SYSTEMNAME :: System 이름입니다.

        /// <summary>
        /// System 이름입니다.
        /// Value : "EBAP™"
        /// </summary>
        public const string SYSTEMNAME = "EBAP-CORE.NET";

        /// <summary>
        /// ComboBox 에서 사용할 ValueMember
        /// Value : "CODEVALUE"
        /// </summary>
        public const string VALUEMEMBER = "CODEVALUE";

        /// <summary>
        /// ComboBox 에서 사용할 DisplayMember
        /// Value : "DISPLAYVALUE"
        /// </summary>
        public const string DISPLAYMEMBER = "DISPLAYVALUE";

        /// <summary>
        /// Default Plant 입니다.
        /// Value : "POOO"
        /// </summary>
        public const string DEFAULTPLANT = "P000";

        /// <summary>
        /// DB에 오늘 날짜로 변경할 컬럼 명
        /// Value : "CHANGEDTTM"
        /// </summary>
        public const string DATECOLUMNNAME = "CHANGEDTTM";

        /// <summary>
        /// DB에 현재 사용자로 변경할 컬럼 명
        /// Value : "CHANGEBY"
        /// </summary>
        public const string USERCOLUMNNAME = "CHANGEBY";

        #endregion

        #region :: SETTINGFILEPATH :: 사용자 정보(ini) File을 저장할 경로입니다.

        /// <summary>
        /// Assembly가 저장될 Folder
        /// VALUE : Path.Combine(Environment.GetLogicalDrives()[0], SYSTEMNAME)
        /// </summary>
        //public static string ASSEMBLYFOLDER = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), SYSTEMNAME);
        public static string ASSEMBLYFOLDER = Path.Combine(Environment.GetLogicalDrives()[0], SYSTEMNAME);

        /// <summary>
        /// Setting Filter이 저장될 Folder
        /// Value : Path.Combine(ASSEMBLYFOLDER, "Setting")
        /// </summary>
        public static string SETTINGFOLDER = Path.Combine(ASSEMBLYFOLDER, "Setting");

        /// <summary>
        /// Grid Layout XML이 저장될 Folder
        /// VALUE : Path.Combine(ASSEMBLYFOLDER, "GridLayout")
        /// </summary>
        public static string GRIDLAYOUTFOLDER = Path.Combine(ASSEMBLYFOLDER, "GridLayout");

        /// <summary>
        /// Grid Layout XML이 저장될 Folder
        /// VALUE : Path.Combine(ASSEMBLYFOLDER, "Download")
        /// </summary>
        public static string DOWNLOADFOLDER = Path.Combine(ASSEMBLYFOLDER, "Download");

        /// <summary>
        /// 다국어 XML이 저장될 Folder
        /// VALUE : Path.Combine(ASSEMBLYFOLDER, "Locale")
        /// </summary>
        public static string LOCALEFOLDER = Path.Combine(ASSEMBLYFOLDER, "Locale");

        /// <summary>
        /// 사용자 정보(ini) File을 저장할 경로입니다.
        /// Value : Path.Combine(SETTINGFOLDER, "BaseSettings.ini")
        /// </summary>
        public static string SETTINGFILEPATH = Path.Combine(SETTINGFOLDER, "BaseSettings.ini");

        /// <summary>
        /// Locale Master의 저장 Path
        /// VALUE : Path.Combine(LOCALEFOLDER, "LocaleMaster.xml")
        /// </summary>
        public static string LOCALEXMLPATH = Path.Combine(LOCALEFOLDER, "LocaleMaster.xml");

        /// <summary>
        /// Locale Message Master의 저장 Path
        /// VALUE : Path.Combine(LOCALEFOLDER, "MessageMaster.xml")
        /// </summary>
        public static string MESSAGEXMLPATH = Path.Combine(LOCALEFOLDER, "MessageMaster.xml");

        #endregion

        #region :: CHECKCOLUMNNAME :: GridView에서 사용할 기본 Check Column 명입니다.

        /// <summary>
        /// GridView에서 사용할 기본 Check Column 명입니다.
        /// Value : "isCheck"
        /// </summary>
        public const string CHECKCOLUMNNAME = "isCheck";

        #endregion

        #region :: DEFAULTDATEFORMAT :: 시스템에서 사용할 기본 Date Format입니다.

        /// <summary>
        /// 시스템에서 사용할 기본 Date Format입니다.
        /// VALUE : AppConfig.DEFAULTDATEFORMAT
        /// </summary>
        public const string DEFAULTDATETIMEFORMAT = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// 시스템에서 사용할 기본 Date Format입니다.
        /// VALUE : AppConfig.DEFAULTDATEFORMAT
        /// </summary>
        public const string DEFAULTDATEFORMAT = "yyyy-MM-dd";

        #endregion

        #region :: WEBSERVICEURL :: 사용할 Web Service의 주소입니다.

        /// <summary>
        /// 사용할 Web Service의 주소입니다.
        /// </summary>
        public static string WEBSERVICEURL = @"http://127.0.0.1/EBAPService/";
        //public static string WEBSERVICEURL = @"http://localhost:61200/";
        /// <summary>
        /// DMZ Web Service의 주소입니다.
        /// </summary>
        public static string DMZSERVICEURL = @"http://127.0.0.1/EBAPService/";

        //public static string WEBSERVICEURL = @"http://localhost:16817/";

        #endregion

        #region :: Command Type :: StoredProcedure, Text

        /// <summary>
        /// Sql Command에 StoredProcedure를 사용합니다.
        /// Value : "StoredProcedure"
        /// </summary>
        public const string COMMANDSP = "StoredProcedure";
        /// <summary>
        /// Sql Command에 Text를 사용합니다.
        /// Value : "Text"
        /// </summary>
        public const string COMMANDTEXT = "Text";

        #endregion

        #region :: Font And Color, Width, Height ::

        /// <summary>
        /// 
        /// </summary>
        //public static readonly Color CONDITIONCOLOR = Color.FromArgb(30, 228, 150, 181);
        public static Color CONDITIONCOLOR = Color.FromArgb(30, 255, 140, 0);

        #endregion
    }
}
