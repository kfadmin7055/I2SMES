using System.Data;

namespace EBAP.Core.Interface
{
    /// <summary>
    /// 컨트롤의 DataSource 를 초기화 하는 Method Interface 입니다.
    /// </summary>
    public interface IInitData
    {
        /// <summary>
        /// DataSource를 초기화합니다.
        /// </summary>
        /// <param name="valueList">값으로 사용할 List</param>
        /// <param name="displayList">보여지는 값으로 사용할 List</param>
        void InitData(object[] valueList, string[] displayList);
        /// <summary>
        /// DataSource를 초기화합니다.
        /// </summary>
        /// <param name="dt">DataSource</param>
        /// <param name="valueMember">Value Member</param>
        /// <param name="displayMember">Display Member</param>
        void InitData(DataTable dt, string valueMember, string displayMember);
    }
}
