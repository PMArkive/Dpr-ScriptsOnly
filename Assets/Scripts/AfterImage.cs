using SmartPoint.AssetAssistant;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.Rendering;

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

    public void OnViewportChange(int width, int height)
    {
        Cleanup();
    }

    private void Cleanup()
    {
        OnDisable();

        if (_camera == null)
            _camera = GetComponent<Camera>();

        if (_camera == null)
            return;

        int width;
        int height;
        if (_camera?.targetTexture != null)
        {
            width = _camera.targetTexture.width;
            height = _camera.targetTexture.height;
        }
        else
        {
            width = Sequencer.screenWidth;
            height = Sequencer.screenHeight;
        }

        if (materialInstance == null)
            materialInstance = new Material(AssetManager.FindShader("Custom/AfterImage"));

        if (_renderTexture == null)
        {
            _renderTexture = new RenderTexture(width, height, 24, DefaultFormat.LDR);
            _renderTexture.autoGenerateMips = false;
        }

        copyOnce = true;
        materialInstance.SetTexture("_PrevFrameTex", _renderTexture);
    }

    private void OnEnable()
    {
        Cleanup();
    }

    private void OnRenderImage(RenderTexture input, RenderTexture output)
    {
        if (materialInstance == null)
            return;

        materialInstance.SetFloat(AngleID, angle * Mathf.Deg2Rad);
        materialInstance.SetFloat(ReciprocalScaleID, 1.0f / Mathf.Max(scale, 0.01f));

        if (copyOnce)
        {
            materialInstance.SetFloat(BlendWeightID, 1.0f);
            copyOnce = false;
        }
        else
        {
            materialInstance.SetFloat(BlendWeightID, 0.2f);
        }

        Graphics.Blit(input, output, materialInstance);
        Graphics.Blit(output, _renderTexture);
    }

    private void OnDisable()
    {
        if (_renderTexture != null)
            DestroyImmediate(_renderTexture);

        if (materialInstance != null)
            DestroyImmediate(materialInstance);

        materialInstance = null;
        _renderTexture = null;
        _camera = null;
    }
}