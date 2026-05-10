using EBAP.Core.Localization;

namespace EBAP.Core.Interface
{
    /// <summary>
    /// 다국어 사용여부를 설정하는 Interface 입니다.
    /// </summary>
    public interface ILocaleConverter
    {
        /// <summary>
        /// 다국어 지원에 사용할 Localizer
        /// </summary>
        LocaleConverter LOCALECONVERTER { get; }
    }
}
