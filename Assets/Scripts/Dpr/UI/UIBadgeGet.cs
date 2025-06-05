using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class UIBadgeGet : UIWindow
	{
		[SerializeField]
		private GameObject modelViewPrefab;
		[SerializeField]
		private RawImage modelViewRawImage;
		private GameObject modelViewObject;
		private BadgeGetViewController modelViewController;
		private int badgeNo;
		
		// TODO
		public override void OnCreate() { }
		
		// TODO
		public void Open(UIWindowID prevWindowId, int no) { }
		
		// TODO
		public IEnumerator OpOpen(UIWindowID prevWindowId) { return default; }
		
		// TODO
		public void Close(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { }
		
		// TODO
		public IEnumerator OpClose(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId) { return default; }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		private void StartBadgeGet()
		{
			// TODO
			IEnumerator BadgeGetFlow() { return default; }
        }
		
		// TODO
		private string GetBadgeAnimation() { return default; }
	}
}