namespace EBAP.Win.Utility
{
    /// <summary>
    /// 싱글 결재 및 메일 관련 파라미터를 설정합니다.
    /// </summary>
    public class ESBParam
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// ESB 파라미터를 기본값으로 생성합니다.
        /// </summary>
        public ESBParam()
        {
            LOCALE = "ko_KR";
            ENCODING = "euc-kr";

            STRPROCEDURENAME = "EBAP";
            REQUESTERCREDENTIAL = "AAA";
            TIMEZONE = "GMT+9";

            INTEROCKYN = true;
        }

        #endregion

        #region :: 전역변수 ::


        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 
        /// </summary>
        public string SUBJECT
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string MESSAGE
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string LOCALE
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string ENCODING
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string REQUESTERID
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string STRPROCEDURENAME
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string REQUESTERCREDENTIAL
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string TIMEZONE
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool INTEROCKYN
        {
            get;
            set;
        }
    }
}
