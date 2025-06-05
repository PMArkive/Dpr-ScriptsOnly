using System.Collections;
using System.Collections.Generic;

namespace Dpr.DigFossil
{
	public interface IDigDepositViewManager
	{
		IEnumerator Load();

		void Initialize(List<DigDepositViewManager.PlacementInfo> placementList);
	}
}