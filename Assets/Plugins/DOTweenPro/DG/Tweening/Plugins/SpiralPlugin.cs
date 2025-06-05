using DG.Tweening.Core;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Core;
using UnityEngine;

namespace DG.Tweening.Plugins
{
	public class SpiralPlugin : ABSTweenPlugin<Vector3, Vector3, SpiralOptions>
	{
		public static readonly Vector3 DefaultDirection = Vector3.forward;
		
		// TODO
		public override void Reset(TweenerCore<Vector3, Vector3, SpiralOptions> t) { }
		
		// TODO
		public override void SetFrom(TweenerCore<Vector3, Vector3, SpiralOptions> t, bool isRelative) { }
		
		// TODO
		public override void SetFrom(TweenerCore<Vector3, Vector3, SpiralOptions> t, Vector3 fromValue, bool setImmediately) { }
		
		// TODO
		public static ABSTweenPlugin<Vector3, Vector3, SpiralOptions> Get() { return default; }
		
		// TODO
		public override Vector3 ConvertToStartValue(TweenerCore<Vector3, Vector3, SpiralOptions> t, Vector3 value) { return default; }
		
		// TODO
		public override void SetRelativeEndValue(TweenerCore<Vector3, Vector3, SpiralOptions> t) { }
		
		// TODO
		public override void SetChangeValue(TweenerCore<Vector3, Vector3, SpiralOptions> t) { }
		
		// TODO
		public override float GetSpeedBasedDuration(SpiralOptions options, float unitsXSecond, Vector3 changeValue) { return default; }
		
		// TODO
		public override void EvaluateAndApply(SpiralOptions options, Tween t, bool isRelative, DOGetter<Vector3> getter, DOSetter<Vector3> setter, float elapsed, Vector3 startValue, Vector3 changeValue, float duration, bool usingInversePosition, UpdateNotice updateNotice) { }
	}
}