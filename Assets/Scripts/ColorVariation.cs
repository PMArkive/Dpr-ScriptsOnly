using System;
using UnityEngine;

public sealed class ColorVariation : MonoBehaviour
{
    public static readonly int _SkinColorID = Shader.PropertyToID("_SkinColor");
    public static readonly int _PrimaryColorID = Shader.PropertyToID("_PrimaryColor");
    public static readonly int _SecondaryColorID = Shader.PropertyToID("_SecondaryColor");
    public int ColorIndex;
    private MaterialPropertyBlock propertyBlock;
    [SerializeField]
    private Property[] Property00;
    [SerializeField]
    private Property[] Property01;
    [SerializeField]
    private Property[] Property02;
    [SerializeField]
    private Property[] Property03;

    public Property[] this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return Property00;
                case 1: return Property01;
                case 2: return Property02;
                case 3: return Property03;
                default: throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0: Property00 = value; break;
                case 1: Property01 = value; break;
                case 2: Property02 = value; break;
                case 3: Property03 = value; break;
            }
        }
    }

    private void OnEnable()
    {
        propertyBlock = new MaterialPropertyBlock();
    }

    public void LateUpdate()
    {
        if (propertyBlock == null)
            return;

        var property = this[ColorIndex];
        if (property.Length > 0)
        {
            for (int i=0; i<property.Length; i++)
                property[i].Update(propertyBlock);
        }
    }

    private void OnDisable()
    {
        propertyBlock = null;
    }

    [Serializable]
    public struct Property
    {
        [SerializeField]
        public Renderer renderer;
        [SerializeField]
        public MaskColor[] colors;

        public void Update(MaterialPropertyBlock propertyBlock)
        {
            for (int i=0; i<colors.Length; i++)
            {
                var color = colors[i];

                renderer.GetPropertyBlock(propertyBlock, color.materialIndex);
                switch (color.channel)
                {
                    case 0:
                        propertyBlock.SetColor(_SkinColorID, color.color);
                        break;

                    case 1:
                        propertyBlock.SetColor(_PrimaryColorID, color.color);
                        break;

                    case 2:
                        propertyBlock.SetColor(_SecondaryColorID, color.color);
                        break;
                }
                renderer.SetPropertyBlock(propertyBlock, color.materialIndex);
            }
        }

        [Serializable]
        public struct MaskColor
        {
            [SerializeField]
            public int materialIndex;
            [SerializeField]
            public int channel;
            [SerializeField]
            public Color color;
        }
    }
}