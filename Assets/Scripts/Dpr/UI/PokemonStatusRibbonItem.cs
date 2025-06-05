using Pml.PokePara;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class PokemonStatusRibbonItem : MonoBehaviour, IUIButton
	{
		[SerializeField]
		private Image _image;
		private int _index;
		private Param _param;
		
		public Param param { get => _param; }
		public int index { get => _index; }
		
		// TODO
		public void Setup(Param param, PokemonParam pokemonParam) { }
		
		// TODO
		bool IUIButton.GetActive() { return default; }
		
		// TODO
		void IUIButton.SetActive(bool isActive) { }
		
		// TODO
		int IUIButton.GetIndex() { return default; }
		
		// TODO
		void IUIButton.SetIndex(int index) { }
		
		// TODO
		RectTransform IUIButton.GetRectTransform() { return default; }
		
		// TODO
		void IUIButton.Select() { }
		
		// TODO
		void IUIButton.UnSelect() { }

		public class Param
		{
			public int ribbonNo;
		}
	}
}