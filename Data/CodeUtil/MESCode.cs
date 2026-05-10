using System.Data;
using EBAP.Business.WSBiz;
using EBAP.Core.Collections;
using EBAP.Core.Info;

namespace EBAP.Data.CodeUtil
{
    /// <summary>
    /// 생산관리 시스템에서 공통으로 사용할 Code Util Method를 정의합니다.
    /// </summary>
    /// <remarks>
    /// 2016-06-17 최초생성 : 오인봉
    /// 변경내역
    /// 
    /// </remarks>
    public static class MESCode
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
                dt = wb.NTx_ExecuteDataSet(ConnectionString.MESDB, queryId, AppConfig.COMMANDSP, paramList, valueList).Tables[0];
            }

            return dt;
        }

        #endregion
    }
}
