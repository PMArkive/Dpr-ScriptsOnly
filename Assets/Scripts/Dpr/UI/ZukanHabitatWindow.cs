using Audio;
using Pml.PokePara;
using SmartPoint.AssetAssistant;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using XLSXContent;

namespace Dpr.UI
{
    public class ZukanHabitatWindow : TownmapWindowBase
    {
        [SerializeField]
        private PokemonModelView _modelView;
        [SerializeField]
        private ZukanHabitatTownmap _townmap;
        [SerializeField]
        private Cursor _cursor;
        [SerializeField]
        private ZukanTimeZone _timeZone;
        [SerializeField]
        private ZukanHabitatSpecialInfo _specialInfo;
        [SerializeField]
        private ZukanHabitatTypeSelector _typeSelector;

        public override void OnCreate()
        {
            // No extra code
            base.OnCreate();
        }

        public void Open(Param param, UIWindowID prevWindowId)
        {
            Sequencer.Start(OpOpen(param, prevWindowId));
        }

        public IEnumerator OpOpen(Param param, UIWindowID prevWindowId)
        {
            OnOpen(prevWindowId);

            _timeZone.Set(ZukanTimeZone.ToConnectId(GameManager.currentPeriodOfDay));
            _modelView.Setup(new PokemonModelView.Param()
            {
                type = UIModelViewController.ModelViewType.Habitat,
                pokemonParam = param.pokemonParam,
                canvas = _canvas,
            }, null);
            _townmap.Setup(param.pokemonParam, _timeZone.timeZone, OnCellChanged);
            _typeSelector.SetType(_townmap.habitatType);
            _cursor.SetActive(false);
            UpdateCursor();

            yield return OpPlayOpenWindowAnimation(prevWindowId, null);

            _cursor.gameObject.SetActive(!_townmap.isNotfound);
            Sequencer.update += OnUpdate;
            _input.inputEnabled = true;
        }

        private void OnCellChanged(Townmap.Cell cell, bool isReset)
        {
            var bits = cell != null ? (Townmap.Cell.HabitatBits)cell.GetHabitatBits(_townmap.habitatType, _timeZone.timeZone) : 0;

            if ((bits & Townmap.Cell.HabitatBits.All) == 0)
            {
                _specialInfo.gameObject.SetActive(false);
            }
            else
            {
                _specialInfo.gameObject.SetActive(true);
                _specialInfo.Setup((int)bits);

                var cellPos = _townmap.ToCellPos(_townmap.cursorPos);
                var iconPos = _townmap.ToCellIconPos(cellPos);
                iconPos.y = (cellPos.y != 0.0f) ? iconPos.y : (iconPos.y - Townmap.CellSize);
                _specialInfo.transform.position = iconPos;
            }

            SetupKeyguide(cell);
        }

        private void SetupKeyguide(Townmap.Cell cell)
        {
            var keyguide = UIManager.Instance.GetKeyguide(null);
            keyguide.transform.SetParent(transform, false);

            var param = new Keyguide.Param();

            if (IsFly(cell))
                param.itemParams.Add(new KeyguideItem.Param() { keyguideId = KeyguideID.POKEDEX_DISTRIBUTION_FLY });

            param.itemParams.Add(new KeyguideItem.Param() { keyguideId = KeyguideID.POKEDEX_DISTRIBUTION_LIST });
            param.itemParams.Add(new KeyguideItem.Param() { keyguideId = KeyguideID.POKEDEX_DISTRIBUTION_BACK });

            keyguide.Open(param);
        }

        protected override bool IsFly(Townmap.Cell cell)
        {
            return base.IsFly(cell) && !_townmap.isNotfound;
        }

        public override void Close(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId)
        {
            Sequencer.Start(OpClose(onClosed_, nextWindowId));
        }

        public IEnumerator OpClose(UnityAction<UIWindow> onClosed_, UIWindowID nextWindowId)
        {
            _cursor.SetActive(false);
            _modelView.Clear(true);
            Sequencer.update -= OnUpdate;

            yield return OpPlayCloseWindowAnimationAndWaiting(nextWindowId);

            UIManager.Instance._ReleaseUIWindow(this);
            onClosed_?.Invoke(this);
        }

        private void OnUpdate(float deltaTime)
        {
            if (UIManager.Instance.GetCurrentUIWindow<UIWindow>() != this)
                return;

            if (_modelView.OnUpdate(deltaTime, _input))
                return;

            if (IsActiveMessageWindow())
                return;

            if (IsPushButton(UIManager.ButtonB))
            {
                AudioManager.Instance.PlaySe(AK.EVENTS.UI_MAP_CLOSE, null);
                Close(onClosed, _prevWindowId);
            }
            else if (IsPushButton(UIManager.ButtonX))
            {
                AudioManager.Instance.PlaySe(AK.EVENTS.UI_COMMON_CANCEL, null);
                ZukanWork.IsShowDescription = false;
                Close(onClosed, _prevWindowId);
            }
            else if (IsPushButton(UIManager.ButtonA) && !_townmap.isNotfound)
            {
                Fly(_townmap);
            }
            else if (IsPushButton(GameController.ButtonMask.L))
            {
                AudioManager.Instance.PlaySe(AK.EVENTS.UI_COMMON_DONE, null);
                _timeZone.Move(-1);
                _townmap.ShowHabitat(_townmap.habitatType, _timeZone.timeZone);
                EnableCursor();
            }
            else if (IsPushButton(GameController.ButtonMask.R))
            {
                AudioManager.Instance.PlaySe(AK.EVENTS.UI_COMMON_DONE, null);
                _timeZone.Move(1);
                _townmap.ShowHabitat(_townmap.habitatType, _timeZone.timeZone);
                EnableCursor();
            }
            else if (IsPushButton(UIManager.ButtonPlusMinus))
            {
                AudioManager.Instance.PlaySe(AK.EVENTS.UI_COMMON_DECIDE, null);
                var newType = _townmap.habitatType == SheetDistributionTable.HabitatType.Field ? SheetDistributionTable.HabitatType.Dungeon : SheetDistributionTable.HabitatType.Field;
                _townmap.ShowHabitat(newType, _timeZone.timeZone);
                _typeSelector.SetType(_townmap.habitatType);
                EnableCursor();
            }
            else
            {
                _townmap.OnUpdate(deltaTime, _input);
                UpdateCursor();
            }
        }

        private void EnableCursor()
        {
            _cursor.gameObject.SetActive(!_townmap.isNotfound);
        }

        private void UpdateCursor()
        {
            _cursor.transform.position = _townmap.cursorPos;
        }

        public class Param
        {
            public PokemonParam pokemonParam;
        }
    }
}