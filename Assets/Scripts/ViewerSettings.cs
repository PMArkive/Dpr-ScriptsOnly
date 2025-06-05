using SmartPoint.Components;
using SmartPoint.Rendering;
using System;
using UnityEngine;

[Serializable]
public class ViewerSettings : PlayerPrefsProvider<ViewerSettings>
{
    [SerializeField]
    private float _cameraFov = 45.0f;
    [SerializeField]
    private float _focalLength = 1.0f;
    [SerializeField]
    private float _farDepth = 30.0f;
    [SerializeField]
    private float _blurry = 1.0f;
    [SerializeField]
    private Color _clearColor = new Color(0.1f, 0.1f, 0.2f);
    [SerializeField]
    private bool _autoRotate;
    [SerializeField]
    private bool _effectEnable = true;
    [SerializeField]
    private bool _saveField;
    [SerializeField]
    private bool _appendOpenMode = true;
    [SerializeField]
    private string _fieldAssetBundleName = string.Empty;
    [SerializeField]
    private int _timeZone;
    [SerializeField]
    private bool _hideBoundingBox;
    [SerializeField]
    private bool _autoFit = true;
    [SerializeField]
    private bool _sequentialShooting;
    [SerializeField]
    private bool _avatarTakeover;
    [SerializeField]
    private int _trackColorVariation;
    [SerializeField]
    private bool _trackShadowAdjust;
    [SerializeField]
    private float _sensorScale = 1.0f;
    private Camera _camera;
    private DepthOfField _dof;
    private string _lastSelectionName = string.Empty;

    protected override string key { get => "ViewerSettings"; }
    public static Camera camera
    {
        set
        {
            instance._camera = value;

            var dof = DepthOfField.instance;

            if (value != null)
            {
                value.fieldOfView = instance._cameraFov;
                value.backgroundColor = instance._clearColor;

                if (dof != null)
                {
                    dof.farDepth = instance._farDepth;
                    dof.focalLength = instance._focalLength;
                }
            }

            instance._dof = dof;
        }
    }
    public static float fieldOfView
    {
        get => instance._cameraFov;
        set
        {
            instance._camera.fieldOfView = value;
            instance._cameraFov = value;
        }
    }
    public static Transform cameraTarget { get => instance._dof.target; set => instance._dof.target = value; }
    public static float farDepth
    {
        get => instance._farDepth;
        set
        {
            instance._dof.farDepth = value;
            instance._farDepth = value;
        }
    }
    public static bool sequentialShooting { get => instance._sequentialShooting; set => instance._sequentialShooting = value; }
    public static bool avatarTakeover { get => instance._avatarTakeover; set => instance._avatarTakeover = value; }
    public static int trackColorVariation { get => instance._trackColorVariation; set => instance._trackColorVariation = value; }
    public static bool trackShadowAdjust { get => instance._trackShadowAdjust; set => instance._trackShadowAdjust = value; }
    public static float clearColorR
    {
        get => instance._clearColor.r;
        set
        {
            instance._clearColor.r = value;
            instance._camera.backgroundColor = instance._clearColor;
        }
    }
    public static float clearColorG
    {
        get => instance._clearColor.g;
        set
        {
            instance._clearColor.g = value;
            instance._camera.backgroundColor = instance._clearColor;
        }
    }
    public static float clearColorB
    {
        get => instance._clearColor.b;
        set
        {
            instance._clearColor.b = value;
            instance._camera.backgroundColor = instance._clearColor;
        }
    }
    public static float sensorScale { get => instance._sensorScale; set => instance._sensorScale = value; }
    public static bool autoRotate { get => instance._autoRotate; set => instance._autoRotate = value; }
    public static bool effectEnable { get => instance._effectEnable; set => instance._effectEnable = value; }
    public static bool saveField { get => instance._saveField; set => instance._saveField = value; }
    public static int timeZone { get => instance._timeZone; set => instance._timeZone = value; }
    public static bool appendOpenMode { get => instance._appendOpenMode; set => instance._appendOpenMode = value; }
    public static bool hideBoundingBox { get => instance._hideBoundingBox; set => instance._hideBoundingBox = value; }
    public static bool autoFit { get => instance._autoFit; set => instance._autoFit = value; }
    public static string fieldAssetBundleName { get => instance._fieldAssetBundleName; set => instance._fieldAssetBundleName = value; }
    public static string lastSelectionName { get => instance._lastSelectionName; set => instance._lastSelectionName = value; }
}