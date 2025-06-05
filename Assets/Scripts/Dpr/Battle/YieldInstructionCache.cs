using UnityEngine;

namespace Dpr.Battle
{
	internal static class YieldInstructionCache
	{
		public static readonly WaitForEndOfFrame WaitForEndOfFrame = new WaitForEndOfFrame();
		public static readonly WaitForFixedUpdate WaitForFixedUpdate = new WaitForFixedUpdate();
	}
}