using DG.Tweening;
using Dpr.UnderGround;
using Dpr.UnderGround.LightStone;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UgMiniMapComponent : MonoBehaviour
{
    private static UgMiniMapComponent _instance;
    private Transform player;
    private RectTransform otherPlayersParent;
    private Image BackGround;
    private RectTransform Mask;
    private RectTransform Waku;
    private RectTransform ButtonGuide;
    [SerializeField]
    private RectTransform MapParent;
    [SerializeField]
    private RectTransform Target;
    [SerializeField]
    private Image TargetFriend;
    [SerializeField]
    private Vector2 _targetSizeOffset;
    [SerializeField]
    private Image MyKasekiIcon;
    [SerializeField]
    private Image OtherKasekiIcon;
    [SerializeField]
    private Image MySecretBaseIcon;
    [SerializeField]
    private Image OtherSecretBaseIcon;
    [SerializeField]
    private Vector2 Offset;
    private ZoneID _nowZone = ZoneID.UNKNOWN;
    [SerializeField]
    private bool _isPlayerPos;
    private static readonly Vector2 MapMiniSize = new Vector2(132.0f, -100.0f);
    private bool prevMode;

    public bool isOverAllMode { get; set; }
    public bool isLargeMode { get; set; }

    private Image[] _randMarkIcon;
    private Image _nowRandMarkIcon;
    [SerializeField]
    private Image[] _mapIamges;
    private Material[] _mapMaterial;
    private OtherPlayers[] _otherPlayers = new OtherPlayers[8];
    private static readonly Vector2 OverAllOffset = new Vector2(105.0f, 30.0f);
    private Image PanelEffect;
    private uint OpenLandMarkNum;
    private uint CloseLandMarkNum;
    [SerializeField]
    private UgLightStoneGauge ugLightStoneGauge;
    private RectTransform rectTra_ugLightStoneGauge;
    private CanvasGroup canvasGroup;
    private Tweener tw;
    public Vector2 hosei = new Vector2(1.0f, -1.0f);

    // TODO
    private void Awake() { }

    // TODO
    private void Start() { }

    // TODO
    private void OnDestroy() { }

    // TODO
    public static void Init() { }

    // TODO
    private void Initialize() { }

    // TODO
    public void SetVisible(bool isVisible) { }

    // TODO
    private void UpdateGoneInfo() { }

    // TODO
    private void _update(float time) { }

    // TODO
    public void OnChengeOtherPlayerZone(int index, ZoneID zoneID) { }

    // TODO
    public void UpdateOtherPlayersPosition(bool isForceUpdate = false) { }

    // TODO
    public void ToOverAllMap(UgFieldManager.DigData data) { }

    // TODO
    public void ToAroundMap(UgFieldManager.DigData data) { }

    // TODO
    private void ToGrayMapGroup(int mapGroupID) { }

    // TODO
    private void ToWhiteMapGroup(int mapGroupID) { }

    // TODO
    private bool GetMapGroupGoneFlag(int mapGroupID) { return false; }

    // TODO
    public void ToLarger(UgFieldManager.DigData data) { }

    // TODO
    public void ToSmaller(UgFieldManager.DigData data) { }

    // TODO
    public void UpdateDigPoint(UgFieldManager.DigData data) { }

    // TODO
    public void ChangeVisibleDigPoint(UgFieldManager.DigData data, bool isVisible) { }

    // TODO
    public void UpdateSecretBase(List<UgFieldManager.SecretBaseModel> SecretBases) { }

    // TODO
    public void UpdateLandMarkIcons() { }

    // TODO
    private void SavePlayReport(uint landMarkID) { }

    // TODO
    public void UpdatePlayerPositionSettings() { }

    // TODO
    public void OpenLandMark(Image image)
    {
        // TODO
        void posUpdate(float deltaTime) { }
    }

    // TODO
    private IEnumerator WaitFade(Action OnComplete) { return null; }

    // TODO
    public void UpdateZoneID_Offset() { }

    // TODO
    private bool IsNullZoneId(ZoneID zoneId) { return false; }

    // TODO
    private Vector2 GetMapOffset(ZoneID zoneID) { return Vector2.zero; }

    // TODO
    public void InitAreaGrayScale() { }

    // TODO
    private bool CheckLandMarkFlag(string MapName) { return false; }

    // TODO
    public void UpdateLightStoneCount() { }

    // TODO
    public void UpdateBonusState() { }

    private class OtherPlayers
    {
	    public Image image;
        public RectTransform nowLandMarkIcon;
    }
}