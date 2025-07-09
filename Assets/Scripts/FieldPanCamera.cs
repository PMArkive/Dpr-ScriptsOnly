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

    public void PanUpdate()
    {
        if (GameManager.connector == null)
            return;

        if (GameManager.connector.sceneID != SceneID.Field)
            return;

        if (PlayerWork.zoneID != ZoneID.UNKNOWN)
        {
            if (GameManager.mapInfo[(int)PlayerWork.zoneID].RoomPanCamera)
            {
                if (PlayerWork.zoneID != zoneID)
                {
                    zoneID = PlayerWork.zoneID;
                    _initialized = false;
                }
            }
            else
            {
                _initialized = false;
            }
        }

        if (!_initialized)
        {
            _dof = DepthOfField.instance;
            minPosition = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
            maxPosition = new Vector3(float.MinValue, float.MinValue, float.MinValue);

            SetPanCameraData(PlayerWork.zoneID);
            _initialized = true;
        }

        _bounds.SetMinMax(minPosition, maxPosition);

        var tf = EntityManager.activeFieldPlayer == null ? null : EntityManager.activeFieldPlayer.transform;

        if (tf != null)
        {
            _dof.target = tf;

            var euler = _camera.transform.eulerAngles;
            euler.x = _pitch;
            euler.y = 180.0f;
            euler.z = FlagWork.GetSysFlag(Dpr.EvScript.EvWork.SYSFLAG_INDEX.SYS_FLAG_CAMERA_REVERSAL) ? 180.0f : 0.0f;
            _camera.transform.eulerAngles = euler;

            _camera.fieldOfView = _fov;

            var y = ((-_camera.transform.forward) * _distance).y;
            if (_autoCalculation)
            {
                _bottom_offset = y / Mathf.Tan((_pitch + _fov * 0.5f) * Mathf.Deg2Rad) + _bounds.center.z + _bounds.extents.z;
                _top_offset = (y - (_bounds.center.y + _bounds.extents.y)) / Mathf.Tan((_pitch - _fov * 0.5f) * Mathf.Deg2Rad) + _bounds.center.z - _bounds.extents.z;
            }

            var z = _bottom_offset;
            if (_top_offset <= _bottom_offset)
            {
                var zBaseOffset = _zOffset + _bounds.center.z + _bounds.extents.z;
                z = Mathf.Lerp(_bottom_offset, _top_offset, -(tf.position.z - zBaseOffset) / (zBaseOffset - (_bounds.center.z - _bounds.extents.z - _zOffset)));
            }

            _camera.transform.localPosition = new Vector3(tf.position.x, y, z);
        }
    }

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
                minPosition.z = data.panMinposZ;
                maxPosition.z = data.panMaxposZ;
            }
        }
    }
}