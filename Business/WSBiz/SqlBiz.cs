using EBAP.Core.Collections;
using EBAP.Core.Info;
using EBAP.Data.Compaction;
using EBAP.Web.Proxy;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace EBAP.Business.WSBiz
{
    /// <summary>
    /// MS-SQL Biz Class
    /// </summary>
    public class SqlBiz : IDisposable
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// Sql Biz를 생성합니다.
        /// </summary>
        public SqlBiz() : this(AppConfig.WEBSERVICEURL)
        {
        }

        /// <summary>
        /// Sql Biz를 생성합니다.
        /// </summary>
        /// <param name="url">Web Service URL입니다.</param>
        public SqlBiz(string url)
        {
            _webUrl = url;
            //SIGNINSEQ = Win32Util.GetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "SIGNINSEQ");
            //VENDOR = Win32Util.GetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "VENDORCODE");
            //PLANT = Win32Util.GetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "PLANTCODE");
        }

        #endregion

        #region :: 전역변수 ::

        private readonly string _webUrl = string.Empty;
        private readonly string SIGNINSEQ = string.Empty;
        private readonly string VENDOR = string.Empty;
        private readonly string PLANT = string.Empty;

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
        // Method(RFC, FTP, Highway 101 관련)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: RFC 관련 ::

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plant"></param>
        /// <param name="wareHouse"></param>
        /// <param name="materialCode"></param>
        /// <returns></returns>
        public DataSet RFC_PACKING_MATERIAL_LIST(string plant, string wareHouse, string materialCode)
        {
            try
            {
                DataSet ds;

                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    ds = wsProxy.RFC_PACKING_MATERIAL_LIST(plant, wareHouse, materialCode);
                }

                return ds;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gubun"></param>
        /// <param name="plant"></param>
        /// <param name="wareHouse"></param>
        /// <param name="materialCode"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public DataSet RFC_PACKING_MATERIAL_HIST(string gubun, string plant, string wareHouse, string materialCode, string fromDate, string toDate)
        {
            try
            {
                DataSet ds;

                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    ds = wsProxy.RFC_PACKING_MATERIAL_HIST(gubun, plant, wareHouse, materialCode, fromDate, toDate);
                }

                return ds;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="docNo"></param>
        /// <param name="postingDate"></param>
        /// <param name="rfcNo"></param>
        /// <param name="rfcMessage"></param>
        /// <returns></returns>
        public bool RFC_PACKING_MATERIAL_CANCEL(string docNo, string postingDate, ref string rfcNo, ref string rfcMessage)
        {
            try
            {
                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    wsProxy.RFC_PACKING_MATERIAL_CANCEL(docNo, postingDate, ref rfcNo, ref rfcMessage);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plant"></param>
        /// <param name="wareHouse"></param>
        /// <param name="materialCode"></param>
        /// <param name="useQty"></param>
        /// <param name="receiveWarehouse"></param>
        /// <param name="rfcNo"></param>
        /// <param name="rfcMessage"></param>
        /// <returns></returns>
        public bool RFC_PACKING_MATERIAL_MOVE(string plant, string wareHouse, string materialCode, long useQty, string receiveWarehouse, ref string rfcNo, ref string rfcMessage)
        {
            try
            {
                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    wsProxy.RFC_PACKING_MATERIAL_MOVE(plant, wareHouse, materialCode, useQty, receiveWarehouse, ref rfcNo, ref rfcMessage);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plant"></param>
        /// <param name="wareHouse"></param>
        /// <param name="materialCode"></param>
        /// <param name="useQty"></param>
        /// <param name="rfcNo"></param>
        /// <param name="rfcMessage"></param>
        /// <returns></returns>
        public bool RFC_PACKING_MATERIAL_INPUT(string plant, string wareHouse, string materialCode, long useQty, ref string rfcNo, ref string rfcMessage)
        {
            try
            {
                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    wsProxy.RFC_PACKING_MATERIAL_INPUT(plant, wareHouse, materialCode, useQty, ref rfcNo, ref rfcMessage);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region :: Highway 101 관련 ::

        /// <summary>
        /// [Highway101]서비스를 사용하여 XML 메시지를 전송합니다.
        /// </summary>
        /// <param name="messageName"></param>
        /// <param name="sourceChannel"></param>
        /// <param name="targetChannel"></param>
        /// <param name="strXML"></param>
        /// <returns></returns>
        public string H101_Execute(string messageName, string sourceChannel, string targetChannel, string strXML)
        {
            try
            {
                string retValue = "";

                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    retValue = wsProxy.H101_Execute(messageName, sourceChannel, targetChannel, strXML);
                }

                return retValue;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// [Highway101]서비스를 사용하여 BOX Tag 라벨을 생성합니다.
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public DataSet H101_MakeBoxTagLabel(string[] values)
        {
            try
            {
                DataSet ds;

                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    ds = wsProxy.H101_MakeBoxTagLabel(values);
                }

                return ds;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// [Highway101]서비스를 사용하여 번들정보를 저장합니다.
        /// </summary>
        /// <param name="values"></param>
        /// <param name="returnValue"></param>
        /// <returns></returns>
        public DataSet H101_BunddleInfoSave(string[] values, ref int returnValue)
        {
            try
            {
                DataSet ds;

                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    ds = wsProxy.H101_BunddleInfoSave(values, ref returnValue);
                }

                return ds;
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region :: FTP 관련 ::

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="directory"></param>
        /// <param name="fileName"></param>
        /// <param name="user"></param>
        /// <param name="pwd"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public Image GetImageFromFTP(string ip, string directory, string fileName, string user, string pwd, int port)
        {
            try
            {
                Image img = null;
                byte[] data = null;

                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    data = wsProxy.GetImageFromFTP(ip, directory, fileName, user, pwd, port);
                    MemoryStream ms = new MemoryStream(data);
                    img = Image.FromStream(ms);
                }

                return img;
            }
            catch
            {
                throw;
            }
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

                const string command = "SELECT GETDATE() AS CURRENTTIME";

                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    object[] outValue = new object[] { };

                    object obj = wsProxy.NTx_ExecuteScalar(ConnectionString.METADB, command, AppConfig.COMMANDTEXT, null, null, null, ref outValue);

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

                string queryText = String.Format("exec {0}  ", command);

                foreach (DictionaryEntry dParam in dbParams)
                {
                    queryText += String.Format("{0}='{1}', ", dParam.Key.ToString().Contains("@") ? dParam.Key.ToString() : "@" + dParam.Key.ToString(), dParam.Value);
                    paramList.Add(dParam.Key.ToString());
                    valueList.Add(dParam.Value);
                }
                queryText = queryText.Substring(0, queryText.Length - 2);

                if (Debugger.IsAttached) Console.WriteLine(queryText);

                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    object[] outValue = new object[] { };

                    CompressDataSet compress = new CompressDataSet();

                    if (dbParams == null) return compress.UnzipData(wsProxy.NTx_ExecuteDataSetCompress(dbName, command, cmdType, null, null, null, ref outValue));

                    return compress.UnzipData(wsProxy.NTx_ExecuteDataSetCompress(dbName, command, cmdType, paramList.ToArray(), valueList.ToArray(), null, ref outValue));
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                UseLogSave("NTx_ExecuteDataSetCompress", command, startDttm);
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
                string queryText = String.Format("exec {0}  ", command);

                if (paramList != null)
                {
                    for (int i = 0; i < paramList.Length; i++)
                    {
                        queryText += String.Format("{0}='{1}', ", paramList[i].Contains("@") ? paramList[i] : "@" + paramList[i], valueList[i]);
                    }

                    queryText = queryText.Substring(0, queryText.Length - 2);
                }
                if (Debugger.IsAttached) Console.WriteLine(queryText);

                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    object[] outValue = new object[] { };

                    CompressDataSet compress = new CompressDataSet();

                    return compress.UnzipData(wsProxy.NTx_ExecuteDataSetCompress(dbName, command, cmdType, paramList, valueList, null, ref outValue));
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                UseLogSave("NTx_ExecuteDataSetCompress", command, startDttm);
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
                string queryText = String.Format("exec {0}  ", command);

                if (paramList != null)
                {
                    for (int i = 0; i < paramList.Length; i++)
                    {
                        queryText += String.Format("{0}='{1}', ", paramList[i].Contains("@") ? paramList[i] : "@" + paramList[i], valueList[i]);
                    }

                    queryText = queryText.Substring(0, queryText.Length - 2);
                }

                if (Debugger.IsAttached) Console.WriteLine(queryText);

                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    CompressDataSet compress = new CompressDataSet();

                    return compress.UnzipData(wsProxy.NTx_ExecuteDataSetCompress(dbName, command, cmdType, paramList, valueList, outParam, ref outValue));
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                UseLogSave("NTx_ExecuteDataSetCompress", command, startDttm);
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

                    //return wsProxy.NTx_ExecuteFromXML(queryId, paramList, valueList, null, ref outValue);
                    return compress.UnzipData(wsProxy.NTx_ExecuteDataSetFromXMLCompress(queryId, paramList, valueList, null, ref outValue));
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                UseLogSave("NTx_ExecuteFromXMLCompress", queryId, startDttm);
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

                    return compress.UnzipData(wsProxy.NTx_ExecuteDataSetFromXMLCompress(queryId, paramList.ToArray(), valueList.ToArray(), null, ref outValue));
                }

            }
            catch
            {
                throw;
            }
            finally
            {
                UseLogSave("NTx_ExecuteDataSetFromXMLCompress", queryId, startDttm);
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

                    return compress.UnzipData(wsProxy.NTx_ExecuteDataSetFromQueryIdCompress(queryId, paramList.ToArray(), valueList.ToArray(), null, ref outValue));
                }

            }
            catch
            {
                throw;
            }
            finally
            {
                UseLogSave("NTx_ExecuteDataSetFromQueryIdCompress", queryId, startDttm);
            }
        }

        /// <summary>
        /// DB Query Master에서 쿼리를 실행하여 DataSet을 반환하는 Web Method를 실행합니다.
        /// </summary>
        /// <param name="queryId">쿼리 ID</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="valueList">Command Parameters Values</param>
        /// <returns></returns>        
        public DataSet NTx_ExecuteDataSetFromQueryId(string queryId, string[] paramList, object[] valueList)
        {
            DateTime startDttm = DateTime.Now;

            try
            {
                //DataTable dt = new DataTable();

                //dt.AddColumnWithValueNewRow(paramList, valueList);

                //CompressDataSet compresss = new CompressDataSet();
                //compresss.ZipData(dt);

                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    object[] outValue = new object[] { };

                    CompressDataSet compress = new CompressDataSet();

                    return compress.UnzipData(wsProxy.NTx_ExecuteDataSetFromQueryIdCompress(queryId, paramList, valueList, null, ref outValue));
                }

            }
            catch
            {
                throw;
            }
            finally
            {
                UseLogSave("NTx_ExecuteDataSetFromQueryId", queryId, startDttm);
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
        /// <param name="dbParams">Command Parameters</param>
        /// <returns></returns>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉(msNib)
        /// 변경내역
        /// 
        /// </remarks>
        public object NTx_ExecuteScalar(string dbName, string command, string cmdType, ParamCollection dbParams)
        {
            DateTime startDttm = DateTime.Now;

            try
            {
                List<string> paramList = new List<string>();
                List<object> valueList = new List<object>();

                string queryText = String.Format("exec {0}  ", command);

                foreach (DictionaryEntry dParam in dbParams)
                {
                    queryText += String.Format("{0}='{1}', ", dParam.Key.ToString().Contains("@") ? dParam.Key.ToString() : "@" + dParam.Key.ToString(), dParam.Value);

                    paramList.Add(dParam.Key.ToString());
                    valueList.Add(dParam.Value);
                }

                queryText = queryText.Substring(0, queryText.Length - 2);

                if (Debugger.IsAttached) Console.WriteLine(queryText);

                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    object[] outValue = new object[] { };

                    return wsProxy.NTx_ExecuteScalar(dbName, command, cmdType, paramList.ToArray(), valueList.ToArray(), null, ref outValue);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                UseLogSave("NTx_ExecuteScalar", command, startDttm);
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
            DateTime startDttm = DateTime.Now;

            try
            {
                string queryText = String.Format("exec {0}  ", command);

                if (paramList != null)
                {
                    for (int i = 0; i < paramList.Length; i++)
                    {
                        queryText += String.Format("{0}='{1}', ", paramList[i].Contains("@") ? paramList[i] : "@" + paramList[i], valueList[i]);
                    }

                    queryText = queryText.Substring(0, queryText.Length - 2);
                }

                if (Debugger.IsAttached) Console.WriteLine(queryText);

                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    object[] outValue = new object[] { };

                    return wsProxy.NTx_ExecuteScalar(dbName, command, cmdType, paramList, valueList, null, ref outValue);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                UseLogSave("NTx_ExecuteScalar", command, startDttm);
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

                    return wsProxy.NTx_ExecuteScalarFromXML(queryId, paramList, valueList, null, ref outValue);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                UseLogSave("NTx_ExecuteScalarFromXML", queryId, startDttm);
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

                    return wsProxy.NTx_ExecuteScalarFromXML(queryId, paramList.ToArray(), valueList.ToArray(), null, ref outValue);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                UseLogSave("NTx_ExecuteScalarFromXML", queryId, startDttm);
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

                    return wsProxy.NTx_ExecuteScalarFromQueryId(queryId, paramList, valueList, null, ref outValue);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                UseLogSave("NTx_ExecuteScalarFromQueryId", queryId, startDttm);
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

                    return wsProxy.NTx_ExecuteScalarFromQueryId(queryId, paramList.ToArray(), valueList.ToArray(), null, ref outValue);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                UseLogSave("NTx_ExecuteScalarFromQueryId", queryId, startDttm);
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
                string queryText = String.Format("exec {0}  ", command);

                if (paramList != null)
                {
                    for (int i = 0; i < paramList.Length; i++)
                    {
                        queryText += String.Format("{0}='{1}', ", paramList[i].Contains("@") ? paramList[i] : "@" + paramList[i], valueList[i]);
                    }

                    queryText = queryText.Substring(0, queryText.Length - 2);
                }

                if (Debugger.IsAttached) Console.WriteLine(queryText);

                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    object[] outValue = new object[] { };

                    return wsProxy.Tx_ExecuteNonQuery(dbName, command, cmdType, paramList, valueList, null, ref outValue);
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

        /// <summary>
        /// 쿼리를 실행하여 영향을 받은 Row 수를 반환하는 Web Method를 실행합니다.
        /// </summary>
        /// <param name="dbName">DB 연결정보</param>
        /// <param name="command">Command String</param>
        /// <param name="cmdType">Command Type</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="valueList">Command Parameters Values</param>
        /// <param name="outParam">Output 파라미터</param>
        /// <param name="outValue">Output 파라미터 값</param>
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
                string queryText = String.Format("exec {0}  ", command);

                if (paramList != null)
                {
                    for (int i = 0; i < paramList.Length; i++)
                    {
                        queryText += String.Format("{0}='{1}', ", paramList[i].Contains("@") ? paramList[i] : "@" + paramList[i], valueList[i]);
                    }

                    queryText = queryText.Substring(0, queryText.Length - 2);
                }

                if (Debugger.IsAttached) Console.WriteLine(queryText);

                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    return wsProxy.Tx_ExecuteNonQuery(dbName, command, cmdType, paramList, valueList, outParam, ref outValue);
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

                string queryText = String.Format("exec {0}  ", command);

                foreach (DictionaryEntry dParam in dbParams)
                {
                    queryText += String.Format("{0}='{1}', ", dParam.Key.ToString().Contains("@") ? dParam.Key : "@" + dParam.Key, dParam.Value);

                    paramList.Add(dParam.Key.ToString());
                    valueList.Add(dParam.Value);
                }

                queryText = queryText.Substring(0, queryText.Length - 2);

                if (Debugger.IsAttached) Console.WriteLine(queryText);

                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    object[] outValue = new object[] { };

                    return wsProxy.Tx_ExecuteNonQuery(dbName, command, cmdType, paramList.ToArray(), valueList.ToArray(), null, ref outValue);
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
            DateTime startDttm = DateTime.Now;

            try
            {
                if (Debugger.IsAttached)
                {
                    string notExistColumn = "";

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string queryText = String.Format("exec {0}  ", command);

                        foreach (string param in paramList)
                        {
                            queryText += String.Format("{0}='{1}', ", param.Contains("@") ? param : "@" + param, dt.Rows[i][param.Replace("@", "")].ToString().Trim());
                        }

                        queryText = queryText.Substring(0, queryText.Length - 2);

                        if (Debugger.IsAttached) Console.WriteLine(queryText);
                    }

                    foreach (string param in paramList)
                    {
                        if (!dt.Columns.Contains(param.Replace("@", "")))
                            notExistColumn += param.Replace("@", "") + ", ";
                    }
                    if (notExistColumn != "") throw new ArgumentException(string.Format("{0} 컬럼이 없어요. 확인하세요.", notExistColumn));
                }
                if (dt == null) return 0;

                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    object[] outValue = new object[] { };

                    CompressDataSet compress = new CompressDataSet();

                    return wsProxy.Tx_ExecuteNonQueryByDataTableCompress(dbName, command, cmdType, paramList, compress.ZipData(dt), null, ref outValue);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                UseLogSave("Tx_ExecuteNonQueryByDataTableCompress", command, startDttm);
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
        /// <param name="outParam"></param>
        /// <param name="outValue"></param>
        /// <returns></returns>
        public int Tx_ExecuteNonQuery(string dbName, string command, string cmdType, string[] paramList, DataTable dt, string[] outParam, ref object[] outValue)
        {
            DateTime startDttm = DateTime.Now;

            try
            {
                if (Debugger.IsAttached)
                {
                    string notExistColumn = "";

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string queryText = String.Format("exec {0}  ", command);

                        foreach (string param in paramList)
                        {
                            queryText += String.Format("{0}='{1}', ", param.Contains("@") ? param : "@" + param, dt.Rows[i][param.Replace("@", "")].ToString().Trim());
                        }

                        queryText = queryText.Substring(0, queryText.Length - 2);

                        if (Debugger.IsAttached) Console.WriteLine(queryText);
                    }

                    foreach (string param in paramList)
                    {
                        if (!dt.Columns.Contains(param.Replace("@", "")))
                            notExistColumn += param.Replace("@", "") + ", ";
                    }
                    if (notExistColumn != "") throw new ArgumentException(string.Format("{0} 컬럼이 없어요. 확인하세요.", notExistColumn));
                }
                if (dt == null) return 0;

                using (WSProxy wsProxy = new WSProxy(_webUrl))
                {
                    CompressDataSet compress = new CompressDataSet();

                    return wsProxy.Tx_ExecuteNonQueryByDataTableCompress(dbName, command, cmdType, paramList, compress.ZipData(dt), outParam, ref outValue);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                UseLogSave("Tx_ExecuteNonQueryByDataTableCompress", command, startDttm);
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

                    return wsProxy.Tx_ExecuteNonQueryFromXMLByDataTableCompress(queryId, paramList, compress.ZipData(dt), null, ref outValue);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                UseLogSave("Tx_ExecuteNonQueryFromXMLByDataTableCompress", queryId, startDttm);
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

                    return wsProxy.Tx_ExecuteNonQueryFromXML(queryId, paramList, valueList, null, ref outValue);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                UseLogSave("Tx_ExecuteNonQueryFromXML", queryId, startDttm);
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

                    return wsProxy.Tx_ExecuteNonQueryFromQueryIdByDataTableCompress(queryId, paramList, compress.ZipData(dt), null, ref outValue);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                UseLogSave("Tx_ExecuteNonQueryFromQueryIdByDataTableCompress", queryId, startDttm);
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

                    return wsProxy.Tx_ExecuteNonQueryFromQueryId(queryId, paramList, valueList, null, ref outValue);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                UseLogSave("Tx_ExecuteNonQueryFromQueryId", queryId, startDttm);
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
            //try
            //{
            //    const string queryId = @"EBAP.Main.saveUseLog";

            //    var paramList = new string[] { "@VENDORCODE", "@PLANTCODE", "@SIGNINSEQ", "@METHODNAME", "@QUERYID", "@STARTDTTM", "@ENDDTTM" };
            //    var valueList = new object[] { VENDOR, PLANT, SIGNINSEQ == string.Empty ? -1 : Convert.ToInt32(SIGNINSEQ), methodName, queryid, startDTTM, DateTime.Now };

            //    object[] outValue = new object[] { };

            //    using (WSProxy wsProxy = new WSProxy(_webUrl))
            //    {
            //        wsProxy.Tx_ExecuteNonQueryFromQueryId(queryId, paramList, valueList, null, ref outValue);
            //    }
            //}
            //catch
            //{
            //    throw;
            //}
        }

        #endregion
    }
}
