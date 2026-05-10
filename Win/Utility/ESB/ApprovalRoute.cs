namespace EBAP.Win.Utility
{
    /// <summary>
    /// 결재 라인 지정
    /// </summary>
    public class ApprovalRoute
    {
        /// <summary>
        /// 요청자
        /// </summary>
        public string requesterID { get; set; }
        /// <summary>
        /// 결재 경로 구분
        /// 0 : 기안, 1 : 결재, 2 : 합의, 9 : 통보
        /// </summary>
        public string AppType { get; set; }
        /// <summary>
        /// 결재자 순서
        /// </summary>
        public int AppSeq { get; set; }
    }
}
