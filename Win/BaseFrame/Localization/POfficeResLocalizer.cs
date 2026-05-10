using DevExpress.Office.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBAP.Win.BaseFrame.Localization
{
    /// <summary>
    /// DevExpress.Office Library를 한국어로 설정합니다.
    /// </summary>
    internal class POfficeResLocalizer : DevExpress.Office.Localization.OfficeResLocalizer
    {
        /// <summary>
        /// Control에서 보여지는 Text를 설정합니다.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override string GetLocalizedString(OfficeStringId id)
        {
            switch (id)
            {
                case OfficeStringId.Caption_InsertHyperlinkForm: return " 하이퍼링크 삽입";
                case OfficeStringId.Caption_UnitPercent: return " %";
                case OfficeStringId.Caption_UnitPoints: return " 포인트";
                case OfficeStringId.FileFilterDescription_AllFiles: return " 모든 파일";
                case OfficeStringId.FileFilterDescription_AllSupportedFiles: return " 모든 지원 되는 파일";
                case OfficeStringId.MenuCmd_AlignmentCenter: return " 가운데";
                case OfficeStringId.MenuCmd_AlignmentJustify: return " 양쪽 맞춤";
                case OfficeStringId.MenuCmd_AlignmentLeft: return " 텍스트 왼쪽 정렬";
                case OfficeStringId.MenuCmd_AlignmentRight: return " 텍스트 오른쪽 정렬";
                case OfficeStringId.MenuCmd_ChangeFontColor: return " 글꼴 색";
                case OfficeStringId.MenuCmd_ChangeFontColorDescription: return " 텍스트 색을 변경 합니다.";
                case OfficeStringId.MenuCmd_ChangeFontName: return " 글꼴";
                case OfficeStringId.MenuCmd_ChangeFontSize: return " 글꼴 크기";
                case OfficeStringId.MenuCmd_ChangeFontSizeDescription: return " 글꼴 크기를 변경 합니다.";
                case OfficeStringId.MenuCmd_CopySelection: return " 복사";
                case OfficeStringId.MenuCmd_CutSelection: return " 잘라내기";
                case OfficeStringId.MenuCmd_DecreaseFontSize: return " 글꼴 축소";
                case OfficeStringId.MenuCmd_DeleteComment: return " 삭제";
                case OfficeStringId.MenuCmd_DeleteCommentDescription: return " 선택한 댓글을 삭제 합니다.";
                case OfficeStringId.MenuCmd_EditComment: return " 코멘트를 편집";
                case OfficeStringId.MenuCmd_EditCommentDescription: return " 문서가이 부분에 대 한 메모를 추가 합니다.";
                case OfficeStringId.MenuCmd_FloatingObjectBringForward: return " 앞으로 가져오기";
                case OfficeStringId.MenuCmd_FloatingObjectBringForwardCommandGroup: return " 앞으로 가져오기";
                case OfficeStringId.MenuCmd_FloatingObjectBringForwardCommandGroupDescription: return " 선택한 개체 앞으로 한 수준 또는 다른 모든 객체의 앞에 그것을 있습니다.";
                case OfficeStringId.MenuCmd_FloatingObjectBringForwardDescription: return " 앞으로 적은 개체는 그것 앞으로 숨겨져 선택한 개체를 가져올";
                case OfficeStringId.MenuCmd_FloatingObjectBringToFront: return " 맨 앞으로 가져오기";
                case OfficeStringId.MenuCmd_FloatingObjectSendBackward: return " 뒤로 보내기";
                case OfficeStringId.MenuCmd_FloatingObjectSendBackwardCommandGroup: return " 뒤로 보내기";
                case OfficeStringId.MenuCmd_FloatingObjectSendBackwardCommandGroupDescription: return " 선택한 객체가 다시 한 단계를 보내거나 다른 모든 오브젝트 뒤에 보낼.";
                case OfficeStringId.MenuCmd_FloatingObjectSendBackwardDescription: return " 개체는 그것 앞으로 숨겨져 있도록 이전 버전과 선택한 개체 보내기";
                case OfficeStringId.MenuCmd_FloatingObjectSendToBack: return " 뒤로 보내기";
                case OfficeStringId.MenuCmd_HyperlinkDescription: return " 웹 페이지, 그림, 전자 메일 주소 또는 프로그램에 대 한 링크를 만듭니다.";
                case OfficeStringId.MenuCmd_IncreaseFontSizeDescription: return " 글꼴 크기를 증가 합니다.";
                case OfficeStringId.MenuCmd_InsertComment: return " 새로운 코멘트";
                case OfficeStringId.MenuCmd_InsertCommentDescription: return " 문서가이 부분에 대 한 메모를 추가 합니다.";
                case OfficeStringId.MenuCmd_InsertFloatingObjectPicture: return " 그림";
                case OfficeStringId.MenuCmd_InsertFloatingObjectPictureDescription: return " 파일에서 그림을 삽입 합니다.";
                case OfficeStringId.MenuCmd_InsertHyperlink: return " 하이퍼링크...";
                case OfficeStringId.MenuCmd_InsertHyperlinkDescription: return " 새 하이퍼링크를 추가 합니다.";
                case OfficeStringId.MenuCmd_InsertSymbol: return " 기호";
                case OfficeStringId.MenuCmd_InsertSymbolDescription: return " 는 저작권 기호, 상표 기호, 등 키보드에 없는 단락 표시 및 유니코드 문자 기호를 삽입 합니다.";
                case OfficeStringId.MenuCmd_LoadDocument: return " 열기";
                case OfficeStringId.MenuCmd_LoadDocumentDescription: return " 문서를 엽니다.";
                case OfficeStringId.MenuCmd_PageOrientationCommandGroup: return " 방향";
                case OfficeStringId.MenuCmd_PageOrientationLandscape: return " 가로";
                case OfficeStringId.MenuCmd_PageOrientationPortrait: return " 세로";
                case OfficeStringId.MenuCmd_Paste: return " 붙여넣기";
                case OfficeStringId.MenuCmd_PasteDescription: return " 는 클립보드의 내용을 붙여 넣습니다.";
                case OfficeStringId.MenuCmd_PrintDescription: return " 프린터, 매수 및 인쇄 하기 전에 다른 인쇄 옵션을 선택 합니다.";
                case OfficeStringId.MenuCmd_PrintPreviewDescription: return " 인쇄 하기 전에 페이지를 미리 보기 합니다.";
                case OfficeStringId.MenuCmd_QuickPrintDescription: return " 직접 기본 프린터 변경 하지 않고 문서를 보냅니다.";
                case OfficeStringId.MenuCmd_Redo: return " 다시 실행";
                case OfficeStringId.MenuCmd_RedoDescription: return " 다시 실행";
                case OfficeStringId.MenuCmd_SaveDocument: return " 저장";
                case OfficeStringId.MenuCmd_SaveDocumentAs: return " 다른 이름으로 저장";
                case OfficeStringId.MenuCmd_ShowPasteSpecialForm: return " ";
                case OfficeStringId.MenuCmd_StatusBarPopupMenuZoom: return " 확대/축소";
                case OfficeStringId.MenuCmd_StatusBarZoomSliderDescription: return " 확대/축소";
                case OfficeStringId.MenuCmd_ToggleFontBold: return " 굵게";
                case OfficeStringId.MenuCmd_ToggleFontBoldDescription: return " 선택한 텍스트를 굵게 합니다.";
                case OfficeStringId.MenuCmd_ToggleFontDoubleUnderline: return " 이중 밑줄";
                case OfficeStringId.MenuCmd_ToggleFontDoubleUnderlineDescription: return " 이중 밑줄";
                case OfficeStringId.MenuCmd_ToggleFontItalic: return " 기울임꼴";
                case OfficeStringId.MenuCmd_ToggleFontItalicDescription: return " 선택한 텍스트를 기울임꼴로 표시 합니다.";
                case OfficeStringId.MenuCmd_ToggleFontStrikeout: return " 취소선";
                case OfficeStringId.MenuCmd_ToggleFontUnderline: return " 밑줄";
                case OfficeStringId.MenuCmd_ToggleFontUnderlineDescription: return " 선택한 텍스트 밑줄.";
                case OfficeStringId.MenuCmd_Undo: return " 취소";
                case OfficeStringId.MenuCmd_UndoDescription: return " 취소";
                case OfficeStringId.MenuCmd_Zoom100Percent: return " 1";
                case OfficeStringId.MenuCmd_ZoomIn: return " 확대";
                case OfficeStringId.MenuCmd_ZoomInDescription: return " 확대";
                case OfficeStringId.MenuCmd_ZoomOut: return " 축소";
                case OfficeStringId.MenuCmd_ZoomOutDescription: return " 축소";
                case OfficeStringId.Msg_InternalError: return " 내부 오류가 발생 했습니다";
                case OfficeStringId.Msg_InvalidBeginInit: return " 오류: BeginUpdate 내부 BeginInit를 호출";
                case OfficeStringId.Msg_InvalidBeginUpdate: return " 오류: BeginUpdate BeginInit 내부 전화";
                case OfficeStringId.Msg_InvalidCopyFromDocumentModel: return " 오류: 원본 및 대상 문서 모델은 다른";
                case OfficeStringId.Msg_InvalidEndInit: return " 오류: EndInit 또는 CancelInit 없이 BeginInit 또는 BeginUpdate 내부 전화";
                case OfficeStringId.Msg_InvalidEndUpdate: return " 오류: EndUpdate 또는 CancelUpate BeginUpdate 없이 또는 BeginInit 내부 전화";
                case OfficeStringId.Msg_InvalidFontSize: return " {0}과 {1} 사이 여야 합니다.";
                case OfficeStringId.Msg_IsNotValid: return " ' {0} '은 '{1}'에 대 한 유효한 값이 아닌";
                case OfficeStringId.Msg_Loading: return " 로드 중...";
                case OfficeStringId.Msg_MagicNumberNotFound: return " 열려고하는 파일은 파일 확장명 표시 형식과 다릅니다.";
                case OfficeStringId.UnitAbbreviation_Percent: return " %";
                case OfficeStringId.MenuCmd_NewEmptyDocumentDescription: return "새로운 문서를 만듭니다.";
                case OfficeStringId.MenuCmd_QuickPrint: return " 빠른 인쇄";
                case OfficeStringId.MenuCmd_SaveDocumentDescription: return " 문서를 저장합니다.";
                case OfficeStringId.MenuCmd_PrintPreview: return "미리보기";
                case OfficeStringId.MenuCmd_Print: return " 인쇄";
                case OfficeStringId.MenuCmd_Encrypt: return " 암호로 문서 보호";
            }

            return base.GetLocalizedString(id);
        }

        ///// <summary>
        ///// Control에서 보여지는 Text를 설정합니다.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public override string GetLocalizedString(OfficeStringId id)
        //{
        //    switch (id)
        //    {
        //        case OfficeStringId.MenuCmd_NewEmptyDocument:
        //            return "새로 만들기";
        //        case OfficeStringId.MenuCmd_NewEmptyDocumentDescription:
        //            return "새로운 문서를 만듭니다.";
        //        case OfficeStringId.MenuCmd_QuickPrint:
        //            return "빠른 인쇄";
        //        case OfficeStringId.MenuCmd_LoadDocument:
        //            return "열기";
        //        case OfficeStringId.MenuCmd_LoadDocumentDescription:
        //            return "문서를 엽니다.";
        //        case OfficeStringId.MenuCmd_SaveDocument:
        //            return "저장";
        //        case OfficeStringId.MenuCmd_SaveDocumentDescription:
        //            return "문서를 저장합니다.";
        //        case OfficeStringId.MenuCmd_SaveDocumentAs:
        //            return "다른 이름으로 저장";
        //        case OfficeStringId.MenuCmd_PrintPreview:
        //            return "미리보기";
        //        case OfficeStringId.MenuCmd_Print:
        //            return "인쇄";
        //        case OfficeStringId.MenuCmd_Encrypt:
        //            return "암호로 문서 보호";
        //        case OfficeStringId.MenuCmd_Undo:
        //            return "실행 취소";
        //        case OfficeStringId.MenuCmd_Redo:
        //            return "다시 실행";
        //    }

        //    return base.GetLocalizedString(id);
        //}
    }
}
