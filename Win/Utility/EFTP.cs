using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;

namespace EBAP.Win.Utility
{
    /// <summary>
    /// FTP의 업로드/다운로드 기능을 담당합니다.
    /// </summary>
    public class EFTP : IDisposable
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip">IP</param>
        /// <param name="port">PORT</param>
        /// <param name="directory"></param>
        /// <param name="user"></param>
        /// <param name="pwd"></param>
        public EFTP(string ip, int port, string directory, string user, string pwd)
        {
            string temp_ip = ip;

            int last_idx = temp_ip.Length;
            int idx = temp_ip.LastIndexOf('/');
            if (idx < 0)
            {
                m_ip = ip;
                m_directory = directory;
            }
            else
            {
                m_ip = temp_ip.Substring(0, idx);
                m_directory = Path.Combine(temp_ip.Substring(idx, last_idx - idx).Trim(), directory.Replace("/", ""));
            }

            m_port = port;
            m_user = user;
            m_pwd = pwd;
        }

        #endregion

        #region :: 전역변수 ::

        string m_ip = string.Empty;
        int m_port = 21;
        string m_user = string.Empty;
        string m_pwd = string.Empty;
        string m_directory = string.Empty;

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

        #region :: DownloadFile :: FTP 서버에서 파일을 다운로드 합니다.

        /// <summary>
        /// FTP 서버에서 파일을 다운로드 합니다.
        /// </summary>
        /// <param name="serverFile">서버 파일 경로</param>
        /// <param name="localFile">로컬 파일 경로</param>
        public string DownloadFile(string serverFile, string localFile)
        {
            WebResponse response = null;
            Stream stream = null;
            FtpWebRequest ftp = null;
            FileStream fs = null;
            byte[] body = null;

            Uri uri = null;

            string clientPath = string.Empty;

            try
            {
                uri = new Uri(String.Format(@"ftp://{0}:{1}{2}", m_ip, m_port, Path.Combine(m_directory, serverFile)));

                ftp = (FtpWebRequest)WebRequest.Create(uri);
                ftp.UseBinary = true;
                ftp.Method = WebRequestMethods.Ftp.DownloadFile;
                ftp.Credentials = new NetworkCredential(m_user, m_pwd);

                response = ftp.GetResponse();
                stream = response.GetResponseStream();

                int readByte = 0;
                clientPath = Path.Combine(Path.GetTempPath(), localFile);
                fs = new FileStream(clientPath, FileMode.Create);
                body = new byte[4096];
                while (true)
                {
                    readByte = stream.Read(body, 0, body.Length);
                    if (readByte == 0) break;
                    fs.Write(body, 0, readByte);
                }
                return clientPath;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (fs != null) fs.Close();
                if (response != null) response.Close();
                if (stream != null) stream.Close();
            }
        }

        #endregion

        #region :: UploadFile :: FTP 서버로 파일을 업로드 합니다.

        /// <summary>
        /// FTP 서버로 파일을 업로드 합니다.
        /// </summary>
        /// <param name="serverFile">서버 파일 경로</param>
        /// <param name="localFile">로컬 파일 경로</param>
        public void UploadFile(string serverFile, string localFile)
        {
            Stream stream = null;
            FtpWebRequest request = null;
            FileStream fs = null;
            Uri uri = null;


            try
            {
                uri = new Uri(String.Format(@"ftp://{0}:{1}{2}", m_ip, m_port, Path.Combine(m_directory, serverFile)));
                //uri = new Uri(String.Format(@"ftp://{0}:{1}", m_ip, m_port));

                request = WebRequest.Create(uri) as FtpWebRequest;
                request.UseBinary = true;
                request.KeepAlive = false;
                request.UsePassive = true;
                request.Proxy = null;
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(m_user, m_pwd);

                byte[] fileContents = null;

                using (stream = request.GetRequestStream())
                {
                    int readByte = 0;
                    fs = new FileStream(localFile, FileMode.Open);
                    fileContents = new byte[4096];

                    while (true)
                    {
                        readByte = fs.Read(fileContents, 0, fileContents.Length);
                        if (readByte == 0) break;
                        stream.Write(fileContents, 0, readByte);
                    }
                }

                //ftp = WebRequest.Create(uri) as FtpWebRequest;
                //ftp.UseBinary = true;
                ////ftp.Method = WebRequestMethods.Ftp.UploadFile;
                //ftp.Credentials = new NetworkCredential(m_user, m_pwd);

                //using (stream = ftp.GetRequestStream())
                //{
                //    int readByte = 0;
                //    fs = new FileStream(localFile, FileMode.Open);
                //    body = new byte[4096];

                //    while (true)
                //    {
                //        readByte = fs.Read(body, 0, body.Length);
                //        if (readByte == 0) break;
                //        stream.Write(body, 0, readByte);
                //    }
                //}
            }
            catch
            {
                throw;
            }
            finally
            {
                if (fs != null) fs.Close();
                if (stream != null) stream.Close();
            }
        }

        #endregion

        /// <summary>
        /// FTP 서버에서 파일을 다운로드 합니다.
        /// </summary>
        /// <param name="serverFile">서버 파일 경로</param>
        public Image GetImageFromFTP(string serverFile)
        {
            WebResponse response = null;
            Stream stream = null;
            FtpWebRequest ftp = null;

            Uri uri = null;

            string clientPath = string.Empty;

            try
            {
                uri = new Uri(String.Format(@"ftp://{0}:{1}{2}", m_ip, m_port, Path.Combine(m_directory, serverFile)));

                ftp = (FtpWebRequest)WebRequest.Create(uri);
                ftp.UseBinary = true;
                ftp.Method = WebRequestMethods.Ftp.DownloadFile;
                ftp.Credentials = new NetworkCredential(m_user, m_pwd);

                response = ftp.GetResponse();
                stream = response.GetResponseStream();

                Image image = Image.FromStream(stream);

                //MemoryStream mStream = new MemoryStream();
                //image.Save(mStream, ImageFormat.Jpeg);
                //mStream.ToArray();

                return image;
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
    }
}
