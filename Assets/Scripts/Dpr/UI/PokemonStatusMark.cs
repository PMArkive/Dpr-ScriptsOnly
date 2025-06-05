using Pml.PokePara;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class PokemonStatusMark : MonoBehaviour
	{
		[SerializeField]
		private Image _image;
		private BoxMarkColor _type;
		
		public BoxMarkColor type { get => _type; }
		
		public void Setup(BoxMarkColor type)
		{
			SetType(type);
		}
		
		public void SetType(BoxMarkColor type)
		{
			_type = type;
			_image.color = UIManager.Instance.GetMarkColor((int)type);
		}
	}
}