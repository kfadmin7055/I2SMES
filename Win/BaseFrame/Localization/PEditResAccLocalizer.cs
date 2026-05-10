using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Accessibility;
using DevExpress.Utils.Filtering.Internal;

namespace EBAP.Win.BaseFrame.Localization
{
    /// <summary>
    /// Edit Resource Library를 한국어로 설정합니다.
    /// </summary>
    internal class PEditResAccLocalizer : DevExpress.Accessibility.EditResAccLocalizer
    {
        /// <summary>
        /// Edit Resource Element 에서 보여지는 Text를 설정합니다.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override string GetLocalizedString(AccStringId id)
        {
            switch (id)
            {
                case AccStringId.AboutCompetitiveDiscounts: return " 문의";
                case AccStringId.AboutCopyToClipboard: return " 클립보드로 복사";
                case AccStringId.AboutExpiredVersion: return " 만료 된 버전";
                case AccStringId.AboutRegisterYourProduct: return " 제품 등록";
                case AccStringId.AboutRegistrationCode: return " 등록 코드";
                case AccStringId.AboutSubscribeOnline: return " 온라인으로 구매";
                case AccStringId.AboutSubscription: return " {0} DXperience 구독을 사용 하는";
                case AccStringId.AboutTrialVersion: return " 평가판";
                case AccStringId.ActionPress: return " 보도 자료";
                case AccStringId.BarDockControlBottom: return " 선 창 하단";
                case AccStringId.BarDockControlLeft: return " 선 창 왼쪽";
                case AccStringId.BarDockControlRight: return " 바로 도킹";
                case AccStringId.BarDockControlTop: return " Dock 상단";
                case AccStringId.BarLinkCaption: return " 아이템";
                case AccStringId.BarLinkClick: return " 보도 자료";
                case AccStringId.BarLinkEdit: return " 편집";
                case AccStringId.BarLinkMenuClose: return " 닫기";
                case AccStringId.BarLinkMenuOpen: return " 오픈";
                case AccStringId.BarLinkStatic: return " 고정";
                case AccStringId.ButtonClose: return " 닫기";
                case AccStringId.ButtonOpen: return " 오픈";
                case AccStringId.ButtonPush: return " 보도 자료";
                case AccStringId.CheckEditCheck: return " 확인";
                case AccStringId.CheckEditUncheck: return " 선택 취소";
                case AccStringId.DescScrollAreaDown: return " 세로 위치를 몇 줄 아래로 이동";
                case AccStringId.DescScrollAreaLeft: return " 열 몇 왼쪽 가로 위치 이동";
                case AccStringId.DescScrollAreaRight: return " 수평 위치 열 몇 마우스 오른쪽 이동";
                case AccStringId.DescScrollAreaUp: return " 라인의 몇 가지를 수직 위치 이동";
                case AccStringId.DescScrollColumnLeft: return " 수평 위치 왼쪽된 한 열 이동";
                case AccStringId.DescScrollColumnRight: return " 수평 위치 오른쪽 하나 열 이동";
                case AccStringId.DescScrollHorzIndicator: return " 현재 가로 위치를 나타냅니다 하 고 그것을 직접 변경 하려면 끌 수 있습니다.";
                case AccStringId.DescScrollLineDown: return " 한 줄 아래로 수직 위치 이동";
                case AccStringId.DescScrollLineUp: return " 한 줄 위로 수직 위치 이동";
                case AccStringId.DescScrollVertIndicator: return " 현재 수직 위치를 나타냅니다 하 고 그것을 직접 변경 하려면 끌 수 있습니다.";
                case AccStringId.GridCardCollapse: return " 축소";
                case AccStringId.GridCardExpand: return " 확장";
                case AccStringId.GridCell: return " 셀";
                case AccStringId.GridCellEdit: return " 편집";
                case AccStringId.GridCellFocus: return " 포커스";
                case AccStringId.GridColumnSortAscending: return " 오름차순 정렬";
                case AccStringId.GridColumnSortDescending: return " 내림차순 정렬";
                case AccStringId.GridColumnSortNone: return " 정렬 제거";
                case AccStringId.GridDataPanel: return " 데이터 패널";
                case AccStringId.GridFilterRow: return " 행 필터";
                case AccStringId.GridHeaderPanel: return " 헤더 패널";
                case AccStringId.GridNewItemRow: return " 신규 아이템 행";
                case AccStringId.GridRow: return " 행 {0}";
                case AccStringId.GridRowActivate: return " 활성화";
                case AccStringId.GridRowCollapse: return " 축소";
                case AccStringId.GridRowExpand: return " 확장";
                case AccStringId.MouseDoubleClick: return " 더블 클릭";
                case AccStringId.NameScroll: return " 스크롤 막대";
                case AccStringId.NameScrollAreaDown: return " 페이지 아래로";
                case AccStringId.NameScrollAreaLeft: return " 페이지 왼쪽";
                case AccStringId.NameScrollAreaRight: return " 페이지 오른쪽";
                case AccStringId.NameScrollAreaUp: return " 페이지 위로";
                case AccStringId.NameScrollColumnLeft: return " 열 왼쪽";
                case AccStringId.NameScrollColumnRight: return " 열 오른쪽";
                case AccStringId.NameScrollIndicator: return " 위치";
                case AccStringId.NameScrollLineDown: return " 아래로 선";
                case AccStringId.NameScrollLineUp: return " 위로 선";
                case AccStringId.NavBarGroupCollapse: return " 축소";
                case AccStringId.NavBarGroupExpand: return " 확장";
                case AccStringId.NavBarItemClick: return " 보도 자료";
                case AccStringId.NavBarScrollDown: return " 아래로 스크롤";
                case AccStringId.NavBarScrollUp: return " 위로 스크롤";
                case AccStringId.SpinBox: return " 회전자";
                case AccStringId.SpinDownButton: return " 아래로";
                case AccStringId.SpinLeftButton: return " 왼쪽";
                case AccStringId.SpinRightButton: return " 오른쪽";
                case AccStringId.SpinUpButton: return " 위로";
                case AccStringId.TabSwitch: return " 스위치";
                case AccStringId.TreeListCellEdit: return " 편집";
                case AccStringId.TreeListColumnSortAscending: return " 오름차순 정렬";
                case AccStringId.TreeListColumnSortDescending: return " 내림차순 정렬";
                case AccStringId.TreeListColumnSortNone: return " 정렬 제거";
                case AccStringId.TreeListDataPanel: return " 데이터 패널";
                case AccStringId.TreeListHeaderPanel: return " 헤더 패널";
                case AccStringId.TreeListNode: return " 노드";
                case AccStringId.TreeListNodeCell: return " 셀";
                case AccStringId.TreeListNodeCollapse: return " 축소";
                case AccStringId.TreeListNodeExpand: return " 확장";
                case AccStringId.TreelistRowActivate: return " 활성화";
            }

            return base.GetLocalizedString(id);
        }
    }
}
