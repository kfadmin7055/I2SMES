using System;

namespace EBAP.Win.Utility
{
    /// <summary>
    /// InternetConnectionState
    /// </summary>
    [Flags]
    public enum InternetConnectionState : int
    {
        /// <summary>
        ///
        /// </summary>
        INTERNET_CONNECTION_CONFIGURED = 0x40,
        /// <summary>
        ///
        /// </summary>
        INTERNET_CONNECTION_LAN = 0x2,
        /// <summary>
        ///
        /// </summary>
        INTERNET_CONNECTION_MODEM = 0x1,
        /// <summary>
        ///
        /// </summary>
        INTERNET_CONNECTION_OFFLINE = 0x20,
        /// <summary>
        ///
        /// </summary>
        INTERNET_CONNECTION_PROXY = 0x4,
        /// <summary>
        ///
        /// </summary>
        INTERNET_RAS_INSTALLED = 0x10
    }
}
