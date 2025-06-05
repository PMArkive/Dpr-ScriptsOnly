using Dpr.Message;
using GameData;
using System;
using UnityEngine;
using UnityEngine.UI;
using XLSXContent;

namespace Dpr.UI
{
    public class ShopBoutiqueItemItem : ShopItemItem
    {
        [SerializeField]
        private Image _waredIcon;
        [SerializeField]
        private Purchased _purchased;
        [SerializeField]
        private Color[] _colors;
        private Param _param;
        private CharacterDressData.SheetData _characterDressData;
        private ShopBoutique.BoutiqueType _boutiqueType;

        public Param param { get => _param; }
        public CharacterDressData.SheetData characterDressData { get => _characterDressData; }

        public void Setup(ShopBoutique.BoutiqueType boutiqueType, Param param)
        {
            _shopType = ShopBase.ShopType.Boutique;
            _boutiqueType = boutiqueType;
            _param = param;

            if (boutiqueType == ShopBoutique.BoutiqueType.Buy)
            {
                _characterDressData = DataManager.GetCharacterDressData(param.data.DressNo);
                _price.gameObject.SetActive(true);
                _price.SetFormattedText(() => MessageWordSetHelper.SetDigitWord(0, param.data.Price), null, null);
            }
            else
            {
                _characterDressData = param.dressData;
                _price.gameObject.SetActive(false);
            }

            _name.SetupMessage(null, _characterDressData.MSLabel);

            SetupWared();
            SetupPurchased();
            SetupNameColor();
        }

        private void SetupNameColor()
        {
            if (IsShowPurchased())
                _name.color = _colors[1];
            else if (IsWaredDress())
                _name.color = _colors[2];
            else
                _name.color = _colors[0];
        }

        private bool IsWaredDress()
        {
            return _boutiqueType == ShopBoutique.BoutiqueType.Change && PlayerWork.playerFashion == _characterDressData.Index;
        }

        public void SetupWared()
        {
            _waredIcon.gameObject.SetActive(IsWaredDress());
            SetupNameColor();
        }

        private bool IsShowPurchased()
        {
            return _boutiqueType == ShopBoutique.BoutiqueType.Buy && FlagWork.GetFlag(_param.data.DressGet);
        }

        private void SetupPurchased()
        {
            _purchased.root.gameObject.SetActive(IsShowPurchased());
            SetupNameColor();
        }

        public override int GetNumForAdd()
        {
            return FlagWork.GetFlag(_param.data.DressGet) ? 0 : 1;
        }

        public void AddItem(int amount)
        {
            FlagWork.SetFlag(_param.data.DressGet, true);
            SetupPurchased();
        }

        [Serializable]
        private class Purchased
        {
            public RectTransform root;
        }

        public class Param
        {
            public ShopTable.SheetBoutiqueShop data;
            public CharacterDressData.SheetData dressData;
        }
    }
}