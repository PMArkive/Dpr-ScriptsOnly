using SmartPoint.AssetAssistant.Forms;
using SmartPoint.AssetAssistant.UnityExtensions;
using UnityEngine;

namespace SmartPoint.AssetAssistant
{
    public class StartupSettings : SingletonScriptableObject<StartupSettings>
    {
        [SerializeField]
        private string _platformName;
        [SerializeField]
        private bool _useSceneBrowser = true;
        [SerializeField]
        private MessageBoxManifestBase _messageBoxManifest;
        [SerializeField]
        private AssetBundleTarget _assetBundleTarget;
        [SerializeField]
        private string _assetBundleTargetURI;
        [SerializeField]
        private string[] _assetBundlesForEditor;
        [SerializeField]
        private string[] _externalProjectNames;
        [SerializeField]
        private bool _clearCacheFiles;
        [SerializeField]
        private bool _webhookInEditMode;
        [SerializeField]
        private string _webhookURL = string.Empty;
        [SerializeField]
        private int _minimumResolution;
        [SerializeField]
        private PreloadRequest[] _preloadRequests = ArrayHelper.Empty<PreloadRequest>();
        [SerializeField]
        private SerializedMethod _preloadMethod;
        [SerializeField]
        private SerializedMethod[] _initializeMethods = ArrayHelper.Empty<SerializedMethod>();
        [SerializeField]
        private SerializedMethod[] _assetManagerAfterSetupMethods = ArrayHelper.Empty<SerializedMethod>();
        [SerializeField]
        private SerializedMethod[] _sceneRestoreOperationMethods = ArrayHelper.Empty<SerializedMethod>();
        [SerializeField]
        private SerializedMethod[] _sceneBeforeActivateOperationMethods = ArrayHelper.Empty<SerializedMethod>();
        [SerializeField]
        private string _startupScenePath = string.Empty;
        [SerializeField]
        private ReferenceObject[] _permanentObjects = ArrayHelper.Empty<ReferenceObject>();
        [SerializeField]
        private bool _runBootSequence = true;
        [SerializeField]
        private string _creationTime = string.Empty;
        [SerializeField]
        private string _buildVersion = string.Empty;

        public static string platformName { get => instance == null ? string.Empty : instance._platformName; }
        public static MessageBoxManifestBase messageBoxManifest { get => instance == null ? null : instance._messageBoxManifest; }
        public static bool useSceneBrowser { get => instance == null ? true : instance._useSceneBrowser; }
        public static string assetBundleTargetURI { get => instance == null ? string.Empty : instance._assetBundleTargetURI; }
        public static string[] assetBundlesForEditor { get => instance == null ? ArrayHelper.Empty<string>() : instance._assetBundlesForEditor; }
        public static string[] externalProjectNames { get => instance == null ? ArrayHelper.Empty<string>() : instance._externalProjectNames; }
        public static AssetBundleTarget assetBundleTarget { get => instance == null ? AssetBundleTarget.AssetDatabase : instance._assetBundleTarget; }
        public static bool runBootSequence { get => instance == null ? false : instance._runBootSequence; }
        public static int minimumResolution { get => instance == null ? 0 : instance._minimumResolution; }
        public static bool clearCacheFiles { get => instance == null ? false : instance._clearCacheFiles; }
        public static bool webhookInEditMode { get => instance == null ? false : instance._webhookInEditMode; }
        public static string webhookURL { get => instance == null ? string.Empty : instance._webhookURL; }
        public static string startupScenePath { get => instance == null ? string.Empty : instance._startupScenePath; }
        public static PreloadRequest[] preloadRequests { get => instance == null ? null : instance._preloadRequests; }
        public static SerializedMethod preloadMethod { get => instance == null ? new SerializedMethod(null, null, false) : instance._preloadMethod; }
        public static SerializedMethod[] initializeMethods { get => instance == null ? ArrayHelper.Empty<SerializedMethod>() : instance._initializeMethods; }
        public static SerializedMethod[] assetManagerAfterSetupMethods { get => instance == null ? ArrayHelper.Empty<SerializedMethod>() : instance._assetManagerAfterSetupMethods; }
        public static SerializedMethod[] sceneRestoreOperationMethods { get => instance == null ? ArrayHelper.Empty<SerializedMethod>() : instance._sceneRestoreOperationMethods; }
        public static SerializedMethod[] sceneBeforeActivateOperationMethods { get => instance == null ? ArrayHelper.Empty<SerializedMethod>() : instance._sceneBeforeActivateOperationMethods; }
        public static ReferenceObject[] permanentObjects { get => instance == null ? ArrayHelper.Empty<ReferenceObject>() : instance._permanentObjects; }
        public static string buildVersion { get => instance == null ? string.Empty : instance._buildVersion; }
        public static string creationTime { get => instance == null ? "" : instance._creationTime; }
    }
}