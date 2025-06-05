using UnityEngine;

namespace Dpr.UI
{
	public class Seal3DObject : MonoBehaviour
	{
        public int SealId { get; set; }
        public int AffixSealId { get; set; }
        public bool IsActive { get; set; }
        public bool IsSetSeal { get; set; }

        private Transform rootTransform;
		private Material sealMaterial;
		private Collider sealCollider;
		private Vector3 sealPosition;		
		
		// TODO
		public void Initialize(Vector3 sealScale, float offsetPositionZ) { }
		
		// TODO
		public void SetActive(bool isActive) { }
		
		// TODO
		public void SetSeal(int sealId, Sprite sprite, int affixSealId = -1) { }
		
		// TODO
		public void SetPositionAndRotation(Vector3 position, Vector3 up) { }
		
		// TODO
		public Vector3 GetPosition() { return default; }
		
		// TODO
		public Vector3 GetSealPosition() { return default; }
		
		// TODO
		public void Clear() { }
		
		// TODO
		public bool EqualCollider(Collider collider) { return default; }
	}
}