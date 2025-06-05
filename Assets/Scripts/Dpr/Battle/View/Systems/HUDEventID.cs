namespace Dpr.Battle.View.Systems
{
	public enum HUDEventID : int
	{
		kInitial = 0,
		kBallPlateIn_FarSide = 1,
		kBallPlateIn_NearSide = 2,
		kStartWaitCamera = 3,
		kCommandInputEnd = 4,
		kEndWaitCamera = 5,
		kWazaEffectStart = 6,
		kWazaEffectEnd = 7,
		kDamageEffectStart = 8,
		kDamageEffectEnd = 9,
		kDeadActStart = 10,
		kMemberOutStart = 11,
		kMemberChangeStart = 12,
		kSimpleHPEffectStart = 13,
		kYesNo = 14,
		kEscapeYesNo = 15,
		kBallThrow = 16,
		kSickIcon = 17,
		kPokeChangeEnd = 18,
		kMoveMember = 19,
		kTrainerInLose = 20,
	}
}