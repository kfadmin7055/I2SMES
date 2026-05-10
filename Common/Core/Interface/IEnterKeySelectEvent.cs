
namespace EBAP.Core.Interface
{
    /// <summary>
    /// 엔터키를 눌렀을때 조회이벤트 발생 여부를 설정하는 Interface 입니다.
    /// </summary>
    public interface IEnterKeySelectEvent
    {
        /// <summary>
        /// 엔터키를 눌렀을때 조회이벤트 발생 여부를 설정합니다.
        /// </summary>
        bool EnterKeySelectEvent { get; set; }
    }
}
