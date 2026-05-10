using EBAP.Business.WSBiz;
using EBAP.Exe.AutoUpdater.Properties;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace EBAP.Exe.AutoUpdater
{
    /// <summary>
    /// Assembly Download Form 입니다.
    /// </summary>
    public partial class Download : Form
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// Download Form을 생성합니다.
        /// </summary>
        public Download()
        {
            InitializeComponent();
            lblIP.Text = String.Format("{0}({1})", UpdateInfo.IP, UpdateInfo.CONNECTTYPE);
            _downloadList = createDownloadList();
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        private DataTable createDownloadList()
        {
            DataTable downloadList = new DataTable();
            downloadList.Columns.Add("ASSEMBLYID");
            downloadList.Columns.Add("ASSEMBLYNAME");
            downloadList.Columns.Add("ASSEMBLYSIZE");
            downloadList.Columns.Add("ASSEMBLYVERSION");

            return downloadList;
        }

        #endregion
        
        #region :: 전역변수 ::

        private int _totalFileCount = 0;
        private decimal _totalFileSize = 0;

        private decimal _curSrcFileSize = 0;
        private decimal _curRcvFileSize = 0;
        private decimal _totRcvFileSize = 0;

        private DataTable _downloadList;

        #endregion

        #region :: CheckDownloadAssembly :: Download List와 Assembly를 검사합니다.

        /// <summary>
        /// Download List와 Assembly를 검사합니다.
        /// </summary>
        /// <returns>0: Download 할 Assembly 없음</returns>
        internal int checkDownloadAssembly()
        {
            try
            {
                DataSet ds = null;

                const string query = "dbo.AssemblyDownloadList_Select";

                using (SqlBiz wb = new SqlBiz(Settings.Default.WebServiceURL))
                {
                    ds = wb.NTx_ExecuteDataSet(Settings.Default.DEFAULTDB, query, Settings.Default.COMMANDSP, null, null);
                }

                if (ds == null || ds.Tables[0].Rows.Count == 0) return 0;

                // 이전에 다운로드 받은 정보를 담고 있는 XmlFile
                FileInfo fInfo = new FileInfo(UpdateInfo.xmlPath);

                string path = UpdateInfo.assemblyFolder;
                string extention = string.Empty;

                using (DataSet dsXml = new DataSet())
                {
                    // 이전 다운로드 정보가 있다면
                    if (fInfo.Exists)
                    {
                        // 이전 다운로드 정보를 읽어 dsXml에 넣어준다.
                        dsXml.ReadXml(UpdateInfo.xmlPath);
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            extention = Path.GetExtension(dr["ASSEMBLYNAME"].ToString()).Substring(1);

                            if (CheckFontType(extention)) path = GetFontPath();
                            else path = UpdateInfo.assemblyFolder;

                            FileInfo assemblyInfo = new FileInfo(Path.Combine(path, dr["ASSEMBLYNAME"].ToString()));
                            //각 Assembly 에 대한 File이 있는지 확인한다.
                            if (assemblyInfo.Exists)
                            {
                                // Assembly ID를 가져와서 이전에 다운 받은 정보를 확인한다.
                                DataRow[] drArray = dsXml.Tables[0].Select(String.Format("ASSEMBLYID = '{0}'", dr["ASSEMBLYID"]));
                                if (drArray.Length > 0)
                                {
                                    if (drArray[0]["ASSEMBLYVERSION"].ToString() != dr["ASSEMBLYVERSION"].ToString()
                                    || drArray[0]["DEPLOYCOUNT"].ToString() != dr["DEPLOYCOUNT"].ToString())
                                        addDownloadListItem(dr);
                                }
                                else
                                    addDownloadListItem(dr);
                            }
                            else
                                //파일이 없으면 ListView에 추가한다.
                                addDownloadListItem(dr);
                        }
                    }
                    else
                        //이전 다운로드 정보가 없으면 모든 파일을 ListView에 추가한다.
                        foreach (DataRow dr in ds.Tables[0].Rows)
                            addDownloadListItem(dr);
                }

                // 다운로드 정보를 XmlFile에 저장한다.
                ds.WriteXml(UpdateInfo.xmlPath);
            }
            catch
            {
                throw;
            }
            finally
            {
                lblTotFile.Text = _totalFileCount.ToString();
                lblTotBytes.Text = _totalFileSize.ToString("#,##0");
            }

            return _totalFileCount;
        }

        /// <summary>
        /// Download List를 생성합니다.
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private void addDownloadListItem(DataRow dr)
        {
            decimal size = Convert.ToDecimal(dr["ASSEMBLYSIZE"]);

            _downloadList.Rows.Add(dr["ASSEMBLYID"], dr["ASSEMBLYNAME"], size.ToString("#,##0"), dr["ASSEMBLYVERSION"]);

            //전역변수 처리
            _totalFileCount++;
            _totalFileSize += size;
        }

        #endregion

        #region :: DownloadAssembly(+1 Overloading) :: Assembly를 Download 합니다.

        /// <summary>
        /// Assembly를 Download 합니다.
        /// </summary>
        internal void DownloadAssembly()
        {
            string status = string.Empty;

            int idx = 0;

            foreach (DataRow dr in _downloadList.Rows)
            {
                lblCurFile.Text = Convert.ToString(idx + 1);

                status = DownloadAssembly(dr);

                idx++;
            }
        }

        /// <summary>
        /// Assembly를 Download 합니다.
        /// </summary>
        /// <param name="dr"></param>
        /// <returns>예외가 발생하면 예외 Message를 Return</returns>
        private string DownloadAssembly(DataRow dr)
        {
            string result = string.Empty;

            string assemblyID = dr["ASSEMBLYID"].ToString();
            string assemblyName = dr["ASSEMBLYNAME"].ToString();
            string extention = Path.GetExtension(assemblyName).Substring(1);
            string filePath = "";

            if (assemblyName == @"EBAP.Exe.AutoUpdater.exe")
                assemblyName += DateTime.Now.ToString("yyyyMMdd");

            if (CheckFontType(extention))
                filePath = Path.Combine(GetFontPath(), assemblyName);
            else
                filePath = Path.Combine(UpdateInfo.assemblyFolder, assemblyName);

            try
            {
                int rcvd = 0;
                _curRcvFileSize = 0;
                int LENGTH = 524288;

                byte[] fileContent = GetAssemblyFileContent(assemblyID) as byte[];

                if (fileContent == null) return "해당 파일이 없어요.";

                lblCurrentName.Text = assemblyName;

                FileStream fStream = File.Create(filePath);

                _curSrcFileSize = Convert.ToDecimal(dr["ASSEMBLYSIZE"]);

                int idx = 0;

                while (true)
                {
                    if (fileContent.Length - (rcvd + LENGTH) < LENGTH)
                        LENGTH = fileContent.Length - rcvd;

                    fStream.Write(fileContent, rcvd, LENGTH);

                    _curRcvFileSize += LENGTH;
                    _totRcvFileSize += LENGTH;

                    int d = 0;
                    if (_curSrcFileSize != 0)
                    {
                        d = Convert.ToInt32((_curRcvFileSize * 100) / _curSrcFileSize); // 받은용량 퍼센트
                        if (d > 100)
                            d = 100;
                    }
                    pbCurrent.Value = d;
                    //pbCurrent.Refresh();
                    int f = 0;
                    if (_totalFileSize != 0)
                    {
                        f = Convert.ToInt32((_totRcvFileSize * 100) / _totalFileSize); // 받은용량 퍼센트
                        if (f > 100)
                            f = 100;
                    }
                    pbTotal.Value = f;
                    lblCurBytes.Text = _totRcvFileSize.ToString("#,##0"); // 현재 파일 사이즈
                    lblTotPercent.Text = Convert.ToString(f);
                    Application.DoEvents();

                    rcvd += LENGTH;
                    idx++;

                    if (d >= 100) // 현재 파일 다운로드가 끝나면 while문 종료
                        break;
                }
                fStream.Close();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }

        /// <summary>
        /// Font인지 아닌지 확인합니다.
        /// </summary>
        /// <param name="extention">확장자</param>
        /// <returns></returns>
        private bool CheckFontType(string extention)
        {
            var fontTypes = new string[] { "ttf", "ttc" };

            foreach (string fontType in fontTypes)
            {
                if (extention == fontType)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// 시스템 폰트 Path를 가져옵니다.
        /// </summary>
        /// <returns></returns>
        private string GetFontPath()
        {
            string[] systemPath = Environment.GetFolderPath(Environment.SpecialFolder.System).Split('\\');
            string fontPath = string.Empty;

            for (int i = 0; i < systemPath.Length - 1; i++)
            {
                fontPath = Path.Combine(fontPath, systemPath[i]) + @"\";
            }

            fontPath += "Fonts";

            return fontPath;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="assemblyID"></param>
        /// <returns></returns>
        private object GetAssemblyFileContent(string assemblyID)
        {
            object obj;

            const string queryId = "dbo.AssemblyFileContent_Get";

            string[] paramList = new string[] { "@ASSEMBLYID" };

            object[] valueList = new object[] { assemblyID };

            using (SqlBiz wb = new SqlBiz(Settings.Default.WebServiceURL))
            {
                obj = wb.NTx_ExecuteScalar(Settings.Default.DEFAULTDB, queryId, Settings.Default.COMMANDSP, paramList, valueList);
            }

            return obj;
        }

        #endregion

        #region :: Download_MouseDown ::

        private Point mousePoint;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Download_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }

        #endregion

        #region :: Download_MouseMove ::

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Download_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(this.Left - (mousePoint.X - e.X),
                     this.Top - (mousePoint.Y - e.Y));
            }
        }

        #endregion
    }
}
