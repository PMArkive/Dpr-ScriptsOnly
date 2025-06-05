using Dpr.MsgWindow;
using UnityEngine;

namespace Dpr.UI
{
	public class PokemonWindowBase : UIWindow
	{
		[SerializeField]
		protected PokemonParty _party;
		[SerializeField]
		protected RectTransform _messageWindowRoot;
		
		// TODO
		public override void OnCreate() { }
		
		// TODO
		public void SetContextMenuPositionParams(ContextMenuWindow.Param param, RectTransform transPartyItem, int selectIndex, float posZ) { }
		
		// TODO
		protected override void OpenMessageWindow(MsgWindowParam messageParam) { }

		public class BaseParam
		{
			public int selectIndex = -1;
		}
	}
}