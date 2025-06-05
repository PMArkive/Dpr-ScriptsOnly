using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Dpr.SecretBase
{
	public class UICursor : UIBehaviour
	{
		[SerializeField]
		private RectTransform rect;
		[SerializeField]
		private Image image;
		[SerializeField]
		protected float forcusMin = 0.5f;
		[SerializeField]
		protected float forcusMax = 1.0f;
		[SerializeField]
		private bool isAttach = true;
		[SerializeField]
		private Vector3 offset = new Vector3(0.0f, 0.0f, 0.0f);
		
		// TODO
		protected override void Start() { }
		
		// TODO
		private void Update() { }
		
		// TODO
		public void Attach() { }
	}
}