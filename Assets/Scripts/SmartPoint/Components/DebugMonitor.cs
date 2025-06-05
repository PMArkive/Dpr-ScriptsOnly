using SmartPoint.AssetAssistant;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

namespace SmartPoint.Components
{
	[RequireComponent(typeof(RectTransform), typeof(Canvas), typeof(CanvasScaler))]
	[DisallowMultipleComponent]
	public class DebugMonitor : SingletonMonoBehaviour<DebugMonitor>
	{
		[SerializeField]
		private GameObject _menu;
		[SerializeField]
		private LayoutScrollView _mainMonitor;
		[SerializeField]
		private LayoutScrollView _subMonitor;
		[SerializeField]
		private ToggleButton _toggleButton;
		[SerializeField]
		private bool _expandLog;
		[SerializeField]
		private bool _displayOnStart;
		[SerializeField]
		private bool _displayOnError = true;
		[SerializeField]
		private bool _displayWatch;
		[SerializeField]
		private bool _isVisible = true;

		public const int MaxLogCount = 256;

		private string _lastCondition;
		private bool _forceDisplay;
		private bool _press;
		private float _remainTime;

		private static List<LogElement> _watchList = new List<LogElement>();
		private static Dictionary<string, LogElement> _watches = new Dictionary<string, LogElement>();

		private int _nextLogID;
		
		public static string logPath { get => Application.isEditor ? "./Logs/DebugMonitor" : (Application.persistentDataPath + "/Logs/DebugMonitor"); }
		
		// TODO
		public static bool isVisible { get; set; }
		
		// TODO
		public static bool displayWatch { get; set; }
		
		// TODO
		protected override bool Awake() { return default; }
		
		// TODO
		private void Start() { }
		
		// TODO
		private void OnEnable() { }
		
		// TODO
		private void OnDisable() { }
		
		// TODO
		public void OnFliterValueChanged(string value) { }
		
		// TODO
		public void ToggleSubMonitor() { }
		
		// TODO
		private void UpdateSubMonitor() { }
		
		// TODO
		public void Close() { }
		
		// TODO
		public void ClearLog() { }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		public static void Show() { }
		
		// TODO
		public static void ShowToggle() { }
		
		// TODO
		[Conditional("ENABLE_DEBUGMONITOR")]
		public static void Output(string label, object value, float life = 10.0f) { }
		
		// TODO
		[Conditional("ENABLE_DEBUGMONITOR")]
		public static void Subscribe(string label, Func<object> getter, float life = -1.0f) { }
		
		// TODO
		[Conditional("ENABLE_DEBUGMONITOR")]
		public static void Subscribe(string label, object value, float life = -1.0f) { }
		
		// TODO
		public static void Unsubscribe(string label) { }
		
		// TODO
		private void LogCallback(string condition, string stackTrace, LogType type) { }
		
		// TODO
		private static string OmittedStackTrace(string stackTrace) { return default; }

		[Serializable]
		public class LogElement
		{
			public string condition;
			public string stackTrace;
			public bool expand;
			public LogType type;
			public int lineCount;
			public bool autoErase;
			public float life;
			public WeakReference reference;
		}
	}
}