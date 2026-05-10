
namespace EBAP.Core.Interface
{
    /// <summary>
    /// 선택 값이 변경되었을 때 조회이벤트 발생 여부를 설정하는 Interface 입니다.
    /// </summary>
    public interface IValueChangeSelectEvent
    {
        /// <summary>
        /// 선택 값이 변경 되었을때 조회이벤트 발생 여부를 설정합니다.
        /// </summary>
        bool ValueChangeSelectEvent { get; set; }
    }
}
