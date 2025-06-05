using System;
using System.Collections;
using XLSXContent;

namespace Dpr.Battle.View
{
	public class ComparerMotionReplaceData : IComparer
	{
		public int Compare(object x, object y)
		{
			var obj = x as BattleDataTable.SheetMotionReplaceData;
			var yInt = Convert.ToInt32(y);

			if (obj.UniqueID < yInt)
				return -1;
			else if (obj.UniqueID > yInt)
				return 1;
			else
				return 0;
		}
	}
}