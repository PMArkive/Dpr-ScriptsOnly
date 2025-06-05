using Dpr.Message;
using TMPro;
using UnityEngine;

namespace Dpr.UI
{
	public class MenuHeader : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _timeText;
		[SerializeField]
		private GameObject _timerObj;
		[SerializeField]
		private string useMsbtName = "";
		[SerializeField]
		private string timeLabelName = "";

		private MessageMsgFile _useMsgFile;
		
		// TODO
		public void Setup() { }
		
		// TODO
		public void HideTimer() { }
		
		// TODO
		private void SetTimerActive(bool active) { }
		
		// TODO
		public void SetTime(int minut, int second) { }
		
		// TODO
		public void SetTime(string minutStr, string secondStr) { }
		
		// TODO
		private bool CheckHaveMsgFile() { return default; }
	}
}