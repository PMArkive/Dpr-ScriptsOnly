using System.Runtime.InteropServices;
using System.Text;

namespace nn.swkbd
{
	public static class Swkbd
	{
		public const int TextMaxLength = 500;
		public const int SeparateModeTextMaxLength = 24;
		public const int HeaderTextMaxLength = 64;
		public const int SubTextMaxLength = 128;
		public const int GuideTextMaxLength = 256;
		public const int OkTextMaxLength = 8;
		public const int UnfixedStringLengthMax = 24;
		public const int UserWordMax = 5000;
		public const int DialogTextMaxLength = 500;
		public const int SepareteTextPosMax = 8;
		public const int CustomizedDicionarySetMax = 24;
		
		// TODO
		public static Result ShowKeyboard(StringBuilder pOutResultString, ShowKeyboardArg showKeyboardArg, bool suspendUnityThreads) { return default; }
		
		// TODO
		public static Result ShowKeyboard(byte[] pOutResultString, ShowKeyboardArg showKeyboardArg, bool suspendUnityThreads) { return default; }
		
		// TODO
		public static Result ShowKeyboard(StringBuilder pOutResultString, ShowKeyboardArg showKeyboardArg) { return default; }
		
		// TODO
		public static Result ShowKeyboard(byte[] pOutResultString, ShowKeyboardArg showKeyboardArg) { return default; }

		private static extern Result ShowKeyboard([In] [Out] StringBuilder pOutResultString, long bufSize, ShowKeyboardArg showKeyboardArg);
		private static extern Result ShowKeyboard([In] [Out] byte[] pOutResultString, long bufSize, ShowKeyboardArg showKeyboardArg);
		public static extern void InitializeKeyboardConfig(ref KeyboardConfig pOutKeyboardConfig);
		public static extern void MakePreset(ref KeyboardConfig pOutKeyboardConfig, Preset preset);
		public static extern long GetRequiredStringBufferSize();
		public static extern void SetLeftOptionalSymbolKey(ref KeyboardConfig pOutKeyboardConfig, char code);
		public static extern void SetLeftOptionalSymbolKeyUtf8(ref KeyboardConfig pOutKeyboardConfig, [In] byte[] code);
		public static extern void SetRightOptionalSymbolKey(ref KeyboardConfig pOutKeyboardConfig, char code);
		public static extern void SetRightOptionalSymbolKeyUtf8(ref KeyboardConfig pOutKeyboardConfig, [In] byte[] code);
		public static extern void SetOkText(ref KeyboardConfig pOutKeyboardConfig, [In] string pStr);
		public static extern void SetOkTextUtf8(ref KeyboardConfig pOutKeyboardConfig, [In] byte[] pStr);
		public static extern void SetHeaderText(ref KeyboardConfig pOutKeyboardConfig, [In] string pStr);
		public static extern void SetHeaderTextUtf8(ref KeyboardConfig pOutKeyboardConfig, [In] byte[] pStr);
		public static extern void SetSubText(ref KeyboardConfig pOutKeyboardConfig, [In] string pStr);
		public static extern void SetSubTextUtf8(ref KeyboardConfig pOutKeyboardConfig, [In] byte[] pStr);
		public static extern void SetGuideText(ref KeyboardConfig pOutKeyboardConfig, [In] string pStr);
		public static extern void SetGuideTextUtf8(ref KeyboardConfig pOutKeyboardConfig, [In] byte[] pStr);
		public static extern void SetInitialText(ref ShowKeyboardArg pOutShowKeyboardArg, [In] string pStr);
		public static extern void SetInitialTextUtf8(ref ShowKeyboardArg pOutShowKeyboardArg, [In] byte[] pStr);
		public static extern void SetUserWordList(ref ShowKeyboardArg pOutShowKeyboardArg, [In] UserWord[] pUserWord, int userWordNum);
		public static extern void SetTextCheckCallback(ref ShowKeyboardArg pOutShowKeyboardArg, [In] TextCheckCallback pCallback);
		public static extern void SetCustomizedDictionaries(ref ShowKeyboardArg pOutShowKeyboardArg, CustomizedDictionarySet dicSet);
		public static extern void Initialize(ref ShowKeyboardArg pOutShowKeyboardArg, bool useDirectory, bool useTextCheck);
		
		// TODO
		public static void Initialize(ref ShowKeyboardArg pOutShowKeyboardArg, bool useDirectory) { }
		
		// TODO
		public static void Initialize(ref ShowKeyboardArg pOutShowKeyboardArg) { }

		public static extern void Initialize(ref ShowKeyboardArg pOutShowKeyboardArg, int userWordNum, bool useTextCheck);
		
		// TODO
		public static void Initialize(ref ShowKeyboardArg pOutShowKeyboardArg, int userWordNum) { }

		public static extern void Destroy(ref ShowKeyboardArg pOutShowKeyboardArg);
		
		// TODO
		private static int GetByteSize(StringBuilder sb) { return default; }
		
		// TODO
		public static ErrorRange ResultCanceled { get; }
	}
}