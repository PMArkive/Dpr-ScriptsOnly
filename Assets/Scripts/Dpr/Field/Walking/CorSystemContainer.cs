using Dpr.FureaiHiroba;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.Field.Walking
{
	public class CorSystemContainer : ICorSystem
	{
		private CorSystem corSys;
		private CorSystem TimeCorSys;
		private List<CorSystem> SubList = new List<CorSystem>();
		public int nowSubNo;
		public float duration;
		public float elapsedTime;
		private Text text;
		private int count;
		
		public bool isFinished { get => corSys.isFinished; }
		public bool isPlaying { get => corSys.isPlaying; }
		public float Rate { get => elapsedTime / duration; }
		
		public CorSystemContainer(string name = "")
		{
			corSys = new CorSystem(name);
			text = FureaiDebugManager.CreateText("");
		}
		
		public void Cancel()
		{
			corSys.Cancel();
		}
		
		public void SubCancel(string s)
        {
            SubCancel(SubList.FindIndex(x => x.CorName == s));
        }
		
		public void SubCancel(CorSystem corSys)
		{
			SubCancel(SubList.FindIndex(x => corSys == x));
		}
		
		public void SubCancel(int no)
		{
			if (SubList.Count < no)
				return;

			var sub = SubList[no];

			if (!sub.isPlaying)
				sub.PrePlayCancel();
			else
				sub.Cancel();

			SubList.RemoveAt(no);
		}
		
		public void Pause()
		{
			corSys.Pause();
		}
		
		public Coroutine Restart()
		{
			if (corSys.isPause)
				return corSys.Restart();
			else
				return null;
		}
		
		public CorSystem AddSub(float duration, corDelegate ienum, string name = "")
		{
			this.duration += duration;

            var sub = corSys.AddSub(name);
            sub.duration = duration;

			SubList.Add(sub);
			AddSubList(sub, ienum.Invoke(sub));

			return sub;
        }
		
		public CorSystem AddSub(float duration, IEnumerator ienum, string name = "")
        {
            this.duration += duration;

            var sub = corSys.AddSub(name);
            SubList.Add(sub);

            return sub;
        }
		
		private void AddSubList(CorSystem sub, IEnumerator ienum)
		{
            SubList.Add(sub);
        }
		
		public CorSystem AddWait(float duration, Action<CorSystem> OnUpdate, string Name)
		{
			count++;

			var sub = corSys.AddSub(Name);
			sub.duration = duration;
			this.duration += duration;

			sub.SetIEnum(sub.Wait(OnUpdate));
            SubList.Add(sub);

			return sub;
		}
		
		public void Play()
		{
			elapsedTime = 0.0f;
			duration = SubList.Sum(x => x.duration);

			corSys.onPauseStart += () => TimeCorSys.Pause();
			corSys.onPauseEnd += () => TimeCorSys.Restart();
			corSys.onFinished += () => SubList.Clear();

			corSys.Play(Main());
		}
		
		private IEnumerator TimeCount()
		{
			while (elapsedTime < duration)
			{
				elapsedTime += DeltaTime.deltaTime;
				yield return null;
			}
		}
		
		private IEnumerator Main()
		{
			nowSubNo = 0;

			while (SubList.Count > 0)
			{
				text.text = nowSubNo.ToString();

				var sub = SubList[0];
				sub.Play();

				var isfinish = false;

				sub.onFinished += () => isfinish = true;

				while (!isFinished)
					yield return new WaitForEndOfFrame();

				nowSubNo++;

				SubList.RemoveAll(x => x.isFinished);
			}
		}

		public delegate IEnumerator corDelegate(CorSystem corSystem);
	}
}