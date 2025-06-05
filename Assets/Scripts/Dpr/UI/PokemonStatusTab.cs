using Pml.PokePara;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class PokemonStatusTab : MonoBehaviour
	{
		[SerializeField]
		private string _messageLabelTitle;
		[SerializeField]
		private PokemonStatusPanel _panel;
		[SerializeField]
		private GameObject _active;
		[SerializeField]
		private GameObject _disable;
		[SerializeField]
		private Image _imageBg;
		[SerializeField]
		private Image _imageIcon;

		private int _index = -1;
		private Color _color;
		private Color[] _colors = new Color[]
		{
			new Color32(155, 157, 158, 255),
			new Color32(209, 209, 210, 255),
			new Color32(235, 235, 235, 255),
		};
		
		public Color bgColor { get => _imageBg.color; }
		public PokemonStatusPanel panel { get => _panel; }
		public string messageLabelTitle { get => _messageLabelTitle; }
		
		// TODO
		public void Awake() { }
		
		// TODO
		public void Setup(int index, bool isActive, PokemonParam pokemonParam, Canvas canvas) { }
		
		// TODO
		public void Select(bool enabled) { }
		
		// TODO
		public void SetEnable(bool enabled) { }
	}
}