using UnityEngine;
using UnityEngine.UI;

namespace Dpr.SecretBase
{
	public class GridSelectWindow<T, Data> : SelectWindow<T, Data>
	{
		[SerializeField]
		protected RectTransform rectTransform;
		[SerializeField]
		protected GridLayoutGroup grid;
		protected float offset;
		[SerializeField]
		protected float scrollSpeed = 0.5f;
		protected Vector3 dest;
		protected MoveState moveStateHorizontal;
		protected MoveState moveStateVertical;
		
		// TODO
		private void Update() { }
		
		// TODO
		public override bool SelectNext() { return default; }
		
		// TODO
		public override bool SelectPrev() { return default; }
		
		// TODO
		public bool SelectNextRow() { return default; }
		
		// TODO
		public bool SelectPrevRow() { return default; }
		
		// TODO
		public void ReleaseInput() { }
		
		// TODO
		protected void ScrollToRow(int row) { }
		
		// TODO
		protected void ScrollCalc() { }
		
		// TODO
		public bool IsNextNewLine() { return default; }
		
		// TODO
		public bool IsPrevNewLine() { return default; }
		
		// TODO
		public float GetCursorRatio() { return default; }
	}
}