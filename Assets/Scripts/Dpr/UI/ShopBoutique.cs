using Audio;
using Dpr.Message;
using SmartPoint.AssetAssistant;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;

namespace Dpr.UI
{
    public class ShopBoutique : ShopBase
    {
        [SerializeField]
        protected UIText _charge;
        [SerializeField]
        protected CharacterModelView _modelView;
        [SerializeField]
        protected ModelParam[] _modelParams;
        protected List<ShopBoutiqueItemItem.Param> _itemParams = new List<ShopBoutiqueItemItem.Param>();
        protected ShopBoutiqueItemItem _selectShopItem;
        protected CharacterModelView.Param.ModelType _modelType = CharacterModelView.Param.ModelType.Battle;
        protected BoutiqueType _boutiqueType;
        protected int _selectIndex;
        protected bool _isPlayerInputActive;
        protected const float _delayTime = 0.5f;
        protected float _loadModelDelayTime = -1.0f;

        public override void OnCreate()
        {
            base.OnCreate();
            _animator = GetComponentInChildren<Animator>(true);
            _itemListScrollView.Initialize(OnRequiredItemData, OnSelectItemScrollViewItem, OnUnSelectItemScrollViewItem);
        }

        public void Open()
        {
            Sequencer.Start(OpOpen());
        }

        public virtual IEnumerator OpOpen()
        {
            _loadModelDelayTime = -1.0f;
            _selectIndex = 0;
            _modelType = CharacterModelView.Param.ModelType.Battle;

            OnOpen(_prevWindowId);
            AudioManager.Instance.SetBgmEvent(AK.EVENTS.DUCKON_BGM);

            _cursor.transform.SetParent(transform, false);
            _cursor.SetActive(false);
            _selectShopItem = null;

            SetupScrollViewItemParams();
            _itemListScrollView.Setup(_itemParams.Count, _selectIndex);
            SetupCharge();

            _wazaItemDescriptionType = 0;
            _cursor.SetActive(true);

            yield return OpPlayOpenWindowAnimation(_prevWindowId, null);

            _loadModelDelayTime = -1.0f;
            SetupModelView(null);
            Sequencer.update += OnUpdate;
            _input.inputEnabled = true;
        }

        protected virtual void SetupScrollViewItemParams()
        {
            // Empty
        }

        protected static bool IsMaleDress(int DressNo)
        {
            return DressNo < 100;
        }

        protected void SetupCharge()
        {
            var charge = GetCharge();
            _charge.SetFormattedText(() => MessageWordSetHelper.SetDigitWord(0, charge), null, "SS_fld_shop_206");
        }

        protected void OnRequiredItemData(IUIButton button)
        {
            (button as ShopBoutiqueItemItem).Setup(_boutiqueType, _itemParams[button.GetIndex()]);
        }

        protected void OnSelectItemScrollViewItem(IUIButton button)
        {
            if (!button.GetActive())
                return;

            button.Select();

            _selectShopItem = button as ShopBoutiqueItemItem;
            _cursor.transform.SetParent(_selectShopItem.transform, false);
            _loadModelDelayTime = _delayTime;

            SetupKeyguide();
        }

        protected void SetupModelView([Optional] UnityAction onComplate)
        {
            var param = new CharacterModelView.Param
            {
                type = UIModelViewController.ModelViewType.Boutique,
                characterDressData = _selectShopItem.characterDressData,
                canvas = _canvas,
                modelType = _modelType,
                offsetZ = _modelParams[(int)_modelType].offsetZ,
            };

            _modelView.Setup(param, param_ =>
            {
                _modelView.PlayAnimation(CharacterModelView.clipName_stand_b);
                onComplate?.Invoke();
            });
        }

        protected void UpdateModelView(float delayTime)
        {
            if (_loadModelDelayTime >= 0.0f)
            {
                _loadModelDelayTime -= delayTime;
                if (_loadModelDelayTime < 0.0f)
                    SetupModelView(null);
            }
        }

        protected void SetupKeyguide()
        {
            var keyguide = UIManager.Instance.GetKeyguide(null);
            keyguide.transform.SetParent(transform, false);

            var param = new Keyguide.Param();
            param.itemParams.Add(new KeyguideItem.Param() { keyguideId = KeyguideID.SHOP_DRESS_CHANGECHARACTER });
            param.itemParams.Add(new KeyguideItem.Param() { keyguideId = KeyguideID.SHOP_DRESS_SELECT });
            param.itemParams.Add(new KeyguideItem.Param() { keyguideId = KeyguideID.SHOP_DRESS_ROTATION_R });
            param.itemParams.Add(new KeyguideItem.Param() { keyguideId = KeyguideID.SHOP_DRESS_CHANGECHARACTER });
            param.itemParams.Add(new KeyguideItem.Param() { keyguideId = KeyguideID.SHOP_FRIENDLY_CANCEL });

            keyguide.Open(param);
        }

        protected void OnUnSelectItemScrollViewItem(IUIButton button)
        {
            button.UnSelect();
        }

        public void Close(UnityAction<UIWindow> onClosed_)
        {
            Sequencer.Start(OpClose(onClosed_));
        }

        public IEnumerator OpClose(UnityAction<UIWindow> onClosed_)
        {
            _modelView.Clear(true);
            PlayerWork.isPlayerInputActive = _isPlayerInputActive;
            Sequencer.update -= OnUpdate;

            yield return OpPlayCloseWindowAnimationAndWaiting(_prevWindowId);

            AudioManager.Instance.SetBgmEvent(AK.EVENTS.DUCKOFF_BGM);
            UIManager.Instance._ReleaseUIWindow(this);
            onClosed_?.Invoke(this);
            UIManager.Instance.ClearCachedSprites();
        }

        protected void OnUpdate(float deltaTime)
        {
            UpdateModelView(deltaTime);

            var window = UIManager.Instance.GetCurrentUIWindow<UIWindow>();
            if (window != this)
                return;

            if (_modelView.OnUpdate(deltaTime, _input))
                return;

            if (IsActiveMessageWindow())
                return;

            if (IsPushButton(UIManager.ButtonPlusMinus))
            {
                _input.inputEnabled = false;

                if (_modelType == CharacterModelView.Param.ModelType.Field)
                    _modelType = CharacterModelView.Param.ModelType.Battle;
                else if (_modelType == CharacterModelView.Param.ModelType.Battle)
                    _modelType = CharacterModelView.Param.ModelType.Field;

                SetupModelView(() => _input.inputEnabled = true);
            }

            if (IsPushButton(UIManager.ButtonB))
                OnCancel();
            else if (IsPushButton(UIManager.ButtonA))
                OnDecidedSelectItem();
            else
                UpdateSelect(deltaTime, 10, false);
        }

        protected virtual void OnCancel()
        {
            // Empty
        }

        protected virtual void OnDecidedSelectItem()
        {
            // Empty
        }

        protected int GetCharge()
        {
            return MoneyWork.Get();
        }

        protected void SubCharge(int subCharge)
        {
            MoneyWork.Sub(subCharge);
        }

        protected override void OnAddContextMenuYesNoItemParams(List<ContextMenuItem.Param> contextMenuItemParams)
        {
            contextMenuItemParams.Add(new ContextMenuItem.Param() { menuId = ContextMenuID.FRIENDLYSHOP_YES });
            contextMenuItemParams.Add(new ContextMenuItem.Param() { menuId = ContextMenuID.FRIENDLYSHOP_NO });
        }

        protected void ChangeDress()
        {
            UIManager.onDressChanged?.Invoke(_selectShopItem.characterDressData.Index);

            PlayerWork.playerFashion = _selectShopItem.characterDressData.Index;
            PlayerWork.playReportDataRef.dress_up++;

            TvWork.FashionChange(PlayerWork.playerFashion, (int)PlayerWork.zoneID);

            foreach (var item in _itemListScrollView.ScrollItems)
            {
                var boutiqueItem = item as ShopBoutiqueItemItem;
                if (boutiqueItem.GetActive())
                    boutiqueItem.SetupWared();
            }

            _modelView.PlayAnimation(CharacterModelView.clipName_pose_b);
        }

        [Serializable]
        protected class ModelParam
        {
	        public float offsetZ;
        }

        public enum BoutiqueType : int
        {
            Buy = 0,
            Change = 1,
        }
    }
}