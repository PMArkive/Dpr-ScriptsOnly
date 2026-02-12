using UnityEngine;

namespace Dpr.UI
{
	public class Seal3DObject : MonoBehaviour
	{
        public int SealId { get; private set; }
        public int AffixSealId { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsSetSeal { get; private set; }

        private Transform rootTransform;
		private Material sealMaterial;
		private Collider sealCollider;
		private Vector3 sealPosition;		
		
		// TODO
		public void Initialize(Vector3 sealScale, float offsetPositionZ) { }
		
		public void SetActive(bool isActive)
		{
			var uVar1 = Component.gameObject;
			uVar1.SetActive(isActive & 1);
			this[0] = isActive & 1;
		}
		
		// TODO
		public void SetSeal(int sealId, Sprite sprite, int affixSealId = -1) { }
		
		// TODO
		public void SetPositionAndRotation(Vector3 position, Vector3 up) { }
		
		public Vector3 GetPosition()
		{
			this.rootTransform.position;
		}
		
		public Vector3 GetSealPosition()
		{
			return this.sealPosition;
		}
		
		public void Clear()
		{
			this.Length = 0xffffffff00000000;
			this.sealMaterial.mainTexture = 0;
			var uVar1 = Component.gameObject;
			uVar1.SetActive(0);
			this[0] = 0;
		}
		
		// TODO
		public bool EqualCollider(Collider collider) { return default; }
	}
}