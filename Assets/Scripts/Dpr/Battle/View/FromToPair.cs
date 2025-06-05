namespace Dpr.Battle.View
{
	public struct FromToPair<T>
	{
		public T from;
		public T to;
		
		public FromToPair(T from, T to)
		{
			this.from = from;
			this.to = to;
		}
	}
}