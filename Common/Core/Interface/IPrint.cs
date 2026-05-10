
namespace EBAP.Core.Interface
{
    /// <summary>
    /// Excel, PDF 파일로 내보내기 사용 여부를 설정하는 Interface 입니다.
    /// </summary>
    public interface IPrint
    {
        /// <summary>
        /// 데이터를 미리보기 합니다.
        /// </summary>
        void PrintPreview();
    }
}
