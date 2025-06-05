using Dpr.Battle.Logic;
using Pml.WazaData;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class TargetSelectCursor : Cursor
	{
		[SerializeField]
		private FrameList[] _TargetFrames;

		private List<Image[]> _showFrames = new List<Image[]>();
		private List<Image[]> _hideFrames = new List<Image[]>();
		
		// TODO
		public void SetCursorFrame(BtlvPos attackerPos, WazaTarget targetType) { }
		
		// TODO
		private void SetFrameParts(List<Image[]> frames, bool isShow) { }
	}
}