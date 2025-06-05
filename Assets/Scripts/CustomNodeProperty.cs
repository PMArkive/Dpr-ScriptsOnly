using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CustomNodeProperty
{
    public GameObject bone;
    public GameObject boneSub;
    public string propertyName;
    public PropertyType pType;
    public Vector2 baseUV;
    public Vector2 baseScale;
    private string propertyName_U;
    private string propertyName_V;

    // TODO: This looks very wrong but I'm not sure what's actually done here
    protected float GetAttributeFloat(IDictionary<string, object> dictAttr, string attrName)
    {
        return (float)(double)((IDictionary<string, object>)dictAttr[attrName])["Value"];
    }

    public void SetUp()
    {
        if (pType == PropertyType.UV)
        {
            propertyName_U = "_" + propertyName + "U";
            propertyName_V = "_" + propertyName + "V";
        }
    }

    public void Update(Material mat)
    {
        switch (pType)
        {
            case PropertyType.FLOAT:
                mat.SetFloat("_" + propertyName, bone.transform.localPosition.x * -100.0f);
                break;

            case PropertyType.UV:
                mat.SetFloat("_" + propertyName + "U", bone.transform.localPosition.x * -100.0f);
                mat.SetFloat("_" + propertyName + "V", bone.transform.localPosition.y * 100.0f);
                break;

            case PropertyType.UV_POKEDEFAULT_COL0TEX:
                mat.SetTextureOffset("_Col0Tex", new Vector2(bone.transform.localPosition.x * 100.0f * baseScale.x, bone.transform.localPosition.y * -100.0f * baseScale.y));
                break;

            case PropertyType.UV_POKEDEFAULT_LAYERTEX:
            case PropertyType.UV_POKEDEFAULT_LAYERTEX_NOT_ROUND:
                mat.SetTextureOffset("_L1Col0Tex", new Vector2(bone.transform.localPosition.x * 100.0f * baseScale.x, bone.transform.localPosition.y * -100.0f * baseScale.y));
                break;

            case PropertyType.UVSL_POKEDEFAULT_COL0TEX:
                baseScale = new Vector2(bone.transform.localScale.x, bone.transform.localScale.x); // Both use x scale
                mat.SetTextureOffset("_Col0Tex", new Vector2(Mathf.Repeat(bone.transform.localPosition.x * 100.0f, 1.0f) * baseScale.x, Mathf.Repeat(bone.transform.localPosition.y * -100.0f, 1.0f) * baseScale.y));
                break;

            case PropertyType.SUV_POKEDEFAULT_COL0TEX:
                mat.SetTextureOffset("_Col0Tex", new Vector2(bone.transform.localPosition.x * 100.0f * baseScale.x, bone.transform.localPosition.x * 100.0f * baseScale.y)); // Both use x position
                break;

            case PropertyType.UV_GROUNDEFFECT_GROUNDEffECTMASKTEX:
                mat.SetTextureOffset("_GourndEffectMaskTex", new Vector2(bone.transform.localPosition.x * 100.0f, bone.transform.localPosition.y * -100.0f));
                break;

            case PropertyType.UVSL_POKEDEFAULT_LAYERTEX:
                baseScale = new Vector2(bone.transform.localScale.x, bone.transform.localScale.x); // Both use x scale
                mat.SetTextureOffset("_L1Col0Tex", new Vector2(Mathf.Repeat(bone.transform.localPosition.x * 100.0f, 1.0f) * baseScale.x, Mathf.Repeat(bone.transform.localPosition.y * -100.0f, 1.0f) * baseScale.y));
                break;
        }
    }

    public void UpdateSmokeMask(Material mat)
    {
        switch (pType)
        {
            case PropertyType.FLOAT:
                mat.SetFloat("_" + propertyName, bone.transform.localPosition.x * -100.0f);
                break;

            case PropertyType.UV:
                mat.SetFloat("_Mask0UVTranslateU", bone.transform.localPosition.x * -100.0f);
                break;

            case PropertyType.UV_POKEDEFAULT_COL0TEX:
            case PropertyType.UV_POKEDEFAULT_LAYERTEX:
            case PropertyType.UV_POKEDEFAULT_LAYERTEX_NOT_ROUND:
                mat.SetTextureOffset("_Col0Tex", new Vector2(Mathf.Repeat(bone.transform.localPosition.x * 100.0f, 1.0f) * baseScale.x, bone.transform.localPosition.y * -100.0f * baseScale.y));
                break;
        }
    }

    public void UpdatePropertyBlock(MaterialPropertyBlock mpb)
    {
        switch (pType)
        {
            case PropertyType.FLOAT:
                mpb.SetFloat("_" + propertyName, bone.transform.localPosition.x * -100.0f);
                break;

            case PropertyType.UV:
                mpb.SetFloat(propertyName_U, bone.transform.localPosition.x * -100.0f);
                mpb.SetFloat(propertyName_V, bone.transform.localPosition.y * 100.0f);
                break;

            case PropertyType.UV_POKEDEFAULT_COL0TEX:
                {
                    var z = Mathf.Round(bone.transform.localPosition.x * 100.0f * 2.0f) * 0.5f * baseScale.x;
                    var w = Mathf.Round(bone.transform.localPosition.y * -100.0f * 4.0f) * 0.25f * baseScale.y;
                    mpb.SetVector("_Col0Tex_ST", new Vector4(baseScale.x, baseScale.y, z, w));
                }
                break;

            case PropertyType.UV_POKEDEFAULT_LAYERTEX:
                {
                    var z = Mathf.Round(bone.transform.localPosition.x * 100.0f * 2.0f) * 0.5f * baseScale.x;
                    var w = Mathf.Round(bone.transform.localPosition.y * -100.0f * 4.0f) * 0.25f * baseScale.y;
                    mpb.SetVector("_L1Col0Tex_ST", new Vector4(baseScale.x, baseScale.y, z, w));
                }
                break;

            case PropertyType.UVSL_POKEDEFAULT_COL0TEX:
                baseScale = new Vector2(bone.transform.localScale.x, bone.transform.localScale.y);
                mpb.SetVector("_Col0Tex_ST", new Vector4(baseScale.x, baseScale.y, bone.transform.localPosition.x * 100.0f * baseScale.x, bone.transform.localPosition.y * -100.0f * baseScale.y));
                break;

            case PropertyType.SUV_POKEDEFAULT_COL0TEX:
                mpb.SetVector("_Col0Tex_ST", new Vector4(baseScale.x, baseScale.y, bone.transform.localPosition.x * 100.0f * baseScale.x, bone.transform.localPosition.x * 100.0f * baseScale.y)); // Both use x position
                break;

            case PropertyType.UV_GROUNDEFFECT_GROUNDEffECTMASKTEX:
                mpb.SetVector("_GourndEffectMaskTex_ST", new Vector4(baseScale.x, baseScale.y, bone.transform.localPosition.x * 100.0f, bone.transform.localPosition.y * -100.0f));
                break;

            case PropertyType.UVSL_POKEDEFAULT_LAYERTEX:
                baseScale = new Vector2(bone.transform.localScale.x, bone.transform.localScale.y);
                mpb.SetVector("_L1Col0Tex_ST", new Vector4(baseScale.x, baseScale.y, bone.transform.localPosition.x * 100.0f * baseScale.x, bone.transform.localPosition.y * -100.0f * baseScale.y)); 
                break;

            case PropertyType.UV_POKEDEFAULT_LAYERTEX_NOT_ROUND:
                mpb.SetVector("_L1Col0Tex_ST", new Vector4(baseScale.x, baseScale.y, bone.transform.localPosition.x * 100.0f * baseScale.x, bone.transform.localPosition.y * -100.0f * baseScale.y));
                break;
        }
    }

    public void UpdatePropertyBlockSmokeMask(MaterialPropertyBlock mpb)
    {
        switch (pType)
        {
            case PropertyType.FLOAT:
                mpb.SetFloat("_" + propertyName, bone.transform.localPosition.x * -100.0f);
                break;

            case PropertyType.UV:
                mpb.SetFloat("_Mask0UVTranslateU", bone.transform.localPosition.x * -100.0f);
                break;

            case PropertyType.UV_POKEDEFAULT_COL0TEX:
                mpb.SetVector("_Col0Tex_ST", new Vector4(baseScale.x, baseScale.y, Mathf.Repeat(bone.transform.localPosition.x * 100.0f, 1.0f) * baseScale.x, bone.transform.localPosition.y * -100.0f * baseScale.y));
                break;

            case PropertyType.UV_POKEDEFAULT_LAYERTEX:
            case PropertyType.UV_POKEDEFAULT_LAYERTEX_NOT_ROUND:
                mpb.SetVector("_L1Col0Tex_ST", new Vector4(baseScale.x, baseScale.y, Mathf.Repeat(bone.transform.localPosition.x * 100.0f, 1.0f) * baseScale.x, bone.transform.localPosition.y * -100.0f * baseScale.y));
                break;

            case PropertyType.UVSL_POKEDEFAULT_COL0TEX:
                baseScale = new Vector2(bone.transform.localScale.x, bone.transform.localScale.y);
                mpb.SetVector("_Col0Tex_ST", new Vector4(baseScale.x, baseScale.y, Mathf.Repeat(bone.transform.localPosition.x * 100.0f, 1.0f) * baseScale.x, bone.transform.localPosition.y * -100.0f * baseScale.y));
                break;

            case PropertyType.UVSL_POKEDEFAULT_LAYERTEX:
                baseScale = new Vector2(bone.transform.localScale.x, bone.transform.localScale.y);
                mpb.SetVector("_L1Col0Tex_ST", new Vector4(baseScale.x, baseScale.y, Mathf.Repeat(bone.transform.localPosition.x * 100.0f, 1.0f) * baseScale.x, bone.transform.localPosition.y * -100.0f * baseScale.y));
                break;
        }
    }

    public enum PropertyType : int
    {
        FLOAT = 0,
        UV = 1,
        UV_POKEDEFAULT_COL0TEX = 2,
        UV_POKEDEFAULT_LAYERTEX = 3,
        UVSL_POKEDEFAULT_COL0TEX = 4,
        SUV_POKEDEFAULT_COL0TEX = 5,
        UV_GROUNDEFFECT_GROUNDEffECTMASKTEX = 6,
        UVSL_POKEDEFAULT_LAYERTEX = 7,
        UV_POKEDEFAULT_LAYERTEX_NOT_ROUND = 8,
    }
}