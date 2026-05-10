using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraVerticalGrid.Localization;

namespace EBAP.Win.BaseFrame.Localization
{
    /// <summary>
    /// Vertical Grid Control Library를 한국어로 설정합니다.
    /// </summary>
    internal class PVGridLocalizer : DevExpress.XtraVerticalGrid.Localization.VGridLocalizer
    {
        /// <summary>
        /// Vertical Grid Control에서 보여지는 Text를 설정합니다.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override string GetLocalizedString(VGridStringId id)
        {
            switch (id)
            {
                case VGridStringId.ExpressionEditorFieldsName: return " 필드";
                case VGridStringId.FilterEditorApplyButton: return " 적용(&A)";
                case VGridStringId.FilterEditorCancelButton: return " 취소(&C)";
                case VGridStringId.FilterEditorCaption: return " 필터 편집기";
                case VGridStringId.FilterEditorOkButton: return " 확인(&O)";
                case VGridStringId.FilterPanelCustomizeButton: return " 필터 편집";
                case VGridStringId.FindControlClearButton: return " 지우기";
                case VGridStringId.FindControlFindButton: return " 찾기";
                case VGridStringId.InvalidRecordExceptionText: return " 값을 수정 하 시겠습니까?";
                case VGridStringId.MenuPropertySortAscending: return " 오름차순 정렬";
                case VGridStringId.MenuPropertySortDescending: return " 내림차순 정렬";
                case VGridStringId.MenuReset: return " 다시 설정";
                case VGridStringId.MenuRowBestFit: return " 맞춤";
                case VGridStringId.MenuRowClearFilter: return " 필터 지우기";
                case VGridStringId.MenuRowCollapse: return " 축소";
                case VGridStringId.MenuRowCollapseAll: return " 모두 축소";
                case VGridStringId.MenuRowExpand: return " 확장";
                case VGridStringId.MenuRowExpandAll: return " 모두 확장";
                case VGridStringId.MenuRowFilterEditor: return " 필터 편집기...";
                case VGridStringId.MenuRowFindFilterHide: return " 찾기 패널 숨기기";
                case VGridStringId.MenuRowFindFilterShow: return " 찾기 패널 표시";
                case VGridStringId.PopupFilterAll: return " (모두)";
                case VGridStringId.PopupFilterBlanks: return " (공백)";
                case VGridStringId.RowCustomizationDeleteCategoryText: return " 삭제(&D)";
                case VGridStringId.RowCustomizationNewCategoryFormLabelText: return " 캡션:";
                case VGridStringId.RowCustomizationNewCategoryFormText: return " 새로운 카테고리";
                case VGridStringId.RowCustomizationNewCategoryText: return " 새로운(&N)...";
                case VGridStringId.RowCustomizationTabPageCategoriesText: return " 카테고리";
                case VGridStringId.RowCustomizationTabPageRowsText: return " 행";
                case VGridStringId.RowCustomizationText: return " 사용자 지정";
                case VGridStringId.StyleCreatorName: return " 나만의 스타일 만들기";
                case VGridStringId.WindowErrorCaption: return " 오류";
            }
            return base.GetLocalizedString(id);
        }
        ///// <summary>
        ///// Vertical Grid Control에서 보여지는 Text를 설정합니다.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public override string GetLocalizedString(VGridStringId id)
        //{
        //    switch (id)
        //    {
        //        case VGridStringId.MenuRowBestFit:
        //            return "최적너비";
        //        case VGridStringId.MenuRowCustomization:
        //            return "로우 사용자지정";
        //        case VGridStringId.MenuRowFindFilterShow:
        //            return "필터 PANEL 보임";
        //        case VGridStringId.MenuRowFindFilterHide:
        //            return "필터 PANEL 숨김";
        //        case VGridStringId.FindControlFindButton:
        //            return "필터링";
        //        case VGridStringId.FindControlClearButton:
        //            return "초기화";
        //        case VGridStringId.MenuRowFilterEditor:
        //            return "필터링 편집";
        //    }
        //    return base.GetLocalizedString(id);
        //}
    }
}
