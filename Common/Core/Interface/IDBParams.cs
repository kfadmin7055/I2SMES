
namespace EBAP.Core.Interface
{
    /// <summary>
    /// Database Parameter로 사용 여부를 설정하는 Interface 입니다.
    /// </summary>
    public interface IDBParams
    {
        /// <summary>
        /// Parameter 명
        /// </summary>
        string ParamName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        object GetControlParamValue();
    }
}
