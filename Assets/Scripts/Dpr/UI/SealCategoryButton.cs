using UnityEngine;

namespace Dpr.UI
{
	public class SealCategoryButton : MonoBehaviour
	{
		[SerializeField]
		private SealIconButon sealIconButon;
		
		public int CategoryId { get; set; }
		public bool IsEnable { get; set; }
		public bool IsNoneCategory { get => CategoryId == 0; }
		
		// TODO
		public void Set(int categoryId) { }
		
		// TODO
		public void Set(SealCategoryButton button) { }
		
		// TODO
		public void SetNone() { }
		
		// TODO
		public void SetEnable(bool isEnable) { }
		
		// TODO
		public Vector3 GetPosition() { return default; }
	}
}