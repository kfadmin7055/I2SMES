using EBAP.Business.WSBiz;
using EBAP.Core.Info;
using EBAP.Win.BaseFrame;
using EBAP.Win.Dialog;
using EBAP.Win.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EBAP.Win.UtilClient
{
    /// <summary>
    /// 시스템에서 공통으로 사용할 FTP Client를 정의합니다.
    /// </summary>
    /// <remarks>
    /// 2016-05-30 최초생성 : 오인봉
    /// 변경내역
    /// 
    /// </remarks>
    public class FTPClient
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="uiForm">UI Form</param>
        /// <param name="ftpId">FTP ID</param>
        /// <param name="uiId">UIID</param>
        /// <param name="key">FTP Key</param>
        public FTPClient(UIFrame uiForm, string ftpId, string uiId, string key)
        {
            UIForm = uiForm;
            FTPID = ftpId;
            UIID = uiId;
            KEY = key;
            KEY2 = "N";
        }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="uiForm">UI Form</param>
        /// <param name="ftpId">FTP ID</param>
        /// <param name="uiId">UIID</param>
        /// <param name="key">FTP Key</param>
        /// <param name="key2">FTP Key2</param>
        public FTPClient(UIFrame uiForm, string ftpId, string uiId, string key, string key2)
        {
            UIForm = uiForm;
            FTPID = ftpId;
            UIID = uiId;
            KEY = key;
            KEY2 = key2;
        }

        #endregion

        #region :: 전역변수 ::

        private DataRow ftpInfo = null;

        private UIFrame UIForm = null;

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// FTP ID
        /// </summary>
        public string FTPID
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string UIID
        {
            get;
            private set;
        }

        /// <summary>
        /// KEY
        /// </summary>
        public string KEY
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string KEY2
        {
            get;
            private set;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Private)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region ::InitFtp :: FTP 정보를 DB에서 가져옵니다.

        /// <summary>
        /// FTP 정보를 DB에서 가져옵니다.
        /// </summary>
        /// <returns>FTP 정보가 있으면 true, 없으면 false</returns>
        private bool InitFtp()
        {
            DataTable dt;
            const string queryId = @"dbo.FTPInfo_Get";

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                dt = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, new string[] { "@FTPID" }, new object[] { FTPID }).Tables[0];
            }

            if (dt.Rows.Count != 1)
            {
                MsgBox.Show("일치하는 FTP 정보가 없어요. 확인하세요", "확인", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            ftpInfo = dt.Rows[0];

            return true;
        }

        #endregion



        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void OpenFtpForm()
        {
            if (!InitFtp()) return;

            //FTPForm ftp = new FTPForm() { infoRow = ftpInfo, UIID = UIID, KEY = KEY, KEY2 = KEY2 };
            //ftp.ShowDialog(UIForm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable DownloadFile()
        {
            if (!InitFtp()) return null;

            DataSet ds;
            const string queryId = @"dbo.FTPFileInfo_Select";

            var paramList = new string[] { "FTPID", "@UIID", "@FTPKEY", "@FTPKEY2" };
            var valueList = new object[] { FTPID, UIID, KEY, KEY2 };

            using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
            {
                ds = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList);
            }

            using (EFTP ftp = new EFTP(ftpInfo["FTPSERVERPATH"].ToString(),
                                       Convert.ToInt32(ftpInfo["FTPPORT"]),
                                       ftpInfo["DIRECTORYPATH"].ToString(),
                                       ftpInfo["FTPUSERID"].ToString(),
                                       ftpInfo["FTPPWD"].ToString()))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ftp.DownloadFile(dr["SERVERFILENAME"].ToString(), dr["FILENAME"].ToString());
                }
            }

            return ds.Tables[0];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverFile"></param>
        /// <param name="localFile"></param>
        public void UploadFile(string serverFile, string localFile)
        {
            if (!InitFtp()) return;

            using (EFTP ftp = new EFTP(ftpInfo["FTPSERVERPATH"].ToString(),
                                       Convert.ToInt32(ftpInfo["FTPPORT"]),
                                       ftpInfo["DIRECTORYPATH"].ToString(),
                                       ftpInfo["FTPUSERID"].ToString(),
                                       ftpInfo["FTPPWD"].ToString()))
            {
                ftp.UploadFile(serverFile, localFile);
            }
        }
    }
}
