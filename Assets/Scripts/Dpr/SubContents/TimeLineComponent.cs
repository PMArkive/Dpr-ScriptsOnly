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
		
		// TODO
		public void StopTimeLine() { }
		
		// TODO
		public void ResumeTimeLine() { }
	}
}