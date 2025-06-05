namespace nn.oe
{
	public static class Language
	{
		private static extern _LanguageCode _GetDesired();
		
		// TODO
		public static string GetDesired() { return default; }

		private struct _LanguageCode
		{
			internal char[] _string;
		}
	}
}