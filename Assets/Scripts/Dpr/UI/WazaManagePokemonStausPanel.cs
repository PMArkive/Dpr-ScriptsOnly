using Pml.PokePara;
using UnityEngine;

namespace Dpr.UI
{
	public class WazaManagePokemonStausPanel : MonoBehaviour
	{
		[SerializeField]
		private UIText zukanNoText;
		[SerializeField]
		private UIText nameText;
		[SerializeField]
		private TypePanel type1Panel;
		[SerializeField]
		private TypePanel type2Panel;
		[SerializeField]
		private UIText hpText;
		[SerializeField]
		private UIText attackText;
		[SerializeField]
		private UIText defenceText;
		[SerializeField]
		private UIText specialAttackText;
		[SerializeField]
		private UIText specialDefenceText;
		[SerializeField]
		private UIText agilityText;
		[SerializeField]
		private UIText characteristicText;
		[SerializeField]
		private UIText haveItemNameText;
		[SerializeField]
		private GameObject wazaObject;
		[SerializeField]
		private WazaManageSubWazaPanel[] subWazaPanels;
		
		// TODO
		public void Setup(PokemonParam pokemonParam, bool isWazaActive) { }
	}
}