using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EBAP.Core.Security
{
    /// <summary>
    /// 암/복호화를 담당하는 Class 입니다.
    /// </summary>
    /// <remarks>
    /// 2023-02-01 최초생성 : 오인봉
    /// 변경내역
    /// 
    /// </remarks>
    public sealed class Cryptography : IDisposable
    {
        #region :: 전역변수 ::

        const string dKey = "PAPSABCD";         //DES Key : 반드시 8자리여야 한다.
        const string dIv = "ABCDPAPS";          //DES IV : 반드시 8자리여야 한다.
        const string rKey = "PAPSABCDPAPSABCD";     //Rijndael Key : 반드시 16자리여야 한다.
        const string rIv = "ABCDPAPSABCDPAPS";      //Rijndael IV : 반드시 16자리여야 한다.

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

        #region :: DesEncrypt :: DES 알고리즘을 이용하여 문자열을 암호화합니다.

        ///// <summary>
        ///// DES 알고리즘을 이용하여 문자열을 암호화합니다.
        ///// </summary>
        ///// <param name="encryptString">암호화할 문자열</param>
        ///// <returns></returns>
        //public static string DesEncrypt(string encryptString)
        //{
        //    string encrypt = string.Empty;

        //    using (DES desKey = DES.Create())
        //    {
        //        desKey.Key = Encoding.Default.GetBytes(dKey);
        //        desKey.IV = Encoding.Default.GetBytes(dIv);

        //        using (MemoryStream mStream = new MemoryStream())
        //        {
        //            using (CryptoStream cStream = new CryptoStream(mStream, desKey.CreateEncryptor(), CryptoStreamMode.Write))
        //            {
        //                using (StreamWriter sWriter = new StreamWriter(cStream))
        //                {
        //                    sWriter.Write(encryptString);
        //                }
        //                encrypt = Convert.ToBase64String(mStream.ToArray());
        //            }
        //        }
        //    }

        //    return encrypt;
        //}

        //#endregion

        //#region :: DesDecrypt :: DES 알고리즘을 이용하여 문자열을 복호화합니다.

        ///// <summary>
        ///// DES 알고리즘을 이용하여 문자열을 복호화합니다.
        ///// </summary>
        ///// <param name="decryptString">복호화할 문자열</param>
        ///// <returns></returns>
        //public static string DesDecrypt(string decryptString)
        //{
        //    string decrypt = string.Empty;

        //    using (DES desKey = DES.Create())
        //    {
        //        desKey.Key = Encoding.Default.GetBytes(dKey);
        //        desKey.IV = Encoding.Default.GetBytes(dIv);

        //        byte[] buffer = Convert.FromBase64String(decryptString);

        //        using (MemoryStream mStream = new MemoryStream(buffer))
        //        {
        //            ICryptoTransform cTrans = desKey.CreateDecryptor();
        //            using (CryptoStream cStream = new CryptoStream(mStream, cTrans, CryptoStreamMode.Read))
        //            {
        //                using (StreamReader sReader = new StreamReader(cStream))
        //                {
        //                    decrypt = sReader.ReadToEnd();
        //                }
        //            }
        //        }
        //    }

        //    return decrypt;
        //}

        #endregion

        #region :: RijndaelEncrypt :: Rijndael 알고리즘을 이용하여 문자열을 암호화합니다.

        /// <summary>
        /// Rijndael 알고리즘을 이용하여 문자열을 암호화합니다.
        /// </summary>
        /// <param name="encryptString">암호화할 문자열</param>
        /// <returns></returns>
        public static string RijndaelEncrypt(string encryptString)
        {
            string encrypt = string.Empty;

            using (MemoryStream mStream = new MemoryStream())
            {
                using (Rijndael aesAlg = Rijndael.Create())
                {
                    aesAlg.Key = Encoding.Default.GetBytes(rKey);
                    aesAlg.IV = Encoding.Default.GetBytes(rIv);

                    ICryptoTransform cTrans = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                    using (CryptoStream cStream = new CryptoStream(mStream, cTrans, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sWriter = new StreamWriter(cStream))
                        {
                            sWriter.Write(encryptString);
                        }
                    }
                }
                encrypt = Convert.ToBase64String(mStream.ToArray());
            }
            return encrypt;
        }

        #endregion

        #region :: RijndaelDecrypt :: Rijndael 알고리즘을 이용하여 문자열을 복호화합니다.

        /// <summary>
        /// Rijndael 알고리즘을 이용하여 문자열을 복호화합니다.
        /// </summary>
        /// <param name="decryptString">복호화할 문자열</param>
        /// <returns></returns>
        public static string RijndaelDecrypt(string decryptString)
        {
            string decrypt = string.Empty;

            using (Rijndael aesAlg = Rijndael.Create())
            {
                aesAlg.Key = Encoding.Default.GetBytes(rKey);
                aesAlg.IV = Encoding.Default.GetBytes(rIv);

                ICryptoTransform cTrans = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                byte[] buffer = Convert.FromBase64String(decryptString);
                using (MemoryStream msDecrypt = new MemoryStream(buffer))
                {
                    using (CryptoStream cStream = new CryptoStream(msDecrypt, cTrans, CryptoStreamMode.Read))
                    {
                        using (StreamReader sReader = new StreamReader(cStream))
                        {
                            decrypt = sReader.ReadToEnd();
                        }
                    }
                }
            }
            return decrypt;
        }

        #endregion

        #region :: GetMD5Hash :: 암호화 된 MD5 Text를 가져옵니다.

        /// <summary>
        /// 암호화 된 MD5 Text를 가져옵니다..
        /// </summary>
        /// <param name="input">입력값</param>
        /// <returns></returns>
        public static string GetMD5Hash(string input)
        {
            MD5 md = MD5.Create();

            byte[] data = md.ComputeHash(Encoding.Default.GetBytes(input));

            StringBuilder sb = new StringBuilder();

            for (int idx = 0; idx < data.Length; idx++)
                sb.Append(data[idx].ToString("x2"));

            return sb.ToString();
        }

        #endregion

        #region :: ValidateMd5Hash :: MD5를 검증합니다.

        /// <summary>
        /// MD5를 검증합니다.
        /// </summary>
        /// <param name="input">입력값</param>
        /// <param name="hash">해쉬 코드값(DB 저장 값)</param>
        /// <returns></returns>
        public static bool ValidateMd5Hash(string input, string hash)
        {
            string hashOfInput = GetMD5Hash(input);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return 0 == comparer.Compare(hashOfInput, hash) ? true : false;
        }

        #endregion

        #region :: GetSHA256Hash :: 암호화 된 SHA256 Text를 가져옵니다.

        /// <summary>
        /// 암호화 된 SHA256 Text를 가져옵니다.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetSHA256Hash(string input)
        {
            SHA256 sha256 = SHA256.Create();

            byte[] data = sha256.ComputeHash(Encoding.Default.GetBytes(input));

            StringBuilder sb = new StringBuilder();

            for (int idx = 0; idx < data.Length; idx++)
                sb.Append(data[idx].ToString("x2"));

            return sb.ToString();
        }

        #endregion

        #region :: ValidateSHA256Hash :: SHA256을 검증합니다.

        /// <summary>
        /// SHA256을 검증합니다.
        /// </summary>
        /// <param name="input">입력값</param>
        /// <param name="hash">해쉬 코드값(DB 저장 값)</param>
        /// <returns></returns>
        public static bool ValidateSHA256Hash(string input, string hash)
        {
            string hashOfInput = GetSHA256Hash(input);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return 0 == comparer.Compare(hashOfInput, hash) ? true : false;
        }

        #endregion

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="strValue"></param>
        ///// <param name="encriptKey"></param>
        ///// <returns></returns>
        //public string CapicomEncript(string strValue, string encriptKey)
        //{
        //    if (strValue == "") return "";

        //    string encript = "";

        //    CAPICOM.EncryptedData capicom = Microsoft.VisualBasic.Interaction.CreateObject("CAPICOM.EncryptedData") as CAPICOM.EncryptedData;

        //    capicom.Algorithm.Name = CAPICOM.CAPICOM_ENCRYPTION_ALGORITHM.CAPICOM_ENCRYPTION_ALGORITHM_RC4;
        //    capicom.SetSecret(encriptKey);
        //    capicom.Content = strValue;
        //    encript = capicom.Encrypt();

        //    return encript;
        //}
    }
}
