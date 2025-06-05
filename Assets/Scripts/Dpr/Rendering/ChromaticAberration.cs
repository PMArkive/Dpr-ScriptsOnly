using Dpr.Battle.View;
using SmartPoint.Rendering;
using UnityEngine;
using UnityEngine.Rendering;

namespace Dpr.Rendering
{
	[CreateAssetMenu(menuName = "ScriptableObjects/ImageEffect/ChromaticAberration", fileName = "ChromaticAberration")]
	public class ChromaticAberration : ImageEffectObject
	{
		private const float DISPERION_ADJUST = 0.2f;

		public static readonly int _Disper = Shader.PropertyToID("_Disper");
		private static Material _chromaticAberrationMaterial;
		
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