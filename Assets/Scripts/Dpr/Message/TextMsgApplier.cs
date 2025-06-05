using System;
using TMPro;
using UnityEngine;

namespace Dpr.Message
{
	public class TextMsgApplier : MonoBehaviour
	{
		[SerializeField]
		private string[] msbtNameArray;
		[SerializeField]
		private UITextParameter[] paramArray;
		private MessageMsgFile[] msgFileArray;
		private MessageEnumData.MsgLangId langId = MessageEnumData.MsgLangId.Num;
		
		// TODO
		public MessageMsgFile GetMsgFile(int arrayIndex) { return default; }
		
		// TODO
		public void Apply() { }
		
		// TODO
		private void SetMsgFile() { }
		
		// TODO
		private void UpdateTextComponent() { }
		
		// TODO
		private void UpdateFontAsset(UITextParameter textParam) { }
		
		// TODO
		private void UpdateMessage(UITextParameter textParam) { }
		
		// TODO
		private bool CheckOutOfArrayIndex(int msgArrayIndex) { return default; }
		
		// TODO
		private void OnDestroy() { }
		
		// TODO
		private void DisposeMsgFiles() { }

		[Serializable]
		public class UITextParameter
		{
			public TextMeshProUGUI uiText;
			[Tooltip("-1以下ならfontMaterialは変更しない")]
			public int fontMaterialIndex = -1;
			[Tooltip("取得先のmsgFile番号(-1ならテキストの更新は行わない)")]
			public int msgFileIndex;
			[Tooltip("ラベル名から取得")]
			public string labelName = "";
			[Tooltip("Indexから取得(labelNameが空の場合)")]
			public int labelIndex;
		}
	}
}