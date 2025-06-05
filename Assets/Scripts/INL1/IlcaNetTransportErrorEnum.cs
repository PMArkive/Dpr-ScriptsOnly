namespace INL1
{
    public enum IlcaNetTransportErrorEnum : int
    {
        NotSessionInitialized = -1,
        AloneSession = -2,
        InvalidIlcaNetPacketType = -3,
        PacketWriterReNotUseUn = -4,
        SendSocketResultFailure = -5,
        SendSocketBufferFull = -6,
        InvalidStationIndex = -7,
        SessionInfoFuncFailure = -8,
        SendToSelf = -9,
        RecvCrash = -10,
        RecvSocketResultFailure = -11,
        PayloadZero = -12,
        NetGamerIsNotActive = -65,
        NetGamerIsNotHomeGamer = -66,
    }
}