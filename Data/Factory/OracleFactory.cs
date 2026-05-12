using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text.RegularExpressions;

namespace EBAP.Data.Factory
{
    /// <summary>
    /// Oracle Database와 연동하는 Oracle Factory 클래스입니다.
    /// </summary>
    /// <remarks>
    /// 2023-02-01 최초생성 : 오인봉
    /// 변경내역
    /// 
    /// </remarks>
    public class OracleFactory : IDisposable
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// Oracle Factory를 생성합니다.
        /// </summary>
        /// <param name="connectionStr">연결문자열</param>
        public OracleFactory(string connectionStr)
        {
            //            con = new OracleConnection(
            //    ConfigurationManager.ConnectionStrings["ORAMETA"].ConnectionString
            //);
            con = new OracleConnection(ConfigurationManager.ConnectionStrings[connectionStr].ToString());
            //con = @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=211.46.7.24)(PORT=1521))(CONNECT_DATA=(SID=ORAKF)));User Id=KFMETA;Password=KFMETA;";

        }

        #endregion

        #region :: 전역변수 ::

        private readonly OracleConnection con;

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
            if (con != null && con.State == ConnectionState.Open) con.Close();

            GC.SuppressFinalize(true);
        }

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: NTx_ExecuteDataSet :: Transaction이 없는 일반 queryText로 DataSet을 Return 하는 Method입니다.

        /// <summary>
        /// Transaction이 없는 일반 queryText 및 SP 를 담당하는 Method입니다.
        /// </summary>
        /// <param name="command">Command String</param>
        /// <param name="cmdType">Command Type</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="valueList">Command Parameters Values</param>
        /// <returns></returns>
        public DataSet NTx_ExecuteDataSet(string command, string cmdType, string[] paramList = null, object[] valueList = null)
        {
            DataSet ds = new DataSet();
            string queryText = command;

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = command;
            cmd.Connection = con;

            switch (cmdType)
            {
                case "StoredProcedure":
                    cmd.CommandType = CommandType.StoredProcedure;
                    break;
                case "Text":
                    cmd.CommandType = CommandType.Text;
                    break;
                default:
                    cmd.CommandType = CommandType.Text;
                    break;
            }

            if (paramList != null)
            {
                for (int idx = 0; idx < paramList.Length; idx++)
                {
                    if (queryText.Contains(!paramList[idx].ToString().Contains(":") ? $":{paramList[idx]}".ToUpper() : paramList[idx].ToUpper()))
                    {
                        cmd.Parameters.Add(paramList[idx], GetParameterOracleType(valueList[idx])).Value = valueList[idx];

                        queryText = queryText.Replace(!paramList[idx].ToString().Contains(":") ? $":{paramList[idx]}".ToUpper() : paramList[idx].ToUpper(), "'" + valueList[idx] + "'");
                    }
                }
            }

            if (Debugger.IsAttached) Console.WriteLine(queryText);

            con.Open();
            OracleDataAdapter adapter = new OracleDataAdapter(queryText, con);
            adapter.Fill(ds);
            con.Close();

            return ds;
        }

        /// <summary>
        /// Transaction이 없는 일반 queryText 및 SP 를 담당하는 Method입니다.
        /// </summary>
        /// <param name="command">Command String</param>
        /// <param name="cmdType">Command Type</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="valueList">Command Parameters Values</param>
        /// <returns></returns>
        public DataSet NTx_ExecuteDataSetMultiTable(string dbName, string[] command, string cmdType, string[] paramList = null, object[] valueList = null)
        {
            DataSet ds = new DataSet();

            // 각 테이블의 데이터를 DataSet에 추가
            for (int i = 0; i < command.Length; i++)
            {
                string queryText = command[i];

                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = queryText;
                cmd.Connection = con;

                switch (cmdType)
                {
                    case "StoredProcedure":
                        cmd.CommandType = CommandType.StoredProcedure;
                        break;
                    case "Text":
                        cmd.CommandType = CommandType.Text;
                        break;
                    default:
                        cmd.CommandType = CommandType.Text;
                        break;
                }

                if (paramList != null)
                {
                    for (int idx = 0; idx < paramList.Length; idx++)
                    {
                        if (queryText.Contains(!paramList[idx].ToString().Contains(":") ? $":{paramList[idx]}".ToUpper() : paramList[idx].ToUpper()))
                        {
                            cmd.Parameters.Add(paramList[idx], GetParameterOracleType(valueList[idx])).Value = valueList[idx];

                            queryText = queryText.Replace(!paramList[idx].ToString().Contains(":") ? $":{paramList[idx]}".ToUpper() : paramList[idx].ToUpper(), "'" + valueList[idx].ToString() + "'");
                        }
                    }
                }

                if (Debugger.IsAttached) Console.WriteLine(queryText);

                con.Open();
                // DataAdapter를 통해 쿼리 실행 및 DataTable 생성
                using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                {
                    adapter.Fill(ds, "Table" + (i + 1));
                }

                con.Close();
            }

            return ds;
        }

        #endregion

        #region :: NTx_ExecuteScalar ::  Transaction이 없는 일반 queryText로 단일 값을 Return 하는 Method입니다.

        /// <summary>
        /// Transaction이 없는 일반 queryText로 단일 값을 Return 하는 Method입니다.
        /// </summary>/// <summary>
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
                    if (Debugger.IsAttached) Console.WriteLine(command);

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
        /// <param name="command">Command String</param>
        /// <param name="cmdType">Command Type</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="valueList">Command Parameters Values</param>
        /// <returns></returns>
        public object NTx_ExecuteScalar(string command, string cmdType, string[] paramList = null, object[] valueList = null)
        {
            object retValue = null;
            string queryText = command;

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = command;
            cmd.Connection = con;

            OracleParameter signinSeqParam = null;

            switch (cmdType)
            {
                case "StoredProcedure":
                    cmd.CommandType = CommandType.StoredProcedure;
                    break;
                case "Text":
                    cmd.CommandType = CommandType.Text;
                    break;
                default:
                    cmd.CommandType = CommandType.Text;
                    break;
            }

            if (paramList != null)
            {
                queryText = $"{command}(";

                for (int idx = 0; idx < paramList.Length; idx++)
                {
                    if (paramList[idx].Contains("v_"))
                    {
                        signinSeqParam = new OracleParameter(paramList[idx], OracleDbType.Int32)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(signinSeqParam);

                        queryText += $"{paramList[idx]});";
                    }
                    else
                    {
                        cmd.Parameters.Add(paramList[idx], GetParameterOracleType(valueList[idx])).Value = valueList[idx];

                        if (cmdType == "StoredProcedure")
                        {
                            queryText += String.Format("{0}=>'{1}', ", paramList[idx].Contains("") ? paramList[idx] : "" + paramList[idx], valueList[idx]);
                        }
                        else
                            queryText = queryText.Replace(!paramList[idx].ToString().Contains(":") ? $":{paramList[idx]}".ToUpper() : paramList[idx].ToUpper(), "'" + valueList[idx].ToString() + "'");

                    }
                }
            }

            if (Debugger.IsAttached) Console.WriteLine(queryText);

            con.Open();

            if (cmdType == "StoredProcedure")
            {
                cmd.ExecuteScalar();
                OracleDecimal oracleDecimal = (OracleDecimal)signinSeqParam.Value;
                retValue = oracleDecimal.ToInt32();  // 안전한 형 변환
            }
            else
                retValue = cmd.ExecuteScalar();


            con.Close();

            return retValue;
        }

        #endregion

        #region :: Tx_ExecuteNonQuery ::  Transaction이 있는 queryText로 영향을 받은 Row 수를 Return 하는 Method입니다.

        /// <summary>
        /// Transaction이 있는 단일 queryText로 영향을 받은 Row 수를 Return 하는 Method입니다.
        /// </summary>
        /// <param name="command">Command String</param>
        /// <param name="cmdType">Command Type</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="valueList">Command Parameters Values</param>
        /// <returns></returns>
        public int Tx_ExecuteNonQuery(string command, string cmdType, string[] paramList, object[] valueList)
        {
            int retValue = -1;
            string queryText = command;

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = command;
            cmd.Connection = con;

            OracleParameter signinSeqParam = null;
            //OracleParameter resultParam = new OracleParameter("o_result", OracleDbType.Int32);

            switch (cmdType)
            {
                case "StoredProcedure":
                    cmd.CommandType = CommandType.StoredProcedure;
                    break;
                case "Text":
                    cmd.CommandType = CommandType.Text;
                    break;
                default:
                    cmd.CommandType = CommandType.Text;
                    break;
            }

            if (paramList != null)
            {
                queryText = $"{command}(";

                for (int idx = 0; idx < paramList.Length; idx++)
                {
                    if (paramList[idx].Contains("v_"))
                    {
                        signinSeqParam = new OracleParameter(paramList[idx], OracleDbType.Int32)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(signinSeqParam);

                        queryText += $"{paramList[idx]});";
                    }
                    else
                    {
                        cmd.Parameters.Add(paramList[idx], GetParameterOracleType(valueList[idx])).Value = valueList[idx];

                        if (cmdType == "StoredProcedure")
                        {
                            queryText += String.Format("{0}=>'{1}', ", paramList[idx].Contains("") ? paramList[idx] : "" + paramList[idx], valueList[idx]);
                        }
                        else
                            queryText = queryText.Replace(!paramList[idx].ToString().Contains(":") ? $":{paramList[idx]}".ToUpper() : paramList[idx].ToUpper(), "'" + valueList[idx].ToString() + "'");

                    }
                }
            }

            if (Debugger.IsAttached) Console.WriteLine(queryText);

            con.Open();

            if (cmdType == "StoredProcedure")
            {
                cmd.ExecuteNonQuery();
                OracleDecimal oracleDecimal = (OracleDecimal)signinSeqParam.Value;
                retValue = oracleDecimal.ToInt32();  // 안전한 형 변환
            }
            else
                retValue = cmd.ExecuteNonQuery();

            con.Close();

            return retValue;
        }

        /// <summary>
        /// Transaction이 있는 단일 query로 영향을 받은 Row 수를 Return 하는 Method입니다.
        /// </summary>
        /// <param name="command">Command String</param>
        /// <param name="cmdType">Command Type</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="valueList">Command Parameters Values</param>
        /// <returns></returns>
        public int Tx_ExecuteNonQuery(string[] command, string cmdType, string[] paramList, object[] valueList)
        {
            int retValue = 0;

            using (OracleConnection connection = new OracleConnection(con.ConnectionString))
            {
                connection.Open();


                // 트랜잭션 시작
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 각 테이블의 데이터를 DataSet에 추가
                        for (int i = 0; i < command.Length; i++)
                        {
                            string queryText = command[i];
                            // 첫 번째 테이블의 DELETE 쿼리
                            using (OracleCommand cmd = new OracleCommand(queryText, connection))
                            {
                                switch (cmdType)
                                {
                                    case "StoredProcedure":
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        break;
                                    case "Text":
                                        cmd.CommandType = CommandType.Text;
                                        break;
                                    default:
                                        cmd.CommandType = CommandType.Text;
                                        break;
                                }

                                if (paramList != null)
                                {
                                    for (int idx = 0; idx < paramList.Length; idx++)
                                    {
                                        if (queryText.Contains(!paramList[idx].ToString().Contains(":") ? $":{paramList[idx]}".ToUpper() : paramList[idx].ToUpper()))
                                        {
                                            cmd.Parameters.Add(paramList[idx], GetParameterOracleType(valueList[idx])).Value = valueList[idx];

                                            queryText = queryText.Replace(!paramList[idx].ToString().Contains(":") ? $":{paramList[idx]}".ToUpper() : paramList[idx].ToUpper(), "'" + valueList[idx].ToString() + "'");
                                        }
                                    }

                                    if (Debugger.IsAttached) Console.WriteLine(queryText);
                                }

                                cmd.ExecuteNonQuery();
                            }
                        }

                        // 모든 작업이 성공하면 커밋
                        transaction.Commit();
                        Console.WriteLine("두 테이블의 레코드가 성공적으로 삭제되었습니다.");
                    }
                    catch (Exception ex)
                    {
                        // 오류가 발생하면 롤백
                        transaction.Rollback();
                        Console.WriteLine("오류 발생: " + ex.Message);
                    }
                }

                connection.Close();
            }

            return retValue;
        }

        #endregion

        #region :: Tx_ExecuteNonQueryByDataTable :: Transaction이 있는 queryText로 DataTable을 사용하여 Multi 처리하고 영향을 받은 Row 수를 Return 하는 Method입니다.

        /// <summary>
        /// Transaction이 있는 queryText로 DataTable을 사용하여 Multi 처리하고 영향을 받은 Row 수를 Return 하는 Method입니다.
        /// </summary>
        /// <param name="command">Command String</param>
        /// <param name="cmdType">Command Type</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="dt">Command Parameters Values(DataTable)</param>
        /// <returns></returns>
        public int Tx_ExecuteNonQueryByDataTable(string command, string cmdType, string[] paramList, DataTable dt)
        {
            int retValue = 0;
            string queryText = command;

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = command;
            cmd.Connection = con;

            switch (cmdType)
            {
                case "StoredProcedure":
                    cmd.CommandType = CommandType.StoredProcedure;
                    break;
                case "Text":
                    cmd.CommandType = CommandType.Text;
                    break;
                default:
                    cmd.CommandType = CommandType.Text;
                    break;
            }

            con.Open();

            OracleTransaction dbTran = con.BeginTransaction();

            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    queryText = command;

                    if (paramList != null)
                    {
                        for (int idx = 0; idx < paramList.Length; idx++)
                        {
                            if (queryText.Contains(!paramList[idx].ToString().Contains(":") ? $":{paramList[idx]}".ToUpper() : paramList[idx].ToUpper()))
                            {
                                //cmd.Parameters.Add(paramList[idx], GetParameterOracleType(dr[paramList[idx].Replace(":", "")])).Value = dr[paramList[idx].Replace(":", "")];
                                cmd.Parameters.Add(paramList[idx], dr[paramList[idx].Replace(":", "")]).Value = dr[paramList[idx].Replace(":", "")];

                                queryText = queryText.Replace(!paramList[idx].ToString().Contains(":") ? $":{paramList[idx]}".ToUpper() : paramList[idx].ToUpper(), "'" + dr[paramList[idx].Replace(":", "")].ToString() + "'");
                            }
                        }

                        if (Debugger.IsAttached) Console.WriteLine(queryText);
                    }

                    retValue += cmd.ExecuteNonQuery();

                    if (cmd.Parameters.Count > 0)
                        cmd.Parameters.Clear();
                }

                dt.AcceptChanges();
                dbTran.Commit();
            }
            catch
            {
                dbTran.Rollback();

                throw;
            }

            con.Close();

            return retValue;
        }

        /// <summary>
        /// Transaction이 있는 queryText로 DataTable을 사용하여 Multi 처리하고 영향을 받은 Row 수를 Return 하는 Method입니다.
        /// </summary>
        /// <param name="command">Command String</param>
        /// <param name="cmdType">Command Type</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="dt">Command Parameters Values(DataTable)</param>
        /// <returns></returns>
        public int Tx_ExecuteNonQueryByDataTable(string[] command, string cmdType, string[] paramList, DataTable dt)
        {
            int retValue = 0;

            using (OracleConnection connection = new OracleConnection(con.ConnectionString))
            {
                connection.Open();

                // 트랜잭션 시작
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 각 테이블의 데이터를 DataSet에 추가
                        for (int i = 0; i < command.Length; i++)
                        {
                            string queryText = command[i];
                            // 첫 번째 테이블의 DELETE 쿼리
                            using (OracleCommand cmd = new OracleCommand(queryText, connection))
                            {
                                switch (cmdType)
                                {
                                    case "StoredProcedure":
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        break;
                                    case "Text":
                                        cmd.CommandType = CommandType.Text;
                                        break;
                                    default:
                                        cmd.CommandType = CommandType.Text;
                                        break;
                                }

                                string baseQuery = queryText;   // ⭐ 원본 보관

                                foreach (DataRow dr in dt.Rows)
                                {
                                    queryText = baseQuery;      // ⭐ 매번 초기화

                                    if (paramList != null)
                                    {
                                        for (int idx = 0; idx < paramList.Length; idx++)
                                        {
                                            string param = paramList[idx]?.ToString();

                                            if (!string.IsNullOrEmpty(param))
                                            {
                                                if (!param.StartsWith(":"))
                                                    param = $":{param}";

                                                if (queryText.ToUpper().Contains(param.ToUpper()))
                                                {
                                                    cmd.Parameters.Add(
                                                        param,
                                                        GetParameterOracleType(dr[param.Replace(":", "")])
                                                    ).Value = dr[param.Replace(":", "")];

                                                    queryText = Regex.Replace(
                                                        queryText,
                                                        Regex.Escape(param.ToUpper()) + @"(?![A-Za-z0-9_])",
                                                        "'" + dr[param.Replace(":", "")].ToString() + "'"
                                                    );
                                                }
                                            }
                                        }

                                        if (Debugger.IsAttached) Console.WriteLine(queryText);
                                    }

                                    // ⭐ 여기서 실행
                                    cmd.CommandText = queryText;
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        dt.AcceptChanges();
                        // 모든 작업이 성공하면 커밋
                        transaction.Commit();
                        Console.WriteLine("두 테이블의 레코드가 성공적으로 삭제되었습니다.");
                    }
                    catch (Exception ex)
                    {
                        // 오류가 발생하면 롤백
                        transaction.Rollback();
                        Console.WriteLine("오류 발생: " + ex.Message);
                    }

                    connection.Close();
                }
            }

            return retValue;
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Private)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: GetParameterOracleType :: 파라미터의 값에 따라 OracleDbType을 정의합니다.

        /// <summary>
        /// 파라미터의 값에 따라 OracleType을 정의합니다.
        /// </summary>
        /// <param name="value">파라미터의 값</param>
        /// <returns></returns>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉(msNib)
        /// 변경내역
        /// 
        /// </remarks>
        private OracleDbType GetParameterOracleType(object value)
        {
            if (value == null)
            {
                return OracleDbType.Varchar2;
            }
            else if (value.GetType().Equals(Type.GetType("System.Byte[]")))
            {
                return OracleDbType.Blob;
            }
            else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.Decimal))))
            {
                return OracleDbType.Decimal;
            }
            else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.Int64))))
            {
                return OracleDbType.Int64;
            }
            else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.Int32))))
            {
                return OracleDbType.Int32;
            }
            else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.Int16))))
            {
                return OracleDbType.Int16;
            }
            else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.DateTime))))
            {
                return OracleDbType.Date;
            }
            else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.Single))))
            {
                return OracleDbType.Single;
            }
            else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.Boolean))))
            {
                return OracleDbType.Boolean;
            }
            else
            {
                return OracleDbType.Varchar2;
            }
        }

        #endregion
    }
}
