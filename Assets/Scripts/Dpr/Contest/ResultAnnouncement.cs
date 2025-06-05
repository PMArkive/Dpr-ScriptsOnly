using DG.Tweening;
using Dpr.SubContents;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.Contest
{
	public class ResultAnnouncement : MonoBehaviour
	{
		[SerializeField]
		private Sprite[] rankNumSprArray;
		private DOTweenAnimation titleFadeTween;
		private Image resultTitleImage;
		private DOTweenAnimation rankGaugeFadeTween;
		private Image rankGaugeImage;
		private Image rankNumImage;
		private EffectEmitter fxEmitter = new EffectEmitter();
		private RankGaugeData gaugeData;
		private ShowMessageWindow resultMsg = new ShowMessageWindow();
		private ResultSettings settingsData;
		private Sprite rankLogoSpr;
		private AnimStateID currentState;
		private ResultID resultId;
		private float waitTimer;
		private float gaugeTimer;
		private int nextRankPoint;
		private int addValue;
		private bool bRunning;
		private bool isRankup;
		private bool isMultiMode;
		
		// TODO
		public void Initialize(ResultSettings setting) { }
		
		// TODO
		private void InitResultTitle() { }
		
		// TODO
		private void InitRankGauge() { }
		
		// TODO
		public void OnFinalize() { }
		
		public bool IsReady { get => fxEmitter.IsReady; }
		
		// TODO
		public void LoadResultFx(ResultID resultID) { }
		
		// TODO
		public void Setup(RankGaugeData gaugeData, Sprite spr, bool isMultiMode, ResultID resultId) { }
		
		// TODO
		public void StartAnimation() { }
		
		// TODO
		public bool OnUpdate(float deltaTime) { return default; }
		
		// TODO
		private void UpdateGauge(float deltaTime) { }
		
		// TODO
		private bool CheckRankUp() { return default; }
		
		// TODO
		private void SetGaugeRatio(float gaugeRatio) { }
		
		// TODO
		private void SetGaugeAnimParam() { }
		
		// TODO
		private int GetNextRankPoint() { return default; }
		
		// TODO
		private bool IsMaxRank() { return default; }
		
		// TODO
		private void StopGaugeSE() { }
		
		// TODO
		private void UpdateRankupAnim() { }
		
		// TODO
		private void ChangeUserRank() { }
		
		// TODO
		private void UpdateWait(float deltaTime) { }
		
		// TODO
		private void StartFadeout() { }
		
		// TODO
		public void OnCompleteTitleFade() { }
		
		// TODO
		private float CalcInitGaugeRatio() { return default; }
		
		// TODO
		public void OnCompleteTitleFadeBackWards() { }
		
		// TODO
		public void OnCompleteRankInfoFade() { }

		private enum AnimStateID : int
		{
			TweenAnim = 0,
			GaugeAnim = 1,
			RankupAnim = 2,
			Wait = 3,
			End = 4,
		}
	}
}