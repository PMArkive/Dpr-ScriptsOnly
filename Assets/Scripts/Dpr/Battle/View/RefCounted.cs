namespace Dpr.Battle.View
{
	public sealed class RefCounted
	{
		public int referencedCount;
		
		public int AddRef()
		{
			return ++referencedCount;
		}
		
		public int Release()
		{
			return --referencedCount;
		}
	}
}