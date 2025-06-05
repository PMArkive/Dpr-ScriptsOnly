using SmartPoint.AssetAssistant;
using System.Collections;
using UnityEngine;

namespace Dpr.SecretBase
{
	public class StatuePlacementEditBoot : MonoBehaviour
	{
		[SerializeField]
		private StatuePlacementEditController scene;
		
		// TODO
		[SceneBeforeActivateOperationMethod]
		public IEnumerator ActivateOperation(Transform cluster) { return default; }
		
		// TODO
		private void Start() { }
		
		// TODO
		private void OnDestroy() { }
		
		// TODO
		private void OnUpdate(float deltaTime) { }
	}
}