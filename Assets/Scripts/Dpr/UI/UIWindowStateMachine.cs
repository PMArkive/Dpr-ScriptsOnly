using UnityEngine;

namespace Dpr.UI
{
    public class UIWindowStateMachine : StateMachineBehaviour
    {
        public static readonly int animParamConnectId = Animator.StringToHash("connectId");
        public static readonly int animParamStateId = Animator.StringToHash("stateId");
        public static readonly int animStateVoid = Animator.StringToHash("void");
        public static readonly int animStateOpened = Animator.StringToHash("opened");

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (stateInfo.shortNameHash != animStateVoid && stateInfo.shortNameHash != animStateOpened)
                return;

            animator.SetInteger(animParamConnectId, -1);
            animator.SetInteger(animParamStateId, -1);
        }
    }
}