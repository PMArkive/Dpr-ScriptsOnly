using Pml;
using UnityEngine;

namespace Dpr.Contest
{
	public sealed class ResultDataModel : ResultData
	{
		private float playerNumDivid;
		private Sprite resultMessageSpr;
		
		// TODO
		public void ResetData() { }
		
		// TODO
		public void OnFinalize() { }
		
		// TODO
		public ResultPlayerDataModel GetPlayerData() { return default; }
		
		// TODO
		public int GetPersonalTotalScore() { return default; }
		
		// TODO
		public bool IsUserWin() { return default; }
		
		// TODO
		public Sprite GetResultMessageSpr() { return default; }
		
		// TODO
		public float CalcVisualGaugeRatio(int playerIndex) { return default; }
		
		// TODO
		public float CalcDanceGaugeRatio(int playerIndex) { return default; }
		
		// TODO
		public float CalcWazaGaugeRatio(int playerIndex) { return default; }
		
		// TODO
		public void ApplyContestPoint() { }
		
		// TODO
		private uint CalcAddRankPoint() { return default; }
		
		// TODO
		private float CalcRatio(float a, float b) { return default; }
		
		// TODO
		public void SetPlayerDataModelArray(ResultPlayerDataModel[] playerDataModelArray) { }
		
		// TODO
		public void CreateVoiceEventName(MonsNo monsNo, uint formNo, int voiceNo) { }
	}
}