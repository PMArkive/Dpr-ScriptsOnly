using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class ZukanCompareStatusPanel : MonoBehaviour
	{
		private const string HeightParamTitleLabelName = "SS_pokedex_027";
		private const string HeightPlayerParamMaleValueLabelName = "SS_pokedex_194";
		private const string HeightPlayerParamFemaleValueLabelName = "SS_pokedex_193";
		private const string WeightParamTitleLabelName = "SS_pokedex_028";
		private const string WeightPlayerParamMaleValueLabelName = "SS_pokedex_196";
		private const string WeightPlayerParamFemaleValueLabelName = "SS_pokedex_195";

		[SerializeField]
		private UIText pokemonNameText;
		[SerializeField]
		private UIText pokemonParamTitleText;
		[SerializeField]
		private UIText pokemonParamValueText;
		[SerializeField]
		private UIText playerNameText;
		[SerializeField]
		private UIText playerParamTitleText;
		[SerializeField]
		private UIText playerParamValueText;
		[SerializeField]
		private Image maleIconImage;
		[SerializeField]
		private Image femaleIconImage;
		[SerializeField]
		private Image rareIconImage;
		[SerializeField]
		private GameObject formNameObject;
		[SerializeField]
		private UIText formNameText;
		
		// TODO
		public void Setup(bool isHeight) { }
		
		// TODO
		public void Set(ZukanInfo zukanInfo, bool isHeight) { }
	}
}