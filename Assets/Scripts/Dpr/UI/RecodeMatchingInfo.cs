using Dpr.Message;
using UnityEngine;

namespace Dpr.UI
{
	public class RecodeMatchingInfo : MonoBehaviour
	{
		[SerializeField]
		private UIText _textName;
		[SerializeField]
		private UIText _textID;

		private MessageMsgFile _msgFile;
		
		// TODO
		public void Setup(string name, uint id) { }
		
		// TODO
		public void SetActive(bool active) { }
	}
}