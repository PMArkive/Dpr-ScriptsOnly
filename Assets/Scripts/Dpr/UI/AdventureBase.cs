using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XLSXContent;

namespace Dpr.UI
{
	public class AdventureBase : UIWindow
	{
		[SerializeField]
		protected AdventureNote _note;
		[SerializeField]
		protected Image _imageBg;
		[SerializeField]
		protected Sprite[] _spriteBgs;

		protected List<AdventureNoteData.SheetData> _currentDatas;
		protected int _pageIndex;
		
		// TODO
		protected void SetupBg() { }
		
		// TODO
		protected bool UpdatePageSelect(float deltaTime) { return default; }
		
		// TODO
		protected void MovePage(int add) { }
	}
}