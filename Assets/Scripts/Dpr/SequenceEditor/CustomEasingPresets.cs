using UnityEngine;

namespace Dpr.SequenceEditor
{
	[CreateAssetMenu(fileName = "CustomEasingPresets", menuName = "ScriptableObjects/SequenceEditor/Create CustomEasingPresets")]
	public class CustomEasingPresets : ScriptableObject
	{
		[SerializeField]
		private AnimationCurve[] _presets = new AnimationCurve[1];
		
		public bool TryGetValue(int index, float ft, out float value)
		{
			value = 0.0f;

			if (!_presets.IsBounds(index))
				return false;

			value = _presets[index].Evaluate(ft);
			return true;
		}
	}
}