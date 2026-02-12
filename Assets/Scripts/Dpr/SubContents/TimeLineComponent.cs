using System;
using UnityEngine;

namespace Dpr.SubContents
{
	public class TimeLineComponent : MonoBehaviour
	{
		protected Action OnStopTimeLine;
		protected Action OnResumeTimeLine;
		
		public void SetCallBack(Action OnStop, Action OnResume)
		{
			OnStopTimeLine = OnStop;
			OnResumeTimeLine = OnResume;
		}
		
		public void StopTimeLine()
		{
			if (this.Length != 0) {
			  this.Length.Invoke();
			}
		}
		
		public void ResumeTimeLine()
		{
			if (this[0] != 0) {
			  Action.Invoke(this[0]);
			}
		}
	}
}