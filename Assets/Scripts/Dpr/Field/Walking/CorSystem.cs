using SmartPoint.AssetAssistant;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.Field.Walking
{
    public class CorSystem : ICorSystem
    {
        public string CorName;
        public float duration;
        public bool isFinished;
        public bool isPlaying;
        public bool isPause;
        public event Action onStart;
        public event Action onFinished;
        public event Action onCancel;
        public event Action onPauseStart;
        public event Action onPauseEnd;
        private List<CorSystem> SubCoroutines = new List<CorSystem>();
        private IEnumerator MainIEnum;
        private IEnumerator IEnum;

        public CorSystem(string name = "")
        {
            CorName = name;
        }

        public void Destroy()
        {
            SubCoroutines.Clear();

            SubCoroutines = null;
            MainIEnum = null;
            IEnum = null;

            ClearCallBacks();
        }

        public Coroutine Play(IEnumerator ienum)
        {
            isFinished = false;
            isPlaying = true;

            OnFinished(() =>
            {
                SubCoroutines.Clear();
                ClearCallBacks();
                MainIEnum = null;
                IEnum = null;

                isFinished = true;
                isPlaying = false;
                isPause = false;
            });

            MainIEnum = Main(ienum);
            IEnum = ienum;

            onStart?.Invoke();

            return StartCoroutine(MainIEnum);
        }

        public void PrePlayCancel()
        {
            OnFinished(() =>
            {
                SubCoroutines.Clear();
                ClearCallBacks();
                MainIEnum = null;
                IEnum = null;

                isFinished = true;
                isPlaying = false;
                isPause = false;
            });

            Cancel();
        }

        public Coroutine Play()
        {
            return Play(IEnum);
        }

        public void SetIEnum(IEnumerator ienum)
        {
            IEnum = ienum;
        }

        public CorSystem OnStart(Action act)
        {
            onStart += act;
            return this;
        }

        public CorSystem OnFinished(Action act)
        {
            onFinished += act;
            return this;
        }

        public CorSystem OnCancel(Action act)
        {
            onCancel += act;
            return this;
        }

        public CorSystem OnPauseStart(Action act)
        {
            onPauseStart += act;
            return this;
        }

        public CorSystem OnPauseEnd(Action act)
        {
            onPauseEnd += act;
            return this;
        }

        public CorSystem AddSub(string name = "")
        {
            var sub = new CorSystem(name);
            SubCoroutines.Add(sub);
            return sub;
        }

        public void Cancel()
        {
            if (!isPlaying)
                return;

            if (IEnum != null)
                StopCoroutine(IEnum);

            if (MainIEnum != null)
                StopCoroutine(MainIEnum);

            SubCoroutines.ForEach(x => x.Cancel());

            onCancel?.Invoke();
            onFinished?.Invoke();
        }

        public void Pause()
        {
            isPause = true;

            SubCoroutines.ForEach(x => x.Pause());

            if (IEnum != null)
                StopCoroutine(IEnum);

            if (MainIEnum != null)
                StopCoroutine(MainIEnum);

            onPauseStart?.Invoke();
        }

        public Coroutine Restart()
        {
            isPause = false;
            onPauseEnd?.Invoke();
            return StartCoroutine(RestartCor());
        }

        private IEnumerator RestartCor()
        {
            for (int i=0; i<SubCoroutines.Count; i++)
            {
                if (!SubCoroutines[i].isFinished)
                {
                    if (SubCoroutines[i].Restart() != null)
                        yield return null;
                }
            }

            if (!isFinished)
            {
                if (IEnum != null)
                    MainIEnum = Main(IEnum);

                if (MainIEnum != null)
                    yield return StartCoroutine(MainIEnum);
            }
        }

        public void ClearCallBacks()
        {
            if (onStart != null)
            {
                var invokeList = onStart.GetInvocationList();
                for (int i=0; i<invokeList.Length; i++)
                    onStart = (Action)Delegate.Remove(onStart, invokeList[i]);
            }
            
            if (onFinished != null)
            {
                var invokeList = onFinished.GetInvocationList();
                for (int i=0; i<invokeList.Length; i++)
                    onFinished = (Action)Delegate.Remove(onFinished, invokeList[i]);
            }

            if (onCancel != null)
            {
                var invokeList = onCancel.GetInvocationList();
                for (int i=0; i<invokeList.Length; i++)
                    onCancel = (Action)Delegate.Remove(onCancel, invokeList[i]);
            }

            if (onPauseStart != null)
            {
                var invokeList = onPauseStart.GetInvocationList();
                for (int i=0; i<invokeList.Length; i++)
                    onPauseStart = (Action)Delegate.Remove(onPauseStart, invokeList[i]);
            }

            if (onPauseEnd != null)
            {
                var invokeList = onPauseEnd.GetInvocationList();
                for (int i=0; i<invokeList.Length; i++)
                    onPauseEnd = (Action)Delegate.Remove(onPauseEnd, invokeList[i]);
            }
        }

        public void StateDebug([Optional] Text text)
        {
            string stateName = CorName;

            if (text != null)
            {
                onStart += () => text.text = stateName + ":実行中"; // Running
                onCancel += () => text.text = stateName + ":キャンセル"; // Cancel
                onFinished += () => text.text = stateName + ":終了"; // End
                onPauseStart += () => text.text = stateName + ":ポーズ中"; // Pausing
                onPauseEnd += () => text.text = stateName + ":実行中"; // Running
            }
            else
            {
                onStart += () => { };
                onCancel += () => { };
                onFinished += () => { };
                onPauseStart += () => { };
                onPauseEnd += () => { };
            }
        }

        private IEnumerator Main(IEnumerator ienum)
        {
            yield return StartCoroutine(ienum);
            onFinished?.Invoke();
        }

        private Coroutine StartCoroutine(IEnumerator ienum)
        {
            return Sequencer.Instance.StartCoroutine(ienum);
        }

        private void StopCoroutine(IEnumerator ienum)
        {
            Sequencer.Instance.StopCoroutine(ienum);
        }

        public Coroutine WaitForSeconds(float duration, [Optional] Action<CorSystem> OnUpdate)
        {
            this.duration = duration;
            return AddSub("ウェイト").Play(Wait(OnUpdate)); // "Wait"
        }

        public IEnumerator Wait(Action<CorSystem> OnUpdate)
        {
            while (duration > 0.0f)
            {
                if (isFinished)
                    break;

                float newDuration = duration - DeltaTime.deltaTime;
                if (newDuration <= 0.0f)
                    newDuration = 0.0f;

                duration = newDuration;

                OnUpdate?.Invoke(this);

                if (duration > 0.0f)
                    yield return new WaitForEndOfFrame();
            }
        }
    }
}