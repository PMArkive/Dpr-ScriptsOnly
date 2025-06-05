namespace Dpr.Battle.Logic
{
	public sealed class Section_FromEvent_SetPower : Section
	{
		public Section_FromEvent_SetPower(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result result, in Description description) { }

		public class Description
		{
			public byte pokeID;
			public ushort attack;
			public ushort defence;
			public ushort spAttack;
			public ushort spDefence;
			public ushort agility;
			public bool isAttackEnable;
			public bool isDefenceEnable;
			public bool isSpAttackEnable;
			public bool isSpDefenceEnable;
			public bool isAgilityEnable;
			public StrParam successMessage = new StrParam();
			
			public Description()
			{
				pokeID = PokeID.INVALID;
				attack = 0;
				defence = 0;
				spAttack = 0;
				spDefence = 0;
				agility = 0;
				isAttackEnable = false;
				isDefenceEnable = false;
				isSpAttackEnable = false;
				isSpDefenceEnable = false;
				isAgilityEnable = false;
			}
		}

		public class Result
		{
			public bool isSuccessed;
		}
	}
}