using System;
using System.Runtime.InteropServices;

namespace nn.ngc
{
	public sealed class ProfanityFilter : IDisposable
	{
		private IntPtr _profanityFilter;
		private IntPtr _ngcWorkBuffer;
		
		// TODO
		public ProfanityFilter() { }
		
		// TODO
		public ProfanityFilter(bool checkDesiredLanguage) { }
		
		// TODO
		~ProfanityFilter() { }
		
		// TODO
		public void Dispose() { }
		
		// TODO
		private void Dispose(bool disposing) { }
		
		// TODO
		public uint GetContentVersion() { return default; }
		
		// TODO
		public Result CheckProfanityWords([Out] PatternList[] checkResults, PatternList patterns, string[] words) { return default; }
		
		// TODO
		public Result MaskProfanityWordsInText(ref int profanityWordCount, string inText, out string outText, PatternList patterns)
		{
			outText = default;
			return default;
		}
		
		// TODO
		public void SetMaskMode(MaskMode mode) { }
		
		// TODO
		public void SkipAtSignCheck(SkipMode skipMode) { }

		private static extern void Destroy(IntPtr profanityFilter, IntPtr ngcWorkBuffer);
		private static extern Result Initialize(ref IntPtr profanityFilter, ref IntPtr ngcWorkBuffer, bool checkDesiredLanguage);
		private static extern uint GetContentVersion(IntPtr profanityFilter);
		private static extern Result CheckProfanityWords(IntPtr profanityFilter, [Out] PatternList[] checkResults, PatternList patterns, string[] words, long wordCount);
		private static extern Result MaskProfanityWordsInText(IntPtr profanityFilter, ref int profanityWordCount, string text, PatternList patterns);
		private static extern void SetMaskMode(IntPtr profanityFilter, MaskMode mode);
		private static extern void SkipAtSignCheck(IntPtr profanityFilter, SkipMode skipMode);

		public enum MaskMode : int
		{
			OverWrite = 0,
			ReplaceByOneCharacter = 1,
		}

		public enum SkipMode : int
		{
			NotSkip = 0,
			SkipAtSign = 1,
		}

		[Flags]
		public enum PatternList : int
		{
			Japanese = 1,
			AmericanEnglish = 2,
			CanadianFrench = 4,
			LatinAmericanSpanish = 8,
			BritishEnglish = 16,
			French = 32,
			German = 64,
			Italian = 128,
			Spanish = 256,
			Dutch = 512,
			Korean = 1024,
			SimplifiedChinese = 2048,
			Portuguese = 4096,
			Russian = 8192,
			BrazilianPortuguese = 16384,
			TraditionalChinese = 32768,
			Max = 16,
		}
	}
}