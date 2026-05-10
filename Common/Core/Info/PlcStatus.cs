using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBAP.Core.Info
{
    /// <summary>
    ///  PLC 접속 상태
    /// </summary>
    public enum PlcStatus
    {
        Disconnected,
        Connecting,
        Connected
    }
}
