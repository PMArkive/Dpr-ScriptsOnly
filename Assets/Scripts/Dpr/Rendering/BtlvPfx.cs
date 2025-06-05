using Dpr.Battle.View;
using SmartPoint.Rendering;
using UnityEngine;
using UnityEngine.Rendering;

namespace Dpr.Rendering
{
	[CreateAssetMenu(menuName = "ScriptableObjects/ImageEffect/BtlvPfx", fileName = "BtlvPfx")]
	public sealed class BtlvPfx : ImageEffectObject
	{
		public static readonly int _ColorHue = Shader.PropertyToID("_ColorHue");
		public static readonly int _ColorSat = Shader.PropertyToID("_ColorSaturation");
        public static readonly int _ColorVal = Shader.PropertyToID("_ColorBrightness");
        public static readonly int _ColorScale = Shader.PropertyToID("_ColorScale");
        public static readonly int _ColorBias = Shader.PropertyToID("_ColorBias");
        public static readonly int _ColorContrast = Shader.PropertyToID("_ColorContrast");
        public const string _SEPIA_TONE_ON = "_SEPIA_TONE_ON";
		public static readonly int _SepiaToneWeight = Shader.PropertyToID("_SepiaToneWeight");
        public const string _COLOR_INVERSION_ON = "_COLOR_INVERSION_ON";

		private static Material _btlvPfxMaterial;
		
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