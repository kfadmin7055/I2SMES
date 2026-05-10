using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EBAP.Win.ControlLibrary.GridInfoHandler
{
    /// <summary>
    ///
    /// </summary>
    public class PGridViewInfo : DevExpress.XtraGrid.Views.Grid.ViewInfo.GridViewInfo
    {
        #region :: 생성자 ::

        /// <summary>
        /// GridView의 정보를 생성합니다.
        /// <param name="gridView"></param>
        /// </summary>
        public PGridViewInfo(DevExpress.XtraGrid.Views.Grid.GridView gridView)
            : base(gridView)
        {
        }

        #endregion
    }
}
