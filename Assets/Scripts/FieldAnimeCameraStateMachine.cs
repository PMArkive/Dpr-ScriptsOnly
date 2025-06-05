using UnityEngine;

public class FieldAnimeCameraStateMachine : StateMachineBehaviour
{
	public override void OnStateMachineExit(Animator animator, int stateMachinePathHash)
	{
		if (FieldAnimeCamera.instance != null)
			FieldAnimeCamera.instance.OnStateMachineExit();
    }
}