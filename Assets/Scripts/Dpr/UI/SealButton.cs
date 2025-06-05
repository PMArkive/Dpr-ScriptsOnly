using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class SealButton : MonoBehaviour
	{
		[SerializeField]
		private SealIconButon sealIconButon;
		[SerializeField]
		private Image typeIconImage;
		[SerializeField]
		private UIText countText;
		
		public int SealId { get => Info.SealId; }
		public SealInfo Info { get; set; }
		public bool IsEnable { get => Info.GetCount() > 0; }
		
		// TODO
		public void Set(int sealId) { }
		
		// TODO
		public void UpdateCount() { }
	}
}