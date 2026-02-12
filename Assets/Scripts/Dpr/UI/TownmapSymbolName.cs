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
		
		public void SetActive(bool isActive)
		{
			this[0] = isActive & 1;
			var uVar1 = Component.gameObject;
			if (this[0] != 0) {
			  uVar1.SetActive(this._data != null);
			}
			uVar1.SetActive(0);
		}
		
		// TODO
		public void Setup(Townmap.Cell cell, Vector3 pos) { }
	}
}