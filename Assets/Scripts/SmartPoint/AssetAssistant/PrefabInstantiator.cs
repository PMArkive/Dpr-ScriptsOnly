using System.Collections;
using UnityEngine;

namespace SmartPoint.AssetAssistant
{
	public class PrefabInstantiator : MonoBehaviour
	{
		[SerializeField]
		public Object prefab;
		
		// TODO
		public void Restore() { }
		
		// TODO
		[SceneRestoreOperationMethod]
		private IEnumerator RestoreOperation(SceneEntity entity) { return default; }
	}
}