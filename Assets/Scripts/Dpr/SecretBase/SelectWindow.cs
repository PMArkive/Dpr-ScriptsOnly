using UnityEngine;

namespace Dpr.SecretBase
{
    public class SelectWindow<T, Data> : ListView<T, Data>
    {
        [SerializeField]
        protected UICursor uiCursor;
        protected float forcusScale = 1.0f;
        [SerializeField]
        protected float forcusTime = 0.1f;
        [SerializeField]
        private bool isScale;
        [SerializeField]
        [Tooltip("ループスクロール時に端で一旦止めるか")]
        protected bool isStopEnd;
        protected int index;

        // TODO
        private void Start() { }

        // TODO
        private void Update() { }

        // TODO
        protected override void Init() { }

        // TODO
        protected void CursorAttach() { }

        // TODO
        public virtual int BindItem(Data data, T item) { return default; }

        // TODO
        public override int AddItem(Data data) { return default; }

        // TODO
        public override void ClearItem() { }

        // TODO
        public virtual bool SelectNext() { return default; }

        // TODO
        public virtual bool SelectPrev() { return default; }

        // TODO
        public void SetCursorActive(bool value) { }

        // TODO
        public void SetIndex(int index) { }

        // TODO
        public int GetIndex() { return default; }

        // TODO
        public Data GetData() { return default; }

        // TODO
        public T GetIcon(int index) { return default; }

        // TODO
        public int GetItemCount() { return default; }

        protected enum MoveState : int
        {
            Idle = 0,
            Move = 1,
            WaitRelease = 2,
        }
    }
}