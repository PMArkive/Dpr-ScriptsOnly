using Pml;
using Pml.PokePara;

namespace Dpr.Battle.Logic
{
	public sealed class ClientPublicInformation
	{
		private readonly POKECON m_pokecon;
		private Party m_party = new Party();
		
		public ClientPublicInformation(POKECON pokecon)
		{
			m_pokecon = pokecon;
			InitPartyInformation(m_party);
		}
		
		// TODO
		private void InitPartyInformation(Party party) { }
		
		// TODO
		public byte GetPokemonID(byte memberIndex) { return default; }
		
		// TODO
		public MonsNo GetPokemonMonsterNo(byte memberIndex) { return default; }
		
		// TODO
		public ushort GetPokemonFormNo(byte memberIndex) { return default; }
		
		// TODO
		public Sex GetPokemonSex(byte memberIndex) { return default; }
		
		// TODO
		public byte GetPokemonLevel(byte memberIndex) { return default; }
		
		// TODO
		public Sick GetPokemonSick(byte memberIndex) { return default; }
		
		// TODO
		public bool HavePokemonItem(byte memberIndex) { return default; }
		
		// TODO
		public bool IsPokemonAppearedOnBattleField(byte memberIndex) { return default; }
		
		// TODO
		private Pokemon GetPublishedPokemonByMemberIndex(byte memberIndex) { return default; }
		
		// TODO
		private Pokemon GetPublishedPokemonByMemberIndexConst(byte memberIndex) { return default; }
		
		// TODO
		public void PublishPokemon(byte memberIndex, byte battlePokeId, MonsNo monsno, ushort formno, Sex sex, byte level, bool haveItem) { }
		
		// TODO
		public void SetPokemonAppearedOnBattleField(byte battlePokeId) { }
		
		// TODO
		public void SetPokemonHaveItem(byte battlePokeId, bool haveItem) { }
		
		// TODO
		public void SetPokemonFormNo(byte battlePokeId, ushort formno) { }
		
		// TODO
		private Pokemon GetPublishedPokemonByBattlePokeId(byte battlePokeId) { return default; }
		
		// TODO
		private Pokemon GetPublishedPokemonByBattlePokeIdConst(byte battlePokeId) { return default; }

		private class Pokemon
		{
			public byte battlePokeId;
			public MonsNo monsno;
			public ushort formno;
			public Sex sex;
			public byte level;
			public bool haveItem;
			public bool isAppearedOnBattleField;
		}

		private class Party
		{
			public Pokemon[] member = Arrays.InitializeWithDefaultInstances<Pokemon>(DefineConstants.BTL_PARTY_MEMBER_MAX);
		}
	}
}