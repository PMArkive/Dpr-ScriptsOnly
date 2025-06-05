using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SmartPoint.AssetAssistant.Forms
{
    public class MessageBox
    {
        private static MessageBoxManifestBase _manifest;
        private static GameObject _window = null;
        private static Transform _buttonLayout = null;
        private static OnClick _onClick;
        private static Dictionary<GameObject, MessageBoxResult> _buttonMaps = new Dictionary<GameObject, MessageBoxResult>();

        public static void SetManifest(MessageBoxManifestBase manifest)
        {
            _manifest = manifest;
        }

        public static bool Show(string message, string caption, MessageBoxButtons buttons, string[] buttonNames, [Optional] OnClick onClick)
        {
            if (_manifest == null)
            {
                Debug.Log("Manifest not set yet.");
                return false;
            }

            if (_window != null)
                return false;

            _window = GameObject.Instantiate(_manifest.windowPrefab);
            _window.name = "MessageBox";

            _onClick = onClick;

            var texts = _window.GetComponentsInChildren<Text>();
            for (int i=0; i<texts.Length; i++)
            {
                var text = texts[i];

                if (_manifest.captionTextObjectName == text.name)
                    text.text = caption;
                else if (_manifest.messageTextObjectName == text.name)
                    text.text = message;
            }

            var tfs = _window.GetComponentsInChildren<Transform>();
            for (int i=0; i<tfs.Length; i++)
            {
                var tf = tfs[i];
                if (_manifest.buttonLayoutObjectName == tf.name)
                    _buttonLayout = tf;
            }

            CreateButtons(_manifest, buttons, buttonNames);
            Object.DontDestroyOnLoad(_window);

            return true;
        }

        public static void Show(string message, string caption, MessageBoxButtons buttons, [Optional] OnClick onClick)
        {
            Show(message, caption, buttons, null, onClick);
        }

        private static void CreateButtons(MessageBoxManifestBase manifest, MessageBoxButtons buttons, string[] buttonNames)
        {
            var buttonCount = buttonNames?.Length ?? 0;

            switch (buttons)
            {
                case MessageBoxButtons.None:
                    AddTrigger(_window);
                    break;

                case MessageBoxButtons.AbortRetryIgnore:
                    if (buttonCount < 3)
                        buttonNames = new string[3] { "Abort", "Retry", "OK" };

                    CreateButton(manifest, MessageBoxResult.Abort, buttonNames[0], null);
                    CreateButtonSeparator(manifest);
                    CreateButton(manifest, MessageBoxResult.Retry, buttonNames[1], null);
                    CreateButtonSeparator(manifest);
                    CreateButton(manifest, MessageBoxResult.Cancel, buttonNames[2], null);
                    break;

                case MessageBoxButtons.OK:
                    if (buttonCount < 1)
                        buttonNames = new string[1] { "OK" };

                    CreateButton(manifest, MessageBoxResult.OK, buttonNames[0], null);
                    break;

                case MessageBoxButtons.OKCancel:
                    if (buttonCount < 2)
                        buttonNames = new string[2] { "OK", "Cancel" };

                    CreateButton(manifest, MessageBoxResult.OK, buttonNames[0], null);
                    CreateButtonSeparator(manifest);
                    CreateButton(manifest, MessageBoxResult.Cancel, buttonNames[1], null);
                    break;

                case MessageBoxButtons.RetryCancel:
                    if (buttonCount < 2)
                        buttonNames = new string[2] { "Retry", "Cancel" };

                    CreateButton(manifest, MessageBoxResult.Retry, buttonNames[0], null);
                    CreateButtonSeparator(manifest);
                    CreateButton(manifest, MessageBoxResult.Cancel, buttonNames[1], null);
                    break;

                case MessageBoxButtons.YesNo:
                    if (buttonCount < 2)
                        buttonNames = new string[2] { "Yes", "No" };

                    CreateButton(manifest, MessageBoxResult.Yes, buttonNames[0], null);
                    CreateButtonSeparator(manifest);
                    CreateButton(manifest, MessageBoxResult.No, buttonNames[1], null);
                    break;

                case MessageBoxButtons.YesNoCancel:
                    if (buttonCount < 3)
                        buttonNames = new string[3] { "Yes", "No", "Cancel" };
                    
                    CreateButton(manifest, MessageBoxResult.Yes, buttonNames[0], null);
                    CreateButtonSeparator(manifest);
                    CreateButton(manifest, MessageBoxResult.No, buttonNames[1], null);
                    CreateButtonSeparator(manifest);
                    CreateButton(manifest, MessageBoxResult.Cancel, buttonNames[2], null);
                    break;
            }
        }

        private static void CreateButtonSeparator(MessageBoxManifestBase manifest)
        {
            if (manifest.buttonSeparatorPrefab != null)
            {
                var sep = GameObject.Instantiate(manifest.buttonSeparatorPrefab, _buttonLayout);
                if (sep != null)
                {
                    sep.name = "Separator";
                    _buttonMaps.Add(sep, MessageBoxResult.None);
                }
            }
        }

        private static void CreateButton(MessageBoxManifestBase manifest, MessageBoxResult result, string name, [Optional] string text)
        {
            var button = GameObject.Instantiate(manifest.buttonPrefab, _buttonLayout);
            if (button == null)
                return;

            var txt = button.GetComponentInChildren<Text>();
            if (txt != null)
                txt.text = text ?? name;

            button.name = name;

            AddTrigger(button);
            _buttonMaps.Add(button, result);
        }

        private static void AddTrigger(GameObject instance)
        {
            var trig = instance.GetComponent<EventTrigger>();
            if (trig == null)
                trig = instance.AddComponent<EventTrigger>();

            var ent = new EventTrigger.Entry();
            ent.eventID = EventTriggerType.PointerClick;
            ent.callback.AddListener(OnPointerClickDelegate);
            trig.triggers.Add(ent);
        }

        public static void OnPointerClickDelegate(BaseEventData baseData)
        {
            _ = baseData as PointerEventData;

            if (baseData.selectedObject == null)
            {
                Hide();
            }
            else if (_buttonMaps.TryGetValue(baseData.selectedObject, out MessageBoxResult res))
            {
                Hide();
                _onClick?.Invoke(res);
            }
        }

        public static void Hide()
        {
            foreach (var key in _buttonMaps.Keys)
            {
                if (key != null)
                    GameObject.DestroyImmediate(key);
            }

            _buttonMaps.Clear();

            if (_window != null)
                GameObject.DestroyImmediate(_window);

            _window = null;
            _buttonLayout = null;
        }

        public delegate void OnClick(MessageBoxResult result);
    }
}