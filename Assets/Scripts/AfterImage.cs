using SmartPoint.AssetAssistant;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Camera))]
public class AfterImage : MonoBehaviour, IViewportChangeHandler, IEventSystemHandler
{
    private Camera _camera;
    private RenderTexture _renderTexture;
    private static readonly int BlendWeightID = Shader.PropertyToID("_BlendWeight");
    private static readonly int AngleID = Shader.PropertyToID("_Angle");
    private static readonly int ReciprocalScaleID = Shader.PropertyToID("_ReciprocalScale");
    private Material materialInstance;
    [SerializeField]
    private float angle;
    [SerializeField]
    private float scale = 1.0f;
    private bool copyOnce;

    public float Angle { set => angle = value; get => angle;  }
    public float Scale { set => scale = value; get => scale; }
    public RenderTexture renderTexture { get => _renderTexture; }

    // TODO
    public void OnViewportChange(int width, int height) { }

    // TODO
    private void Cleanup() { }

    // TODO
    private void OnEnable() { }

    // TODO
    private void OnRenderImage(RenderTexture input, RenderTexture output) { }

    // TODO
    private void OnDisable() { }
}