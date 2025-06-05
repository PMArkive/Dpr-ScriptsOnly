namespace Dpr.NetworkUtils
{
    public enum ErrorCodeID : uint
    {
        ErrorNSATokenAuth = 0,
        ErrorSerialServerMaintenance = 2,
        ErrorSerialServiceEnd = 4,
        ErrorSerialInvalidParameter = 6,
        ErrorSerialUnexpected = 8,
        ErrorSerialIntgernal = 10,
        ErrorConnectBCATServer = 12,
        ErrorDisconnectionServer = 14,
        ErrorTimeout = 15,
        ErrorDisconnectionP2P = 16,
        ErrorValidateServer = 47,
        ErrorValidateServerMaintenance = 48,
        ErrorDisconnectionSession = 49,
        ErrorVersion = 50,
        ErrorGMSCall = 100,
        ErrorGMSServer = 101,
        ErrorGMSEmpty = 102,
        ErrorInternetGoLogin = 200,
        FatalError = 9999,
        NUM = 10000,
    }
}