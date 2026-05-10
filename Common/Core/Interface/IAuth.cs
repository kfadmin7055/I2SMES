
namespace EBAP.Core.Interface
{
    /// <summary>
    /// 권한 설정 기능을 정의하는 Interface입니다.
    /// </summary>
    public interface IAuth
    {
        /// <summary>
        /// 조회권한을 설정합니다.
        /// </summary>
        bool SelectAuth { get; set; }

        /// <summary>
        /// 신규권한을 설정합니다.
        /// </summary>
        bool NewAuth { get; set; }

        /// <summary>
        /// 저장권한을 설정합니다.
        /// </summary>
        bool SaveAuth { get; set; }

        /// <summary>
        /// 삭제권한을 설정합니다.
        /// </summary>
        bool DelAuth { get; set; }
    }
}
