using System;
using System.ComponentModel;
using System.Net;

namespace EBAP.Web.Proxy
{
    /// <summary>
    /// Application에서 사용할 Web Service Proxy입니다.
    /// </summary>
    /// <remarks>
    /// 2023-02-01 최초생성 : 오인봉
    /// 변경내역
    /// 
    /// </remarks>
    [ToolboxItem(false)]
    public class WSProxy : EBAPService.Service
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// Web Service Proxy를 생성합니다.
        /// </summary>
        /// <param name="url"></param>
        public WSProxy(string url)
        {
            _webServiceUrl = url;
        }

        #endregion

        #region :: 전역변수 ::

        private readonly string _webServiceUrl = string.Empty;

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: GetWebRequest :: Web Request를 가져옵니다.

        /// <summary>
        /// Web Request를 가져옵니다.
        /// </summary>
        /// <param name="svrUri"></param>
        /// <returns></returns>
        protected override System.Net.WebRequest GetWebRequest(Uri svrUri)
        {
            try
            {
                int length = svrUri.Segments.Length;
                string Segments = svrUri.Segments[length - 1];

                string Uri = _webServiceUrl + Segments;
                Uri uri = new Uri(Uri);

                HttpWebRequest webReq = base.GetWebRequest(uri) as HttpWebRequest;

                webReq.Credentials = CredentialCache.DefaultCredentials;
                webReq.KeepAlive = false;
                webReq.Timeout = -1;
                webReq.UserAgent = ".NET Framework 3.x Client";

                return webReq;
            }
            catch
            {
                throw;
            }
        }

        #endregion
    }
}
