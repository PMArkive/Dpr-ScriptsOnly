namespace Dpr.Battle.Logic
{
	public sealed class Section_WazaExec_Category_FieldEffect : Section
	{
		public Section_WazaExec_Category_FieldEffect(in CommonParam commonParam) : base(commonParam) { }
		
		// TODO
		public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void execute_Weather(BTL_POKEPARAM attacker, BtlWeather weather) { }
		
		// TODO
		private ChangeWeatherResult changeWeather(BtlWeather weather, byte turnUpCount, byte causePokeID) { return default; }
		
		// TODO
		private void putFailMessage_ByStrongWeather() { }
		
		// TODO
		private void execute_Others(WazaParam wazaParam, BTL_POKEPARAM attacker) { }

		public class Description
		{
			public WazaParam wazaParam;
			public BTL_POKEPARAM attacker;
			
			public Description()
			{
				wazaParam = null;
				attacker = null;
			}
		}

		public class Result { }
	}
}