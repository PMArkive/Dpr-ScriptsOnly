using Dpr.Battle.Logic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.Battle.View.UI
{
	public sealed class BUISituationButton : BUIButtonBase<BUISituationButton>
	{
		[SerializeField]
		private Image _pokeIcon;
		[SerializeField]
		private Image _sexIcon;
		[SerializeField]
		private Image _statusIcon;
		[SerializeField]
		private TextMeshProUGUI _trainerNameText;
		
		public Image MonsIcon { get => _pokeIcon; }
		
		// TODO
		public bool Initialize(BTL_POKEPARAM btlParam, string trainerName = "") { return default; }
	}
}