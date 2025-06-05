using UnityEngine;

public class Snowfield : ProceduralPlane
{
    protected static readonly int ID_HEIGHT_MAP = Shader.PropertyToID("_HeightMap");
    protected static readonly int ID_CORNER = Shader.PropertyToID("_Corner");
    protected static readonly int ID_SNOWCOVER = Shader.PropertyToID("_Decrease");

    public static Snowfield global;
    [SerializeField]
    protected float _snowCover = 0.005f;
    [SerializeField]
    protected Texture2D _skierFootprintTexture;
    [SerializeField]
    protected Texture2D _heightMap;
    [SerializeField]
    protected Vector3Int _corner = Vector3Int.zero;
    private Material transferMaterial;

    public float snowCover { get => _snowCover; set => _snowCover = value; }

    protected override void OnEnable()
    {
        global = this;

        base.OnEnable();

        if (_transferMaterial != null)
            transferMaterial = new Material(_transferMaterial);
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        if (transferMaterial != null)
        {
            DestroyImmediate(transferMaterial);
            transferMaterial = null;
        }

        global = null;
    }

    // TODO
    protected override void OnUpdate() { }
}