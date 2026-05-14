using System.Data;
using EBAP.Business.WSBiz;
using EBAP.Core.Collections;
using EBAP.Core.Info;
using I2S.SQL.COMMON.DATA.OraData.Base;
using I2S.SQL.COMMON.DATA.OraData.Item;

namespace EBAP.Data.CodeUtil
{
    /// <summary>
    /// 시스템에서 공통으로 사용할 Code Util Method를 정의합니다.
    /// </summary>
    /// <remarks>
    /// 2016-06-17 최초생성 : 오인봉
    /// 변경내역
    /// EBAP.Data.CodeUtil.AppCode
    /// </remarks>
    public static class AppCode
    {
        #region :: GetCodes :: Code Master를 가져옵니다.

        /// <summary>
        /// Code Master
        /// </summary>
        /// <param name="queryId">쿼리 ID</param>
        /// <param name="paramList">Param Names</param>
        /// <param name="valueList">Param Values</param>
        /// <returns></returns>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public static DataTable GetCodes(string queryId, string[] paramList, object[] valueList)
        {
            DataTable dt;

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                dt = wb.NTx_ExecuteDataSetFromQueryId(queryId, paramList, valueList).Tables[0];
            }

            return dt;
        }

        #endregion

        #region :: GetCodeMaster :: Code Master를 가져옵니다.

        /// <summary>
        /// Code Master
        /// </summary>
        /// <param name="pCodeValue">대구분 코드</param>
        /// <param name="codeValue">소구분 코드</param>
        /// <param name="includedisplay">Code View 여부</param>
        /// <returns></returns>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public static DataTable GetCodeMaster(string pCodeValue, string codeValue, string includedisplay = "N")
        {
            DataTable dt;

            const string queryId = @"dbo.CodeMaster_Get";

            string[] paramList = new string[] { "@PCODEVALUE", 
                                                "@CODEVALUE",
                                                "@INCLUDEDISPLAY" };

            object[] valueList = new object[] { pCodeValue,
                                                codeValue,
                                                includedisplay };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                dt = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList).Tables[0];
            }

            return dt;
        }

        #endregion

        #region :: GetCodeMasterMES :: MES Code Master를 가져옵니다.

        /// <summary>
        /// upQComboList의 콤보 생성 마스터
        /// </summary>
        /// <param name="ListGubun"></param>
        /// <param name="Plant"></param>
        /// <param name="Line"></param>
        /// <param name="Factory"></param>
        /// <param name="Value"></param>
        /// <param name="vendorcode"></param>
        /// <returns></returns>
        public static DataTable GetCodeMasterMES(string ListGubun, string Plant, string Line, string Factory, string Value, string vendorcode)
        {
            DataTable dt = null;

            const string queryId = @"dbo.upQComboList";

            string[] paramList = new string[] { "@i_ListGubun", 
                                                "@i_Plant",
                                                "@i_Line",
                                                "@i_Factory",
                                                "@i_Value",
                                                "@i_Vendorcode"};

            object[] valueList = new object[] { ListGubun,
                                                Plant,
                                                Line, 
                                                Factory,
                                                Value,
                                                vendorcode };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                dt = wb.NTx_ExecuteDataSet(ConnectionString.MESDB, queryId, AppConfig.COMMANDSP, paramList, valueList).Tables[0];
            }

            return dt;
        }

        #endregion

        #region :: GetServerID :: Server ID 를 가져옵니다.

        /// <summary>
        /// Server ID 를 가져옵니다.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 2016-06-25 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public static DataTable GetServerID()
        {
            DataTable dt;

            const string queryId = @"dbo.ServerID_Get";

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                dt = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, null, null).Tables[0];
            }

            return dt;
        }

        #endregion

        #region :: GetDatabaseID :: Database ID 를 가져옵니다.

        /// <summary>
        /// Database ID 를 가져옵니다.
        /// </summary>
        /// <param name="server_id">서버 ID</param>
        /// <returns></returns>
        /// <remarks>
        /// 2016-06-25 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public static DataTable GetDatabaseID(int server_id)
        {
            DataTable dt;

            const string queryId = @"dbo.DatabaseID_Get";
            
            string[] paramList = new string[] { "@server_id" };
            object[] valueList = new object[] { server_id };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                dt = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList).Tables[0];
            }

            return dt;
        }

        #endregion

        #region :: GetTableID :: Table ID 를 가져옵니다.

        /// <summary>
        /// Table ID 를 가져옵니다.
        /// </summary>
        /// <param name="server_id">서버 ID</param>
        /// <param name="database_id">Database ID</param>
        /// <returns></returns>
        /// <remarks>
        /// 2016-06-25 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public static DataTable GetTableID(int server_id, int database_id)
        {
            DataTable dt;

            const string queryId = @"dbo.TableID_Get";

            string[] paramList = new string[] { "@server_id",
                                                "@database_id" };
            object[] valueList = new object[] { server_id,
                                                database_id };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                dt = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList).Tables[0];
            }

            return dt;
        }

        #endregion

        #region :: GetDatabaseLogEvent :: Database Log의 Event 를 가져옵니다.

        /// <summary>
        /// Database Log의 Event 를 가져옵니다.
        /// </summary>
        /// <param name="server_id">서버 ID</param>
        /// <param name="database_id">Database ID</param>
        /// <returns></returns>
        /// <remarks>
        /// 2016-06-25 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public static DataTable GetDatabaseLogEvent(int server_id, int database_id)
        {
            DataTable dt;

            const string queryId = @"dbo.DatabaseLogEvent_Get";

            string[] paramList = new string[] { "@server_id",
                                                "@database_id" };

            object[] valueList = new object[] { server_id,
                                                database_id };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                dt = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList).Tables[0];
            }

            return dt;
        }

        #endregion

        #region :: GetDatabaseLogObject :: Database Log의 Object 를 가져옵니다.

        /// <summary>
        /// Database Log의 Object 를 가져옵니다.
        /// </summary>
        /// <param name="server_id">서버 ID</param>
        /// <param name="database_id">Database ID</param>
        /// <returns></returns>
        /// <remarks>
        /// 2016-06-25 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public static DataTable GetDatabaseLogObject(int server_id, int database_id)
        {
            DataTable dt;

            const string queryId = @"dbo.DatabaseLogObject_Get";

            string[] paramList = new string[] { "@server_id",
                                                "@database_id" };

            object[] valueList = new object[] { server_id,
                                                database_id };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                dt = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList).Tables[0];
            }

            return dt;
        }

        #endregion

        #region :: GetDatabaseLogObjectType :: Database Log의 Object Type 을 가져옵니다.

        /// <summary>
        /// Database Log의 Object Type 을 가져옵니다.
        /// </summary>
        /// <param name="server_id">서버 ID</param>
        /// <param name="database_id">Database ID</param>
        /// <returns></returns>
        /// <remarks>
        /// 2016-06-25 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public static DataTable GetDatabaseLogObjectType(int server_id, int database_id)
        {
            DataTable dt;

            const string queryId = @"dbo.DatabaseLogObjectType_Get";

            string[] paramList = new string[] { "@server_id",
                                                "@database_id" };

            object[] valueList = new object[] { server_id,
                                                database_id };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                dt = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList).Tables[0];
            }

            return dt;
        }

        #endregion

        #region :: GetFileID :: FileID 를 가져옵니다.

        /// <summary>
        /// FileID 를 가져옵니다.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 2024-01-04 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public static DataTable GetFileID()
        {
            DataTable dt;

            const string queryId = @"dbo.FileID_Get";

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                dt = wb.NTx_ExecuteDataSet(ConnectionString.FILEDB, queryId, AppConfig.COMMANDSP, null, null).Tables[0];
            }

            return dt;
        }

        #endregion

        #region :: GetFileConents :: DB에서 FILE 컨텐츠를 가져옵니다.

        /// <summary>
        /// DB에서 FILE 컨텐츠를 가져옵니다.
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public static object GetFileConents(string fileId)
        {
            object obj;

            const string queryId = @"dbo.FileContent_Get";

            ParamCollection param = new ParamCollection();
            param.Add("@FILEID", fileId);

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                obj = wb.NTx_ExecuteScalar(ConnectionString.FILEDB, queryId, AppConfig.COMMANDSP, param);
            }

            return obj;
        }

        #endregion

        #region :: GetAssemblyID :: AssemblyID 를 가져옵니다.

        /// <summary>
        /// AssemblyID 를 가져옵니다.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 2010-11-24 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public static DataTable GetAssemblyID()
        {
            DataTable dt;

            const string queryId = @"dbo.AssemblyID_Get";

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                dt = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, null, null).Tables[0];
            }

            return dt;
        }

        #endregion

        #region :: GetVendorCode :: Vendor Code를 가져옵니다.

        /// <summary>
        /// Vendor Code를 가져옵니다.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetVendorCode(string userid)
        {
            DataTable dt;
            const string queryId = @"dbo.VendorAuth_Get";

            string[] paramList = new string[] { "@USERID" };
            object[] valueList = new object[] { userid };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                dt = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList).Tables[0];
            }

            return dt;
        }

        #endregion

        #region :: GetPlantCode :: Vendor에 맞는 Plant Code를 가져옵니다.

        /// <summary>
        /// Vendor에 맞는 Plant Code를 가져옵니다.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetPlantCode(string userid)
        {
            DataTable dt;
            const string queryId = @"dbo.PlantAuth_Get";

            string[] paramList = new string[] { "@USERID" };
            object[] valueList = new object[] { userid };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                dt = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList).Tables[0];
            }

            return dt;
        }

        #endregion

        #region :: GetUseVendor :: 사용 Vendor ID 를 가져옵니다.

        /// <summary>
        /// 사용 Vendor ID 를 가져옵니다.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 2017-06-25 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public static DataTable GetUseVendor()
        {
            DataTable dt;

            const string queryId = @"dbo.UseVendor_Get";

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                dt = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, null, null).Tables[0];
            }

            return dt;
        }

        #endregion

        #region :: GetUsePlant :: 사용 PLANT ID 를 가져옵니다.

        /// <summary>
        /// 사용 PLANT ID 를 가져옵니다.
        /// </summary>
        /// <param name="vendorCode"></param>
        /// <returns></returns>
        /// <remarks>
        /// 2017-06-25 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public static DataTable GetUsePlant(string vendorCode)
        {
            DataTable dt;

            const string queryId = @"dbo.UsePlant_Get";

            string[] paramList = new string[] { "@VENDORCODE" };
            object[] valueList = new object[] { vendorCode };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                dt = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList).Tables[0];
            }

            return dt;
        }

        #endregion

        #region :: GetMessageKey :: 메시지 키를 가져옵니다.

        /// <summary>
        /// 메시지 키를 가져옵니다.
        /// </summary>
        /// <param name="vendorCode"></param>
        /// <param name="userId"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static string GetMessageKey(string vendorCode, string userId, string ip)
        {
            object obj;

            const string queryId = @"upMsgKey_GetSet";

            string[] paramList = new string[] { "@IP_Address",
                                                "@EmployeeCode",
                                                "@ExtVendorCode",
                                                "@Type" };
            object[] valueList = new object[] { ip,
                                                userId,
                                                vendorCode,
                                                "S" };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                obj = wb.NTx_ExecuteScalar(ConnectionString.MESDB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            }

            return obj == null ? "" : obj.ToString();
        }

        #endregion

        #region :: GetUserToken :: 사용자 토큰 값을 가져옵니다.

        /// <summary>
        /// 사용자 토큰 값을 가져옵니다.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string GetUserToken(string userId)
        {
            object obj;

            const string queryId = @"SELECT TOKENID FROM dbo.UserToken WHERE USERID = @USERID";

            string[] paramList = new string[] { "@USERID" };
            object[] valueList = new object[] { userId };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                obj = wb.NTx_ExecuteScalar(ConnectionString.METADB, queryId, AppConfig.COMMANDTEXT, paramList, valueList);
            }

            return obj == null ? "" : obj.ToString();
        }

        #endregion

        #region :: PRODUCT :: Product Type를 가져옵니다.

        /// <summary>
        /// MES 의 공통코드 데이터를 가져옵니다.
        /// </summary>
        /// <param name="reference"></param>
        /// <param name="pCodeValue"></param>
        /// <param name="codeValue"></param>
        /// <param name="includedisplay"></param>
        /// <returns></returns>
        public static DataTable GetMESCommonCode(string reference, string pCodeValue, string codeValue = "", string includedisplay = "N")
        {
            DataTable dt;

            string queryId = Q_COMMON_CODE.GetCommonCombo(reference);

            string[] paramList = new string[] { "PCODEVALUE",
                                                "INCLUDEDISPLAY" };

            object[] valueList = new object[] { pCodeValue,
                                                includedisplay };

            using (OraBiz wb = new OraBiz(AppConfig.WEBSERVICEURL))
            {
                dt = wb.NTx_ExecuteDataSet(ConnectionString.ORAMESDB, queryId, AppConfig.COMMANDTEXT, paramList, valueList).Tables[0];
            }

            return dt;
        }

        #endregion
    }
}
