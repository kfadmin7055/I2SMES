using EBAP.Core.Collections;
using EBAP.Core.Info;
using EBAP.Data.Factory;
using EBAP.Web.Proxy;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Net;
using System.Xml.Linq;

namespace EBAP.Business.WSBiz
{
    /// <summary>
    /// Oracle Biz Client/Server Class
    /// </summary>
    public class OraBiz_CS : IDisposable
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// Sql Biz를 생성합니다.
        /// </summary>
        public OraBiz_CS() : this(AppConfig.WEBSERVICEURL)
        {
        }

        /// <summary>
        /// Sql Biz를 생성합니다.
        /// </summary>
        /// <param name="url">Web Service URL입니다.</param>
        public OraBiz_CS(string url)
        {
            _webUrl = url;
        }

        #endregion

        #region :: 전역변수 ::

        private readonly string _webUrl = string.Empty;
        //private readonly string SIGNINSEQ = string.Empty;
        //private readonly string VENDOR = string.Empty;
        //private readonly string PLANT = string.Empty;

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Interface 구현
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region IDisposable 멤버

        /// <summary>
        /// 할당된 리소스를 해제합니다.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

        #endregion

        /// <summary>
        /// 서버의 현재 시간을 가져옵니다.
        /// </summary>
        /// <returns></returns>
        public DateTime GetServerTime()
        {
            try
            {
                DateTime serverTime = DateTime.Now;
                const string command = "SELECT SYSDATE FROM DUAL";

                using (OracleFactory oraFactory = new OracleFactory(ConnectionString.METADB))
                {
                    object[] outValue = new object[] { };

                    object obj = oraFactory.NTx_ExecuteScalar(command, AppConfig.COMMANDTEXT, null, null);

                  serverTime = (DateTime)obj;
                }

                return serverTime;
            }
            catch
            {
                throw;
            }
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Database Query 관련)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: NTx_ExecuteDataSet(+2 Overloading) :: 쿼리를 실행하여 DataSet을 반환하는 Web Method를 실행합니다.

        /// <summary>
        /// 쿼리를 실행하여 DataSet을 반환하는 Web Method를 실행합니다.
        /// </summary>
        /// <param name="dbName">DB 연결정보</param>
        /// <param name="command">Command String</param>
        /// <param name="cmdType">Command Type</param>
        /// <param name="dbParams">Parameters</param>
        /// <returns></returns>
        public DataSet NTx_ExecuteDataSet(string dbName, string command, string cmdType, ParamCollection dbParams)
        {
            //DateTime startDttm = DateTime.Now;

            try
            {
                List<string> paramList = new List<string>();
                List<object> valueList = new List<object>();

                if (dbParams != null)
                {
                    foreach (DictionaryEntry dParam in dbParams)
                    {
                        paramList.Add(dParam.Key.ToString());
                        valueList.Add(dParam.Value);
                    }
                }


                using ( OracleFactory oraFactory = new OracleFactory(dbName))
                {                    
                    if (dbParams == null) return oraFactory.NTx_ExecuteDataSet(command, cmdType, null, null);

                    return oraFactory.NTx_ExecuteDataSet(command, cmdType, paramList.ToArray(), valueList.ToArray());
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                //UseLogSave("ONTx_ExecuteDataSetCompress", command, startDttm);
            }
        }

        /// <summary>
        /// 쿼리를 실행하여 DataSet을 반환하는 Web Method를 실행합니다.
        /// </summary>
        /// <param name="dbName">DB 연결정보</param>
        /// <param name="command">Command String</param>
        /// <returns></returns>
        public DataSet NTx_ExecuteDataSet(string dbName, string[] command, string cmdType, string[] paramList, object[] valueList)
        {
            //DateTime startDttm = DateTime.Now;

            try
            {
                string[] queryId = command;

                using (OracleFactory oraFactory = new OracleFactory(dbName))
                {
                    return oraFactory.NTx_ExecuteDataSetMultiTable(dbName, queryId, cmdType, paramList, valueList);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                //UseLogSave("ONTx_ExecuteDataSetCompress", command, startDttm);
            }
        }

        /// <summary>
        /// 쿼리를 실행하여 DataSet을 반환하는 Web Method를 실행합니다.
        /// </summary>
        /// <param name="dbName">DB 연결정보</param>
        /// <param name="command">Command String</param>
        /// <param name="cmdType">Command Type</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="valueList">Command Parameters Values</param>
        /// <returns></returns>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉(msNib)
        /// 변경내역
        /// 
        /// </remarks>
        public DataSet NTx_ExecuteDataSet(string dbName, string command, string cmdType, string[] paramList, object[] valueList)
        {
            //DateTime startDttm = DateTime.Now;

            try
            {
                using (OracleFactory oraFactory = new OracleFactory(dbName))
                {
                    return oraFactory.NTx_ExecuteDataSet(command, cmdType, paramList, valueList);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                //UseLogSave("ONTx_ExecuteDataSetCompress", command, startDttm);
            }
        }

        #endregion


        #region :: NTx_ExecuteScalar(+1 Overloading) :: 쿼리를 실행하여 object을 반환하는 Web Method를 실행합니다.
        /// <summary>
        /// 쿼리를 실행하여 object을 반환하는 Web Method를 실행합니다.
        /// </summary>
        /// <param name="dbName">DB 연결정보</param>
        /// <param name="command">Command String</param>
        /// <param name="cmdType">Command Type</param>
        /// <param name="param">Command Parameters</param>
        /// <param name="value">Command Parameters Values</param>
        /// <returns></returns>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉(msNib)
        /// 변경내역
        /// 
        /// </remarks>
        public object NTx_ExecuteScalar(string dbName, string command, string cmdType, string param, object value)
        {
            //DateTime startDttm = DateTime.Now;

            try
            {
                string[] paramList = new string[] {param};
                object[] valueList = new object[] {value};

                using (OracleFactory oraFactory = new OracleFactory(dbName))
                {
                    return oraFactory.NTx_ExecuteScalar(command, cmdType, paramList, valueList);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                //UseLogSave("ONTx_ExecuteScalar", command, startDttm);
            }
        }

        /// <summary>
        /// 쿼리를 실행하여 object을 반환하는 Web Method를 실행합니다.
        /// </summary>
        /// <param name="dbName">DB 연결정보</param>
        /// <param name="command">Command String</param>
        /// <param name="cmdType">Command Type</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="valueList">Command Parameters Values</param>
        /// <returns></returns>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉(msNib)
        /// 변경내역
        /// 
        /// </remarks>
        public object NTx_ExecuteScalar(string dbName, string command, string cmdType, string[] paramList, object[] valueList)
        {
            //DateTime startDttm = DateTime.Now;

            try
            {
                using (OracleFactory oraFactory = new OracleFactory(dbName))
                {
                    return oraFactory.NTx_ExecuteScalar(command, cmdType, paramList, valueList);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                //UseLogSave("ONTx_ExecuteScalar", command, startDttm);
            }
        }

        /// <summary>
        /// 쿼리를 실행하여 object을 반환하는 Web Method를 실행합니다.
        /// </summary>
        /// <param name="dbName">DB 연결정보</param>
        /// <param name="command">Command String</param>
        /// <param name="cmdType">Command Type</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="valueList">Command Parameters Values</param>
        /// <returns></returns>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉(msNib)
        /// 변경내역
        /// 
        /// </remarks>
        public object NTx_ExecuteScalar(string dbName, string command, string cmdType, ParamCollection dbParams = null)
        {
            //DateTime startDttm = DateTime.Now;

            try
            {
                List<string> paramList = new List<string>();
                List<object> valueList = new List<object>();

                if (dbParams != null)
                {
                    foreach (DictionaryEntry dParam in dbParams)
                    {
                        paramList.Add(dParam.Key.ToString());
                        valueList.Add(dParam.Value);
                    }
                }

                using (OracleFactory oraFactory = new OracleFactory(dbName))
                {
                    return oraFactory.NTx_ExecuteScalar(command, cmdType, paramList.ToArray(), valueList.ToArray());
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                //UseLogSave("ONTx_ExecuteScalar", command, startDttm);
            }
        }

        #endregion

        #region :: Tx_ExecuteNonQuery(+1 Overloading) :: 쿼리를 실행하여 영향을 받은 Row 수를 반환하는 Web Method를 실행합니다.

        /// <summary>
        /// 쿼리를 실행하여 영향을 받은 Row 수를 반환하는 Web Method를 실행합니다.
        /// </summary>
        /// <param name="dbName">DB 연결정보</param>
        /// <param name="command">Command String</param>
        /// <param name="cmdType">Command Type</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="valueList">Command Parameters Values</param>
        /// <returns></returns>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉(msNib)
        /// 변경내역
        /// 
        /// </remarks>
        public int Tx_ExecuteNonQuery(string dbName, string command, string cmdType = "Text", string[] paramList = null, object[] valueList = null)
        {
            //DateTime startDttm = DateTime.Now;

            try
            {
                using (OracleFactory oraFactory = new OracleFactory(dbName))
                {
                    return oraFactory.Tx_ExecuteNonQuery(command, cmdType, paramList, valueList);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                //UseLogSave("OTx_ExecuteNonQuery", command, startDttm);
            }
        }

        /// <summary>
        /// 쿼리를 실행하여 영향을 받은 Row 수를 반환하는 Web Method를 실행합니다.
        /// </summary>
        /// <param name="dbName">DB 연결정보</param>
        /// <param name="command">Command String</param>
        /// <param name="cmdType">Command Type</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="valueList">Command Parameters Values</param>
        /// <returns></returns>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉(msNib)
        /// 변경내역
        /// 
        /// </remarks>
        public int Tx_ExecuteNonQuery(string dbName, string[] command, string cmdType = "Text", string[] paramList = null, object[] valueList = null)
        {
            //DateTime startDttm = DateTime.Now;

            try
            {
                using (OracleFactory oraFactory = new OracleFactory(dbName))
                {
                    return oraFactory.Tx_ExecuteNonQuery(command, cmdType, paramList, valueList);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                //UseLogSave("OTx_ExecuteNonQuery", command, startDttm);
            }
        }


        /// <summary>
        /// 쿼리를 실행하여 영향을 받은 Row 수를 반환하는 Web Method를 실행합니다.
        /// </summary>
        /// <param name="dbName">DB 연결정보</param>
        /// <param name="command">Command String</param>
        /// <param name="cmdType">Command Type</param>
        /// <param name="dbParams"></param>
        /// <returns></returns>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉(msNib)
        /// 변경내역
        /// 
        /// </remarks>
        public int Tx_ExecuteNonQuery(string dbName, string command, string cmdType, ParamCollection dbParams)
        {
            DateTime startDttm = DateTime.Now;

            try
            {
                List<string> paramList = new List<string>();
                List<object> valueList = new List<object>();

                foreach (DictionaryEntry dParam in dbParams)
                {
                    paramList.Add(dParam.Key.ToString());
                    valueList.Add(dParam.Value);
                }

                using (OracleFactory oraFactory = new OracleFactory(dbName))
                {
                    return oraFactory.Tx_ExecuteNonQuery(command, cmdType, paramList.ToArray(), valueList.ToArray());
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                UseLogSave("Tx_ExecuteNonQuery", command, startDttm);
            }
        }
        #endregion

        #region :: Tx_ExecuteNonQueryByDataTable :: DataTable을 사용하여 쿼리를 실행하여 Multi 처리하고 영향을 받은 Row 수를 반환하는 Web Method를 실행합니다.

        /// <summary>
        /// DataTable을 사용하여 쿼리를 실행하여 Multi 처리하고 영향을 받은 Row 수를 반환하는 Web Method를 실행합니다.
        /// </summary>
        /// <param name="dbName">DB 연결정보</param>
        /// <param name="command">Command String</param>
        /// <param name="cmdType">Command Type</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="dt">Command Parameters Values(DataTable)</param>
        /// <returns></returns>
        public int Tx_ExecuteNonQuery(string dbName, string command, string cmdType, string[] paramList, DataTable dt)
        {
            //DateTime startDttm = DateTime.Now;

            try
            {
                if (dt ==  null) return 0;

                using (OracleFactory oraFactory = new OracleFactory(dbName))
                {
                    return oraFactory.Tx_ExecuteNonQueryByDataTable(command, cmdType, paramList, dt);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                //UseLogSave("OTx_ExecuteNonQueryByDataTableCompress", command, startDttm);
            }
        }

        /// <summary>
        /// DataTable을 사용하여 쿼리를 실행하여 Multi 처리하고 영향을 받은 Row 수를 반환하는 Web Method를 실행합니다.
        /// </summary>
        /// <param name="dbName">DB 연결정보</param>
        /// <param name="command">Command String</param>
        /// <param name="cmdType">Command Type</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="dt">Command Parameters Values(DataTable)</param>
        /// <returns></returns>
        public int Tx_ExecuteNonQuery(string dbName, string[] command, string cmdType, string[] paramList, DataTable dt)
        {
            //DateTime startDttm = DateTime.Now;

            try
            {
                if (dt == null) return 0;

                using (OracleFactory oraFactory = new OracleFactory(dbName))
                {
                    return oraFactory.Tx_ExecuteNonQueryByDataTable(command, cmdType, paramList, dt);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                //UseLogSave("OTx_ExecuteNonQueryByDataTableCompress", command, startDttm);
            }
        }

        #endregion

        #region :: UseLogSave :: WebService 사용 이력 저장

        /// <summary>
        /// 
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="queryid"></param>
        /// <param name="startDTTM"></param>
        private void UseLogSave(string methodName, string queryid, DateTime startDTTM)
        {
            try
            {
                //const string queryId = @"EBAP.Main.saveUseLog";

                //var paramList = new string[] { "VENDORCODE", "PLANTCODE", "SIGNINSEQ", "METHODNAME", "QUERYID", "STARTDTTM", "ENDDTTM" };
                //var valueList = new object[] { VENDOR, PLANT, SIGNINSEQ == string.Empty ? -1 : Convert.ToInt32(SIGNINSEQ), methodName, queryid, startDTTM, DateTime.Now };

                //object[] outValue = new object[] { };

                //using (OracleFactory oraFactory = new OracleFactory(dbName))
                //{
                //    wsProxy.Tx_ExecuteNonQueryFromQueryId(queryId, paramList, valueList, null, ref outValue);
                //}
            }
            catch
            {
                throw;
            }
        }

        #endregion
    }
}
