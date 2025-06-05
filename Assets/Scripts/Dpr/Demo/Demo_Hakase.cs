using System;
using System.Collections;
using System.IO;
using Audio;
using DG.Tweening;
using Dpr.Battle.Logic;
using Dpr.Message;
using Dpr.MsgWindow;
using Dpr.SubContents;
using Dpr.UI;
using Effect;
using GameData;
using Pml;
using SmartPoint.AssetAssistant;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Dpr.Demo
{
    public class Demo_Hakase : DemoBase
    {
        private const string HAKASE_ASSET_PATH = "persons/battle/tr2003_01";
        private const string RIVAL_ASSET_PATH = "persons/battle/tr0002_00";
        private const string GONBE_ASSET_PATH = "pm0446_00_00_gonbe";
        private UnityEngine.Object Rival3DModel;
        private static readonly string[] RIVAL_NAMES_D = new string[5]
        {
            "7-msg_opening_26", "7-msg_opening_27", "7-msg_opening_28", "7-msg_opening_29", "7-msg_opening_30"
        };
        private static readonly string[] RIVAL_NAMES_P = new string[5]
        {
            "7-msg_opening_26", "7-msg_opening_31", "7-msg_opening_32", "7-msg_opening_33", "7-msg_opening_34"
        };
        private RuntimeAnimatorController animController;
        public OpeningController openingController;
        private BattleCharacterEntity hakaseEntity;
        private EffectInstance bgEffect;
        private EffectData bgEffectData;
        private bool isSkip;

        public override AssetRequestOperation PreloadAssetBundles()
        {
            AssetManager.AppendAssetBundleRequest(AssetBundlePath, true, null, null);
            AssetManager.AppendAssetBundleRequest(HAKASE_ASSET_PATH, true, null, null);
            AssetManager.AppendAssetBundleRequest(RIVAL_ASSET_PATH, true, null, null);
            AssetManager.AppendAssetBundleRequest("field/camera/chapter001", true, null, null);
            AssetManager.AppendAssetBundleRequest(BGPaths[(int)bgType], true, null, null);

            string munchlaxBundle = Utils.GetPokemonAssetbundleName(DataManager.GetPokemonCatalog(MonsNo.GONBE, 0, Sex.MALE, false, false).AssetBundleName);
            AssetManager.AppendAssetBundleRequest(munchlaxBundle, true, null, null);

            string fieldEffectBundle = EffectManager.Instance.dbEffects.FieldEffectData[(int)EffectFieldID.EF_F_BG_EVENTAREA001_01].AssetBundleName;
            AssetManager.AppendAssetBundleRequest(fieldEffectBundle, true, null, null);

            return AssetManager.DispatchRequests(null);
        }

        public override void ReleasePreloadedAssetBundles()
        {
            AssetManager.UnloadAssetBundle(AssetBundlePath);
            AssetManager.UnloadAssetBundle(HAKASE_ASSET_PATH);
            AssetManager.UnloadAssetBundle(RIVAL_ASSET_PATH);
            AssetManager.UnloadAssetBundle("field/camera/chapter001");
            AssetManager.UnloadAssetBundle(BGPaths[(int)bgType]);

            string munchlaxBundle = Utils.GetPokemonAssetbundleName(DataManager.GetPokemonCatalog(MonsNo.GONBE, 0, Sex.MALE, false, false).AssetBundleName);
            AssetManager.UnloadAssetBundle(munchlaxBundle);

            if (EffectManager.Instance == null)
                return;

            string fieldEffectBundle = EffectManager.Instance.dbEffects.FieldEffectData[(int)EffectFieldID.EF_F_BG_EVENTAREA001_01].AssetBundleName;
            AssetManager.UnloadAssetBundle(fieldEffectBundle);
        }

        public Demo_Hakase()
        {
            UseStartEnterFade = true;
            UseStartExitFade = true;
            UseEndEnterFade = true;
            UseEndExitFade = true;
            StartEnterFadeDuration = 1.0f;
            StartExitFadeDuration = 1.0f;
            EndEnterFadeDuration = 1.0f;
            EndExitFadeDuration = 1.0f;
            FadeColor = Color.black;
        }

        public override IEnumerator Enter()
        {
            manager.Fade.DOFade(1.0f, 0.0f);
            manager.UICanvas.sortingOrder = 99;
            manager.MyEnvironmentController.SetLight(cameraController.environmentSettings[1], GameManager.currentPeriodOfDay, 0.0f, 0.0f);

            Messages.Add(CreateMsgWindowParam("dp_scenario1", "7-msg_opening_01", true));
            Messages.Add(CreateMsgWindowParam("dp_scenario1", "7-msg_opening_02_1", false));
            Messages.Add(CreateMsgWindowParam("dp_scenario1", "7-msg_opening_06", true));
            Messages.Add(CreateMsgWindowParam("dp_scenario1", "7-msg_opening_09_1", false));
            Messages.Add(CreateMsgWindowParam("dp_scenario1", "7-msg_opening_09_2", false));
            Messages.Add(CreateMsgWindowParam("dp_scenario1", "7-msg_opening_36", true));
            Messages.Add(CreateMsgWindowParam("dp_scenario1", "7-msg_opening_15", false));
            Messages.Add(CreateMsgWindowParam("dp_scenario1", "7-msg_opening_16_1", true));
            Messages.Add(CreateMsgWindowParam("dp_scenario1", "7-msg_opening_16_2", false));
            Messages.Add(CreateMsgWindowParam("dp_scenario1", "7-msg_opening_17", true));
            Messages.Add(CreateMsgWindowParam("dp_scenario1", "7-msg_opening_18", true));
            Messages.Add(CreateMsgWindowParam("dp_scenario1", "7-msg_opening_19_1", false));
            Messages.Add(CreateMsgWindowParam("dp_scenario1", "7-msg_opening_19_2", false));
            Messages.Add(CreateMsgWindowParam("dp_scenario1", "7-msg_opening_19_3", true));

#if PEARL
            bgType = BGType.HakaseRed;
#else
            bgType = BGType.HakaseBlue;
#endif

            yield return LoadBackGround((bg) =>
            {
                bg.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            }, true);

            yield return LoadPokeAsset(MonsNo.GONBE, 0, Sex.MALE, false, false, false, true);

            yield return Utils.LoadAsset(HAKASE_ASSET_PATH, (asset) =>
            {
                if (asset.name != "tr2003_01")
                    return;

                var obj = UnityEngine.Object.Instantiate(asset, parent);
                var go = obj as GameObject;

                go.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                hakaseEntity = go.GetComponent<BattleCharacterEntity>();
                hakaseEntity.Initialize(default, false);
            });

            yield return Utils.LoadAsset(RIVAL_ASSET_PATH, (asset) =>
            {
                if (asset.name != "tr0002_00")
                    return;

                Rival3DModel = asset;
            });

            yield return Utils.LoadAsset("field/camera/chapter001", (asset) =>
            {
                if (asset.name != "chapter001_controller")
                    return;

                animController = (RuntimeAnimatorController)asset;
                cameraController.SetAnimatorController(animController);
            });

            var loadParams = new EffectManager.LoadParam[] { EffectManager.Instance.dbEffects.FieldEffectData[(int)EffectFieldID.EF_F_BG_EVENTAREA001_01] };
            yield return EffectManager.Instance.OpLoad(loadParams, (effect, isAllLoaded) =>
            {
                bgEffect = EffectManager.Instance.Play(effect, hakaseEntity.transform.position + new Vector3(0.0f, 0.0f, 1.46f), Quaternion.identity, null, null);
                bgEffectData = effect;
            });

            nowMessageNo = -1;
        }

        public override IEnumerator Main()
        {
            cameraController.cam.usePhysicalProperties = true;
            cameraController.cam.gateFit = Camera.GateFitMode.Vertical;
            cameraController.PlayAnim("chapter001-001_cut01");
            yield return null;

            cameraController.PauseAnim();
            DrawNextMessage();
            yield return WaitMessageWindow(true, 0.0f);

            manager.Fade.DOFade(0.0f, 2.0f);
            cameraController.ResumeAnim();
            AudioManager.Instance.SetBgmEvent(AK.EVENTS.B_OTH003, false);
            yield return new WaitForSeconds(2.0f);

            DrawNextMessage();
            yield return WaitMessageWindow(false, 0.0f);

            DrawNextMessage();
            yield return WaitMessageWindow(true, 0.0f);

            hakaseEntity.RequestAnimationState(BattleCharacterEntity.AnimationState.Wait02_B);
            yield return new WaitForSeconds(0.5f);

            hakaseEntity.RequestAnimationState(BattleCharacterEntity.AnimationState.Advent_B);
            yield return new WaitForSeconds(0.9f);

            cameraController.PlayAnim("chapter001-001_cut02");
            yield return new WaitForSeconds(0.15f);

            cameraController.PlayAnim("chapter001-001_cut03");
            yield return new WaitForSeconds(1.0f);

            var gonbe = UnityEngine.Object.Instantiate(PokeAsset, parent) as GameObject;
            gonbe.transform.localScale = Vector3.zero;
            gonbe.transform.localPosition = new Vector3(0.38f, 0.0f, 0.314f);
            var pokeBall = Array.Find(BattleDataTableManager.Instance.BattleDataTable.BallEffectData, x => x.BallID == BallId.MONSUTAABOORU);
            var path = ("effect/prefab/battle/" + Path.GetFileNameWithoutExtension(pokeBall.IntroEffectAssetbundleName)).ToLower();
            var effectParam = Array.Find(EffectManager.Instance.dbEffects.BattleEffectData, x => x.AssetBundleName == path);
            yield return EffectManager.Instance.OpLoad(new EffectManager.LoadParam[1] { effectParam }, (effect, isAllLoaded) =>
            {
                EffectManager.Instance.Play(effect, gonbe.transform.position, Quaternion.identity, null, instance => effect.Release());
            });

            var animPlayer = gonbe.GetComponent<FieldPokemonEntity>().GetAnimationPlayer();
            gonbe.transform.DOScale(Vector3.one, 0.2f).OnComplete(() =>
            {
                animPlayer.Play(FieldPokemonEntity.Animation.Roar01);
                DOVirtual.DelayedCall(animPlayer.currentRemaingTime, () => animPlayer.Play(FieldPokemonEntity.Animation.Idle));
                DOVirtual.DelayedCall(0.2f, () => Utils.PlayVoice(MonsNo.GONBE, 0, 0, (UnityAction<AudioInstance>)null));
            });
            AudioManager.Instance.PlaySe(AK.EVENTS.PLAY_BA_SYS_BALL_OPEN, null);
            yield return new WaitForSeconds(3.5f);

            DrawNextMessage();
            yield return WaitMessageWindow(false, 0.0f);

            DrawNextMessage();
            yield return WaitMessageWindow(false, 0.0f);

            DrawNextMessage();
            yield return WaitMessageWindow(true, 0.0f);

            yield return null;

            // Params are ignored, so they don't matter
            yield return PlayerSelect(gonbe, null);

            DrawNextMessage();
            yield return WaitMessageWindow(true, 0.0f);

            var rival = UnityEngine.Object.Instantiate(Rival3DModel, parent) as GameObject;
            rival.transform.localPosition = new Vector3(-3.0f, 0.0f, 2.1f);
            cameraController.cam.GetComponent<Animator>().enabled = false;
            yield return null;

            var tw = cameraController.cam.transform.DOLocalMove(new Vector3(-3.0f, 1.2f, 5.0f), 2.0f).SetEase(Ease.InOutQuint);
            while (tw.IsPlaying())
                yield return null;

            DrawNextMessage();
            yield return WaitMessageWindow(false, 0.0f);

            yield return RivalSelect();

            cameraController.PlayAnim("chapter001-001_cut04");
            animPlayer.Play(FieldPokemonEntity.Animation.Happy02);
            DOVirtual.DelayedCall(animPlayer.currentRemaingTime, () =>
            {
                animPlayer.Play(FieldPokemonEntity.Animation.MoveC);
                animPlayer.forceLoop = true;
            });
            DrawNextMessage();
            yield return WaitMessageWindow(false, 0.0f);

            DrawNextMessage();
            yield return WaitMessageWindow(false, 0.0f);

            DrawNextMessage();
            yield return WaitMessageWindow(true, 0.0f);

            cameraController.PlayAnim("chapter001-001_cut05");
            yield return new WaitForSeconds(3.0f);

            AudioManager.Instance.SetBgmEvent("EV012");
        }

        private IEnumerator PlayerSelect(GameObject gonbe, Image bgImage)
        {
            bool isFinished = false;
            while (!isFinished)
            {
                bool isCharacterSelected = false;

                if (openingController != null)
                {
                    openingController.OnFinishedCallBack = () => isCharacterSelected = true;
                    openingController.OpenSelectPlayerVisual();
                }
                else
                {
                    isCharacterSelected = true;
                }

                yield return new WaitForSeconds(0.2f);

                while (!isCharacterSelected)
                    yield return null;

                MessageWordSetHelper.SetPlayerNickNameWord(0);
                DrawNextMessage();

                bool isSelect = false;
                Messages[nowMessageNo].onFinishedShowAllMessage = () => MsgWindowManager.OpenYesNoMenu((selectIndex) =>
                {
                    if (selectIndex != 0)
                        nowMessageNo++;
                    else
                        isFinished = true;

                    isSelect = true;
                }, ContextMenuWindow.CursorType.Arrow, true, true, null);

                while (!isSelect)
                    yield return null;

                CloseWindow();
            }
        }

        private IEnumerator RivalSelect()
        {
            bool isFinished = false;
            while (!isFinished)
            {
                DrawNextMessage();
                yield return WaitMessageWindow(true, 0.0f);

                bool isRivalSelected = false;

                bool isDiamond = PlayerWork.cassetVersion == CassetVersion.DPR_B;
                var msgFile = MessageManager.Instance.GetMsgFile("dp_scenario1");
                var windowParam = new ContextMenuWindow.Param
                {
                    itemParams = new ContextMenuItem.Param[5]
                    {
                        new ContextMenuItem.Param() { text = msgFile.GetFormattedMessage(isDiamond ? RIVAL_NAMES_D[0] : RIVAL_NAMES_P[0]), messageIndex = 0, },
                        new ContextMenuItem.Param() { text = msgFile.GetFormattedMessage(isDiamond ? RIVAL_NAMES_D[1] : RIVAL_NAMES_P[1]), messageIndex = 1, },
                        new ContextMenuItem.Param() { text = msgFile.GetFormattedMessage(isDiamond ? RIVAL_NAMES_D[2] : RIVAL_NAMES_P[2]), messageIndex = 2, },
                        new ContextMenuItem.Param() { text = msgFile.GetFormattedMessage(isDiamond ? RIVAL_NAMES_D[3] : RIVAL_NAMES_P[3]), messageIndex = 3, },
                        new ContextMenuItem.Param() { text = msgFile.GetFormattedMessage(isDiamond ? RIVAL_NAMES_D[4] : RIVAL_NAMES_P[4]), messageIndex = 4, },
                    },
                    position = new Vector2(160.0f, 300.0f),
                    minItemWidth = 122.0f,
                    useCancel = false,
                    useLoopAndRepeat = false,
                };

                var window = UIManager.Instance.CreateUIWindow<ContextMenuWindow>(UIWindowID.CONTEXTMENU);

                bool isSelectMyself = false;
                bool isAnySelected = false;

                window.onClicked = item =>
                {
                    isAnySelected = true;

                    if (item.param.messageIndex == 0)
                        isSelectMyself = true;
                    else
                        PlayerWork.rivalName = item.param.text;

                    return true;
                };

                window.Open(windowParam);

                while (!isAnySelected)
                    yield return null;

                if (isSelectMyself && openingController != null)
                {
                    openingController.OnFinishedCallBack = () => isRivalSelected = true;
                    openingController.OpenKeyboardByRivalName();
                }
                else
                {
                    isRivalSelected = true;
                }

                while (!isRivalSelected)
                    yield return null;

                if (PlayerWork.rivalName == "")
                {
                    nowMessageNo--;
                    continue;
                }

                MessageWordSetHelper.SetPlayerNickNameWord(0);
                MessageWordSetHelper.SetRivalNickNameWord(1);
                DrawNextMessage();

                bool isSelect = false;

                nowMSG.onFinishedShowAllMessage = () =>
                {
                    MsgWindowManager.OpenYesNoMenu(selectIndex =>
                    {
                        if (selectIndex == 0)
                        {
                            isFinished = true;
                            isSelect = true;
                        }
                        else
                        {
                            nowMessageNo--;
                            nowMessageNo--;
                            isSelect = true;
                        }
                    }, ContextMenuWindow.CursorType.Arrow, true, true, null);
                };

                while (!isSelect)
                    yield return null;

                CloseWindow();

                yield return new WaitForSeconds(0.5f);

                if (isFinished)
                    cameraController.cam.GetComponent<Animator>().enabled = true;
            }
        }

        public override void LightUpdate()
        {
            base.LightUpdate();
        }

        public override IEnumerator Exit()
        {
            bgEffectData.Release();
            EffectManager.Instance.RemoveInstances(true);

            if (openingController == null)
                manager.FadeExit(1.0f);
            else
                PlayerWork.SetTransitionZone(ZoneID.T01R0202, 0);

            yield return null;
        }
    }
}
