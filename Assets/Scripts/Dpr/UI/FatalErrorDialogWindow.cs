using System;
using System.Collections;
using UnityEngine;

namespace Dpr.UI
{
    public class FatalErrorDialogWindow : UIWindow
    {
        [SerializeField]
        private UIText dialogText;

        // TODO
        public override void OnCreate() { }

        // TODO
        public void Open(Action<UIText> setDialogText, UIWindowID prevWindowId = WINDOWID_PARENT) { }

        // TODO
        public IEnumerator OpOpen(UIWindowID prevWindowId) { return null; }
    }
}