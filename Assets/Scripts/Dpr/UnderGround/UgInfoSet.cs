using Dpr.Message;
using Dpr.SubContents;
using Dpr.UI;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.UnderGround
{
	public class UgInfoSet : MonoBehaviour
	{
		private RectTransform View;
		private UIText uiText;

		private static readonly Vector3 HidePos = new Vector3(0.0f, 34.0f, 0.0f);
		private static readonly Vector3 ViewPos = new Vector3(0.0f, 0.0f, 0.0f);

        public float duration = 0.8f;
		private DG.Tweening.Sequence anim;
		public bool isPlaying;
		private List<(PlayerNameData, bool, float)> StockPlayerMessageList = new List<(PlayerNameData, bool, float)>();
		private List<(string, float)> StockKousekiMessageList = new List<(string, float)>();

		private const string UG_MSG_FILE = "dlp_underground";
		private const string Label_EnterOtherPlayer = "DLP_underground_758";
		private const string Label_ExitOtherPlayer = "DLP_underground_759";
		private const string Label_StartKousekiBonus = "DLP_underground_738";
		private const string Label_StartKousekiSagashi = "DLP_underground_739";

		[Button("SetText", "SetText", new object[] { "テストメッセージ" })]
		public int Button01;
		
		// TODO
		private void Awake() { }
		
		// TODO
		private void Update() { }
		
		// TODO
		public void Play(float displayTime) { }
		
		// TODO
		public void SetText(PlayerNameData playerName, bool isEnter, float displayTime = 1.5f) { }
		
		// TODO
		public void SetText(string KousekiMessage, float displayTime = 1.5f) { }
		
		// TODO
		private string GetPlayerText(PlayerNameData playerName, bool isEnter) { return default; }
		
		// TODO
		public void OnOtherPlayerEnter(PlayerNameData nameData) { }
		
		// TODO
		public void OnOtherPlayerExit(PlayerNameData nameData) { }
		
		// TODO
		public void OnStartKousekiBonus() { }
		
		// TODO
		public void OnStartKousekiSagashi() { }
	}
}