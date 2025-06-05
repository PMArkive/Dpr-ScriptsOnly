using Dpr.MsgWindow;
using Dpr.SubContents;
using Dpr.UI;
using Pml;
using Pml.PokePara;
using SmartPoint.AssetAssistant;
using SmartPoint.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.Demo
{
    public class DemoSceneManager : MonoBehaviour
    {
        public bool isAutoDestroy = true;
        public static bool isExist;
        public List<DemoBase> DemoStock = new List<DemoBase>();
        public EnvironmentController MyEnvironmentController;
        public EnvironmentController PrevEnviroment;
        public GameObject DemoSceneAsset;
        public GameObject PrevDemoSceneAsset;
        public Canvas UICanvas;
        public RawImage RenderImage;
        public Image Fade;
        private int PrevScreenWidth;
        private DemoBase Demo;
        [SerializeField]
        private DEBUG_DEMO _debug_demo;
        public List<GameObject> DebugAsset;
        [Button("PlayDebug", "Play", new object[0] { })]
        public int Button01;
        [Button("Pofin", "Pofin", new object[0] { })]
        public int Button03;
        public int TestNo;
        [Button("_Test", "_Test", new object[0] { })]
        public int Button05;

        private void Awake()
        {
            isExist = true;
            PrevScreenWidth = Screen.width;
        }

        private void OnDestroy()
        {
            isExist = false;
            RenderImage = null;
            UICanvas = null;
            PrevDemoSceneAsset = null;
            DemoSceneAsset = null;
            PrevEnviroment = null;
            MyEnvironmentController = null;
            DemoStock.Clear();
            DemoStock = null;
            Fade = null;
            Demo?.Destroy();
            Demo = null;
        }

        private void MyUpdate(float deltaTime)
        {
            Demo?.LightUpdate();
        }

        public IEnumerator OpLoadAndPlay(DemoBase demo, bool useAssetUnloader = true)
        {
            yield return OpLoad(demo, useAssetUnloader);

            yield return Play();
        }

        public IEnumerator OpPlay()
        {
            yield return Play();
        }

        public IEnumerator OpLoad(DemoBase demo, bool useAssetUnloader = true)
        {
            demo.manager = this;

            yield return AssetBundleLoad(demo.AssetBundlePath, (eventType, name, asset) =>
            {
                if (eventType == RequestEventType.Complete)
                {
                    FieldManager.abUnloader.AddPath(demo.AssetBundlePath, Utils.AssetUnloader.ID_DEMO, useAssetUnloader);
                    return;
                }

                if (eventType != RequestEventType.Activated)
                    return;

                if (DemoSceneAsset != null)
                    PrevDemoSceneAsset = DemoSceneAsset;

                DemoSceneAsset = Instantiate(asset, transform) as GameObject;
            });

            ManagerInit(demo);
            demo.Init();
        }

        private void ManagerInit(DemoBase demo)
        {
            Demo = demo;
            UICanvas = DemoSceneAsset.transform.Find("Preset/Canvas").GetComponent<Canvas>();
            UICanvas.sortingOrder = demo.AddSortOrder + 101;

            UICanvas = DemoSceneAsset.transform.Find("Preset/FadeCanvas").GetComponent<Canvas>();
            UICanvas.sortingOrder = 120;

            Fade = DemoSceneAsset.transform.Find("Preset/FadeCanvas/Fade").GetComponent<Image>();
            Fade.color = new Color(demo.FadeColor.r, demo.FadeColor.g, demo.FadeColor.b, demo.FadeColor.a);

            MyEnvironmentController = DemoSceneAsset.transform.Find("Preset/EnvironmentController").GetComponent<EnvironmentController>();

            var cameraController = DemoSceneAsset.transform.Find("Preset/DemoCamera").GetComponent<DemoCamera>();
            cameraController.enabled = false;

            demo.parent = DemoSceneAsset.transform;
            demo.cameraController = cameraController;

            if (demo.isDisablePostProcess)
                demo.cameraController.postProcessFilter.enabled = false;
        }

        public static IEnumerator AssetBundleLoad(string path, RequestEventCallback callback)
        {
            AssetManager.AppendAssetBundleRequest(path, true, null, null);
            yield return AssetManager.DispatchRequests(callback);
        }

        private Coroutine Play()
        {
            return Sequencer.Start(PlayCor());
        }

        private IEnumerator PlayCor()
        {
            yield return SceneStart();
            yield return Demo.Main();
            yield return SceneEnd();
        }

        private IEnumerator SceneStart()
        {
            PlayerWork.isPlayerInputActive = false;
            if (Demo.UseStartEnterFade)
            {
                SetFadeEnter(Demo.StartEnterFadeDuration);

                while (Fader.isBusy)
                    yield return null;
            }

            CommonInit();
            if (PrevDemoSceneAsset != null)
                Destroy(PrevDemoSceneAsset);

            while (!UIManager.isInitialized)
                yield return null;

            while (!MsgWindowManager.isInstantiated)
                yield return null;

            yield return Demo.Enter();

            if (Demo.DisableEnvironmentController)
            {
                GameManager.connector.ResetLight(true);
                if (EnvironmentController.global != null)
                {
                    EnvironmentController.global.gameObject.SetActive(false);
                    PrevEnviroment = EnvironmentController.global;
                }

                MyEnvironmentController.SetActive(true);
                MyEnvironmentController.cloudShadowEnable = false;

                GameManager.connector.IsEnableUpdate = false;
                Sequencer.update += MyUpdate;
            }

            FieldManager.Instance?.SetCloudShadowBaseDisable();
            if (Demo.isDisableMainCamera)
            {
                GameManager.fieldCamera.SetActive(false);
                yield return null;
            }

            if (Demo.cameraController.postProcessFilter.enabled)
                Demo.cameraController.postProcessFilter.Reset();

            Demo.PostProcessSetting();

            if (Demo.UseCamera)
            {
                Demo.cameraController.cam.enabled = true;
                RenderImage.enabled = true;
            }

            if (Demo.UseStartExitFade)
            {
                SetFadeExit(Demo.StartExitFadeDuration);

                while (Fader.isBusy)
                    yield return null;
            }
        }

        private IEnumerator SceneEnd()
        {
            if (Demo.UseEndEnterFade)
            {
                SetFadeEnter(Demo.EndEnterFadeDuration);

                while (Fader.isBusy)
                    yield return null;
            }

            MyEnvironmentController.SetActive(false);

            if (PrevEnviroment != null)
            {
                EnvironmentController.global = PrevEnviroment;
                EnvironmentController.global.gameObject.SetActive(true);
            }

            Demo.cameraController.cam.enabled = false;

            yield return Demo.Exit();

            if (Demo.isDisableMainCamera)
                GameManager.fieldCamera.SetActive(true);

            GameManager.connector.IsEnableUpdate = true;

            Sequencer.update -= MyUpdate;

            FieldManager.Instance.SetCloudShadowBaseEnable();

            if (Demo.UseCamera)
            {
                (RenderImage.mainTexture as RenderTexture).Release();
                RenderImage.enabled = false;
            }

            if (DemoStock.Count != 0)
            {
                var nextDemo = DemoStock[0];
                DemoStock.RemoveAt(0);
                yield return OpLoadAndPlay(nextDemo, true);
                yield break;
            }

            if (Demo.OnPreEndDemo != null)
                yield return Demo.OnPreEndDemo;

            if (Demo.UseEndExitFade)
                SetFadeExit(Demo.EndExitFadeDuration);

            if (isAutoDestroy)
            {
                Destroy(gameObject);
                FieldManager.abUnloader.Unload(Utils.AssetUnloader.ID_DEMO);
            }

            Demo.OnEndDemo?.Invoke();
        }

        private void CommonInit()
        {
            gameObject.SetLayerRecursively(Layer.UIModelLayer);
            if (Demo.UseCamera)
            {
                var rendertex = Demo.cameraController.CreateRenderTex(Demo.isUseAlpha, true);
                var obj = new GameObject("RenderTex");
                obj.transform.SetParent(UICanvas.transform);

                RenderImage = obj.AddComponent<RawImage>();
                RenderImage.rectTransform.anchoredPosition = Vector3.zero;
                RenderImage.rectTransform.sizeDelta = new Vector2(1280.0f, 720.0f);
                RenderImage.rectTransform.localScale = Vector3.one;
                RenderImage.texture = rendertex;
                RenderImage.rectTransform.SetSiblingIndex(0);
                RenderImage.enabled = false;
            }

            AddLightLayer("Character");
        }

        public void SetFadeEnter(float duration)
        {
            Fader.valid = true;
            Fader.fadeMode = Fader.FadeMode.Color;
            Fader.fillColor = new Color(Demo.FadeColor.r, Demo.FadeColor.g, Demo.FadeColor.b, 1.0f);
            Fader.FadeOut(duration);
        }

        public void SetFadeExit(float duration)
        {
            Fader.fadeMode = Fader.FadeMode.Color;
            Fader.fillColor = new Color(Demo.FadeColor.r, Demo.FadeColor.g, Demo.FadeColor.b, 1.0f);
            Fader.FadeIn(duration);
        }

        public WaitForSeconds FadeEnter(float duration)
        {
            SetFadeEnter(duration);
            return new WaitForSeconds(duration);
        }

        public WaitForSeconds FadeExit(float duration)
        {
            SetFadeExit(duration);
            return new WaitForSeconds(duration);
        }

        public void AddLightLayer(string layerName)
        {
            var light = MyEnvironmentController.GetComponent<Light>();
            light.cullingMask |= (1 << LayerMask.NameToLayer(layerName));
        }

        public void PlayDebug()
        {
            switch (_debug_demo)
            {
                case DEBUG_DEMO.Eat_Poffin:
                    Demo = new Demo_PoffinEat();
                    break;

                case DEBUG_DEMO.Evolve:
                    Demo = new Demo_Evolve();
                    break;

                case DEBUG_DEMO.Hatch:
                    Demo = new Demo_Hatch(new PokemonParam(MonsNo.PIKATYUU, 1, 0));
                    break;

                case DEBUG_DEMO.Hakase:
                    Demo = new Demo_Hakase();
                    break;

                case DEBUG_DEMO.Gosanke:
                    Demo = new Demo_Gosanke();
                    break;

                case DEBUG_DEMO.Trade:
                    Demo = new Demo_Trade();
                    break;

                case DEBUG_DEMO.PokeViewer:
                    Demo = new Demo_PokeViewer((MonsNo)Random.Range(1, (int)MonsNo.MAX), 0, Sex.NUM);
                    break;
            }

            Sequencer.Start(OpLoadAndPlay(Demo, true));
        }

        public void Pofin()
        {
            (Demo as Demo_PoffinEat).PofinThrow();
        }

        public void _Test()
        {
            Demo._DebugMethod(TestNo);
        }

        public enum DEBUG_DEMO : int
        {
            _None = 0,
            Eat_Poffin = 1,
            Evolve = 2,
            Hatch = 3,
            Hakase = 4,
            Gosanke = 5,
            Trade = 6,
            MysteryGift = 7,
            HallOfFame = 8,
            PokeViewer = 9,
            ModelViewer = 10,
            TeleScope = 11,
        }
    }
}