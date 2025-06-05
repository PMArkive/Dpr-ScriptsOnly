using Dpr.Battle.View;
using SmartPoint.Rendering;
using UnityEngine;
using UnityEngine.Rendering;

namespace Dpr.Rendering
{
	[CreateAssetMenu(menuName = "ScriptableObjects/ImageEffect/RadialBlur", fileName = "RadialBlur")]
	public class RadialBlur : ImageEffectObject
	{
		public static readonly int _RadialBlurCenter = Shader.PropertyToID("_RadialBlurCenter");
		public static readonly int _RadialBlurIntensity = Shader.PropertyToID("_RadialBlurIntensity");
        public static readonly int _RadialBlurNumSamples = Shader.PropertyToID("_RadialBlurNumSamples");
        private static Material _radialBlurMaterial;
		
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