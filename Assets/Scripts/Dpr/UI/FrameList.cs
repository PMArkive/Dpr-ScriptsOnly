using System;
using UnityEngine.UI;

namespace Dpr.UI
{
	[Serializable]
	public class FrameList
	{
		public Image[] FrameUpLeft;
		public Image[] FrameUpRight;
		public Image[] FrameDownLeft;
		public Image[] FrameDownRight;
		
		public FrameList(Image[] images)
		{
			// Empty
		}

		public enum ImageIndex : int
		{
			Image = 0,
			Eff01 = 1,
			Eff02 = 2,
		}
	}
}