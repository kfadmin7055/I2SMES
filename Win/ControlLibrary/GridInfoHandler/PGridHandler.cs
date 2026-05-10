using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EBAP.Win.ControlLibrary.GridInfoHandler
{
    /// <summary>
    ///
    /// </summary>
    public class PGridHandler : DevExpress.XtraGrid.Views.Grid.Handler.GridHandler
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// Grid Handler를 생성합니다.
        /// </summary>
        /// <param name="gridView"></param>
        public PGridHandler(DevExpress.XtraGrid.Views.Grid.GridView gridView)
            : base(gridView)
        {

        }

        #endregion
    }
}
