using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
    public class SelectOpeningItem : MonoBehaviour
    {
        [SerializeField]
        protected Image _imageBody;
        [SerializeField]
        protected Sprite[] _sprites;
        [SerializeField]
        protected Image _imageText;
        [SerializeField]
        protected Color[] _colors;

        public virtual void Select(bool enabled)
        {
            _imageBody.sprite = _sprites[enabled ? 1 : 0];

            if (_imageText == null)
                return;

            _imageText.color = _colors[enabled ? 1 : 0];
        }
    }
}