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
		
		public void Initialize(ResultSettings setting)
		{
			this.settingsData = setting;
			this.waitTimer = 0;
			this.currentState = (AnimStateID)0;
			Contest_ResultAnnouncement.InitResultTitle();
			Contest_ResultAnnouncement.InitRankGauge();
			ExtensionMethods.SetActive(0);
		}
		
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
		
		public bool OnUpdate(float deltaTime)
		{
			if ((int)this.currentState == 3) {
			  Contest_ResultAnnouncement.UpdateWait();
			  return this.bRunning;
			}
			if ((int)this.currentState != 2) {
			  if ((int)this.currentState == 1) {
			    Contest_ResultAnnouncement.UpdateGauge();
			  }
			  return this.bRunning;
			}
			Contest_ResultAnnouncement.UpdateRankupAnim();
			return this.bRunning;
		}
		
		// TODO
		private void UpdateGauge(float deltaTime) { }
		
		private bool CheckRankUp()
		{
			return this.nextRankPoint <=
			       this.addValue + this.gaugeData.Length;
		}
		
		private void SetGaugeRatio(float gaugeRatio)
		{
			UI_Image.fillAmount = this.rankGaugeImage;
		}
		
		// TODO
		private void SetGaugeAnimParam() { }
		
		// TODO
		private int GetNextRankPoint() { return default; }
		
		private bool IsMaxRank()
		{
			var uVar1 = this.gaugeData[0].Length;
			if ((int)uVar1 <= (int)this.gaugeData.userRank) {
			  return true;
			}
			if (this.gaugeData.userRank < uVar1) {
			  return this.gaugeData[0] + (int)this.gaugeData.userRank * 8[0].Length >> 0x1f;
			}
		}
		
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
		
		private float CalcInitGaugeRatio()
		{
			var uVar3 = this.gaugeData.userRank;
			var uVar1 = this.gaugeData[0].Length;
			if ((int)uVar3 < (int)uVar1) {
			  if (uVar1 <= uVar3) {
			  }
			  var iVar2 = this.gaugeData[0] + (int)uVar3 * 8[0].Length;
			  this.nextRankPoint = iVar2;
			  if (0 < iVar2) {
			    return (float)this.gaugeData.Length / (float)iVar2;
			  }
			}
			else {
			  this.nextRankPoint = 0xffffffff;
			}
			return 1.0;
		}
		
		public void OnCompleteTitleFadeBackWards()
		{
			this.bRunning = false;
		}
		
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