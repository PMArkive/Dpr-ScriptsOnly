using UnityEngine;

namespace Dpr.DigFossil
{
	public class DigCameraManager : MonoBehaviour
	{
		[SerializeField]
		private Camera mainCamera;
		[SerializeField]
		private DigStatueCameraSelector resultCamera;
		
		public void SetCamera(CameraSet set)
		{
			if ((int)set == 2) {
			  GameObject.SetActive(Component.get_gameObject(this[0]),1,0);
			}
			else {
			  if (((int)set != 1) && ((int)set != 0)) {
			  }
			  GameObject.SetActive(this.Length.gameObject,1,0);
			}
			this[0] = Component.get_gameObject(this[0]);
			GameObject.SetActive(this[0],0);
		}

		public enum CameraSet : int
		{
			Game = 0,
			ItemResult = 1,
			BoxResult = 2,
		}
	}
}