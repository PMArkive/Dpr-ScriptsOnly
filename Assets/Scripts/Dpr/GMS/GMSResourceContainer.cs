using Dpr.Message;
using Dpr.UI;
using Pml;
using System.Collections.Generic;
using UnityEngine;
using XLSXContent;

namespace Dpr.GMS
{
	public class GMSResourceContainer
	{
		private UIManager uiManagerPtr;
		private Dictionary<int, Sprite> langIconSprTable = new Dictionary<int, Sprite>();
		private Dictionary<int, string> langIconDataTable = new Dictionary<int, string>();
		private MonsIconData[] monsIconDataArray;
		private Sprite[] sexSprArray;
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public void CreateLangIconDataTable(GMSMasterData.SheetLangIconData[] langIconData) { }
		
		// TODO
		public void OnFinalize() { }
		
		// TODO
		public Sprite GetSexSpr(Sex sex) { return default; }
		
		// TODO
		public Sprite GetLangIconSpr(MessageEnumData.MsgLangId langID) { return default; }
		
		// TODO
		public bool CheckHasMonsIcon(MonsNo monsNo, uint formNo) { return default; }
		
		// TODO
		public Sprite GetMonsIconSpr(MonsNo monsNo, uint formNo) { return default; }
		
		// TODO
		public void AddMonsIconSpr(MonsNo monsNo, uint formNo, Sprite iconSpr) { }
		
		// TODO
		private int ConvertMonsNoToIndex(MonsNo monsNo) { return default; }
	}
}