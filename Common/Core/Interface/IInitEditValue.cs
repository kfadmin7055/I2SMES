
namespace EBAP.Core.Interface
{
    /// <summary>
    /// 컨트롤이 초기화를 지원 여부를 설정하는 Interface 입니다.
    /// </summary>
    public interface IInitEditValue
    {
        /// <summary>
        /// 컨트롤이 초기화를 지원 여부를 설정합니다.
        /// </summary>
        bool IsInitEditValue { get; set; }
        /// <summary>
        /// 컨트롤을 초기화합니다.
        /// </summary>
        void InitEditValue();
    }
}
