namespace Dpr.Battle.View.Systems
{
	public enum SUBSEQ_MEMBER_CHANGE_ACT : int
	{
		SUBSEQ_DEFAULT = 0,
		MEMBER_LOAD_WAIT = 1,
		SEQUENCE_MEMBER_CHANGE_WAIT = 2,
		SEQUENCE_RARE_WAIT = 3,
		FINISH = 4,
	}
}