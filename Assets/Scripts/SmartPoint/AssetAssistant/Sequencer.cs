using SmartPoint.AssetAssistant.Forms;
using SmartPoint.EditorAssetAssistant;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;

namespace SmartPoint.AssetAssistant
{
    public sealed class Sequencer : SingletonMonoBehaviour<Sequencer>
    {
        public const int StringBuilderCapaity = 1024;
        private static IUnityEditorProxy _editorProxy = null;
        private static List<(int, TickCallback)> _orderableList = new List<(int, TickCallback)>();
        private static Dictionary<Coroutine, Coroutine> _subToOwner = new Dictionary<Coroutine, Coroutine>();
        private static Dictionary<Coroutine, Coroutine> _ownerToSub = new Dictionary<Coroutine, Coroutine>();
        private static Coroutine _referenceCoroutine = null;
        private static List<UnityEngine.Object> _trashObjects = new List<UnityEngine.Object>();
        private static List<LogMessage> _messageList = new List<LogMessage>(0x100);
        private static Queue<string> _messageQueue = null;
        private static WebhookTarget _webhookTarget = WebhookTarget.None;
        private static bool _onetimeSkipFlag = true;

        public static StringBuilder stringBuilder { get; } = new StringBuilder(StringBuilderCapaity);
        public static float elapsedTime { get; private set; } = 0.0f;

        public static EventCallback start;
        public static EventCallback onDestroy;
        public static EventCallback onFinalize;
        public static EventCallback applicationQuit;
        public static TickCallback earlyUpdate;
        public static TickCallback update;
        public static TickCallback afterUpdate;
        public static TickCallback earlyLateUpdate;
        public static TickCallback lateUpdate;
        public static TickCallback postLateUpdate;
        public static TickCallback onEndOfFrame;

        public static int nativeScreenWidth { get; private set; }
        public static int nativeScreenHeight { get; private set; }
        public static float nativeAspectRatio { get; private set; }
        public static int screenWidth { get; private set; }
        public static int screenHeight { get; private set; }
        public static float aspectRatio { get; private set; }
        public static bool isSuspendUpdate { get; set; }

        private static WaitForEndOfFrame waitForEndOfFrame = null;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Initialize()
        {
            waitForEndOfFrame = new WaitForEndOfFrame();
            Instantiate(null, null);
        }

        public static IUnityEditorProxy editorProxy
        {
            get
            {
#if NON_DECOMP // [NON-DECOMP] Since we don't have access to the proper UnityEditorProxy, we use a dummy class.
                if (_editorProxy == null)
                {
                    if (!Application.isEditor)
                        return null;

                    _editorProxy = new UnityEditorProxy();
                }
#else
                if (_editorProxy == null)
                {
                    if (!Application.isEditor)
                        return null;

                    // Not sure if this is the correct property here
                    string location = Type.GetTypeFromHandle(typeof(IUnityEditorProxy).TypeHandle).Assembly.Location;
                    Assembly assembly;
                    if (location.Contains("AssetAssistant.dll"))
                    {
                        assembly = Assembly.LoadFile("Library/ScriptAssemblies/Assembly-CSharp-Editor.dll");
                    }
                    else
                    {
                        var uri = new Uri(Directory.GetCurrentDirectory() + "/");
                        var editorUri = new Uri(location.Replace("AssetAssistant.dll", "EditorAssetAssistant.dll"));
                        assembly = Assembly.LoadFile(uri.MakeRelativeUri(editorUri).ToString());
                    }

                    if (assembly == null)
                        return null;

                    _editorProxy = (IUnityEditorProxy)assembly.GetType("SmartPoint.EditorAssetAssistant.UnityEditorProxy").GetMethod("GetInstance").Invoke(null, null);
                }
#endif
                return _editorProxy;
            }
        }

        protected override bool Awake()
        {
            if (!base.Awake())
                return false;

            for (int i=0; i<256; i++)
                _messageList.Add(new LogMessage(i));

            if (!string.IsNullOrEmpty(StartupSettings.webhookURL))
            {
                if (!Application.isEditor || StartupSettings.webhookInEditMode)
                {
                    if (StartupSettings.webhookURL.IndexOf("Discord", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        _webhookTarget = WebhookTarget.Discord;
                    }

                    if (StartupSettings.webhookURL.Contains("Slack"))
                    {
                        _webhookTarget = WebhookTarget.Slack;
                    }

                    if (_webhookTarget != WebhookTarget.None)
                    {
                        Start(LogSender(StartupSettings.webhookURL));
                    }
                }
            }

            Application.targetFrameRate = 30;
            Application.logMessageReceivedThreaded += LogReceiver;

            Debug.Log("Starting " + Application.productName);

            nativeScreenWidth = Screen.width;
            nativeScreenHeight = Screen.height;
            nativeAspectRatio = (float)Screen.width / (float)Screen.height;

            start?.Invoke();
            start = null;

            MessageBox.SetManifest(StartupSettings.messageBoxManifest);

            foreach (var initMethod in StartupSettings.initializeMethods)
            {
                initMethod.GetMethodInfo()?.Invoke(null, null);
            }

            int width = Screen.width;
            int height = Screen.height;
            aspectRatio = (float)width / (float)height;

            if (Application.platform != RuntimePlatform.WindowsPlayer)
            {
                if (StartupSettings.minimumResolution != 0)
                {
                    if (width > height)
                    {
                        width = (int)(aspectRatio * StartupSettings.minimumResolution);
                        height = StartupSettings.minimumResolution;
                    }
                    else
                    {
                        width = StartupSettings.minimumResolution;
                        height = (int)(StartupSettings.minimumResolution / aspectRatio);
                    }
                }
            }

            Debug.Log(string.Format("Screen Resolusion ({0}x{1})", width, height));

            _onetimeSkipFlag = true;

            screenWidth = width;
            screenHeight = height;

            DontDestroyOnLoad(gameObject);

            StartCoroutine(AfterUpdate());

            return true;
        }

        public static void SubscribeUpdate(int order, TickCallback callback)
        {
            UnsubscribeUpdate(callback);

            var index = _orderableList.FindIndex(x => order < x.Item1);

            if (index == -1)
                _orderableList.Add((order, callback));
            else
                _orderableList.Insert(index, (order, callback));
        }

        public static void UnsubscribeUpdate(TickCallback callback)
        {
            var index = _orderableList.FindIndex(x => x.Item2 == callback);

            if (index != -1)
            {
                _orderableList.RemoveAt(index);
            }
        }

        public static void Trash(UnityEngine.Object trashObject)
        {
            _trashObjects.Add(trashObject);
        }

        public static Coroutine Start(IEnumerator routine)
        {
            if (Instance == null)
            {
                Debug.LogError("Error: Sequencer is null");
                return null;
            }
            var coroutine = Instance.StartCoroutine(RunCoroutine(routine));
            if (_referenceCoroutine != null)
            {
                _ownerToSub.Add(coroutine, _referenceCoroutine);
                _subToOwner.Add(_referenceCoroutine, coroutine);
            }
            return coroutine;
        }

        private static IEnumerator RunCoroutine(IEnumerator routine)
        {
            var coroutine = Instance.StartCoroutine(routine);
            _referenceCoroutine = coroutine;
            yield return coroutine;

            if (coroutine != null)
            {
                if (_subToOwner.TryGetValue(coroutine, out Coroutine ownerCoroutine))
                {
                    _ownerToSub.Remove(ownerCoroutine);
                }

                _subToOwner.Remove(coroutine);
            }
        }

        public static void Stop(Coroutine coroutine)
        {
            if (coroutine != null && Instance != null)
            {
                Instance.StopCoroutine(coroutine);

                if (_ownerToSub.TryGetValue(coroutine, out Coroutine subCoroutine))
                {
                    Stop(subCoroutine);
                    _subToOwner.Remove(subCoroutine);
                }

                _ownerToSub.Remove(coroutine);
            }
        }

        public static bool IsFinished(Coroutine coroutine)
        {
            if (coroutine != null && Instance != null)
            {
                return !_ownerToSub.ContainsKey(coroutine);
            }

            return true;
        }

        private void Update()
        {
            float deltaTime = Time.deltaTime;
            elapsedTime = deltaTime;

            foreach (var item in _orderableList)
            {
                item.Item2?.Invoke(deltaTime);
            }

            if (!isSuspendUpdate)
            {
                for (int i=0; i<_trashObjects.Count; i++)
                {
                    var obj = _trashObjects[i];
                    DestroyImmediate(obj);
                    _trashObjects[i] = null;
                }
                _trashObjects.Clear();
            }

            start?.Invoke();
            start = null;

            earlyUpdate?.Invoke(elapsedTime);
            update?.Invoke(elapsedTime);
        }

        private IEnumerator AfterUpdate()
        {
            while (!isQuit)
            {
                while (isSuspendUpdate)
                {
                    yield return null;
                }

                afterUpdate?.Invoke(Time.deltaTime);
                yield return waitForEndOfFrame;
                onEndOfFrame?.Invoke(Time.deltaTime);

                yield return null;
            }
        }

        private void LateUpdate()
        {
            if (_onetimeSkipFlag)
            {
                _onetimeSkipFlag = false;
                return;
            }

            if (isSuspendUpdate)
                return;

            int newWidth = Screen.width;
            int newHeight = Screen.height;

            if (newWidth != screenWidth || newHeight != screenHeight)
            {
                Debug.Log(string.Format("Change Resolusion ({0}x{1}) -> ({2}x{3})", screenWidth, screenHeight, newWidth, newHeight));

                screenWidth = newWidth;
                screenHeight = newHeight;
                aspectRatio = (float)newWidth / newHeight;

                // Assuming GameObjects implement IViewportChangeHandler
                var gameObjects = FindObjectsOfType<GameObject>();
                foreach (var go in gameObjects)
                {
                    if (ExecuteEvents.CanHandleEvent<IViewportChangeHandler>(go))
                    {
                        ExecuteEvents.Execute<IViewportChangeHandler>(go, null, (x, y) => x.OnViewportChange(screenWidth, screenHeight));
                    }
                }
            }

            float deltaTime = Time.deltaTime;

            earlyLateUpdate?.Invoke(deltaTime);
            lateUpdate?.Invoke(deltaTime);
            postLateUpdate?.Invoke(deltaTime);
        }

        private void OnDestroy()
        {
            onDestroy?.Invoke();

            onFinalize?.Invoke();

            if (isQuit)
                return;

            earlyUpdate = null;
            update = null;
            afterUpdate = null;
            earlyLateUpdate = null;
            lateUpdate = null;
            postLateUpdate = null;
            onDestroy = null;

            Resources.UnloadUnusedAssets();
        }

        protected override void OnApplicationQuit()
        {
            base.OnApplicationQuit();

            applicationQuit?.Invoke();
            applicationQuit = null;
        }

        public static Component AddComponent(Type componentType)
        {
            if (Instance == null)
                return null;

            return _instance.gameObject.AddComponent(componentType);
        }

        public static T AddComponent<T>() where T : Component
        {
            if (Instance == null)
                return null;

            return (T)AddComponent(typeof(T));
        }

        public static void RemoveComponent(Type componentType)
        {
            if (Instance == null)
                return;

            var component = _instance.gameObject.GetComponent(componentType);
            if (component != null)
                DestroyImmediate(component);
        }

        public static void RemoveComponent<T>() where T : Component
        {
            if (Instance == null)
                return;

            RemoveComponent(typeof(T));
        }

        private static void LogReceiver(string condition, string stackTrace, LogType type)
        {
            var messageList = Sequencer._messageList;
            var nextId = LogMessage.nextID;

            messageList[nextId].AdvanceAndSet(condition, stackTrace, type);

            var messageQueue = Sequencer._messageQueue;
            if (messageQueue != null)
            {
                if (type == LogType.Warning || type == LogType.Log)
                    messageQueue.Enqueue(condition);
                else
                    messageQueue.Enqueue($"{condition}\n{stackTrace}");
            }
        }

        public static LogMessage GetLastLog()
        {
            if (LogMessage.lastID != 0)
                return _messageList[LogMessage.lastID];

            return null;
        }

        public static LogMessage[] GetLogs(int startID)
        {
            int lastID = LogMessage.lastID;
            if (lastID < startID)
                return new LogMessage[0];
            else
                return _messageList.GetRange(startID, lastID - startID + 1).ToArray();
        }

        private string FormatMessage(string message)
        {
            stringBuilder.Length = 0;
            stringBuilder.Append(message);
            stringBuilder.Replace("\n", "\\n");

            switch (_webhookTarget)
            {
                case WebhookTarget.Discord:
                    stringBuilder.Insert(0, "{\"content\":\"");
                    stringBuilder.Append("\"}");
                    break;
                case WebhookTarget.Slack:
                    stringBuilder.Insert(0, "{\"text\":\"");
                    stringBuilder.Append("\"\n,\"username\":\"");
                    stringBuilder.Append(Application.productName);
                    stringBuilder.Append("\"}");
                    break;
            }

            return stringBuilder.ToString();
        }

        private IEnumerator LogSender(string url)
        {
            _messageQueue = new Queue<string>();
            while (true)
            {
                if (isQuit && _messageQueue.Count < 1)
                    yield break;

                if (_messageQueue.Count > 0)
                {
                    while (_messageQueue.Count > 0)
                    {
                        stringBuilder.Length = 0;

                        if (stringBuilder.Length > 0)
                            stringBuilder.AppendLine();

                        if (_webhookTarget == WebhookTarget.Slack)
                            stringBuilder.Append(">");

                        string msg = _messageQueue.Dequeue();
                        stringBuilder.Append(msg);
                    }

                    string message = stringBuilder.ToString();
                    string postData = FormatMessage(message);
                    var request = UnityWebRequest.Post(url, postData);
                    request.SetRequestHeader("Content-Type", "application/json; charset=UTF-8");
                    yield return request.SendWebRequest();

                    if (request.isHttpError)
                        yield return null;

                    request = null;
                }
                
                yield return null;
            }
        }

        public static bool IntersectGUI(Vector3 position)
        {
            List<RaycastResult> intersects = GetIntersectGUIs(position);
            if (intersects == null)
                return false;
            else
                return intersects.Count > 0;
        }

        public static List<RaycastResult> GetIntersectGUIs(Vector3 position)
        {
            EventSystem currentEvent = EventSystem.current;

            if (currentEvent == null)
                return null;

            var pointerEvent = new PointerEventData(currentEvent);
            pointerEvent.position = position;

            List<RaycastResult> result = new List<RaycastResult>();
            currentEvent.RaycastAll(pointerEvent, result);
            return result;
        }

        public enum WebhookTarget : int
        {
            None = 0,
            Discord = 1,
            Slack = 2,
        }

        public delegate void EventCallback();
        public delegate void TickCallback(float deltaTime);
    }
}