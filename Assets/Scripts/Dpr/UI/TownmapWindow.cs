using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Dpr.UI
{
	public class TownmapWindow : TownmapWindowBase
	{
		[SerializeField]
		private Townmap _townmap;
		[SerializeField]
		private Cursor _cursor;
		[SerializeField]
		private GuideNavi _guide;
		[SerializeField]
		private TownmapFacility _facility;
		[SerializeField]
		private TownmapInfo _info;
		[SerializeField]
		private TownmapSymbolName _symbolName;

		private Townmap.NoticeType _noticeType = Townmap.NoticeType.None;
		private Param _param;
		
		// TODO
		public override void OnCreate() { }
		
		// TODO
		public void Open(Param param, UIWindowID prevWindowId) { }
		
		// TODO
		public IEnumerator OpOpen(Param param, UIWindowID prevWindowId) { return default; }
		
		// TODO
		private void SetupKeyguide(Townmap.Cell cell) { }
		
		// TODO
		protected override bool IsFly(Townmap.Cell cell) { return default; }
		
		// TODO
		public override void Close(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { }
		
		// TODO
		public IEnumerator OpClose(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { return default; }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		private void UpdateCursor() { }
		
		// TODO
		private void OnCellChanged(Townmap.Cell cell, bool isReset) { }
		
		// TODO
		private void OnNoticeChanged(Townmap.NoticeType type) { }

		[Serializable]
		private class GuideNavi
		{
			public RectTransform root;
			public UIText text;
		}

		public class Param
		{
			public Townmap.TownmapType type;
		}
	}
}