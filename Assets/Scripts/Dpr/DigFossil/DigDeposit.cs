using UnityEngine;
using UnityEngine.UI;

namespace Dpr.DigFossil
{
	public class DigDeposit : MonoBehaviour, IDigDeposit
	{
		[SerializeField]
		private Image image;
		[SerializeField]
		private Transform effectPos;
		[SerializeField]
		private DigMasterDataManager.IDeposit depositData;
		[SerializeField]
		private Animator animator;
		private DigEffectManager effectManager;
		
		// TODO
		public void Initialize(DigMasterDataManager.IDeposit depositData, Vector3 pos, Vector2 size, int turn, Sprite sprite, Material material, DigEffectManager effectManager) { }
		
		// TODO
		public void RequestDigOutDirection() { }
		
		public DigDeposit()
		{
			// Empty, explicitly declared
		}
		
		GameObject IDigDeposit.gameObject { get => gameObject; }
	}
}