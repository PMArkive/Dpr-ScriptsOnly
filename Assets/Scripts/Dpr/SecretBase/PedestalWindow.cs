using UnityEngine;
using UnityEngine.UI;
using XLSXContent;

namespace Dpr.SecretBase
{
	public class PedestalWindow : SelectWindow<PedestalIcon, Pedestal.SheetInfo>
	{
		[SerializeField]
		protected RectTransform rectTransform;
		[SerializeField]
		protected VerticalLayoutGroup layout;
		[SerializeField]
		protected RectTransform itemRect;
		protected float offset;
		
		// TODO
		private void Start() { }
		
		// TODO
		public override bool SelectNext() { return default; }
		
		// TODO
		public override bool SelectPrev() { return default; }
		
		// TODO
		public void ScrollCalc(int margin = 0) { }
		
		// TODO
		public int GetIndex(int id) { return default; }
		
		// TODO
		public bool HasEnableItem() { return default; }
	}
}