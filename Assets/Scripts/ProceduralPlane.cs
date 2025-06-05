using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
public class ProceduralPlane : MonoBehaviour
{
    protected static readonly int ID_MAIN_TEX = Shader.PropertyToID("_MainTex");
    protected static readonly int ID_SUBDUCTION = Shader.PropertyToID("_Subduction");
    protected static readonly int ID_DYNAMIC_NORMALMAP = Shader.PropertyToID("_DynamicNormalMap");
    protected static readonly int ID_FIELD_RT = Shader.PropertyToID("_TemporaryFieldRT");
    protected static readonly int ID_RCP_GRIDSIZE = Shader.PropertyToID("_RcpGridSize");
    protected static readonly int ID_GRID_X = Shader.PropertyToID("_GridX");
    protected static readonly int ID_GRID_Y = Shader.PropertyToID("_GridY");
    protected static readonly int ID_FOOT_ANGLE = Shader.PropertyToID("_FootAngle");
    protected static readonly int ID_FOOT_SCALE = Shader.PropertyToID("_FootScale");

    [SerializeField]
    protected string _proceduralPlaneName = "ProceduralPlane";
    [SerializeField]
    protected Color _initialColor = Color.black;
    [SerializeField]
    protected int _textureWidth = 512;
    [SerializeField]
    protected int _textureHeight = 512;
    [SerializeField]
    protected RenderTextureFormat _textureFormat = RenderTextureFormat.R8;
    [SerializeField]
    protected TextureWrapMode _textureWrapMode = TextureWrapMode.Clamp;
    [SerializeField]
    protected Material _footprintMaterial;
    [SerializeField]
    protected Material _transferMaterial;
    [SerializeField]
    protected RenderTextureFormat _dynamicNormalMapFormat = RenderTextureFormat.RG16;
    [SerializeField]
    protected Material _dynamicNormalMapMaterial;
    [SerializeField]
    protected float _subduction = 1.0f;
    [SerializeField]
    protected int _gridSize = 21;
    [SerializeField]
    protected float _gridScale = 1.0f;
    [SerializeField]
    protected int _gridDivision = 10;
    [SerializeField]
    protected float _planeElevation = 0.75f;
    [SerializeField]
    protected float _swingWidth = 0.2f;
    [SerializeField]
    protected RawImage _debugDisplay;
    protected RenderTexture _renderTexture;
    protected RenderTexture _dynamicNormalTexture;
    protected CommandBuffer _commandBuffer;
    protected Mesh _quadMesh;
    protected Mesh _fieldMesh;
    protected Vector2Int _previousGrid;
    protected MeshRenderer _meshRenderer;
    protected MeshFilter _meshFilter;
    protected MaterialPropertyBlock _propertyBlock;
    protected Dictionary<Transform, (Vector3, Quaternion)> _hipTrails = new Dictionary<Transform, (Vector3, Quaternion)>();

    public float planeElevation { get => _planeElevation; set => _planeElevation = value; }

    // TODO
    protected void CreateAssets() { }

    // TODO
    protected virtual void OnSetup() { }

    // TODO
    protected void DestroyAssets() { }

    // TODO
    protected virtual void OnValidate() { }

    // TODO
    protected virtual void OnEnable() { }

    // TODO
    protected virtual void OnDisable() { }

    // TODO
    protected virtual Transform GetTargetTransform(FieldObjectEntity objectEntity) { return null; }

    // TODO
    protected virtual void OnUpdate() { }

    // TODO
    private Mesh CreatePlaneMesh(string name, int cols, int rows, float width, float height) { return null; }
}