using EBAP.Core.Collections;
using EBAP.Core.Info;
using EBAP.Core.Interface;
using EBAP.Data.Compaction;
using EBAP.Web.Proxy;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBAP.Business.WSBiz
{
    /// <summary>
    /// Oracle Biz Class
    /// </summary>
    public class OraBiz : IDisposable
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// Sql Biz를 생성합니다.
        /// </summary>
        public OraBiz() : this(AppConfig.WEBSERVICEURL)
        {
        }

        /// <summary>
        /// Sql Biz를 생성합니다.
        /// </summary>
        /// <param name="url">Web Service URL입니다.</param>
        public OraBiz(string url)
        {
            _webUrl = url;
            //SIGNINSEQ = Win32Util.GetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "SIGNINSEQ");
            //VENDOR = Win32Util.GetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "VENDORCODE");
            //PLANT = Win32Util.GetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "PLANTCODE");
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


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Database Query 관련)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: GetServerTime :: 서버의 현재 시간을 가져옵니다.

        /// <summary>
        /// 서버의 현재 시간을 가져옵니다.
        /// </summary>
        /// <returns></returns>
        public DateTime GetServerTime()
        {
            try
            {
                DateTime serverTime = DateTime.Now;

                const string command = "SELECT NOW() AS CURRENTTIME FROM DUAL";

                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    object[] outValue = new object[] { };

                    object obj = wsProxy.ONTx_ExecuteScalar(ConnectionString.METADB, command, AppConfig.COMMANDTEXT, null, null, null, ref outValue);

                    serverTime = (DateTime)obj;
                }
                return serverTime;
            }
            catch
            {
                throw;
            }
        }

        #endregion

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

                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    object[] outValue = new object[] { };

                    CompressDataSet compress = new CompressDataSet();

                    if (dbParams == null) return compress.UnzipData(wsProxy.ONTx_ExecuteDataSetCompress(dbName, command, cmdType, null, null, null, ref outValue));

                    return compress.UnzipData(wsProxy.ONTx_ExecuteDataSetCompress(dbName, command, cmdType, paramList.ToArray(), valueList.ToArray(), null, ref outValue));
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
            DateTime startDttm = DateTime.Now;

            try
            {
                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    object[] outValue = new object[] { };

                    CompressDataSet compress = new CompressDataSet();

                    return compress.UnzipData(wsProxy.ONTx_ExecuteDataSetCompress(dbName, command, cmdType, paramList, valueList, null, ref outValue));
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
        /// <param name="outParam"></param>
        /// <param name="outValue"></param>
        /// <returns></returns>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉(msNib)
        /// 변경내역
        /// 
        /// </remarks>
        public DataSet NTx_ExecuteDataSet(string dbName, string command, string cmdType, string[] paramList, object[] valueList, string[] outParam, ref object[] outValue)
        {
            DateTime startDttm = DateTime.Now;

            try
            {
                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    CompressDataSet compress = new CompressDataSet();

                    return compress.UnzipData(wsProxy.ONTx_ExecuteDataSetCompress(dbName, command, cmdType, paramList, valueList, outParam, ref outValue));
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

        #region :: NTx_ExecuteDataSetFromXML(+2 Overloading) :: XML 파일에서 쿼리를 실행하여 DataSet을 반환하는 Web Method를 실행합니다.

        /// <summary>
        /// XML 파일에서 쿼리를 실행하여 DataSet을 반환하는 Web Method를 실행합니다.
        /// </summary>
        /// <param name="queryId">쿼리 ID</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="valueList">Command Parameters Values</param>
        /// <returns></returns>        
        public DataSet NTx_ExecuteDataSetFromXML(string queryId, string[] paramList, object[] valueList)
        {
            DateTime startDttm = DateTime.Now;

            try
            {
                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    object[] outValue = new object[] { };

                    CompressDataSet compress = new CompressDataSet();

                    //return wsProxy.ONTx_ExecuteFromXML(queryId, paramList, valueList, null, ref outValue);
                    return compress.UnzipData(wsProxy.ONTx_ExecuteDataSetFromXMLCompress(queryId, paramList, valueList, null, ref outValue));
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                //UseLogSave("ONTx_ExecuteDataSetFromXMLCompress", queryId, startDttm);
            }
        }

        /// <summary>
        /// XML 파일에서 쿼리를 실행하여 DataSet을 반환하는 Web Method를 실행합니다.
        /// </summary>
        /// <param name="queryId">쿼리 ID</param>
        /// <param name="dbParams">DB Params</param>
        /// <returns></returns>     
        public DataSet NTx_ExecuteDataSetFromXML(string queryId, ParamCollection dbParams)
        {
            DateTime startDttm = DateTime.Now;

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

                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    object[] outValue = new object[] { };

                    CompressDataSet compress = new CompressDataSet();

                    return compress.UnzipData(wsProxy.ONTx_ExecuteDataSetFromXMLCompress(queryId, paramList.ToArray(), valueList.ToArray(), null, ref outValue));
                }

            }
            catch
            {
                throw;
            }
            finally
            {
                //UseLogSave("ONTx_ExecuteFromXMLCompress", queryId, startDttm);
            }
        }

        /// <summary>
        /// XML 파일에서 쿼리를 실행하여 DataSet을 반환하는 Web Method를 실행합니다.
        /// </summary>
        /// <param name="queryId">쿼리 ID</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="valueList">Command Parameters Values</param>
        /// <param name="outParam"></param>
        /// <param name="outValue"></param>
        /// <returns></returns>        
        public DataSet NTx_ExecuteDataSetFromXML(string queryId, string[] paramList, object[] valueList, string[] outParam, ref object[] outValue)
        {
            DateTime startDttm = DateTime.Now;

            try
            {
                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    CompressDataSet compress = new CompressDataSet();

                    return compress.UnzipData(wsProxy.ONTx_ExecuteDataSetFromXMLCompress(queryId, paramList, valueList, outParam, ref outValue));
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                //UseLogSave("ONTx_ExecuteDataSetFromXMLCompress", queryId, startDttm);
            }
        }

        #endregion

        #region :: NTx_ExecuteDataSetFromQueryId(+2 Overloading) :: DB Query Master에서 쿼리를 실행하여 DataSet을 반환하는 Web Method를 실행합니다.

        /// <summary>
        /// DB Query Master에서 쿼리를 실행하여 DataSet을 반환하는 Web Method를 실행합니다.
        /// </summary>
        /// <param name="queryId">쿼리 ID</param>
        /// <param name="dbParams">DB Params</param>
        /// <returns></returns>     
        public DataSet NTx_ExecuteDataSetFromQueryId(string queryId, ParamCollection dbParams)
        {
            DateTime startDttm = DateTime.Now;

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

                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    object[] outValue = new object[] { };

                    CompressDataSet compress = new CompressDataSet();

                    return compress.UnzipData(wsProxy.ONTx_ExecuteDataSetFromQueryIdCompress(queryId, paramList.ToArray(), valueList.ToArray(), null, ref outValue));
                }

            }
            catch
            {
                throw;
            }
            finally
            {
                //UseLogSave("ONTx_ExecuteFromQueryIdCompress", queryId, startDttm);
            }
        }

        /// <summary>
        /// DB Query Master에서 쿼리를 실행하여 DataSet을 반환하는 Web Method를 실행합니다.
        /// </summary>
        /// <param name="queryId">쿼리 ID</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="valueList">Command Parameters Values</param>
        /// <param name="outParam"></param>
        /// <param name="outValue"></param>
        /// <returns></returns>        
        public DataSet NTx_ExecuteDataSetFromQueryId(string queryId, string[] paramList, object[] valueList, string[] outParam, ref object[] outValue)
        {
            DateTime startDttm = DateTime.Now;

            try
            {
                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    CompressDataSet compress = new CompressDataSet();

                    return compress.UnzipData(wsProxy.ONTx_ExecuteDataSetFromQueryIdCompress(queryId, paramList, valueList, outParam, ref outValue));
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                //UseLogSave("ONTx_ExecuteDataSetFromQueryIdCompress", queryId, startDttm);
            }
        }

        /// <summary>
        /// DB Query Master에서 쿼리를 실행하여 DataSet을 반환하는 Web Method를 실행합니다.
        /// </summary>
        /// <param name="queryId">쿼리 ID</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="valueList">Command Parameters Values</param>
        /// <returns></returns>        
        public object NTx_ExecuteDataSetFromQueryId(string queryId, string[] paramList, object[] valueList)
        {
            DateTime startDttm = DateTime.Now;

            try
            {
                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    object[] outValue = new object[] { };

                    return wsProxy.ONTx_ExecuteDataSetFromQueryId(queryId, paramList, valueList, null, ref outValue).Tables[0].Rows[0][0];
                }

            }
            catch
            {
                throw;
            }
            finally
            {
                //UseLogSave("ONTx_ExecuteDataSetFromQueryId", queryId, startDttm);
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
            DateTime startDttm = DateTime.Now;

            try
            {
                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    object[] outValue = new object[] { };

                    return wsProxy.ONTx_ExecuteScalar(dbName, command, cmdType, paramList, valueList, null, ref outValue);
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
        /// XML 파일에서 쿼리를 실행하여 Object을 반환하는 Web Method를 실행합니다.
        /// </summary>
        /// <param name="queryId">쿼리 ID</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="valueList">Command Parameters Values</param>
        /// <returns></returns>        
        public object NTx_ExecuteScalarFromXML(string queryId, string[] paramList, object[] valueList)
        {
            DateTime startDttm = DateTime.Now;

            try
            {
                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    object[] outValue = new object[] { };

                    return wsProxy.ONTx_ExecuteScalarFromXML(queryId, paramList, valueList, null, ref outValue);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                //UseLogSave("ONTx_ExecuteScalarFromXML", queryId, startDttm);
            }
        }

        /// <summary>
        /// XML 파일에서 쿼리를 실행하여 Object을 반환하는 Web Method를 실행합니다.
        /// </summary>
        /// <param name="queryId">쿼리 ID</param>
        /// <param name="dbParams">Parameters</param>
        /// <returns></returns>
        public object NTx_ExecuteScalarFromXML(string queryId, ParamCollection dbParams)
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

                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    object[] outValue = new object[] { };

                    return wsProxy.ONTx_ExecuteScalarFromXML(queryId, paramList.ToArray(), valueList.ToArray(), null, ref outValue);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                //UseLogSave("ONTx_ExecuteScalarFromXML", queryId, startDttm);
            }
        }

        /// <summary>
        /// DB Query Master에서 쿼리를 실행하여 Object을 반환하는 Web Method를 실행합니다.
        /// </summary>
        /// <param name="queryId">쿼리 ID</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="valueList">Command Parameters Values</param>
        /// <returns></returns>        
        public object NTx_ExecuteScalarFromQueryId(string queryId, string[] paramList, object[] valueList)
        {
            DateTime startDttm = DateTime.Now;

            try
            {
                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    object[] outValue = new object[] { };

                    return wsProxy.ONTx_ExecuteScalarFromQueryId(queryId, paramList, valueList, null, ref outValue);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                //UseLogSave("ONTx_ExecuteScalarFromQueryId", queryId, startDttm);
            }
        }

        /// <summary>
        /// DB Query Master에서 쿼리를 실행하여 Object을 반환하는 Web Method를 실행합니다.
        /// </summary>
        /// <param name="queryId">쿼리 ID</param>
        /// <param name="dbParams">Parameters</param>
        /// <returns></returns>
        public object NTx_ExecuteScalarFromQueryId(string queryId, ParamCollection dbParams)
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

                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    object[] outValue = new object[] { };

                    return wsProxy.ONTx_ExecuteScalarFromQueryId(queryId, paramList.ToArray(), valueList.ToArray(), null, ref outValue);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                //UseLogSave("ONTx_ExecuteScalarFromQueryId", queryId, startDttm);
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
        public int Tx_ExecuteNonQuery(string dbName, string command, string cmdType, string[] paramList, object[] valueList)
        {
            DateTime startDttm = DateTime.Now;

            try
            {
                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    object[] outValue = new object[] { };

                    return wsProxy.OTx_ExecuteNonQuery(dbName, command, cmdType, paramList, valueList, null, ref outValue);
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
        /// <param name="outParam"></param>
        /// <param name="outValue"></param>
        /// <returns></returns>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉(msNib)
        /// 변경내역
        /// 
        /// </remarks>
        public int Tx_ExecuteNonQuery(string dbName, string command, string cmdType, string[] paramList, object[] valueList, string[] outParam, ref object[] outValue)
        {
            DateTime startDttm = DateTime.Now;

            try
            {
                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    return wsProxy.OTx_ExecuteNonQuery(dbName, command, cmdType, paramList, valueList, outParam, ref outValue);
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
            DateTime startDttm = DateTime.Now;

            try
            {
                if (dt == null) return 0;

                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    object[] outValue = new object[] { };

                    CompressDataSet compress = new CompressDataSet();

                    return wsProxy.OTx_ExecuteNonQueryByDataTableCompress(dbName, command, cmdType, paramList, compress.ZipData(dt), null, ref outValue);
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
        /// XML 파일에서 쿼리를 실행하여 영향을 받은 Row 수를 반환하는 Web Method를 실행합니다.
        /// </summary>
        /// <param name="queryId">쿼리 ID</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="dt">Command Parameters Values(DataTable)</param>
        /// <returns></returns>
        public int Tx_ExecuteNonQueryFromXML(string queryId, string[] paramList, DataTable dt)
        {
            DateTime startDttm = DateTime.Now;

            try
            {
                if (dt == null) return 0;

                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    object[] outValue = new object[] { };

                    CompressDataSet compress = new CompressDataSet();

                    return wsProxy.OTx_ExecuteNonQueryFromXMLByDataTableCompress(queryId, paramList, compress.ZipData(dt), null, ref outValue);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                //UseLogSave("OTx_ExecuteNonQueryFromXMLByDataTableCompress", queryId, startDttm);
            }
        }

        /// <summary>
        /// XML 파일에서 쿼리를 실행하여 영향을 받은 Row 수를 반환하는 Web Method를 실행합니다.
        /// </summary>
        /// <param name="queryId">쿼리 ID</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="valueList">Command Parameters Values</param>
        /// <returns></returns>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉(msNib)
        /// 변경내역
        /// 
        /// </remarks>
        public int Tx_ExecuteNonQueryFromXML(string queryId, string[] paramList, object[] valueList)
        {
            DateTime startDttm = DateTime.Now;

            try
            {
                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    object[] outValue = new object[] { };

                    return wsProxy.OTx_ExecuteNonQueryFromXML(queryId, paramList, valueList, null, ref outValue);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                //UseLogSave("OTx_ExecuteNonQueryFromXML", queryId, startDttm);
            }
        }

        /// <summary>
        /// XML 파일에서 쿼리를 실행하여 영향을 받은 Row 수를 반환하는 Web Method를 실행합니다.
        /// </summary>
        /// <param name="queryId">쿼리 ID</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="valueList">Command Parameters Values</param>
        /// <param name="outParam"></param>
        /// <param name="outValue"></param>
        /// <returns></returns>
        public int Tx_ExecuteNonQueryFromXML(string queryId, string[] paramList, object[] valueList, string[] outParam, ref object[] outValue)
        {
            DateTime startDttm = DateTime.Now;

            try
            {
                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    return wsProxy.OTx_ExecuteNonQueryFromXML(queryId, paramList, valueList, outParam, ref outValue);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                //UseLogSave("OTx_ExecuteNonQueryFromXML", queryId, startDttm);
            }
        }

        /// <summary>
        /// DB Query Master에서 쿼리를 실행하여 영향을 받은 Row 수를 반환하는 Web Method를 실행합니다.
        /// </summary>
        /// <param name="queryId">쿼리 ID</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="dt">Command Parameters Values(DataTable)</param>
        /// <returns></returns>
        public int Tx_ExecuteNonQueryFromQueryId(string queryId, string[] paramList, DataTable dt)
        {
            DateTime startDttm = DateTime.Now;

            try
            {
                if (dt == null) return 0;

                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    object[] outValue = new object[] { };

                    CompressDataSet compress = new CompressDataSet();

                    return wsProxy.OTx_ExecuteNonQueryFromQueryIdByDataTableCompress(queryId, paramList, compress.ZipData(dt), null, ref outValue);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                //UseLogSave("OTx_ExecuteNonQueryFromQueryId", queryId, startDttm);
            }
        }

        /// <summary>
        /// DB Query Master에서 쿼리를 실행하여 영향을 받은 Row 수를 반환하는 Web Method를 실행합니다.
        /// </summary>
        /// <param name="queryId">쿼리 ID</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="valueList">Command Parameters Values</param>
        /// <returns></returns>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉(msNib)
        /// 변경내역
        /// 
        /// </remarks>
        public int Tx_ExecuteNonQueryFromQueryId(string queryId, string[] paramList, object[] valueList)
        {
            DateTime startDttm = DateTime.Now;

            try
            {
                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    object[] outValue = new object[] { };

                    return wsProxy.OTx_ExecuteNonQueryFromQueryId(queryId, paramList, valueList, null, ref outValue);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                //UseLogSave("OTx_ExecuteNonQueryFromQueryId", queryId, startDttm);
            }
        }

        /// <summary>
        /// DB Query Master에서 쿼리를 실행하여 영향을 받은 Row 수를 반환하는 Web Method를 실행합니다.
        /// </summary>
        /// <param name="queryId">쿼리 ID</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="valueList">Command Parameters Values</param>
        /// <param name="outParam"></param>
        /// <param name="outValue"></param>
        /// <returns></returns>
        public int Tx_ExecuteNonQueryFromQueryId(string queryId, string[] paramList, object[] valueList, string[] outParam, ref object[] outValue)
        {
            DateTime startDttm = DateTime.Now;

            try
            {
                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    return wsProxy.OTx_ExecuteNonQueryFromQueryId(queryId, paramList, valueList, outParam, ref outValue);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                //UseLogSave("OTx_ExecuteNonQueryFromQueryId", queryId, startDttm);
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

                //var paramList = new string[] { "@VENDORCODE", "@PLANTCODE", "@SIGNINSEQ", "@METHODNAME", "@QUERYID", "@STARTDTTM", "@ENDDTTM" };
                //var valueList = new object[] { VENDOR, PLANT, SIGNINSEQ == string.Empty ? -1 : Convert.ToInt32(SIGNINSEQ), methodName, queryid, startDTTM, DateTime.Now };

                //object[] outValue = new object[] { };

                //using (WSProxy wsProxy = new WSProxy(_webUrl))
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
