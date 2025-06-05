using UnityEngine;
using UnityEngine.Rendering;

namespace SmartPoint.Rendering
{
    [CreateAssetMenu(fileName = "Bloom", menuName = "ScriptableObjects/ImageEffect/Bloom")]
    public class Bloom : ImageEffectObject
    {
        private static Material fogMaterial;
        private const int MaxLayerCount = 5;

        // TODO
        public override CommandBuffer Build(RenderTargetIdentifier sourceRT, out RenderTargetIdentifier resultRT, bool feedbackCameraTarget = true)
        {
            var buffer = new CommandBuffer();
            buffer.name = "Bloom";

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

        public static void SetFogParameters(FogMode fogMode, float start, float end, float density, float farClip, Color baseColor, Color farColor)
        {
            if (fogMaterial == null)
                return;

            fogMaterial.DisableKeyword("_FOGMODE_NONE");

            switch (fogMode)
            {
                case FogMode.Linear:
                    fogMaterial.EnableKeyword("_FOGMODE_LINEAR");
                    fogMaterial.DisableKeyword("_FOGMODE_EXP");
                    fogMaterial.DisableKeyword("_FOGMODE_EXP2");
                    break;

                case FogMode.Exponential:
                    fogMaterial.DisableKeyword("_FOGMODE_LINEAR");
                    fogMaterial.EnableKeyword("_FOGMODE_EXP");
                    fogMaterial.DisableKeyword("_FOGMODE_EXP2");
                    break;

                case FogMode.ExponentialSquared:
                    fogMaterial.DisableKeyword("_FOGMODE_LINEAR");
                    fogMaterial.DisableKeyword("_FOGMODE_EXP");
                    fogMaterial.EnableKeyword("_FOGMODE_EXP2");
                    break;

                default:
                    fogMaterial.DisableKeyword("_FOGMODE_LINEAR");
                    fogMaterial.DisableKeyword("_FOGMODE_EXP");
                    fogMaterial.DisableKeyword("_FOGMODE_EXP2");
                    break;
            }

            float y = 1.0f / Mathf.Max(end - start, 0.1f);

            if (fogMode != FogMode.Linear)
            {
                y *= density;
                end = start;
            }

            fogMaterial.SetVector("_FogParam", new Vector4(end, y, 0.0f, farClip));
            fogMaterial.color = baseColor;
            fogMaterial.SetColor("_FarColor", farColor);
        }

        public static void SetFogColorAlpha(float baseAlpha, float farAlpha)
        {
            if (fogMaterial == null)
                return;

            var matColor = fogMaterial.color;
            fogMaterial.color = new Color(matColor.r, matColor.g, matColor.b, baseAlpha);

            var propColor = fogMaterial.GetColor("_FarColor");
            fogMaterial.SetColor("_FarColor", new Color(propColor.r, propColor.g, propColor.b, farAlpha));
        }
    }
}