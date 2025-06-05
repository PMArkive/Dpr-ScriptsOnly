using UnityEngine;

namespace Dpr.SequenceEditor
{
	[CreateAssetMenu(fileName = "SplinePositionData", menuName = "ScriptableObjects/SequenceEditor/Create SplinePositionData")]
	public class SplinePositionData : ScriptableObject
	{
		[SerializeField]
		private Vector3[] _positions = new Vector3[1];
		
		public Vector3[] GetPositions()
		{
			return _positions;
		}
	}
}