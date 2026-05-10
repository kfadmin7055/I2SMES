
namespace EBAP.Core.Interface
{
    /// <summary>
    /// 필수입력 체크 여부를 설정하는 Interface 입니다.
    /// </summary>
    public interface IMandatory
    {
        /// <summary>
        /// 필수입력(저장) 체크 여부를 설정합니다.
        /// </summary>
        bool IsMandatoryForSave { get; set; }

        /// <summary>
        /// 필수입력(조회) 체크 여부를 설정합니다.
        /// </summary>
        bool IsMandatoryForSelect { get; set; }
    }
}
