using System;
using System.Collections.Generic;

namespace EBAP.Win.Utility
{
    /// <summary>
    /// Application에서 사용할 ESB(싱글 결재 및 메일) Method를 정의합니다.
    /// </summary>
    /// <remarks>
    /// 2018-02-13 최초생성 : 오인봉
    /// 변경내역
    ///
    /// </remarks>
    public static class ESBUtil
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 
        /// </summary>
        public static ESBParam Param = new ESBParam();

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: ApprovalSend :: 결재 전송

        /// <summary>
        /// 결재 전송
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="requesterID"></param>
        /// <param name="approutes"></param>
        /// <param name="MailKey"></param>
        /// <returns></returns>
        public static string ApprovalSend(string subject, string message, string requesterID, List<ApprovalRoute> approutes, string MailKey)
        {
            try
            {
                string rslt = string.Empty;

                //using (ESBService.WebService SVC = new ESBService.WebService())
                //{
                //    List<ESBService.ApprovalRoute> routes = new List<ESBService.ApprovalRoute>();
                //    ESBService.ApprovalRoute route;

                //    foreach (ApprovalRoute aRoute in approutes)
                //    {
                //        route = new ESBService.ApprovalRoute();
                //        route.requesterID = aRoute.requesterID;
                //        route.AppType = aRoute.AppType;

                //        routes.Add(route);
                //    }

                //    rslt = SVC.ApprovalSend_V1(subject, message, Param.LOCALE, Param.ENCODING, requesterID,
                //                Param.REQUESTERCREDENTIAL, Param.TIMEZONE, Param.INTEROCKYN, routes.ToArray(), MailKey, Param.STRPROCEDURENAME);
                //}

                return rslt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region :: MailSend :: 메일 전송

        /// <summary>
        /// 메일 전송
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="locale"></param>
        /// <param name="encoding"></param>
        /// <param name="requesterID"></param>
        /// <param name="requesterCredential"></param>
        /// <param name="timeZone"></param>
        /// <param name="sendMailAddress"></param>
        /// <param name="reciveMailAddress"></param>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string MailSend(string subject, string message, string locale, string encoding, string requesterID
            , string requesterCredential, string timeZone, string sendMailAddress, string reciveMailAddress, string filePath, string fileName)
        {
            try
            {
                string rslt = string.Empty;

                //using (ESBService.WebService SVC = new ESBService.WebService())
                //{
                //    SVC.MailSend(subject, message, locale, encoding, requesterID, requesterCredential, timeZone, sendMailAddress, reciveMailAddress, filePath, fileName);
                //}

                return rslt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
