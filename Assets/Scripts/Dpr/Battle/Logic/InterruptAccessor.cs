namespace Dpr.Battle.Logic
{
	public sealed class InterruptAccessor
	{
		private InterruptCode m_interrupt;
		
		public InterruptAccessor()
		{
			m_interrupt = InterruptCode.NONE;
		}
		
		// TODO
		public void Clear() { }
		
		// TODO
		public void Request(InterruptCode interrupt) { }
		
		// TODO
		public bool IsRequested(InterruptCode interrupt) { return default; }
		
		// TODO
		public bool IsRequested() { return default; }
		
		// TODO
		public InterruptCode GetRequest() { return default; }
	}
}