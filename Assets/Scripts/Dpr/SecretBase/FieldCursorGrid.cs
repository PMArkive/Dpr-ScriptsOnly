using UnityEngine;

namespace Dpr.SecretBase
{
	public class FieldCursorGrid : MonoBehaviour
	{
		[SerializeField]
		private Transform top;
		[SerializeField]
		private Transform bottom;
		[SerializeField]
		private Transform left;
		[SerializeField]
		private Transform right;

		public int Width { get; set; } = 1;
		public int Height { get; set; } = 1;
		
		// TODO
		public void SetSize(int width, int height) { }
		
		// TODO
		public void OnUpdate() { }
	}
}