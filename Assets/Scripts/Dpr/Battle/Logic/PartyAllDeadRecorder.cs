namespace Dpr.Battle.Logic
{
	public sealed class PartyAllDeadRecorder
	{
		public const byte DEAD_ORDER_NONE = 5;

		private byte[] m_partyAllDeadOrder = new byte[(int)BTL_CLIENT_ID.BTL_CLIENT_NUM];

        public PartyAllDeadRecorder()
		{
			Clear();
		}
		
		public void Clear()
		{
			m_partyAllDeadOrder[0] = DEAD_ORDER_NONE;
			m_partyAllDeadOrder[1] = DEAD_ORDER_NONE;
			m_partyAllDeadOrder[2] = DEAD_ORDER_NONE;
			m_partyAllDeadOrder[3] = DEAD_ORDER_NONE;
			m_partyAllDeadOrder[4] = DEAD_ORDER_NONE;
		}
		
		// TODO
		public void RecordPartyAllDead(byte clientID) { }
		
		// TODO
		public byte GetAllDeadOrder(byte clientID) { return default; }
	}
}