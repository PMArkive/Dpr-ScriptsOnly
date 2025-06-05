using Dpr.Message;
using nn.ngc;
using nn.swkbd;
using System;
using System.Reflection;
using System.Text;
using System.Threading;
using UnityEngine.Events;

namespace Dpr.UI
{
    public static class SoftwareKeyboard
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
        private static bool _isInitialized = false;
        private static Param _param = null;
        private static Func<string, ErrorState, (bool, string)> _onInputCheck = null;
        private static UnityAction<bool, string> _onComplete = null;
        private static string _resultText = null;
        private static ErrorState _errorState = ErrorState.None;
        private static bool _isCheckResult = true;
        private static ShowKeyboardArg _showKeyboardArg = new ShowKeyboardArg();
        private static ProfanityFilter.PatternList _patterns = 0;
        private const string _messageFileNameWhiteWords = "dlp_whitelist_monsname";
        private const string _messageFileName = "ss_strinput";
        private const int _maxNumberNum = 5;
        private static char _errorWhiteUnicode = '\u0020';
        private static int _disableErrorChecks = 0;
        private static MessageEnumData.MsgLangId _checkLangId = (MessageEnumData.MsgLangId)(-1);
        private const int _errorMessageArgIndex = 18;
        private static bool _isSuspendUnityThreads = false;
        private static bool _isThreadCall = false;
        private static bool _isMainThreadBlocked = false;
        private static ThreadParam _threadParam = null;
        private static SynchronizationContext _mainContext = null;
        private static int _mainThreadId = 0;
        private static MethodInfo _methodExecuteTasks = null;

        public static bool isInitialized { get => _isInitialized; }
        public static Func<string, ErrorState, (bool, string)> onInputCheck { get => _onInputCheck; }
        public static UnityAction<bool, string> onComplete { get => _onComplete; }
        public static string resultText { get => _resultText; }
        public static ErrorState errorState { get => _errorState; }
        public static bool isCheckResult { get => _isCheckResult; }

        public static void Initialize()
        {
#if SWITCH
            if (_isInitialized)
                return;

            _isInitialized = true;
            _mainContext = SynchronizationContext.Current;
            _mainThreadId = Thread.CurrentThread.ManagedThreadId;
            _methodExecuteTasks = _mainContext.GetType().GetMethod("ExecuteTasks", BindingFlags.NonPublic | BindingFlags.Static);

            if (_threadParam == null)
            {
                _threadParam = new ThreadParam();
                _threadParam.Create();
            }

            // TODO: nn stuff
            //_showKeyboardArg.Initialize(false, true);
            //_patterns = _showKeyboardArg.GetLanguagePatternAll();

            if (MessageManager.isInstantiated)
            {
                _ = MessageManager.Instance.IsInitialize;
            }
#endif
        }

        public static string GetMessageText(string messageLabel)
        {
            var msgFile = MessageManager.Instance.GetMsgFile(_messageFileName);

            if (msgFile == null)
                return "_msgFile is Null";

            var dataModel = msgFile.GetTextDataModel(messageLabel);
            dataModel.ApplyFormat();
            return dataModel.GetAllText();
        }

        private static bool IsDisableCheck(ErrorCheck checkBit)
        {
            return (_disableErrorChecks & (int)checkBit) != 0;
        }

        private static bool CheckWhiteSpace(string text)
        {
            if (IsDisableCheck(ErrorCheck.WhiteSpace) || string.IsNullOrEmpty(text))
                return true;

            return text.Trim().Length > 0;
        }

        private static bool CheckNumbers(string text)
        {
            if (IsDisableCheck(ErrorCheck.NumberCount))
                return true;

            int count = 0;
            for (int i=0; i<text.Length; i++)
            {
                char c = text[i];
                if (c >= '0' && c <= '9')
                    count++;
            }

            return count <= _maxNumberNum;
        }

        private static bool CheckWhiteUnicodes(string text)
        {
            var hashset = UIManager.Instance.GetInputLimitHashSet(_checkLangId);

            for (int i=0; i<text.Length; i++)
            {
                char c = text[i];
                if (!hashset.Contains(c))
                    return false;
            }

            return true;
        }

        private static bool CheckWhiteWords(string text)
        {
            var msgFile = MessageManager.Instance.GetMsgFile(_messageFileNameWhiteWords, _checkLangId);

            for (int i=0; i<msgFile.GetTotalTextNum(); i++)
            {
                if (msgFile.GetSimpleMessage(i) == text)
                    return true;
            }

            return false;
        }

        public static void Terminate()
        {
            //Swkbd.Destroy(ref _showKeyboardArg);

            if (_threadParam != null)
            {
                _threadParam.thread.Abort();
                _threadParam.callEvent.Dispose();
                _threadParam = null;
            }

            _isInitialized = false;
        }

        public static bool Open(Param param, Func<string, ErrorState, ValueTuple<bool, string>> onInputCheck, UnityAction<bool, string> onComplete)
        {
#if SWITCH
            if (_threadParam.isActived)
            {
                onComplete.Invoke(false, null);
                return false;
            }

            _param = param;
            _onInputCheck = onInputCheck;
            _onComplete = onComplete;
            _errorState = ErrorState.None;
            _isCheckResult = true;
            _isThreadCall = NetworkManager.IsConnect;

            if (_isThreadCall)
            {
                _isMainThreadBlocked = true;
                _threadParam.isActived = true;
                _threadParam.callEvent.Set();
            }
            else
            {
                _isMainThreadBlocked = false;
                OpenInternal();
            }

            var akInit = AudioManager.Instance.GetComponent<AkInitializer>();
            while (true)
            {
                if (!_isMainThreadBlocked)
                    break;

                NetworkManager.Instance.OnUpdate(0.03333334f);
                _methodExecuteTasks?.Invoke(null, null);
                akInit.LateUpdate();
                Thread.Sleep(33);
            }

            return true;
#else
            onComplete.Invoke(true, "Decomp");
            return true;
#endif
        }

        private static void WakerOpen(object obj)
        {
            var param = obj as ThreadParam;

            while (true)
            {
                param.callEvent.WaitOne();
                OpenInternal();
                param.isActived = false;
            }
        }

        private static void MainThreadPost(UnityAction onCallback, bool isSleep = false)
        {
            if (!_isThreadCall)
                onCallback.Invoke();

            bool isComplete = false;
            _mainContext.Post(__ =>
            {
                onCallback.Invoke();
                isComplete = true;
            }, null);

            if (isSleep)
            {
                while (!isComplete)
                    Thread.Sleep(1);
            }
        }

        // TODO
        private static void OpenInternal()
        {
            //Swkbd.InitializeKeyboardConfig(_showKeyboardArg);
        }

        private static KeyboardMode GetKeyboardMode()
        {
            if (_param.keyboardMode == KeyboardMode.Max)
                return GetLanguageKeyboardMode();

            return _param.keyboardMode;
        }

        private static KeyboardMode GetLanguageKeyboardMode()
        {
            switch (UIManager.GetCurrentLangId())
            {
                case MessageEnumData.MsgLangId.JPN:
                    return KeyboardMode.LanguageSet1;

                case MessageEnumData.MsgLangId.USA:
                case MessageEnumData.MsgLangId.FRA:
                case MessageEnumData.MsgLangId.ITA:
                case MessageEnumData.MsgLangId.DEU:
                case MessageEnumData.MsgLangId.ESP:

                case MessageEnumData.MsgLangId.KOR:
                    return KeyboardMode.Korean;

                case MessageEnumData.MsgLangId.SCH:
                    return KeyboardMode.SimplifiedChinese;

                case MessageEnumData.MsgLangId.TCH:
                    return KeyboardMode.TraditionalChinese;

                default:
                    return KeyboardMode.Alphabet;
            }
        }

        internal static void _SetCheckResult(bool isCheckResult)
        {
            _isCheckResult = isCheckResult;
        }

        internal static void _SetResult(bool isSuccess, string resultText)
        {
            _resultText = resultText;
            MainThreadPost(() =>
            {
                _onComplete.Invoke(isSuccess, resultText);
                _onComplete = null;
                _onInputCheck = null;
                _isMainThreadBlocked = false;
            }, false);
        }

        // TODO
        private static ProfanityFilter.PatternList GetLanguagePatternAll() { return ProfanityFilter.PatternList.Japanese; }

        // TODO: This normally has the MonoPInvokeCallback attribute, see if it's automatically added by compiler
        private static TextCheckResult TextCheckCallback(IntPtr textBuf, ref long length, ref nn.swkbd.String str) { return default; }

        internal static int _GetDisableErrorChecks()
        {
            if (_param == null)
                return _disableErrorChecks | (int)ErrorCheck.NumberCount;

            if (_param.keyboardMode != KeyboardMode.Numeric)
                return _disableErrorChecks;

            return _disableErrorChecks | (int)ErrorCheck.NumberCount;
        }

        // TODO
        private static TextCheckResult _TextCheckCallbackImpl(IntPtr textBuf, ref long length, string input, Encoding encoding) { return default; }

        public static ErrorState CheckNgWords(ref string resultText, int disableErrorChecks = 0, MessageEnumData.MsgLangId langId = (MessageEnumData.MsgLangId)(-1))
        {
            return _CheckNgWords(ref resultText, disableErrorChecks, langId);
        }

        private static ErrorState _CheckNgWords(ref string resultText, int disableErrorChecks, MessageEnumData.MsgLangId langId)
        {
            if (langId < MessageEnumData.MsgLangId.JPN)
                langId = UIManager.GetCurrentLangId();

            _checkLangId = langId;
            _disableErrorChecks = disableErrorChecks;

            _errorState = ErrorState.None;
            _errorState = CheckWhiteSpace(resultText) ? ErrorState.None : ErrorState.WhiteSpace;

            if (_errorState == ErrorState.None)
                _errorState = CheckNumbers(resultText) ? ErrorState.None : ErrorState.NumberCount;

            if (_errorState == ErrorState.None)
                _errorState = CheckWhiteUnicodes(resultText) ? ErrorState.None : ErrorState.WhiteUnicode;

            if (_errorState == ErrorState.None && !IsDisableCheck(ErrorCheck.WhiteUnicode))
            {
                if (!CheckWhiteWords(resultText) && CheckNgc(ref resultText))
                    _errorState = ErrorState.NgWord;
            }

            return _errorState;
        }

        // TODO
        private static bool CheckNgc(ref string resultText, bool isMaskResult = false) { return false; }

        public static int LanguageMaxLength(int maxLength, MessageEnumData.MsgLangId langId = (MessageEnumData.MsgLangId)(-1))
        {
            if (langId < MessageEnumData.MsgLangId.JPN)
                langId = UIManager.GetCurrentLangId();

            switch (langId)
            {
                case MessageEnumData.MsgLangId.JPN:
                case MessageEnumData.MsgLangId.KOR:
                case MessageEnumData.MsgLangId.SCH:
                case MessageEnumData.MsgLangId.TCH:
                    return maxLength;

                default:
                    return maxLength << 1;
            }
        }

        public static (bool, string) InputCheck(string resultText, ErrorState errorState)
        {
            string errorMsg;

            switch (errorState)
            {
                case ErrorState.WhiteSpace:
                    errorMsg = GetMessageText("SS_strinput_004");
                    break;

                case ErrorState.NumberCount:
                    errorMsg = GetMessageText("SS_strinput_035");
                    break;

                case ErrorState.WhiteUnicode:
                    MessageWordSetHelper.SetStringWord(_errorMessageArgIndex, string.Format("{0}", _errorWhiteUnicode));
                    errorMsg = GetMessageText("SS_strinput_003");
                    break;

                case ErrorState.NgWord:
                    errorMsg = GetMessageText("SS_strinput_002");
                    break;

                default:
                    errorMsg = null;
                    break;
            }

            return (string.IsNullOrEmpty(errorMsg), errorMsg);
        }

        public enum Preset : int
        {
            Default = 0,
            Password = 1,
            UserName = 2,
            DownloadCode = 3,
            Custom = 4,
            Max = 5,
        }

        public enum KeyboardMode : int
        {
            LanguageSet1 = 0,
            Numeric = 1,
            ASCII = 2,
            LanguageSet1Latin = 3,
            Alphabet = 4,
            SimplifiedChinese = 5,
            TraditionalChinese = 6,
            Korean = 7,
            LanguageSet2 = 8,
            Max = 9,
            Full = 0,
            FullLatin = 3,
            Auto = 9,
        }

        [Flags]
        public enum InvalidChar : int
        {
            Space = 2,
            AtMark = 4,
            Percent = 8,
            Slash = 16,
            BackSlash = 32,
            Numeric = 64,
            OutsideOfDownloadCode = 128,
            OutsideOfMiiNickName = 256,
            Force32 = -1,
        }

        public enum InitialCursorPos : int
        {
            First = 0,
            Last = 1,
            Max = 2,
        }

        public enum PasswordMode : int
        {
            Show = 0,
            Hide = 1,
            Max = 2,
        }

        public enum InputFormMode : int
        {
            OneLine = 0,
            MultiLine = 1,
            Separate = 2,
            Max = 3,
        }

        public class Param
        {
            public Preset preset = Preset.Custom;
            public KeyboardMode keyboardMode = KeyboardMode.Max;
            public bool isPredictionEnabled;
            public InvalidChar invalidCharFlag;
            public InitialCursorPos initialCursorPos;
            public int textMaxLength = 16;
            public int textMinLength = 1;
            public PasswordMode passwordMode;
            public InputFormMode inputFormMode;
            public bool isUseNewLine;
            public bool isUseBlurBackground = true;
            public int[] separateTextPos;
            public string text;
            public string guideText;
            public string headerText;
            public string subText;
            public string okText;
            public int disableErrorChecks;
        }

        public enum ErrorState : int
        {
            None = 0,
            WhiteSpace = 1,
            NumberCount = 2,
            WhiteUnicode = 3,
            NgWord = 4,
        }

        [Flags]
        public enum ErrorCheck : int
        {
            None = 0,
            WhiteSpace = 2,
            NumberCount = 4,
            WhiteUnicode = 8,
            NgWord = 16,
        }

        private class ThreadParam
        {
            public Thread thread;
            public AutoResetEvent callEvent;
            public bool isActived;

            public void Create()
            {
                thread = new Thread(WakerOpen);
                callEvent = new AutoResetEvent(false);
                thread.IsBackground = true;
                thread.Priority = ThreadPriority.Lowest;
                thread.Start(this);
            }

            public void Remove()
            {
                _threadParam.thread.Abort();
                callEvent.Dispose();
            }

            public void Call()
            {
                _threadParam.isActived = true;
                _threadParam.callEvent.Set();
            }
        }
    }
}
