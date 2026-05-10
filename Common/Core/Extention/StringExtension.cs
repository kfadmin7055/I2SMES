using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace EBAP.Core
{
    /// <summary>
    /// String Class 확장 메서드 입니다.
    /// </summary>
    /// <remarks>
    /// 2023-02-01 최초생성 : 오인봉
    /// 변경내역
    /// 
    /// </remarks>
    public static class StringExtension
    {
        #region :: 정규식 ::

        /// <summary>
        /// 이메일 정규식 패턴 샘플
        /// </summary>
        public const string EmailAddressRegex = @"^([a-zA-Z0-9_'+*$%\^&!\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9:]{2,4})+$";
        /// <summary>
        /// 통화 정규식 패턴 샘플
        /// </summary>
        public const string CurrencyRegex = @"(^\$?(?!0,?\d)\d{1,3}(,?\d{3})*(\.\d\d)?)$";
        /// <summary>
        /// 일자 정규식 패턴 샘플
        /// </summary>
        public const string DateRegex = @"^(((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}|\d))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00|[048])))$";
        /// <summary>
        /// 숫자 정규식 패턴 샘플
        /// </summary>
        public const string NumericRegex = @"\d*";
        /// <summary>
        /// 영문 포함 패턴 샘플
        /// </summary>
        public const string ContainAlphabeta = @"^[a-zA-Z]";

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Extention Method
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: IsMatch :: 해당 문자열이 지정된 정규식 패턴 부합 결과를 반환합니다.

        /// <summary>
        /// 해당 문자열이 지정된 정규식 패턴 부합 결과를 반환합니다.
        /// </summary>
        /// <param name="s">해당 문자열</param>
        /// <param name="pattern">정규식 패턴</param>
        /// <returns></returns>
        public static bool IsMatch(this string s, string pattern)
        {
            return (new Regex(pattern)).IsMatch(s);
        }

        #endregion

        #region :: Left(+1 Overloading) :: 해당 문자열을 왼쪽에서부터 지정된 길이만큼 나누어 반환합니다.

        /// <summary>
        /// 해당 문자열을 왼쪽에서부터 지정된 길이만큼 나누어 반환합니다.
        /// </summary>
        /// <param name="s">해당 문자열</param>
        /// <param name="length">문자열을 나눌 길이</param>
        /// <returns></returns>
        public static string Left(this string s, int length)
        {
            if (String.IsNullOrEmpty(s) || length > s.Length || length < 0)
                return s;

            return s.Substring(0, length);
        }

        /// <summary>
        /// 해당 문자열을 지정된 Encoding에 맞춰 왼쪽에서부터 지정된 길이만큼 나누어 반환합니다.
        /// </summary>
        /// <param name="s">해당 문자열</param>
        /// <param name="length">문자열을 나눌 길이</param>
        /// <param name="isAscii">ASCII 코드 길이로 계산할지 지정합니다.</param>
        /// <returns></returns>
        public static string Left(this string s, int length, bool isAscii)
        {
            if (String.IsNullOrEmpty(s) || length > s.Length || length < 0)
                return s;

            if (!isAscii) return s.Substring(0, length);

            byte[] sBuff = Encoding.Unicode.GetBytes(s);
            byte[] uBuff = Encoding.Convert(Encoding.Unicode, Encoding.Default, sBuff);

            return uBuff.Length < length ? Encoding.Default.GetString(uBuff) : Encoding.Default.GetString(uBuff, 0, length);
        }

        #endregion

        #region :: ToByteArray(+1 Overloading) :: 해당 문자열을 바이트 배열로 반환합니다.

        /// <summary>
        /// 해당 문자열을 바이트 배열로 반환합니다.
        /// </summary>
        /// <param name="s">해당 문자열</param>
        /// <returns></returns>
        public static byte[] ToByteArray(this string s)
        {
            return s.ToByteArray(ASCIIEncoding.ASCII);
        }

        /// <summary>
        /// 해당 문자열을 지정된 Encoding에 맞춰 바이트 배열로 반환합니다.
        /// </summary>
        /// <param name="s">해당 문자열</param>
        /// <param name="encoding">Encoding</param>
        /// <returns></returns>
        public static byte[] ToByteArray(this string s, Encoding encoding)
        {
            if (encoding == null) throw new ArgumentException("An encoding scheme must be specified");

            return encoding.GetBytes(s);
        }

        #endregion

        #region :: ToList :: 해당 문자열을 Split하여 List Collection으로 반환합니다.

        /// <summary>
        /// 해당 문자열을 Split하여 List Collection으로 반환합니다.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static List<string> ToList(this string s, string separator)
        {
            List<string> list = new List<string>();

            foreach (string e in s.Split(separator.ToCharArray())) list.Add(e.Trim());

            return list;
        }

        #endregion

        #region :: Right :: 해당 문자열을 오른쪽에서부터 지정된 길이만큼 나누어 반환합니다.

        /// <summary>
        /// 해당 문자열을 오른쪽에서부터 지정된 길이만큼 나누어 반환합니다.
        /// </summary>
        /// <param name="s">해당 문자열</param>
        /// <param name="length">문자열을 나눌 길이</param>
        /// <returns></returns>
        public static string Right(this string s, int length)
        {
            if (String.IsNullOrEmpty(s) || length > s.Length || length < 0)
                return s;

            return s.Substring(s.Length - length);
        }

        #endregion

        #region :: Split :: 해당 문자열을 Split 하여 문자열 배열로 반환합니다.

        /// <summary>
        /// 해당 문자열을 Split 하여 문자열 배열로 반환합니다.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string[] Split(this string s, string separator)
        {
            return s.Split(separator.ToCharArray());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="length"></param>
        /// <param name="pad"></param>
        /// <returns></returns>
        public static string LPAD(this string s, int length, string pad)
        {
            string val = "";

            for (int i = 0; i < length; i++)
            {
                val += pad;
            }
            s = val + s;

            return s.Right(length);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="length"></param>
        /// <param name="pad"></param>
        /// <returns></returns>
        public static string RPAD(this string s, int length, string pad)
        {
            string val = "";

            for (int i = 0; i < length; i++)
            {
                val += pad;
            }
            s += val;

            return s.Left(length);
        }

        #endregion

        #region :: In :: 포함된 문자열이 있는지 검사합니다.

        /// <summary>
        /// 포함된 문자열이 있는지 검사합니다.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool In(this string s, params string[] values)
        {
            foreach (string value in values)
            {
                if (s == value)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 포함된 문자열이 있는지 검사합니다.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool NotIn(this string s, params string[] values)
        {
            foreach (string value in values)
            {
                if (s == value)
                    return false;
            }
            return true;
        }

        #endregion

        #region :: TryParse :: 문자열을 해당 형태로 변환하여 반환합니다.

        /// <summary>
        /// 문자열을 숫자로 변환하여 반환합니다.
        /// </summary>
        /// <param name="o">문자열</param>
        /// <param name="baseVale">기본값</param>
        /// <returns></returns>
        public static int TryParseInt32(this object o, int baseVale = 0)
        {
            return o.ToString().TryParseInt32(baseVale);
        }

        /// <summary>
        /// 문자열을 숫자로 변환하여 반환합니다.
        /// </summary>
        /// <param name="s">문자열</param>
        /// <param name="baseVale">기본값</param>
        /// <returns></returns>
        public static int TryParseInt32(this string s, int baseVale = 0)
        {
            int x = 0;

            if (Int32.TryParse(s, out x))
                return x;
            else
                return baseVale;
        }

        /// <summary>
        /// 문자열을 숫자로 변환하여 반환합니다.
        /// </summary>
        /// <param name="o">문자열</param>
        /// <param name="baseVale">기본값</param>
        /// <returns></returns>
        public static double TryParseDouble(this object o, double baseVale = 0)
        {
            return o.ToString().TryParseDouble(baseVale);
        }

        /// <summary>
        /// 문자열을 숫자로 변환하여 반환합니다.
        /// </summary>
        /// <param name="s">문자열</param>
        /// <param name="baseVale">기본값</param>
        /// <returns></returns>
        public static double TryParseDouble(this string s, double baseVale = 0)
        {
            double x = 0;

            if (Double.TryParse(s, out x))
                return x;
            else
                return baseVale;
        }

        #endregion

        #region :: GetWordCount :: 문자열에 포함된 단어 수를 반환합니다.

        /// <summary>
        /// 문자열에 포함된 단어 수를 반환합니다.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int GetWordCount(this string s)
        {
            return s.Split(" ").Length;
        }

        #endregion

        #region :: 데이터가 비어있는지 확인합니다.

        /// <summary>
        /// 데이터가 비어있는지 확인합니다.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsEmpty(this string s)
        {
            if (s.Trim() == "") return true;

            return false;
        }

        #endregion

        /// <summary>
        /// 문자 증가
        /// </summary>
        /// <param name="schar"></param>
        /// <param name="sValue"></param> 
        /// /// <param name="endSeq"></param>
        /// <returns></returns>
        public static string GetASCValue(this string schar, string sValue = "A", int endSeq = 0)
        {
            string returnValue = null;
            int ichar = schar.TryParseInt32();
            int isValue = 0;
            int changeValue = 0;

            if (endSeq > 0 && ichar > endSeq)
            {
                return "";
            }

            int iDec = (char)(Convert.ToChar(sValue) + ichar);

            // Z 초과 시 returnValue 에 A 부터 증가
            if (iDec > 90)
            {
                isValue = (char)(Convert.ToChar(sValue));

                while (isValue > 65)
                {
                    --isValue;
                    ++changeValue;
                }

                decimal dValue = (ichar + changeValue) / 26;
                int iCuttingValue = (int)Math.Floor(dValue);

                returnValue = ((char)(64 + iCuttingValue)).ToString();

                ichar = (ichar + changeValue) - (26 * iCuttingValue);
                sValue = "A";
            }

            returnValue += ((char)(Convert.ToChar(sValue) + ichar)).ToString();

            return returnValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string[] GetWeekToDate(this string s)
        {
            string maxDate = string.Empty;
            string minDate = string.Empty;
            DateTime nowDate = DateTime.Parse(s);
            int week = (int)(DateTime.Parse(s).DayOfYear / 7) + 1;
            int vWeek;

            for (int i = 0; i < 7; i++)
            {
                vWeek = (int)(DateTime.Parse(nowDate.ToString()).DayOfYear / 7) + 1;

                if (week == vWeek)
                {
                    nowDate = nowDate.AddDays(1);
                    maxDate = nowDate.AddDays(-1).ToString();
                }
                else
                    break;
            }

            nowDate = DateTime.Parse(s);

            if (DateTime.Parse(s).DayOfWeek == DayOfWeek.Monday)
                minDate = DateTime.Parse(s).AddDays(-6).ToString();
            else
            {
                for (int i = 0; i < 7; i++)
                {
                    vWeek = (int)(DateTime.Parse(nowDate.ToString()).DayOfYear / 7) + 1;

                    if (week == vWeek || nowDate.Year != DateTime.Parse(s).Year)
                    {
                        nowDate = nowDate.AddDays(-1);
                        minDate = nowDate.AddDays(1).ToString();
                    }
                    else
                        break;
                }
            }

            string[] returnValue = new string[] { minDate, maxDate, week.ToString() };

            return returnValue;
        }
    }
}
