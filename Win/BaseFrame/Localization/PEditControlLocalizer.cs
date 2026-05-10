using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBAP.Win.BaseFrame.Localization
{
    /// <summary>
    /// EditControl Library를 한국어로 설정합니다.
    /// </summary>
    internal class PEditControlLocalizer : DevExpress.XtraEditors.Controls.Localizer
    {
        /// <summary>
        /// Editor Control에서 보여지는 Text를 설정합니다.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override string GetLocalizedString(StringId id)
        {
            switch (id)
            {
                case StringId.Apply: return " 적용";
                case StringId.CalcButtonBack: return " Back";
                case StringId.CalcButtonC: return " C";
                case StringId.CalcButtonCE: return " CE";
                case StringId.CalcButtonMC: return " MC";
                case StringId.CalcButtonMR: return " MR";
                case StringId.CalcButtonMS: return " MS";
                case StringId.CalcButtonMx: return " M+";
                case StringId.CalcButtonSqrt: return " sqrt";
                case StringId.CalcError: return " 계산 오류";
                case StringId.Cancel: return " 취소";
                case StringId.CaptionError: return " 에러";
                case StringId.CheckChecked: return " 선택";
                case StringId.CheckIndeterminate: return " 미정";
                case StringId.CheckUnchecked: return " 선택안됨";
                case StringId.ColorPickBlueValidationMsg: return " 파랑 구성 요소에 범위..255 이어야 한다";
                case StringId.ColorPickBrightnessAxisName: return " 밝기";
                case StringId.ColorPickBrightValidationMsg: return " 밝기 구성 요소 범위 0..100에 있어야";
                case StringId.ColorPickColorHexValidationMsg: return " 잘못 된 16 진수 값";
                case StringId.ColorPickGreenValidationMsg: return " 녹색 구성 요소 범위..255에 있어야";
                case StringId.ColorPickHueAxisName: return " 색조";
                case StringId.ColorPickHueValidationMsg: return " 색상 구성 요소 범위 0..359에 있어야";
                case StringId.ColorPickLuminanceAxisName: return " 광도";
                case StringId.ColorPickOpacityAxisName: return " 불투명도";
                case StringId.ColorPickOpacityValidationMsg: return " 불투명도 구성 요소 범위..255에 있어야";
                case StringId.ColorPickPopupAutomaticItemCaption: return " 자동";
                case StringId.ColorPickPopupMoreColorsItemCaption: return " 더 많은 색상...";
                case StringId.ColorPickPopupRecentColorsGroupCaption: return " 최근 색";
                case StringId.ColorPickPopupStandardColorsGroupCaption: return " 표준 색상";
                case StringId.ColorPickPopupThemeColorsGroupCaption: return " 테마 색";
                case StringId.ColorPickRedValidationMsg: return " 빨강 구성 요소 범위..255에 있어야";
                case StringId.ColorPickSaturationAxisName: return " 채도";
                case StringId.ColorPickSaturationValidationMsg: return " 채도 구성 요소 범위 0..100에 있어야";
                case StringId.ColorTabCustom: return " 사용자정의";
                case StringId.ColorTabSystem: return " 시스템";
                case StringId.ColorTabWeb: return " 웹";
                case StringId.ColorTabWebSafeColors: return " 웹 안전";
                case StringId.ContainerAccessibleEditName: return " 컨트롤 편집";
                case StringId.DataEmpty: return " 이미지 데이터 없음";
                case StringId.DateEditClear: return " 지우기";
                case StringId.DateEditToday: return " 오늘";
                case StringId.Days: return " 일";
                case StringId.DefaultBooleanDefault: return " 기본";
                case StringId.DefaultBooleanFalse: return " FALSE";
                case StringId.DefaultBooleanTrue: return " TRUE";
                case StringId.DXCollectionEditorAddItemButtonText: return " 추가";
                case StringId.DXCollectionEditorCancelButtonText: return " 취소";
                case StringId.DXCollectionEditorItemPropertiesGroupCaption: return " 속성";
                case StringId.DXCollectionEditorOKButtonText: return " 확인";
                case StringId.DXCollectionEditorPreviewGroupCaption: return " 미리 보기";
                case StringId.DXCollectionEditorRemoveItemButtonText: return " 제거";
                case StringId.FieldListName: return " 필드 목록 ({0})";
                case StringId.FilterAggregateAvg: return " Avg";
                case StringId.FilterAggregateCount: return " Count";
                case StringId.FilterAggregateExists: return " Exists";
                case StringId.FilterAggregateMax: return " Max";
                case StringId.FilterAggregateMin: return " Min";
                case StringId.FilterAggregateSum: return " Sum";
                case StringId.FilterClauseAnyOf: return " Is any of";
                case StringId.FilterClauseBeginsWith: return " Begins with";
                case StringId.FilterClauseBetween: return " Is between";
                case StringId.FilterClauseBetweenAnd: return " and";
                case StringId.FilterClauseContains: return " Contains";
                case StringId.FilterClauseDoesNotContain: return " Does not contain";
                case StringId.FilterClauseDoesNotEqual: return " 같지 않음";
                case StringId.FilterClauseEndsWith: return " Ends with";
                case StringId.FilterClauseEquals: return " 같음";
                case StringId.FilterClauseGreater: return " Is greater than";
                case StringId.FilterClauseGreaterOrEqual: return " Is greater than or equal to";
                case StringId.FilterClauseIsNotNull: return " Is not null";
                case StringId.FilterClauseIsNotNullOrEmpty: return " Is not blank";
                case StringId.FilterClauseIsNull: return " Is null";
                case StringId.FilterClauseIsNullOrEmpty: return " Is blank";
                case StringId.FilterClauseLess: return " 보다 작음";
                case StringId.FilterClauseLessOrEqual: return " Is less than or equal to";
                case StringId.FilterClauseLike: return " Is like";
                case StringId.FilterClauseNoneOf: return " Is none of";
                case StringId.FilterClauseNotBetween: return " Is not between";
                case StringId.FilterClauseNotLike: return " Is not like";
                case StringId.FilterCriteriaInvalidExpression: return " 지정된 식은 잘못된 기호를 포함합니다. (line {0} character {1}).";
                case StringId.FilterCriteriaInvalidExpressionEx: return " 지정된 표현식이 유효하지 않습니다.";
                case StringId.FilterCriteriaToStringBetween: return " Between";
                case StringId.FilterCriteriaToStringBinaryOperatorBitwiseAnd: return " &";
                case StringId.FilterCriteriaToStringBinaryOperatorBitwiseOr: return " |";
                case StringId.FilterCriteriaToStringBinaryOperatorBitwiseXor: return " ^";
                case StringId.FilterCriteriaToStringBinaryOperatorDivide: return " /";
                case StringId.FilterCriteriaToStringBinaryOperatorEqual: return " =";
                case StringId.FilterCriteriaToStringBinaryOperatorGreater: return " >";
                case StringId.FilterCriteriaToStringBinaryOperatorGreaterOrEqual: return " >=";
                case StringId.FilterCriteriaToStringBinaryOperatorLess: return " <";
                case StringId.FilterCriteriaToStringBinaryOperatorLessOrEqual: return " <=";
                case StringId.FilterCriteriaToStringBinaryOperatorLike: return " Like";
                case StringId.FilterCriteriaToStringBinaryOperatorMinus: return " -";
                case StringId.FilterCriteriaToStringBinaryOperatorModulo: return " %";
                case StringId.FilterCriteriaToStringBinaryOperatorMultiply: return " *";
                case StringId.FilterCriteriaToStringBinaryOperatorNotEqual: return " <>";
                case StringId.FilterCriteriaToStringBinaryOperatorPlus: return " +";
                case StringId.FilterCriteriaToStringFunctionAbs: return " Abs";
                case StringId.FilterCriteriaToStringFunctionAcos: return " Acos";
                case StringId.FilterCriteriaToStringFunctionAddDays: return " Add days";
                case StringId.FilterCriteriaToStringFunctionAddHours: return " Add hours";
                case StringId.FilterCriteriaToStringFunctionAddMilliSeconds: return " Add milliseconds";
                case StringId.FilterCriteriaToStringFunctionAddMinutes: return " Add minutes";
                case StringId.FilterCriteriaToStringFunctionAddMonths: return " Add months";
                case StringId.FilterCriteriaToStringFunctionAddSeconds: return " Add seconds";
                case StringId.FilterCriteriaToStringFunctionAddTicks: return " Add ticks";
                case StringId.FilterCriteriaToStringFunctionAddTimeSpan: return " Add time span";
                case StringId.FilterCriteriaToStringFunctionAddYears: return " Add years";
                case StringId.FilterCriteriaToStringFunctionAscii: return " Ascii";
                case StringId.FilterCriteriaToStringFunctionAsin: return " Asin";
                case StringId.FilterCriteriaToStringFunctionAtn: return " Atn";
                case StringId.FilterCriteriaToStringFunctionAtn2: return " Atn2";
                case StringId.FilterCriteriaToStringFunctionBigMul: return " Big mul";
                case StringId.FilterCriteriaToStringFunctionCeiling: return " Ceiling";
                case StringId.FilterCriteriaToStringFunctionChar: return " Char";
                case StringId.FilterCriteriaToStringFunctionCharIndex: return " Char index";
                case StringId.FilterCriteriaToStringFunctionConcat: return " Concat";
                case StringId.FilterCriteriaToStringFunctionContains: return " Contains";
                case StringId.FilterCriteriaToStringFunctionCos: return " Cos";
                case StringId.FilterCriteriaToStringFunctionCosh: return " Cosh";
                case StringId.FilterCriteriaToStringFunctionCustom: return " Custom";
                case StringId.FilterCriteriaToStringFunctionCustomNonDeterministic: return " Custom non deterministic";
                case StringId.FilterCriteriaToStringFunctionDateDiffDay: return " Date diff day";
                case StringId.FilterCriteriaToStringFunctionDateDiffHour: return " Date diff hour";
                case StringId.FilterCriteriaToStringFunctionDateDiffMilliSecond: return " Date diff millisecond";
                case StringId.FilterCriteriaToStringFunctionDateDiffMinute: return " Date diff minute";
                case StringId.FilterCriteriaToStringFunctionDateDiffMonth: return " Date diff month";
                case StringId.FilterCriteriaToStringFunctionDateDiffSecond: return " Date diff second";
                case StringId.FilterCriteriaToStringFunctionDateDiffTick: return " Date diff tick";
                case StringId.FilterCriteriaToStringFunctionDateDiffYear: return " Date diff year";
                case StringId.FilterCriteriaToStringFunctionEndsWith: return " Ends with";
                case StringId.FilterCriteriaToStringFunctionExp: return " Exp";
                case StringId.FilterCriteriaToStringFunctionFloor: return " Floor";
                case StringId.FilterCriteriaToStringFunctionGetDate: return " Get date";
                case StringId.FilterCriteriaToStringFunctionGetDay: return " Get day";
                case StringId.FilterCriteriaToStringFunctionGetDayOfWeek: return " Get day of week";
                case StringId.FilterCriteriaToStringFunctionGetDayOfYear: return " Get day of year";
                case StringId.FilterCriteriaToStringFunctionGetHour: return " Get hour";
                case StringId.FilterCriteriaToStringFunctionGetMilliSecond: return " Get millisecond";
                case StringId.FilterCriteriaToStringFunctionGetMinute: return " Get minute";
                case StringId.FilterCriteriaToStringFunctionGetMonth: return " Get month";
                case StringId.FilterCriteriaToStringFunctionGetSecond: return " Get second";
                case StringId.FilterCriteriaToStringFunctionGetTimeOfDay: return " Get time of day";
                case StringId.FilterCriteriaToStringFunctionGetYear: return " Get year";
                case StringId.FilterCriteriaToStringFunctionIif: return " Iif";
                case StringId.FilterCriteriaToStringFunctionInsert: return " Insert";
                case StringId.FilterCriteriaToStringFunctionIsDecember: return " 12 월";
                case StringId.FilterCriteriaToStringFunctionIsJanuary: return " 1 월";
                case StringId.FilterCriteriaToStringFunctionIsJuly: return " 7 월";
                case StringId.FilterCriteriaToStringFunctionIsLastMonth: return " 지난 달";
                case StringId.FilterCriteriaToStringFunctionIsMarch: return " 3 월";
                case StringId.FilterCriteriaToStringFunctionIsNextMonth: return " 다음 달";
                case StringId.FilterCriteriaToStringFunctionIsNextYear: return " 내년";
                case StringId.FilterCriteriaToStringFunctionIsNovember: return " 11 월";
                case StringId.FilterCriteriaToStringFunctionIsNull: return " IsNull";
                case StringId.FilterCriteriaToStringFunctionIsNullOrEmpty: return " Is null or empty";
                case StringId.FilterCriteriaToStringFunctionIsOctober: return " 10 월";
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalBeyondThisYear: return " Is beyond this year";
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalEarlierThisMonth: return " Is earlier this month";
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalEarlierThisWeek: return " Is earlier this week";
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalEarlierThisYear: return " Is earlier this year";
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalLastWeek: return " Is last week";
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalLaterThisMonth: return " Is later this month";
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalLaterThisWeek: return " Is later this week";
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalLaterThisYear: return " Is later this year";
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalNextWeek: return " Is next week";
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalPriorThisYear: return " Is prior this year";
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalToday: return " Is today";
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalTomorrow: return " Is tomorrow";
                case StringId.FilterCriteriaToStringFunctionIsOutlookIntervalYesterday: return " Is yesterday";
                case StringId.FilterCriteriaToStringFunctionIsSameDay: return " 같은 날은";
                case StringId.FilterCriteriaToStringFunctionIsSeptember: return " 9 월은";
                case StringId.FilterCriteriaToStringFunctionIsThisMonth: return " Is this month";
                case StringId.FilterCriteriaToStringFunctionIsThisWeek: return " Is this week";
                case StringId.FilterCriteriaToStringFunctionIsThisYear: return " Is this year";
                case StringId.FilterCriteriaToStringFunctionIsYearToDate: return " 올해-날짜 기간";
                case StringId.FilterCriteriaToStringFunctionLen: return " Len";
                case StringId.FilterCriteriaToStringFunctionLocalDateTimeDayAfterTomorrow: return " Day after tomorrow";
                case StringId.FilterCriteriaToStringFunctionLocalDateTimeLastMonth: return " 지난 달";
                case StringId.FilterCriteriaToStringFunctionLocalDateTimeLastWeek: return " Last week";
                case StringId.FilterCriteriaToStringFunctionLocalDateTimeLastYear: return " 지난 1 년";
                case StringId.FilterCriteriaToStringFunctionLocalDateTimeNextMonth: return " Next month";
                case StringId.FilterCriteriaToStringFunctionLocalDateTimeNextWeek: return " Next week";
                case StringId.FilterCriteriaToStringFunctionLocalDateTimeNextYear: return " Next year";
                case StringId.FilterCriteriaToStringFunctionLocalDateTimeNow: return " Now";
                case StringId.FilterCriteriaToStringFunctionLocalDateTimeThisMonth: return " This month";
                case StringId.FilterCriteriaToStringFunctionLocalDateTimeThisWeek: return " This week";
                case StringId.FilterCriteriaToStringFunctionLocalDateTimeThisYear: return " This year";
                case StringId.FilterCriteriaToStringFunctionLocalDateTimeToday: return " Today";
                case StringId.FilterCriteriaToStringFunctionLocalDateTimeTomorrow: return " Tomorrow";
                case StringId.FilterCriteriaToStringFunctionLocalDateTimeTwoMonthsAway: return " 두 달 거리";
                case StringId.FilterCriteriaToStringFunctionLocalDateTimeTwoWeeksAway: return " Two weeks away";
                case StringId.FilterCriteriaToStringFunctionLocalDateTimeTwoYearsAway: return " 2 년 떨어져";
                case StringId.FilterCriteriaToStringFunctionLocalDateTimeYearBeforeToday: return " 1 년 전";
                case StringId.FilterCriteriaToStringFunctionLocalDateTimeYesterday: return " Yesterday";
                case StringId.FilterCriteriaToStringFunctionLog: return " Log";
                case StringId.FilterCriteriaToStringFunctionLog10: return " Log10";
                case StringId.FilterCriteriaToStringFunctionLower: return " Lower";
                case StringId.FilterCriteriaToStringFunctionMax: return " Max";
                case StringId.FilterCriteriaToStringFunctionMin: return " Min";
                case StringId.FilterCriteriaToStringFunctionNone: return " None";
                case StringId.FilterCriteriaToStringFunctionNow: return " Now";
                case StringId.FilterCriteriaToStringFunctionPadLeft: return " Pad left";
                case StringId.FilterCriteriaToStringFunctionPadRight: return " Pad right";
                case StringId.FilterCriteriaToStringFunctionPower: return " Power";
                case StringId.FilterCriteriaToStringFunctionRemove: return " Remove";
                case StringId.FilterCriteriaToStringFunctionReplace: return " Replace";
                case StringId.FilterCriteriaToStringFunctionReverse: return " Reverse";
                case StringId.FilterCriteriaToStringFunctionRnd: return " Rnd";
                case StringId.FilterCriteriaToStringFunctionRound: return " Round";
                case StringId.FilterCriteriaToStringFunctionSign: return " Sign";
                case StringId.FilterCriteriaToStringFunctionSin: return " Sin";
                case StringId.FilterCriteriaToStringFunctionSinh: return " Sinh";
                case StringId.FilterCriteriaToStringFunctionSqr: return " Sqr";
                case StringId.FilterCriteriaToStringFunctionStartsWith: return " Starts with";
                case StringId.FilterCriteriaToStringFunctionSubstring: return " Substring";
                case StringId.FilterCriteriaToStringFunctionTan: return " Tan";
                case StringId.FilterCriteriaToStringFunctionTanh: return " Tanh";
                case StringId.FilterCriteriaToStringFunctionToday: return " Today";
                case StringId.FilterCriteriaToStringFunctionToDecimal: return " To decimal";
                case StringId.FilterCriteriaToStringFunctionToDouble: return " To double";
                case StringId.FilterCriteriaToStringFunctionToFloat: return " To float";
                case StringId.FilterCriteriaToStringFunctionToInt: return " To int";
                case StringId.FilterCriteriaToStringFunctionToLong: return " To long";
                case StringId.FilterCriteriaToStringFunctionToStr: return " To str";
                case StringId.FilterCriteriaToStringFunctionTrim: return " Trim";
                case StringId.FilterCriteriaToStringFunctionUpper: return " Upper";
                case StringId.FilterCriteriaToStringFunctionUtcNow: return " Utc now";
                case StringId.FilterCriteriaToStringGroupOperatorAnd: return " And";
                case StringId.FilterCriteriaToStringGroupOperatorOr: return " Or";
                case StringId.FilterCriteriaToStringIn: return " In";
                case StringId.FilterCriteriaToStringIsNotNull: return " Is Not Null";
                case StringId.FilterCriteriaToStringNotLike: return " Not Like";
                case StringId.FilterCriteriaToStringUnaryOperatorBitwiseNot: return " ~";
                case StringId.FilterCriteriaToStringUnaryOperatorIsNull: return " Is Null";
                case StringId.FilterCriteriaToStringUnaryOperatorMinus: return " -";
                case StringId.FilterCriteriaToStringUnaryOperatorNot: return " Not";
                case StringId.FilterCriteriaToStringUnaryOperatorPlus: return " +";
                case StringId.FilterDateTextAlt: return " 모두 보기|공백 표시|지정된 날짜 필터링 :|이후|||다음 주|오늘|이번 주|이번 달|이전|{0 : yyyy}, {0 : MMMM}";
                case StringId.FilterDateTimeConstantMenuCaption: return " 날짜 및 시간 상수";
                case StringId.FilterDateTimeOperatorMenuCaption: return " 날짜 및 시간 연산자";
                case StringId.FilterEditorTabText: return " 텍스트";
                case StringId.FilterEditorTabVisual: return " 비주얼";
                case StringId.FilterEmptyEnter: return " <값을 입력하세요>";
                case StringId.FilterEmptyParameter: return " <파라미터를 입력하세요>";
                case StringId.FilterEmptyValue: return " <공백>";
                case StringId.FilterFunctionsMenuCaption: return " 함수";
                case StringId.FilterGroupAnd: return " And";
                case StringId.FilterGroupNotAnd: return " Not And";
                case StringId.FilterGroupNotOr: return " Not Or";
                case StringId.FilterGroupOr: return " Or";
                case StringId.FilterMenuAddNewParameter: return " 새로운 파라미터 추가...";
                case StringId.FilterMenuClearAll: return " 모두 지우기";
                case StringId.FilterMenuConditionAdd: return " 조건 추가";
                case StringId.FilterMenuGroupAdd: return " 그룹 추가";
                case StringId.FilterMenuRowRemove: return " 그룹 삭제";
                case StringId.FilterNewEmptyEnter: return " 입력 값...";
                case StringId.FilterOutlookDateText: return " Show all|Show Empty|Filter by a specific date:|Beyond this year|Later this year|Later this month|Next week|Later this week|Tomorrow|Today|Yesterday|Earlier this week|Last week|Earlier this month|Earlier this year|Prior to this year";
                case StringId.FilterPopupToolbarIncrementalSearch: return " 증분 검색";
                case StringId.FilterPopupToolbarInvertFilter: return " 역 필터";
                case StringId.FilterPopupToolbarMultiSelection: return " 다중 선택";
                case StringId.FilterPopupToolbarRadioMode: return " 라디오 모드";
                case StringId.FilterPopupToolbarShowNewValues: return " 새로운 필드 값을 표시";
                case StringId.FilterPopupToolbarShowOnlyAvailableItems: return " 가능한 항목만 표시";
                case StringId.FilterShowAll: return " (전체 선택)";
                case StringId.FilterToolTipElementAdd: return " 목록에 새 항목 추가";
                case StringId.FilterToolTipKeysAdd: return " (Insert 혹은 + 키 사용)";
                case StringId.FilterToolTipKeysRemove: return " (Delete 혹은 - 키 사용)";
                case StringId.FilterToolTipNodeAction: return " 동작";
                case StringId.FilterToolTipNodeAdd: return " 이 그룹에 새로운 조건을 추가";
                case StringId.FilterToolTipNodeRemove: return " 이 조건 제거";
                case StringId.FilterToolTipValueType: return " 값 / 다른 필드의 값을 비교";
                case StringId.FormatRuleMenuItemAboveAverage: return " 평균 이상";
                case StringId.FormatRuleMenuItemBetween: return " 사이";
                case StringId.FormatRuleMenuItemLessThan: return " 미만";
                case StringId.FormatRuleWith: return " 와 함께";
                case StringId.Hours: return " 시간";
                case StringId.ImagePopupEmpty: return " (공백)";
                case StringId.ImagePopupPicture: return " (그림)";
                case StringId.InvalidValueText: return " 유효하지 않은 값";
                case StringId.LookUpColumnDefaultName: return " 이름";
                case StringId.LookUpEditValueIsNull: return " [EditValue is null]";
                case StringId.LookUpInvalidEditValueType: return " 유효하지 않은 LookUpEdit EditValue 타입";
                case StringId.ManageRuleAboveAverage: return " 평균 이상";
                case StringId.ManageRuleAllColumns: return " (모두)";
                case StringId.ManageRuleAverageFormatValuesThatAre: return " 다음과 같은 서식 값 :";
                case StringId.ManageRuleBelowAverage: return " 평균 이하";
                case StringId.ManageRuleCellValueBetween: return " 사이";
                case StringId.ManageRuleCellValueLessThan: return " 미만";
                case StringId.ManageRuleCommonAutomatic: return " 자동";
                case StringId.ManageRuleCommonColor: return " 색상:";
                case StringId.ManageRuleCommonMaximum: return " 최대";
                case StringId.ManageRuleCommonMinimum: return " 최소";
                case StringId.ManageRuleCommonNumber: return " 숫자";
                case StringId.ManageRuleCommonPercent: return " %";
                case StringId.ManageRuleCommonPreview: return " 미리 보기:";
                case StringId.ManageRuleCommonType: return " 유형:";
                case StringId.ManageRuleCommonValue: return " 값:";
                case StringId.ManageRuleDataBarUseNegativeBar: return " 네거티브 바 사용";
                case StringId.ManageRuleDatesOccurringBeyondThisYear: return " 이 따라";
                case StringId.ManageRuleDatesOccurringEarlier: return " 월 6 개월 전 사전";
                case StringId.ManageRuleDatesOccurringEarlierThisYear: return " 이 년이 달 전에";
                case StringId.ManageRuleDatesOccurringLastWeek: return " 지난 주";
                case StringId.ManageRuleDatesOccurringLaterThisYear: return " 이 년이 달 넘어";
                case StringId.ManageRuleDatesOccurringMonthAfter1: return " 다음 달";
                case StringId.ManageRuleDatesOccurringMonthAgo1: return " 지난 달";
                case StringId.ManageRuleDatesOccurringNextWeek: return " 다음 주";
                case StringId.ManageRuleDatesOccurringThisMonth: return " 이번 달";
                case StringId.ManageRuleDatesOccurringThisWeek: return " 이번 주";
                case StringId.ManageRuleDatesOccurringToday: return " 오늘";
                case StringId.ManageRuleDatesOccurringTomorrow: return " 내일";
                case StringId.ManageRuleDatesOccurringYesterday: return " 어제";
                case StringId.ManageRuleDown: return " 아래로";
                case StringId.ManageRuleFormatCellsBold: return " 굵게";
                case StringId.ManageRuleFormatCellsCaption: return " 셀 서식";
                case StringId.ManageRuleFormatCellsClear: return " 지우기";
                case StringId.ManageRuleFormatCellsFill: return " 채우기";
                case StringId.ManageRuleFormatCellsFont: return " 글꼴";
                case StringId.ManageRuleFormatCellsItalic: return " 기울임꼴";
                case StringId.ManageRuleFormatCellsNone: return " 없음";
                case StringId.ManageRuleFormatCellsStrikethrough: return " 취소선";
                case StringId.ManageRuleFormatCellsUnderline: return " 밑줄";
                case StringId.ManageRuleGridCaptionColumn: return " 열";
                case StringId.ManageRuleGridCaptionEnabled: return " 사용 가능";
                case StringId.ManageRuleGridCaptionFormat: return " 형식";
                case StringId.ManageRuleGridCaptionRow: return " 행";
                case StringId.ManageRuleRankedValuesBottom: return " 하단";
                case StringId.ManageRuleRankedValuesTop: return " 상단";
                case StringId.ManageRuleThatContainNoBlanks: return " 공백 없음";
                case StringId.ManageRuleThatContainNoErrors: return " 오류 없음";
                case StringId.ManageRuleUp: return " 위로";
                case StringId.MaskBoxValidateError: return " 입력된 값이 불완전합니다. 수정 하시겠습니까? 예 - 편집기로 돌아가 값을 수정합니다. 아니오 - 값을 그래도 둡니다. 취소 - 이전 값으로 재설정합니다.";
                case StringId.Mins: return " 분";
                case StringId.NavigatorAppendButtonHint: return " 추가";
                case StringId.NavigatorCancelEditButtonHint: return " 편집 취소";
                case StringId.NavigatorEditButtonHint: return " 편집";
                case StringId.NavigatorEndEditButtonHint: return " 편집 완료";
                case StringId.NavigatorFirstButtonHint: return " 처음";
                case StringId.NavigatorLastButtonHint: return " 마지막";
                case StringId.NavigatorNextButtonHint: return " 다음";
                case StringId.NavigatorNextPageButtonHint: return " 다음 페이지";
                case StringId.NavigatorPreviousButtonHint: return " 이전";
                case StringId.NavigatorPreviousPageButtonHint: return " 이전 페이지";
                case StringId.NavigatorRemoveButtonHint: return " 삭제";
                case StringId.NavigatorTextStringFormat: return " 레코드 {0} / {1}";
                case StringId.None: return " ";
                case StringId.NoneItemText: return " (없음)";
                case StringId.NotValidArrayLength: return " 유효하지 않은 배열 길이";
                case StringId.OK: return " 확인";
                case StringId.PictureEditCopyImageError: return " 이미지를 복사 할 수 없습니다.";
                case StringId.PictureEditMenuCopy: return " 복사";
                case StringId.PictureEditMenuCut: return " 잘라내기";
                case StringId.PictureEditMenuDelete: return " 삭제";
                case StringId.PictureEditMenuEdit: return " 편집";
                case StringId.PictureEditMenuFitImage: return " 이미지 맞춤";
                case StringId.PictureEditMenuFullSize: return " 전체 크기";
                case StringId.PictureEditMenuLoad: return " 로드";
                case StringId.PictureEditMenuPaste: return " 붙여넣기";
                case StringId.PictureEditMenuSave: return " 저장";
                case StringId.PictureEditMenuZoom: return " 확대/축소";
                case StringId.PictureEditMenuZoomIn: return " 확대";
                case StringId.PictureEditMenuZoomOut: return " 축소";
                case StringId.PictureEditMenuZoomTo: return " 확대:";
                case StringId.PictureEditMenuZoomToolTip: return " {0}%";
                case StringId.PictureEditOpenFileError: return " 잘못된 그림 포맷";
                case StringId.PictureEditOpenFileErrorCaption: return " 열기 오류";
                case StringId.PictureEditOpenFileFilter: return " Bitmap Files (*.bmp)|*.bmp|Graphics Interchange Format (*.gif)|*.gif|JPEG File Interchange Format (*.jpg;*.jpeg)|*.jpg;*.jpeg|Icon Files (*.ico)|*.ico|Portable Network Graphics Format (*.png)|*.png|All Picture Files |*.bmp;*.gif;*.jpg;*.jpeg;*.ico;*.png;*.tif|All Files |*.*";
                case StringId.PictureEditOpenFileTitle: return " 열기";
                case StringId.PictureEditSaveFileFilter: return " Bitmap Files (*.bmp)|*.bmp|Graphics Interchange Format (*.gif)|*.gif|JPEG File Interchange Format (*.jpg)|*.jpg|Portable Network Graphics Format (*.png)|*.png";
                case StringId.PictureEditSaveFileTitle: return " 다른 이름으로 저장";
                case StringId.PreviewPanelText: return " 미리보기:";
                case StringId.ProgressCancel: return " 취소";
                case StringId.ProgressCancelPending: return " 취소 대기";
                case StringId.ProgressCreateDocument: return " 문서 만들기";
                case StringId.ProgressExport: return " 내보내기";
                case StringId.ProgressLoadingData: return " 데이터 로드 중";
                case StringId.ProgressPrinting: return " 인쇄 중";
                case StringId.RestoreLayoutDialogFileFilter: return " XML files (*.xml)|*.xml|All files|*.*";
                case StringId.RestoreLayoutDialogTitle: return " 레이아웃 불러오기";
                case StringId.SaveLayoutDialogFileFilter: return " XML files (*.xml)|*.xml";
                case StringId.SaveLayoutDialogTitle: return " 레이아웃 저장";
                case StringId.SearchForColumn: return " 열 검색...";
                case StringId.SearchForField: return " 필드 검색...";
                case StringId.Secs: return " 초";
                case StringId.SyntaxEditFindPanelCloseButtonTooltip: return " 닫기";
                case StringId.SyntaxEditFindPanelFindNextButtonTooltip: return " 다음 찾기";
                case StringId.TabHeaderButtonClose: return " 닫기";
                case StringId.TabHeaderButtonDown: return " 아래로 스크롤";
                case StringId.TabHeaderButtonNext: return " 오른쪽 스크롤";
                case StringId.TabHeaderButtonPrev: return " 왼쪽 스크롤";
                case StringId.TabHeaderSelectorButton: return " 윈도우 목록 보기";
                case StringId.TakePictureDialogSave: return " 저장";
                case StringId.TextEditMenuCopy: return " 복사(&C)";
                case StringId.TextEditMenuCut: return " 잘라내기(&T)";
                case StringId.TextEditMenuDelete: return " 삭제(&D)";
                case StringId.TextEditMenuPaste: return " 붙여넣기(&P)";
                case StringId.TextEditMenuSelectAll: return " 모두 선택(&A)";
                case StringId.TextEditMenuUndo: return " 실행 취소(&U)";
                case StringId.TimeSpanDaysPlural: return " 일";
                case StringId.TimeSpanHoursPlural: return " 시간";
                case StringId.TimeSpanMinutesPlural: return " 분";
                case StringId.TimeSpanMinutesShort: return " m";
                case StringId.TransparentBackColorNotSupported: return " 이 컨트롤은 투명 한 배경 색상을 지원하지 않습니다.";
                case StringId.UnknownPictureFormat: return " 알 수 없는 그림 포맷";
                case StringId.Version: return " 버전";
                case StringId.XtraMessageBoxAbortButtonText: return " 중단(&A)";
                case StringId.XtraMessageBoxCancelButtonText: return " 취소(&C)";
                case StringId.XtraMessageBoxIgnoreButtonText: return " 무시(&I)";
                case StringId.XtraMessageBoxNoButtonText: return " 아니오(&N)";
                case StringId.XtraMessageBoxOkButtonText: return " 확인(&O)";
                case StringId.XtraMessageBoxRetryButtonText: return " 재시도(&R)";
                case StringId.XtraMessageBoxYesButtonText: return " 예(&Y)";
                case StringId.SearchControlNullValuePrompt: return " 검색할 내용을 입력하세요.";
            }
            return base.GetLocalizedString(id);
        }

        ///// <summary>
        ///// Editor Control에서 보여지는 Text를 설정합니다.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public override string GetLocalizedString(StringId id)
        //{
        //    switch (id)
        //    {
        //        case StringId.SearchControlNullValuePrompt:
        //            return "검색할 내용을 입력하세요.";
        //        case StringId.FilterClauseDoesNotEqual:
        //            return "같지 않음";
        //        case StringId.FilterClauseEquals:
        //            return "같음";
        //        case StringId.OK:
        //            return "확인";
        //        case StringId.Cancel:
        //            return "취소";
        //        case StringId.FilterShowAll:
        //            return "(전체)";
        //        case StringId.FilterMenuConditionAdd:
        //            return "조건 추가";
        //        case StringId.XtraMessageBoxAbortButtonText:
        //            return "중단";
        //        case StringId.XtraMessageBoxCancelButtonText:
        //            return "취소";
        //        case StringId.XtraMessageBoxIgnoreButtonText:
        //            return "무시";
        //        case StringId.XtraMessageBoxNoButtonText:
        //            return "아니오";
        //        case StringId.XtraMessageBoxOkButtonText:
        //            return "확인";
        //        case StringId.XtraMessageBoxRetryButtonText:
        //            return "재시도";
        //        case StringId.XtraMessageBoxYesButtonText:
        //            return "예";
        //        case StringId.DateEditToday:
        //            return "오늘";
        //        case StringId.DateEditClear:
        //            return "Clear";
        //        case StringId.PictureEditMenuCopy:
        //            return "복사";
        //        case StringId.PictureEditMenuCut:
        //            return "잘라내기";
        //        case StringId.PictureEditMenuDelete:
        //            return "삭제";
        //        case StringId.PictureEditMenuLoad:
        //            return "불러오기";
        //        case StringId.PictureEditMenuPaste:
        //            return "붙여넣기";
        //        case StringId.PictureEditMenuSave:
        //            return "저장";
        //        case StringId.PictureEditOpenFileTitle:
        //            return "Image 열기";
        //        case StringId.PictureEditSaveFileTitle:
        //            return "Image 저장";
        //        case StringId.PictureEditMenuZoomIn:
        //            return "확대";
        //        case StringId.PictureEditMenuZoomOut:
        //            return "축소";
        //        case StringId.TakePictureMenuItem:
        //            return "카메라로 사진 찍기";
        //        case StringId.PictureEditMenuZoom:
        //            return "확대/축소";
        //        case StringId.PictureEditMenuFullSize:
        //            return "원래 크기";
        //        case StringId.PictureEditMenuFitImage:
        //            return "전체 크기";
        //        case StringId.PictureEditOpenFileError:
        //            return "잘못된 그림 형식입니다.";
        //        case StringId.PictureEditOpenFileErrorCaption:
        //            return "열기 오류";
        //        case StringId.TabHeaderButtonPrev:
        //            return "이전";
        //        case StringId.TabHeaderButtonNext:
        //            return "다음";
        //        case StringId.TabHeaderButtonClose:
        //            return "닫기";
        //        case StringId.TextEditMenuCopy:
        //            return "복사";
        //        case StringId.TextEditMenuCut:
        //            return "잘라내기";
        //        case StringId.TextEditMenuDelete:
        //            return "삭제";
        //        case StringId.TextEditMenuPaste:
        //            return "붙여넣기";
        //        case StringId.TextEditMenuSelectAll:
        //            return "전체선택";
        //        case StringId.TextEditMenuUndo:
        //            return "되돌리기";
        //        case StringId.NavigatorAppendButtonHint:
        //            return "추가";
        //        case StringId.NavigatorCancelEditButtonHint:
        //            return "취소";
        //        case StringId.NavigatorEditButtonHint:
        //            return "수정";
        //        case StringId.NavigatorEndEditButtonHint:
        //            return "수정완료";
        //        case StringId.NavigatorFirstButtonHint:
        //            return "처음";
        //        case StringId.NavigatorLastButtonHint:
        //            return "마지막";
        //        case StringId.NavigatorNextButtonHint:
        //            return "다음";
        //        case StringId.NavigatorNextPageButtonHint:
        //            return "다음 페이지";
        //        case StringId.NavigatorPreviousButtonHint:
        //            return "이전";
        //        case StringId.NavigatorPreviousPageButtonHint:
        //            return "이전 페이지";
        //        case StringId.NavigatorRemoveButtonHint:
        //            return "삭제";
        //    }
        //    return base.GetLocalizedString(id);
        //}
    }
}
