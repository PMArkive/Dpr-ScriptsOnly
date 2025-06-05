using UnityEngine;

namespace Dpr.UI
{
	public class BoxSearchDescription : MonoBehaviour
	{
		[SerializeField]
		private UIText _mainDescription;
		[SerializeField]
		private UIText[] _subDescriptions;
		[SerializeField]
		private GameObject _mainObject;
		[SerializeField]
		private GameObject _subObject;

        public BoxWindow.SEARCH_DATA SearchData { get; set; }

        private float _openPosX;
		private float _closePosX;
		private int? _searchType;
		private int _subIndex = -1;
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public void Open(BoxWindow.SEARCH_DATA searchData, int index = 0) { }
		
		// TODO
		public void Close() { }
		
		// TODO
		public void Apply(BoxWindow.SEARCH_DATA searchData, int index = -1, int subIndex = -1) { }
	}
}