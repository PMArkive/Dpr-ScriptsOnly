using UnityEngine;

namespace SmartPoint.Components
{
	[RequireComponent(typeof(Camera))]
	public class CopyCamera : MonoBehaviour
	{
		[SerializeField]
		private Camera _sourceCamera;
		private Camera _camera;
		
		// TODO
		private void OnEnable() { }
		
		// TODO
		private void OnDisable() { }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
	}
}