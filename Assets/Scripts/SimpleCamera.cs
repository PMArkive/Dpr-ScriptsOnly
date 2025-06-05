using UnityEngine;

public class SimpleCamera : MonoBehaviour
{
	private Camera _camera;
	private Transform _cameraTransform;
	private bool _drag;
	private Transform _dragTarget;
	private Vector3 _interestPoint;
	private float _distance;
	private bool _controllable;
	public BoundingSphere _boundingSphere;
	public Bounds _bounds;
	private Transform _cameraTarget;
	
	public Transform dragTarget { set => _dragTarget = value; }
	public Transform cameraTarget { get => _cameraTarget; set => _cameraTarget = value; }
	public BoundingSphere boundingSphere { get => _boundingSphere; set => _boundingSphere = value; }
	public Bounds bounds { get => _bounds; set => _bounds = value; }
	public bool controllable { set => _controllable = value; }
	
	// TODO
	private void OnEnable() { }
	
	// TODO
	private void OnDisable() { }
	
	// TODO
	private void OnUpdate(float deltaTime) { }
	
	// TODO
	private void Track(float x, float y) { }
	
	// TODO
	private void Tumble(float yaw, float pitch) { }
	
	// TODO
	private void Pan(float yaw, float pitch) { }
	
	// TODO
	public void SetTarget(GameObject instance, bool fit = true) { }
	
	// TODO
	private Vector3[] GetPositions(GameObject instance) { return default; }
	
	// TODO
	private Bounds ComputeBounds(Vector3[] positions) { return default; }
	
	// TODO
	private BoundingSphere ComputeBoundingSphereFast(Vector3[] positions) { return default; }
	
	// TODO
	public void FitSphere(BoundingSphere sphere) { }
	
	// TODO
	public void FitSphere() { }
	
	// TODO
	public void FitBox() { }
}