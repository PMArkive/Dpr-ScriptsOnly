namespace Dpr.Battle.Logic
{
	public sealed class Section_ChangeWeather_Core : Section
	{
		public Section_ChangeWeather_Core(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private void afterChangeWeather(BtlWeather weather) { }
		
		// TODO
		private void checkBattleTalk(byte pokeID, BtlWeather weather) { }

		public class Description
		{
			public BtlWeather weather;
			public byte turn;
			public byte turnUpCount;
			public byte causePokeID;
			public ChangeWeatherCause cause;
			
			public Description()
			{
				weather = BtlWeather.BTL_WEATHER_NONE;
				turn = 0;
				turnUpCount = 0;
				causePokeID = PokeID.INVALID;
				cause = ChangeWeatherCause.OTHERS;
			}
		}

		public class Result { }
	}
}