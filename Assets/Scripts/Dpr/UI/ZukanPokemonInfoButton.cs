using Dpr.Message;
using Pml.PokePara;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class ZukanPokemonInfoButton : MonoBehaviour, IUIButton
	{
		private const string ZukanMessageFileName = "ss_pokedex";
		private const string ZukanNoMessageLabel = "SS_pokedex_131";

		[SerializeField]
		private Image baseImage;
		[SerializeField]
		private Image getIconImage;
		[SerializeField]
		private Image unknownIconImage;
		[SerializeField]
		private PokemonIcon pokemonIcon;
		[SerializeField]
		private UIText noText;
		[SerializeField]
		private UIText nameText;
		[SerializeField]
		private Sprite unselectBaseSprite;
		[SerializeField]
		private Sprite selectedBaseSprite;

		private int index;
		private RectTransform rectTransform;
		
		public ZukanInfo Info { get; set; }
		public UIText NameText { get => nameText; }
		public bool IsAllowShowDescription { get; set; }
		
		// TODO
		public int GetIndex() { return default; }
		
		// TODO
		public void SetIndex(int index) { }
		
		// TODO
		public RectTransform GetRectTransform() { return default; }
		
		// TODO
		public bool GetActive() { return default; }
		
		// TODO
		public void SetActive(bool isActive) { }
		
		// TODO
		public void Select() { }
		
		// TODO
		public void UnSelect() { }
		
		// TODO
		public void SetInfo(ZukanInfo zukanInfo, ViewType viewType) { }
		
		// TODO
		public void SetViewType(ViewType viewType) { }
		
		// TODO
		public void ChangeLanguage(MessageEnumData.MsgLangId langId) { }
		
		// TODO
		public void UpdatePokemonIcon(PokemonParam pokemonParam) { }
		
		// TODO
		public void CopyTo(ZukanPokemonInfoButton button) { }

		public enum ViewType : int
		{
			No = 0,
			Weight = 1,
			Height = 2,
		}
	}
}