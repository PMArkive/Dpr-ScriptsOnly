using System;
using UnityEngine;

public class PokemonVariation : MonoBehaviour
{
    [SerializeField]
    private PokeType pokeType;
    public string[] variations;
    public string variation = "00";
    [Header("Visibility")]
    public VisibilityParam[] mVisibilitys;
    [Header("Material")]
    [HideInInspector]
    public RendererMaterial[] rendererMaterials;
    [SerializeField]
    private Material[] mBaseMaterials;
    public MaterialParam[] mMaterialParams;
    [Header("Scale")]
    public float[] mVariationScale;
    [Header("Debug")]
    public bool debugKey = true;

    public PokeType Type { get => pokeType; set => pokeType = value; }
    public float ScaleVariation
    {
        get
        {
            if (mVariationScale != null && mVariationScale.Length != 0)
                return mVariationScale[Array.IndexOf(variations, variation)];
            else
                return 1.0f;
        }
    }

    // TODO
    private void Start() { }

    // TODO
    private void Update() { }

    // TODO
    private void UpdateVariation() { }

    // TODO
    public void ChangeVariation(string newVri) { }

    // TODO
    public void ChangePrevVariation() { }

    // TODO
    public void ChangeNextVariation() { }

    // TODO
    public void ChangeType(PokeType type) { }

    public enum PokeType : int
    {
        NORMAL = 0,
        SHINYCOLOR = 1,
        TEST = 2,
    }

    [Serializable]
    public class VisibilityParam
    {
        public GameObject[] boneVisibilitys;
        public string variation;
    }

    [Serializable]
    public class MaterialArray
    {
        public Material[] materials;

        public MaterialArray(int num)
        {
            materials = new Material[num];
        }
    }

    [Serializable]
    public class MaterialVariation
    {
        public MaterialArray[] materialArrays;
        public Material[] materials_default;
        public Material[] materials_rare;

        public Material[] GetMaterials(PokeType pt)
        {
            if (materialArrays != null && (int)pt < materialArrays.Length)
                return materialArrays[(int)pt].materials;
            else
                return null;
        }
    }

    [Serializable]
    public class MaterialParam
    {
        public string variation;
        public MaterialVariation materialVariation;

        public MaterialParam(MaterialParam source)
        {
            variation = source.variation;
            materialVariation = source.materialVariation;
        }
    }

    [Serializable]
    public class RendererMaterial
    {
        public Renderer renderer;
        public Material[] materials;
        public int[] materialIndexs;
    }
}