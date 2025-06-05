using System.Collections;
using UnityEngine;

namespace Dpr.Field.Walking
{
	public class SanpoPairActionCommon : ActionModel
	{
		private int masterAnim;
		private int slaveAnim;
		private bool isCanSameTime;
		
		public SanpoPairActionCommon(int masterAnim, int slaveAnim, bool isCanSameTime = false)
		{
			this.masterAnim = masterAnim;
			this.slaveAnim = slaveAnim;
			this.isCanSameTime = isCanSameTime;
		}
		
		// TODO
		private IEnumerator WaitFrame(int count) { return default; }
		
		// TODO
		public override IEnumerator DoAction(AIModel m) { return default; }

		private delegate Coroutine deleCor();
	}
}