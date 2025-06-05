using TMPro;
using UnityEngine;

namespace Dpr.SecretBase
{
	public class FilterDetailItem : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _enabledText;
		[SerializeField]
		private TextMeshProUGUI _disabledText;
		[SerializeField]
		private GameObject _body;

        public string ItemTextxt { get; set; }

        private int _index;
		private RectTransform _rectTransform;
		
		// TODO
		public void Initialize(string itemText) { }
		
		// TODO
		public void SetSelect(bool isEnable) { }
		
		// TODO
		public int GetIndex() { return default; }
		
		// TODO
		public void SetIndex(int index) { }
		
		// TODO
		public RectTransform GetRectTransform() { return default; }
		
		// TODO
		public bool GetActive() { return default; }
		
		// TODO
		public void SetActive(bool isActive) { }
		
		// TODO
		public void Select() { }
		
		// TODO
		public void UnSelect() { }
	}
}