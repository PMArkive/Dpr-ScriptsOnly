using Dpr.MsgWindow;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;

namespace Dpr.UI
{
	public class UIMsgWindowController
	{
		private MsgWindow.MsgWindow msgWindow;
		private Action onCloseMsgWindow;
		private Action onFinishedContinueMessage;
		private bool isWaitMsgWindow;
		private Vector2? windowAnchorPosition;
		private MsgWindowParam msgWindowParam = new MsgWindowParam();
		private List<string> continueMessageLabels = new List<string>();
		private List<Action> continueMessageOnSets = new List<Action>();
		
		public bool isOpen { get => msgWindow != null; }
		
		// TODO
		public static string GetMessageFileName(MessageFileType messageFileType) { return default; }
		
		// TODO
		public void OpenMsgWindow(MessageFileType messageFileType, string labelName, [Optional] [DefaultParameterValue(true)] bool isWait, [Optional] [DefaultParameterValue(false)] bool isBatchDisplay, [Optional] Action onFinishedMessage, [Optional] Action onCloseWindow) { }
		
		// TODO
		public void OpenMsgWindow(string messageFileName, string labelName, [Optional] [DefaultParameterValue(true)] bool isWait, [Optional] [DefaultParameterValue(false)] bool isBatchDisplay, [Optional] Action onFinishedMessage, [Optional] Action onCloseWindow) { }
		
		// TODO
		public void OpenMsgWindow(MessageFileType messageFileType, string[] labelNames, Action[] onSets, [Optional] [DefaultParameterValue(true)] bool isWait, [Optional] [DefaultParameterValue(false)] bool isBatchDisplay, [Optional] Action onFinishedMessage, [Optional] Action onCloseWindow) { }
		
		// TODO
		public void OpenMsgWindow(string messageFileName, string[] labelNames, Action[] onSets, [Optional] [DefaultParameterValue(true)] bool isWait, [Optional] [DefaultParameterValue(false)] bool isBatchDisplay, [Optional] Action onFinishedMessage, [Optional] Action onCloseWindow) { }
		
		// TODO
		public void CloseMsgWindow() { }
		
		// TODO
		public void HideKeywaitIcon() { }
		
		// TODO
		public void SetAnchorPosition(Vector2? pos) { }
		
		// TODO
		public ContextMenuWindow.Param CreateContextMenuParam(MessageFileType messageFileType, string[] labelNames) { return default; }
		
		// TODO
		public ContextMenuWindow.Param CreateContextMenuParam(string messageFileName, string[] labelNames) { return default; }
		
		// TODO
		public void OpenContextMenu(ContextMenuWindow.Param param, Action<int> onSelect, [Optional] UnityAction<UIWindow> onClosed) { }
		
		// TODO
		public bool OnUpdate(float deltaTime) { return default; }
		
		// TODO
		private bool NextOpenMsgWindow() { return default; }

		public enum MessageFileType : int
		{
			Bag = 0,
			LevelUp = 1,
			Seal = 2,
			WazaRemember = 3,
			Zukan = 4,
			MysteryGift = 5,
			Evolve = 6,
		}
	}
}