using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class BoxTray : BoxInfinityScrollItem
	{
		[SerializeField]
		private UIText _title;
		[SerializeField]
		private Image _boxTitleImage;
		[SerializeField]
		private Image _boxBgImage;
		[SerializeField]
		private RectTransform _contents;

		public const int cellColumn = 6;

		private BoxTrayParam _param;
		private List<BoxTrayItem> _items = new List<BoxTrayItem>();
		
		public Image BoxTitleImage { get => _boxTitleImage; }
		public Image BoxBgImage { get => _boxBgImage; }
		public BoxTrayParam Param { get => _param; }
		public List<BoxTrayItem> Items { get => _items; }
		
		// TODO
		private void Awake() { }
		
		// TODO
		public override void Setup(BaseParam baseParam) { }
		
		// TODO
		public void SetTitle() { }
		
		// TODO
		public void Apply() { }
		
		// TODO
		public UINavigator GetNavigator(int posX, int posY) { return default; }

		public class BoxTrayParam : BaseParam
		{
			public UnityAction<BoxTray, int> setupAction;
		}
	}
}