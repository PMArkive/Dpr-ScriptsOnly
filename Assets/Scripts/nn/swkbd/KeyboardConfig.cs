using System;

namespace nn.swkbd
{
	public struct KeyboardConfig
	{
		public KeyboardMode keyboardMode;
		public string okText;
		public char leftOptionalSymbolKey;
		public char rightOptionalSymbolKey;
		public bool isPredictionEnabled;
		public InvalidChar invalidCharFlag;
		public InitialCursorPos initialCursorPos;
		public string headerText;
		public string subText;
		public string guideText;
		public int textMaxLength;
		public int textMinLength;
		public PasswordMode passwordMode;
		public InputFormMode inputFormMode;
		public bool isUseNewLine;
		public bool isUseUtf8;
		public bool isUseBlurBackground;
		private int _initialStringOffset;
		private int _initialStringLength;
		private int _userDictionaryOffset;
		private int _userDictionaryNum;
		private bool _isUseTextCheck;
		private IntPtr _textCheckCallback;
		public int[] separateTextPos;
		private DictionaryInfo[] _customizedDicInfoList;
		private byte _customizedDicCount;
		private byte[] _reserved;
	}
}