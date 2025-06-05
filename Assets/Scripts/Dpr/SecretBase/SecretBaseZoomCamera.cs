using UnityEngine;

namespace Dpr.SecretBase
{
	public class SecretBaseZoomCamera : MonoBehaviour
	{
		[SerializeField]
		private Camera zoomCamera;
		[SerializeField]
		private float initFOV = 10.0f;
		[SerializeField]
		private float offsetPosY = 2.0f;
		[SerializeField]
		private float offsetRotationX = 2.0f;
		[SerializeField]
		private float offsetRotationY = 250.0f;
		[SerializeField]
		private float moveSpeed = 0.5f;
		[SerializeField]
		private float rotateSpeed = 2.0f;
		[SerializeField]
		private float rotateLimitX = 30.0f;
		[SerializeField]
		private float rotateLimitYTop = 30.0f;
		[SerializeField]
		private float rotateLimitYBottom = 5.0f;
		[SerializeField]
		private float moveLimit = 3.0f;
		[SerializeField]
		private Vector3 offsetY = new Vector3(0.0f, 1.37f, 0.0f);
		[SerializeField]
		[Range(6.0f, 25.0f)]
		private float farDepth = 10.0f;
		private float normalDepthFar;
		private float totalRotateX;
		private float totalRotateY;
		private float totalMove;
		private Vector3 initDistance;
		private int facial;
		
		// TODO
		public void Initialize(FieldConnector fieldConnector) { }
		
		// TODO
		public void OnUpdate() { }
		
		// TODO
		private void ZoomCameraRotateUpdate() { }
		
		// TODO
		private void UpdateFacial() { }
	}
}