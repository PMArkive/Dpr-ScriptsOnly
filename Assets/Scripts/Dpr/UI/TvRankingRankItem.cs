using UnityEngine;
using UnityEngine.UI;
using XLSXContent;

namespace Dpr.UI
{
	public class TvRankingRankItem : MonoBehaviour
	{
		[SerializeField]
		private Image _rank;
		[SerializeField]
		private UIText _name;
		[SerializeField]
		private UIText _num;
		[SerializeField]
		private Sprite[] _spriteRanks;
		[SerializeField]
		private Color[] _colors;
		
		// TODO
		public void Setup(UIDatabase.SheetRankingDisplay rankData, TvRankingMenuItem.RankParam rankParam) { }
	}
}