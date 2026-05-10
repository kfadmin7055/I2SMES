using DevExpress.XtraGrid.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBAP.Win.BaseFrame.Localization
{
    /// <summary>
    /// Grid Control Library를 한국어로 설정합니다.
    /// </summary>
    internal class PGridLocalizer : DevExpress.XtraGrid.Localization.GridLocalizer
    {
        /// <summary>
        /// Grid Control에서 보여지는 Text를 설정합니다.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override string GetLocalizedString(GridStringId id)
        {
            switch (id)
            {
                case GridStringId.CardViewCaptionFormat: return " 레코드 N {0}";
                case GridStringId.CardViewNewCard: return " 새로운 카드";
                case GridStringId.CardViewQuickCustomizationButton: return " 사용자 지정";
                case GridStringId.CardViewQuickCustomizationButtonFilter: return " 필터";
                case GridStringId.CardViewQuickCustomizationButtonSort: return " 정렬:";
                case GridStringId.CheckboxSelectorColumnCaption: return " 선택";
                case GridStringId.ColumnViewExceptionMessage: return " 값을 수정 하 시겠습니까?";
                case GridStringId.CustomFilterDialog2FieldCheck: return " 필드";
                case GridStringId.CustomFilterDialogCancelButton: return " 취소";
                case GridStringId.CustomFilterDialogCaption: return " 행 위치:";
                case GridStringId.CustomFilterDialogClearFilter: return " 필터 삭제 (&L)";
                case GridStringId.CustomFilterDialogEmptyOperator: return " (선택 연산자)";
                case GridStringId.CustomFilterDialogEmptyValue: return " (입력 값)";
                case GridStringId.CustomFilterDialogFormCaption: return " 사용자 지정 자동 필터";
                case GridStringId.CustomFilterDialogOkButton: return " 확인(&O)";
                case GridStringId.CustomFilterDialogRadioAnd: return " &And";
                case GridStringId.CustomFilterDialogRadioOr: return " Or (&R)";
                case GridStringId.CustomizationBands: return " 밴드";
                case GridStringId.CustomizationCaption: return " 사용자 지정";
                case GridStringId.CustomizationColumns: return " 열";
                case GridStringId.CustomizationFormBandHint: return " 끌어서 밴드 여기 레이아웃 사용자 지정";
                case GridStringId.CustomizationFormColumnHint: return " 레이아웃을 사용자 정의하기 위해 열을 여기로 끌어서 놓기";
                case GridStringId.EditFormCancelButton: return " 취소";
                case GridStringId.EditFormCancelMessage: return " 편집을 취소 하시겠습니까?";
                case GridStringId.EditFormUpdateButton: return " 업데이트";
                case GridStringId.FileIsNotFoundError: return " 파일 ({0})를 찾을 수 없습니다";
                case GridStringId.FilterBuilderApplyButton: return " 적용(&A)";
                case GridStringId.FilterBuilderCancelButton: return " 취소(&C)";
                case GridStringId.FilterBuilderCaption: return " 필터 편집기";
                case GridStringId.FilterBuilderOkButton: return " 확인(&O)";
                case GridStringId.FilterPanelCustomizeButton: return " 필터 편집";
                case GridStringId.FindControlClearButton: return " 지우기";
                case GridStringId.FindControlFindButton: return " 찾기";
                case GridStringId.FindControlNextButton: return " 다음";
                case GridStringId.FindControlPrevButton: return " 이전";
                case GridStringId.GridGroupPanelText: return " 그룹화 할 열 머리글을 여기로 끌어옵니다.";
                case GridStringId.GridNewRowText: return " 새 행을 추가 하려면 여기를 클릭 하십시오.";
                case GridStringId.GroupSummaryEditorFormCancelButton: return " 취소";
                case GridStringId.GroupSummaryEditorFormCaption: return " 그룹 요약 편집기";
                case GridStringId.GroupSummaryEditorFormItemsTabCaption: return " 항목";
                case GridStringId.GroupSummaryEditorFormOkButton: return " 확인";
                case GridStringId.GroupSummaryEditorFormOrderTabCaption: return " 순서";
                case GridStringId.GroupSummaryEditorSummaryAverage: return " 평균";
                case GridStringId.GroupSummaryEditorSummaryCount: return " 카운트";
                case GridStringId.GroupSummaryEditorSummaryMax: return " 최대값";
                case GridStringId.GroupSummaryEditorSummaryMin: return " 최소값";
                case GridStringId.GroupSummaryEditorSummarySum: return " 합계";
                case GridStringId.LayoutModifiedWarning: return "레이아웃 수정 되었습니다. 변경 내용을 저장 하시겠습니까?";
                case GridStringId.LayoutViewButtonApply: return " 적용(&A)";
                case GridStringId.LayoutViewButtonCancel: return " 취소(&C)";
                case GridStringId.LayoutViewButtonCustomizeHide: return " 사용자 지정 숨기기 (&Z)";
                case GridStringId.LayoutViewButtonCustomizeShow: return " 사용자 지정 표시 (&S)";
                case GridStringId.LayoutViewButtonLoadLayout: return " 레이아웃 불러오기...(&L)";
                case GridStringId.LayoutViewButtonOk: return " 확인(&O)";
                case GridStringId.LayoutViewButtonSaveLayout: return " 레이아웃 저장...(&V)";
                case GridStringId.LayoutViewButtonShrinkToMinimum: return " 템플릿 카드 축소(&S)";
                case GridStringId.LayoutViewCardCaptionFormat: return " 레코드 [{0} / {1}]";
                case GridStringId.LayoutViewCarouselModeBtnHint: return " 회전 목마 모드";
                case GridStringId.LayoutViewCloseZoomBtnHintClose: return " 보기 복원";
                case GridStringId.LayoutViewCloseZoomBtnHintZoom: return " 세부를 극대화";
                case GridStringId.LayoutViewColumnModeBtnHint: return " 한 열";
                case GridStringId.LayoutViewCustomizationFormCaption: return " LayoutView 사용자 지정";
                case GridStringId.LayoutViewCustomizationFormDescription: return " 드래그 앤 드롭 및 사용자 지정 메뉴를 사용 하 여 카드 레이아웃을 사용자 지정 하 고 보기 레이아웃 페이지에서 데이터를 미리 합니다.";
                case GridStringId.LayoutViewCustomizeBtnHint: return " 사용자 지정";
                case GridStringId.LayoutViewFieldCaptionFormat: return " {0}:";
                case GridStringId.LayoutViewFormLoadLayoutCaption: return " 레이아웃 로드";
                case GridStringId.LayoutViewFormSaveLayoutCaption: return " 레이아웃 저장";
                case GridStringId.LayoutViewGroupCaptions: return " 캡션";
                case GridStringId.LayoutViewGroupCards: return " 카드";
                case GridStringId.LayoutViewGroupCustomization: return " 사용자 지정";
                case GridStringId.LayoutViewGroupFields: return " 필드";
                case GridStringId.LayoutViewGroupHiddenItems: return " 숨겨진 항목";
                case GridStringId.LayoutViewGroupIndents: return " 들여쓰기";
                case GridStringId.LayoutViewGroupIntervals: return " 간격";
                case GridStringId.LayoutViewGroupLayout: return " 레이아웃";
                case GridStringId.LayoutViewGroupPropertyGrid: return " 속성 표";
                case GridStringId.LayoutViewGroupTreeStructure: return " 레이아웃 트리 보기";
                case GridStringId.LayoutViewGroupView: return " 보기";
                case GridStringId.LayoutViewLabelAllowFieldHotTracking: return " 핫 트래킹 허용";
                case GridStringId.LayoutViewLabelCaptionLocation: return " 필드 캡션 위치:";
                case GridStringId.LayoutViewLabelCardArrangeRule: return " 규칙 배열:";
                case GridStringId.LayoutViewLabelCardEdgeAlignment: return " 카드 모서리 맞춤:";
                case GridStringId.LayoutViewLabelGroupCaptionLocation: return " 그룹 캡션 위치:";
                case GridStringId.LayoutViewLabelHorizontal: return " 가로 간격";
                case GridStringId.LayoutViewLabelPadding: return " 패딩";
                case GridStringId.LayoutViewLabelScrollVisibility: return " 스크롤 표시:";
                case GridStringId.LayoutViewLabelShowCardBorder: return " 테두리 표시";
                case GridStringId.LayoutViewLabelShowCardCaption: return " 캡션 표시";
                case GridStringId.LayoutViewLabelShowFieldBorder: return " 테두리 표시";
                case GridStringId.LayoutViewLabelShowFieldHint: return " 힌트 보기";
                case GridStringId.LayoutViewLabelShowFilterPanel: return " [필터] 패널 표시:";
                case GridStringId.LayoutViewLabelShowHeaderPanel: return " 헤더 패널 표시";
                case GridStringId.LayoutViewLabelShowLines: return " 라인 표시";
                case GridStringId.LayoutViewLabelSpacing: return " 간격";
                case GridStringId.LayoutViewLabelTextAlignment: return " 필드 캡션 텍스트 맞춤:";
                case GridStringId.LayoutViewLabelTextIndent: return " 텍스트 들여쓰기";
                case GridStringId.LayoutViewLabelVertical: return " 세로 간격";
                case GridStringId.LayoutViewLabelViewMode: return " 보기 모드:";
                case GridStringId.LayoutViewMultiColumnModeBtnHint: return " 여러 열";
                case GridStringId.LayoutViewMultiRowModeBtnHint: return " 여러 행";
                case GridStringId.LayoutViewPageTemplateCard: return " 템플릿 카드";
                case GridStringId.LayoutViewPageViewLayout: return " 뷰 레이아웃";
                case GridStringId.LayoutViewPanBtnHint: return " 패닝";
                case GridStringId.LayoutViewRowModeBtnHint: return " 한 행";
                case GridStringId.LayoutViewSingleModeBtnHint: return " 1 카드 표시";
                case GridStringId.MenuColumnAutoFilterRowHide: return " 자동 필터 행 숨기기";
                case GridStringId.MenuColumnAutoFilterRowShow: return " 자동 필터 행 표시";
                case GridStringId.MenuColumnAverageSummaryTypeDescription: return " 평균";
                case GridStringId.MenuColumnBandCustomization: return " 열/밴드 선택";
                case GridStringId.MenuColumnBestFit: return " 맞춤";
                case GridStringId.MenuColumnBestFitAllColumns: return " 맞춤 (모든 열)";
                case GridStringId.MenuColumnClearAllSorting: return " 모든 정렬 지우기";
                case GridStringId.MenuColumnClearFilter: return " 필터 지우기";
                case GridStringId.MenuColumnClearSorting: return " 정렬 지우기";
                case GridStringId.MenuColumnColumnCustomization: return " 열 선택";
                case GridStringId.MenuColumnCountSummaryTypeDescription: return " 카운트";
                case GridStringId.MenuColumnCustomSummaryTypeDescription: return " 사용자 지정";
                case GridStringId.MenuColumnExpressionEditor: return " 식 편집기...";
                case GridStringId.MenuColumnFilter: return " 필터링 할 수 있습니다";
                case GridStringId.MenuColumnFilterEditor: return " 필터 편집기...";
                case GridStringId.MenuColumnFilterMode: return " 필터 모드";
                case GridStringId.MenuColumnFilterModeDisplayText: return " 표시 텍스트";
                case GridStringId.MenuColumnFilterModeValue: return " 값";
                case GridStringId.MenuColumnFindFilterHide: return " 찾기 패널 숨기기";
                case GridStringId.MenuColumnFindFilterShow: return " [찾기] 패널 표시";
                case GridStringId.MenuColumnGroup: return " 이 열으로 그룹";
                case GridStringId.MenuColumnGroupBox: return " 그룹 상자";
                case GridStringId.MenuColumnGroupIntervalDay: return " 일";
                case GridStringId.MenuColumnGroupIntervalMenu: return " 그룹 간격";
                case GridStringId.MenuColumnGroupIntervalMonth: return " 달";
                case GridStringId.MenuColumnGroupIntervalNone: return " 없음";
                case GridStringId.MenuColumnGroupIntervalSmart: return " 스마트";
                case GridStringId.MenuColumnGroupIntervalYear: return " 년";
                case GridStringId.MenuColumnGroupSummaryEditor: return " 그룹 요약 편집기...";
                case GridStringId.MenuColumnGroupSummarySortFormat: return " '{0}'-{2}에서 {1}";
                case GridStringId.MenuColumnMaxSummaryTypeDescription: return " 맥스";
                case GridStringId.MenuColumnMinSummaryTypeDescription: return " 분";
                case GridStringId.MenuColumnRemoveColumn: return " 이 열 제거";
                case GridStringId.MenuColumnResetGroupSummarySort: return " 요약 정렬 지우기";
                case GridStringId.MenuColumnShowColumn: return " 이 열 표시";
                case GridStringId.MenuColumnSortAscending: return " 오름차순 정렬";
                case GridStringId.MenuColumnSortDescending: return " 내림차순 정렬";
                case GridStringId.MenuColumnSortGroupBySummaryMenu: return " 요약으로 정렬";
                case GridStringId.MenuColumnSumSummaryTypeDescription: return " 합계";
                case GridStringId.MenuColumnUnGroup: return " 그룹 해제";
                case GridStringId.MenuFooterAddSummaryItem: return " 새로운 요약 추가";
                case GridStringId.MenuFooterAverage: return " 평균";
                case GridStringId.MenuFooterAverageFormat: return " 평균 = {0:0. # #}";
                case GridStringId.MenuFooterClearSummaryItems: return " 요약 항목 지우기";
                case GridStringId.MenuFooterCount: return " 갯수";
                case GridStringId.MenuFooterCountFormat: return " {0}";
                case GridStringId.MenuFooterCountGroupFormat: return " 갯수 = {0}";
                case GridStringId.MenuFooterCustomFormat: return " 사용자 정의 {0} =";
                case GridStringId.MenuFooterMax: return " 최대값";
                case GridStringId.MenuFooterMaxFormat: return " 최대값 = {0}";
                case GridStringId.MenuFooterMin: return " 최소값";
                case GridStringId.MenuFooterMinFormat: return " 최소값 = {0}";
                case GridStringId.MenuFooterNone: return " 없음";
                case GridStringId.MenuFooterSelection: return " 선택";
                case GridStringId.MenuFooterSum: return " 합계";
                case GridStringId.MenuFooterSumFormat: return " SUM = {0:0. # #}";
                case GridStringId.MenuGroupPanelClearGrouping: return " 그룹화 지우기";
                case GridStringId.MenuGroupPanelFullCollapse: return " 모두 축소";
                case GridStringId.MenuGroupPanelFullExpand: return " 모두 확장";
                case GridStringId.MenuGroupPanelHide: return " 그룹 상자 숨기기";
                case GridStringId.MenuGroupPanelShow: return " 그룹 상자 표시";
                case GridStringId.MenuGroupRowCollapse: return " 축소";
                case GridStringId.MenuGroupRowExpand: return " 확장";
                case GridStringId.MenuHideSplitItem: return " 분할 해제";
                case GridStringId.MenuShowSplitItem: return " 분할";
                case GridStringId.PopupFilterAll: return " (모두)";
                case GridStringId.PopupFilterBlanks: return " (공백)";
                case GridStringId.PopupFilterCustom: return " (사용자 지정)";
                case GridStringId.PopupFilterNonBlanks: return " (비 공백)";
                case GridStringId.PrintDesignerBandedView: return " 인쇄 설정 (밴드 뷰)";
                case GridStringId.PrintDesignerBandHeader: return " 밴드 헤더";
                case GridStringId.PrintDesignerCardView: return " 인쇄 설정 (카드 뷰)";
                case GridStringId.PrintDesignerGridView: return " 인쇄 설정 (그리드 뷰)";
                case GridStringId.PrintDesignerLayoutView: return " 인쇄 설정 (레이아웃 보기)";
                case GridStringId.SearchLookUpAddNewButton: return " 새로 추가";
                case GridStringId.SearchLookUpMissingRows: return " 모든 행을 표시 하려면 ENTER 키를 누르거나 찾기를 클릭 합니다. 행을 검색 하려면, 검색 문자열을 입력 하 고 ENTER 키를 누르거나 찾기를 클릭 합니다.";
                case GridStringId.ServerRequestError: return " 서버 요청 ({0}...)을 처리 하는 동안 오류가 발생 했습니다";
                case GridStringId.WindowErrorCaption: return " 오류";
                case GridStringId.WindowWarningCaption: return " 경고";
                case GridStringId.FindNullPrompt: return " 검색할 내용을 입력하세요.";
            }
            return base.GetLocalizedString(id);
        }

        ///// <summary>
        ///// Grid Control에서 보여지는 Text를 설정합니다.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public override string GetLocalizedString(GridStringId id)
        //{
        //    switch (id)
        //    {
        //        case GridStringId.FindNullPrompt:
        //            return "검색할 내용을 입력하세요.";
        //        case GridStringId.MenuColumnBestFit:
        //            return "최적너비";
        //        case GridStringId.MenuColumnBestFitAllColumns:
        //            return "최적너비(전체 컬럼)";
        //        case GridStringId.MenuColumnClearFilter:
        //            return "필터링 초기화";
        //        case GridStringId.MenuColumnClearSorting:
        //            return "정렬 초기화";
        //        case GridStringId.MenuColumnColumnCustomization:
        //            return "컬럼 사용자지정";
        //        case GridStringId.MenuColumnBandCustomization:
        //            return "컬럼/밴드 사용자지정";
        //        case GridStringId.MenuColumnFilter:
        //            return "필터링";
        //        case GridStringId.FindControlNextButton:
        //            return "다음";
        //        case GridStringId.FindControlPrevButton:
        //            return "이전";
        //        case GridStringId.MenuFooterAddSummaryItem:
        //            return "합계 추가";
        //        case GridStringId.MenuColumnFilterEditor:
        //            return "필터링 편집";
        //        case GridStringId.MenuColumnGroup:
        //            return "그룹 지정";
        //        case GridStringId.MenuColumnGroupSummaryEditor:
        //            return "그룹 소계 편집...";
        //        case GridStringId.MenuColumnGroupBox:
        //            return "그룹박스 사용";
        //        case GridStringId.MenuColumnRemoveColumn:
        //            return "컬럼 제거";
        //        case GridStringId.MenuColumnSortAscending:
        //            return "오름차순 정렬";
        //        case GridStringId.MenuColumnSortDescending:
        //            return "내림차순 정렬";
        //        case GridStringId.MenuColumnClearAllSorting:
        //            return "모든 정렬 초기화";
        //        case GridStringId.MenuColumnSortGroupBySummaryMenu:
        //            return "그룹 소계로 정렬 지정";
        //        case GridStringId.MenuColumnUnGroup:
        //            return "그룹 지정 제거";
        //        case GridStringId.MenuColumnGroupIntervalMenu:
        //            return "그룹 간격 지정";
        //        case GridStringId.MenuColumnGroupIntervalDay:
        //            return "일";
        //        case GridStringId.MenuColumnGroupIntervalMonth:
        //            return "월";
        //        case GridStringId.MenuColumnGroupIntervalYear:
        //            return "년";
        //        case GridStringId.MenuColumnGroupIntervalSmart:
        //            return "알파고";
        //        case GridStringId.MenuGroupPanelFullCollapse:
        //            return "전체 접기";
        //        case GridStringId.MenuGroupPanelFullExpand:
        //            return "전체 펼침";
        //        case GridStringId.MenuGroupPanelClearGrouping:
        //            return "그룹 지정 초기화";
        //        case GridStringId.MenuGroupPanelHide:
        //            return "그룹 PANEL 숨김";
        //        case GridStringId.MenuGroupPanelShow:
        //            return "그룹 PANEL 보임";
        //        case GridStringId.GroupSummaryEditorFormCancelButton:
        //            return "취소";
        //        case GridStringId.GroupSummaryEditorFormCaption:
        //            return "그룹 소계 편집";
        //        case GridStringId.GroupSummaryEditorFormOkButton:
        //            return "확인";
        //        case GridStringId.GroupSummaryEditorFormOrderTabCaption:
        //            return "정렬";
        //        case GridStringId.GroupSummaryEditorFormItemsTabCaption:
        //            return "컬럼";
        //        case GridStringId.GroupSummaryEditorSummaryAverage:
        //            return "평균";
        //        case GridStringId.GroupSummaryEditorSummaryCount:
        //            return "갯수";
        //        case GridStringId.GroupSummaryEditorSummaryMax:
        //            return "최대값";
        //        case GridStringId.GroupSummaryEditorSummaryMin:
        //            return "최소값";
        //        case GridStringId.GroupSummaryEditorSummarySum:
        //            return "합계";
        //        case GridStringId.FindControlFindButton:
        //            return "필터링";
        //        case GridStringId.FindControlClearButton:
        //            return "초기화";
        //        case GridStringId.MenuColumnFindFilterShow:
        //            return "필터 PANEL 보임";
        //        case GridStringId.MenuColumnFindFilterHide:
        //            return "필터 PANEL 숨김";
        //        case GridStringId.MenuColumnAutoFilterRowShow:
        //            return "자동 필터링 보임";
        //        case GridStringId.MenuColumnAutoFilterRowHide:
        //            return "자동 필터링 숨김";
        //        case GridStringId.MenuColumnFilterMode:
        //            return "필터 모드";
        //        case GridStringId.MenuColumnFilterModeValue:
        //            return "값";
        //        case GridStringId.MenuColumnFilterModeDisplayText:
        //            return "텍스트";
        //        case GridStringId.GridNewRowText:
        //            return "새로운 ROW를 추가합니다.";
        //        case GridStringId.GridGroupPanelText:
        //            return "그룹으로 지정할 컬럼을 이 공간으로 끌어 놓으세요";
        //    }
        //    return base.GetLocalizedString(id);
        //}
    }
}
