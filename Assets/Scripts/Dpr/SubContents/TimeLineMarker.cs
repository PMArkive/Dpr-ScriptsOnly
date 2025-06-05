using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Dpr.SubContents
{
	public class TimeLineMarker : Marker, INotification
	{
		public Mode mode;
		public int value;
		public float frame;
		
		public PropertyName id { get => new PropertyName("method"); }

		public enum Mode : int
		{
			CheckEnd = 0,
			UpdateText = 1,
			ToBattleScale = 2,
			ToMenuScale = 3,
		}
	}
}