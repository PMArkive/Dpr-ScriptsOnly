using UnityEngine;

namespace Dpr.Message
{
    [CreateAssetMenu(fileName = "FontMaterialData", menuName = "ScriptableObjects/FontMaterialData")]
    public class FontMaterialData : ScriptableObject
    {
        [Header("【Material Index 0 指定で反映される設定】")]
        public FontMaterialProperty defaultMaterialProperty;
        [Header("【Material Index は1からになります】")]
        public FontMaterialProperty[] materialPropertyArray;
    }
}
