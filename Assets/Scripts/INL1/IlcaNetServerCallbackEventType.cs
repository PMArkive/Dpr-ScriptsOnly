namespace INL1
{
	public enum IlcaNetServerCallbackEventType : int
	{
		NSAIDtokenGetAsync = 0,
		CheckValidateRequestAsync = 1,
		PublicKeyRequestAsync = 2,
		CheckSerialRequestAsync = 3,
		UpdateSerialRequestAsync = 4,
		ImmediateSyncRequestAsync = 5,
		MountStorageAsync = 6,
		FileReadAsync = 7,
	}
}