using System.Data;

namespace EBAP.Core.Interface
{
    /// <summary>
    /// 데이터 바인딩을 설정하는 Interface 입니다.
    /// </summary>
    public interface IBindings
    {
        /// <summary>
        /// 데이터 바인딩 멤버
        /// </summary>
        string BindingMember { get; set; }

        /// <summary>
        /// 데이터 바인딩 설정
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dataMember"></param>
        void BindingMapping(DataTable dt, string dataMember);
    }
}
