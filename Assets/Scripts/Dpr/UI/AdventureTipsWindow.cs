using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class AdventureTipsWindow : AdventureBase
	{
		[SerializeField]
		private Image _image;
		[SerializeField]
		private UIText _text;
		[SerializeField]
		private UIText _title;
		
		// TODO
		public override void OnCreate() { }
		
		// TODO
		public void Open(AdventureNoteID category, UIWindowID prevWindowId) { }
		
		// TODO
		public IEnumerator OpOpen(AdventureNoteID category, UIWindowID prevWindowId) { return default; }
		
		// TODO
		public void Close(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { }
		
		// TODO
		public IEnumerator OpClose(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { return default; }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
	}
}