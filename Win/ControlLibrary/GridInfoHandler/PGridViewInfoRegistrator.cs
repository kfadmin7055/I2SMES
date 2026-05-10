using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EBAP.Win.ControlLibrary.GridInfoHandler
{
    /// <summary>
    ///
    /// </summary>
    public class PGridViewInfoRegistrator : DevExpress.XtraGrid.Registrator.GridInfoRegistrator
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: ViewName :: 기본 GridView의 이름을 설정합니다.

        /// <summary>
        /// 기본 GridView의 이름을 설정합니다.
        /// </summary>
        public override string ViewName
        {
            get { return "PGridView"; }
        }

        #endregion

        #region :: CreateView :: 기본 GridView를 생성합니다.

        /// <summary>
        /// 기본 GridView를 생성합니다.
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public override DevExpress.XtraGrid.Views.Base.BaseView CreateView(DevExpress.XtraGrid.GridControl grid)
        {
            return new PGridView(grid);
        }

        #endregion

        #region :: CreateViewInfo :: GridView를 생성합니다.

        /// <summary>
        /// GridView를 생성합니다.
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public override DevExpress.XtraGrid.Views.Base.ViewInfo.BaseViewInfo CreateViewInfo(DevExpress.XtraGrid.Views.Base.BaseView view)
        {
            return new PGridViewInfo(view as PGridView);
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
            return new PGridHandler(view as PGridView);
        }

        #endregion
    }
}
