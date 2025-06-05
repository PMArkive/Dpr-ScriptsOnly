using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace Dpr.DigFossil
{
	public class DigCameraShaker : MonoBehaviour, IDigCameraShaker
	{
		[SerializeField]
		private Transform targetCamera;
		private Vector3 defaultPosition;
		private Tweener tweenHandler;

		public bool IsEnable { get; set; } = true;
		
		// TODO
		public void DoShake(float strength, float period) { }
		
		// TODO
		private IEnumerator OnEnd(float period) { return default; }
		
		// TODO
		private void Start() { }
	}
}