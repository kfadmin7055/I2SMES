using System.Data;

namespace EBAP.Core.Interface
{
    /// <summary>
    /// Database에서 컬럼 정보 설정 기능을 정의하는 Interface입니다.
    /// </summary>
    public interface IGridColumnSet
    {
        /// <summary>
        /// Database에서 컬럼 정보를 가져옵니다.
        /// </summary>
        /// <param name="gridName"></param>
        DataSet GetGridColumnSet(string gridName);

        /// <summary>
        /// Database에서 컬럼 정보를 가져옵니다.
        /// </summary>
        /// <param name="screenId"></param>
        /// <param name="gridName"></param>
        DataSet GetGridColumnSet(string screenId, string gridName);
    }
}
