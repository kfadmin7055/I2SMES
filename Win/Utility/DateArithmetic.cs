using System;

namespace EBAP.Win.Utility
{
    /// <summary>
    /// Application에서 사용할 날짜 관련 Method를 정의합니다.
    /// </summary>
    /// <remarks>
    /// 2023-02-01 최초생성 : 오인봉
    /// 변경내역
    /// 
    /// </remarks>
    public class DateArithmetic
    {
        /// <summary>
        /// 현재 시간과 비교하여 연수를 Return 합니다.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static int GetYearFrom(DateTime dt)
        {
            int gap = 0;
            TimeSpan ts = DateTime.Now - dt;

            gap = ts.Days / 365;

            return gap + 2;
        }

        /// <summary>
        /// 날짜 형식에 날짜를 더합니다.
        /// </summary>
        /// <param name="dateString">날짜문자열</param>
        /// <param name="type">YEAR, MONTH, DAY</param>
        /// <param name="gap">더할 숫자</param>
        /// <returns></returns>
        public static string GetAddDate(string dateString, DateTimeType type, int gap)
        {
            if (dateString.Length < 8) return string.Empty;

            DateTime dt = Convert.ToDateTime(dateString);

            switch (type)
            {
                case DateTimeType.YEAR:
                    dt.AddYears(gap);
                    break;
                case DateTimeType.MONTH:
                    dt.AddMonths(gap);
                    break;
                case DateTimeType.DAY:
                    dt.AddDays(gap);
                    break;
            }

            return dt.ToShortDateString();
        }
    }
}
