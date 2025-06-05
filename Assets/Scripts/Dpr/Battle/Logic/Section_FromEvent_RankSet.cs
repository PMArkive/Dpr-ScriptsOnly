namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_RankSet : Section
	{
		public Section_FromEvent_RankSet(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result result, in Description description) { }

		public class Description
		{
			public byte pokeID;
			public byte attack;
			public byte defence;
			public byte sp_attack;
			public byte sp_defence;
			public byte agility;
			public byte hit_ratio;
			public byte avoid_ratio;
			public byte critical_rank;
			
			public Description()
			{
				pokeID = PokeID.INVALID;
				attack = 0;
				defence = 0;
				sp_attack = 0;
				sp_defence = 0;
				agility = 0;
				hit_ratio = 0;
				avoid_ratio = 0;
				critical_rank = 0;
			}
		}

		public class Result
		{
			public bool isSuccessed;
		}
	}
}