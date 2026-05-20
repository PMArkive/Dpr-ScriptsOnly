using AK;
using Audio;
using DG.Tweening;
using Dpr.EvScript;
using Dpr.Message;
using Dpr.SubContents;
using Pml;
using Pml.PokePara;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using XLSXContent;

namespace Dpr.Field.Walking
{
    public sealed class FieldPokeTalkModel
    {
        private PokemonParam param;
        private List<FieldWalkingPokeTalk.SheetSheet1> talkList;
        private int MonohiroiItemID = -1;
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
        public bool isBadStateTalk = true;

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

        public FieldPokeTalkModel(WalkingCharacterController Controller, PokemonParam param, List<FieldWalkingPokeTalk.SheetSheet1> talkList, FieldWalkingKinomiTable kinomiTable, List<FieldWalkingKinomiSeikakuTable.SheetSheet1> seikakuTable)
        {
            this.Controller = Controller;
            this.param = param;
            this.talkList = talkList;
            kinomiTableA = kinomiTable.A.ToList();
            kinomiTableB = kinomiTable.B.ToList();
            kinomiTableC = kinomiTable.C.ToList();
            this.seikakuTable = seikakuTable;
        }

        public void WalkUpdate(float deltaDistance)
        {
            walkDistance_nakayoshi += deltaDistance;

            if (walkDistance_nakayoshi >= 128.0f)
            {
                walkDistance_nakayoshi = 0.0f;
                if (UnityEngine.Random.Range(0, 2) == 0)
                    param.AddFriendship(1);
            }

            if (!SystemTimeWork.IsPenalty() &&
                (GetMonohiroiCount() < 1 || !Check4Hour()) &&
                MonohiroiItemID == -1)
            {
                walkDistance_monohiroi += deltaDistance;

                if (walkDistance_monohiroi >= 200.0f)
                {
                    CheckState();
                    walkDistance_monohiroi = 0.0f;

                    if (LotteryMonohiroi())
                    {
                        MonohiroiItemID = LotteryItem(GetTableID());
                        MonohiroiItemID = Utils.KinomiID_to_ItemID(MonohiroiItemID);

                        TvWork.RareMonohiroi((ItemNo)MonohiroiItemID, param);
                        AddMonohiroiCount();

                        var timeAndCount = GetTimeAndCount();

                        // Result ignored
                        _ = GetTimeAndCountArray();

                        FlagWork.SetWork(EvWork.WORK_INDEX.MONOHIROI_TIME, timeAndCount);
                    }
                }
            }
        }

        private void DebugTimeSave()
        {
            FlagWork.SetWork(EvWork.WORK_INDEX.MONOHIROI_TIME, DebugTime);
        }
        
        private int GetTimeAndCount()
        {
            var now = DateTime.Now;
            return now.Minute * 10 + now.Hour * 1000 + GetMonohiroiCount();
        }

        private int GetMonohiroiCount()
        {
            return FlagWork.GetWork(EvWork.WORK_INDEX.MONOHIROI_TIME) % 10;
        }

        private void AddMonohiroiCount()
        {
            FlagWork.SetWork(EvWork.WORK_INDEX.MONOHIROI_TIME, GetTimeAndCount() + 1);
        }

        private int[] GetTimeAndCountArray()
        {
            var prev = FlagWork.GetWork(EvWork.WORK_INDEX.MONOHIROI_TIME);
            var prevHours = (prev / 1000) % 100;
            var prevMins = (prev / 10) % 100;

            var now = DateTime.Now;
            var nowHours = now.Hour;
            var nowMins = now.Minute;

            return new int[]
            {
                prev % 10,
                prevMins,
                prevHours,
                nowMins,
                nowHours,
                GetMinutesDiff(prevMins, nowMins),
                GetHourDiff(prevHours, nowHours),
            };
        }

        private bool Check4Hour()
        {
            var prev = FlagWork.GetWork(EvWork.WORK_INDEX.MONOHIROI_TIME);
            var prevHours = (prev / 1000) % 100;
            var prevMins = (prev / 10) % 100;

            var now = DateTime.Now;
            var nowHours = now.Hour;
            var nowMins = now.Minute;

            var hourDiff = GetHourDiff(prevHours, nowHours);

            return hourDiff < 4 || (nowMins < prevMins && hourDiff == 4);
        }

        private int GetHourDiff(int prevHour, int nowHour)
        {
            return ((prevHour <= nowHour) ? nowHour : (nowHour + 24)) - prevHour;
        }

        private int GetMinutesDiff(int prevMinutes, int nowMinutes)
        {
            return ((prevMinutes <= nowMinutes) ? nowMinutes : (nowMinutes + 60)) - prevMinutes;
        }

        public void StartTalk()
        {
            FieldWalkingManager.talkState = FieldWalkingManager.TalkState.Talking;
            Controller.model.walkData.nowSpeed = 0.0f;

            // None of these strings are used (likely a commented out log)
            var timeCountArray = GetTimeAndCountArray();
            var str1 = "もの拾い時間 h:" + timeCountArray[2] + "m:" + timeCountArray[1] + " 1日個数:" + timeCountArray[0] + "\n";
            var str2 = str1 + "現在時間 h:" + timeCountArray[4] + "m:" + timeCountArray[3] + "\n";
            var str3 = str2 + "経過時間 h:" + timeCountArray[6] + "m:" + timeCountArray[5] + "\n";

            var animPlayer = Controller.model.entity.GetAnimationPlayer();
            var animID = 0;

            Controller.emoticon.Enter();
            AudioManager.Instance.PlaySe(EVENTS.S_FI004, null);

            var isMotionEnd = false;
            var isTalkEnd = false;

            var existAnim = Utils.GetExistAnim(animPlayer, new int[] { FieldPokemonEntity.Animation.Kw_Wait, FieldPokemonEntity.Animation.Idle });
            var kobetuWait = Controller.view.GetNeutralWaitAnim();
            var waitAnim = Controller.view.GetWaitAnim(kobetuWait, existAnim);

            // Result ignored
            _ = Controller.view.GetWaitAnim(existAnim, kobetuWait);

            var isExistKW_Motion = Utils.GetExistAnim(animPlayer, new int[] { FieldPokemonEntity.Animation.Kw_Wait }) != -1;
            var isPikaV = Utils.IsPikaV(param.GetMonsNo());
            var isMotionTalk = false;

            if (!IsMonohiroi())
            {
                CheckState();
                LotteryTalkMessage();

                if (((!isExistKW_Motion || isPikaV) ? SelectedAction.BaWaitMotion : SelectedAction.Motion) != "なし") // "None"
                    isMotionTalk = true;

                if (Controller.trearukiAnimeInfo == null || !Controller.trearukiAnimeInfo.Enable)
                {
                    if (Controller.view.isHokanAnimation(waitAnim) && isMotionTalk)
                    {
                        Controller.AI.GetNowState().Play(new PlayAnim(waitAnim, 0.5f, 0.0f), () =>
                        {
                            Controller.model.isForceAnimation = true;
                            Controller.InitAnimationPlayer();
                            TalkMain();
                        });
                    }
                    else
                    {
                        Controller.view.AnimPlay(kobetuWait, 0.5f, 0.0f);
                        Controller.model.isForceAnimation = true;

                        DOVirtual.DelayedCall(1.0f, () => TalkMain());
                    }
                }
                else
                {
                    var timer = 0.0f;

                    Controller.nextActionState = WalkingCharacterController.ActionState.TalkStayWait;
                    Controller.talkAction = time =>
                    {
                        if (timer <= 0.15f)
                        {
                            timer += time;
                        }
                        else if (IsMonohiroi())
                        {
                            isTalkEnd = true;
                            Controller.nextTalkState = WalkingCharacterController.ActionState.TalkNormal;
                            Controller.talkAction = null;
                        }
                        else
                        {
                            var motion = (!isExistKW_Motion || isPikaV) ? SelectedAction.BaWaitMotion : SelectedAction.Motion;

                            if (!isMotionTalk)
                            {
                                isMotionEnd = true;
                                ShowMessage();
                                Controller.nextTalkState = WalkingCharacterController.ActionState.TalkNormal;
                            }
                            else
                            {
                                animPlayer.forceLoop = false;

                                var pos = EntityManager.activeFieldPlayer.transform.TransformDirection(Vector3.forward);

                                switch (motion)
                                {
                                    case "ba20_buturi01":
                                        Controller.AI.GetNowState().Play(new LookAtPosition(pos, 5.0f, 0.5f), () =>
                                        {
                                            Controller.nextTalkState = WalkingCharacterController.ActionState.Buturi;
                                            PlayVoice();
                                            ShowMessage();
                                        });
                                        break;

                                    case "ba21_tokusyu01":
                                        Controller.AI.GetNowState().Play(new LookAtPosition(pos, 5.0f, 0.5f), () =>
                                        {
                                            Controller.nextTalkState = WalkingCharacterController.ActionState.Tokusyu;
                                            PlayVoice();
                                            ShowMessage();
                                        });
                                        break;

                                    case "kw32_happyB01":
                                        Controller.nextTalkState = WalkingCharacterController.ActionState.Happy;
                                        Controller.model.isForceAnimation = false;
                                        PlayVoice();
                                        ShowMessage();
                                        break;

                                    case "kw30_hate01":
                                        Controller.nextTalkState = WalkingCharacterController.ActionState.Hate;
                                        Controller.model.isForceAnimation = false;
                                        PlayVoice();
                                        ShowMessage();
                                        break;

                                    case "ba02_roar01":
                                        Controller.nextTalkState = WalkingCharacterController.ActionState.Roar;
                                        Controller.model.isForceAnimation = false;
                                        PlayVoice();
                                        ShowMessage();
                                        break;

                                    case "kw20_drowseA01":
                                        Controller.nextTalkState = WalkingCharacterController.ActionState.DrowSe;
                                        Controller.model.isForceAnimation = false;
                                        PlayVoice();
                                        ShowMessage();
                                        break;
                                }
                            }

                            Controller.talkAction = null;
                            timer += time;
                        }
                    };
                }
            }

            void PlayVoice()
            {
                if (SelectedAction.PokeVoice == -1)
                    return;

                var isSpecialVoice = Utils.IsPikaV(param.GetMonsNo());
                var monsno = param.GetMonsNo();

                if (isSpecialVoice)
                    Controller.voicePlayer.PlayVoice(param.GetMonsNo(), 0, monsno == MonsNo.PIKATYUU ? SelectedAction.PikaVoice : SelectedAction.EevVoice);
                else
                    Utils.PlayVoice(monsno, param.GetFormNo(), 0, Controller.voicePlayer);
            }

            void ShowMessage()
            {
                MessageWordSetHelper.SetPokemonNickNameWord(1, param);
                MessageWordSetHelper.SetPlayerNickNameWord(2);
                MessageWordSetHelper.SetPlayerNickNameWord(0);

                MsgWindow.MsgWindow window = null;
                var msgParam = Utils.CreateMsgWindowParam("dlp_tsurearuki", SelectedAction.ID);
                Utils.DrawMessage(msgParam, ref window);

                if (!window.IsOpen)
                    FieldWalkingManager.talkState = FieldWalkingManager.TalkState.TalkEnd;

                msgParam.onFinishedCloseWindow = () =>
                {
                    isTalkEnd = true;
                    EndCheck();
                };
            }

            void EndCheck()
            {
                if (isTalkEnd && isMotionEnd)
                {
                    FieldWalkingManager.talkState = FieldWalkingManager.TalkState.TalkEnd;
                    Controller.model.isForceAnimation = false;

                    if (isMotionTalk)
                        Controller.InitAnimationPlayer();
                }
            }

            void EndAnimation(bool forceLoop)
            {
                if (Controller.view.isHokanAnimation(kobetuWait))
                {
                    Controller.AI.GetNowState().Play(new PlayAnim(kobetuWait, 0.0f, 0.0f), () =>
                    {
                        DOVirtual.DelayedCall(0.2f, () => animPlayer.forceLoop = forceLoop);
                        isMotionEnd = true;
                        EndCheck();
                    });
                }
                else
                {
                    Controller.view.AnimPlay(kobetuWait, 1.0f, 0.0f);
                    DOVirtual.DelayedCall(0.2f, () => animPlayer.forceLoop = forceLoop);
                    isMotionEnd = true;
                    EndCheck();
                }
            }

            void TalkMain()
            {
                var forceloop = animPlayer.forceLoop;

                if (IsMonohiroi())
                {
                    FieldWalkingManager.talkState = FieldWalkingManager.TalkState.TalkEnd;
                    Controller.model.isForceAnimation = false;
                }
                else
                {
                    var Motion = (!isExistKW_Motion || isPikaV) ? SelectedAction.BaWaitMotion : SelectedAction.Motion;

                    if (!isMotionTalk)
                    {
                        isMotionEnd = true;
                        ShowMessage();
                    }
                    else
                    {
                        animPlayer.forceLoop = false;

                        var playerDirection = EntityManager.activeFieldPlayer.transform.TransformDirection(Vector3.forward);

                        if (Motion == "ba20_buturi01" || Motion == "ba21_tokusyu01")
                        {
                            Controller.AI.GetNowState().Play(new LookAtPosition(playerDirection, 5.0f, 0.5f), () =>
                            {
                                PlayVoice();
                                ShowMessage();

                                animID = AnimNameToID(Motion);
                                if (animID == 0)
                                {
                                    var clip = Array.Find(animPlayer.clips, x => x != null && x.name.Contains(Motion));
                                    animID = Array.FindIndex(animPlayer.clips, x => x == clip);
                                }

                                Controller.AI.GetNowState().Play(new PlayAnim(animID), () =>
                                {
                                    Controller.AI.GetNowState().Play(new LookAtPosition(playerDirection, 5.0f, 0.5f), () => EndAnimation(forceloop));
                                });
                            });
                        }
                        else
                        {
                            PlayVoice();
                            ShowMessage();

                            animID = AnimNameToID(Motion);
                            if (animID == FieldPokemonEntity.Animation.Idle)
                            {
                                var clip = Array.Find(animPlayer.clips, x => x != null && x.name.Contains(Motion));
                                animID = Array.FindIndex(animPlayer.clips, x => x == clip);
                            }

                            Controller.AI.GetNowState().Play(new PlayAnim(animID), () => EndAnimation(forceloop));
                        }
                    }
                }
            }
        }

        private int AnimNameToID(string animName)
        {
            switch (animName)
            {
                case "kw32_happyA01":  return FieldPokemonEntity.Animation.Happy01;
                case "kw32_happyB01":  return FieldPokemonEntity.Animation.Happy02;
                case "kw32_happyC01":  return FieldPokemonEntity.Animation.Happy03;
                case "ba20_buturi01":  return FieldPokemonEntity.Animation.Buturi01;
                case "ba21_tokusyu01": return FieldPokemonEntity.Animation.Tokusyu01;
                case "ba02_roar01":    return FieldPokemonEntity.Animation.Roar01;
                default:               return FieldPokemonEntity.Animation.Idle;
            }
        }

        private void CheckState()
        {
            friendship = param.GetFriendship();
            HPRate = (float)param.GetHp() / param.GetMaxHp() * 100.0f;
            sick = param.GetSick();
            type = param.GetType1();
        }

        private int GetVoiceID()
        {
            return 0;
        }

        private int GetAnimID()
        {
            return 0;
        }

        public bool IsMonohiroi()
        {
            return MonohiroiItemID != -1;
        }

        private bool LotteryMonohiroi()
        {
            var chance = MonohiroiKakuritu[Utils.GetNakayoshiRank(param.GetFriendship())];
            return UnityEngine.Random.Range(0, 100) < chance;
        }

        private int GetTableID()
        {
            var seikaku = param.GetSeikaku();
            return seikakuTable.Find(x => x.Seikaku == seikaku).TableID;
        }

        private int LotteryItem(int tableID)
        {
            var berryIDs = new List<int>(16);
            var berryRates = new List<int>(16);
            var lots = new List<MonohiroiLottery>();

            switch (tableID)
            {
                case 0:
                    berryIDs.AddRange(kinomiTableA.Select(x => x.MstID));
                    berryRates.AddRange(kinomiTableA.Select(x => x.Rate));
                    break;

                case 1:
                    berryIDs.AddRange(kinomiTableB.Select(x => x.MstID));
                    berryRates.AddRange(kinomiTableB.Select(x => x.Rate));
                    break;

                case 2:
                    berryIDs.AddRange(kinomiTableC.Select(x => x.MstID));
                    berryRates.AddRange(kinomiTableC.Select(x => x.Rate));
                    break;
            }

            for (int i=0; i<berryIDs.Count; i++)
                lots.Add(new MonohiroiLottery(berryRates[i], berryIDs[i]));

            return RandomWithWeight.Lotto(lots).MstID;
        }

        public void ResetItem()
        {
            MonohiroiItemID = -1;
        }

        private void LotteryTalkMessage()
        {
            var possibleMessages = talkList.FindAll(x =>
            {
                if (x.General)
                    return true;

                if (x.FriendshipMin != -1)
                {
                    if (friendship < x.FriendshipMin)
                        return false;

                    if (friendship > x.FriendshipMax)
                        return false;
                }

                if (x.LifeRetioMin != -1)
                {
                    if (HPRate < x.LifeRetioMin)
                        return false;

                    if (HPRate > x.LifeRetioMax)
                        return false;
                }

                if (x.State != -1)
                {
                    if (x.State == 0)
                    {
                        if (sick == Sick.NONE)
                            return false;
                    }
                    else if (x.State != (int)sick)
                        return false;
                }

                if (x.Type != -1)
                {
                    if (PokeTypeArray[x.Type] != type)
                        return false;
                }

                return true;
            });

            if (PrevTalk != null && !isBadStateTalk && possibleMessages.Contains(PrevTalk))
                possibleMessages.Remove(PrevTalk);

            if (isBadStateTalk)
            {
                var sickMessages = possibleMessages.FindAll(x => (uint)(x.State + 1) > 1);
                if (sickMessages.Count != 0)
                {
                    isBadStateTalk = false;
                    possibleMessages = sickMessages;
                }
            }

            SelectedAction = possibleMessages[UnityEngine.Random.Range(0, possibleMessages.Count)];
        }

        public int GetItemID()
        {
            return MonohiroiItemID;
        }

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