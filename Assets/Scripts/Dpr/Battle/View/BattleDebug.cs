using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Dpr.Battle.View
{
	public static class BattleDebug
	{
		private const string CONDITION = "DMY";
		private const string BATTLE_PRODUCT_NAME = "Battle";
		private const string MONITOR_LABEL_CMD = "Cmd";
		private const string MONITOR_LABEL_CMD_WAIT = "CmdWait";
		private const string MONITOR_LABEL_SUSPEND = "Suspend";

		private static Dictionary<string, Stopwatch> _stopwatches = new Dictionary<string, Stopwatch>();
		private static Stopwatch _stopwatch = new Stopwatch();
		public static bool isDisableLog;

        [Conditional(CONDITION)]
        public static void Log(object msg) { }

        [Conditional(CONDITION)]
        public static void NormalLog(object msg) { }

        [Conditional(CONDITION)]
        public static void LogWarning(object msg) { }

        [Conditional(CONDITION)]
        public static void LogSeq(object msg) { }

        [Conditional(CONDITION)]
        public static void LogError(object msg) { }

        [Conditional(CONDITION)]
        public static void LogErrorSeq(object msg) { }

        [Conditional(CONDITION)]
        public static void LogErrorSeqOldMacro(object oldEffect, object newEffect) { }

        [Conditional(CONDITION)]
        public static void Assert(bool condition) { }

        [Conditional(CONDITION)]
        public static void Assert(bool condition, object msg, bool isEditorPause = false) { }

        [Conditional(CONDITION)]
        public static void OutputMonitor(string label, object value, float life = 10.0f) { }

        [Conditional(CONDITION)]
        public static void OutputMonitorCmd(object value, float life = 10.0f) { }

        [Conditional(CONDITION)]
        public static void OutputMonitorCmdWait(object value, float life = 10.0f) { }

        [Conditional(CONDITION)]
        public static void OutputSuspend(object value, float life = 1.0f) { }
		
		[Conditional(CONDITION)]
		public static void FrameLog([Optional] object value) { }
		
		public static void StartStopwatch(string key)
		{
			if (!_stopwatches.ContainsKey(key))
				_stopwatches.Add(key, new Stopwatch());

			var sw = _stopwatches[key];
			if (sw.IsRunning)
				sw.Stop();

			sw.Reset();
			sw.Start();
		}
		
		public static void LapStopwatch(string key, string label = "")
		{
			_stopwatches.TryGetValue(key, out _);
		}
		
		public static void StopStopwatch(string key, string label)
		{
			if (_stopwatches.TryGetValue(key, out Stopwatch sw))
			{
				if (sw.IsRunning)
					sw.Stop();
			}
		}
	}
}