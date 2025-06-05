using Dpr.SubContents;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.Contest
{
	public class ScoreGauge : MonoBehaviour
	{
		[SerializeField]
		private RectTransform clearArrowRect;
		[SerializeField]
		private RectTransform markRect;
		[SerializeField]
		private Color baseColor;
		[SerializeField]
		private Color flashColor;
		[SerializeField]
		private float flickDuration = 360.0f;
		[SerializeField]
		private Material gaugeMat;
		private EffectEmitter fxEmitter = new EffectEmitter();
		private LockPlayFx lockNormalFxTimer = new LockPlayFx();
		private LockPlayFx lockLargeFxTimer = new LockPlayFx();
		private RectTransform leftFrameRect;
		private Image leftGaugeImage;
		private Image leftGaugeBgImage;
		private RectTransform rightFrameRect;
		private Image rightGaugeImage;
		private Image rightGaugeBgImage;
		private Color gaugeColor;
		private float successScoreRatio;
		private float totalWidth;
		private float goalRatio;
		private float currentRatio;
		private float addGaugeValue;
		private float addFadeValue;
		private float colorAngleValue;
		private bool playingGaugeFlash;
		
		public Vector3 MarkCenterPos { get => markRect.position; }
		
		// TODO
		public void Initialize(float addValue, float lockTime) { }
		
		// TODO
		private void SetComponents() { }
		
		// TODO
		public void OnFinalize() { }
		
		// TODO
		public void SetUp(float successScoreRatio, float initGaugeRatio) { }
		
		// TODO
		private EmitEffectParam[] GetHitFxParams() { return default; }
		
		// TODO
		public void SetScoreRatio(float ratio, EmitHeartPattern emitPattern) { }
		
		// TODO
		private void CheckSuccessRatio() { }
		
		// TODO
		public void ResetParam(float ratio) { }
		
		// TODO
		public void OnUpdate(float deltaTime) { }
		
		// TODO
		private void UpdateGaugeAmount(float deltaTime) { }
		
		// TODO
		private void SetGaugeRatio(float scoreRatio) { }
		
		// TODO
		private float CalcLeftGaugeAmount(float scoreRatio) { return default; }
		
		// TODO
		private float CalcRightGaugeAmount(float scoreRatio) { return default; }
		
		// TODO
		private void UpdateColorFade(float deltaTime) { }
		
		// TODO
		private void SetColorRatio(float ratio) { }
		
		// TODO
		private float LerpColorFactor(float a, float b, float ratio) { return default; }
	}
}