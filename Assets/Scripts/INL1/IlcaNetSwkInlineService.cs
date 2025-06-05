using System;

namespace INL1
{
	internal class IlcaNetSwkInlineService
	{
		private const int TextMaxLength = 500;

		private static byte[] SoftwareKeyboardTextBuff = new byte[2001];
		public static string SoftwareKeyboardText = "";
		
		// TODO
		public static void InitializeSoftwareKeyboardInlineCs(uint textMaxLength, int textMinLength, int HeapSize = 0x1000000, bool miniaturize = false, uint invalidButtonFlag = 0, uint invalidCharFlag = 0, bool isCancelButtonDisabled = false, bool isPredictionEnabled = false, bool isUseNewLine = false, uint keyboardMode = 0, short leftOptionalSymbolKey = 0, short rightOptionalSymbolKey = 0) { }
		
		// TODO
		public static UpdateSKICs UpdateSoftwareKeyboardInlineCs() { return default; }
		
		// TODO
		public static void FinalizeSoftwareKeyboardInlineCs() { }
		
		// TODO
		public static bool GetImageSoftwareKeyboardInlineCs(out IntPtr buff, out int size)
		{
			buff = default;
			size = default;
			return default;
		}

		public enum UpdateSKICs : int
		{
			RUNNING = 0,
			NORMALL_END = 1,
			CRASH_END = 2,
		}
	}
}