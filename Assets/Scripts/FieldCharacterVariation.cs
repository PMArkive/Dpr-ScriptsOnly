using System;
using UnityEngine;

[Serializable]
public class FieldCharacterVariation
{
    [SerializeField]
    public Transform root;
    [SerializeField]
    public Transform neck;
    [SerializeField]
    public Transform lhand;
    [SerializeField]
    public Transform rhand;
    [SerializeField]
    public Renderer faceRenderer;
    [SerializeField]
    public int eyeMaterialIndex;
    [SerializeField]
    public int mouthMaterialIndex;
}