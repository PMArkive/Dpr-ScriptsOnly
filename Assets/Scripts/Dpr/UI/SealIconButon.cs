using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class SealIconButon : MonoBehaviour
	{
		private static readonly int GrayscaleAmountPropertyId = Shader.PropertyToID("_GrayscaleAmount");

		private const string CategoryIconAssetNameFormat = "cup_ico_sealcategory_{0:00}";
		public const int NoneCategoryId = 0;

		[SerializeField]
		private Shader iconShader;
		[SerializeField]
		protected Image iconImage;
		[SerializeField]
		private Image bodyImage;
		[SerializeField]
		private Sprite normalBodySprite;
		[SerializeField]
		private Sprite disableBodySprite;
		
		// TODO
		private void Awake() { }
		
		// TODO
		public void SetSealIcon(SealInfo sealInfo) { }
		
		// TODO
		public void SetCategoryIcon(int categoryId) { }
		
		// TODO
		public void SetEnable(bool isEnable) { }
		
		// TODO
		private void SetGrayscale(bool isGrayscale) { }
	}
}