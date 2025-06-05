namespace INL1
{
	public enum IlcaNetSessionState : int
	{
		SS_NoInit = 0,
		SS_WorkingAsync = 1,
		SS_MatchingWait = 2,
		SS_MatchingBlock = 3,
		SS_GamingFront = 4,
		SS_Gaming = 5,
		SS_GamingLeave = 6,
		SS_GamingError = 7,
		SS_Final = 8,
		SS_Crash = 9,
	}
}