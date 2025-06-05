using System.Collections.Generic;
using UnityEngine;

namespace Dpr.UI
{
	public class BoxMultiNavigator : UINavigator
	{
		[SerializeField]
		private List<UINavigator> _lefts;
		[SerializeField]
		private List<UINavigator> _rights;
		[SerializeField]
		private List<UINavigator> _tops;
		[SerializeField]
		private List<UINavigator> _bottoms;

		private List<List<UINavigator>> _multiNavigates = new List<List<UINavigator>>();
		private bool isMultiInitialized;
		
		// TODO
		protected override void Awake() { }
		
		// TODO
		public void SetNavigate(NavigateType type, int index) { }
		
		// TODO
		public List<UINavigator> GetNavigates(NavigateType type) { return default; }
		
		// TODO
		public void SetNavigates(NavigateType type, List<UINavigator> naviList) { }
	}
}