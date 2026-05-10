
namespace EBAP.Core.Interface
{
    /// <summary>
    /// 이벤트 강제 발생을 설정하는 Interface 입니다.
    /// </summary>
    public interface IRaiseEvent
    {
        /// <summary>
        /// 조회 Event를 강제로 발생시킵니다.
        /// </summary>
        void RaiseSelectEvent();

        /// <summary>
        /// 신규 Event를 강제로 발생시킵니다.
        /// </summary>
        void RaiseNewEvent();

        /// <summary>
        /// Save Event를 강제로 발생시킵니다.
        /// </summary>
        void RaiseSaveEvent();

        /// <summary>
        /// 삭제 Event를 강제로 발생시킵니다.
        /// </summary>
        void RaiseDeleteEvent();
    }
}
