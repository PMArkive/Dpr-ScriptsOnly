using Pml;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

namespace Dpr.UnderGround
{
	public class UIStatueBuffIcon : MonoBehaviour
	{
		public Image Icon;
		public Image BuffArrow;
		
		public void SetData(int pokeType, int value, SpriteAtlas IconAtlas)
		{
			if (pokeType == (int)PokeType.NORMAL && value == 0)
			{
				Icon.color = Color.clear;
				BuffArrow.enabled = false;
			}
			else
            {
                Icon.color = Color.white;
                BuffArrow.enabled = true;
				Icon.sprite = IconAtlas.GetSprite("ugmap_eff_type_" + pokeType.ToString("00"));

				var arrowCount = 1;
				if (value > 300) arrowCount = 2;
				if (value > 700) arrowCount = 3;
                Icon.sprite = IconAtlas.GetSprite("ugmap_arw_up_" + arrowCount.ToString("00"));
            }
		}
	}
}