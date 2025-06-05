using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Dpr.UI
{
    public class BoxParty : BoxInfinityScrollItem
    {
        [SerializeField]
        private UIText _title;
        [SerializeField]
        private RectTransform _contents;

        public const int cellColumn = 6;
        public const int cellNum = 30;

        private BoxPartyParam _param;
        private List<BoxPartyItem> _items = new List<BoxPartyItem>();

        private static string[] _titleLabels = new string[]
        {
            "SS_boxname_033", "SS_boxname_034", "SS_boxname_035", "SS_boxname_036",
            "SS_boxname_037", "SS_boxname_038",
        };

        public BoxPartyParam Param { get => _param; }
        public List<BoxPartyItem> Items { get => _items; }

        // TODO
        private void Awake() { }

        // TODO
        public override void Setup(BaseParam baseParam) { }

        // TODO
        public void Setup() { }

        // TODO
        public void SetTitle() { }

        // TODO
        public void Apply(List<int> hideIcons, BoxWindow.OpenParam openParam, [Optional] BoxWindow.SEARCH_DATA searchData, [Optional] List<BoxWindow.SelectedPokemon> selected) { }

        // TODO
        public void SetupItems() { }

        // TODO
        public UINavigator GetNavigator(int index) { return default; }

        // TODO
        public static string GetTeamNameID(int index) { return default; }

        public class BoxPartyParam : BaseParam
        {
            public PartyType partyType;

            public enum PartyType : int
            {
                Normal = 0,
                BattleTeam = 1,
            }
        }
    }
}