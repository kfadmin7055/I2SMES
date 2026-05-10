using DevExpress.XtraLayout.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EBAP.Win.BaseFrame.Localization
{
    /// <summary>
    /// Layout Control Library를 한국어로 설정합니다.
    /// </summary>
    internal class PLayoutResLocalizer : DevExpress.XtraLayout.Localization.LayoutResLocalizer
    {
        /// <summary>
        /// Layout Control에서 보여지는 Text를 설정합니다.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override string GetLocalizedString(LayoutStringId id)
        {
            switch (id)
            {
                case LayoutStringId.AddTabMenuText: return " 탭 추가";
                case LayoutStringId.BestFitMenuText: return " 맞춤";
                case LayoutStringId.CreateEmptySpaceItem: return " 빈 공간 항목 만들기";
                case LayoutStringId.CustomizationFormTitle: return " 사용자 지정";
                case LayoutStringId.DefaultEmptyText: return " 없음";
                case LayoutStringId.DeleteTemplateText: return " 삭제";
                case LayoutStringId.EditColumns: return " 열 편집";
                case LayoutStringId.GroupItemsMenuText: return " 그룹";
                case LayoutStringId.GroupStyleTitle: return " 제목";
                case LayoutStringId.HiddenItemsNodeText: return " 숨겨진 항목";
                case LayoutStringId.HiddenItemsPageTitle: return " 숨겨진 항목";
                case LayoutStringId.HideCustomizationFormMenuText: return " 사용자 정의 폼 숨기기";
                case LayoutStringId.HideTextMenuItem: return " 텍스트 숨기기";
                case LayoutStringId.LayoutControlDescription: return " 레이아웃 컨트롤";
                case LayoutStringId.LayoutGroupDescription: return " 레이아웃 컨트롤 그룹 요소";
                case LayoutStringId.LayoutItemDescription: return " 레이아웃 컨트롤 항목 요소";
                case LayoutStringId.LayoutResetConfirmationDialogCaption: return " 레이아웃 재설정 확인";
                case LayoutStringId.LayoutResetConfirmationText: return " 레이아웃 사용자 지정을 다시 설정 하려고 합니다. 계속 진행 하시겠습니까?";
                case LayoutStringId.LoadButtonHintText: return " XML 파일에서 레이아웃 로드";
                case LayoutStringId.LoadHintCaption: return " 로드 (Ctrl + O)";
                case LayoutStringId.LockMenuGroup: return " 크기 제한";
                case LayoutStringId.RedoHintCaption: return " 다시 실행 (Ctrl + Y)";
                case LayoutStringId.RenameMenuText: return " 이름 바꾸기";
                case LayoutStringId.RenameSelected: return " 이름 바꾸기";
                case LayoutStringId.ResetConstraintsToDefaultsMenuItem: return " 기본값으로 재설정";
                case LayoutStringId.SaveHintCaption: return " 저장 (Ctrl + S)";
                case LayoutStringId.ShowCustomizationFormMenuText: return " 레이아웃 사용자 지정";
                case LayoutStringId.ShowTextMenuItem: return " 텍스트 표시";
                case LayoutStringId.SimpleLabelItemDefaultText: return " 레이블";
                case LayoutStringId.SimpleSeparatorItemDefaultText: return " 구분 기호";
                case LayoutStringId.TextPositionBottomMenuText: return " 하단";
                case LayoutStringId.TextPositionLeftMenuText: return " 왼쪽";
                case LayoutStringId.TextPositionMenuText: return " 텍스트 위치";
                case LayoutStringId.TextPositionRightMenuText: return " 오른쪽";
                case LayoutStringId.TextPositionTopMenuText: return " 위";
                case LayoutStringId.TreeViewRootNodeName: return " 루트";
                case LayoutStringId.UnGroupItemsMenuText: return " 그룹 해제";
                case LayoutStringId.UnGroupTabbedGroupMenuText: return " 탭 그룹 해제";
                case LayoutStringId.ControlGroupDefaultText: return " 그룹";
                case LayoutStringId.EmptySpaceItemDefaultText: return " 빈 공간 항목";
                case LayoutStringId.TreeViewPageTitle: return " 트리 구조 보기";
                case LayoutStringId.AddItem: return " 항목 추가";
                case LayoutStringId.HideItemMenutext: return " 항목 숨김";
                case LayoutStringId.CreateTabbedGroupMenuText: return " 탭그룹 만들기";
            }
            return base.GetLocalizedString(id);
        }
    }
}
