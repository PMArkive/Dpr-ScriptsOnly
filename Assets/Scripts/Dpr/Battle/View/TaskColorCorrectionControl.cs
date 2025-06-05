using DG.Tweening;
using Dpr.SequenceEditor;
using UnityEngine;

namespace Dpr.Battle.View
{
	public sealed class TaskColorCorrectionControl : TaskPostEffectCotrol
	{
		private FromToPair<Vector3> _colorScale;
		private FromToPair<Vector3> _colorBias;
		private FromToPair<float> _brightness;
		private FromToPair<float> _saturation;
		private FromToPair<float> _contrast;
		private FromToPair<float> _temperature;
		private FromToPair<float> _sepiaToneWeight;
		
		protected override bool IsFinishCondition { get => _lifeTime <= _frame; }
		
		public TaskColorCorrectionControl(SequenceCameraObject cameraObject, Vector3 colorScale, Vector3 colorBias, float brightness, float saturation, float contrast, float temperature, float sepiaToneWeight, int lifeTime, Ease easeingType) : base(cameraObject)
		{
			var postEffects = cameraObject.GetPostEffects();
			var pfxParam = postEffects.GetPfxParam();

			_colorScale = new FromToPair<Vector3>(new Vector3(pfxParam.colorScaleR, pfxParam.colorScaleG, pfxParam.colorScaleB), colorScale);
			_colorBias = new FromToPair<Vector3>(new Vector3(pfxParam.colorBiasR, pfxParam.colorBiasG, pfxParam.colorBiasB), colorBias);
			_brightness = new FromToPair<float>(pfxParam.colorBrightness, brightness);
			_saturation = new FromToPair<float>(pfxParam.colorSaturation, saturation);
            _contrast = new FromToPair<float>(pfxParam.colorContrast, contrast);
            _temperature = new FromToPair<float>(pfxParam.colorTemperature, temperature);
            _sepiaToneWeight = new FromToPair<float>(pfxParam.sepiaToneWeight, sepiaToneWeight);
		}
		
		protected override void OnDispose()
		{
			Mem.Del(ref _cameraObject);
		}
		
		// TODO
		protected override PfxParam OnUpdate(int frame, float raito, ref PfxParam pfxParam) { return default; }
	}
}