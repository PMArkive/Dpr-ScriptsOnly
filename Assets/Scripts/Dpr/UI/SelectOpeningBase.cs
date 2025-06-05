using Pml;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
    public class SelectOpeningBase : UIWindow
    {
        [SerializeField]
        protected Image _imageBg;
        [SerializeField]
        protected Image _imageBgBody;
        [SerializeField]
        protected Sprite[] _spriteBgs;

        protected void SetupBgs()
        {
            bool isPearl = PmlUse.Instance.CassetVersion != 0;
            _imageBg.sprite = _spriteBgs[isPearl ? 1 : 0];

            if (_imageBgBody == null)
                return;

            _imageBgBody.sprite = _spriteBgs[isPearl ? 3 : 2];
        }
    }
}