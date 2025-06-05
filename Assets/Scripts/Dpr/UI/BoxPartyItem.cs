using Pml.PokePara;
using UnityEngine;

namespace Dpr.UI
{
	public class BoxPartyItem : BoxItem
	{
		[SerializeField]
		private RectTransform _infoRoot;
		[SerializeField]
		private UIText _name;
		[SerializeField]
		private UIText _level;
		
		// TODO
		public override PokemonParam pokemonParam { get; }
		
		// TODO
		public override void Setup(Param param) { }
		
		// TODO
		public override void Clear() { }
		
		// TODO
		public override void SetIconDefault(bool isShow = true) { }
		
		// TODO
		public override void Select(bool isSelect, bool isImmidiate = false) { }
		
		// TODO
		public void SelectOnlyIcon(bool isSelect, bool isImmidiate = false) { }
		
		// TODO
		public void ShowName(bool enabled) { }
	}
}