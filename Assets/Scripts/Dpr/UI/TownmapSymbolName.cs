using UnityEngine;
using XLSXContent;

namespace Dpr.UI
{
	public class TownmapSymbolName : MonoBehaviour
	{
		[SerializeField]
		private UIText _text;
		private bool _isActived;
		private TownMapTable.SheetData _data;
		
		// TODO
		public void SetActive(bool isActive) { }
		
		// TODO
		public void Setup(Townmap.Cell cell, Vector3 pos) { }
	}
}