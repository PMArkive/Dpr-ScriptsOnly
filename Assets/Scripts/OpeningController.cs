using Dpr.Demo;
using Dpr.Message;
using Dpr.UI;
using SmartPoint.AssetAssistant;
using SmartPoint.Components;
using System;
using System.Collections;
using UnityEngine;

public class OpeningController : MonoBehaviour
{
    private SelectPlayerVisualItem _selectPlayerVisualItem;
    public Action OnFinishedCallBack;
    private AssetRequestOperation demoRequestOperation;
    private GameObject demoInstance;
    private DemoSceneManager demoSceneManager;
    private Demo_Hakase demoModel = new Demo_Hakase();

    private IEnumerator Start()
    {
        if (PlayerWork.transitionZoneID != ZoneID.UNKNOWN)
            yield break;

        if (EntityManager.activeFieldPlayer != null)
        {
            Destroy(EntityManager.activeFieldPlayer.gameObject);
            EntityManager.activeFieldPlayer = null;
        }

        KinomiWork.SetDefault();
        demoInstance = new GameObject("DemoSceneManager", new Type[1] { typeof(DemoSceneManager) });
        demoSceneManager = demoInstance.GetComponent<DemoSceneManager>();
        demoModel.openingController = this;
        demoRequestOperation = demoModel.PreloadAssetBundles();
        yield return demoRequestOperation;

        while (!UIManager.isInitialized)
            yield return null;

        while (!MessageManager.Instance.IsInitialize)
            yield return null;

        UIManager.Instance.NowLoadingClose();
        Fader.valid = true;
        Fader.FadeIn();
        OpenSelectLanguage();
    }

    private void OnDisable()
    {
        demoModel?.ReleasePreloadedAssetBundles();
    }

    private void OpenSelectLanguage()
    {
        var selectLanguage = UIManager.Instance.CreateUIWindow<SelectLanguageWindow>(UIWindowID.SELECT_LANGUAGE);
        selectLanguage.onClosed = (window) => { /* Empty */ };
        selectLanguage.onReloadLanguage = () =>
        {
            var manager = new GameObject("DemoSceneManager").AddComponent<DemoSceneManager>();
            var demo = new Demo_Hakase
            {
                openingController = this,
                StartEnterFadeDuration = 0.0f,
                StartExitFadeDuration = 0.0f
            };
            Sequencer.Start(manager.OpLoadAndPlay(demo, true));
        };

        selectLanguage.Open(UIWindow.WINDOWID_FIELD);
    }

    public void OpenSelectPlayerVisual()
    {
        var selectPlayer = UIManager.Instance.CreateUIWindow<SelectPlayerVisualWindow>(UIWindowID.SELECT_PLAYER);
        selectPlayer.onClosed = (window) =>
        {
            _selectPlayerVisualItem = selectPlayer.selectItem;
            OpenKeyboardByPlayerName();
        };
        selectPlayer.Open(UIWindow.WINDOWID_FIELD);
    }

    private void OpenKeyboardByPlayerName()
    {
        var param = new SoftwareKeyboard.Param
        {
            text = "",
            textMinLength = 1,
            textMaxLength = SoftwareKeyboard.LanguageMaxLength(6),
            headerText = MessageManager.Instance.GetSimpleMessage("dp_scenario1", "7-msg_opening_13"),
            subText = null,
            guideText = null,
            okText = null,
            invalidCharFlag = SoftwareKeyboard.InvalidChar.AtMark
        };

        SoftwareKeyboard.Open(param, OnInputCheck, (isSuccess, resultText) =>
        {
            if (resultText.Length == 0)
            {
                OpenSelectPlayerVisual();
                return;
            }

            PlayerWork.SetPlayerStatus(_selectPlayerVisualItem.sex, _selectPlayerVisualItem.colorId, resultText);
            OnFinished();
        });
    }

    private (bool, string) OnInputCheck(string resultText, SoftwareKeyboard.ErrorState errorState)
    {
        return SoftwareKeyboard.InputCheck(resultText, errorState);
    }

    public void OpenKeyboardByRivalName()
    {
        var param = new SoftwareKeyboard.Param
        {
            text = "",
            textMinLength = 1,
            textMaxLength = SoftwareKeyboard.LanguageMaxLength(6),
            headerText = SoftwareKeyboard.GetMessageText("SS_strinput_042"),
            subText = null,
            guideText = null,
            okText = null,
            invalidCharFlag = SoftwareKeyboard.InvalidChar.AtMark
        };

        SoftwareKeyboard.Open(param, OnInputCheck, (isSuccess, resultText) =>
        {
            PlayerWork.rivalName = resultText;
            OnFinished();
        });
    }

    private void OnFinished()
    {
        OnFinishedCallBack?.Invoke();
    }
}