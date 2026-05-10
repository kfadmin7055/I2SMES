using EBAP.Core.Collections;
using EBAP.Core.Info;
using EBAP.Data.Compaction;
using EBAP.Data.Factory;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace EBAP.Business.WSBiz
{
    /// <summary>
    /// MS-SQL Biz Class
    /// </summary>
    public class SqlBiz_CS : IDisposable
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// Sql Biz를 생성합니다.
        /// </summary>
        public SqlBiz_CS() : this(AppConfig.WEBSERVICEURL)
        {
        }

        /// <summary>
        /// Sql Biz를 생성합니다.
        /// </summary>
        /// <param name="url">Web Service URL입니다.</param>
        public SqlBiz_CS(string url)
        {
            _webUrl = url;
            //SIGNINSEQ = Win32Util.GetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "SIGNINSEQ");
            //VENDOR = Win32Util.GetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "VENDORCODE");
            //PLANT = Win32Util.GetIniValue(AppConfig.SETTINGFILEPATH, "COMMON", "PLANTCODE");
        }

        #endregion

        #region :: 전역변수 ::

        private readonly string _webUrl = string.Empty;

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

                const string command = "SELECT GETDATE() AS CURRENTTIME";

                using (SqlFactory wsProxy = new SqlFactory(ConnectionString.METADB))
                {
                    object[] outValue = new object[] { };

                    object obj = wsProxy.NTx_ExecuteScalar(command, AppConfig.COMMANDTEXT, null, null, null, ref outValue);

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
                    queryText += String.Format("{0}='{1}', ", dParam.Key.ToString().Contains("") ? dParam.Key.ToString() : "" + dParam.Key.ToString(), dParam.Value);
                    paramList.Add(dParam.Key.ToString());
                    valueList.Add(dParam.Value);
                }
                queryText = queryText.Substring(0, queryText.Length - 2);

                if (Debugger.IsAttached) Console.WriteLine(queryText);

                using (SqlFactory wsProxy = new SqlFactory(ConnectionString.METADB))
                {
                    object[] outValue = new object[] { };

                    return wsProxy.NTx_ExecuteDataSet(command, cmdType, paramList.ToArray(), valueList.ToArray(), null, ref outValue);
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
                        queryText += String.Format("{0}='{1}', ", paramList[i].Contains("") ? paramList[i] : "" + paramList[i], valueList[i]);
                    }

                    queryText = queryText.Substring(0, queryText.Length - 2);
                }
                if (Debugger.IsAttached) Console.WriteLine(queryText);

                using (SqlFactory wsProxy = new SqlFactory(ConnectionString.METADB))
                {
                    object[] outValue = new object[] { };

                    return wsProxy.NTx_ExecuteDataSet(command, cmdType, paramList, valueList, null, ref outValue);
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
                        queryText += String.Format("{0}='{1}', ", paramList[i].Contains("") ? paramList[i] : "" + paramList[i], valueList[i]);
                    }

                    queryText = queryText.Substring(0, queryText.Length - 2);
                }

                if (Debugger.IsAttached) Console.WriteLine(queryText);

                using (SqlFactory wsProxy = new SqlFactory(ConnectionString.METADB))
                {
                    return wsProxy.NTx_ExecuteDataSet(command, cmdType, paramList.ToArray(), valueList.ToArray(), outParam, ref outValue);
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
                    queryText += String.Format("{0}='{1}', ", dParam.Key.ToString().Contains("") ? dParam.Key.ToString() : "" + dParam.Key.ToString(), dParam.Value);

                    paramList.Add(dParam.Key.ToString());
                    valueList.Add(dParam.Value);
                }

                queryText = queryText.Substring(0, queryText.Length - 2);

                if (Debugger.IsAttached) Console.WriteLine(queryText);

                using (SqlFactory wsProxy = new SqlFactory(ConnectionString.METADB))
                {
                    object[] outValue = new object[] { };

                    return wsProxy.NTx_ExecuteScalar(command, cmdType, paramList.ToArray(), valueList.ToArray(), null, ref outValue);
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
                        queryText += String.Format("{0}='{1}', ", paramList[i].Contains("") ? paramList[i] : "" + paramList[i], valueList[i]);
                    }

                    queryText = queryText.Substring(0, queryText.Length - 2);
                }

                if (Debugger.IsAttached) Console.WriteLine(queryText);

                using (SqlFactory wsProxy = new SqlFactory(ConnectionString.METADB))
                {
                    object[] outValue = new object[] { };

                    return wsProxy.NTx_ExecuteScalar(command, cmdType, paramList.ToArray(), valueList.ToArray(), null, ref outValue);
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
                        queryText += String.Format("{0}='{1}', ", paramList[i].Contains("") ? paramList[i] : "" + paramList[i], valueList[i]);
                    }

                    queryText = queryText.Substring(0, queryText.Length - 2);
                }

                if (Debugger.IsAttached) Console.WriteLine(queryText);


                using (SqlFactory wsProxy = new SqlFactory(dbName))
                {
                    object[] outValue = new object[] { };

                    return wsProxy.Tx_ExecuteNonQuery(command, cmdType, paramList.ToArray(), valueList.ToArray(), null, ref outValue);
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
                        queryText += String.Format("{0}='{1}', ", paramList[i].Contains("") ? paramList[i] : "" + paramList[i], valueList[i]);
                    }

                    queryText = queryText.Substring(0, queryText.Length - 2);
                }

                if (Debugger.IsAttached) Console.WriteLine(queryText);

                using (SqlFactory wsProxy = new SqlFactory(dbName))
                {
                    return wsProxy.Tx_ExecuteNonQuery(command, cmdType, paramList.ToArray(), valueList.ToArray(), outParam, ref outValue);
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
                    queryText += String.Format("{0}='{1}', ", dParam.Key.ToString().Contains("") ? dParam.Key : "" + dParam.Key, dParam.Value);

                    paramList.Add(dParam.Key.ToString());
                    valueList.Add(dParam.Value);
                }

                queryText = queryText.Substring(0, queryText.Length - 2);

                if (Debugger.IsAttached) Console.WriteLine(queryText);

                using (SqlFactory wsProxy = new SqlFactory(dbName))
                {
                    object[] outValue = new object[] { };

                    return wsProxy.Tx_ExecuteNonQuery(command, cmdType, paramList.ToArray(), valueList.ToArray(), null, ref outValue);
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
                            queryText += String.Format("{0}='{1}', ", param.Contains("") ? param : "" + param, dt.Rows[i][param.Replace("@", "")].ToString().Trim());
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

                using (SqlFactory wsProxy = new SqlFactory(dbName))
                {
                    return wsProxy.Tx_ExecuteNonQueryByDataTable(command, cmdType, paramList.ToArray(), dt, outParam, ref outValue);
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
                            queryText += String.Format("{0}='{1}', ", param.Contains("") ? param : "" + param, dt.Rows[i][param.Replace("@", "")].ToString().Trim());
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

                using (SqlFactory wsProxy = new SqlFactory(dbName))
                {
                    object[] outValue = new object[] { };

                    return wsProxy.Tx_ExecuteNonQueryByDataTable(command, cmdType, paramList, dt, null, ref outValue);
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

            //    var paramList = new string[] { "VENDORCODE", "PLANTCODE", "SIGNINSEQ", "METHODNAME", "QUERYID", "STARTDTTM", "ENDDTTM" };
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
