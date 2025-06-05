using SmartPoint.Rendering;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FieldPanCamera : MonoBehaviour
{
    private Camera _camera;
    private DepthOfField _dof;
    [SerializeField]
    private float _distance = 25.0f;
    [SerializeField]
    private float _pitch = 20.0f;
    [SerializeField]
    private float _fov = 15.0f;
    [SerializeField]
    private float _zOffset = 1.0f;
    [SerializeField]
    private float _top_offset;
    [SerializeField]
    private float _bottom_offset = -3.5f;
    [SerializeField]
    private bool _autoCalculation;
    [SerializeField]
    private Vector3 minPosition;
    [SerializeField]
    private Vector3 maxPosition;
    private ZoneID zoneID = ZoneID.UNKNOWN;
    private Bounds _bounds;
    private bool _initialized;

    public void onEnable()
    {
        _camera = GetComponent<Camera>();
        _initialized = false;
    }

    public void onDisable()
    {
        _initialized = false;
    }

    // TODO
    public void PanUpdate() { }

    public void SetPanCameraData(ZoneID zoneID)
    {
        if (zoneID != ZoneID.UNKNOWN)
        {
            var data = GameManager.mapInfo.Camera[(int)zoneID];

            _distance = data.panDistance;
            _pitch = data.panPitch;
            _fov = data.panFov;

            if (data.panpos_useflag)
            {
                minPosition.y = data.panMinposY;
                maxPosition.y = data.panMaxposY;
                maxPosition.z = data.panMaxposZ;
                maxPosition.z = data.panMaxposZ;
            }
        }
    }
}