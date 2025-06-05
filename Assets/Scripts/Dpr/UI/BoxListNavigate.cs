using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class BoxListNavigate : MonoBehaviour
	{
		[SerializeField]
		private int _arrayWidth;
		[SerializeField]
		private int _arrayHeight;
		[SerializeField]
		private GridLayoutGroup _layout;
		[SerializeField]
		private UINavigator _leftTop;
		[SerializeField]
		private UINavigator _rightTop;
		[SerializeField]
		private UINavigator _leftBottom;
		[SerializeField]
		private UINavigator _rightBottom;
		
		public List<UINavigator> NavigatorList { get; set; }
		public GridLayoutGroup LayoutGroup { get => _layout; }
		public int Width { get => _arrayWidth; }
		public int Height { get => _arrayHeight; }
		
		// TODO
		public void Initialize(int trayNum, BoxMultiNavigator functionLeft, BoxMultiNavigator functionRight) { }
		
		// TODO
		private IEnumerator SetFunctionNavigates(UINavigator.NavigateType setType, BoxMultiNavigator functionLeft, BoxMultiNavigator functionRight) { return default; }
	}
}