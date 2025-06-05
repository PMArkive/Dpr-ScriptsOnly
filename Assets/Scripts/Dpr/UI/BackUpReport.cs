using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Dpr.UI
{
    public class BackUpReport : ReportWindowBase
    {
        [SerializeField]
        private Cursor _cursor;
        [SerializeField]
        private BuckUpReportButton[] _buttons;
        private int _selectIndex;
        private UnityAction<bool> _closeCalback;

        // TODO
        public virtual void Open(UIWindowID prevWindowId, UnityAction<bool> closeCalback) { }

        // TODO
        protected override void Setup() { }

        // TODO
        public override IEnumerator OpOpen(UIWindowID prevWindowId) { return null; }

        // TODO
        protected override void OnUpdate(float deltaTime) { }

        // TODO
        private bool UpdateSelect() { return false; }

        // TODO
        private bool SetSelectIndex(int selectIndex, bool isInitialize = false) { return false; }
    }
}