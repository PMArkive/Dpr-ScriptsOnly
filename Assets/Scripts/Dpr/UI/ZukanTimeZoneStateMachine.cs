using UnityEngine;

namespace Dpr.UI
{
	public class ZukanTimeZoneStateMachine : StateMachineBehaviour
	{
		public static readonly int animParamConnectIdSrc = Animator.StringToHash("connectId01");
        public static readonly int animParamConnectIdDest = Animator.StringToHash("connectId02");
        public static readonly int animParamStateId = Animator.StringToHash("stateId");
		public static readonly int animStateMoveEnd = Animator.StringToHash("Move_End");

        // TODO
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }
	}
}