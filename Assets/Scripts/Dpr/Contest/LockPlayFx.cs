using Dpr.MsgWindow;

namespace Dpr.Contest
{
	public class LockPlayFx
	{
		private WaitTimer waitTimer = new WaitTimer();
		private bool isLock;
		
		// TODO
		public void Initialize(float limitTime) { }
		
		public bool IsLock { get => isLock; }
		
		public void Lock()
		{
			this.Length = 1;
		}
		
		public void Reset()
		{
			this.waitTimer.ResetTimer();
		}
		
		public void OnUpdate(float deltaTime)
		{
			ulong uVar1 = default;
			if ((this.Length != 0) &&
			   (uVar1 = this.waitTimer.IsFinishWait(),
			   (uVar1 & 1) != 0)) {
			  this.waitTimer.ResetTimer();
			  this.Length = 0;
			}
		}
	}
}