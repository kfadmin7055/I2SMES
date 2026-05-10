using DevExpress.XtraGrid.Localization;
using DevExpress.XtraTreeList.Localization;

namespace EBAP.Win.BaseFrame.Localization
{
    /// <summary>
    /// TreeList Control Library를 한국어로 설정합니다.
    /// </summary>
    internal class PTreeListLocalizer : DevExpress.XtraTreeList.Localization.TreeListLocalizer
    {
        /// <summary>
        /// TreeList Control에서 보여지는 Text를 설정합니다.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override string GetLocalizedString(TreeListStringId id)
        {
            switch (id)
            {
                case TreeListStringId.ColumnCustomizationText: return " 사용자 지정";
                case TreeListStringId.CustomizationBands: return " 밴드";
                case TreeListStringId.CustomizationColumns: return " 열";
                case TreeListStringId.CustomizationFormColumnHint: return " 레이아웃을 사용자 정의하기 위해 열을 여기로 끌어서 놓기";
                case TreeListStringId.EditFormCancelButton: return " 취소";
                case TreeListStringId.EditFormUpdateButton: return " 업데이트";
                case TreeListStringId.FilterEditorApplyButton: return " 적용(&A)";
                case TreeListStringId.FilterEditorCancelButton: return " 취소";
                case TreeListStringId.FilterEditorCaption: return " 필터 편집기";
                case TreeListStringId.FilterEditorOkButton: return " 확인(&O)";
                case TreeListStringId.FilterPanelCustomizeButton: return " 필터 편집";
                case TreeListStringId.FindControlClearButton: return " 지우기";
                case TreeListStringId.FindControlFindButton: return " 찾기";
                case TreeListStringId.FindControlNextButton: return " 다음";
                case TreeListStringId.FindControlPrevButton: return " 이전";
                case TreeListStringId.FindNullPrompt: return " 검색 텍스트를 입력...";
                case TreeListStringId.InvalidNodeExceptionText: return " 값을 수정 하 시겠습니까?";
                case TreeListStringId.MenuColumnAutoFilterRowHide: return " 자동 필터 행 숨기기";
                case TreeListStringId.MenuColumnAutoFilterRowShow: return " 자동 필터 행 표시";
                case TreeListStringId.MenuColumnBestFit: return " 맞춤";
                case TreeListStringId.MenuColumnBestFitAllColumns: return " 맞춤 (모든 열)";
                case TreeListStringId.MenuColumnClearFilter: return " 필터 지우기";
                case TreeListStringId.MenuColumnClearSorting: return " 정렬 지우기";
                case TreeListStringId.MenuColumnColumnCustomization: return " 열 선택";
                case TreeListStringId.MenuColumnConditionalFormatting: return " 조건부 서식";
                case TreeListStringId.MenuColumnFilterEditor: return " 필터 편집기...";
                case TreeListStringId.MenuColumnFindFilterHide: return " [찾기] 패널 숨기기";
                case TreeListStringId.MenuColumnFindFilterShow: return " [찾기] 패널 표시";
                case TreeListStringId.MenuColumnFooterHide: return " 바닥글 숨기기";
                case TreeListStringId.MenuColumnFooterShow: return " 바닥글 표시";
                case TreeListStringId.MenuColumnSortAscending: return " 오름차순 정렬";
                case TreeListStringId.MenuColumnSortDescending: return " 내림차순";
                case TreeListStringId.MenuFooterAllNodes: return " 모든 노드";
                case TreeListStringId.MenuFooterAverage: return " 평균";
                case TreeListStringId.MenuFooterAverageFormat: return " AVG={0:#.##}";
                case TreeListStringId.MenuFooterCount: return " 카운트";
                case TreeListStringId.MenuFooterCountFormat: return " {0}";
                case TreeListStringId.MenuFooterMax: return " 최대값";
                case TreeListStringId.MenuFooterMaxFormat: return " 최대 = {0}";
                case TreeListStringId.MenuFooterMin: return " 최소값";
                case TreeListStringId.MenuFooterMinFormat: return " 최소 = {0}";
                case TreeListStringId.MenuFooterNone: return " 없음";
                case TreeListStringId.MenuFooterSum: return " 합계";
                case TreeListStringId.MenuFooterSumFormat: return " 합계={0:#.##}";
                case TreeListStringId.MenuNodeCollapse: return " 축소";
                case TreeListStringId.MenuNodeExpand: return " 확장";
                case TreeListStringId.MultiSelectMethodNotSupported: return " OptionsBehavior.MultiSelect 활성화 되지 않은 경우 지정 된 메서드가 작동 하지 것입니다.";
                case TreeListStringId.PopupFilterAll: return " (모두)";
                case TreeListStringId.PopupFilterBlanks: return " (공백)";
                case TreeListStringId.PopupFilterNonBlanks: return " (비 공백)";
                case TreeListStringId.PreviewColumnLocationName: return " 위치";
                case TreeListStringId.PrintDesignerDescription: return " 현재 treelist에 대 한 다양 한 인쇄 옵션을 설정 합니다.";
                case TreeListStringId.PrintDesignerHeader: return " 인쇄 설정";
                case TreeListStringId.SearchForBand: return " 밴드 검색...";
                case TreeListStringId.WindowErrorCaption: return " 오류";
                case TreeListStringId.MenuNodeExpandAll: return " 모두 확장";
                case TreeListStringId.MenuNodeCollapseAll: return " 모두 축소";
            }
            return base.GetLocalizedString(id);
        }
        ///// <summary>
        ///// TreeList Control에서 보여지는 Text를 설정합니다.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public override string GetLocalizedString(TreeListStringId id)
        //{
        //    switch (id)
        //    {
        //        case TreeListStringId.FindNullPrompt:
        //            return "검색할 내용을 입력하세요.";
        //        case TreeListStringId.FindControlFindButton:
        //            return "찾기";
        //        case TreeListStringId.FindControlNextButton:
        //            return "다음";
        //        case TreeListStringId.FindControlPrevButton:
        //            return "이전";
        //        case TreeListStringId.FindControlClearButton:
        //            return "초기화";
        //        case TreeListStringId.MenuNodeExpand:
        //            return "펼침";
        //        case TreeListStringId.MenuNodeExpandAll:
        //            return "모두 펼침";
        //        case TreeListStringId.MenuNodeCollapse:
        //            return "접기";
        //        case TreeListStringId.MenuNodeCollapseAll:
        //            return "모두 접기";
        //        case TreeListStringId.ColumnCustomizationText:
        //            return "컬럼 사용자지정";
        //        case TreeListStringId.MenuColumnBestFit:
        //            return "최적너비";
        //        case TreeListStringId.MenuColumnBestFitAllColumns:
        //            return "최적너비(전체 컬럼)";
        //        case TreeListStringId.MenuColumnSortAscending:
        //            return "오름차순 정렬";
        //        case TreeListStringId.MenuColumnSortDescending:
        //            return "내림차순 정렬";
        //        case TreeListStringId.MenuColumnClearSorting:
        //            return "정렬 초기화";
        //        case TreeListStringId.MenuColumnColumnCustomization:
        //            return "컬럼 사용자지정";
        //        case TreeListStringId.MenuColumnFindFilterShow:
        //            return "필터 PANEL 보임";
        //        case TreeListStringId.MenuColumnFindFilterHide:
        //            return "필터 PANEL 숨김";
        //        case TreeListStringId.MenuColumnAutoFilterRowShow:
        //            return "자동 필터링 보임";
        //        case TreeListStringId.MenuColumnAutoFilterRowHide:
        //            return "자동 필터링 숨김";
        //        case TreeListStringId.MenuColumnFilterEditor:
        //            return "필터링 편집";
        //    }
        //    return base.GetLocalizedString(id);
        //}
    }
}
