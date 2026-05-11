namespace EBAP.Core.Info
{
    /// <summary>
    /// DB Type
    /// </summary>
    public enum DB_TYPE
    {
        ORACLE,
        MSSQL
    }

    /// <summary>
    /// 
    /// </summary>
    public static class clsDBHelper
    {
        public static DB_TYPE GetDBType(string connName)
        {
            if (connName == ConnectionString.ORAMESDB)
            {
                return DB_TYPE.ORACLE;
            }

            if (connName == ConnectionString.METADB ||
                connName == ConnectionString.LOGDB ||
                connName == ConnectionString.FILEDB)
            {
                return DB_TYPE.MSSQL;
            }

            return DB_TYPE.MSSQL;
        }
    }
}
