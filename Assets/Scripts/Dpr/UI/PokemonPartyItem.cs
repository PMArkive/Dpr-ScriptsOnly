using Dpr.Battle.Logic;
using Effect;
using Pml.PokePara;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
    public class PokemonPartyItem : MonoBehaviour
    {
        [SerializeField]
        private RectTransform _root;
        [SerializeField]
        private RectTransform _infoRoot;
        [SerializeField]
        private RectTransform _statusRoot;
        [SerializeField]
        private UIText _name;
        [SerializeField]
        private UIText _hp;
        [SerializeField]
        private UIText _maxHp;
        [SerializeField]
        private HpBar _hpBar;
        [SerializeField]
        private Image _hpBG;
        [SerializeField]
        private UIText _level;
        [SerializeField]
        private Image _sex;
        [SerializeField]
        private RectTransform _itemRoot;
        [SerializeField]
        private PokemonIcon _pokemonIcon;
        [SerializeField]
        private PokemonSick _sick;
        [SerializeField]
        private RectTransform _pair;
        [SerializeField]
        private Contest _contest;
        [SerializeField]
        private RotomSelect _rotomSelect;
        [SerializeField]
        private RectTransform _usableItemRoot;
        [SerializeField]
        private float _formChangeLoadIconTiming = 0.8f;

        private int _stateBits;
        private Param _param;
        private bool isShowUsableItem;
        private Vector3 _offsetIconPos = Vector3.zero;
        private Vector3 _initIconPos = Vector3.zero;
        private Animator _animator;

        public static readonly int animState0Normal = Animator.StringToHash("Normal");
        public static readonly int animState0Select = Animator.StringToHash("Select");
        public static readonly int animState0DecideContext = Animator.StringToHash("Context");
        public static readonly int animState0Decide = Animator.StringToHash("Decide");
        public static readonly int animState0Disable = Animator.StringToHash("Disable");
        public static readonly int animState1Stop = Animator.StringToHash("Stop");
        public static readonly int animState1Sick = Animator.StringToHash("Shiver");
        public static readonly int animState1SelectState0 = Animator.StringToHash("Jump_01_01");
        public static readonly int animState1State0 = Animator.StringToHash("Jump_02_01");
        public static readonly int animState1SelectState1 = Animator.StringToHash("Jump_01_02");
        public static readonly int animState1State1 = Animator.StringToHash("Jump_02_02");
        public static readonly int animState1SelectState2 = Animator.StringToHash("Jump_01_03");
        public static readonly int animState1State2 = Animator.StringToHash("Jump_02_03");
        public static readonly int animState1SelectState3 = Animator.StringToHash("Jump_01_04");
        public static readonly int animState1State3 = Animator.StringToHash("Jump_02_04");
        public static readonly int animState2Normal0 = Animator.StringToHash("Member_Normal");
        public static readonly int animState2Normal1 = Animator.StringToHash("Leader_Normal");
        public static readonly int animState2Exchange0 = Animator.StringToHash("Member_ItemExchang");
        public static readonly int animState2Exchange1 = Animator.StringToHash("Leader_ItemExchang");
        public static readonly int animState2Friend0 = Animator.StringToHash("FriendMember_Normal");
        public static readonly int animState2Friend1 = Animator.StringToHash("FriendLeader_Normal");

        private Coroutine _coroutine;
        private EffectInstance _effectInstance;
        private bool _isDestroy;

        public Param param { get => _param; }
        public PokemonIcon pokemonIcon { get => _pokemonIcon; }

        // TODO
        private void Awake() { }

        // TODO
        private void OnDestroy() { }

        // TODO
        public void Setup(Param param) { }

        // TODO
        public void SetEnable(bool enabled) { }

        // TODO
        public void EnablePairIcon(bool enabled) { }

        // TODO
        public void SetupItem() { }

        // TODO
        public void ShowItemName(bool enabled) { }

        // TODO
        public void ShowUsableItemText(string labelName) { }

        // TODO
        public void HideUsableItemText() { }

        // TODO
        public void Select(int stateBits) { }

        // TODO
        public void Decide(bool isOpenContextMenu) { }

        // TODO
        private void SetState() { }

        // TODO
        private void SetIconState(bool isSelect) { }

        // TODO
        public void ReturnItemInBag() { }

        // TODO
        public void EnableSwapMode(bool enabled) { }

        // TODO
        public Vector3 GetSwapPosition() { return default; }

        // TODO
        public void SetSwapPosition() { }

        // TODO
        public void SetSwapPosition(Vector3 pos) { }

        // TODO
        public void UpdateHp([Optional] Action onComplete) { }

        // TODO
        public bool FormChange(ushort formNo, [Optional] RectTransform effectRoot, [Optional] Action<PokemonParam> onChangeIcon, [Optional] Action<PokemonParam> onComplete)
        {
            // TODO
            IEnumerator EffectProc() { return default; }

            // TODO
            void Complete() { }

            return default;
        }

        // TODO
        private void PlayVoice(PokemonParam pokemonParam, [Optional] Action onComplete) { }

        [Serializable]
        private class Contest
        {
            public RectTransform root;
            public Image bg;
            public UIText text;
            public string[] messageIds;
            public Sprite[] spriteBgs;
            public Color[] colors;
        }

        [Serializable]
        private class RotomSelect
        {
            public RectTransform root;
            public Image bg;
            public UIText text;
            public string messageFile;
            public string[] messageIds;
            public Sprite[] spriteBgs;
            public Color[] colors;
        }

        [Flags]
        public enum StateBits : int
        {
            Select = 1,
            ItemSwap = 2,
        }

        public class Param
        {
            public PokemonParam pokemonParam;
            public bool showItemName;
            public Contest contest;
            public Battle battle;
            public RotomSelect rotomSelect;

            public class Contest
            {
                public bool isEntry = true;
            }

            public class Battle
            {
                public BTL_POKEPARAM battlePokemonParam;
                public int plateType = 1;
            }

            public class RotomSelect
            {
                public bool isEntry = true;
            }
        }
    }
}