using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class CapsuleViewController : MonoBehaviour
	{
		[SerializeField]
		private GameObject capsule3DViewPrefab;
		[SerializeField]
		private GameObject capsule2DObject;
		[SerializeField]
		private GameObject capsule3DObject;
		[SerializeField]
		private RawImage capsule3DViewRawImage;
		[SerializeField]
		private RectTransform bgRectTransform;
		[SerializeField]
		private SealSubKeyGuide subKeyGuide;

		private static GameObject capsule3DViewObject;
		private Transform bgParent;
		private bool isBeforeFadeBlurActive;
		private bool isOpenedKeyguide;
		private bool isFading;
		
		public bool IsInitialized { get => View3DController != null && View3DController.IsIntialized; }
		public Capsule2DViewController View2DController { get; set; }
		public Capsule3DViewController View3DController { get; set; }
		
		// TODO
		public IEnumerator Initialize() { return default; }
		
		// TODO
		public void Dispose() { }
		
		// TODO
		public void Setup(CapsuleInfo capsuleInfo, bool isResetView) { }
		
		// TODO
		public void Set3DCapsuleActive(bool isAvtive) { }
		
		// TODO
		public void SetDisablePreviewGuide(bool isEnable) { }
		
		// TODO
		public IEnumerator ShowPreviewScene(CapsuleInfo capsuleInfo, CapsuleInfo subCapsuleInfo, IEnumerator playFadeWindow, Action onBeforeFadeIn, bool isCallStopScript = true) { return default; }
		
		// TODO
		public IEnumerator HidePreviewScene(IEnumerator playFadeWindow, Action onBeforeFadeIn, bool isCallOnOpenMenu = true) { return default; }
		
		// TODO
		public void UpdatePreviewKeyGuide(Keyguide keyguide) { }
		
		// TODO
		public bool CheckWaitFade() { return default; }
		
		// TODO
		private void SetupRawImage(Transform parent) { }
	}
}