using EBAP.Core.Collections;
using System.Data;

namespace EBAP.Core.Async
{
    /// <summary>
    /// [비동기 처리] DB Query Master에서 쿼리를 실행하여 DataSet을 반환하는 Web Method를 실행합니다.
    /// </summary>
    /// <param name="queryid"></param>
    /// <param name="param"></param>
    /// <returns></returns>
    public delegate DataSet AsyncMethodCaller(string queryid, ParamCollection param);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public delegate DataSet MethodCaller();
}
