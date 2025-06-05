using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.DigFossil
{
	public class DigCursor : MonoBehaviour, IDigCursor
	{
		[SerializeField]
		private float speed = 40.0f;
		[SerializeField]
		private List<Sprite> toolSprites;
		[SerializeField]
		private Image tool;
		[SerializeField]
		private Image cursor;
		[SerializeField]
		private GameObject root;
		[SerializeField]
		private DigBoard board;
		[SerializeField]
		private Transform debugCursor;
		[SerializeField]
		private Text debugText;

        public OnClicked onClicked { get; set; }
        public bool IsOnTouchModeChanged { get; set; }
        public bool IsUse { get; set; }

        private Coroutine animationWaitCoroutine;
		private TweenerCore<Quaternion, Quaternion, NoOptions> tweenHandler;
		private Vector2 cursorPos = new Vector2(0.0f, 0.0f);
		private Vector2 fieldSize;
		private Quaternion toolDefaultRotation;
		private bool bIsTouchMode = true;
		
		public Transform effectRoot { get => root.transform; }
		
		// TODO
		public void OnUpdate() { }
		
		// TODO
		public void SetTool(bool bIsPickaxe) { }
		
		// TODO
		public void SetDisplay(bool bIsDisplay) { }
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public void DigPosition(Vector2 posiiton, bool bIsPickaxe) { }
		
		// TODO
		private void ClampAndUpdateCursorPos() { }
		
		// TODO
		private void OnClickToolAnimation() { }
		
		// TODO
		private IEnumerator AnimationWait(float time) { return default; }
		
		// TODO
		private Vector2 ScreenPosToBoardPos(Vector2 screenPos) { return default; }
		
		// TODO
		private bool CheckInsideBoradArea(Vector2 touchPos) { return default; }
		
		// TODO
		public void SetTouchMode(bool bIsTouchMode) { }

		public delegate void OnClicked(in Vector2 inPos);

		private enum SpriteIndex : int
		{
			Hummer = 0,
			Pickaxe = 1,
		}
	}
}