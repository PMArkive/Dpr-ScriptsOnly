using UnityEngine;
using UnityEngine.UI;
using XLSXContent;

namespace Dpr.UI
{
    public class ZukanHabitatTypeSelector : MonoBehaviour
    {
        [SerializeField]
        private Image[] _icons;

        public void SetType(SheetDistributionTable.HabitatType habitatType)
        {
            switch (habitatType)
            {
                case SheetDistributionTable.HabitatType.Field:
                    _icons[0].gameObject.SetActive(true);
                    _icons[1].gameObject.SetActive(false);
                    break;

                case SheetDistributionTable.HabitatType.Dungeon:
                    _icons[0].gameObject.SetActive(false);
                    _icons[1].gameObject.SetActive(true);
                    break;
            }
        }
    }
}