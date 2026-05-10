using EBAP.Core.Collections;
using EBAP.Core.Info;
using System;

namespace EBAP.Core.Interface
{
    /// <summary>
    /// Main Frame과 UI 설정 기능을 정의하는 Interface입니다.
    /// </summary>
    public interface IFrameUI
    {
        /// <summary>
        /// 현재 사용자의 정보를 설정합니다.
        /// </summary>
        UserInfo CurrentUser { get; }

        /// <summary>
        /// 메뉴ID를 설정합니다.
        /// </summary>
        string MENUID { get; set; }

        /// <summary>
        /// 저장/삭제 처리 후 보여줄 메시지
        /// </summary>
        string OKMESSAGE { get; set; }

        /// <summary>
        /// 최상위 메뉴 ID를 설정합니다.
        /// </summary>
        string TOPMENUID { get; set; }

        /// <summary>
        /// 중간 메뉴 ID를 설정합니다.
        /// </summary>
        string MIDDLEMENUID { get; set; }

        /// <summary>
        /// 공통 Parameter 포함 여부를 설정합니다.
        /// </summary>
        bool AddCommomParam { get; set; }

        /// <summary>
        /// UI 수정여부를 Check 하여 수정여부를 Caption에 표시합니다.
        /// </summary>
        bool ISMODIFIED { get; set; }

        /// <summary>
        /// LOAD 상태를 체크합니다.
        /// </summary>
        bool ISLOADING { get; set; }

        /// <summary>
        /// Popup을 생성하고 실행합니다.
        /// </summary>
        /// <param name="text">Popup 제목</param>
        /// <param name="dllPath">Dll 경로</param>
        /// <param name="className">Class 명</param>
        /// <param name="popParams">Popup Parameters</param>
        /// <remarks>
        /// 2016-06-17 최초생성 : 오인봉
        /// 변경내역
        ///
        /// </remarks>
        object ExecutePopup(string text, string dllPath, string className, ParamCollection popParams);

        /// <summary>
        /// 시스템의 현재 시간을 가져옵니다.
        /// </summary>
        /// <returns></returns>
        DateTime GetCurrentTime();

        /// <summary>
        /// Database에 실행 Log를 저장합니다.
        /// </summary>
        /// <param name="opertion"></param>
        /// <param name="dtStart"></param>
        void SaveOperationLog(string opertion, DateTime dtStart);

        /// <summary>
        /// Database에 실행 Log를 저장합니다.
        /// </summary>
        /// <param name="opertion"></param>
        /// <param name="dtStart"></param>
        /// <param name="dtEnd"></param>
        void SaveOperationLog(string opertion, DateTime dtStart, DateTime dtEnd);
    }
}
