using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.Battle.View.UI
{
	public class BUISituationParam : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _titleText;
		[SerializeField]
		private Image[] _arrowImages;
		[SerializeField]
		private Sprite _upArrow;
		[SerializeField]
		private Sprite _downArrow;
		
		// TODO
		public void Initialize(string paramName, int value) { }
	}
}