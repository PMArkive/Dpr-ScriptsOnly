using System.Collections.Generic;
using UnityEngine;
using XLSXContent;

namespace Dpr.DigFossil
{
	public class DigStatueCameraSelector : MonoBehaviour, IDigStatueCameraSelector
	{
		[SerializeField]
		private Camera camBox;
		[SerializeField]
		private List<Camera> statueCamera;
		private Camera currentCamera;
		
		// TODO
		public void SetCamera(StatueEffectRawData.Sheettable data) { }
		
		// TODO
		public void SwitchBoxCamera(bool isBox) { }
		
		// TODO
		private void ResetPostEffect(Camera camera) { }
		
		// TODO
		public void SetActive(bool isActive) { }
	}
}