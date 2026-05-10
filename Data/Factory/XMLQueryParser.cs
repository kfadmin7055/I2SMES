using System;
using System.IO;
using System.Web;
using System.Xml;

namespace EBAP.Data.Factory
{
    /// <summary>
    /// XML 파일에서 Query Id로 쿼리를 가져옵니다.
    /// </summary>
    public class XMLQueryParser
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// XML Parser 를 생성합니다.
        /// </summary>
        public XMLQueryParser()
        {

        }

        /// <summary>
        /// XML Parser 를 생성합니다.
        /// </summary>
        /// <param name="fullPath">전체 경로</param>
        public XMLQueryParser(string fullPath)
        {
            string[] paths = fullPath.Split('.');

            int len = paths.Length;

            string path = string.Empty;
            for (int i = 0; i < len - 1; i++)
            {
                if (i < paths.Length - 1)
                    path = Path.Combine(path, paths[i]);
            }
            path += ".xml";
            //string path = paths[0] + ".xml";

            string serverPath = HttpContext.Current.Request.PhysicalApplicationPath + @"App_Code\Queries\";

            XMLPATH = Path.Combine(serverPath, path);
            QUERYID = paths[len - 1];
        }

        #endregion

        #region :: 전역변수 ::

        private readonly string XMLPATH = string.Empty;

        private readonly string QUERYID = string.Empty;

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


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: GetXMLQuery :: XML Query를 설정하고 실행합니다.

        /// <summary>
        /// XML Query를 설정하고 실행합니다.
        /// </summary>
        public void GetXMLQuery()
        {
            try
            {
                if (!File.Exists(XMLPATH)) throw new FileNotFoundException();

                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(XMLPATH);

                XmlElement queryList = xDoc.DocumentElement;

                XmlNodeList nodes = queryList.SelectNodes(QUERYID);

                foreach (XmlNode xNode in nodes)
                {
                    QUERY = xNode["sql"].InnerText.Trim();
                    DBNAME = xNode["connection"].InnerText;
                    COMMANDTYPE = xNode["commandtype"].InnerText;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
