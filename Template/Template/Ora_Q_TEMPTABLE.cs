using EBAP.Core.Collections;
using EBAP.Core.Info;
using EBAP.Core.Interface;
using EBAP.Core.OracleQuery;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Template
{
    #region :: $rootnamespace$.$safeitemname$ ::


    /// <summary>
    /// TEMPTABLE 테이블 쿼리
    /// </summary>
    public static class Ora_Q_TEMPTABLE
    {
        static string queryText = string.Empty;

        #region :: TEMPTABLE 테이블 Select 쿼리

        public static string SelectQuery(string reference)
        {
            queryText = string.Empty;

            queryText = $@"
            /* {reference} */
            
            ";

            return queryText;
        }

        #endregion

        #region :: TEMPTABLE 테이블 Merge 쿼리
        /// <summary>
        /// TEMPTABLE 테이블 머지 쿼리
        /// </summary>
        /// <returns></returns>
        public static string Merge(string reference)
        {
            queryText = string.Empty;

            queryText = $@"
            /* {reference} */
            ";

            return queryText;
        }
        #endregion

        #region :: TEMPTABLE 테이블 Delete 쿼리
        /// <summary>
        /// TEMPTABLE 테이블 삭제 쿼리
        /// </summary>
        /// <returns></returns>
        public static string Delete(string reference)
        {
            queryText = string.Empty;

            queryText = @"
            DELETE FROM TEMPTABLE
            WHERE 1 = 1
            ";
            return queryText;
        }
        #endregion
    }

    #endregion
}
