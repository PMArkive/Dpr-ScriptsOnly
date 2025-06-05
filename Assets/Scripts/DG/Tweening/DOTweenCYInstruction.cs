using UnityEngine;

namespace DG.Tweening
{
	public static class DOTweenCYInstruction
	{
		public class WaitForCompletion : CustomYieldInstruction
		{
			private readonly Tween t;
			
			// TODO
			public override bool keepWaiting { get; }
			
			// TODO
			public WaitForCompletion(Tween tween) { }
		}

		public class WaitForRewind : CustomYieldInstruction
		{
			private readonly Tween t;
			
			// TODO
			public override bool keepWaiting { get; }
			
			// TODO
			public WaitForRewind(Tween tween) { }
		}

		public class WaitForKill : CustomYieldInstruction
		{
			private readonly Tween t;
			
			// TODO
			public override bool keepWaiting { get; }
			
			// TODO
			public WaitForKill(Tween tween) { }
		}

		public class WaitForElapsedLoops : CustomYieldInstruction
		{
			private readonly Tween t;
			private readonly int elapsedLoops;
			
			// TODO
			public override bool keepWaiting { get; }
			
			// TODO
			public WaitForElapsedLoops(Tween tween, int elapsedLoops) { }
		}

		public class WaitForPosition : CustomYieldInstruction
		{
			private readonly Tween t;
			private readonly float position;
			
			// TODO
			public override bool keepWaiting { get; }
			
			// TODO
			public WaitForPosition(Tween tween, float position) { }
		}

		public class WaitForStart : CustomYieldInstruction
		{
			private readonly Tween t;
			
			// TODO
			public override bool keepWaiting { get; }
			
			// TODO
			public WaitForStart(Tween tween) { }
		}
	}
}