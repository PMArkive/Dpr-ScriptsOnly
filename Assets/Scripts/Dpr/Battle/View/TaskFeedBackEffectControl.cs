using DG.Tweening;
using Dpr.SequenceEditor;

namespace Dpr.Battle.View
{
	public sealed class TaskFeedBackEffectControl : TaskPostEffectCotrol
	{
		private FromToPair<float> _feedbackEffectWeight;
		private FromToPair<float> _feedbackEffectRotation;
		private FromToPair<float> _feedbackEffectScale;
		private FromToPair<float> _feedbackEffectHue;
		private FromToPair<float> _feedbackEffectSaturation;
		private FromToPair<float> _feedbackEffectBrightness;
		private FromToPair<float> _feedbackEffectContrast;
		
		protected override bool IsFinishCondition { get => _lifeTime <= _frame; }
		
		public TaskFeedBackEffectControl(SequenceCameraObject cameraObject, float feedbackEffectWeight, float feedbackEffectRotation, float feedbackEffectScale, float feedbackEffectHue, float feedbackEffectSaturation, float feedbackEffectBrightness, float feedbackEffectContrast, Ease easingType, int lifeTime) : base(cameraObject)
		{
			var postEffects = cameraObject.GetPostEffects();
			var pfxParam = postEffects.GetPfxParam();

			_feedbackEffectWeight = new FromToPair<float>(pfxParam.feedbackEffectWeight, feedbackEffectWeight);
			_feedbackEffectRotation = new FromToPair<float>(pfxParam.feedbackEffectRotation, feedbackEffectRotation);
			_feedbackEffectScale = new FromToPair<float>(pfxParam.feedbackEffectScale, feedbackEffectScale);
            _feedbackEffectHue = new FromToPair<float>(pfxParam.feedbackEffectHue, feedbackEffectHue);
            _feedbackEffectSaturation = new FromToPair<float>(pfxParam.feedbackEffectSaturation, feedbackEffectSaturation);
            _feedbackEffectBrightness = new FromToPair<float>(pfxParam.feedbackEffectBrightness, feedbackEffectBrightness);
            _feedbackEffectContrast = new FromToPair<float>(pfxParam.feedbackEffectContrast, feedbackEffectContrast);

			_lifeTime = lifeTime;
			_easingType = easingType;

			postEffects.SetPfxParam(pfxParam);
		}
		
		protected override void OnDispose()
		{
            var postEffects = _cameraObject.GetPostEffects();
            var pfxParam = postEffects.GetPfxParam();
			pfxParam.feedbackEffectWeight = 0.0f;
			postEffects.SetPfxParam(pfxParam);

			Mem.Del(ref _cameraObject);
        }
		
		// TODO
		protected override PfxParam OnUpdate(int frame, float raito, ref PfxParam pfxParam) { return default; }
	}
}