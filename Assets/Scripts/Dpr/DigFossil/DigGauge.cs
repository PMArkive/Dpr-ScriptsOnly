using UnityEngine;
using UnityEngine.UI;

namespace Dpr.DigFossil
{
	public class DigGauge : MonoBehaviour, IDigGauge
	{
		[SerializeField]
		private Animator animator;
		[SerializeField]
		private Text debugGaugeValue;
		private float gaugeMax = 1.0f;
		private int stateNameHash;
		
		// TODO
		public void Initialize(float gaugeMax) { }
		
		// TODO
		public void SetGauge(float gaugeValue) { }
	}
}