using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Dpr.UI
{
	public class FloorWindow : UIWindow
	{
		[SerializeField]
		private UIText _number;
		
		// TODO
		public override void OnCreate() { }
		
		// TODO
		public void Open(FLOOR_DISPLAY floorId, UIWindowID prevWindowId) { }
		
		// TODO
		public IEnumerator OpOpen(FLOOR_DISPLAY floorId, UIWindowID prevWindowId) { return default; }
		
		// TODO
		public void Close(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { }
		
		// TODO
		public IEnumerator OpClose(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { return default; }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
	}
}