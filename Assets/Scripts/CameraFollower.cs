using UnityEngine;

[ExecuteInEditMode]
public class CameraFollower : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;
    private Transform _cameraTransform;
    private Transform _targetTransform;

    private void OnEnable()
    {
        var cam = _camera;
        if (cam == null)
            cam = GetComponent<Camera>();

        if (cam != null)
            _cameraTransform = cam.transform;

        if (_targetTransform == null)
            _targetTransform = transform;
    }

    public bool SetCamera(Camera camera)
    {
        if (camera == null)
            return false;

        _cameraTransform = camera.transform;
        return true;
    }

    private void LateUpdate()
    {
        if (_targetTransform == null)
        {
            OnEnable();
        }
        else
        {
            _targetTransform.position = _cameraTransform.position;
            var cameraRot = _cameraTransform.rotation.eulerAngles;
            var targetRot = _targetTransform.eulerAngles;
            var resultRot = new Vector3(targetRot.x, cameraRot.y, cameraRot.z);
            _targetTransform.rotation = Quaternion.Euler(resultRot);
        }
    }
}