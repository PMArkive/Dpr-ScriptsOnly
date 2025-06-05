using System;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UnderGround
{
	public class UgEmoticonSet : MonoBehaviour
	{
		[SerializeField]
		private RectTransform cursorFrame;
		[SerializeField]
		private Image[] Icons;
		[SerializeField]
		private CanvasGroup group;

        public int nowIndex { get; set; }

        public Action<int> OnDeside;
		
		// TODO
		private void Awake() { }
		
		// TODO
		private void MyUpdate(float deltaTime) { }
		
		// TODO
		public void Open() { }
		
		// TODO
		public void Close(bool useInputActive = true) { }
		
		// TODO
		private void Next() { }
		
		// TODO
		private void Prev() { }
		
		// TODO
		private void UpdateCursor() { }
		
		// TODO
		private void OnDestroy() { }
	}
}