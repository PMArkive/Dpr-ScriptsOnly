using Dpr.Item;
using Pml;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.Battle.View.UI
{
    public class BUIPokeBallList : BattleViewUICanvasBase, IResultable<ItemNo>
    {
        [SerializeField]
        private BUIButton _prevButton;
        [SerializeField]
        private BUIButton _nextButton;
        [SerializeField]
        private Image _ballIcon;
        [SerializeField]
        private Image _originalIcon;
        [SerializeField]
        private TextMeshProUGUI _ballNameText;
        [SerializeField]
        private TextMeshProUGUI _ballCountText;
        [SerializeField]
        private TextMeshProUGUI _descriptionText;
        [SerializeField]
        private BUIButton _useButton;
        private List<ItemInfo> _balls;
        private Dictionary<ItemNo, Sprite> _ballSprites = new Dictionary<ItemNo, Sprite>();
        private Action _callBack;
        private int firstIndex;
        private bool isAction;
        [SerializeField]
        private List<Sprite> _sprites = new List<Sprite>();

        public ItemNo Result { get; set; }

        // TODO
        public bool Initialize(List<ItemInfo> balls, Action callback) { return false; }

        // TODO
        public override void OnUpdate(float deltaTime) { }

        // TODO
        protected override void OnShow() { }

        // TODO
        public BallListState SetOpenBallInfo(bool enableCallback = true) { return BallListState.Empty; }

        // TODO
        public BallListState SetBallInfo(bool enableCallback = true) { return BallListState.Empty; }

        // TODO
        private void SetBallInfo(ItemNo ballItemNo, int count, Sprite icon) { }

        // TODO
        protected override void PreparaNext(bool isForward) { }

        // TODO
        public void SetInvalid() { }

        // TODO
        public void CleanUp() { }

        // TODO
        private void OnSubmit() { }

        // TODO
        private void OnCancel() { }

        public enum BallListState : int
        {
            Empty = 0,
            One = 1,
            Many = 2,
        }
    }
}