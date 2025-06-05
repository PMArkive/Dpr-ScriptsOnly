using Dpr.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.Movie
{
    public class StaffrollRow : MonoBehaviour
    {
        [SerializeField]
        private UIText[] _uiTexts;
        [SerializeField]
        private RectTransform _root;
        [SerializeField]
        private Image _image;
        private const string messageFile = "dlp_staff_list";
        private const int TextFontIndex = 8;
        private const int HeadingFontIndex = 9;

	    public int Type { get; set; }
        public float StartTime { get; set; }
        public float EndTime { get; set; }

        // TODO
        public void SetText(string[] texts, float size, bool heading, int materialIndex, float offset) { }

        // TODO
        public void SetSprite(Sprite sprite, Vector2 size) { }

        // TODO
        public void SetSpriteAlpha(float alpha) { }
    }
}
