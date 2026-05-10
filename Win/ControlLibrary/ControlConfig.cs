using DevExpress.LookAndFeel;
using System.Drawing;

namespace EBAP.Win.ControlLibrary
{
    /// <summary>
    /// 
    /// </summary>
    internal class ControlConfig
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Font 및 Color, Width, Height
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: Font And Color, Width, Height ::

        /// <summary>
        /// Application에서 사용할 기본 Font입니다.
        /// Value : new Font("나눔고딕", 8.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
        /// </summary>
        internal static readonly Font DEFAULTFONT = new Font("나눔고딕", 8.75F);
        /// <summary>
        /// DropDown에서 사용할 기본 Font입니다.(약간 작은게 보기 좋음)
        /// Value : new Font("나눔고딕", 8.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
        /// </summary>
        internal static readonly Font DROPDOWNFONT = new Font("나눔고딕", 8.75F);
        /// <summary>
        /// Application에서 사용할 BOLD Font입니다.
        /// Value : new Font("나눔고딕", 8.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
        /// </summary>
        internal static readonly Font BOLDFONT = new Font("나눔고딕", 8.75F, FontStyle.Bold);
        /// <summary>
        /// Grid, Tree에서 데이터 수정이 되었을 때 사용할 Font입니다.
        /// Value : new Font("나눔고딕", 8.75F, FontStyle.Italic, GraphicsUnit.Point, ((byte)(0)));
        /// </summary>
        internal static readonly Font ITALICFONT = new Font("나눔고딕", 8.75F, FontStyle.Italic | FontStyle.Bold);
        /// <summary>
        /// Grid, Tree에서 데이터 삭제가 될 때 사용할 Font입니다.
        /// Value : new Font("나눔고딕", 8.75F, FontStyle.Strikeout, GraphicsUnit.Point, ((byte)(0)));
        /// </summary>
        //internal static readonly Font DELETEFONT = new Font("나눔고딕", 8.75F, FontStyle.Strikeout);
        internal static readonly Font DELETEFONT = new Font("나눔고딕", 8.75F, FontStyle.Bold);
        /// <summary>
        /// Grid, Tree에서 Unbound 컬럼에서 사용할 Font입니다.
        /// Value : new Font("나눔고딕", 8.75F, FontStyle.Strikeout, GraphicsUnit.Point, ((byte)(0)));
        /// </summary>
        //internal static readonly Font UNDERLINEFONT = new Font("나눔고딕", 8.75F, FontStyle.Strikeout);
        internal static readonly Font UNDERLINEFONT = new Font("나눔고딕", 8.75F, FontStyle.Underline);
        /// <summary>
        /// 
        /// </summary>
        //internal static readonly Color ADDEDROWCOLOR = Color.FromArgb(42, 93, 1);
        internal static readonly Color ADDEDROWCOLOR = DXSkinColors.FillColors.Success; //Color.FromArgb(230, 30, 115, 70);
        /// <summary>
        /// 
        /// </summary>
        //internal static readonly Color MODIFIEDROWCOLOR = Color.FromArgb(150, 143, 150);
        //internal static readonly Color MODIFIEDROWCOLOR = Color.FromArgb(50, 0, 0, 230);
        internal static readonly Color MODIFIEDROWCOLOR = DXSkinColors.FillColors.Question;//Color.FromArgb(190, 0, 0, 230);
        ///// <summary>
        ///// 
        ///// </summary>
        //internal static readonly Color FOCUSEDROWCOLOR = Color.FromArgb(40, 0, 0, 230);
        /// <summary>
        /// 
        /// </summary>
        internal static readonly Color DELETEROWCOLOR = DXSkinColors.FillColors.Danger;//Color.FromArgb(180, 170, 10, 10);
        ///// <summary>
        ///// 
        ///// </summary>
        ////internal static readonly Color MANDATORYBACKCOLOR = Color.FromArgb(200, 255, 240, 245); //레드계열
        //internal static readonly Color MANDATORYBACKCOLOR = DXSkinColors.FillColors.Danger;//그린계열
        /// <summary>
        /// 
        /// </summary>
        //internal static readonly Color MANDATORYBORDERCOLOR = Color.FromArgb(150, 255, 130, 130); // 레드계열
        internal static readonly Color MANDATORYBORDERCOLOR = DXSkinColors.FillColors.Warning;//그린계열
        /// <summary>
        /// 
        /// </summary>
        internal static readonly Color EMPTYCOLOR = Color.Empty;
        ///// <summary>
        ///// 
        ///// </summary>
        //internal static readonly Color SELECTEVENTBACKCOLOR = Color.FromArgb(210, 230, 245, 250);
        /// <summary>
        /// 
        /// </summary>
        internal static readonly Color SELECTEVENTBORDERCOLOR = DXSkinColors.FillColors.Primary;
        ///// <summary>
        ///// 
        ///// </summary>
        //internal static readonly Color SELECTEVENTFORECOLOR = Color.FromArgb(255, 35, 35, 35);
        /// <summary>
        /// 
        /// </summary>
        //internal static readonly Color HEADERBACKCOLOR = Color.FromArgb(255, 0, 120, 215);
        //internal static readonly Color HEADERBACKCOLOR = Color.FromArgb(255, 0, 170, 255);
        //internal static readonly Color HEADERBACKCOLOR = Color.FromArgb(255, 20, 110, 190); //블루 계열
        internal static readonly Color HEADERBACKCOLOR = DXSkinColors.FillColors.Primary;//Color.FromArgb(200, 16, 120, 120); //그린 계열
        //internal static readonly Color HEADERBACKCOLOR = Color.FromArgb(255, 200, 210, 225); //그레이 계열
        /// <summary>
        /// 
        /// </summary>
        internal static readonly Color FOOTERBACKCOLOR = Color.FromArgb(50, DXSkinColors.FillColors.Warning);
        /// <summary>
        /// 
        /// </summary>
        //internal static readonly Color SAVELAYOUTCOLOR = Color.FromArgb(250, 95, 0);
        internal static readonly Color SAVELAYOUTCOLOR = DXSkinColors.FillColors.Warning;//Color.FromArgb(255, 125, 105);
        /// <summary>
        /// 
        /// </summary>
        internal static readonly Color HEADERFORECOLOR = Color.White;
        //internal static readonly Color HEADERFORECOLOR = Color.FromArgb(250, 95, 0);
        //internal static readonly Color HEADERFORECOLOR = Color.FromArgb(55, 75, 95);
        /// <summary>
        /// 
        /// </summary>
        //internal static readonly Color VIEWCAPTIONFORECOLOR = Color.FromArgb(230, 20, 110, 190); //블루 계열
        internal static readonly Color VIEWCAPTIONFORECOLOR = DXSkinColors.FillColors.Primary;//Color.FromArgb(255, 16, 120, 120); //그린 계열
        /// <summary>
        /// Contorl의 기본 높이
        /// Value : 21
        /// </summary>
        internal const int DEFAULTHEIGHT = 25;

        /// <summary>
        /// Control의 기본 너비
        /// Value : 120
        /// </summary>
        internal const int DEFAULTWIDTH = 120;

        #endregion
    }
}
