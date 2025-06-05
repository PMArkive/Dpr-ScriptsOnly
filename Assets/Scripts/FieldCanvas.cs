using DG.Tweening;
using Dpr.Demo;
using Dpr.MsgWindow;
using Dpr.SubContents;
using SmartPoint.AssetAssistant;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class FieldCanvas : MonoBehaviour
{
    private static FieldCanvas _instance;
    public static bool useLateUpdate;

    private const int BALLOON_MAX = 20;

    public Image BalloonImage;
    public Vector3 BalloonOffset;
    private Balloon[] _balloonArray = new Balloon[BALLOON_MAX];
    public GameObject controller;
    public GameObject left;
    public GameObject right;
    [SerializeField]
    private SpriteAtlas BalloonIconsAtlas;
    [SerializeField]
    private Sprite ugHoleSprite;
    private Canvas canvas;
    private AreaNameWindow areaNameWindow;
    private DisplayMessage displayMessage;
    private FieldFader fieldFader;

    [Button("Warp", "Warp", new object[0])]
    public int Button;

    public float BaseFov = 17.5f;
    public float BaseDistance = 30.0f;
    private static DemoSceneManager demoMng;
    public static bool isNPCTrading;
    public static bool isNPCTradeEnd;

    [Button("TestCreateTurearuki", "TestCreateTurearuki", new object[0])]
    public int Button01;
    [Button("TestDeleteTurearuki", "TestDeleteTurearuki", new object[0])]
    public int Button02;
    [Button("Bikkuri", "Bikkuri", new object[0])]
    public int Button05;

    public static Sprite UgHoleSprite { get => _instance.ugHoleSprite; }

    public void Warp()
    {
        FieldManager.fwMng.TurearukiWarp();
    }

    private void Start()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        canvas = GetComponent<Canvas>();

        for (int i=0; i<_balloonArray.Length; i++)
        {
            var balloonTransform = new GameObject("balloon").transform;

            controller = new GameObject("Controller");
            left = new GameObject("HostImgLeft");
            right = new GameObject("HostImgRight");
            balloonTransform.SetParent(BalloonImage.transform.parent, false);
            balloonTransform.SetActive(false);

            var newBalloon = Instantiate(BalloonImage.gameObject, balloonTransform);

            controller.transform.SetParent(balloonTransform);
            left.transform.SetParent(controller.transform);
            right.transform.SetParent(controller.transform);

            _balloonArray[i] = new Balloon();
            _balloonArray[i].isBusy = false;
            _balloonArray[i].Index = i;
            _balloonArray[i].gameObject = newBalloon;
            _balloonArray[i].BlnImg = newBalloon.GetComponent<Image>();
            _balloonArray[i].MarkImg = newBalloon.transform.GetChild(0).GetComponent<Image>();
            _balloonArray[i].Target = null;
            _balloonArray[i].parent = balloonTransform.gameObject;
            _balloonArray[i].ParentRectTra = balloonTransform.gameObject.AddComponent<RectTransform>();
            _balloonArray[i].MyRectTra = newBalloon.transform.GetComponent<RectTransform>();
            _balloonArray[i].MyRectTra.anchoredPosition = Vector3.zero;
            _balloonArray[i].ParentRectTra.anchorMin = new Vector2(0.5f, 0.0f);
            _balloonArray[i].ParentRectTra.anchorMax = new Vector2(0.5f, 0.0f);
            _balloonArray[i].ParentRectTra.pivot = new Vector2(0.5f, 0.0f);

            left.AddComponent<Image>().enabled = false;
            right.AddComponent<Image>().enabled = false;
            controller.AddComponent<UnionHostEmoticonController>();

            _balloonArray[i].HostImgLeft = left.GetComponent<Image>();
            _balloonArray[i].HostImgLeft = right.GetComponent<Image>();
            _balloonArray[i].ballonAtlas = null;
        }

        BalloonImage.gameObject.SetActive(false);
        areaNameWindow = this.FindDeep("AreaNameWindow").GetComponent<AreaNameWindow>();
        areaNameWindow.Initialize();

        displayMessage = this.FindDeep("DisplayMessage").GetComponent<DisplayMessage>();
        displayMessage.Initialize();
        displayMessage.gameObject.SetActive(false);

        fieldFader = this.FindDeep("FieldFader").GetComponent<FieldFader>();
        fieldFader.SetActive(false);

        Sequencer.update -= MyUpdate;
        Sequencer.update += MyUpdate;
        Sequencer.postLateUpdate -= MyLateUpdate;
        Sequencer.postLateUpdate += MyLateUpdate;
    }

    private void OnDestroy()
    {
        _instance = null;

        for (int i=0; i<_balloonArray.Length; i++)
        {
            if (_balloonArray[i] != null)
            {
                _balloonArray[i].gameObject = null;
                _balloonArray[i].BlnImg = null;
                _balloonArray[i].Target = null;
                _balloonArray[i].ParentRectTra = null;
                _balloonArray[i].parent = null;
                _balloonArray[i] = null;
            }
        }

        Sequencer.update -= MyUpdate;
        Sequencer.postLateUpdate -= MyLateUpdate;

        demoMng = null;
    }

    private void OnEnable()
    {
        Sequencer.update -= MyUpdate;
        Sequencer.postLateUpdate -= MyLateUpdate;

        if (_instance == null)
            return;

        areaNameWindow.OnEnableFieldCanvas();

        Sequencer.update += MyUpdate;
        Sequencer.postLateUpdate += MyLateUpdate;
    }

    private void OnDisable()
    {
        Sequencer.update -= MyUpdate;
        Sequencer.postLateUpdate -= MyLateUpdate;

        areaNameWindow.OnDisableFieldCanvas();
    }

    private void UpdateProc(float deltaTime)
    {
        for (int i=0; i<_balloonArray.Length; i++)
        {
            var balloon = _balloonArray[i];
            if (balloon.gameObject.activeSelf)
            {
                if (balloon.Target != null)
                {
                    UpdateBalloonPos(balloon);

                    if (balloon.ballonAtlas != null)
                        balloon.AddSpriteIndex();
                }
            }
        }

        if (!fieldFader)
            return;

        fieldFader.OnUpdate(deltaTime);
    }

    private void MyUpdate(float deltaTime)
    {
        if (!useLateUpdate)
            UpdateProc(deltaTime);
    }

    private void MyLateUpdate(float deltaTime)
    {
        if (useLateUpdate)
            UpdateProc(deltaTime);
    }

    private void UpdateBalloonPos(Balloon bln)
    {
        Vector3 balloonPos = bln.Target.position + BalloonOffset;
        float camdistance = Vector3.Distance(GameManager.fieldCamera.transform.position, bln.Target.position);
        float minfov = Mathf.Min(BaseDistance / (camdistance + 0.01f), 2.5f);
        float unclampedfov = BaseFov / (GameManager.fieldCamera.Fov + 0.01f) * minfov;
        float finalfov = Mathf.Clamp((unclampedfov - 2.0f) * 0.5f, 0.0f, 0.3f);
        Vector3 worldpos = balloonPos + (Vector3.down * finalfov);

        bln.BlnImg.rectTransform.localScale = Vector3.one * unclampedfov;
        bln.ParentRectTra.position = RectTransformUtility.WorldToScreenPoint(GameManager.fieldCamera.GetCamera(), worldpos);
    }

    public static Balloon SetBalloon(int type, Transform target)
    {
        if (_instance == null)
            return null;

        return _instance._setBalloon(type, target);
    }

    public static void DeleteBalloon([Optional] Balloon balloon, bool isDirect = false)
    {
        if (_instance == null)
            return;

        _instance._deleteBalloon(balloon, isDirect);
    }

    public static void ShowHostIcon(Balloon balloon)
    {
        if (_instance == null)
            return;

        balloon?.SetHostImgIcon(_instance.BalloonIconsAtlas);
    }

    public static void StopHostEmoticon(Balloon balloon)
    {
        if (_instance == null)
            return;

        balloon?.StopHostEmoAnimation();
    }

    private Balloon _setBalloon(int type, Transform target)
    {
        for (int i=0; i<_balloonArray.Length; i++)
        {
            var bln = _balloonArray[i];
            if (!bln.isBusy)
            {
                bln.isBusy = true;
                bln.Target = target;
                bln.Time = 0.0f;
                UpdateBalloonPos(bln);
                bln.parent.SetActive(true);
                bln.PlayAnimation(type, BalloonIconsAtlas);
                return bln;
            }
        }

        return null;
    }

    private void _deleteBalloon([Optional] Balloon balloon, bool isDirect = false)
    {
        void ClearBalloon(Balloon balloon_)
        {
            balloon_.Target = null;
            balloon_.parent.SetActive(false);
            balloon_.Time = 0.0f;
            balloon_.MyRectTra.anchoredPosition = Vector3.zero;
            balloon_.StopHostEmoAnimation();
        }

        if (balloon != null)
        {
            var bln = _balloonArray[balloon.Index];
            if (isDirect)
                ClearBalloon(bln);
            else
                bln.Fade(0.0f, 0.1f).OnComplete(() => ClearBalloon(bln));
        }
        else
        {
            for (int i=0; i<_balloonArray.Length; i++)
                ClearBalloon(_balloonArray[i]);
        }
    }

    private void _showHostIcon(Balloon balloon)
    {
        balloon?.SetHostImgIcon(BalloonIconsAtlas);
    }

    private void _backEmotiocnNormal(Balloon balloon)
    {
        balloon?.StopHostEmoAnimation();
    }

    public static void OpenAreaNameWindow(string labelName)
    {
        if (MsgWindowManager.Instance != null && !MsgWindowManager.Instance.gameObject.activeInHierarchy)
            return;

        if (_instance == null)
            return;

        _instance.areaNameWindow.Open(labelName);
    }

    public static void ResetAreaNameWindow()
    {
        if (_instance == null)
            return;

        _instance.areaNameWindow.ResetParam();
    }

    public static void ImmidiateCloseAreaNameWindow()
    {
        if (_instance == null)
            return;

        _instance.areaNameWindow.ImmidiateClose();
    }

    public static void ShowDisplayMessage(string labelName, string msbtName = "", bool bIsUseTag = false)
    {
        _instance.displayMessage.ShowMessage(labelName, msbtName, bIsUseTag);
    }

    public static void CloseDisplayMessage()
    {
        _instance.displayMessage.HideMessage();
    }

    public static void RedGyaradosMessage(bool flag)
    {
        _instance.displayMessage.RedGyaradosMessage(flag);
    }

    public static void Debug_ShowDisplayMessage(string message)
    {
        _instance.displayMessage.ChangeMessage(message);
    }

    public static void PlayDemoOrStock(DemoBase demo)
    {
        if (demoMng != null)
            demoMng.DemoStock.Add(demo);
        else
            PlayDemo(demo);
    }

    public static void PlayDemo(DemoBase demo, bool useAssetUnloader = true)
    {
        demoMng = new GameObject("DemoSceneManager").AddComponent<DemoSceneManager>();
        Sequencer.Start(demoMng.OpLoadAndPlay(demo, useAssetUnloader));
    }

    public static void PlayDemo()
    {
        Sequencer.Start(demoMng.OpPlay());
    }

    public static Coroutine LoadDemo(DemoBase demo, bool useAssetUnloader = true)
    {
        demoMng = new GameObject("DemoSceneManager").AddComponent<DemoSceneManager>();
        return Sequencer.Start(demoMng.OpLoad(demo, useAssetUnloader));
    }

    public static void UgSetUp(bool isUgEnter)
    {
        if (isUgEnter)
        {
            var canvas = _instance.areaNameWindow.AddComponentIfNecessary<Canvas>();
            _instance.areaNameWindow.gameObject.SetActive(true);
            canvas.overrideSorting = true;
            canvas.sortingOrder = 2;
            _instance.areaNameWindow.gameObject.SetActive(false);
            _instance.canvas.sortingOrder = -1;
        }
        else
        {
            if (_instance != null && _instance.areaNameWindow != null)
            {
                var canvas = _instance.areaNameWindow.GetComponent<Canvas>();
                if (canvas != null)
                    Destroy(canvas);

                _instance.canvas.sortingOrder = 0;
            }
        }
    }

    public static void CanvasEnable(bool isEnable)
    {
        if (_instance != null)
            _instance.canvas.enabled = isEnable;
    }

    public void TestCreateTurearuki()
    {
        FieldManager.fwMng.CreateTurearuki();
    }

    public void TestDeleteTurearuki()
    {
        FieldManager.fwMng.DeleteTurearuki();
    }

    public void Bikkuri()
    {
        // Empty
    }

    public static bool IsFieldFadeBusy()
    {
        if (_instance == null)
            return false;

        if (_instance.fieldFader != null)
            return _instance.fieldFader.IsBusy;

        return false;
    }

    public static void FadeOut(FieldFader.FieldFadeType type = FieldFader.FieldFadeType.NONE, float time = 0.5f)
    {
        if (_instance == null)
            return;

        if (_instance.fieldFader == null)
            return;

        _instance.fieldFader.FadeOut(type, time);
    }

    public static void FadeIn(FieldFader.FieldFadeType type = FieldFader.FieldFadeType.NONE, float time = 0.5f)
    {
        if (_instance == null)
            return;

        if (_instance.fieldFader == null)
            return;

        _instance.fieldFader.FadeIn(type, time);
    }
}