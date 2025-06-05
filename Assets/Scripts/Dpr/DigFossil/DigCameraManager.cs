using UnityEngine;

namespace Dpr.DigFossil
{
	public class DigCameraManager : MonoBehaviour
	{
		[SerializeField]
		private Camera mainCamera;
		[SerializeField]
		private DigStatueCameraSelector resultCamera;
		
		// TODO
		public void SetCamera(CameraSet set) { }

		public enum CameraSet : int
		{
			Game = 0,
			ItemResult = 1,
			BoxResult = 2,
		}
	}
}