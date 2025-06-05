using Pml.PokePara;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class UIBattleMatchingPokemonSlot : MonoBehaviour
	{
		[SerializeField]
		private Image _imageFrame;
		[SerializeField]
		private Sprite[] _spriteFrames;
		[SerializeField]
		private Image _imageItemFrame;
		[SerializeField]
		private Sprite[] _spriteItemFrames;
		[SerializeField]
		private PokemonIcon _pokemonIcon;
		[SerializeField]
		private UIText _textName;
		[SerializeField]
		private UIText _textLevel;
		[SerializeField]
		private Image _imageGender;
		[SerializeField]
		private Cursor _cursor;
		[SerializeField]
		private GameObject _objBan;
		
		// TODO
		public void Setup(SlotType type, PokemonParam param, int tray = -1, int pos = -1) { }

		public enum SlotType : int
		{
			Own = 0,
			OTher = 1,
			Ban = 2,
		}
	}
}