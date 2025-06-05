using Dpr;
using Dpr.EvScript;
using FieldCommon;
using GameData;
using SmartPoint.Rendering;
using UnityEngine;
using XLSXContent;

[RequireComponent(typeof(Camera))]
public class FieldCamera : MonoBehaviour
{
    private Transform _target;
    private Camera _camera;
    [SerializeField]
    private float _pitch = 45.0f;
    [SerializeField]
    private float _fov = 30.0f;
    [SerializeField]
    private float _targetRange = 30.0f;
    [SerializeField]
    private float _defocusStart = 0.5f;
    [SerializeField]
    private float _defocusEnd = 2.5f;
    private float _start_pitch = 45.0f;
    private float _start_fov = 30.0f;
    private float _start_targetRange = 30.0f;
    private float _start_defocusStart = 0.5f;
    private float _start_defocusEnd = 2.5f;
    private float _end_pitch = 45.0f;
    private float _end_fov = 30.0f;
    private float _end_targetRange = 30.0f;
    private float _end_defocusStart = 0.5f;
    private float _end_defocusEnd = 2.5f;
    private float _pitch_time;
    private float _pitch_work_wait;
    private Vector3 oldPosition;

    public Vector3 offset { get; set; } = Vector3.zero;
    public Vector3 offsetAngle { get; set; } = Vector3.zero;
    public Transform Target { set => _target = value; get => _target; }

    [SerializeField]
    private float _cameraLerpRate = 10.0f;
    public Camera EncountEffectCamera;
    public bool IsUpdateStop;

    public EventCamera EventCamera { set; get; }
    public FieldCameraShake FieldCameraShake { set; get; } = new FieldCameraShake();
    public FieldFloatMove TargetRangeOffset { set; get; } = new FieldFloatMove();
    public float Fov { get => _camera.fieldOfView; set => _camera.fieldOfView = value; }

    private bool isPanCamera;
    private FieldPanCamera _panCamera;
    private GameObject DarkWindow;
    private float _scriptFardepth;
    private float _scriptFardepthTime;
    private float _scriptFardepthTimeVectol = -1.0f;

    public AfterImage AfterImage { set; get; }

    private float _fovOffset;
    private float _fovOffsetStart;
    private float _fovOffsetEnd;
    private float _fovOffsetTime;
    private float _fovOffsetTimeScale;
    private Transform returnDofTransform;
    private GameObject tempDofTransform;
    private bool IsStopDofTarget;

    public void SetPanCameraFlag(bool flag)
    {
        isPanCamera = flag;

        if (flag)
            _panCamera.onEnable();
        else
            _panCamera.onDisable();
    }

    public bool GetPanCameraFlag()
    {
        return isPanCamera;
    }

    private void Awake()
    {
        // Empty
    }

    public float TargetRange { get => _targetRange; }

    private void OnEnable()
    {
        GameManager.fieldCamera = this;
        _camera = GetComponent<Camera>();
        _panCamera = GetComponent<FieldPanCamera>();
        IsUpdateStop = false;

        if (EventCamera == null)
            EventCamera = new EventCamera(this);

        TargetRangeOffset.EaseFunc = FieldFloatMove.EaseInOutSin;

        if (AfterImage == null)
        {
            var compositor = transform.Find("Compositor");
            if (compositor != null)
            {
                AfterImage = compositor.GetComponent<AfterImage>();
                AfterImage.enabled = false;
            }
        }

        EncountEffectCamera.SetActive(false);
    }

    private void Update()
    {
        float deltaTime = Time.deltaTime;
        UpdateMapInfoParam(deltaTime);
        TargetRangeOffset.Update(deltaTime);

        if (isPanCamera)
        {
            _panCamera.PanUpdate();
            _camera.transform.eulerAngles += offsetAngle;
            _camera.transform.position += offset;
        }
        else
        {
            CameraUpdate(deltaTime);
        }

        FieldCameraShake.Update(deltaTime);
        _camera.transform.position += FieldCameraShake.ShakeOffset;
    }

    private void LateUpdate()
    {
        if (DepthOfField.instance != null)
        {
            if (!IsStopDofTarget)
                DepthOfField.instance.target = _target;

            DepthOfField.instance.focalLength = _defocusStart;
            DepthOfField.instance.farDepth = Mathf.Lerp(_defocusEnd, _scriptFardepth, _scriptFardepthTime);

            _scriptFardepthTime += Time.deltaTime * _scriptFardepthTimeVectol;
            _scriptFardepthTime = Mathf.Clamp(_scriptFardepthTime, 0.0f, 1.0f);
        }

        EventCamera.lateUpdate(Time.deltaTime);

        if (FieldAnimeCamera.instance != null && FieldAnimeCamera.instance.IsPlay())
        {
            _camera.transform.position = FieldAnimeCamera.instance.transform.position;
            _camera.transform.rotation = FieldAnimeCamera.instance.transform.rotation;
            _camera.fieldOfView = FieldAnimeCamera.instance.GetFov() + _fovOffset;

            if (DepthOfField.instance != null)
                DepthOfField.instance.focalLength = FieldAnimeCamera.instance.GetFocalLength();
        }
    }

    public void ForceUpdateCamera()
    {
        CameraUpdate(1000.0f);
    }

    private void CameraUpdate(float deltaTime)
    {
        if (_target == null || !_target.gameObject.activeInHierarchy)
        {
            if (EntityManager.activeFieldPlayer != null)
                _target = EntityManager.activeFieldPlayer.transform;
            else
                _target = null;

            if (_target == null)
                return;
        }

        if (IsUpdateStop)
            return;

        _ = _camera.transform.eulerAngles;

        float z = FlagWork.GetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_CAMERA_REVERSAL) ? 180.0f : 0.0f;
        _camera.transform.eulerAngles = new Vector3(_pitch, 180.0f, z) + offsetAngle;
        _camera.fieldOfView = _fov + _fovOffset;

        Vector3 maxVec = _target.position + offset + new Vector3(0.0f, 0.5f);
        oldPosition = Vector3.Lerp(oldPosition, maxVec, _cameraLerpRate * deltaTime);

        _camera.transform.position = oldPosition - (_camera.transform.forward * (_targetRange + TargetRangeOffset.CurrentValue));

        if (_fovOffset != _fovOffsetEnd)
        {
            _fovOffset = Mathf.Lerp(_fovOffsetStart, _fovOffsetEnd, _fovOffsetTime);
            _fovOffsetTime += _fovOffsetTimeScale * deltaTime;
            if (_fovOffsetTime > 1.0f)
                _fovOffsetTime = 1.0f;
        }
    }

    public void FixedPosition()
    {
        if (_target == null)
            return;

        oldPosition = _target.position + offset + new Vector3(0.0f, 0.5f);
        _camera.transform.position = oldPosition - (_camera.transform.forward * (_targetRange + TargetRangeOffset.CurrentValue));
    }

    public void SetTempNormalCamera(float pitch, float fov, float far)
    {
        _start_pitch = _pitch;
        _pitch = pitch;
        _start_fov = _fov;
        _start_targetRange = _targetRange;
        _start_defocusStart = _defocusStart;
        _end_pitch = pitch;
        _end_fov = fov;
        _end_targetRange = far;
        _fov = fov;
        _targetRange = far;
        _pitch_time = 1.0f;
        _pitch_work_wait = 0.0f;
        _end_defocusStart = _defocusStart;
        _end_defocusEnd = _defocusEnd;
        _start_defocusEnd = _defocusEnd;
    }

    public void SetTempNormalCamera(float pitch, float fov, float targetRange, float defocusStart, float defocusEnd, bool isForse = true, float wait = 0.0f)
    {
        _start_pitch = _pitch;
        _start_fov = _fov;
        _start_targetRange = _targetRange;
        _start_defocusStart = _defocusStart;
        _end_pitch = pitch;
        _end_fov = fov;
        _end_targetRange = targetRange;
        _end_defocusStart = defocusStart;
        _end_defocusEnd = defocusEnd;
        _pitch_work_wait = wait;
        _start_defocusEnd = _defocusEnd;
        _pitch_time = 0.0f;

        if (isForse)
        {
            _pitch = pitch;
            _fov = fov;
            _targetRange = targetRange;
            _defocusStart = defocusStart;
            _defocusEnd = defocusEnd;
            _pitch_time = 1.0f;
            _pitch_work_wait = 0.0f;
        }
    }

    public void SetTempNormalCamera(MapInfo.SheetCamera data, bool isForse, float wait)
    {
        _start_defocusEnd = _defocusEnd;
        _end_pitch = data.pitch;
        _start_pitch = _pitch;
        _start_fov = _fov;
        _end_fov = data.fov;
        _end_targetRange = data.targetRange;
        _end_defocusStart = data.defocusStart;
        _end_defocusEnd = data.defocusEnd;
        _start_targetRange = _targetRange;
        _start_defocusStart = _defocusStart;
        _pitch_work_wait = wait;
        _pitch_time = 0.0f;

        if (isForse)
        {
            _pitch = data.pitch;
            _fov = data.fov;
            _targetRange = data.targetRange;
            _defocusStart = data.defocusStart;
            _defocusEnd = data.defocusEnd;
            _pitch_time = 1.0f;
            _pitch_work_wait = 0.0f;
        }
    }

    public void UpdateMapInfoParam(float time)
    {
        if ((_pitch_work_wait <= 0.0f || (_pitch_work_wait -= time) <= 0.0f) && _pitch_time < 1.0f)
        {
            _pitch_time += time * 3.0f;
            _pitch = Mathf.Lerp(_start_pitch, _end_pitch, _pitch_time);
            _fov = Mathf.Lerp(_start_fov, _end_fov, _pitch_time);
            _targetRange = Mathf.Lerp(_start_targetRange, _end_targetRange, _pitch_time);
            _defocusStart = Mathf.Lerp(_start_defocusStart, _end_defocusStart, _pitch_time);
            _defocusEnd = Mathf.Lerp(_start_defocusEnd, _end_defocusEnd, _pitch_time);
        }
    }

    public bool IsMoveStop()
    {
        if (IsUpdateStop || isPanCamera)
            return true;

        Vector3 offsetVec = _target.position + offset + new Vector3(0.0f, 0.5f);
        float xOffset = offsetVec.x - oldPosition.x;
        float yOffset = offsetVec.y - oldPosition.y;
        float zOffset = offsetVec.z - oldPosition.z;

        return xOffset > -0.001f && xOffset < 0.001f &&
            yOffset > -0.001f && yOffset < 0.001f &&
            zOffset > -0.001f && zOffset < 0.001f;
    }

    public void CameraComponentEnable(bool flag)
    {
        _camera.enabled = flag;
    }

    public void InstantiateDarkWindow(GameObject darkWindow)
    {
        DarkWindow = Instantiate(darkWindow, transform);
        DarkWindow.transform.localPosition = new Vector3(0.0f, 0.0f, DataManager.FieldCommonParam[(int)ParamIndx.FlashDark_DarkCameraOfs].param);
        DarkWindow.transform.localEulerAngles = new Vector3(-90.0f, 0.0f, 0.0f);
    }

    public void DestroyDarkWindow()
    {
        if (DarkWindow != null)
        {
            Destroy(DarkWindow);
            DarkWindow = null;
        }
    }

    public GameObject GetDarkWindow()
    {
        return DarkWindow;
    }

    public void ScriptFarDepth(float depth, float frame)
    {
        if (depth >= 0.0f)
        {
            _scriptFardepth = depth;
            if (frame > 0.0f)
                _scriptFardepthTimeVectol = 30.0f / frame;
            else
                _scriptFardepthTime = 1.0f;
        }
        else
        {
            if (frame > 0.0f)
                _scriptFardepthTimeVectol = -30.0f / frame;
            else
                _scriptFardepthTime = 0.0f;
        }
    }

    public void ChangeDofTarget(ref Vector3 postion)
    {
        if (DepthOfField.instance == null)
            return;

        if (tempDofTransform == null)
        {
            tempDofTransform = new GameObject();
            tempDofTransform.name = "Temp DOF target";
            returnDofTransform = DepthOfField.instance.target;
        }

        tempDofTransform.transform.position = postion;
        DepthOfField.instance.target = tempDofTransform.transform;
        IsStopDofTarget = true;
    }

    public void ResetChangeDofTarget()
    {
        if (DepthOfField.instance == null)
            return;

        if (returnDofTransform == null)
            return;

        DepthOfField.instance.target = returnDofTransform;
        returnDofTransform = null;

        if (tempDofTransform != null)
        {
            Destroy(tempDofTransform);
            tempDofTransform = null;
            IsStopDofTarget= false;
        }
    }

    public void SetCameraDirect(Vector3 position, Vector3 rotate)
    {
        _camera.transform.localPosition = position;
        _camera.transform.localEulerAngles = rotate;
    }

    public Camera GetCamera()
    {
        return _camera;
    }

    public void SetFovOffset(float offset, float time)
    {
        _fovOffsetStart = _fovOffsetEnd;
        _fovOffsetEnd = offset;
        _fovOffsetTime = 0.0f;
        _fovOffsetTimeScale = time;

        if (time <= 0.0f)
        {
            _fovOffsetTime = 1.0f;
            _fovOffset = offset;
        }
    }

    public float GetFov()
    {
        return _fov;
    }
}