using Pml.PokePara;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Dpr.UI
{
	public class PokemonStatusMarkSetting : MonoBehaviour
	{
		[SerializeField]
		private RectTransform _markRoot;
		[SerializeField]
		private Cursor _cursor;

		public UnityAction onClosed;
		private List<PokemonStatusMark> _marks = new List<PokemonStatusMark>();
		private int _selectIndex;
		private Animator _animator;

		private readonly int _animStateIn = Animator.StringToHash("in");
		private readonly int _animStateOut = Animator.StringToHash("out");

        private OpenState _openState;
		
		public List<PokemonStatusMark> marks { get => _marks; }
		
		// TODO
		private void Awake() { }
		
		// TODO
		public void Open(BoxMarkColor[] types) { }
		
		// TODO
		private IEnumerator OpOpen(BoxMarkColor[] types) { return default; }
		
		// TODO
		private void Close(UnityAction onClosed_) { }
		
		// TODO
		public IEnumerator OpClose(UnityAction onClosed_) { return default; }
		
		// TODO
		public bool OnUpdate(float deltaTime, UIInputController input) { return default; }
		
		// TODO
		private bool SetSelectIndex(int selectIndex, bool isInitialize = false) { return default; }

		private enum OpenState : int
		{
			Closed = 0,
			Opening = 1,
			Opened = 2,
			Closing = 3,
		}
	}
}