using EBAP.Data.Compaction;
//using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Web.Services;
using EBAP.Data.Factory;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class Service : System.Web.Services.WebService
{
    #region :: FTP 관련 Web Method ::

    /// <summary>
    /// [FTP]를 사용하여 Image를 가져옵니다.
    /// </summary>
    /// <param name="ip"></param>
    /// <param name="directory"></param>
    /// <param name="serverFile"></param>
    /// <param name="user"></param>
    /// <param name="pwd"></param>
    /// <param name="port"></param>
    /// <returns></returns>
    [WebMethod(Description = "[FTP]를 사용하여 Image를 가져옵니다.")]
    public byte[] GetImageFromFTP(string ip, string directory, string serverFile, string user, string pwd, int port)
    {
        WebResponse response = null;
        Stream stream = null;
        FtpWebRequest ftp = null;

        Uri uri = null;

        string clientPath = string.Empty;

        try
        {
            uri = new Uri(String.Format(@"ftp://{0}:{1}{2}", ip, port, Path.Combine(directory, serverFile)));

            ftp = (FtpWebRequest)WebRequest.Create(uri);
            ftp.UseBinary = true;
            ftp.Method = WebRequestMethods.Ftp.DownloadFile;
            ftp.Credentials = new NetworkCredential(user, pwd);

            response = ftp.GetResponse();
            stream = response.GetResponseStream();

            Image image = Image.FromStream(stream);

            MemoryStream mStream = new MemoryStream();
            image.Save(mStream, ImageFormat.Png);

            return mStream.ToArray();
        }
        catch
        {
            throw;
        }
        finally
        {
            if (response != null) response.Close();
            if (stream != null) stream.Close();
        }
    }

    #endregion


    #region :: MS-SQL Non Transaction 관련 Web Method ::

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dbName"></param>
    /// <param name="command"></param>
    /// <param name="cmdType"></param>
    /// <param name="paramList"></param>
    /// <param name="valueList"></param>
    /// <param name="outParam"></param>
    /// <param name="outValue"></param>
    /// <returns></returns>
    [WebMethod(Description = "[MS-SQL]쿼리를 실행하여 DataSet을 반환하는 Web Method 입니다.")]
    public DataSet NTx_ExecuteDataSet(string dbName, string command, string cmdType, string[] paramList, object[] valueList, string[] outParam, ref object[] outValue)
    {
        try
        {
            SqlFactory sf = new SqlFactory(dbName);

            DataSet ds = sf.NTx_ExecuteDataSet(command, cmdType, paramList, valueList, outParam, ref outValue);

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
    /// <param name="dbName"></param>
    /// <param name="command"></param>
    /// <param name="cmdType"></param>
    /// <param name="paramList"></param>
    /// <param name="valueList"></param>
    /// <param name="outParam"></param>
    /// <param name="outValue"></param>
    /// <returns></returns>
    [WebMethod(Description = "[MS-SQL]쿼리를 실행하여 DataSet을 압축하여 반환하는 Web Method 입니다.")]
    public byte[] NTx_ExecuteDataSetCompress(string dbName, string command, string cmdType, string[] paramList, object[] valueList, string[] outParam, ref object[] outValue)
    {
        try
        {
            SqlFactory sf = new SqlFactory(dbName);
            
            DataSet ds = sf.NTx_ExecuteDataSet(command, cmdType, paramList, valueList, outParam, ref outValue);

            CompressDataSet compress = new CompressDataSet();
            
            return compress.ZipData(ds);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="queryId"></param>
    /// <param name="paramList"></param>
    /// <param name="valueList"></param>
    /// <param name="outParam"></param>
    /// <param name="outValue"></param>
    /// <returns></returns>
    [WebMethod(Description = "[MS-SQL]XML 파일에서 쿼리를 실행하여 DataSet을 반환하는 Web Method 입니다.")]
    public DataSet NTx_ExecuteDataSetFromXML(string queryId, string[] paramList, object[] valueList, string[] outParam, ref object[] outValue)
    {
        try
        {
            XMLQueryParser xParser = new XMLQueryParser(queryId);

            xParser.GetXMLQuery();

            if (xParser.QUERY == string.Empty) throw new MissingFieldException();

            SqlFactory sf = new SqlFactory(xParser.DBNAME);

            DataSet ds = sf.NTx_ExecuteDataSet(xParser.QUERY, xParser.COMMANDTYPE, paramList, valueList, outParam, ref outValue);

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
    /// <param name="queryId"></param>
    /// <param name="paramList"></param>
    /// <param name="valueList"></param>
    /// <param name="outParam"></param>
    /// <param name="outValue"></param>
    /// <returns></returns>
    [WebMethod(Description = "[MS-SQL]XML 파일에서 쿼리를 실행하여 DataSet을 압축하여 반환하는 Web Method 입니다.")]
    public byte[] NTx_ExecuteDataSetFromXMLCompress(string queryId, string[] paramList, object[] valueList, string[] outParam, ref object[] outValue)
    {
        try
        {
            XMLQueryParser xParser = new XMLQueryParser(queryId);

            xParser.GetXMLQuery();

            if (xParser.QUERY == string.Empty) throw new MissingFieldException();

            SqlFactory sf = new SqlFactory(xParser.DBNAME);

            DataSet ds = sf.NTx_ExecuteDataSet(xParser.QUERY, xParser.COMMANDTYPE, paramList, valueList, outParam, ref outValue);

            CompressDataSet compress = new CompressDataSet();

            return compress.ZipData(ds);
        }
        catch
        {
            throw;
        }
    }



    /// <summary>
    /// 
    /// </summary>
    /// <param name="queryId"></param>
    /// <param name="paramList"></param>
    /// <param name="valueList"></param>
    /// <param name="outParam"></param>
    /// <param name="outValue"></param>
    /// <returns></returns>
    [WebMethod(Description = "[MS-SQL]DB에서 Query ID로 쿼리를 실행하여 DataSet을 반환하는 Web Method 입니다.")]
    public DataSet NTx_ExecuteDataSetFromQueryId(string queryId, string[] paramList, object[] valueList, string[] outParam, ref object[] outValue)
    {
        try
        {
            QueryFinder finder = new QueryFinder(queryId);

            if (finder.QUERY == string.Empty) throw new RowNotInTableException();

            SqlFactory sf = new SqlFactory(finder.DBNAME);

            DataSet ds = sf.NTx_ExecuteDataSet(finder.QUERY, finder.COMMANDTYPE, paramList, valueList, outParam, ref outValue);

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
    /// <param name="queryId"></param>
    /// <param name="paramList"></param>
    /// <param name="valueList"></param>
    /// <param name="outParam"></param>
    /// <param name="outValue"></param>
    /// <returns></returns>
    [WebMethod(Description = "[MS-SQL]DB에서 Query ID로 쿼리를 실행하여 DataSet을 압축하여 반환하는 Web Method 입니다.")]
    public byte[] NTx_ExecuteDataSetFromQueryIdCompress(string queryId, string[] paramList, object[] valueList, string[] outParam, ref object[] outValue)
    {
        try
        {
            QueryFinder finder = new QueryFinder(queryId);

            if (finder.QUERY == string.Empty) throw new RowNotInTableException();

            SqlFactory sf = new SqlFactory(finder.DBNAME);

            DataSet ds = sf.NTx_ExecuteDataSet(finder.QUERY, finder.COMMANDTYPE, paramList, valueList, outParam, ref outValue);

            CompressDataSet compress = new CompressDataSet();

            return compress.ZipData(ds);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dbName"></param>
    /// <param name="command"></param>
    /// <param name="cmdType"></param>
    /// <param name="paramList"></param>
    /// <param name="valueList"></param>
    /// <param name="outParam"></param>
    /// <param name="outValue"></param>
    /// <returns></returns>
    [WebMethod(Description = "[MS-SQL]쿼리를 실행하여 object을 반환하는 Web Method 입니다.")]
    public object NTx_ExecuteScalar(string dbName, string command, string cmdType, string[] paramList, object[] valueList, string[] outParam, ref object[] outValue)
    {
        try
        {
            SqlFactory sf = new SqlFactory(dbName);

            object value = sf.NTx_ExecuteScalar(command, cmdType, paramList, valueList, outParam, ref outValue);

            return value;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dbName"></param>
    /// <param name="command"></param>
    /// <param name="cmdType"></param>
    /// <param name="paramList"></param>
    /// <param name="valueList"></param>
    /// <param name="outParam"></param>
    /// <param name="outValue"></param>
    /// <returns></returns>
    [WebMethod(Description = "[MS-SQL]쿼리를 실행하여 object을 반환하는 Web Method 입니다.")]
    public object NTx_ExecuteScalarFromXML(string queryId, string[] paramList, object[] valueList, string[] outParam, ref object[] outValue)
    {
        try
        {
            XMLQueryParser xParser = new XMLQueryParser(queryId);

            xParser.GetXMLQuery();

            if (xParser.QUERY == string.Empty) throw new MissingFieldException();

            SqlFactory sf = new SqlFactory(xParser.DBNAME);

            object value = sf.NTx_ExecuteScalar(xParser.QUERY, xParser.COMMANDTYPE, paramList, valueList, outParam, ref outValue);

            return value;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dbName"></param>
    /// <param name="command"></param>
    /// <param name="cmdType"></param>
    /// <param name="paramList"></param>
    /// <param name="valueList"></param>
    /// <param name="outParam"></param>
    /// <param name="outValue"></param>
    /// <returns></returns>
    [WebMethod(Description = "[MS-SQL]쿼리를 실행하여 object을 반환하는 Web Method 입니다.")]
    public object NTx_ExecuteScalarFromQueryId(string queryId, string[] paramList, object[] valueList, string[] outParam, ref object[] outValue)
    {
        try
        {
            QueryFinder finder = new QueryFinder(queryId);

            if (finder.QUERY == string.Empty) throw new RowNotInTableException();

            SqlFactory sf = new SqlFactory(finder.DBNAME);

            object value = sf.NTx_ExecuteScalar(finder.QUERY, finder.COMMANDTYPE, paramList, valueList, outParam, ref outValue);

            return value;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// XML에서 Query ID로 쿼리정보를 가져옵니다.
    /// </summary>
    /// <param name="queryId"></param>
    /// <returns></returns>
    [WebMethod(Description = "XML에서 Query ID로 쿼리정보를 가져옵니다.")]
    public string[] NTx_GetQueryInfoFromXML(string queryId)
    {
        XMLQueryParser xParser = new XMLQueryParser(queryId);

        xParser.GetXMLQuery();

        if (xParser.QUERY == string.Empty) throw new MissingFieldException();

        List<string> info = new List<string>();
        info.Add(xParser.QUERY);
        info.Add(xParser.DBNAME);
        info.Add(xParser.COMMANDTYPE);

        return info.ToArray();
    }

    #endregion

    #region :: MS-SQL Transaction 관련 Web Method ::

    [WebMethod(Description = "[MS-SQL]쿼리를 실행하여 영향을 받은 Row 수를 반환하는 Web Method 입니다.")]
    public int Tx_ExecuteNonQuery(string dbName, string command, string cmdType, string[] paramList, object[] valueList, string[] outParam, ref object[] outValue)
    {
        try
        {
            //DateTime startDttm = DateTime.Now;

            int value = -1;

            SqlFactory sf = new SqlFactory(dbName);

            value = sf.Tx_ExecuteNonQuery(command, cmdType, paramList, valueList, outParam, ref outValue);

            //UseLogSave("Tx_ExecuteNonQuery", command, startDttm, DateTime.Now);

            return value;
        }
        catch
        {
            throw;
        }
    }

    [WebMethod(Description = "[MS-SQL]DataTable을 사용하여 쿼리를 실행하여 처리하고 영향을 받은 Row 수를 반환하는 Web Method 입니다.")]
    public int Tx_ExecuteNonQueryByDataTable(string dbName, string command, string cmdType, string[] paramList, DataTable dt, string[] outParam, ref object[] outValue)
    {
        try
        {
            int value = -1;

            SqlFactory sf = new SqlFactory(dbName);

            value = sf.Tx_ExecuteNonQueryByDataTable(command, cmdType, paramList, dt, outParam, ref outValue);

            return value;
        }
        catch
        {
            throw;
        }
    }

    [WebMethod(Description = "[MS-SQL]DataTable을 사용하여 쿼리를 실행하여 처리하고 영향을 받은 Row 수를 반환하는 Web Method 입니다.")]
    public int Tx_ExecuteNonQueryByDataTableCompress(string dbName, string command, string cmdType, string[] paramList, byte[] bData, string[] outParam, ref object[] outValue)
    {
        try
        {
            int value = -1;

            SqlFactory sf = new SqlFactory(dbName);

            CompressDataSet compress = new CompressDataSet();

            DataTable dt = compress.UnzipDataDataTable(bData);

            value = sf.Tx_ExecuteNonQueryByDataTable(command, cmdType, paramList, dt, outParam, ref outValue);

            return value;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="queryId"></param>
    /// <param name="paramList"></param>
    /// <param name="valueList"></param>
    /// <param name="outParam"></param>
    /// <param name="outValue"></param>
    /// <returns></returns>
    [WebMethod(Description = "[MS-SQL]XML파일에서 쿼리를 실행하여 처리하고 영향을 받은 Row 수를 반환하는 Web Method 입니다.")]
    public int Tx_ExecuteNonQueryFromXML(string queryId, string[] paramList, object[] valueList, string[] outParam, ref object[] outValue)
    {
        try
        {
            int value = -1;

            XMLQueryParser xParser = new XMLQueryParser(queryId);

            xParser.GetXMLQuery();

            SqlFactory sf = new SqlFactory(xParser.DBNAME);

            value = sf.Tx_ExecuteNonQuery(xParser.QUERY, xParser.COMMANDTYPE, paramList, valueList, outParam, ref outValue);

            return value;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="queryId"></param>
    /// <param name="paramList"></param>
    /// <param name="dt"></param>
    /// <param name="outParam"></param>
    /// <param name="outValue"></param>
    /// <returns></returns>
    [WebMethod(Description = "[MS-SQL]XML과 DataTable을 사용하여 쿼리를 실행하여 처리하고 영향을 받은 Row 수를 반환하는 Web Method 입니다.")]
    public int Tx_ExecuteNonQueryFromXMLByDataTable(string queryId, string[] paramList, DataTable dt, string[] outParam, ref object[] outValue)
    {
        try
        {
            int value = -1;

            XMLQueryParser xParser = new XMLQueryParser(queryId);

            xParser.GetXMLQuery();

            SqlFactory sf = new SqlFactory(xParser.DBNAME);

            value = sf.Tx_ExecuteNonQueryByDataTable(xParser.QUERY, xParser.COMMANDTYPE, paramList, dt, outParam, ref outValue);

            return value;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="queryId"></param>
    /// <param name="paramList"></param>
    /// <param name="bData"></param>
    /// <param name="outParam"></param>
    /// <param name="outValue"></param>
    /// <returns></returns>
    [WebMethod(Description = "[MS-SQL]XML과 DataTable을 사용하여 쿼리를 실행하여 처리하고 영향을 받은 Row 수를 반환하는 Web Method 입니다.")]
    public int Tx_ExecuteNonQueryFromXMLByDataTableCompress(string queryId, string[] paramList, byte[] bData, string[] outParam, ref object[] outValue)
    {
        try
        {
            int value = -1;

            XMLQueryParser xParser = new XMLQueryParser(queryId);

            xParser.GetXMLQuery();

            SqlFactory sf = new SqlFactory(xParser.DBNAME);

            CompressDataSet compress = new CompressDataSet();

            DataTable dt = compress.UnzipDataDataTable(bData);

            value = sf.Tx_ExecuteNonQueryByDataTable(xParser.QUERY, xParser.COMMANDTYPE, paramList, dt, outParam, ref outValue);

            return value;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="queryId"></param>
    /// <param name="paramList"></param>
    /// <param name="valueList"></param>
    /// <param name="outParam"></param>
    /// <param name="outValue"></param>
    /// <returns></returns>
    [WebMethod(Description = "[MS-SQL]DB의 Qury ID를 사용하여 쿼리를 실행하여 처리하고 영향을 받은 Row 수를 반환하는 Web Method 입니다.")]
    public int Tx_ExecuteNonQueryFromQueryId(string queryId, string[] paramList, object[] valueList, string[] outParam, ref object[] outValue)
    {
        try
        {
            int value = -1;

            QueryFinder finder = new QueryFinder(queryId);

            SqlFactory sf = new SqlFactory(finder.DBNAME);

            value = sf.Tx_ExecuteNonQuery(finder.QUERY, finder.COMMANDTYPE, paramList, valueList, outParam, ref outValue);

            return value;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="queryId"></param>
    /// <param name="paramList"></param>
    /// <param name="dt"></param>
    /// <param name="outParam"></param>
    /// <param name="outValue"></param>
    /// <returns></returns>
    [WebMethod(Description = "[MS-SQL]DB의 Qury ID와 DataTable을 사용하여 쿼리를 실행하여 처리하고 영향을 받은 Row 수를 반환하는 Web Method 입니다.")]
    public int Tx_ExecuteNonQueryFromQueryIdByDataTable(string queryId, string[] paramList, DataTable dt, string[] outParam, ref object[] outValue)
    {
        try
        {
            int value = -1;

            QueryFinder finder = new QueryFinder(queryId);

            SqlFactory sf = new SqlFactory(finder.DBNAME);

            value = sf.Tx_ExecuteNonQueryByDataTable(finder.QUERY, finder.COMMANDTYPE, paramList, dt, outParam, ref outValue);

            return value;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="queryId"></param>
    /// <param name="paramList"></param>
    /// <param name="bData"></param>
    /// <param name="outParam"></param>
    /// <param name="outValue"></param>
    /// <returns></returns>
    [WebMethod(Description = "[MS-SQL]DB의 Qury ID와 DataTable을 사용하여 쿼리를 실행하여 처리하고 영향을 받은 Row 수를 반환하는 Web Method 입니다.")]
    public int Tx_ExecuteNonQueryFromQueryIdByDataTableCompress(string queryId, string[] paramList, byte[] bData, string[] outParam, ref object[] outValue)
    {
        try
        {
            int value = -1;

            QueryFinder finder = new QueryFinder(queryId);

            SqlFactory sf = new SqlFactory(finder.DBNAME);

            CompressDataSet compress = new CompressDataSet();

            DataTable dt = compress.UnzipDataDataTable(bData);

            value = sf.Tx_ExecuteNonQueryByDataTable(finder.QUERY, finder.COMMANDTYPE, paramList, dt, outParam, ref outValue);

            return value;
        }
        catch
        {
            throw;
        }
    }

    #endregion

    
    #region :: Oracle Non Transaction 관련 Web Method ::

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dbName"></param>
    /// <param name="command"></param>
    /// <param name="cmdType"></param>
    /// <param name="paramList"></param>
    /// <param name="valueList"></param>
    /// <param name="outParam"></param>
    /// <param name="outValue"></param>
    /// <returns></returns>
    [WebMethod(Description = "[Oracle]쿼리를 실행하여 DataSet을 반환하는 Web Method 입니다.")]
    public DataSet ONTx_ExecuteDataSet(string dbName, string command, string cmdType, string[] paramList, object[] valueList, string[] outParam, ref object[] outValue)
    {
        try
        {
            OracleFactory of = new OracleFactory(dbName);

            //DataSet ds = of.NTx_ExecuteDataSet(command, cmdType, paramList, valueList, outParam, ref outValue);
            DataSet ds = of.NTx_ExecuteDataSet(command, cmdType, paramList, valueList);

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
    /// <param name="dbName"></param>
    /// <param name="command"></param>
    /// <param name="cmdType"></param>
    /// <param name="paramList"></param>
    /// <param name="valueList"></param>
    /// <param name="outParam"></param>
    /// <param name="outValue"></param>
    /// <returns></returns>
    [WebMethod(Description = "[Oracle]쿼리를 실행하여 DataSet을 압축하여 반환하는 Web Method 입니다.")]
    public byte[] ONTx_ExecuteDataSetCompress(string dbName, string command, string cmdType, string[] paramList, object[] valueList, string[] outParam, ref object[] outValue)
    {
        try
        {
            OracleFactory of = new OracleFactory(dbName);

            //DataSet ds = of.NTx_ExecuteDataSet(command, cmdType, paramList, valueList, outParam, ref outValue);
            DataSet ds = of.NTx_ExecuteDataSet(command, cmdType, paramList, valueList);

            CompressDataSet compress = new CompressDataSet();
            
            return compress.ZipData(ds);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="queryId"></param>
    /// <param name="paramList"></param>
    /// <param name="valueList"></param>
    /// <param name="outParam"></param>
    /// <param name="outValue"></param>
    /// <returns></returns>
    [WebMethod(Description = "[Oracle]XML 파일에서 쿼리를 실행하여 DataSet을 반환하는 Web Method 입니다.")]
    public DataSet ONTx_ExecuteDataSetFromXML(string queryId, string[] paramList, object[] valueList, string[] outParam, ref object[] outValue)
    {
        try
        {
            XMLQueryParser xParser = new XMLQueryParser(queryId);

            xParser.GetXMLQuery();

            OracleFactory of = new OracleFactory(xParser.DBNAME);

            //DataSet ds = of.NTx_ExecuteDataSet(xParser.QUERY, xParser.COMMANDTYPE, paramList, valueList, outParam, ref outValue);
            DataSet ds = of.NTx_ExecuteDataSet(xParser.QUERY, xParser.COMMANDTYPE, paramList, valueList);

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
    /// <param name="queryId"></param>
    /// <param name="paramList"></param>
    /// <param name="valueList"></param>
    /// <param name="outParam"></param>
    /// <param name="outValue"></param>
    /// <returns></returns>
    [WebMethod(Description = "[Oracle]XML 파일에서 쿼리를 실행하여 DataSet을 압축하여 반환하는 Web Method 입니다.")]
    public byte[] ONTx_ExecuteDataSetFromXMLCompress(string queryId, string[] paramList, object[] valueList, string[] outParam, ref object[] outValue)
    {
        try
        {
            XMLQueryParser xParser = new XMLQueryParser(queryId);

            xParser.GetXMLQuery();

            OracleFactory of = new OracleFactory(xParser.DBNAME);

            //DataSet ds = of.NTx_ExecuteDataSet(xParser.QUERY, xParser.COMMANDTYPE, paramList, valueList, outParam, ref outValue);
            DataSet ds = of.NTx_ExecuteDataSet(xParser.QUERY, xParser.COMMANDTYPE, paramList, valueList);

            CompressDataSet compress = new CompressDataSet();
            
            return compress.ZipData(ds);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="queryId"></param>
    /// <param name="paramList"></param>
    /// <param name="valueList"></param>
    /// <param name="outParam"></param>
    /// <param name="outValue"></param>
    /// <returns></returns>
    [WebMethod(Description = "[Oracle]DB Query Master에서 쿼리를 실행하여 DataSet을 반환하는 Web Method 입니다.")]
    public DataSet ONTx_ExecuteDataSetFromQueryId(string queryId, string[] paramList, object[] valueList, string[] outParam, ref object[] outValue)
    {
        try
        {
            QueryFinder finder = new QueryFinder(queryId);

            OracleFactory of = new OracleFactory(finder.DBNAME);

            //DataSet ds = of.NTx_ExecuteDataSet(finder.QUERY, finder.COMMANDTYPE, paramList, valueList, outParam, ref outValue);
            DataSet ds = of.NTx_ExecuteDataSet(finder.QUERY, finder.COMMANDTYPE, paramList, valueList);

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
    /// <param name="queryId"></param>
    /// <param name="paramList"></param>
    /// <param name="valueList"></param>
    /// <param name="outParam"></param>
    /// <param name="outValue"></param>
    /// <returns></returns>
    [WebMethod(Description = "[Oracle]DB Query Master에서 쿼리를 실행하여 DataSet을 압축하여 반환하는 Web Method 입니다.")]
    public byte[] ONTx_ExecuteDataSetFromQueryIdCompress(string queryId, string[] paramList, object[] valueList, string[] outParam, ref object[] outValue)
    {
        try
        {
            QueryFinder finder = new QueryFinder(queryId);

            OracleFactory of = new OracleFactory(finder.DBNAME);

            //DataSet ds = of.NTx_ExecuteDataSet(finder.QUERY, finder.COMMANDTYPE, paramList, valueList, outParam, ref outValue);
            DataSet ds = of.NTx_ExecuteDataSet(finder.QUERY, finder.COMMANDTYPE, paramList, valueList);

            CompressDataSet compress = new CompressDataSet();

            return compress.ZipData(ds);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dbName"></param>
    /// <param name="command"></param>
    /// <param name="cmdType"></param>
    /// <param name="paramList"></param>
    /// <param name="valueList"></param>
    /// <param name="outParam"></param>
    /// <param name="outValue"></param>
    /// <returns></returns>
    [WebMethod(Description = "[Oracle]쿼리를 실행하여 object을 반환하는 Web Method 입니다.")]
    public object ONTx_ExecuteScalar(string dbName, string command, string cmdType, string[] paramList, object[] valueList, string[] outParam, ref object[] outValue)
    {
        try
        {
            OracleFactory sf = new OracleFactory(dbName);

            //object value = sf.NTx_ExecuteScalar(command, cmdType, paramList, valueList, outParam, ref outValue);
            object value = sf.NTx_ExecuteScalar(command, cmdType, paramList, valueList);

            return value;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dbName"></param>
    /// <param name="command"></param>
    /// <param name="cmdType"></param>
    /// <param name="paramList"></param>
    /// <param name="valueList"></param>
    /// <param name="outParam"></param>
    /// <param name="outValue"></param>
    /// <returns></returns>
    [WebMethod(Description = "[MS-Oracle]쿼리를 실행하여 object을 반환하는 Web Method 입니다.")]
    public object ONTx_ExecuteScalarFromXML(string queryId, string[] paramList, object[] valueList, string[] outParam, ref object[] outValue)
    {
        try
        {
            XMLQueryParser xParser = new XMLQueryParser(queryId);

            xParser.GetXMLQuery();

            if (xParser.QUERY == string.Empty) throw new MissingFieldException();

            OracleFactory sf = new OracleFactory(xParser.DBNAME);

            //object value = sf.NTx_ExecuteScalar(xParser.QUERY, xParser.COMMANDTYPE, paramList, valueList, outParam, ref outValue);
            object value = sf.NTx_ExecuteScalar(xParser.QUERY, xParser.COMMANDTYPE, paramList, valueList);

            return value;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dbName"></param>
    /// <param name="command"></param>
    /// <param name="cmdType"></param>
    /// <param name="paramList"></param>
    /// <param name="valueList"></param>
    /// <param name="outParam"></param>
    /// <param name="outValue"></param>
    /// <returns></returns>
    [WebMethod(Description = "[Oracle]쿼리를 실행하여 object을 반환하는 Web Method 입니다.")]
    public object ONTx_ExecuteScalarFromQueryId(string queryId, string[] paramList, object[] valueList, string[] outParam, ref object[] outValue)
    {
        try
        {
            QueryFinder finder = new QueryFinder(queryId);

            if (finder.QUERY == string.Empty) throw new RowNotInTableException();

            OracleFactory sf = new OracleFactory(finder.DBNAME);

            //object value = sf.NTx_ExecuteScalar(finder.QUERY, finder.COMMANDTYPE, paramList, valueList, outParam, ref outValue);
            object value = sf.NTx_ExecuteScalar(finder.QUERY, finder.COMMANDTYPE, paramList, valueList);

            return value;
        }
        catch
        {
            throw;
        }
    }

    #endregion

    #region :: Oracle Transaction 관련 Web Method ::

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dbName"></param>
    /// <param name="command"></param>
    /// <param name="cmdType"></param>
    /// <param name="paramList"></param>
    /// <param name="valueList"></param>
    /// <param name="outParam"></param>
    /// <param name="outValue"></param>
    /// <returns></returns>
    [WebMethod(Description = "[Oracle]쿼리를 실행하여 영향을 받은 Row 수를 반환하는 Web Method 입니다.")]
    public int OTx_ExecuteNonQuery(string dbName, string command, string cmdType, string[] paramList, object[] valueList, string[] outParam, ref object[] outValue)
    {
        try
        {
            int value = -1;

            OracleFactory of = new OracleFactory(dbName);

            //value = of.Tx_ExecuteNonQuery(command, cmdType, paramList, valueList, outParam, ref outValue);
            value = of.Tx_ExecuteNonQuery(command, cmdType, paramList, valueList);

            return value;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dbName"></param>
    /// <param name="command"></param>
    /// <param name="cmdType"></param>
    /// <param name="paramList"></param>
    /// <param name="dt"></param>
    /// <param name="outParam"></param>
    /// <param name="outValue"></param>
    /// <returns></returns>
    [WebMethod(Description = "[Oracle]DataTable을 사용하여 쿼리를 실행하여 Multi 처리하고 영향을 받은 Row 수를 반환하는 Web Method 입니다.")]
    public int OTx_ExecuteNonQueryByDataTable(string dbName, string command, string cmdType, string[] paramList, DataTable dt, string[] outParam, ref object[] outValue)
    {
        try
        {
            int value = -1;

            OracleFactory of = new OracleFactory(dbName);

            //value = of.Tx_ExecuteNonQueryByDataTable(command, cmdType, paramList, dt, outParam, ref outValue);
            value = of.Tx_ExecuteNonQueryByDataTable(command, cmdType, paramList, dt);

            return value;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dbName"></param>
    /// <param name="command"></param>
    /// <param name="cmdType"></param>
    /// <param name="paramList"></param>
    /// <param name="bData"></param>
    /// <param name="outParam"></param>
    /// <param name="outValue"></param>
    /// <returns></returns>
    [WebMethod(Description = "[Oracle]DataTable을 사용하여 쿼리를 실행하여 Multi 처리하고 영향을 받은 Row 수를 반환하는 Web Method 입니다.")]
    public int OTx_ExecuteNonQueryByDataTableCompress(string dbName, string command, string cmdType, string[] paramList, byte[] bData, string[] outParam, ref object[] outValue)
    {
        try
        {
            int value = -1;

            OracleFactory of = new OracleFactory(dbName);
            
            CompressDataSet compress = new CompressDataSet();

            DataTable dt = compress.UnzipDataDataTable(bData);

            //value = of.Tx_ExecuteNonQueryByDataTable(command, cmdType, paramList, dt, outParam, ref outValue);
            value = of.Tx_ExecuteNonQueryByDataTable(command, cmdType, paramList, dt);

            return value;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="queryId"></param>
    /// <param name="paramList"></param>
    /// <param name="valueList"></param>
    /// <param name="outParam"></param>
    /// <param name="outValue"></param>
    /// <returns></returns>
    [WebMethod(Description = "[Oracle]XML파일에서 쿼리를 실행하여 처리하고 영향을 받은 Row 수를 반환하는 Web Method 입니다.")]
    public int OTx_ExecuteNonQueryFromXML(string queryId, string[] paramList, object[] valueList, string[] outParam, ref object[] outValue)
    {
        try
        {
            int value = -1;

            XMLQueryParser xParser = new XMLQueryParser(queryId);

            xParser.GetXMLQuery();

            OracleFactory of = new OracleFactory(xParser.DBNAME);

            //value = of.Tx_ExecuteNonQuery(xParser.QUERY, xParser.COMMANDTYPE, paramList, valueList, outParam, ref outValue);
            value = of.Tx_ExecuteNonQuery(xParser.QUERY, xParser.COMMANDTYPE, paramList, valueList);

            return value;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="queryId"></param>
    /// <param name="paramList"></param>
    /// <param name="dt"></param>
    /// <param name="outParam"></param>
    /// <param name="outValue"></param>
    /// <returns></returns>
    [WebMethod(Description = "[Oracle]XML과 DataTable을 사용하여 쿼리를 실행하여 처리하고 영향을 받은 Row 수를 반환하는 Web Method 입니다.")]
    public int OTx_ExecuteNonQueryFromXMLByDataTable(string queryId, string[] paramList, DataTable dt, string[] outParam, ref object[] outValue)
    {
        try
        {
            int value = -1;

            XMLQueryParser xParser = new XMLQueryParser(queryId);

            xParser.GetXMLQuery();

            OracleFactory of = new OracleFactory(xParser.DBNAME);

            //value = of.Tx_ExecuteNonQueryByDataTable(xParser.QUERY, xParser.COMMANDTYPE, paramList, dt, outParam, ref outValue);
            value = of.Tx_ExecuteNonQueryByDataTable(xParser.QUERY, xParser.COMMANDTYPE, paramList, dt);

            return value;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="queryId"></param>
    /// <param name="paramList"></param>
    /// <param name="bData"></param>
    /// <param name="outParam"></param>
    /// <param name="outValue"></param>
    /// <returns></returns>
    [WebMethod(Description = "[Oracle]XML과 DataTable을 사용하여 쿼리를 실행하여 처리하고 영향을 받은 Row 수를 반환하는 Web Method 입니다.")]
    public int OTx_ExecuteNonQueryFromXMLByDataTableCompress(string queryId, string[] paramList, byte[] bData, string[] outParam, ref object[] outValue)
    {
        try
        {
            int value = -1;

            XMLQueryParser xParser = new XMLQueryParser(queryId);

            xParser.GetXMLQuery();

            OracleFactory of = new OracleFactory(xParser.DBNAME);

            CompressDataSet compress = new CompressDataSet();

            DataTable dt = compress.UnzipDataDataTable(bData);

            //value = of.Tx_ExecuteNonQueryByDataTable(xParser.QUERY, xParser.COMMANDTYPE, paramList, dt, outParam, ref outValue);
            value = of.Tx_ExecuteNonQueryByDataTable(xParser.QUERY, xParser.COMMANDTYPE, paramList, dt);

            return value;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="queryId"></param>
    /// <param name="paramList"></param>
    /// <param name="valueList"></param>
    /// <param name="outParam"></param>
    /// <param name="outValue"></param>
    /// <returns></returns>
    [WebMethod(Description = "[Oracle]DB의 Qury ID를 사용하여 쿼리를 실행하여 처리하고 영향을 받은 Row 수를 반환하는 Web Method 입니다.")]
    public int OTx_ExecuteNonQueryFromQueryId(string queryId, string[] paramList, object[] valueList, string[] outParam, ref object[] outValue)
    {
        try
        {
            int value = -1;

            QueryFinder finder = new QueryFinder(queryId);

            OracleFactory of = new OracleFactory(finder.DBNAME);

            //value = of.Tx_ExecuteNonQuery(finder.QUERY, finder.COMMANDTYPE, paramList, valueList, outParam, ref outValue);
            value = of.Tx_ExecuteNonQuery(finder.QUERY, finder.COMMANDTYPE, paramList, valueList);

            return value;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="queryId"></param>
    /// <param name="paramList"></param>
    /// <param name="dt"></param>
    /// <param name="outParam"></param>
    /// <param name="outValue"></param>
    /// <returns></returns>
    [WebMethod(Description = "[Oracle]DB의 Qury ID와 DataTable을 사용하여 쿼리를 실행하여 처리하고 영향을 받은 Row 수를 반환하는 Web Method 입니다.")]
    public int OTx_ExecuteNonQueryFromQueryIdByDataTable(string queryId, string[] paramList, DataTable dt, string[] outParam, ref object[] outValue)
    {
        try
        {
            int value = -1;

            QueryFinder finder = new QueryFinder(queryId);

            OracleFactory sf = new OracleFactory(finder.DBNAME);

            //value = sf.Tx_ExecuteNonQueryByDataTable(finder.QUERY, finder.COMMANDTYPE, paramList, dt, outParam, ref outValue);
            value = sf.Tx_ExecuteNonQueryByDataTable(finder.QUERY, finder.COMMANDTYPE, paramList, dt);

            return value;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="queryId"></param>
    /// <param name="paramList"></param>
    /// <param name="bData"></param>
    /// <param name="outParam"></param>
    /// <param name="outValue"></param>
    /// <returns></returns>
    [WebMethod(Description = "[Oracle]DB의 Qury ID와 DataTable을 사용하여 쿼리를 실행하여 처리하고 영향을 받은 Row 수를 반환하는 Web Method 입니다.")]
    public int OTx_ExecuteNonQueryFromQueryIdByDataTableCompress(string queryId, string[] paramList, byte[] bData, string[] outParam, ref object[] outValue)
    {
        try
        {
            int value = -1;

            QueryFinder finder = new QueryFinder(queryId);

            OracleFactory sf = new OracleFactory(finder.DBNAME);

            CompressDataSet compress = new CompressDataSet();

            DataTable dt = compress.UnzipDataDataTable(bData);

            //value = sf.Tx_ExecuteNonQueryByDataTable(finder.QUERY, finder.COMMANDTYPE, paramList, dt, outParam, ref outValue);
            value = sf.Tx_ExecuteNonQueryByDataTable(finder.QUERY, finder.COMMANDTYPE, paramList, dt);

            return value;
        }
        catch
        {
            throw;
        }
    }

    #endregion

    #region :: UseLogSave :: WebService 사용 이력 저장 

    ///// <summary>
    ///// 
    ///// </summary>
    ///// <param name="methodName"></param>
    ///// <param name="queryid"></param>
    ///// <param name="startDTTM"></param>
    ///// <param name="endDTTM"></param>
    //private void UseLogSave(string methodName, string queryid, DateTime startDTTM , DateTime endDTTM)
    //{
    //    SqlFactory sf = new SqlFactory("METADB");

    //    string command = "UseLog_Save";
    //    string cmdType = "StoredProcedure";

    //    var paramList = new string[] { "@METHODNAME", "@QUERYID", "@STARTDTTM", "@ENDDTTM" };
    //    var valueList = new object[] { methodName, queryid, startDTTM, endDTTM };

    //    object[] outValue = new object[] { };

    //    sf.Tx_ExecuteNonQuery(command, cmdType, paramList, valueList, null, ref outValue);
    //}

    #endregion
}