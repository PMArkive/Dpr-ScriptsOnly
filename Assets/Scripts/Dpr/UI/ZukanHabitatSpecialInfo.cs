using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
    public class ZukanHabitatSpecialInfo : MonoBehaviour
    {
        [SerializeField]
        private Image[] _icons;

        public void Setup(int habitatBits)
        {
            _icons[0].gameObject.SetActive(((Townmap.Cell.HabitatBits)habitatBits).HasFlag(Townmap.Cell.HabitatBits.Normal));
            _icons[1].gameObject.SetActive(((Townmap.Cell.HabitatBits)habitatBits).HasFlag(Townmap.Cell.HabitatBits.Fishing));
            _icons[2].gameObject.SetActive(((Townmap.Cell.HabitatBits)habitatBits).HasFlag(Townmap.Cell.HabitatBits.PokemonTraser));
            _icons[3].gameObject.SetActive(((Townmap.Cell.HabitatBits)habitatBits).HasFlag(Townmap.Cell.HabitatBits.HoneyTree));
        }
    }
}