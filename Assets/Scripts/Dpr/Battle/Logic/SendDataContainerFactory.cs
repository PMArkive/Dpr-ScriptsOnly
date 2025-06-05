namespace Dpr.Battle.Logic
{
	public static class SendDataContainerFactory
	{
		private const uint CONTAINER_BUFFER_NUM = 2;

		private static SendDataContainer s_containerForServerSend;
		private static SendDataContainer[] s_containerForClientSend = new SendDataContainer[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];
		private static SendDataContainer[] s_containerForClientRecieve = new SendDataContainer[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];

        // TODO
        public static void CreateContainer() { }
		
		// TODO
		public static void DeleteContainer() { }
		
		// TODO
		public static SendDataContainer GetServerSendContainer() { return default; }
		
		// TODO
		public static SendDataContainer GetClientSendContainer(BTL_CLIENT_ID clientId) { return default; }
		
		// TODO
		public static SendDataContainer GetClientReceiveContainer(BTL_CLIENT_ID clientId) { return default; }
	}
}