using DG.Tweening;
using Dpr.SequenceEditor;
using UnityEngine;

namespace Dpr.Battle.View
{
	public sealed class TaskRadialBlurControl : TaskPostEffectCotrol
	{
		private FromToPair<Vector2> _center;
		private FromToPair<float> _intensity;
		private FromToPair<int> _numSamples;
		
		protected override bool IsFinishCondition { get => _lifeTime <= _frame; }
		
		public TaskRadialBlurControl(SequenceCameraObject cameraObject, Vector2 center, float intensity, int numSamples, int lifeTime, Ease easingType) : base(cameraObject)
		{
			var postEffects = cameraObject.GetPostEffects();
			var pfxParam = postEffects.GetPfxParam();

			_center = new FromToPair<Vector2>(pfxParam.radialBlurCenter, center);
			_intensity = new FromToPair<float>(pfxParam.radialBlurIntensity, intensity);
			_numSamples = new FromToPair<int>(pfxParam.radialBlurNumSamples, numSamples);

			_lifeTime = lifeTime;
			_easingType = easingType;

			postEffects.SetPfxParam(pfxParam);
		}
		
		protected override void OnDispose()
		{
			Mem.Del(ref _cameraObject);
			Mem.Del(ref _numSamples);
			Mem.Del(ref _center);
			Mem.Del(ref _intensity);
		}
		
		// TODO
		protected override PfxParam OnUpdate(int frame, float raito, ref PfxParam pfxParam) { return default; }
	}
}