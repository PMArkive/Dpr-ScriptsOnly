using System;
using UnityEngine;

[Serializable]
public class CustomNodeMaterial
{
    private static readonly int _FixMultiplierColor = Shader.PropertyToID("_FixMultiplierColor");
    private static readonly int _BillboardScale = Shader.PropertyToID("_BillboardScale");
    private const bool useMaterialBlock = true;
    private static MaterialPropertyBlock materialPropertyBlock;
    public MaterialParam mp;
    public string shaderName;

    [SerializeField]
    private CustomNodeProperty[] cnProperties;
    [ColorUsage(false, true)]
    public Color fixMultiplyColor;

    public CustomNodeProperty[] CnProperties { set => cnProperties = value; }

    public CustomNodeMaterial(Material mat)
    {
        shaderName = mat.shader.name;
        mp = new MaterialParam();
        mp.mat = mat;
        cnProperties = null;
    }

    public void SetUp(Renderer[] renderers)
    {
        mp.SetUpUsing(renderers);
    }

    public void Start()
    {
        if (materialPropertyBlock == null)
            materialPropertyBlock = new MaterialPropertyBlock();

        if (cnProperties != null)
        {
            for (int i=0; i<cnProperties.Length; i++)
                cnProperties[i].SetUp();
        }

        fixMultiplyColor = Color.white;
    }

    public void Update(float lossyScale)
    {
        if (mp.mat == null || materialPropertyBlock == null)
            return;

        materialPropertyBlock.Clear();

        for (int i=0; i<cnProperties.Length; i++)
        {
            if (shaderName == "Mitake/SmokeMask1st" || shaderName == "Mitake/SmokeMask_MT")
                cnProperties[i].UpdatePropertyBlockSmokeMask(materialPropertyBlock);
            else
                cnProperties[i].UpdatePropertyBlock(materialPropertyBlock);
        }

        materialPropertyBlock.SetColor(_FixMultiplierColor, fixMultiplyColor);
        materialPropertyBlock.SetFloat(_BillboardScale, lossyScale);

        for (int i=0; i<mp.usings.Length; i++)
        {
            var use = mp.usings[i];
            if (use.renderer != null)
                use.renderer.SetPropertyBlock(materialPropertyBlock, use.index);
        }
    }
}