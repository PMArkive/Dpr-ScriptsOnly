using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class TownmapFacility : MonoBehaviour
	{
		[SerializeField]
		private Image _imageEmpty;
		[SerializeField]
		private RectTransform _infoRoot;
		[SerializeField]
		private UIText _name;
		[SerializeField]
		private UIText[] _infoTexts;
		[SerializeField]
		private RectTransform _facilityContent;
		[SerializeField]
		private TownmapFacilityItem _facilityItemPrefab;
		[SerializeField]
		private Image _facilityBg;

		private List<TownmapFacilityItem> _facilities = new List<TownmapFacilityItem>();
		
		// TODO
		public void Setup(Townmap.Cell cell) { }
	}
}