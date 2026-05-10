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
    public class PBandedGridHandler : DevExpress.XtraGrid.Views.BandedGrid.Handler.BandedGridHandler
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// Banded Grid Handler를 생성합니다.
        /// </summary>
        /// <param name="gridView"></param>
        public PBandedGridHandler(DevExpress.XtraGrid.Views.BandedGrid.BandedGridView gridView) : base(gridView) { }

        #endregion
    }
}
