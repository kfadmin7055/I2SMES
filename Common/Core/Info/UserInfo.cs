using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EBAP.Core.Info
{
    /// <summary>
    /// 사용자 정보를 저장하고 있는 Class 입니다.
    /// </summary>
    /// <remarks>
    /// 2023-02-01 최초생성 : 오인봉
    /// 변경내역
    /// 
    /// </remarks>
    public class UserInfo
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// User Inforatmion을 생성합니다.
        /// </summary>
        public UserInfo()
        {
            ISADMIN = true;
            ISSSO = false;
            ISEXT = false;

            EPID = "DBD14C3366CD40A0B2D428FD9B70D5DE";
            USERID = "system";
            WORKERX = USERID;
            USERNAME = "관리자";
            LOGINID = "system";

            EMPLOYEENUM = "99999999";

            GRADECODE = "CEO";
            GRADENAME = "관리자";

            DEPARTMENTCODE = "CEO";
            DEPARTMENTNAME = "개발관리";

            COMPANY = "1111111111";
            COMPANYNAME = @"한국제일";

            PLANTCODE = "0001";

            PHONENUM = "02-";
            OFFICEPHONENUM = "02-";
            CELLPHONENUM = "010-";

            EMAIL = @"o2u4u@naver.com";
            CURRENTLANGUAGE = "ko-KR";
            BASEVENDORCODE = "2230653058";
            BASEPLANT = "0001";
            BASEFACTORY = "BASE";
            GTPSID = "1e893c96e6e495fe9d1914d36909e2b6";
            //LANGUAGE = "en-US";

            foreach (IPAddress address in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    IP = address.ToString();
            }
        }

        /// <summary>
        /// User Inforatmion을 생성합니다.
        /// </summary>
        /// <param name="dr"></param>
        public UserInfo(DataRow dr)
        {
            ISADMIN = dr["ADMINFLAG"].ToString() == "True" ? true : false;
            ISSSO = dr["SSOFLAG"].ToString() == "True" ? true : false;
            ISEXT = dr["EXTFLAG"].ToString() == "True" ? true : false;

            EPID = dr["EPID"].ToString().Trim();
            LOGINID = dr["LOGINID"].ToString().Trim();
            USERID = dr["USERID"].ToString().Trim();
            WORKERX = USERID;
            USERNAME = dr["USERNAME"].ToString().Trim();
            PWD = dr["PWD"].ToString().Trim();

            EMPLOYEENUM = dr["EMPNO"].ToString().Trim();
            EMPLOYEENAME = "";

            DEPARTMENTCODE = dr["DEPTCODE"].ToString().Trim();
            DEPARTMENTNAME = dr["DEPTNAME"].ToString().Trim();

            GRADECODE = dr["GRADECODE"].ToString().Trim();
            GRADENAME = dr["GRADENAME"].ToString().Trim();

            VENDORCODE = dr["VENDORCODE"].ToString().Trim();
            VENDORNAME = dr["VENDORNAME"].ToString().Trim();

            PLANTCODE = dr["PLANTCODE"].ToString().Trim();
            PLANTNAME = dr["PLANTNAME"].ToString().Trim();

            PHONENUM = dr["PHONE"].ToString().Trim();
            OFFICEPHONENUM = dr["OFFICEPHONE"].ToString().Trim();
            CELLPHONENUM = dr["CELLPHONE"].ToString().Trim();

            EMAIL = dr["EMAILADDRESS"].ToString().Trim();
            GTPSID = dr["GTPSID"].ToString().Trim();

            foreach (IPAddress address in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    IP = address.ToString();

                    if (IP.Substring(0, 3) == "14.") break;
                }
            }

            BASEVENDORCODE = "0000000001";
            BASEPLANT = "0001";
            BASEFACTORY = "BASE";
        }

        #endregion

        #region :: 전역변수 ::

        private string _restrictions = string.Empty;

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: Readonly Properties ::

        /// <summary>
        /// Admin 권한 여부
        /// </summary>
        public bool ISADMIN { get; private set; }

        /// <summary>
        /// SSO 사용 여부
        /// </summary>
        public bool ISSSO { get; private set; }

        /// <summary>
        /// 외주 사용자 여부
        /// </summary>
        public bool ISEXT { get; private set; }

        /// <summary>
        /// Login Seq
        /// </summary>
        public int SIGNINSEQ
        {
            get;
            set;
        }

        /// <summary>
        /// EP ID
        /// </summary>
        public string EPID { get; private set; }

        /// <summary>
        /// 사용자 ID
        /// </summary>
        public string USERID { get; private set; }

        /// <summary>
        /// 로그인 ID
        /// </summary>
        public string LOGINID { get; private set; }

        /// <summary>
        /// 사용자 명
        /// </summary>
        public string USERNAME { get; private set; }

        /// <summary>
        /// 비밀번호
        /// </summary>
        public string PWD
        {
            get;
            private set;
        }

        /// <summary>
        /// 사번
        /// </summary>
        public string EMPLOYEENUM { get; private set; }

        /// <summary>
        /// 사원명
        /// </summary>
        public string EMPLOYEENAME { get; private set; }

        /// <summary>
        /// 부서코드
        /// </summary>
        public string DEPARTMENTCODE { get; private set; }

        /// <summary>
        /// 부서명
        /// </summary>
        public string DEPARTMENTNAME { get; private set; }

        /// <summary>
        /// 직급코드
        /// </summary>
        public string GRADECODE { get; private set; }

        /// <summary>
        /// 직급명
        /// </summary>
        public string GRADENAME { get; private set; }

        /// <summary>
        /// GTPS ID
        /// </summary>
        public string GTPSID { get; private set; }

        /// <summary>
        /// 작업자
        /// </summary>
        public string WORKERX
        {
            get;
            set;
        }

        /// <summary>
        /// 사업장코드
        /// </summary>
        public string PLANTCODE
        {
            get;
            set;
        }

        /// <summary>
        /// 사업장명
        /// </summary>
        public string PLANTNAME
        {
            get;
            set;
        }

        /// <summary>
        /// 라인코드
        /// </summary>
        public string LINECODE
        {
            get;
            set;
        }

        /// <summary>
        /// 라인명
        /// </summary>
        public string LINENAME
        {
            get;
            set;
        }

        /// <summary>
        /// CELL코드
        /// </summary>
        public string CELLCODE
        {
            get;
            set;
        }

        /// <summary>
        /// CELL 명
        /// </summary>
        public string CELLNAME
        {
            get;
            set;
        }

        /// <summary>
        /// 설비그룹코드
        /// </summary>
        public string STATIONGROUP
        {
            get;
            set;
        }

        /// <summary>
        /// 설비그룹 명
        /// </summary>
        public string STATIONGROUPNAME
        {
            get;
            set;
        }

        /// <summary>
        /// 회사코드
        /// </summary>
        public string COMPANY
        {
            get;
            set;
        }

        /// <summary>
        /// 업체코드
        /// </summary>
        public string VENDORCODE
        {
            get;
            set;
        }

        /// <summary>
        /// 기준업체코드 고정
        /// </summary>
        public string BASEVENDORCODE
        {
            get;
            private set;
        }

        /// <summary>
        /// 기준 PLANT코드 고정
        /// </summary>
        public string BASEPLANT
        {
            get;
            private set;
        }

        /// <summary>
        /// 기준 FACTORY 코드 고정
        /// </summary>
        public string BASEFACTORY
        {
            get;
            private set;
        }

        /// <summary>
        /// 암호화 KEY
        /// </summary>
        public string USERTOKEN
        {
            get;
            set;
        }

        /// <summary>
        /// 사용 언어
        /// </summary>
        public string CURRENTLANGUAGE
        {
            get;
            set;
        }

        /// <summary>
        /// 회사명
        /// </summary>
        public string COMPANYNAME { get; set; }

        /// <summary>
        /// 업체명
        /// </summary>
        public string VENDORNAME { get; set; }

        /// <summary>
        /// 기본 전화번호
        /// </summary>
        public string PHONENUM { get; private set; }

        /// <summary>
        /// 사내 전화번호
        /// </summary>
        public string OFFICEPHONENUM { get; private set; }

        /// <summary>
        /// 휴대폰 전화번호
        /// </summary>
        public string CELLPHONENUM { get; private set; }

        /// <summary>
        /// E mail
        /// </summary>
        public string EMAIL { get; private set; }

        /// <summary>
        /// IP Address
        /// </summary>
        public string IP { get; private set; }

        /// <summary>
        /// 공정 권한
        /// </summary>
        public string[] PROCESSAUTH { get; private set; }

        /// <summary>
        /// 예외 권한
        /// </summary>
        public string RESTRICTIONS { private get; set; }

        #endregion:


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // PublicMethod
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: CheckRestrictionsAuth :: 예외 권한을 체크합니다.

        /// <summary>
        /// 예외 권한을 체크합니다.
        /// </summary>
        /// <param name="checkAuths">체크할 예외 권한</param>
        /// <returns></returns>
        public bool CheckRestrictionsAuth(params string[] checkAuths)
        {
            string[] restrictionsAuth = RESTRICTIONS.Split(',');

            foreach (string auth in restrictionsAuth)
            {
                foreach (string checkAuth in checkAuths)
                {
                    if (auth == checkAuth)
                        return true;
                }
            }
            return false;
        }

        #endregion
    }
}
