using System;
using System.Data;
using System.Xml;
using EBAP.Core.Info;

namespace EBAP.Core.Localization
{
    /// <summary>
    /// System에서 사용할 다국어지원 Class 입니다.
    /// </summary>
    /// <remarks>
    /// 2023-02-01 최초생성 : 오인봉
    /// 변경내역
    /// 
    /// </remarks>
    public class LocaleConverter
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// 다국어지원 Class Instance를 생성합니다.
        /// </summary>
        /// <param name="locale">사용 언어</param>
        public LocaleConverter(string locale)
        {
            _locale = locale;

            dsString.ReadXml(AppConfig.LOCALEXMLPATH);
            dsMessage.ReadXml(AppConfig.MESSAGEXMLPATH);
        }

        #endregion

        #region :: 전역변수 ::

        private string _locale = string.Empty;

        DataSet dsString = new DataSet();
        DataSet dsMessage = new DataSet();

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 
        /// </summary>
        /// <param name="locale"></param>
        public void SetLocale(string locale)
        {
            _locale = locale;
        }

        #region :: GetLocaleString :: StringId로 해당 문화권의 언어를 가져옵니다.

        ///// <summary>
        ///// StringId로 해당 문화권의 언어를 가져옵니다.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public string GetLocaleString(StrId id)
        //{
        //    XmlDocument document = new XmlDocument();
        //    document.Load(AppConfig.LOCALEXMLPATH);

        //    XmlNodeList nodeList = document.SelectNodes("//Table");

        //    foreach (XmlNode node in nodeList)
        //    {
        //        if (Convert.ToInt32(id).ToString() != node["STRINGID"].InnerText)
        //            continue;

        //        return node[_locale].InnerText;
        //    }

        //    return string.Empty;
        //}

        /// <summary>
        /// Enum Class로 해당 문화권의 언어를 가져옵니다.
        /// </summary>
        /// <param name="enumClass"></param>
        /// <returns></returns>
        public string GetLocaleString(string enumClass)
        {
            //XmlDocument document = new XmlDocument();
            //document.Load(AppConfig.LOCALEXMLPATH);

            //XmlNodeList nodeList = document.SelectNodes("//Table");

            //foreach (XmlNode node in nodeList)
            //{
            //    if (enumClass != node["ENUMCLASS"].InnerText)
            //        continue;

            //    return node[_locale].InnerText;
            //}

            //return enumClass;// +(Debugger.IsAttached ? "_NG" : string.Empty);

            DataRow[] drs = dsString.Tables[0].Select($"ENUMCLASS = '{enumClass}'");

            if (drs.Length == 0) return enumClass;

            return drs[0][_locale].ToString();
        }

        #endregion

        #region :: GetLocaleMessage :: MessageId로 해당 문화권의 메시지를 가져옵니다.

        ///// <summary>
        ///// MessageId로 해당 문화권의 메시지를 가져옵니다.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public string GetLocaleMessage(MsgId id)
        //{
        //    XmlDocument document = new XmlDocument();
        //    document.Load(AppConfig.MESSAGEXMLPATH);

        //    XmlNodeList nodeList = document.SelectNodes("//Table");

        //    foreach (XmlNode node in nodeList)
        //    {
        //        if (Convert.ToInt32(id).ToString() != node["MESSAGEID"].InnerText)
        //            continue;

        //        return node[_locale].InnerText.Replace(@"\n", Environment.NewLine);
        //    }

        //    return string.Empty;
        //}

        /// <summary>
        /// MessageId로 해당 문화권의 메시지를 가져옵니다.
        /// </summary>
        /// <param name="enumClass"></param>
        /// <returns></returns>
        public string GetLocaleMessage(string enumClass)
        {
            //XmlDocument document = new XmlDocument();
            //document.Load(AppConfig.MESSAGEXMLPATH);

            //XmlNodeList nodeList = document.SelectNodes("//Table");

            //foreach (XmlNode node in nodeList)
            //{
            //    if (enumClass != node["ENUMCLASS"].InnerText)
            //        continue;

            //    return node[_locale].InnerText.Replace(@"\n", Environment.NewLine);
            //}

            //return string.Empty;

            DataRow[] drs = dsMessage.Tables[0].Select($"ENUMCLASS = '{enumClass}'");

            if (drs.Length == 0) return "";

            return drs[0][_locale].ToString().Replace(@"\n", Environment.NewLine);
        }

        #endregion
    }
}
