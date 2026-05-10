using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Data;
using System.Data.Common;
using System.Drawing;

namespace EBAP.Data.Factory
{
    /// <summary>
    /// MS-SQL Database와 연동하는 Sql Factory 클래스입니다.
    /// Microsoft.Practices.EnterpriseLibrary 5.0을 사용합니다.
    /// </summary>
    /// <remarks>
    /// 2023-02-01 최초생성 : 오인봉
    /// 변경내역
    /// 
    /// </remarks>
    public class SqlFactory : IDisposable
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// Sql Factory를 생성합니다.
        /// </summary>
        /// <param name="connectionStr">연결문자열</param>
        public SqlFactory(string connectionStr)
        {
            db = DatabaseFactory.CreateDatabase(connectionStr);
        }

        #endregion

        #region :: 전역변수 ::

        private readonly Database db;
        private string[] whiteList = new string[] { "SELECT GETDATE() AS CURRENTTIME",
                                                    "SELECT NOW() AS CURRENTTIME FROM DUAL",
                                                    "SELECT TOKENID FROM dbo.UserToken WHERE USERID = @USERID",
                                                    "BACKUP DATABASE" };

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
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: NTx_ExecuteDataSet :: Transaction이 없는 일반 Query로 DataSet을 Return 하는 Method입니다.

        /// <summary>
        /// Transaction이 없는 일반 Query 및 SP 를 담당하는 Method입니다.
        /// </summary>
        /// <param name="command">Command String</param>
        /// <param name="cmdType">Command Type</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="valueList">Command Parameters Values</param>
        /// <param name="outParam">Command Out Parameters</param>
        /// <param name="outValue">Command Out Parameters Values</param>
        /// <returns></returns>
        public DataSet NTx_ExecuteDataSet(string command, string cmdType, string[] paramList, object[] valueList, string[] outParam, ref object[] outValue)
        {
            DataSet ds = new DataSet();

            DbCommand dbCommand = null;

            switch (cmdType)
            {
                case "StoredProcedure":
                    dbCommand = db.GetStoredProcCommand(command);
                    break;
                case "Text":
                    dbCommand = db.GetSqlStringCommand(command);
                    break;
                default:
                    dbCommand = db.GetStoredProcCommand(command);
                    break;
            }
            dbCommand.CommandTimeout = 600;

            if (dbCommand.CommandType == CommandType.Text)
            {
                bool ISWHITELIST = false;

                foreach (string l in whiteList)
                {
                    if (command.Contains(l))
                    {
                        ISWHITELIST = true;
                        break;
                    }
                }
                if (!ISWHITELIST) return null;
            }

            if (paramList != null)
            {
                for (int idx = 0; idx < paramList.Length; idx++)
                {
                    db.AddInParameter(dbCommand, paramList[idx], GetParameterDbType(valueList[idx]), valueList[idx]);
                }
            }

            if (outParam != null)
            {
                for (int idx = 0; idx < outParam.Length; idx++)
                {
                    //db.AddParameter(dbCommand, outParam[idx], GetParameterDbType(outValue[idx]), ParameterDirection.InputOutput, outParam[idx], DataRowVersion.Current, outValue[idx]);
                    if (outParam[idx] == "RTNVALUE") continue;

                    db.AddOutParameter(dbCommand, outParam[idx], DbType.String, 4000);
                }
            }

            db.AddParameter(dbCommand, "RTNVALUE", DbType.Int32, ParameterDirection.ReturnValue, "RTNVALUE", DataRowVersion.Current, -99999);

            ds = db.ExecuteDataSet(dbCommand);

            if (outParam != null)
            {
                int rtlIndex = -1;

                for (int idx = 0; idx < outParam.Length; idx++)
                {
                    outValue[idx] = db.GetParameterValue(dbCommand, outParam[idx]);
                    if (outParam[idx] == "RTNVALUE")
                        rtlIndex = idx;
                }

                if (db.GetParameterValue(dbCommand, "RTNVALUE").ToString() != "-99999" && rtlIndex != -1)
                {
                    outValue[rtlIndex] = Convert.ToInt32(db.GetParameterValue(dbCommand, "RTNVALUE"));
                }
            }

            return ds;
        }

        #endregion

        #region :: NTx_ExecuteScalar ::  Transaction이 없는 일반 Query로 단일 값을 Return 하는 Method입니다.

        /// <summary>
        /// Transaction이 없는 일반 Query로 단일 값을 Return 하는 Method입니다.
        /// </summary>
        /// <param name="command">Command String</param>
        /// <param name="cmdType">Command Type</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="valueList">Command Parameters Values</param>
        /// <param name="outParam">Command Out Parameters</param>
        /// <param name="outValue">Command Out Parameters Values</param>
        /// <returns></returns>
        public object NTx_ExecuteScalar(string command, string cmdType, string[] paramList, object[] valueList, string[] outParam, ref object[] outValue)
        {
            object retValue = null;

            DbCommand dbCommand = null;

            switch (cmdType)
            {
                case "StoredProcedure":
                    dbCommand = db.GetStoredProcCommand(command);
                    break;
                case "Text":
                    dbCommand = db.GetSqlStringCommand(command);
                    break;
                default:
                    dbCommand = db.GetStoredProcCommand(command);
                    break;
            }
            dbCommand.CommandTimeout = 600;

            if (dbCommand.CommandType == CommandType.Text)
            {
                bool ISWHITELIST = false;

                foreach (string l in whiteList)
                {
                    if (command.Contains(l))
                    {
                        ISWHITELIST = true;
                        break;
                    }
                }
                if (!ISWHITELIST) return null;
            }

            if (paramList != null)
            {
                for (int idx = 0; idx < paramList.Length; idx++)
                {
                    db.AddInParameter(dbCommand, paramList[idx], GetParameterDbType(valueList[idx]), valueList[idx]);
                }
            }

            if (outParam != null)
            {
                for (int idx = 0; idx < outParam.Length; idx++)
                {
                    db.AddParameter(dbCommand, outParam[idx], GetParameterDbType(outValue[idx]), ParameterDirection.InputOutput, outParam[idx], DataRowVersion.Current, outValue[idx]);
                }
            }

            retValue = db.ExecuteScalar(dbCommand);

            if (outParam != null)
            {
                for (int idx = 0; idx < outParam.Length; idx++)
                {
                    outValue[idx] = db.GetParameterValue(dbCommand, outParam[idx]);
                }
            }

            return retValue;
        }

        #endregion

        #region :: Tx_ExecuteNonQuery ::  Transaction이 있는 Query로 영향을 받은 Row 수를 Return 하는 Method입니다.

        /// <summary>
        /// Transaction이 있는 단일 Query로 영향을 받은 Row 수를 Return 하는 Method입니다.
        /// </summary>
        /// <param name="command">Command String</param>
        /// <param name="cmdType">Command Type</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="valueList">Command Parameters Values</param>
        /// <param name="outParam">Command Out Parameters</param>
        /// <param name="outValue">Command Out Parameters Values</param>
        /// <returns></returns>
        public int Tx_ExecuteNonQuery(string command, string cmdType, string[] paramList, object[] valueList, string[] outParam, ref object[] outValue)
        {
            int retValue = -1;

            DbCommand dbCommand = null;

            switch (cmdType)
            {
                case "StoredProcedure":
                    dbCommand = db.GetStoredProcCommand(command);
                    break;
                case "Text":
                    dbCommand = db.GetSqlStringCommand(command);
                    break;
                default:
                    dbCommand = db.GetStoredProcCommand(command);
                    break;
            }

            dbCommand.CommandTimeout = 600;
            dbCommand.UpdatedRowSource = UpdateRowSource.Both;

            if (dbCommand.CommandType == CommandType.Text)
            {
                bool ISWHITELIST = false;

                foreach (string l in whiteList)
                {
                    if (command.Contains(l))
                    {
                        ISWHITELIST = true;
                        break;
                    }
                }
                if (!ISWHITELIST) return -999999;
            }

            if (paramList != null)
            {
                for (int idx = 0; idx < paramList.Length; idx++)
                {
                    db.AddInParameter(dbCommand, paramList[idx], GetParameterDbType(valueList[idx]), valueList[idx]);
                }
            }

            if (outParam != null)
            {
                for (int idx = 0; idx < outParam.Length; idx++)
                {
                    //db.AddParameter(dbCommand, outParam[idx], GetParameterDbType(outValue[idx]), ParameterDirection.Output, outParam[idx], DataRowVersion.Current, outValue[idx]);
                    db.AddOutParameter(dbCommand, outParam[idx], DbType.String, 4000);
                }
            }

            db.AddParameter(dbCommand, "RTNVALUE", DbType.Int32, ParameterDirection.ReturnValue, "RTNVALUE", DataRowVersion.Current, -99999);

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction dbTran = connection.BeginTransaction();

                try
                {
                    retValue = db.ExecuteNonQuery(dbCommand, dbTran);

                    dbTran.Commit();
                }
                catch
                {
                    dbTran.Rollback();

                    throw;
                }

                connection.Close();
            }

            if (outParam != null)
            {
                for (int idx = 0; idx < outParam.Length; idx++)
                {
                    outValue[idx] = db.GetParameterValue(dbCommand, outParam[idx]) == null ? "" : db.GetParameterValue(dbCommand, outParam[idx]);
                }
            }

            retValue = db.GetParameterValue(dbCommand, "RTNVALUE").ToString() != "0" ? Convert.ToInt32(db.GetParameterValue(dbCommand, "RTNVALUE")) : retValue;

            return retValue;
        }

        #endregion

        #region :: Tx_ExecuteNonQueryByDataTable :: Transaction이 있는 Query로 DataTable을 사용하여 Multi 처리하고 영향을 받은 Row 수를 Return 하는 Method입니다.

        /// <summary>
        /// Transaction이 있는 Query로 DataTable을 사용하여 Multi 처리하고 영향을 받은 Row 수를 Return 하는 Method입니다.
        /// </summary>
        /// <param name="command">Command String</param>
        /// <param name="cmdType">Command Type</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="dt">Command Parameters Values(DataTable)</param>
        /// <param name="outParam">Command Out Parameters</param>
        /// <param name="outValue">Command Out Parameters Values</param>
        /// <returns></returns>
        public int Tx_ExecuteNonQueryByDataTable(string command, string cmdType, string[] paramList, DataTable dt, string[] outParam, ref object[] outValue)
        {
            int retValue = 0;

            DbCommand dbCommand = null;

            switch (cmdType)
            {
                case "StoredProcedure":
                    dbCommand = db.GetStoredProcCommand(command);
                    break;
                case "Text":
                    dbCommand = db.GetSqlStringCommand(command);
                    break;
                default:
                    dbCommand = db.GetStoredProcCommand(command);
                    break;
            }
            dbCommand.CommandTimeout = 600;
            dbCommand.UpdatedRowSource = UpdateRowSource.Both;

            if (dbCommand.CommandType == CommandType.Text)
            {
                bool ISWHITELIST = false;

                foreach (string l in whiteList)
                {
                    if (command.Contains(l))
                    {
                        ISWHITELIST = true;
                        break;
                    }
                }
                if (!ISWHITELIST) return -999999;
            }

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction dbTran = connection.BeginTransaction();

                try
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (paramList != null)
                        {
                            for (int idx = 0; idx < paramList.Length; idx++)
                            {
                                db.AddInParameter(dbCommand, paramList[idx], GetParameterDbType(dt.Columns[paramList[idx].Replace("@", "")]), dr[paramList[idx].Replace("@", "")]);
                            }
                        }

                        if (outParam != null)
                        {
                            for (int idx = 0; idx < outParam.Length; idx++)
                            {
                                db.AddParameter(dbCommand, outParam[idx], GetParameterDbType(outValue[idx]), ParameterDirection.InputOutput, outParam[idx], DataRowVersion.Current, outValue[idx]);
                            }
                        }

                        retValue += db.ExecuteNonQuery(dbCommand, dbTran);

                        if (outParam != null)
                        {
                            for (int idx = 0; idx < outParam.Length; idx++)
                            {
                                outValue[idx] = db.GetParameterValue(dbCommand, outParam[idx]);
                            }
                        }

                        if (dbCommand.Parameters.Count > 0)
                            dbCommand.Parameters.Clear();
                    }
                    dt.AcceptChanges();
                    dbTran.Commit();
                }
                catch
                {
                    dbTran.Rollback();

                    throw;
                }

                connection.Close();
            }

            return retValue;
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Private)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: GetParameterDbType :: 파라미터의 값에 따라 DbType을 정의합니다.

        /// <summary>
        /// 파라미터의 값에 따라 DbType을 정의합니다.
        /// </summary>
        /// <param name="value">파라미터의 값</param>
        /// <returns></returns>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        private DbType GetParameterDbType(DataColumn value)
        {
            if (value.DataType.Equals(Type.GetType("System.Byte[]")))
            {
                return DbType.Binary;
            }
            else if (value.DataType.Equals(Type.GetType(String.Format("System.{0}", TypeCode.Decimal))))
            {
                return DbType.Decimal;
            }
            else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.Int64))))
            {
                return DbType.Int64;
            }
            else if (value.DataType.Equals(Type.GetType(String.Format("System.{0}", TypeCode.Int32))))
            {
                return DbType.Int32;
            }
            else if (value.DataType.Equals(Type.GetType(String.Format("System.{0}", TypeCode.Int16))))
            {
                return DbType.Int16;
            }
            else if (value.DataType.Equals(Type.GetType(String.Format("System.{0}", TypeCode.Single))))
            {
                return DbType.Single;
            }
            else if (value.DataType.Equals(Type.GetType(String.Format("System.{0}", TypeCode.DateTime))))
            {
                return DbType.DateTime;
            }
            else if (value.DataType.Equals(Type.GetType(String.Format("System.{0}", TypeCode.Boolean))))
            {
                return DbType.Boolean;
            }
            else
            {
                return DbType.String;
            }
        }

        /// <summary>
        /// 파라미터의 값에 따라 DbType을 정의합니다.
        /// </summary>
        /// <param name="value">파라미터의 값</param>
        /// <returns></returns>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉(msNib)
        /// 변경내역
        /// 
        /// </remarks>
        private DbType GetParameterDbType(object value)
        {
            if (value == null)
            {
                return DbType.String;
            }
            else if (value.GetType().Equals(Type.GetType("System.Byte[]")))
            {
                return DbType.Binary;
            }
            else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.Decimal))))
            {
                return DbType.Decimal;
            }
            else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.Int64))))
            {
                return DbType.Int64;
            }
            else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.Int32))))
            {
                return DbType.Int32;
            }
            else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.Int16))))
            {
                return DbType.Int16;
            }
            else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.DateTime))))
            {
                return DbType.DateTime;
            }
            else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.Single))))
            {
                return DbType.Single;
            }
            else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.Boolean))))
            {
                return DbType.Boolean;
            }
            else
            {
                return DbType.String;
            }
        }

        #endregion
    }
}
