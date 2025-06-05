using System;

namespace Dpr.Contest
{
	public class PlayerDanceDataModel : PlayerDanceData
	{
		public PlayerDanceDataModel()
		{
			tapTimingCountArray = new int[(int)NoteTapTimingID.Num];
		}
		
		// TODO
		public void SetPlayerData(PlayerDanceData data) { }
		
		// TODO
		public void ResetParam() { }
		
		public int StackLiveScore { get => stackLiveScore; }
		
		// TODO
		public void AddLiveScore(int addScore) { }
		
		// TODO
		public void DecLiveScore(int decScore) { }
		
		// TODO
		public void AddTapTimingCount(NoteTapTimingID timingID) { }
		
		// TODO
		public int GetTapTimingCount(NoteTapTimingID timingID) { return default; }
		
		// TODO
		public void ForceSetTension(int tension) { }
		
		// TODO
		public void SetUpdownCount(TensionData tensionData) { }
		
		// TODO
		public bool AddSuccessCount() { return default; }
		
		// TODO
		private void UpTension() { }
		
		// TODO
		public bool AddFailedCount() { return default; }
		
		// TODO
		private void DownTension() { }
		
		// TODO
		private void ResetTensionCount() { }
		
		// TODO
		public bool AddHeartGauge(int addValue) { return default; }
		
		public bool IsAlreadyUseSkill { get => usedSkill; }
		public bool IsActiveSkill { get => contestSkill.IsActive; }
		public bool IsForceSuccess { get => bonusParam.forceSuccess; }
		public bool CanEmitHeart { get => canEmitHeart; }
		
		// TODO
		public void UseSkill() { }
		
		// TODO
		public void LockSkill() { }
		
		// TODO
		public void LaunchSkill() { }
		
		// TODO
		public void FinishedSkillAnim() { }
		
		// TODO
		public void ActivateSkillEffect(double elapsedTime, Action onFinishSkillEffect) { }
		
		// TODO
		public void UpdateSkillEffect(double elapsedTime) { }
		
		// TODO
		public void AddWazaScore(int score) { }
	}
}