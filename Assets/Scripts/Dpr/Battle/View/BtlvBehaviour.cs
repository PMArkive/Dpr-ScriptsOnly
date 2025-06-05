using UnityEngine;

namespace Dpr.Battle.View
{
	public abstract class BtlvBehaviour : MonoBehaviour
	{
		private Transform _cachedTransform;
		
		public Transform transform { get => this.GetComponentThis(ref _cachedTransform); }
	}
}