using Dpr.Message;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class UIContMatchingPlayerBoard : MonoBehaviour
	{
		[SerializeField]
		private UIText _playerName;
		private GameObject loadingMonboObj;
		private Image preparationIconImage;
		private Sprite waitIconSpr;
		private Sprite readyIconSpr;
		
		// TODO
		public void Initialize(string initPlayerNameText, Sprite waitIconSpr, Sprite readyIconSpr) { }
		
		// TODO
		public void SetPlayerName(string playerNameSrt) { }
		
		// TODO
		public void SetPlayerName(string playerNameSrt, MessageEnumData.MsgLangId langId) { }
		
		// TODO
		public void ShowPreparatioIcon(bool isReady) { }
		
		// TODO
		public void HidePreparatioIcon() { }
		
		// TODO
		private void SetPreparatioIconActive(bool active) { }
		
		// TODO
		public void SetLoadingMonboObjActive(bool active) { }
	}
}