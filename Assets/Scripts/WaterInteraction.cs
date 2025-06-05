using UnityEngine;
using XLSXContent;

public class WaterInteraction : ProceduralPlane
{
    protected static readonly int ID_WATERCOLOR = Shader.PropertyToID("_WaterSurfaceColor");
    protected static readonly int ID_WATERATTENUATION = Shader.PropertyToID("_WaterAttenuation");
    protected static readonly int ID_WATERUPSCALE = Shader.PropertyToID("_WaterUpScale");
    protected static readonly int ID_WATERMAXDENSITY = Shader.PropertyToID("_WaterMaxDensity");
    protected static readonly int ID_REFLECTIVITY = Shader.PropertyToID("_Reflectivity");
    protected static readonly int ID_FRESNELPOWER = Shader.PropertyToID("_FresnelPower");
    protected static readonly int ID_SPECULARPOWER = Shader.PropertyToID("_SpecularCosinePower");
    protected static readonly int ID_SPECULARINTENSITY = Shader.PropertyToID("_SpecularColorIntensity");
    protected static readonly int ID_ = Shader.PropertyToID("_WaterSurfaceColor");

    [SerializeField]
    private bool useWaterSettings = true;
    [SerializeField]
    protected Color _waterColor = new Color(0.2f, 0.4f, 1.0f);
    [SerializeField]
    [Range(0.1f, 4.0f)]
    protected float _waterUpScale = 0.25f;
    [SerializeField]
    [Range(0.1f, 8.0f)]
    protected float _waterAttenuation = 2.0f;
    [SerializeField]
    [Range(0.1f, 1.0f)]
    protected float _waterMaxDensity = 0.95f;
    [SerializeField]
    [Range(0.0f, 1.0f)]
    protected float _reflectivity = 0.03f;
    [SerializeField]
    [Range(0.01f, 8.0f)]
    protected float _fresnelPower = 5.0f;
    [SerializeField]
    [Range(0.0f, 1024.0f)]
    protected float _specularIntensity = 256.0f;
    [SerializeField]
    [Range(1.0f, 1024.0f)]
    protected float _specularCosinePower = 64.0f;
    [SerializeField]
    [Range(1.0f, 3.0f)]
    protected int _randomDropCount = 1;
    [SerializeField]
    [Range(0.001f, 0.2f)]
    protected float _randomDropDepthMin = 0.025f;
    [SerializeField]
    [Range(0.001f, 0.2f)]
    protected float _randomDropDepthMax = 0.1f;
    [SerializeField]
    protected CentroidType _centroidType;
    [SerializeField]
    protected Texture2D _initialWater;
    private bool _isInitialized;
    public static WaterSettings.SheetSettings waterSettings = null;
    public static WaterInteraction global;

    public Color waterColor { get => _waterColor; set => _waterColor = value; }
    public float waterUpScale { get => _waterUpScale; set => _waterUpScale = value; }
    public float waterAttenuation { get => _waterAttenuation; set => _waterAttenuation = value; }
    public float waterMaxDensity { get => _waterMaxDensity; set => _waterMaxDensity = value; }
    public CentroidType centroidType { get => _centroidType; set => _centroidType = value; }

    // TODO
    protected override void OnEnable() { }

    // TODO
    protected override void OnDisable() { }

    // TODO
    private Vector2Int IntersectPlaneXZ(Vector3 point, Vector3 direction) { return Vector2Int.zero; }

    // TODO
    protected override void OnUpdate() { }

    public enum CentroidType : int
    {
        Player = 0,
        EyeRay = 1,
    }
}