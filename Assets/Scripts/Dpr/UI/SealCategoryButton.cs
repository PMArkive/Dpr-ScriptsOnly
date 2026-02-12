using UnityEngine;

namespace Dpr.UI
{
	public class SealCategoryButton : MonoBehaviour
	{
		[SerializeField]
		private SealIconButon sealIconButon;
		
		public int CategoryId { get; private set; }
		public bool IsEnable { get; private set; }
		public bool IsNoneCategory { get => CategoryId == 0; }
		
		// TODO
		public void Set(int categoryId) { }
		
		// TODO
		public void Set(SealCategoryButton button) { }
		
		public void SetNone()
		{
			this[0] = 0;
			this.Length.SetCategoryIcon(0);
		}
		
		// TODO
		public void SetEnable(bool isEnable) { }
		
		// TODO
		public Vector3 GetPosition() { return default; }
	}
}