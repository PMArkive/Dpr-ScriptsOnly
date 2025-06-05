﻿using Dpr.SubContents;
using Pml;
using Pml.PokePara;
using System.Collections.Generic;
using XLSXContent;
using static AK.STATES;

namespace Dpr.Field.Walking
{
    public sealed class FieldPokeTalkModel
    {
        private PokemonParam param;
        private List<FieldWalkingPokeTalk.SheetSheet1> talkList;
        private int MonohiroiItemID;
        private float walkDistance_nakayoshi;
        private float walkDistance_monohiroi;
        private uint friendship;
        private float HPRate;
        private Sick sick;
        private PokeType type;
        private uint walkCount;
        private WalkingCharacterController Controller;
        private FieldWalkingPokeTalk.SheetSheet1 SelectedAction;
        public FieldWalkingPokeTalk.SheetSheet1 PrevTalk;
        public bool isBadStateTalk;

        public static readonly PokeType[] PokeTypeArray = new PokeType[19]
        {
            PokeType.NULL,  PokeType.NORMAL, PokeType.HONOO, PokeType.MIZU,
            PokeType.DENKI, PokeType.KUSA,   PokeType.KOORI, PokeType.KAKUTOU,
            PokeType.DOKU,  PokeType.JIMEN,  PokeType.HIKOU, PokeType.ESPER,
            PokeType.MUSHI, PokeType.IWA,    PokeType.GHOST, PokeType.DRAGON,
            PokeType.AKU,   PokeType.HAGANE, PokeType.FAIRY,
        };
        public static readonly int[] MonohiroiKakuritu = new int[6] { 5, 15, 20, 30, 35, 50 };

        private List<FieldWalkingKinomiTable.SheetA> kinomiTableA;
        private List<FieldWalkingKinomiTable.SheetB> kinomiTableB;
        private List<FieldWalkingKinomiTable.SheetC> kinomiTableC;
        private List<FieldWalkingKinomiSeikakuTable.SheetSheet1> seikakuTable;

        [Button("DebugTimeSave", "DebugTimeSave", new object[0])]
        public int button002;

        public int DebugTime;

        [Button("Check4Hour", "Check4Hour", new object[0])]
        public int button001;

        public bool isMotionEnd;
        public bool isTalkEnd;

        // TODO
        public FieldPokeTalkModel(WalkingCharacterController Controller, PokemonParam param, List<FieldWalkingPokeTalk.SheetSheet1> talkList, FieldWalkingKinomiTable kinomiTable, List<FieldWalkingKinomiSeikakuTable.SheetSheet1> seikakuTable) { }

        // TODO
        public void WalkUpdate(float deltaDistance) { }

        // TODO
        private void DebugTimeSave() { }

        // TODO
        private int GetTimeAndCount() { return 0; }

        // TODO
        private int GetMonohiroiCount() { return 0; }

        // TODO
        private void AddMonohiroiCount() { }

        // TODO
        private int[] GetTimeAndCountArray() { return null; }

        // TODO
        private bool Check4Hour() { return false; }

        // TODO
        private int GetHourDiff(int prevHour, int nowHour) { return 0; }

        // TODO
        private int GetMinutesDiff(int prevMinutes, int nowMinutes) { return 0; }

        // TODO
        public void StartTalk()
        {
            // TODO
            void PlayVoice() { }

            // TODO
            void ShowMessage() { }

            // TODO
            void EndCheck() { }

            // TODO
            void EndAnimation(bool forceLoop) { }

            // TODO
            void TalkMain() { }
        }

        // TODO
        private int AnimNameToID(string animName) { return 0; }

        // TODO
        private void CheckState() { }

        // TODO
        private int GetVoiceID() { return 0; }

        // TODO
        private int GetAnimID() { return 0; }

        // TODO
        public bool IsMonohiroi() { return false; }

        // TODO
        private bool LotteryMonohiroi() { return false; }

        // TODO
        private int GetTableID() { return 0; }

        // TODO
        private int LotteryItem(int tableID) { return 0; }

        // TODO
        public void ResetItem() { }

        // TODO
        private void LotteryTalkMessage() { }

        // TODO
        public int GetItemID() { return 0; }

        public class MonohiroiLottery : IHaveWeight
        {
            private float rate;
            public int MstID;

            public float lotteryWeight { get => rate; }

            public MonohiroiLottery(int Rate, int MstID)
            {
                this.rate = Rate * 0.01f;
                this.MstID = MstID;
            }
        }
    }
}