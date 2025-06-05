using UnityEngine;

public class PokemonCustomNodeAnim : MonoBehaviour
{
    [Header("Debug")]
    public bool debugKey = true;
    [Header("Material")]
    public CustomNodeMaterial[] mCustomNodeMaterials;
    [Header("Visibility")]
    public CustomNodeVisibility[] mCNViss;
    public bool isAutoUpdate = true;
    private bool _isSetup;

    private void Start()
    {
        SetUp();
    }

    private void SetUp()
    {
        _isSetup = true;
        var scale = transform.lossyScale;

        for (int i=0; i<mCustomNodeMaterials.Length; i++)
        {
            mCustomNodeMaterials[i].Start();
            mCustomNodeMaterials[i].Update(scale.x);
        }

        for (int i=0; i<mCNViss.Length; i++)
            mCNViss[i]?.Update();
    }

    public void UpdateCusAnimNode()
    {
        if (!_isSetup)
            return;

        var scale = transform.lossyScale;

        for (int i=0; i<mCustomNodeMaterials.Length; i++)
            mCustomNodeMaterials[i].Update(scale.x);

        for (int i=0; i<mCNViss.Length; i++)
            mCNViss[i].Update();
    }

    private void LateUpdate()
    {
        if (isAutoUpdate)
            UpdateCusAnimNode();
    }
}