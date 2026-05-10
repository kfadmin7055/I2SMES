using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EBAP.Win.ControlLibrary.GridInfoHandler
{
    /// <summary>
    ///
    /// </summary>
    /// <remarks>
    /// 2016-06-17 최초생성 : 오인봉
    /// 변경내역
    ///
    /// </remarks>
    public class PBandedGridViewInfoRegistrator : DevExpress.XtraGrid.Registrator.BandedGridInfoRegistrator
    {
        #region :: ViewName :: 기본 GridView의 이름을 설정합니다.

        /// <summary>
        /// 기본 GridView의 이름을 설정합니다.
        /// </summary>
        public override string ViewName
        {
            get { return "PBandedGridView"; }
        }

        #endregion

        #region :: CreateView :: 기본 GridView를 생성합니다.

        /// <summary>
        /// 기본 BandedGridView를 생성합니다.
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public override DevExpress.XtraGrid.Views.Base.BaseView CreateView(DevExpress.XtraGrid.GridControl grid)
        {
            return new PBandedGridView(grid);
        }

        #endregion

        #region :: CreateViewInfo :: GridView를 생성합니다.

        /// <summary>
        /// BandedGridView를 생성합니다.
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public override DevExpress.XtraGrid.Views.Base.ViewInfo.BaseViewInfo CreateViewInfo(DevExpress.XtraGrid.Views.Base.BaseView view)
        {
            return new PGridViewInfo(view as PBandedGridView);
        }

        #endregion

        #region :: CreateHandler :: GridHandler를 생성합니다.

        /// <summary>
        /// GridHandler를 생성합니다.
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public override DevExpress.XtraGrid.Views.Base.Handler.BaseViewHandler CreateHandler(DevExpress.XtraGrid.Views.Base.BaseView view)
        {
            return new PBandedGridHandler(view as PBandedGridView);
        }

        #endregion
    }
}
