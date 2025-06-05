using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class BoxListPanel : MonoBehaviour
	{
		[SerializeField]
		private CanvasGroup _canvasGroup;
		[SerializeField]
		private GridLayoutGroup _grid;
		[SerializeField]
		private BoxListNavigate[] _naviSteps;
		[SerializeField]
		private BoxListItem[] _boxes;

		private int _step;
		private float _openPosX;
		private float _closePosX;

		private readonly float[] _boxItemScales = new float[] { 0.86f, 0.86f, 0.86f, 0.78f, 0.7f };
		
		public BoxListNavigate CurrentNavigates { get => _naviSteps[_step]; }
		public int SelectedIndex { get; set; } = -1;
		public CanvasGroup BoxCcanvasGroup { get => _canvasGroup; }
		
		// TODO
		public void Initialize(int boxCount, BoxWindow.SEARCH_DATA searchData) { }
		
		// TODO
		public void Open([Optional] Action callback) { }
		
		// TODO
		public void Close([Optional] Action callback) { }
		
		// TODO
		public void SetPanel(bool isEnable, [Optional] Action callback) { }
		
		// TODO
		public bool ToggleSelectBox(int index) { return default; }
		
		// TODO
		public void ApplyBox(int index, [Optional] BoxWindow.SEARCH_DATA searchData) { }
		
		// TODO
		public void SetBoxChips(int index, [Optional] BoxWindow.SEARCH_DATA searchData) { }
		
		// TODO
		public void SetBoxWallcolor(int index) { }
	}
}