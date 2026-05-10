using DevExpress.XtraSpreadsheet.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EBAP.Win.BaseFrame.Localization
{
    /// <summary>
    /// Spreadsheet Control Library를 한국어로 설정합니다.
    /// </summary>
    internal class PSpreadsheetResLocalizer : DevExpress.XtraSpreadsheet.Localization.XtraSpreadsheetResLocalizer
    {
        /// <summary>
        /// Spreadsheet Control에서 보여지는 Text를 설정합니다.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public override string GetLocalizedString(XtraSpreadsheetStringId id)
        {
            switch(id)
            {
                case XtraSpreadsheetStringId.Caption_ColorAutomatic: return " 자동";
                case XtraSpreadsheetStringId.Caption_CustomTableStyleCategory: return " 사용자 지정";
                case XtraSpreadsheetStringId.Caption_FormatNumberCustom: return " 사용자 지정";
                case XtraSpreadsheetStringId.Caption_FormatNumberDate: return " 날짜";
                case XtraSpreadsheetStringId.Caption_GroupAlignment: return " 맞춤";
                case XtraSpreadsheetStringId.Caption_GroupChartsDesignData: return " 데이터";
                case XtraSpreadsheetStringId.Caption_GroupChartsDesignType: return " 유형";
                case XtraSpreadsheetStringId.Caption_GroupChartsLayoutLabels: return " 레이블";
                case XtraSpreadsheetStringId.Caption_GroupFont: return " 글꼴";
                case XtraSpreadsheetStringId.Caption_GroupMailMergeBinding: return " 디자인";
                case XtraSpreadsheetStringId.Caption_GroupPageSetup: return " 페이지 설정";
                case XtraSpreadsheetStringId.Caption_GroupPrint: return " 인쇄";
                case XtraSpreadsheetStringId.Caption_GroupTableProperties: return " 속성";
                case XtraSpreadsheetStringId.Caption_GroupZoom: return " 확대/축소";
                case XtraSpreadsheetStringId.Caption_PageChartsDesign: return " 디자인";
                case XtraSpreadsheetStringId.Caption_PageChartsLayout: return " 레이아웃";
                case XtraSpreadsheetStringId.Caption_PageData: return " 데이터";
                case XtraSpreadsheetStringId.Caption_PageFile: return " 파일";
                case XtraSpreadsheetStringId.Caption_PageFormat: return " 형식";
                case XtraSpreadsheetStringId.Caption_PageHome: return " 홈";
                case XtraSpreadsheetStringId.Caption_PageInsert: return " 삽입";
                case XtraSpreadsheetStringId.Caption_PageMailMerge: return " 편지 병합";
                case XtraSpreadsheetStringId.Caption_PagePageLayout: return " 페이지 레이아웃";
                case XtraSpreadsheetStringId.Caption_PageView: return " 보기";
                case XtraSpreadsheetStringId.Caption_StyleGalleryGroupCustom: return " 사용자 지정";
                case XtraSpreadsheetStringId.Caption_TableStyleNameIsNone: return " 없음";
                case XtraSpreadsheetStringId.Caption_TableToolsDesignPage: return " 디자인";
                case XtraSpreadsheetStringId.Caption_TimePeriod_Today: return " 오늘";
                case XtraSpreadsheetStringId.CaptionAllFunctionsGroup: return " 모든";
                case XtraSpreadsheetStringId.FontStyle_Bold: return " 굵게";
                case XtraSpreadsheetStringId.FontStyle_Italic: return " 기울임꼴";
                case XtraSpreadsheetStringId.FormatCellsForm_HorizontalAlignmentCaption_Center: return " 가운데";
                case XtraSpreadsheetStringId.FormatCellsForm_HorizontalAlignmentCaption_General: return " 일반";
                case XtraSpreadsheetStringId.FormatCellsForm_HorizontalAlignmentCaption_Justify: return " 양쪽 맞춤";
                case XtraSpreadsheetStringId.FormatCellsForm_UnderlineCaption_None: return " 없음";
                case XtraSpreadsheetStringId.FormatCellsForm_VerticalAlignmentCaption_Bottom: return " 하단";
                case XtraSpreadsheetStringId.FormatCellsForm_VerticalAlignmentCaption_Center: return " 가운데";
                case XtraSpreadsheetStringId.FormatCellsForm_VerticalAlignmentCaption_Justify: return " 양쪽 맞춤";
                case XtraSpreadsheetStringId.FormatCellsForm_VerticalAlignmentCaption_Top: return " 상단";
                case XtraSpreadsheetStringId.HyperlinkForm_SelectedBookmarkNone: return " < 없음 >";
                case XtraSpreadsheetStringId.MenuCmd_CalculationModeAutomatic: return " 자동";
                case XtraSpreadsheetStringId.MenuCmd_ChartDataLabelsBestFitCommand: return " 맞춤";
                case XtraSpreadsheetStringId.MenuCmd_ChartDataLabelsCenterCommand: return " 가운데";
                case XtraSpreadsheetStringId.MenuCmd_ChartDataLabelsLeftCommand: return " 왼쪽";
                case XtraSpreadsheetStringId.MenuCmd_ChartDataLabelsNoneCommand: return " 없음";
                case XtraSpreadsheetStringId.MenuCmd_ChartDataLabelsRightCommand: return " 오른쪽";
                case XtraSpreadsheetStringId.MenuCmd_ChartErrorBarsNoneCommand: return " 없음";
                case XtraSpreadsheetStringId.MenuCmd_ChartHidePrimaryHorizontalAxisCommand: return " 없음";
                case XtraSpreadsheetStringId.MenuCmd_ChartHidePrimaryVerticalAxisCommand: return " 없음";
                case XtraSpreadsheetStringId.MenuCmd_ChartHideUpDownBarsCommand: return " 없음";
                case XtraSpreadsheetStringId.MenuCmd_ChartLegendNoneCommand: return " 없음";
                case XtraSpreadsheetStringId.MenuCmd_ChartLinesNoneCommand: return " 없음";
                case XtraSpreadsheetStringId.MenuCmd_ChartPrimaryHorizontalAxisTitleNoneCommand: return " 없음";
                case XtraSpreadsheetStringId.MenuCmd_ChartPrimaryHorizontalGridlinesNoneCommand: return " 없음";
                case XtraSpreadsheetStringId.MenuCmd_ChartPrimaryVerticalAxisTitleNoneCommand: return " 없음";
                case XtraSpreadsheetStringId.MenuCmd_ChartPrimaryVerticalGridlinesNoneCommand: return " 없음";
                case XtraSpreadsheetStringId.MenuCmd_ChartTitleNoneCommand: return " 없음";
                case XtraSpreadsheetStringId.MenuCmd_EditingFind: return " 찾기";
                case XtraSpreadsheetStringId.MenuCmd_FormatClearAll: return " 모두 지우기";
                case XtraSpreadsheetStringId.MenuCmd_FormatClearCommandGroup: return " 지우기";
                case XtraSpreadsheetStringId.MenuCmd_FormatCommandGroup: return " 형식";
                case XtraSpreadsheetStringId.MenuCmd_FormatNumberGeneral: return " 일반";
                case XtraSpreadsheetStringId.MenuCmd_FormatNumberText: return " 텍스트";
                case XtraSpreadsheetStringId.MenuCmd_FunctionsInsertAverage: return " 평균";
                case XtraSpreadsheetStringId.MenuCmd_FunctionsInsertMax: return " 최대값";
                case XtraSpreadsheetStringId.MenuCmd_FunctionsInsertMin: return " 최소값";
                case XtraSpreadsheetStringId.MenuCmd_FunctionsInsertSum: return " 합계";
                case XtraSpreadsheetStringId.MenuCmd_FunctionsTextCommandGroup: return " 텍스트";
                case XtraSpreadsheetStringId.MenuCmd_HideColumnsContextMenuItem: return " 숨기기";
                case XtraSpreadsheetStringId.MenuCmd_HideRowsContextMenuItem: return " 숨기기";
                case XtraSpreadsheetStringId.MenuCmd_HideSheetContextMenuItem: return " 숨기기";
                case XtraSpreadsheetStringId.MenuCmd_InsertCellsCommandGroup: return " 삽입";
                case XtraSpreadsheetStringId.MenuCmd_InsertChartColumnCommandGroup: return " 열";
                case XtraSpreadsheetStringId.MenuCmd_InsertSheetColumnsContextMenuItem: return " 삽입";
                case XtraSpreadsheetStringId.MenuCmd_InsertSheetContextMenuItem: return " 삽입";
                case XtraSpreadsheetStringId.MenuCmd_InsertSheetRowsContextMenuItem: return " 삽입";
                case XtraSpreadsheetStringId.MenuCmd_MailMergeHorizontalModeCommand: return " 가로";
                case XtraSpreadsheetStringId.MenuCmd_MailMergeResetRangeCommand: return " 다시 설정";
                case XtraSpreadsheetStringId.MenuCmd_MailMergeSetFooterRangeCommand: return " 바닥글";
                case XtraSpreadsheetStringId.MenuCmd_MailMergeSetHeaderRangeCommand: return " 헤더";
                case XtraSpreadsheetStringId.MenuCmd_MailMergeVerticalModeCommand: return " 수직";
                case XtraSpreadsheetStringId.MenuCmd_PageSetupMarginsCommandGroup: return " 여백";
                case XtraSpreadsheetStringId.MenuCmd_PageSetupPaperKindCommandGroup: return " 크기";
                case XtraSpreadsheetStringId.MenuCmd_PageSetupSetPaperKind: return " 크기";
                case XtraSpreadsheetStringId.MenuCmd_RemoveCellsCommandGroup: return " 삭제";
                case XtraSpreadsheetStringId.MenuCmd_RemoveSheetColumnsContextMenuItem: return " 삭제";
                case XtraSpreadsheetStringId.MenuCmd_RemoveSheetContextMenuItem: return " 삭제";
                case XtraSpreadsheetStringId.MenuCmd_RemoveSheetRowsContextMenuItem: return " 삭제";
                case XtraSpreadsheetStringId.MoveOrCopySheetForm_Copy: return " 복사";
                case XtraSpreadsheetStringId.StyleName_Normal: return " 보통";
                case XtraSpreadsheetStringId.Tooltip_FormulaBarCancelButton: return " 취소";

            }
            return base.GetLocalizedString(id);
        }
    }
}
