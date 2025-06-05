using UnityEngine;

namespace Effect
{
	public class SimulationSpacePositionOnly : MonoBehaviour
	{
		private void LateUpdate()
		{
			transform.rotation = Quaternion.identity;
		}
	}
}