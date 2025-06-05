namespace nn
{
	public static class Nn
	{
		internal const string DllName = "__Internal";

		// TODO
		public static extern void Abort(string message);
		
		// TODO
		public static void Abort(string message, object[] args) { }
		
		// TODO
		public static void Abort(bool condition, string message) { }
		
		// TODO
		public static void Abort(bool condition, string message, object[] args) { }
	}
}