using System.Collections;
using UnityEngine;

namespace SmartPoint.AssetAssistant
{
	public class AssetBundleInstantiator : MonoBehaviour
	{
		[SerializeField]
		public string assetBundleName;
		
		// TODO
		[SceneRestoreOperationMethod]
		private IEnumerator RestoreOperation(SceneEntity entity) { return default; }
		
		// TODO
		public virtual void OnFinished() { }
	}
}