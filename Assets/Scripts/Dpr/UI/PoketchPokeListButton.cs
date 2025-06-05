using Pml.PokePara;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class PoketchPokeListButton : PoketchButton
	{
		[SerializeField]
		private PokemonIcon _pokemonIcon;
		[SerializeField]
		private Image _itemIcon;
		[SerializeField]
		private Slider _hpGuage;
		[SerializeField]
		private static Vector3 _vibrationValue = new Vector3(0.0f, 12.0f, 0.0f);
		[SerializeField]
		private static float _vibrationTime = 0.075f;

		public PokemonParam PokeParam;
		private DG.Tweening.Sequence _sequence;
		
		public PokemonIcon PokeIcon { get => _pokemonIcon; }
		public Slider HpGauge { get => _hpGuage; }
		public Image MonsIcon { get => _pokemonIcon.monsIcon; }
		public Image ItemIcon { get => _itemIcon; }
		
		// TODO
		public DG.Tweening.Sequence SetVibration() { return default; }
		
		// TODO
		public void StopVibration() { }
	}
}