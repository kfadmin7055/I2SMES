
namespace EBAP.Core.Interface
{
    /// <summary>
    /// 컨트롤의 값이 변경되었을 때 UIFrame에 수정 여부 알림을 설정하는 Interface 입니다.
    /// </summary>
    public interface ICheckModified
    {
        /// <summary>
        /// 컨트롤의 값이 변경되었을 때 UIFrame에 수정 여부 알림을 설정합니다.
        /// </summary>
        bool CheckModified { get; set; }
    }
}
