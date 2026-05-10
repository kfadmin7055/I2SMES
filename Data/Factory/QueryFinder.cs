using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBAP.Data.Factory
{
    /// <summary>
    /// DB Table의 Query Id로 쿼리를 가져옵니다.
    /// </summary>
    public class QueryFinder
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// 
        /// </summary>
        public QueryFinder()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryId"></param>
        public QueryFinder(string queryId)
        {
            SqlFactory sf = new SqlFactory("METADB");

            object[] outValue = new object[] { };

            DataSet ds = sf.NTx_ExecuteDataSet("dbo.QueryMaster_Get", "StoredProcedure", new string[] { "@QUERYID" }, new object[] { queryId }, null, ref outValue);

            DataTable dt = ds.Tables[0];

            QUERY = string.Empty;

            if (dt.Rows.Count == 0) return;

            foreach (DataRow dr in dt.Rows)
            {
                QUERY += dr["QUERYTEXT"].ToString();

                DBNAME = dr["DBID"].ToString();

                COMMANDTYPE = dr["QUERYTYPE"].ToString();
            }
        }

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 
        /// </summary>
        public string QUERY
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string DBNAME
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string COMMANDTYPE
        {
            get;
            set;
        }
    }
}
