namespace EBAP.Core.Info
{
    /// <summary>
    /// Summary Type을 정의합니다.
    /// </summary>
    public enum SummaryType
    {
        // 요약:
        //     The sum of all values in a column.
        /// <summary>
        /// SUM
        /// </summary>
        Sum = 0,
        //
        // 요약:
        //     The minimum value in a column.
        /// <summary>
        /// MIN
        /// </summary>
        Min = 1,
        //
        // 요약:
        //     The maximum value in a column.
        /// <summary>
        /// MAX
        /// </summary>
        Max = 2,
        //
        // 요약:
        //     The record count.
        /// <summary>
        /// COUNT
        /// </summary>
        Count = 3,
        //
        // 요약:
        //     The average value of a column.
        /// <summary>
        /// Average
        /// </summary>
        Average = 4,
        //
        // 요약:
        //     Specifies whether calculations should be performed manually using a specially
        //     designed event.
        /// <summary>
        /// CUSTOM
        /// </summary>
        Custom = 5,
        //
        // 요약:
        //     Disables summary value calculation.
        /// <summary>
        /// NONE
        /// </summary>
        None = 6,
    }
}
