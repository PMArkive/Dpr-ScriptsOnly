using System;
using UnityEngine;

namespace Dpr.Message
{
    [Serializable]
    public class FontMaterialProperty
    {
        [SerializeField]
        public string name;
        [Header("Face")]
        [SerializeField]
        public bool useFace;
        [SerializeField]
        public Color faceColor = Color.white;
        [SerializeField]
        [Range(-1.0f, 1.0f)]
        public float faceSoftness;
        [SerializeField]
        [Range(-1.0f, 1.0f)]
        public float faceDilate;
        public static readonly int PropFaceColor = Shader.PropertyToID("_FaceColor");
        public static readonly int PropOutlineSoftness = Shader.PropertyToID("_OutlineSoftness");
        public static readonly int PropFaceDilate = Shader.PropertyToID("_FaceDilate");
        [Header("Outline")]
        [SerializeField]
        public bool useOutline;
        [SerializeField]
        public Color outlineColor = Color.black;
        [SerializeField]
        [Range(0.0f, 1.0f)]
        public float outlineThickness;
        public static readonly int PropOutlineColor = Shader.PropertyToID("_OutlineColor");
        public static readonly int PropOutlineWidth = Shader.PropertyToID("_OutlineWidth");
        [Header("Glow")]
        [SerializeField]
        public bool useGlow;
        [SerializeField]
        public Color glowColor = Color.green;
        [SerializeField]
        [Range(-1.0f, 1.0f)]
        public float glowOffset;
        [SerializeField]
        [Range(0.0f, 1.0f)]
        public float glowInner = 0.05f;
        [SerializeField]
        [Range(0.0f, 1.0f)]
        public float glowOuter = 0.05f;
        [SerializeField]
        [Range(0.0f, 1.0f)]
        public float glowPower = 0.75f;
        public static readonly int PropGlowColor = Shader.PropertyToID("_GlowColor");
        public static readonly int PropGlowOffset = Shader.PropertyToID("_GlowOffset");
        public static readonly int PropGlowInner = Shader.PropertyToID("_GlowInner");
        public static readonly int PropGlowOuter = Shader.PropertyToID("_GlowOuter");
        public static readonly int PropGlowPower = Shader.PropertyToID("_GlowPower");
        [Header("Underlay")]
        [SerializeField]
        public bool useUnderlay;
        [SerializeField]
        public Color underlayColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);
        [SerializeField]
        [Range(-1.0f, 1.0f)]
        public float underlayOffsetX;
        [SerializeField]
        [Range(-1.0f, 1.0f)]
        public float underlayOffsetY;
        [SerializeField]
        [Range(-1.0f, 1.0f)]
        public float underLayDilate;
        [SerializeField]
        [Range(0.0f, 1.0f)]
        public float underlaySoftness;
        public static readonly int PropUnderlayColor = Shader.PropertyToID("_UnderlayColor");
        public static readonly int PropUnderlayOffsetX = Shader.PropertyToID("_UnderlayOffsetX");
        public static readonly int PropUnderlayOffsetY = Shader.PropertyToID("_UnderlayOffsetY");
        public static readonly int PropUnderlayDilate = Shader.PropertyToID("_UnderlayDilate");
        public static readonly int PropUnderlaySoftness = Shader.PropertyToID("_UnderlaySoftness");
        [Header("DebugSetting")]
        [SerializeField]
        public bool useDebugSetting;
        [SerializeField]
        public float debugSettingGradientScale = 6.0f;
        [SerializeField]
        [Range(-1.0f, 1.0f)]
        public float debugSettingSharpness;
        public static readonly int PropDebugSettingGradientScale = Shader.PropertyToID("_GradientScale");
        public static readonly int PropDebugSettingSharpness = Shader.PropertyToID("_Sharpness");
    }
}