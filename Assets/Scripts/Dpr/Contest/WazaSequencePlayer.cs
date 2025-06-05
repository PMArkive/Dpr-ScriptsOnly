using Dpr.Battle.View.Objects;

namespace Dpr.Contest
{
	public class WazaSequencePlayer
	{
		private SceneObjectManager objManager;
		private BOCamera mainCamera;
		private BOCamera wazaCamera;
		private ContestViewSystem wazaViewSystemPtr;
		private WazaSeqState seqState;
		private int userIndex;
		private bool hasRequestPlaySequence;
		
		// TODO
		public void SetupWazaSequence() { }
		
		// TODO
		public void ResetParam() { }
		
		public bool IsRunning { get => seqState == WazaSeqState.Active || seqState == WazaSeqState.Playing; }
		
		// TODO
		private void ActivateWazaCamera() { }
		
		// TODO
		private void DeactivateWazaCamera() { }
		
		// TODO
		public void PlayWazaSequence(int userIndex) { }
		
		// TODO
		public void OnUpdate() { }
		
		// TODO
		private void UpdateStateActive() { }
		
		// TODO
		private void UpdateStatePlaying() { }
		
		// TODO
		public void OnLateUpdate() { }

		private enum WazaSeqState : int
		{
			Wait = 0,
			Start = 1,
			Active = 2,
			Playing = 3,
			End = 4,
		}
	}
}