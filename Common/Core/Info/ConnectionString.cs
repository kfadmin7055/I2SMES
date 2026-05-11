namespace EBAP.Core.Info
{
    /// <summary>
    /// Web.config 의 ConnectionString과 Mapping 할 정보입니다.
    /// </summary>
    /// <remarks>
    /// 2023-02-01 최초생성 : 오인봉
    /// 변경내역
    /// 
    /// </remarks>
    public static class ConnectionString
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Database Connection String
        ///////////////////////////////////////////////////////////////////////////////////////////////    

        #region :: Database Name :: Web.config 의 ConnectionString과 Mapping 할 정보입니다.

        /// <summary>
        /// 기본적으로 사용할 Database입니다.
        /// Value : METADB
        /// </summary>
        public static string DEFAULTDB = "METADB";
        /// <summary>
        /// 기준정보 Database를 사용합니다.
        /// Value : "MetaDB"
        /// </summary>
        public static string METADB = "METADB";
        /// <summary>
        /// 기준정보 Oracle Database를 사용합니다.
        /// Value : "MetaDB"
        /// </summary>
        public static string ORAMESDB = "ORAMETADB";
        /// <summary>
        /// MES Database를 사용합니다.
        /// Value : "MES"
        /// </summary>
        public static string MESDB = "MESDB";
        /// <summary>
        /// LOG Database를 사용합니다.
        /// VALUE : LOGDB
        /// </summary>
        public static string LOGDB = "LOGDB";
        /// <summary>
        /// File DB를 사용합니다.
        /// Value : "FILEDB"
        /// </summary>
        public static string FILEDB = "FILEDB";

        #endregion
    }
}
