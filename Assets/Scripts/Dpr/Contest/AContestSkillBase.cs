using Pml;
using System;
using XLSXContent;

namespace Dpr.Contest
{
	public abstract class AContestSkillBase
	{
		protected ContestWazaInfo.SheetContestWazaData skillData;
		protected PlayerDanceDataModel targetData;
		protected PokeType wazaType;
		protected double launchElapsedTime;
		protected double lifeTime;
		protected bool active;
		private Action onFinished;
		
		public bool IsActive { get => active; }
		public SkillTypeID SkillType { get => (SkillTypeID)skillData.wazaType; }
		public PokeType WazaType { get => wazaType; }
		
		// TODO
		public void Reset() { }
		
		// TODO
		public void CreateSkill(ContestWazaInfo.SheetContestWazaData skillData, PokeType wazaType, PlayerDanceDataModel target) { }

		public abstract int CalcAppealPoint();
		
		// TODO
		public void ActivateSkillEffect(SkillBonusParam bonusParam, double elapsedTime, Action onFinished) { }

		protected abstract void OnLaunchSkillEffect(SkillBonusParam bonusParam);
		
		// TODO
		public void UpdateSkill(double elapsedTime) { }
		
		// TODO
		private void FinishSkill() { }
	}
}