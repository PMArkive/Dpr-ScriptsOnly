using DG.Tweening.Core;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace DG.Tweening
{
	[AddComponentMenu(menuName: "DOTween/DOTween Path")]
	public class DOTweenPath : ABSAnimationComponent
	{
        public static event Action<DOTweenPath> OnReset;
		public float delay;
		public float duration;
		public Ease easeType;
		public AnimationCurve easeCurve;
		public int loops;
		public string id;
		public LoopType loopType;
		public OrientType orientType;
		public Transform lookAtTransform;
		public Vector3 lookAtPosition;
		public float lookAhead;
		public bool autoPlay;
		public bool autoKill;
		public bool relative;
		public bool isLocal;
		public bool isClosedPath;
		public int pathResolution;
		public PathMode pathMode;
		public AxisConstraint lockRotation;
		public bool assignForwardAndUp;
		public Vector3 forwardDirection;
		public Vector3 upDirection;
		public bool tweenRigidbody;
		public List<Vector3> wps;
		public List<Vector3> fullWps;
		public Path path;
		public DOTweenInspectorMode inspectorMode;
		public PathType pathType;
		public HandlesType handlesType;
		public bool livePreview;
		public HandlesDrawMode handlesDrawMode;
		public float perspectiveHandleSize;
		public bool showIndexes;
		public bool showWpLength;
		public Color pathColor;
		public Vector3 lastSrcPosition;
		public Quaternion lastSrcRotation;
		public bool wpsDropdown;
		public float dropToFloorOffset;
		private static MethodInfo _miCreateTween;
		
		// TODO
		private static void Dispatch_OnReset(DOTweenPath path) { }
		
		// TODO
		private void Awake() { }
		
		// TODO
		private void Reset() { }
		
		// TODO
		private void OnDestroy() { }
		
		// TODO
		public override void DOPlay() { }
		
		// TODO
		public override void DOPlayBackwards() { }
		
		// TODO
		public override void DOPlayForward() { }
		
		// TODO
		public override void DOPause() { }
		
		// TODO
		public override void DOTogglePause() { }
		
		// TODO
		public override void DORewind() { }
		
		// TODO
		public override void DORestart() { }
		
		// TODO
		public override void DORestart(bool fromHere) { }
		
		// TODO
		public override void DOComplete() { }
		
		// TODO
		public override void DOKill() { }
		
		// TODO
		public Tween GetTween() { return default; }
		
		// TODO
		public Vector3[] GetDrawPoints() { return default; }
		
		// TODO
		internal Vector3[] GetFullWps() { return default; }
		
		// TODO
		private void ReEvaluateRelativeTween() { }
		
		// TODO
		public DOTweenPath() { }
	}
}