using Pml.PokePara;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class UIBattleMatchingTeamPlate : MonoBehaviour
	{
		[SerializeField]
		private Image _imageFrame;
		[SerializeField]
		private Sprite[] _spriteFrames;
		[SerializeField]
		private UIText _textTitle;
		[SerializeField]
		private GameObject _objWarning;
		[SerializeField]
		private GameObject _objTeam;
		[SerializeField]
		private UIBattleMatchingPokemonSlot[] _pokemonSlots;

		private static string[] _titleLabels = new string[]
		{
            "SS_boxname_033", "SS_boxname_034", "SS_boxname_035",
            "SS_boxname_036", "SS_boxname_037", "SS_boxname_038",
        };
		
		// TODO
		public void Setup(PokemonParam[] pokemonParams, bool[] regurations, UIBattleMatchingPokemonSlot.SlotType type = UIBattleMatchingPokemonSlot.SlotType.Own, int teamIndex = -1, bool isMine = false) { }
		
		// TODO
		public void SetTitleOwn(int index) { }
		
		// TODO
		public void SetTitle(string msbt, string label) { }
		
		// TODO
		public void SetTitle(string playerName, uint language) { }
		
		// TODO
		public void SetActiveFrame(bool active) { }
	}
}