namespace Dpr.Battle.Logic
{
	public sealed class EffectSummarizer
	{
		private ServerCommandQueue m_pQueue;
		private ushort m_reservedPos_Effect;
		private ushort m_reservedPos_Message;
		
		public EffectSummarizer(ServerCommandQueue pQueue)
		{
			m_pQueue = pQueue;
			m_reservedPos_Effect = 0;
			m_reservedPos_Message = 0;
		}
		
		// TODO
		public void Reserve() { }
		
		// TODO
		public void Put(in GShockEffectParam param) { }
		
		// TODO
		private void put_Effect(in GShockEffectParam param) { }
		
		// TODO
		private void put_Message(in GShockEffectParam param) { }
	}
}