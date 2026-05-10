using EBAP.Business.WSBiz;
using EBAP.Core.Info;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace EBAP.Exe.MainUI
{
    internal static class CheckUpdate
    {
        internal static List<string> updateReason = new List<string>();
        internal static bool ISESSENTIAL = false;
        /// <summary>
        /// Download List와 Assembly를 검사합니다.
        /// </summary>
        /// <param name="userid">사용자 ID</param>
        /// <returns>0: Download 할 Assembly 없음</returns>
        internal static int checkUpdate(string userid)
        {
            int totalFileCount = 0;
            updateReason.Clear();

            try
            {
                DataSet ds = null;

                const string queryId = "dbo.AssemblyDownloadList_Select";

                string[] paramList = new string[] { "@USERID" };
                object[] valueList = new object[] { userid };

                using (SqlBiz wb = new SqlBiz(AppConfig.WEBSERVICEURL))
                {
                    ds = wb.NTx_ExecuteDataSet(ConnectionString.METADB, queryId, AppConfig.COMMANDSP, paramList, valueList);
                }

                if (ds == null) return 0;

                // 이전에 다운로드 받은 정보를 담고 있는 XmlFile
                FileInfo fInfo = new FileInfo(Path.Combine(AppConfig.ASSEMBLYFOLDER, @"DownloadList.xml"));

                string path = AppConfig.ASSEMBLYFOLDER;
                string extention = string.Empty;

                using (DataSet dsXml = new DataSet())
                {
                    // 이전 다운로드 정보가 있다면
                    if (fInfo.Exists)
                    {
                        // 이전 다운로드 정보를 읽어 dsXml에 넣어준다.
                        dsXml.ReadXml(fInfo.FullName);
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            string reason = dr["REASON"].ToString();
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
                                    {
                                        totalFileCount++;
                                        AddUpdateReason(reason);
                                        if (dr["ISESSENTIAL"].ToString() == "True") ISESSENTIAL = true;
                                    }
                                }
                                else
                                {
                                    totalFileCount++;
                                    AddUpdateReason(reason);
                                    if (dr["ISESSENTIAL"].ToString() == "True") ISESSENTIAL = true;
                                }
                            }
                            else
                            {
                                //파일이 없으면 ListView에 추가한다.
                                totalFileCount++;
                                AddUpdateReason(reason);
                                if (dr["ISESSENTIAL"].ToString() == "True") ISESSENTIAL = true;
                            }
                        }
                    }
                    else
                    {
                        //이전 다운로드 정보가 없으면 모든 파일을 ListView에 추가한다.
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            string reason = dr["REASON"].ToString();
                            if (dr["ISESSENTIAL"].ToString() == "True") ISESSENTIAL = true;
                            totalFileCount++;
                            AddUpdateReason(reason);
                        }
                    }
                }
            }
            catch
            {
                throw;
            }

            return totalFileCount;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reason"></param>
        private static void AddUpdateReason(string reason)
        {
            if (updateReason.Contains(reason)) return;

            updateReason.Add(reason);
        }
    }
}
