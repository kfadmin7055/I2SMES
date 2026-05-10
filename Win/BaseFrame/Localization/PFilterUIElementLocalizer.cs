using DevExpress.Utils.Filtering.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EBAP.Win.BaseFrame.Localization
{
    /// <summary>
    /// Filter UI Element Library를 한국어로 설정합니다.
    /// </summary>
    internal class PFilterUIElementLocalizer : DevExpress.Utils.Filtering.Internal.FilterUIElementLocalizer
    {
        /// <summary>
        /// Filter UI Element 에서 보여지는 Text를 설정합니다.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override string GetLocalizedString(FilterUIElementLocalizerStringId id)
        {
            switch(id)
            {
                case FilterUIElementLocalizerStringId.CustomUIFilterAboveAverageDescription: return " 평균 이상의 값";
                case FilterUIElementLocalizerStringId.CustomUIFilterAboveAverageName: return " 평균 이상";
                case FilterUIElementLocalizerStringId.CustomUIFilterAfterDescription: return " 날짜 이후";
                case FilterUIElementLocalizerStringId.CustomUIFilterAfterName: return " 후";
                case FilterUIElementLocalizerStringId.CustomUIFilterAllDatesInThePeriodDescription: return " 날짜 범위 내에서";
                case FilterUIElementLocalizerStringId.CustomUIFilterAllDatesInThePeriodName: return " 기간에 모든 날짜";
                case FilterUIElementLocalizerStringId.CustomUIFilterAprilDescription: return " 4 월";
                case FilterUIElementLocalizerStringId.CustomUIFilterAprilName: return " 4 월";
                case FilterUIElementLocalizerStringId.CustomUIFilterAugustDescription: return " 8 월";
                case FilterUIElementLocalizerStringId.CustomUIFilterAugustName: return " 8 월";
                case FilterUIElementLocalizerStringId.CustomUIFilterBeforeDescription: return " 사전에 날짜";
                case FilterUIElementLocalizerStringId.CustomUIFilterBeforeName: return " 전에";
                case FilterUIElementLocalizerStringId.CustomUIFilterBeginsWithDescription: return " 특정 텍스트와 함께 시작";
                case FilterUIElementLocalizerStringId.CustomUIFilterBeginsWithName: return " 로 시작";
                case FilterUIElementLocalizerStringId.CustomUIFilterBelowAverageDescription: return " 평균 값";
                case FilterUIElementLocalizerStringId.CustomUIFilterBetweenDescription: return " 범위 내의 값";
                case FilterUIElementLocalizerStringId.CustomUIFilterBetweenName: return " 사이";
                case FilterUIElementLocalizerStringId.CustomUIFilterBottomNDescription: return " 가장 낮은 값";
                case FilterUIElementLocalizerStringId.CustomUIFilterBottomNName: return " 하위 N";
                case FilterUIElementLocalizerStringId.CustomUIFilterContainsDescription: return " 특정 텍스트 포함";
                case FilterUIElementLocalizerStringId.CustomUIFilterContainsName: return " 포함";
                case FilterUIElementLocalizerStringId.CustomUIFilterCustomDescription: return " AND로 두 조건을 결합 또는 OR 연산자";
                case FilterUIElementLocalizerStringId.CustomUIFilterCustomName: return " 사용자 지정 필터";
                case FilterUIElementLocalizerStringId.CustomUIFilterDatePeriodsDescription: return " 일반적인 날짜 범위";
                case FilterUIElementLocalizerStringId.CustomUIFilterDatePeriodsName: return " 특정 날짜 기간";
                case FilterUIElementLocalizerStringId.CustomUIFilterDecemberDescription: return " 12 월";
                case FilterUIElementLocalizerStringId.CustomUIFilterDecemberName: return " 12 월";
                case FilterUIElementLocalizerStringId.CustomUIFilterDoesNotBeginsWithDescription: return " 특정 텍스트와 함께 시작 하지 않음";
                case FilterUIElementLocalizerStringId.CustomUIFilterDoesNotBeginsWithName: return " 로 시작 하지 않습니다";
                case FilterUIElementLocalizerStringId.CustomUIFilterDoesNotBeginWithDescription: return " 특정 텍스트와 함께 시작 하지 않음";
                case FilterUIElementLocalizerStringId.CustomUIFilterDoesNotBeginWithName: return " 로 시작 하지 않습니다";
                case FilterUIElementLocalizerStringId.CustomUIFilterDoesNotContainDescription: return " 특정 텍스트를 포함 하지 않음";
                case FilterUIElementLocalizerStringId.CustomUIFilterDoesNotContainName: return " 포함 하지 않음";
                case FilterUIElementLocalizerStringId.CustomUIFilterDoesNotEndsWithDescription: return " 특정 텍스트와 함께 끝나지 않음";
                case FilterUIElementLocalizerStringId.CustomUIFilterDoesNotEndsWithName: return " 로 끝나지 않음";
                case FilterUIElementLocalizerStringId.CustomUIFilterDoesNotEndWithDescription: return " 특정 텍스트와 함께 끝나지 않음";
                case FilterUIElementLocalizerStringId.CustomUIFilterDoesNotEndWithName: return " 로 끝나지 않음";
                case FilterUIElementLocalizerStringId.CustomUIFilterDoesNotEqualDescription: return " 값을 같게 하지 않음";
                case FilterUIElementLocalizerStringId.CustomUIFilterDoesNotEqualName: return " 같지 않음";
                case FilterUIElementLocalizerStringId.CustomUIFilterEndsWithDescription: return " 특정 텍스트로 끝남";
                case FilterUIElementLocalizerStringId.CustomUIFilterEndsWithName: return " 로 끝남";
                case FilterUIElementLocalizerStringId.CustomUIFilterEqualsDescription: return " 값";
                case FilterUIElementLocalizerStringId.CustomUIFilterEqualsName: return " 같음";
                case FilterUIElementLocalizerStringId.CustomUIFilterFebruaryDescription: return " 2 월";
                case FilterUIElementLocalizerStringId.CustomUIFilterFebruaryName: return " 2 월";
                case FilterUIElementLocalizerStringId.CustomUIFilterGreaterThanDescription: return " 값 보다 큰";
                case FilterUIElementLocalizerStringId.CustomUIFilterGreaterThanName: return " 보다 큰";
                case FilterUIElementLocalizerStringId.CustomUIFilterGreaterThanOrEqualToDescription: return " 값 보다 크거나";
                case FilterUIElementLocalizerStringId.CustomUIFilterGreaterThanOrEqualToName: return " 보다 작거나";
                case FilterUIElementLocalizerStringId.CustomUIFilterIsBlankDescription: return " 빈 또는 지정 하지 않은";
                case FilterUIElementLocalizerStringId.CustomUIFilterIsBlankName: return " 비어 있음";
                case FilterUIElementLocalizerStringId.CustomUIFilterIsNotBlankDescription: return " 비어 있지 않음";
                case FilterUIElementLocalizerStringId.CustomUIFilterIsNotBlankName: return " 비어 있지 않음";
                case FilterUIElementLocalizerStringId.CustomUIFilterIsNotNullDescription: return " 비어 있지 않음";
                case FilterUIElementLocalizerStringId.CustomUIFilterIsNotNullName: return " Null이 아님";
                case FilterUIElementLocalizerStringId.CustomUIFilterIsNullDescription: return " 비어 있음";
                case FilterUIElementLocalizerStringId.CustomUIFilterIsNullName: return " Null";
                case FilterUIElementLocalizerStringId.CustomUIFilterJanuaryDescription: return " 1 월";
                case FilterUIElementLocalizerStringId.CustomUIFilterJanuaryName: return " 1 월";
                case FilterUIElementLocalizerStringId.CustomUIFilterJulyDescription: return " 7 월";
                case FilterUIElementLocalizerStringId.CustomUIFilterJulyName: return " 7 월";
                case FilterUIElementLocalizerStringId.CustomUIFilterJuneDescription: return " 6 월";
                case FilterUIElementLocalizerStringId.CustomUIFilterJuneName: return " 6 월";
                case FilterUIElementLocalizerStringId.CustomUIFilterLastMonthDescription: return " 지난 달";
                case FilterUIElementLocalizerStringId.CustomUIFilterLastMonthName: return " 지난 달";
                case FilterUIElementLocalizerStringId.CustomUIFilterLastQuarterDescription: return " 지난 분기";
                case FilterUIElementLocalizerStringId.CustomUIFilterLastQuarterName: return " 지난 분기";
                case FilterUIElementLocalizerStringId.CustomUIFilterLastWeekDescription: return " 지난 주";
                case FilterUIElementLocalizerStringId.CustomUIFilterLastWeekName: return " 지난 주";
                case FilterUIElementLocalizerStringId.CustomUIFilterLastYearDescription: return " 지난 1 년";
                case FilterUIElementLocalizerStringId.CustomUIFilterLastYearName: return " 지난 1 년";
                case FilterUIElementLocalizerStringId.CustomUIFilterLessThanDescription: return " 값 미만";
                case FilterUIElementLocalizerStringId.CustomUIFilterLessThanName: return " 미만";
                case FilterUIElementLocalizerStringId.CustomUIFilterLessThanOrEqualToDescription: return " 값 보다 작거나";
                case FilterUIElementLocalizerStringId.CustomUIFilterLessThanOrEqualToName: return " 보다 작거나 같음";
                case FilterUIElementLocalizerStringId.CustomUIFilterLikeDescription: return " 특정 패턴 일치";
                case FilterUIElementLocalizerStringId.CustomUIFilterMarchDescription: return " 3 월";
                case FilterUIElementLocalizerStringId.CustomUIFilterMarchName: return " 3 월";
                case FilterUIElementLocalizerStringId.CustomUIFilterMayDescription: return " 5 월";
                case FilterUIElementLocalizerStringId.CustomUIFilterMayName: return " 5 월";
                case FilterUIElementLocalizerStringId.CustomUIFilterNextMonthDescription: return " 다음 달";
                case FilterUIElementLocalizerStringId.CustomUIFilterNextMonthName: return " 다음 달";
                case FilterUIElementLocalizerStringId.CustomUIFilterNextQuarterDescription: return " 다음 분기";
                case FilterUIElementLocalizerStringId.CustomUIFilterNextQuarterName: return " 다음 분기";
                case FilterUIElementLocalizerStringId.CustomUIFilterNextWeekDescription: return " 다음 주";
                case FilterUIElementLocalizerStringId.CustomUIFilterNextWeekName: return " 다음 주";
                case FilterUIElementLocalizerStringId.CustomUIFilterNextYearDescription: return " 내년";
                case FilterUIElementLocalizerStringId.CustomUIFilterNextYearName: return " 내년";
                case FilterUIElementLocalizerStringId.CustomUIFilterNoneDescription: return " 한 설명 선택";
                case FilterUIElementLocalizerStringId.CustomUIFilterNoneName: return " 하나를 선택";
                case FilterUIElementLocalizerStringId.CustomUIFilterNotLikeDescription: return " 특정 패턴과 일치하지 않음";
                case FilterUIElementLocalizerStringId.CustomUIFilterNovemberDescription: return " 11 월";
                case FilterUIElementLocalizerStringId.CustomUIFilterNovemberName: return " 11 월";
                case FilterUIElementLocalizerStringId.CustomUIFilterOctoberDescription: return " 10 월";
                case FilterUIElementLocalizerStringId.CustomUIFilterOctoberName: return " 10 월";
                case FilterUIElementLocalizerStringId.CustomUIFilterQuarter1Description: return " 1 분기";
                case FilterUIElementLocalizerStringId.CustomUIFilterQuarter1Name: return " 분기 1";
                case FilterUIElementLocalizerStringId.CustomUIFilterQuarter2Description: return " 2 분기";
                case FilterUIElementLocalizerStringId.CustomUIFilterQuarter2Name: return " 분기 2";
                case FilterUIElementLocalizerStringId.CustomUIFilterQuarter3Description: return " 3 분기";
                case FilterUIElementLocalizerStringId.CustomUIFilterQuarter3Name: return " 분기 3";
                case FilterUIElementLocalizerStringId.CustomUIFilterQuarter4Description: return " 4 분기";
                case FilterUIElementLocalizerStringId.CustomUIFilterQuarter4Name: return " 분기 4";
                case FilterUIElementLocalizerStringId.CustomUIFiltersBooleanDescription: return " 필터 설명";
                case FilterUIElementLocalizerStringId.CustomUIFiltersBooleanName: return " Filters";
                case FilterUIElementLocalizerStringId.CustomUIFiltersDateTimeDescription: return " 날짜 필터 설명";
                case FilterUIElementLocalizerStringId.CustomUIFiltersDateTimeName: return " 날짜 필터";
                case FilterUIElementLocalizerStringId.CustomUIFiltersDurationName: return " Filters";
                case FilterUIElementLocalizerStringId.CustomUIFiltersEnumDescription: return " 필터 설명";
                case FilterUIElementLocalizerStringId.CustomUIFiltersEnumName: return " Filters";
                case FilterUIElementLocalizerStringId.CustomUIFilterSeptemberDescription: return " 9 월";
                case FilterUIElementLocalizerStringId.CustomUIFilterSeptemberName: return " 9 월";
                case FilterUIElementLocalizerStringId.CustomUIFilterSequenceQualifierItemsDescription: return " 항목 설명";
                case FilterUIElementLocalizerStringId.CustomUIFilterSequenceQualifierItemsName: return " 항목";
                case FilterUIElementLocalizerStringId.CustomUIFilterSequenceQualifierPercentsDescription: return " 퍼센트 설명";
                case FilterUIElementLocalizerStringId.CustomUIFilterSequenceQualifierPercentsName: return " 퍼센트";
                case FilterUIElementLocalizerStringId.CustomUIFiltersNumericDescription: return " 숫자 필터 설명";
                case FilterUIElementLocalizerStringId.CustomUIFiltersNumericName: return " 숫자 필터";
                case FilterUIElementLocalizerStringId.CustomUIFiltersTextDescription: return " 텍스트 필터 설명";
                case FilterUIElementLocalizerStringId.CustomUIFiltersTextName: return " 텍스트 필터";
                case FilterUIElementLocalizerStringId.CustomUIFilterThisMonthDescription: return " 이번 달";
                case FilterUIElementLocalizerStringId.CustomUIFilterThisMonthName: return " 이번 달";
                case FilterUIElementLocalizerStringId.CustomUIFilterThisQuarterDescription: return " 이 분기";
                case FilterUIElementLocalizerStringId.CustomUIFilterThisQuarterName: return " 이 분기";
                case FilterUIElementLocalizerStringId.CustomUIFilterThisWeekDescription: return " 이번 주";
                case FilterUIElementLocalizerStringId.CustomUIFilterThisWeekName: return " 이번 주";
                case FilterUIElementLocalizerStringId.CustomUIFilterThisYearDescription: return " 올해";
                case FilterUIElementLocalizerStringId.CustomUIFilterThisYearName: return " 올해";
                case FilterUIElementLocalizerStringId.CustomUIFilterTodayDescription: return " 오늘";
                case FilterUIElementLocalizerStringId.CustomUIFilterTodayName: return " 오늘";
                case FilterUIElementLocalizerStringId.CustomUIFilterTomorrowDescription: return " 내일";
                case FilterUIElementLocalizerStringId.CustomUIFilterTomorrowName: return " 내일";
                case FilterUIElementLocalizerStringId.CustomUIFilterTopNDescription: return " 가장 높은 값";
                case FilterUIElementLocalizerStringId.CustomUIFilterTopNName: return " 상위 n 개";
                case FilterUIElementLocalizerStringId.CustomUIFilterYearToDateDescription: return " 현재 올해의 시작에서";
                case FilterUIElementLocalizerStringId.CustomUIFilterYearToDateName: return " 연간 누계";
                case FilterUIElementLocalizerStringId.CustomUIFilterYesterdayDescription: return " 어제";
                case FilterUIElementLocalizerStringId.CustomUIFilterYesterdayName: return " 어제";
                case FilterUIElementLocalizerStringId.CustomUIFirstLabel: return " 첫 번째";
                case FilterUIElementLocalizerStringId.CustomUINullValuePromptChooseOne: return " 하나을 선택 하는 것은...";
                case FilterUIElementLocalizerStringId.CustomUINullValuePromptEnterADate: return " 입력 한 날짜를...";
                case FilterUIElementLocalizerStringId.CustomUINullValuePromptEnterAValue: return " 입력 값...";
                case FilterUIElementLocalizerStringId.CustomUINullValuePromptSearchControl: return " 입력 검색 텍스트를...";
                case FilterUIElementLocalizerStringId.CustomUINullValuePromptSelectADate: return " 선택 날짜...";
                case FilterUIElementLocalizerStringId.CustomUINullValuePromptSelectAValue: return " 선택 값...";
                case FilterUIElementLocalizerStringId.CustomUISecondLabel: return " 초";
                case FilterUIElementLocalizerStringId.CustomUITypeLabel: return " 유형";
                case FilterUIElementLocalizerStringId.CustomUIValueLabel: return " 값";
                case FilterUIElementLocalizerStringId.FilteringUIClearFilter: return " 필터 지우기";
                case FilterUIElementLocalizerStringId.FilteringUIClose: return " 닫기";
                case FilterUIElementLocalizerStringId.FilteringUISearchByDayCaption: return " 일";
                case FilterUIElementLocalizerStringId.FilteringUISearchByMonthCaption: return " 달";
                case FilterUIElementLocalizerStringId.FilteringUISearchByYearCaption: return " 년";
                case FilterUIElementLocalizerStringId.FilteringUITabValues: return " 값";
            }

            return base.GetLocalizedString(id);
        }
    }
}
