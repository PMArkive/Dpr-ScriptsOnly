using Dpr.Message;
using Dpr.NetworkUtils;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class UIBattleMatchingPlayer : MonoBehaviour
	{
		[SerializeField]
		private UIContMatchingPlayerBoard[] _playerBoards;

		private List<int> _indexList;
		private string[] uiPlayerNameArray = new string[UnionWork.COLISEUM_MAX_PLAYER_NUM_MULTI];
		
		// TODO
		public void Initialize(int num, BattleModeID type, bool vs = false) { }
		
		// TODO
		public void SetPlayerName(int index, string name, MessageEnumData.MsgLangId languageId) { }
		
		// TODO
		public void SetLoadingMonboObjActive(int index, bool active) { }
		
		// TODO
		public void ShowPreparatioIconReady(int index) { }
		
		// TODO
		public void ShowPreparatioIconWait(int index) { }
		
		// TODO
		public void HidePreparatioIcon() { }
		
		// TODO
		public void HidePreparatioIcon(int index) { }
		
		// TODO
		public void ResetPreparatioIcon() { }
		
		// TODO
		public RawImage[] GetRowImages() { return default; }
	}
}