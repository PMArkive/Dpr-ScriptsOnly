using DG.Tweening.Plugins;
using System.Runtime.InteropServices;
using UnityEngine;

namespace DG.Tweening
{
	public static class DOTweenProShortcuts
	{
		// Ignoring the created object
		static DOTweenProShortcuts()
		{
			_ = new SpiralPlugin();
		}

        // TODO
        public static Tweener DOSpiral(this Transform target, float duration, [Optional] Vector3? axis, SpiralMode mode = SpiralMode.Expand, float speed = 1.0f, float frequency = 10.0f, float depth = 0.0f, bool snapping = false) { return default; }
		
		// TODO
		public static Tweener DOSpiral(this Rigidbody target, float duration, [Optional] Vector3? axis, SpiralMode mode = SpiralMode.Expand, float speed = 1.0f, float frequency = 10.0f, float depth = 0.0f, bool snapping = false) { return default; }
	}
}