namespace INL1
{
	public class IlcaNetSessionProperty
	{
		public ushort currentParticipantNum;
		public ushort participantNumMax;
		public bool isOpened;
		public bool isRestrictedByUserPassword;

		public const int IlcaNetApplicationDataSystemBufferSizeMax = 360;

		public byte[] applicationData = new byte[IlcaNetApplicationDataSystemBufferSizeMax];
		public uint applicationDataSize;
		public ulong targetPrincipalId;
	}
}