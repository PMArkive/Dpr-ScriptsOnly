using UnityEngine;
using Dpr.Movie;
using UnityEngine.Events;
using UnityEngine.UI;
using Dpr.Message;
using SmartPoint.AssetAssistant;
using System.Collections;
using Dpr.UI;
using Dpr.EvScript;
using Dpr.Title;

public class Title : MonoBehaviour
{
    [SerializeField]
    public bool forceEndingPlay;
    [SerializeField]
    public bool forceMovieLangSetting;
    [SerializeField]
    public MessageEnumData.MsgLangId forceMovieLang = MessageEnumData.MsgLangId.JPN;
    [SerializeField]
    public bool forceVersionSetting;
    [SerializeField]
    public bool forceDiamondVersion;
    [SerializeField]
    public bool forceMaleSetting;
    [SerializeField]
    public bool forceMale;
    [SerializeField]
    public bool forceSkinTypeSetting;
    [SerializeField]
    [Range(0.0f, 3.0f)]
    public int forceSkinType;
    public GameObject movieRendereObject;
    public RawImage fadeImage;
    public StaffrollPlayer staffrollPlayer;
    private bool _diaVersion = true;
    private MessageEnumData.MsgLangId _lang = MessageEnumData.MsgLangId.JPN;
    private bool _male = true;
    private int _skinType;
    private MoviePlayer _moviePlayer;
    private TitlePlayer titlePlayer;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        _moviePlayer = GetComponent<MoviePlayer>();
        _moviePlayer.Initialize(movieRendereObject);
        _diaVersion = true;
        _lang = PlayerWork.msgLangID;
        _male = PlayerWork.playerSex;
        _skinType = PlayerWork.playerStatus.body_type;

        if (GameManager.playEnding)
            PlayEndingSequence();
        else
            PlayOpeningSequence();
    }

    private void Uninitialize()
    {
        _moviePlayer.Uninitialize();
    }

    private void PlayOpeningSequence()
    {
        staffrollPlayer.SetActive(false);

        if (titlePlayer == null)
            titlePlayer = gameObject.GetComponent<TitlePlayer>();

        titlePlayer.Initialize(_moviePlayer, _diaVersion, _lang, fadeImage, OnFinishedOpening);
        titlePlayer.Play();
    }

    private void PlayEndingSequence()
    {
        staffrollPlayer.SetActive(true);
        var endingPlayer = gameObject.AddComponent<EndingPlayer>();

        endingPlayer.Initialize(_moviePlayer, _diaVersion, _lang, _male, _skinType, fadeImage, PlayOpeningSequence, staffrollPlayer);
        endingPlayer.Play();
    }

    private void OnFinishedOpening(int type)
    {
        switch (type)
        {
            case 0:
                PlayOpeningSequence();
                break;
            case 1:
                PlayBackUpSequence();
                break;
            default:
                EndTitle();
                break;
        }
    }

    private void EndTitle()
    {
        if (PlayerWork.GetLoadResult() == PlayerWork.LoadResult.CORRUPTED)
            SaveDataErrorDialog();
        else
            Sequencer.Start(PlayNowLoading(false));
    }

    private void PlayBackUpSequence()
    {
        if (!PlayerWork.ExistBackUpData())
        {
            OpenDialog("ss_common_text", "SS_common_text_02", PlayOpeningSequence);
        }
        else
        {
            bool isErrorSaveData = PlayerWork.GetLoadResult() > PlayerWork.LoadResult.NOT_EXIST;
            var unloadLangId = PlayerWork.msgLangID;

            PlayerWork.DataLoad(false, true);
            if (unloadLangId == PlayerWork.msgLangID)
            {
                if (PlayerWork.GetLoadResult() != PlayerWork.LoadResult.CORRUPTED)
                {
                    var ui = UIManager.Instance.CreateUIWindow<BackUpReport>(UIWindowID.BACKUP_START);
                    if (ui == null)
                        return;

                    ui.Open(UIWindow.WINDOWID_FIELD, (isBackupLoad) =>
                    {
                        if (isBackupLoad)
                        {
                            FlagWork.SetSysFlag(EvWork.SYSFLAG_INDEX.SYS_INPUT_OFF, false);
                            FlagWork.SetSysFlag(EvWork.SYSFLAG_INDEX.SYS_FLAG_AUTOSAVE_STOP, false);
                            OpenDialog("ss_common_text", "SS_common_text_01", () => Sequencer.Start(PlayNowLoading(true, false, unloadLangId)));
                        }
                        else
                        {
                            PlayerWork.DataLoad(false, false);
                            PlayOpeningSequence();
                        }
                    });

                    return;
                }
            }

            PlayerWork.DataLoad(false, false);
            OpenDialog("ss_common_text", "SS_common_text_02", PlayOpeningSequence);
        }
    }

    private void OpenDialog(string file, string label, UnityAction closeCallback)
    {
        var window = UIManager.Instance.CreateUIWindow<DialogWindow>(UIWindowID.DIALOG);
        if (window != null)
        {
            window.onClosed = (res) => closeCallback?.Invoke();
            window.Open((text) => text.text = MessageManager.Instance.GetMsgFile(file).GetNameStr(label));
        }
    }

    private void SaveDataErrorDialog()
    {
        var window = UIManager.Instance.CreateUIWindow<FatalErrorDialogWindow>(UIWindowID.FATAL_ERROR_DIALOG);
        if (window != null)
            window.Open((text) => text.text = MessageManager.Instance.GetMsgFile("ss_common_text").GetNameStr("SS_common_text_04"));
    }

    private IEnumerator PlayNowLoading(bool useBackupData, bool isErrorSaveData = false, MessageEnumData.MsgLangId unloadLangId = 0)
    {
        UIManager.Instance.NowLoadingOpen(0.0f);
        while (AssetPreloader.IsLoading)
            yield return null;

        bool isLoadWindows = false;
        GameManager.ReloadLanguege(unloadLangId, (isReload) =>
        {
            if (isReload)
            {
                GameManager.AfterInitialize(GameManager.AfterInitType.BackupLoad, unloadLangId, (state) =>
                {
                    if (state == GameManager.AfterLoadState.Ui)
                        isLoadWindows = true;
                });
            }
            else
            {
                isLoadWindows = true;
            }
        });

        while (!isLoadWindows)
            yield return null;

        _moviePlayer.Uninitialize();
        PlayerWork.transitionZoneID = PlayerWork.zoneID;
        GameManager.afterStarting = true;
    }
}