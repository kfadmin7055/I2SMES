using DevExpress.XtraPivotGrid.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBAP.Win.BaseFrame.Localization
{
    /// <summary>
    /// PivotGrid Control Library를 한국어로 설정합니다.
    /// </summary>
    internal class PPivotGridLocalizer : DevExpress.XtraPivotGrid.Localization.PivotGridLocalizer
    {
        /// <summary>
        /// Pivot Grid Control에서 보여지는 Text를 설정합니다.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override string GetLocalizedString(PivotGridStringId id)
        {
            switch (id)
            {
                case PivotGridStringId.Alt_Collapse: return " [축소]";
                case PivotGridStringId.Alt_ColumnAreaHeaders: return " [열 영역 헤더]";
                case PivotGridStringId.Alt_DataAreaHeaders: return " [데이터 영역 헤더]";
                case PivotGridStringId.Alt_DragHideField: return " 숨기기";
                case PivotGridStringId.Alt_Expand: return " [확장]";
                case PivotGridStringId.Alt_FieldListHeaders: return " [숨겨진 필드의 헤더]";
                case PivotGridStringId.Alt_FilterAreaHeaders: return " [필터 영역 헤더]";
                case PivotGridStringId.Alt_FilterButton: return " [필터]";
                case PivotGridStringId.Alt_FilterButtonActive: return " [필터링]";
                case PivotGridStringId.Alt_FilterWindowSizeGrip: return " [크기 조정]";
                case PivotGridStringId.Alt_LayoutButton: return " [레이아웃 버튼]";
                case PivotGridStringId.Alt_RowAreaHeaders: return " [행 영역 헤더]";
                case PivotGridStringId.Alt_SortedAscending: return " (오름차순)";
                case PivotGridStringId.Alt_SortedDescending: return " (내림차순)";
                case PivotGridStringId.Alt_StackedSideBySideLayout: return " [집합 형식 단계별 레이아웃]";
                case PivotGridStringId.Alt_TopPanelOnlyLayout: return " [상단 패널만 레이아웃]";
                case PivotGridStringId.CellError: return " 오류";
                case PivotGridStringId.ColumnArea: return " 열 영역";
                case PivotGridStringId.CustomizationFormAddTo: return " 에 추가";
                case PivotGridStringId.CustomizationFormAvailableFields: return " 보고서에 추가할 필드 선택:";
                case PivotGridStringId.CustomizationFormCaption: return " PivotGrid 필드 목록";
                case PivotGridStringId.CustomizationFormDeferLayoutUpdate: return " 레이아웃 업데이트 연기";
                case PivotGridStringId.CustomizationFormHiddenFields: return " 숨겨진 필드";
                case PivotGridStringId.CustomizationFormHint: return " 아래 영역 간에 필드를 끌어:";
                case PivotGridStringId.CustomizationFormLayoutButtonTooltip: return " 사용자 지정 양식 레이아웃";
                case PivotGridStringId.CustomizationFormText: return " 항목을 피벗 그리드로 드래그 앤 드롭";
                case PivotGridStringId.CustomizationFormTopPanelOnly: return " 필드 섹션만";
                case PivotGridStringId.CustomizationFormUpdate: return " 업데이트";
                case PivotGridStringId.DataArea: return " 데이터 영역";
                case PivotGridStringId.DataFieldCaption: return " 데이터";
                case PivotGridStringId.DataHeadersCustomization: return " 데이터 항목을 여기에 드래그 앤 드롭";
                case PivotGridStringId.DateTimeGroupIntervalDay: return " 일";
                case PivotGridStringId.DateTimeGroupIntervalHour: return " 시간";
                case PivotGridStringId.DateTimeGroupIntervalMonth: return " 달";
                case PivotGridStringId.DateTimeGroupIntervalQuarter: return " 분기";
                case PivotGridStringId.DateTimeGroupIntervalSecond: return " 초";
                case PivotGridStringId.DateTimeGroupIntervalYear: return " 년";
                case PivotGridStringId.EditFilter: return " 필터 편집";
                case PivotGridStringId.EditPrefilter: return " Prefilter 편집";
                case PivotGridStringId.ExpressionEditorFieldsCategory: return " 필드";
                case PivotGridStringId.FilterArea: return " 필터 영역";
                case PivotGridStringId.FilterBlank: return " (공백)";
                case PivotGridStringId.FilterCancel: return " 취소";
                case PivotGridStringId.FilterFormCaption: return " 필터 편집기";
                case PivotGridStringId.FilterHeadersCustomization: return " 필터 필드를 여기에 드래그 앤 드롭";
                case PivotGridStringId.FilterInvert: return " 필터 반전";
                case PivotGridStringId.FilterOk: return " OK";
                case PivotGridStringId.FilterShowAll: return " (모두 보기)";
                case PivotGridStringId.FilterShowBlanks: return " (공백 표시)";
                case PivotGridStringId.FunctionCategoryAdvanced: return " 고급";
                case PivotGridStringId.FunctionCategoryAggregate: return " 집계";
                case PivotGridStringId.FunctionCategoryWindow: return " Window";
                case PivotGridStringId.GrandTotal: return " 총계";
                case PivotGridStringId.OLAPDrillDownFilterException: return " 자세한 정보 표시 명령을 실행할 수 없습니다. 보고서 필터 영역에는 드릴스루를 수행 하기 전에 각 필드에 대 한 단일 항목을 선택 합니다.";
                case PivotGridStringId.OLAPKPITypeGoal: return " 목표";
                case PivotGridStringId.OLAPKPITypeStatus: return " 상태";
                case PivotGridStringId.OLAPKPITypeTrend: return " 동향";
                case PivotGridStringId.OLAPKPITypeValue: return " 값";
                case PivotGridStringId.OLAPKPITypeWeight: return " 무게";
                case PivotGridStringId.OLAPMeasuresCaption: return " 대책";
                case PivotGridStringId.OLAPNoOleDbProvidersMessage: return " PivotGrid OLAP 기능을 사용 하기 위해서는 MS OLAP OleDb 공급자를 시스템에 설치 되어 있어야 합니다. 당신은 여기에서 다운로드할 수 있습니다: ";
                case PivotGridStringId.PopupMenuBestFit: return " 맞춤";
                case PivotGridStringId.PopupMenuCollapse: return " 축소";
                case PivotGridStringId.PopupMenuCollapseAll: return " 모두 축소";
                case PivotGridStringId.PopupMenuExpand: return " 확장";
                case PivotGridStringId.PopupMenuExpandAll: return " 모두 확장";
                case PivotGridStringId.PopupMenuFieldOrder: return " 순서";
                case PivotGridStringId.PopupMenuFormatRules: return " 형식 규칙";
                case PivotGridStringId.PopupMenuFormatRulesColumn: return " 열";
                case PivotGridStringId.PopupMenuFormatRulesRow: return " 행";
                case PivotGridStringId.PopupMenuHideField: return " 숨기기";
                case PivotGridStringId.PopupMenuHideFieldList: return " 필드 목록 숨기기";
                case PivotGridStringId.PopupMenuHidePrefilter: return " Prefilter 숨기기";
                case PivotGridStringId.PopupMenuKPIGraphic: return " KPI 그래픽";
                case PivotGridStringId.PopupMenuKPIGraphicCylinder: return " 원통";
                case PivotGridStringId.PopupMenuKPIGraphicFaces: return " 면";
                case PivotGridStringId.PopupMenuKPIGraphicGauge: return " 게이지";
                case PivotGridStringId.PopupMenuKPIGraphicNone: return " 없음";
                case PivotGridStringId.PopupMenuKPIGraphicReversedCylinder: return " 역방향 원통";
                case PivotGridStringId.PopupMenuKPIGraphicReversedGauge: return " 역방향 게이지";
                case PivotGridStringId.PopupMenuKPIGraphicReversedStatusArrow: return " 역방향 상태 화살표";
                case PivotGridStringId.PopupMenuKPIGraphicReversedThermometer: return " 역방향 온도계";
                case PivotGridStringId.PopupMenuKPIGraphicRoadSigns: return " 교통 표지";
                case PivotGridStringId.PopupMenuKPIGraphicServerDefined: return " 서버 정의";
                case PivotGridStringId.PopupMenuKPIGraphicShapes: return " 도형";
                case PivotGridStringId.PopupMenuKPIGraphicStandardArrow: return " 표준 화살표";
                case PivotGridStringId.PopupMenuKPIGraphicStatusArrow: return " 상태 화살표";
                case PivotGridStringId.PopupMenuKPIGraphicThermometer: return " 온도계";
                case PivotGridStringId.PopupMenuKPIGraphicTrafficLights: return " 신호등";
                case PivotGridStringId.PopupMenuKPIGraphicVarianceArrow: return " 분산 화살표";
                case PivotGridStringId.PopupMenuMovetoBeginning: return " 처음으로 이동";
                case PivotGridStringId.PopupMenuMovetoEnd: return " 끝으로 이동";
                case PivotGridStringId.PopupMenuMovetoLeft: return " 왼쪽으로 이동";
                case PivotGridStringId.PopupMenuMovetoRight: return " 오른쪽으로 이동";
                case PivotGridStringId.PopupMenuRefreshData: return " 데이터 다시 로드";
                case PivotGridStringId.PopupMenuRemoveAllSortByColumn: return " 모든 정렬을 제거";
                case PivotGridStringId.PopupMenuShowFieldList: return " 필드 목록 표시";
                case PivotGridStringId.PopupMenuShowPrefilter: return " Prefilter 표시";
                case PivotGridStringId.PopupMenuSortAscending: return " 오름차순 정렬";
                case PivotGridStringId.PopupMenuSortDescending: return " 내림차순 정렬";
                case PivotGridStringId.PopupMenuSummaryType: return " 요약 유형";
                case PivotGridStringId.PrefilterFormCaption: return " PivotGrid Prefilter";
                case PivotGridStringId.PrefilterInvalidProperty: return " (잘못 된 속성)";
                case PivotGridStringId.PrintDesigner: return " 인쇄 디자이너";
                case PivotGridStringId.PrintDesignerCategoryDefault: return " 기본";
                case PivotGridStringId.PrintDesignerCategoryFieldValues: return " 필드 값";
                case PivotGridStringId.PrintDesignerCategoryHeaders: return " 헤더";
                case PivotGridStringId.PrintDesignerCategoryLines: return " 라인";
                case PivotGridStringId.PrintDesignerColumnHeaders: return " 열 헤더";
                case PivotGridStringId.PrintDesignerDataHeaders: return " 데이터 헤더";
                case PivotGridStringId.PrintDesignerFilterHeaders: return " 필터 헤더";
                case PivotGridStringId.PrintDesignerHeadersOnEveryPage: return " 모든 페이지에 머리글";
                case PivotGridStringId.PrintDesignerHorizontalLines: return " 가로줄";
                case PivotGridStringId.PrintDesignerMergeColumnFieldValues: return " 열 필드 값을 병합";
                case PivotGridStringId.PrintDesignerPageBehavior: return " 동작";
                case PivotGridStringId.PrintDesignerPageOptions: return " 옵션";
                case PivotGridStringId.PrintDesignerRowHeaders: return " 행 헤더";
                case PivotGridStringId.PrintDesignerUnusedFilterFields: return " 미사용 필터 필드";
                case PivotGridStringId.PrintDesignerUsePrintAppearance: return " 인쇄 보기 사용";
                case PivotGridStringId.PrintDesignerVerticalLines: return " 수직 라인";
                case PivotGridStringId.RowArea: return " 행 영역";
                case PivotGridStringId.RowHeadersCustomization: return " 행 필드를 여기에 드래그 앤 드롭";
                case PivotGridStringId.SearchBoxText: return " 검색";
                case PivotGridStringId.StatusBad: return " 나쁜";
                case PivotGridStringId.StatusGood: return " 좋은";
                case PivotGridStringId.StatusNeutral: return " 중립";
                case PivotGridStringId.SummaryAverage: return " 평균";
                case PivotGridStringId.SummaryCount: return " 카운트";
                case PivotGridStringId.SummaryCustom: return " 사용자 지정";
                case PivotGridStringId.SummaryFilterApplyToSpecificLevel: return " 특정 레벨에 적용";
                case PivotGridStringId.SummaryFilterClearButton: return " 지우기";
                case PivotGridStringId.SummaryFilterColumnField: return " 열 필드:";
                case PivotGridStringId.SummaryFilterLabelValues: return " 값";
                case PivotGridStringId.SummaryFilterLegendHidden: return " 숨기기";
                case PivotGridStringId.SummaryFilterLegendVisible: return " 표시";
                case PivotGridStringId.SummaryFilterMaxValueCount: return " 최대 수";
                case PivotGridStringId.SummaryFilterMaxVisibleCount: return " 최대 표시 수";
                case PivotGridStringId.SummaryFilterRangeFrom: return " 값 표시";
                case PivotGridStringId.SummaryFilterRangeTo: return " ~";
                case PivotGridStringId.SummaryFilterRowField: return " 행 필드:";
                case PivotGridStringId.SummaryMax: return " 최대값";
                case PivotGridStringId.SummaryMin: return " 최소값";
                case PivotGridStringId.SummaryStdDev: return " StdDev";
                case PivotGridStringId.SummarySum: return " 합계";
                case PivotGridStringId.SummaryVar: return " Var";
                case PivotGridStringId.SummaryVarp: return " Varp";
                case PivotGridStringId.TopValueOthersRow: return " 기타";
                case PivotGridStringId.Total: return " 소계";
                case PivotGridStringId.TotalFormat: return " {0} Total";
                case PivotGridStringId.TotalFormatAverage: return " {0} 평균";
                case PivotGridStringId.TotalFormatCount: return " {0} 카운트";
                case PivotGridStringId.TotalFormatCustom: return " {0} 사용자 정의";
                case PivotGridStringId.TotalFormatMax: return " {0} 최대";
                case PivotGridStringId.TotalFormatStdDev: return " {0} StdDev";
                case PivotGridStringId.TotalFormatSum: return " {0} 합계";
                case PivotGridStringId.TotalFormatVar: return " {0} Var";
                case PivotGridStringId.TotalFormatVarp: return " {0} Varp";
                case PivotGridStringId.TrendGoingDown: return " 하락";
                case PivotGridStringId.TrendGoingUp: return " 상승";
                case PivotGridStringId.TrendNoChange: return " 변경 사항 없음";
                case PivotGridStringId.ValueError: return " 오류";
                case PivotGridStringId.CustomizationFormBottomPanelOnly2by2: return "영역 구역만 표시( 2 x 2 )";
                case PivotGridStringId.CustomizationFormBottomPanelOnly1by4: return "영역 구역만 표시( 1 x 4 )";
                case PivotGridStringId.CustomizationFormStackedDefault: return "필드 구역과 영역 구역을 위아래로 표시";
                case PivotGridStringId.CustomizationFormStackedSideBySide: return "필드 구역과 영역 구역을 옆으로 표시";
                case PivotGridStringId.CustomizationFormListBoxText: return "추가할 필드 선택";
                case PivotGridStringId.ColumnHeadersCustomization: return "열 항목을 여기에 드래그 앤 드롭";
                case PivotGridStringId.PopupMenuSortFieldByColumn: return "이 열을 기준으로 [ {0} ] 정렬";
                case PivotGridStringId.PopupMenuSortFieldByRow: return "이 행을 기준으로 [ {0} ] 정렬";
            }

            return base.GetLocalizedString(id);
        }
        ///// <summary>
        ///// Pivot Grid Control에서 보여지는 Text를 설정합니다.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public override string GetLocalizedString(PivotGridStringId id)
        //{
        //    switch (id)
        //    {
        //        case PivotGridStringId.CustomizationFormLayoutButtonTooltip:
        //            return "레이아웃 변경";
        //        case PivotGridStringId.CustomizationFormText:
        //            return "추가할 필드를 선택하세요.";
        //        case PivotGridStringId.CustomizationFormCaption:
        //            return "피벗 테이블 필드";
        //        case PivotGridStringId.CustomizationFormBottomPanelOnly2by2:
        //            return "영역 구역만 표시( 2 x 2 )";
        //        case PivotGridStringId.CustomizationFormBottomPanelOnly1by4:
        //            return "영역 구역만 표시( 1 x 4 )";
        //        case PivotGridStringId.CustomizationFormStackedDefault:
        //            return "필드 구역과 영역 구역을 위아래로 표시";
        //        case PivotGridStringId.CustomizationFormStackedSideBySide:
        //            return "필드 구역과 영역 구역을 옆으로 표시";
        //        case PivotGridStringId.CustomizationFormTopPanelOnly:
        //            return "필드 구역만 표시";
        //        case PivotGridStringId.DataArea:
        //            return "값";
        //        case PivotGridStringId.FilterArea:
        //            return "필터";
        //        case PivotGridStringId.RowArea:
        //            return "행";
        //        case PivotGridStringId.ColumnArea:
        //            return "열";
        //        case PivotGridStringId.CustomizationFormUpdate:
        //            return "업데이트";
        //        case PivotGridStringId.CustomizationFormDeferLayoutUpdate:
        //            return "나중에 레이아웃 업데이트";
        //        case PivotGridStringId.CustomizationFormListBoxText:
        //            return "추가할 필드 선택";
        //        case PivotGridStringId.CustomizationFormHint:
        //            return "아래 영역 사이에 필드를 끌어 놓으세요.";
        //        case PivotGridStringId.DataHeadersCustomization:
        //            return "Data Field를 이 공간으로 끌어 놓으세요.";
        //        case PivotGridStringId.FilterHeadersCustomization:
        //            return "Filter Field를 이 공간으로 끌어 놓으세요.";
        //        case PivotGridStringId.RowHeadersCustomization:
        //            return "Row Field를 이 공간으로 끌어 놓으세요.";
        //        case PivotGridStringId.ColumnHeadersCustomization:
        //            return "Column Field를 이 공간으로 끌어 놓으세요.";
        //        case PivotGridStringId.PopupMenuSortFieldByColumn:
        //            return "이 열을 기준으로 [ {0} ] 정렬";
        //        case PivotGridStringId.PopupMenuSortFieldByRow:
        //            return "이 행을 기준으로 [ {0} ] 정렬";
        //        //case PivotGridStringId.PopupMenuBestFit:
        //        //    return "최적너비";
        //        case PivotGridStringId.PopupMenuRefreshData:
        //            return "새로 고침";
        //        case PivotGridStringId.PopupMenuShowPrefilter:
        //            return "필터링 편집";
        //        case PivotGridStringId.PopupMenuCollapse:
        //            return "축소";
        //        case PivotGridStringId.PopupMenuCollapseAll:
        //            return "전체 축소";
        //        case PivotGridStringId.PopupMenuExpand:
        //            return "확장";
        //        case PivotGridStringId.PopupMenuBestFit:
        //            return "최적너비";
        //        case PivotGridStringId.PopupMenuExpandAll:
        //            return "전체 확장";
        //        case PivotGridStringId.PopupMenuShowFieldList:
        //            return "필드 리스트 보임";
        //        case PivotGridStringId.PopupMenuHideFieldList:
        //            return "필드 리스트 숨김";
        //        case PivotGridStringId.PopupMenuHideField:
        //            return "숨김";
        //        case PivotGridStringId.PopupMenuRemoveAllSortByColumn:
        //            return "모든 정렬 초기화";
        //        case PivotGridStringId.PopupMenuFieldOrder:
        //            return "정렬";
        //        case PivotGridStringId.PopupMenuClearSorting:
        //            return "정렬 초기화";
        //        case PivotGridStringId.PopupMenuMovetoBeginning:
        //            return "처음으로 이동";
        //        case PivotGridStringId.PopupMenuMovetoEnd:
        //            return "끝으로 이동";
        //        case PivotGridStringId.PopupMenuMovetoLeft:
        //            return "왼쪽으로 이동";
        //        case PivotGridStringId.PopupMenuMovetoRight:
        //            return "오른쪽으로 이동";
        //        case PivotGridStringId.GrandTotal:
        //            return "총계";
        //        case PivotGridStringId.Total:
        //            return "소계";
        //    }

        //    return base.GetLocalizedString(id);
        //}
    }
}
