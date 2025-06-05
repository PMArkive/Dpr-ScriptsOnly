using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class ZukanMovingPan : MonoBehaviour
	{
		[SerializeField]
		private Slider _slider;

		private float[] _values = new float[] { 0.5f, 0.5f };
		
		// TODO
		public void Setup() { }
		
		// TODO
		public void OnUpdate(float deltaTime) { }
		
		// TODO
		public float GetSensorValue() { return default; }
	}
}