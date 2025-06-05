using Pml.PokePara;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class UIPokeStatusSelectPanel : MonoBehaviour
	{
		[SerializeField]
		private UIText _name;
		[SerializeField]
		private UIText _level;
		[SerializeField]
		private Image _imageMonsterBall;
		[SerializeField]
		private Image _sex;
		[SerializeField]
		private Image _language;
		[SerializeField]
		private GameObject _selectArrowRoot;
		[SerializeField]
		private GameObject _infoStatusRoot;
		[SerializeField]
		private Image[] _arrows;
		[SerializeField]
		private PokemonSick _sick;
		
		// TODO
		public void Setup(PokemonParam pokemonParam) { }
		
		// TODO
		private void SetInfoStatusRootActive(bool active) { }
		
		// TODO
		public void SetArrowAcitve(bool active) { }
		
		// TODO
		public void PlayAnimArrow(int move) { }
	}
}