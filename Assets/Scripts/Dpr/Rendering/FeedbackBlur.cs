using Dpr.Battle.View;
using SmartPoint.Rendering;
using UnityEngine;
using UnityEngine.Rendering;

namespace Dpr.Rendering
{
	[CreateAssetMenu(menuName = "ScriptableObjects/ImageEffect/FeedbackBlur", fileName = "FeedbackBlur")]
	public class FeedbackBlur : ImageEffectObject
	{
		public static readonly int DELAY_BUFFER_TEX_ID = Shader.PropertyToID("_DelayFrameTexture");
		public static readonly int _FeedbackBlurWeight = Shader.PropertyToID("_FeedbackBlurWeight");
        public static readonly int _FeedbackBlurRotation = Shader.PropertyToID("_FeedbackBlurRotation");
        public static readonly int _FeedbackBlurScale = Shader.PropertyToID("_FeedbackBlurScale");
        public static readonly int _FeedbackBlurHue = Shader.PropertyToID("_FeedbackBlurHue");
        public static readonly int _FeedbackBlurSaturation = Shader.PropertyToID("_FeedbackBlurSaturation");
        public static readonly int _FeedbackBlurBrightness = Shader.PropertyToID("_FeedbackBlurBrightness");
        public static readonly int _FeedbackBlurContrast = Shader.PropertyToID("_FeedbackBlurContrast");

        private RenderTexture _delayBuffer;
		private static Material _feedbackBlurMaterial;
		
		// TODO
		public override void Destroy() { }
		
		// TODO
		public override CommandBuffer Build(RenderTargetIdentifier sourceRT, out RenderTargetIdentifier resultRT, bool feedbackCameraTarget = true)
		{
			resultRT = default;
			return default;
		}
		
		// TODO
		public void UpdateShaderProperties(PfxParam param) { }
	}
}