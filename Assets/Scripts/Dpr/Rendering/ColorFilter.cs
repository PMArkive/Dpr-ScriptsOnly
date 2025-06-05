using Dpr.Battle.View;
using SmartPoint.Rendering;
using UnityEngine;
using UnityEngine.Rendering;

namespace Dpr.Rendering
{
	[CreateAssetMenu(menuName = "ScriptableObjects/ImageEffect/ColorFilter", fileName = "ColorFilter")]
	public class ColorFilter : ImageEffectObject
	{
		public static readonly int _Color = Shader.PropertyToID("_Color");
		private static Material _colorFilteMaterial = null;
		
		public Material[] materials { get => materialInstances; }
		
		// TODO
		public override CommandBuffer Build(RenderTargetIdentifier sourceRT, out RenderTargetIdentifier resultRT, bool feedbackCameraTarget = true)
		{
			resultRT = default;
			return default;
		}
		
		// TODO
		public void Blit(RenderTexture src, RenderTexture dest) { }
		
		// TODO
		public void UpdateShaderProperties(PfxParam param) { }
	}
}