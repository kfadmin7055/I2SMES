namespace EBAP.Core.Info
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 2023-02-01 최초생성 : 오인봉
    /// 변경내역
    /// 
    /// </remarks>
    public enum UnboundType
    {
        /// <summary>
        /// 요약:
        ///     Indicates that the column is bound to a field in the control’s underlying data
        ///     source. The type of data this column contains is determined by the bound field.
        /// </summary>
        Bound,
        //
        /// <summary>
        /// 요약:
        ///     Indicates that the column is unbound and it contains integer values (the System.Int32
        ///     type).
        /// </summary>
        Integer,
        /// <summary>
        /// 요약:
        ///     Indicates that the column is unbound and it contains decimal values (the System.Decimal
        ///     type).
        /// </summary>
        Decimal,
        /// <summary>
        /// 요약:
        ///     Indicates that the column is unbound and it contains date/time values (the System.DateTime
        ///     type).
        /// </summary>
        DateTime,
        /// <summary>
        /// 요약:
        ///     Indicates that the column is unbound and it contains string values (the System.String
        ///     type).
        /// </summary>
        String,
        /// <summary>
        /// 요약:
        ///     Indicates that the column is unbound and it contains Boolean values (the System.Boolean
        ///     type).
        /// </summary>
        Boolean,
        /// <summary>
        /// 요약:
        ///     Indicates that the column is unbound and it contains values of any type. A DevExpress.XtraEditors.TextEdit
        ///     editor is assigned for the in-place editing of such a column.
        /// </summary>
        Object
    }
}
