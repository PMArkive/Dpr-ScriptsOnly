using DG.Tweening;
using Pml.PokePara;
using Pml;
using SmartPoint.AssetAssistant;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dpr.MsgWindow;
using Dpr.SubContents;
using GameData;
using Dpr.Message;
using System.Runtime.InteropServices;

namespace Dpr.Demo
{
    [Serializable]
    public abstract class DemoBase
    {
        public DemoCamera cameraController;
        public DemoSceneManager manager;
        public Transform parent;
        protected List<Tweener> Tws = new List<Tweener>();
        public Action OnEndDemo;
        public IEnumerator OnPreEndDemo;
        public bool UseCamera = true;
        public bool DisableEnvironmentController = true;
        public bool isUseAlpha;
        public bool isDisableEndLightSet;
        public bool isDisablePostProcess;
        public bool isDisableMainCamera;
        public int AddSortOrder;
        protected List<MsgWindowParam> Messages = new List<MsgWindowParam>();
        protected MsgWindow.MsgWindow _messageWindow;
        protected int nowMessageNo;
        public string AssetBundlePath = "demo/demosceneprefab";
        protected const string POKE_VIEW_PREFAB_PATH = "demo/pokemonview";
        protected const string RENDERCAMERA_PREFAB_PATH = "demo/demorendercamera";
        protected List<Coroutine> coroutines = new List<Coroutine>();
        protected Dictionary<int, UnityEngine.Object> PokeAssets = new Dictionary<int, UnityEngine.Object>();
        protected UnityEngine.Object PokeAsset;
        protected UnityEngine.Object BG;
        protected bool is2DBG;
#if PEARL
        protected BGType bgType = BGType.HakaseRed;
#else
        protected BGType bgType = BGType.HakaseBlue;
#endif
        protected static readonly string[] BGPaths = new string[5]
        {
            "bg/arenas/ground/pofin001",
            "bg/arenas/ground/eventarea001",
            "bg/arenas/ground/eventarea002",
            "bg/arenas/ground/eventarea003",
            "bg/arenas/ground/eventarea004",
        };
        public bool UseStartEnterFade = true;
        public bool UseStartExitFade = true;
        public bool UseEndEnterFade = true;
        public bool UseEndExitFade = true;
        public float StartEnterFadeDuration = 1.0f;
        public float StartExitFadeDuration = 1.0f;
        public float EndEnterFadeDuration = 1.0f;
        public float EndExitFadeDuration = 1.0f;
        public Color FadeColor = Color.white;

        protected Camera cam { get => cameraController.cam; }

        public virtual AssetRequestOperation PreloadAssetBundles()
        {
            // Empty
            return null;
        }

        public virtual void ReleasePreloadedAssetBundles()
        {
            // Empty
        }

        public string GetPokemonAssetBundle(MonsNo monsNo, ushort formNo, Sex sex, bool isRare, bool isBattleModel = false)
        {
            var catalog = DataManager.GetPokemonCatalog(monsNo, formNo, sex, isRare, false);
            if (isBattleModel)
                return Utils.GetBattlePokemonAssetbundleName(catalog.AssetBundleName);
            else
                return Utils.GetPokemonAssetbundleName(catalog.AssetBundleName);
        }

        public virtual void Init()
        {
            // Empty
        }

        public virtual IEnumerator Enter()
        {
            yield return null;
        }

        public virtual IEnumerator Main()
        {
            yield return null;
        }

        public virtual IEnumerator Exit()
        {
            yield return null;
        }

        public virtual void Destroy()
        {
            manager = null;
            parent = null;
            Tws.Clear();
            Tws = null;
            OnEndDemo = null;
            OnPreEndDemo = null;
            Messages.Clear();
            Messages = null;
            _messageWindow = null;
            cameraController = null;
            coroutines.Clear();
            coroutines = null;
            PokeAssets.Clear();
            PokeAssets = null;
            BG = null;
        }

        public virtual void PostProcessSetting()
        {
            // Empty
        }

        public virtual void _DebugMethod(int TestNo)
        {
            // Empty
        }

        protected bool PushA { get => Utils.PushA; }
        protected bool PushB { get => Utils.PushB; }
        protected bool PushX { get => Utils.PushX; }
        protected bool PushY { get => Utils.PushY; }
        protected bool PushAorB { get => Utils.PushAorB; }
        protected bool KeyLeft { get => Utils.KeyLeft; }
        protected bool KeyRight { get => Utils.KeyRight; }
        protected bool KeyDown { get => Utils.KeyDown; }
        protected bool KeyUp { get => Utils.KeyUp; }

        public virtual void LightUpdate()
        {
            manager.MyEnvironmentController.SetLight(cameraController.environmentSettings[1], PeriodOfDay.Daytime, 0.0f, 0.0f);
        }

        protected bool isMessageFinished
        {
            get
            {
                if (_messageWindow == null)
                    return true;

                return _messageWindow.MsgState == MsgWindowDataModel.MsgWindowState.FinishedShowMessage;
            }
        }
        protected MsgWindowParam nowMSG { get => Messages[nowMessageNo]; }
        protected bool isEnableInput
        {
            get
            {
                if (nowMSG != null && !nowMSG.inputEnabled)
                    return false;

                return isMessageFinished;
            }
        }

        protected IEnumerator WaitMessageWindow(bool isCloseWindow = true, float autoCloseTime = 0.0f)
        {
            var time = 0.0f;

            while (!Utils.PushAorB || !isEnableInput || autoCloseTime != 0.0f)
            {
                if (autoCloseTime < time && autoCloseTime != 0.0f)
                    break;

                yield return null;
                time += Sequencer.elapsedTime;
            }

            if (isCloseWindow)
                CloseWindow();

            yield return null;
        }

        protected MsgWindowParam DrawNextMessage()
        {
            return DrawMessage(++nowMessageNo);
        }

        protected MsgWindowParam DrawMessage(int NextMessageNo)
        {
            if (_messageWindow != null)
            {
                Messages[NextMessageNo].playTextFeedSe = true;
                _messageWindow.ReplaceMessage(Messages[NextMessageNo]);
            }
            else
            {
                _messageWindow = MsgWindowManager.OpenMsg(Messages[NextMessageNo]);
            }

            nowMessageNo = NextMessageNo;
            return Messages[NextMessageNo];
        }

        protected void CloseWindow()
        {
            if (_messageWindow != null)
                _messageWindow.CloseWindow();

            _messageWindow = null;
        }

        protected MsgWindowParam CreateMsgWindowParam(string msgFileName, string labelName, bool isCloseMessage = true)
        {
            var param = new MsgWindowParam
            {
                useMsgFile = MessageManager.Instance.GetMsgFile(msgFileName),
                labelName = labelName,
                inputEnabled = true,
                inputCloseEnabled = false,
                showLastKeywaitIcon = !isCloseMessage
            };

            return param;
        }

        protected IEnumerator LoadBackGround([Optional] Action<GameObject> OnLoad, bool useAssetUnloader = true)
        {
            AssetManager.AppendAssetBundleRequest(BGPaths[(int)bgType], true, null, null);

            yield return AssetManager.DispatchRequests((eventType, name, asset) =>
            {
                if (eventType == RequestEventType.Activated)
                    BG = asset;
                else if (eventType == RequestEventType.Complete)
                    FieldManager.abUnloader.AddPath(BGPaths[(int)bgType], Utils.AssetUnloader.ID_DEMO, useAssetUnloader);
            });

            var go = UnityEngine.Object.Instantiate(BG, parent) as GameObject;
            go.transform.localPosition = Vector3.zero;
            if (is2DBG)
                go.transform.localEulerAngles = new Vector3(-cameraController.cam.transform.localEulerAngles.x, 0.0f, 0.0f);

            OnLoad?.Invoke(go);
        }

        public IEnumerator LoadPokeAsset(PokemonParam param, bool isHideRare = false, bool isBattleModel = false, bool useAssetUnloader = true)
        {
            yield return LoadPokeAsset(param.GetMonsNo(), param.GetFormNo(), param.GetSex(), param.IsRare() && !isHideRare, param.IsEgg(EggCheckType.BOTH_EGG), isBattleModel, useAssetUnloader);
        }

        public IEnumerator LoadPokeAsset(MonsNo monsNo, ushort formNo, Sex sex, bool isRare, bool isEgg = false, bool isBattleModel = false, bool useAssetUnloader = true)
        {
            var catalog = DataManager.GetPokemonCatalog(monsNo, formNo, sex, isRare, isEgg);
            string pokeBundleName = isEgg ? "objects/" + catalog.AssetBundleName : GetPokemonAssetBundle(monsNo, formNo, sex, isRare, isBattleModel);

            if (!PokeAssets.ContainsKey(catalog.UniqueID))
            {
                PokeAssets.Add(catalog.UniqueID, null);

                AssetManager.AppendAssetBundleRequest(pokeBundleName, true, null, null);
                yield return AssetManager.DispatchRequests((eventType, name, asset) =>
                {
                    if (eventType == RequestEventType.Complete)
                        FieldManager.abUnloader.AddPath(pokeBundleName, Utils.AssetUnloader.ID_DEMO, useAssetUnloader);

                    if (eventType == RequestEventType.Activated)
                    {
                        if (asset.name == catalog.AssetBundleName)
                        {
                            PokeAssets[catalog.UniqueID] = asset;
                            PokeAsset = asset;
                        }
                    }
                });
            }
        }

        public Color ClearColor { get => new Color(FadeColor.r, FadeColor.g, FadeColor.b, 0.0f); }

        public void FadeSetting(bool fade1, bool fade2, bool fade3, bool fade4)
        {
            UseStartEnterFade = fade1;
            UseStartExitFade = fade2;
            UseEndEnterFade = fade3;
            UseEndExitFade = fade4;
        }

        public void SetFadeTime(float t1, float t2, float t3, float t4)
        {
            StartEnterFadeDuration = t1;
            StartExitFadeDuration = t2;
            EndEnterFadeDuration = t3;
            EndExitFadeDuration = t4;
        }

        public Tweener RenderImageFade(float alpha, float duration)
        {
            return manager.RenderImage.DOFade(alpha, duration);
        }

        public Tweener RenderImageScale(float scale, float duration)
        {
            return manager.RenderImage.rectTransform.DOScale(scale, duration);
        }

        protected enum BGType : int
        {
            PoffinEat = 0,
            HakaseRed = 1,
            HakaseBlue = 2,
            Evolve = 3,
            Gosanke = 4,
        }
    }
}
