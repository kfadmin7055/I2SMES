using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EBAP.Core.Interface
{
    /// <summary>
    /// Excel, PDF 파일로 내보내기 사용 여부를 설정하는 Interface 입니다.
    /// </summary>
    public interface IExport
    {
        /// <summary>
        /// Export를 비활성화 합니다.
        /// </summary>
        bool DisableExport { get; set; }
        /// <summary>
        /// Excel로 Export 합니다.
        /// </summary>
        /// <param name="filePath"></param>
        void ExportXlsx(string filePath);

        /// <summary>
        /// PDF로 Export 합니다.
        /// </summary>
        /// <param name="filePath"></param>
        void ExportPdf(string filePath);
    }
}
