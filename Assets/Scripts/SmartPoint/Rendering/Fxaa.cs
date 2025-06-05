using UnityEngine;
using UnityEngine.Rendering;

namespace SmartPoint.Rendering
{
    [CreateAssetMenu(fileName = "FXAA", menuName = "ScriptableObjects/ImageEffect/FXAA")]
    public class Fxaa : ImageEffectObject
    {
        private static Material fxaaMaterial;

        // TODO
        public override CommandBuffer Build(RenderTargetIdentifier sourceRT, out RenderTargetIdentifier resultRT, bool feedbackCameraTarget = true)
        {
            Destroy();
            InstantiateMaterials();

            fxaaMaterial = materialInstances[0];

            var buffer = new CommandBuffer();
            buffer.name = "FXAA";

            resultRT = sourceRT;
            return buffer;
        }

        private static void SetKeyword(Material material, string keyword, bool state)
        {
            if (state)
                material.EnableKeyword(keyword);
            else
                material.DisableKeyword(keyword);
        }

        public static void SetColorGrading(Texture2D lut0, float influence, Texture2D lut1, float weight)
        {
            if (fxaaMaterial == null)
                return;

            SetKeyword(fxaaMaterial, "_GRADING_NONE", lut0 == null);
            SetKeyword(fxaaMaterial, "_GRADING_SINGLE", lut0 != null && lut1 == null);
            SetKeyword(fxaaMaterial, "_GRADING_MULTI", lut0 != null && lut1 != null);

            fxaaMaterial.SetFloat("_ColorGradingInfluence", influence);
            fxaaMaterial.SetFloat("_ColorGradingBlendWeight", weight);
            fxaaMaterial.SetTexture("_ColorGradingLUT0", lut0);
            fxaaMaterial.SetTexture("_ColorGradingLUT1", lut1);
        }
    }
}