namespace Dpr.Battle.Logic
{
	public sealed class Section_TurnCheck_Weather : Section
	{
		public Section_TurnCheck_Weather(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void endWeather(BtlWeather weather) { }
		
		// TODO
		private void afterChangeWeather(BtlWeather weather) { }
		
		// TODO
		private void changeWeather(BtlWeather weather) { }
		
		// TODO
		private void weatherDamage_All() { }
		
		// TODO
		private void storeFrontPokeByAgilityOrder(PokeSet pPokeSet) { }
		
		// TODO
		private bool isWeatherDamageTarget(BTL_POKEPARAM poke) { return default; }
		
		// TODO
		private bool needSummarizeWeatherDamageMessage() { return default; }
		
		// TODO
		private void putSummarizedWeatherDamageMessage(ushort reservedQueuePos) { }
		
		// TODO
		private BtlWeather geWeather() { return default; }
		
		// TODO
		private bool applyWeatherDamage(BTL_POKEPARAM pTarget, bool canPutMessage) { return default; }
		
		// TODO
		private BtlWeather getLoaclWeather(byte pokeID) { return default; }
		
		// TODO
		private bool weatherDamage(BTL_POKEPARAM poke, BtlWeather weather, uint damage, byte damageCausePokeID, bool canPutMessage) { return default; }
		
		// TODO
		private bool weatherDamage_IsEnable(BTL_POKEPARAM poke, uint damage) { return default; }
		
		// TODO
		private void weatherDamage_Damage(BTL_POKEPARAM poke, uint damage, byte damageCausePokeID) { }
		
		// TODO
		private void weatherDamage_Message(BtlWeather weather, byte pokeID) { }
		
		// TODO
		private void weatherDamage_Effect(byte pokeID) { }
		
		// TODO
		private void checkPokeDead(BTL_POKEPARAM poke) { }
		
		// TODO
		private bool checkExpGet() { return default; }

		public class Description { }

		public class Result
		{
			public bool isExpGet;
		}
	}
}