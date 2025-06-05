using Dpr.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.Contest
{
	public class PlayerStatusIcon : MonoBehaviour
	{
		private UIText wazaNameText;
		private UIText playerNameText;
		private RectTransform iconContent;
		private RectTransform statusIconRect;
		private RectTransform pmIconRect;
		private Image pmIconImage;
		private Image wazaTypeIconImage;
		private Image wazaMaskObj;
		private Image tensionIconImage;
		private Vector3 startPos = Vector3.zero;
		
		// TODO
		public Transform GetTransform() { return default; }
		
		// TODO
		public Vector3 GetPmIconPos() { return default; }
		
		// TODO
		public void Initialize(int index) { }
		
		// TODO
		private void SetComponents() { }
		
		// TODO
		public void ResetIcon() { }
		
		// TODO
		public void SetWazaName(string wazaName, Sprite wazaTypeIconSpr) { }
		
		// TODO
		public void SetMonsterIconSpr(Sprite iconSpr) { }
		
		// TODO
		public void SetPlayerName(string name) { }
		
		// TODO
		public void ShowTension(Sprite spr) { }
		
		// TODO
		public void ShowTension(Sprite spr, float duration, float jumpPower) { }
		
		// TODO
		public void HideTension() { }
		
		// TODO
		private void SetTensionImageActive(bool active) { }
		
		// TODO
		public void ShowWazaMask() { }
		
		// TODO
		public void HideWazaMask() { }
		
		// TODO
		public void StartContestSkill() { }
	}
}