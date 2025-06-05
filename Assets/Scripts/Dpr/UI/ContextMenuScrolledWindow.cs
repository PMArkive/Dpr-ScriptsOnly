using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class ContextMenuScrolledWindow : UIWindow
	{
		[SerializeField]
		private RectTransform _windowRoot;
		[SerializeField]
		private RectTransform _contentRoot;
		[SerializeField]
		private Cursor _cursor;
		[SerializeField]
		private Image _imageBg;
		[SerializeField]
		private MenuWindowParam[] _windowParams;
		[SerializeField]
		protected UIScrollView _itemListScrollView;

		private readonly int _animStateIn = Animator.StringToHash("in");
		private readonly int _animStateOut = Animator.StringToHash("out");

        private VerticalLayoutGroup _verticalLayoutGroup;
		private ContextMenuItem _selectItem;
		public Func<ContextMenuItem, bool> onClicked;
		public UnityAction<ContextMenuItem> onSelectChanged;
		private Param _param;
		
		public ContextMenuItem selectItem { get => _selectItem; }
		
		// TODO
		public void Awake() { }
		
		// TODO
		public void Open(Param param) { }
		
		// TODO
		public IEnumerator OpOpen(Param param) { return default; }
		
		// TODO
		public void Close(UnityAction<UIWindow> onClosed_) { }
		
		// TODO
		public IEnumerator OpClose(UnityAction<UIWindow> onClosed_) { return default; }
		
		// TODO
		private void OnRequiredItemData(IUIButton button) { }
		
		// TODO
		private void OnSelectItemScrollViewItem(IUIButton button) { }
		
		// TODO
		private void OnUnSelectItemScrollViewItem(IUIButton button) { }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
		
		// TODO
		private bool UpdateSelect(float deltaTime) { return default; }

		[Serializable]
		private class MenuWindowParam
		{
			public Sprite _bgSprite;
			public Color[] _fontColors;
		}

		public enum CursorType : int
		{
			Frame = 0,
			Arrow = 1,
		}

		public class Param
		{
			public MenuWindowType windowType;
			public ContextMenuItem.Param[] itemParams;
			public Vector2 pivot = Vector2.zero;
			public Vector3 position = Vector3.zero;
			public int selectIndex;
			public float minItemWidth = 122.0f;
			public int cancelIndex = -1;
			public bool useCancel = true;
			public bool useLoopAndRepeat = true;
            public bool isInputEnable = true;
            public UnityAction<int, ContextMenuItem.Param> onSetupMessageArgs;

            public enum MenuWindowType : int
            {
                Default = 0,
                Network = 1,
            }
        }
	}
}