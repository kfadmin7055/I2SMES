
namespace EBAP.Core.Localization
{
    /// <summary>
    /// 다국어코드와 Mapping 될 Enum Class 입니다.
    /// </summary>
    public enum MsgId
    {
        /// <summary>
        /// 없음
        /// </summary>
        None = 0,
        /// <summary>
        /// [ {0} ] 을(를) 저장하시겠습니까?
        /// </summary>
        CF_Save = 1,
        /// <summary>
        /// [ {0} ] 을(를) 삭제할까요?
        /// </summary>
        CF_Delete = 2,
        /// <summary>
        /// 선택한 [ {0} ] 을(를) 삭제할까요?
        /// </summary>
        CF_S_Delete = 3,
        /// <summary>
        /// [ {0} ] 을(를) 인쇄하시겠습니까?
        /// </summary>
        CF_Print = 4,
        /// <summary>
        /// [ {0} ] 하시겠습니까?
        /// </summary>
        CF_Do = 5,
        /// <summary>
        /// [ {0} ] 을(를) 취소하시겠습니까?
        /// </summary>
        CF_Cancel = 6,
        /// <summary>
        /// 정상으로 조회 되었습니다.
        /// </summary>
        OK_SELECT = 7,
        /// <summary>
        /// 정상으로 저장 되었습니다.
        /// </summary>
        OK_SAVE = 8,
        /// <summary>
        /// 정상으로 삭제 되었습니다.
        /// </summary>
        OK_DELETE = 9,
        /// <summary>
        /// 정상으로 처리 되었습니다.
        /// </summary>
        OK_PROCESS = 10,
        /// <summary>
        /// [ {0} ] 작업이 정상으로 처리 되었습니다.
        /// </summary>
        OK_WORK = 11,
        /// <summary>
        /// [ {0} ] 을(를) 종료하시겠습니까?
        /// </summary>
        CF_Exit = 12,
        /// <summary>
        /// [ {0} ] 은(는) 필수 입력 항목입니다.
        /// </summary>
        IF_EssentialItem = 13,
        /// <summary>
        /// [ {0} ] 처리할 데이터가 없어요.
        /// </summary>
        IF_NoData = 14,
        /// <summary>
        /// 치공구를 폐기하시겠습니까?
        /// </summary>
        CF_JigDiscard = 501,
        /// <summary>
        /// 치공구를 폐기취소 하시겠습니까?
        /// </summary>
        CF_JigDisuseCancel = 502,
        /// <summary>
        /// 치공구의 특이사항을 등록하시겠습니까?
        /// </summary>
        CF_JigPeculiar = 503,
        /// <summary>
        /// 치공구를 [ {0} ] 상태로 변경할까요?
        /// </summary>
        CF_JigStatusChange = 504,
        /// <summary>
        /// 선택한 치공구를 요청 처리 하시겠습니까?
        /// </summary>
        CF_S_JigRequest = 505,
        /// <summary>
        /// 선택한 치공구를 이동 처리 하시겠습니까?
        /// </summary>
        CF_S_JigMove = 506,
        /// <summary>
        /// 선택한 치공구를 불출이동 처리 하시겠습니까?
        /// </summary>
        CF_S_JigMoveInOut = 507,
        /// <summary>
        /// 선택한 치공구를 [ {0} ] 상태로 변경할까요?
        /// </summary>
        CF_S_JigStatusChange = 508,
        /// <summary>
        /// 선택한 치공구를 폐기 하시겠습니까?
        /// </summary>
        CF_S_JigDiscard = 509,
        /// <summary>
        /// [ {0} ] 제작(검사)공정을 시작하시겠습니까?
        /// </summary>
        CF_MakeProcess = 510,
        /// <summary>
        /// 치공구 [ {0} ] 을(를) 완료하시겠습니까?
        /// </summary>
        CF_JigCompletion = 511,
        /// <summary>
        /// 치공구 신규 제작을 요청하시겠습니까?
        /// </summary>
        CF_JigMakeRequest = 512,
        /// <summary>
        /// [ {0} ] 이(가) 없어요.
        /// </summary>
        IF_NotExist = 10002,
        /// <summary>
        /// [ {0} ] 을(를) 선택하세요.
        /// </summary>
        IF_Select = 10003,
        /// <summary>
        /// 중복된 데이터가 존재합니다.
        /// </summary>
        IF_DupValue = 10004,
        /// <summary>
        /// [ {0} ] 이(가) 저장되었습니다.
        /// </summary>
        IF_Save = 10005,
        /// <summary>
        /// 미입력된 항목이 존재합니다.
        /// </summary>
        IF_BlankItem = 10006,
        /// <summary>
        /// [ {0} ] 할 [ {1} ] 을(를) 선택하세요.
        /// </summary>
        IF_S_Select = 10007,
        /// <summary>
        /// 인쇄 ROLL [ {0} ] Pitch는 숫자(3 or 4자리)입니다.
        /// </summary>
        IF_RollPitch = 40001,
        /// <summary>
        /// 치공구가 요청 취소 되었습니다.
        /// </summary>
        IF_JigRequestCancel = 40002,
        /// <summary>
        /// {0} 개의 치공구 [ {1} ] 처리가 완료되었습니다.
        /// </summary>
        IF_S_JigCompletion = 40003,
        /// <summary>
        /// 4개 이상의 바코드는 출력되지 않습니다.
        /// </summary>
        IF_NotPrint4 = 40004,
        /// <summary>
        /// 같은 관리번호만 출력 가능합니다.
        /// </summary>
        IF_SameMntPrint = 40005,
        /// <summary>
        /// [ {0} 제작(검사)공정 ] 시 검사장비는 필수 완료 조건입니다.
        /// </summary>
        IF_EssentialMakeStation = 40006,
        /// <summary>
        /// 신청 필름번호를 확인하세요. [ {0} ] 을(를) 입력하세요.
        /// </summary>
        IF_CheckFilmNumber = 40007,
        /// <summary>
        /// 현 재공에 없는 [ {0} ] 입니다.
        /// </summary>
        IF_NotExistWIP = 40008,
        /// <summary>
        /// 치공구 신규 제작 요청이 완료 되었습니다.
        /// </summary>
        IF_JigMakeRequestComplete = 40009,
        /// <summary>
        /// [ 관리번호 SPEC ]이 등록되지 않아 신규신청을 할 수 없어요.\n\n[ 관리번호 SPEC ]을 등록하시겠습니까?
        /// </summary>
        IF_RegisterMntSpec = 40010,
        /// <summary>
        /// 요청 불가 내역이 존재합니다.
        /// </summary>
        IF_NotRequestContents = 40011,
        /// <summary>
        /// [ {0} ] 이(가) 정확하지 않습니다. [ {0} ] 을(를) 확인하세요.
        /// </summary>
        IF_IncorrectCheck = 40012,
        /// <summary>
        /// 최소 1개 이상의 수리값을 입력해야 합니다.
        /// </summary>
        IF_RepairValue = 40013
    }
}
