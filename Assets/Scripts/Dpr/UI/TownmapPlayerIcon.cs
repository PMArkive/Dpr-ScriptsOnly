using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
    public class TownmapPlayerIcon : TownmapIcon
    {
        [SerializeField]
        private Image _image;

        protected override void Awake()
        {
            _image.sprite = GetSpritePlayerIcon();
        }

        private Sprite GetSpritePlayerIcon()
        {
            return UIManager.Instance.GetAtlasSprite(SpriteAtlasID.TEXTUREMASS, string.Format("map_ico_player_01_{0:D3}_{1:D2}", PlayerWork.playerFashion, PlayerWork.colorID));
        }
    }
}