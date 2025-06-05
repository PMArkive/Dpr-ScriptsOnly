using Pml.PokePara;
using Pml;
using UnityEngine;
using UnityEngine.UI;
using Dpr.BallDeco;

namespace Dpr.UI
{
    public class PokemonIcon : MonoBehaviour
    {
        [SerializeField]
        private Image _imageMonsIcon;
        [SerializeField]
        private Image _imageItemIcon;
        [SerializeField]
        private Image _imageBallDecoIcon;

        public Image monsIcon { get => _imageMonsIcon; }
        public Image itemIcon { get => _imageItemIcon; }
        public Image ballDecoIcon { get => _imageBallDecoIcon; }

        public void Load(PokemonParam pokemonParam, int tray = -1, int pos = -1)
        {
            if (_imageMonsIcon != null)
            {
                UIManager.Instance.LoadSpritePokemon(pokemonParam.GetMonsNo(), pokemonParam.GetFormNo(),
                    pokemonParam.GetSex(), pokemonParam.GetRareType(), pokemonParam.IsEgg(EggCheckType.BOTH_EGG), sprite =>
                    {
                        _imageMonsIcon.sprite = sprite;
                        _imageMonsIcon.gameObject.SetActive(sprite != null);
                    });
            }

            if (_imageItemIcon != null)
            {
                if (pokemonParam.GetItem() == (ushort)ItemNo.DUMMY_DATA)
                {
                    _imageItemIcon.gameObject.SetActive(false);
                }
                else
                {
                    UIManager.Instance.LoadSpriteItem((ItemNo)pokemonParam.GetItem(), sprite =>
                    {
                        _imageItemIcon.sprite = sprite;
                        _imageItemIcon.gameObject.SetActive(sprite != null);
                    });
                }
            }

            if (_imageBallDecoIcon != null)
            {
                if (pos == -1 && tray == -1)
                    BallDecoWork.GetPokeIndex(pokemonParam, out tray, out pos);

                int capsuleId = BallDecoWork.GetAttachCapsuleId(pokemonParam.GetID(), pokemonParam.GetPersonalRnd(), tray, pos);
                _imageBallDecoIcon.gameObject.SetActive(capsuleId > -1 && !pokemonParam.IsEgg(EggCheckType.BOTH_EGG));
            }
        }

        public void Load(PokemonParam pokemonParam, ItemNo itemNo, int tray = -1, int pos = -1)
        {
            if (_imageMonsIcon != null)
            {
                UIManager.Instance.LoadSpritePokemon(pokemonParam.GetMonsNo(), pokemonParam.GetFormNo(),
                    pokemonParam.GetSex(), pokemonParam.GetRareType(), pokemonParam.IsEgg(EggCheckType.BOTH_EGG), sprite =>
                    {
                        _imageMonsIcon.sprite = sprite;
                        _imageMonsIcon.gameObject.SetActive(sprite != null);
                    });
            }

            if (itemNo != ItemNo.DUMMY_DATA && _imageItemIcon != null)
            {
                UIManager.Instance.LoadSpriteItem((ItemNo)pokemonParam.GetItem(), sprite =>
                {
                    _imageItemIcon.sprite = sprite;
                    _imageItemIcon.gameObject.SetActive(sprite != null);
                });
            }

            if (_imageBallDecoIcon != null)
            {
                if (pos == -1 && tray == -1)
                    BallDecoWork.GetPokeIndex(pokemonParam, out tray, out pos);

                int capsuleId = BallDecoWork.GetAttachCapsuleId(pokemonParam.GetID(), pokemonParam.GetPersonalRnd(), tray, pos);
                _imageBallDecoIcon.gameObject.SetActive(capsuleId > -1);
            }
        }

        public void Copy(PokemonIcon src)
        {
            if (_imageMonsIcon != null)
                _imageMonsIcon.sprite = src._imageMonsIcon.sprite;

            if (_imageItemIcon != null)
                _imageItemIcon.sprite = src._imageItemIcon.sprite;
        }

        public void SwapItemIcon(PokemonIcon from)
        {
            Sprite toSprite = _imageItemIcon.sprite;
            _imageItemIcon.sprite = from._imageItemIcon.sprite;
            from._imageItemIcon.sprite = toSprite;
        }
    }
}