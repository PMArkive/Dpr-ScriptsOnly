namespace Dpr.Battle.Logic
{
	public static class ServerClientFactory
	{
		// TODO
		public static void CreateServerClient(in Input input, Output output) { }
		
		// TODO
		private static void InitOutput(Output output) { }
		
		// TODO
		private static void CreateLocalClients(in Input input, Output output) { }
		
		// TODO
		private static BTL_CLIENT CreateLocalClient(in Input input, BTL_SERVER server, BTL_CLIENT_ID clientId) { return default; }
		
		// TODO
		public static BTL_CLIENT CreateClientObject(in Input input, BTL_SERVER server, BTL_CLIENT_ID clientId, byte clientType) { return default; }
		
		// TODO
		public static Adapter CreateClientAdapter(in Input input, BTL_CLIENT_ID clientId, byte clientType) { return default; }
		
		// TODO
		private static void CreateDummyClients(in Input input, Output output) { }
		
		// TODO
		private static BTL_CLIENT CreateDummyClient(in Input input, BTL_SERVER server, BTL_CLIENT_ID clientId, BTL_CLIENT localClient) { return default; }
		
		// TODO
		private static void CreateRemoteClients(in Input input, Output output) { }
		
		// TODO
		private static void SetupCommandCheckServer(in Input input, Output output) { }

		public class Input
		{
			public AdapterFactory adapterFactory;
			public BtlRule rule;
			public BtlCommMode commMode;
			public BtlMultiMode multiMode;
			public BtlBagMode bagMode;
			public bool isRecordPlayMode;
			public BTL_CLIENT_ID myClientId;
			public bool amIServer;
			public ulong randomSeed;
			public MainModule mainModule;
			public BattleEnv battleEnvForServer;
			public BattleEnv battleEnvForClient;
			public SendDataContainer sendDataContainerForServerSend;
			public SendDataContainer[] sendDataContainerForClientSend = new SendDataContainer[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
			public SendDataContainer[] sendDataContainerForClientReceive = new SendDataContainer[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
		}

		public class Output
		{
			public BTL_SERVER server;
			public BTL_CLIENT[] localClients = new BTL_CLIENT[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
			public BTL_CLIENT[] dummyClients = new BTL_CLIENT[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
		}
	}
}