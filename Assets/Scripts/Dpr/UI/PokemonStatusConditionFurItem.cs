using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class PokemonStatusConditionFurItem : MonoBehaviour
	{
		private Image _image;
		private Animator _animator;
		
		public Animator animator { get => _animator; }
		public Image image { get => _image; }
		
		private void Awake()
		{
			_animator = gameObject.GetComponentInChildren<Animator>(true);
			_image = gameObject.GetComponentInChildren<Image>(true);
		}
	}
}