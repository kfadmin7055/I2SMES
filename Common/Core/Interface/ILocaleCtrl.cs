
namespace EBAP.Core.Interface
{
    /// <summary>
    /// 다국어 사용 여부를 설정하는 Interface 입니다.
    /// </summary>
    public interface ILocaleCtrl
    {
        /// <summary>
        /// Language String ID 명
        /// </summary>
        string LocaleEnumClass { get; set; }

        /// <summary>
        /// 컨트롤의 다국어 텍스트를 설정합니다.
        /// </summary>
        void SetLocaleString();
    }
}
