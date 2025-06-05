namespace Dpr.Battle.Logic
{
	public sealed class Section_ChangeWeather : Section
	{
		public Section_ChangeWeather(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private ChangeWeatherResult checkWeatherChangeEnable(BtlWeather weather, byte turn) { return default; }
		
		// TODO
		private void changeWeather(BtlWeather weather, byte turn, byte turnUpCount, byte causePokeID, ChangeWeatherCause cause) { }

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

		public class Result
		{
			public ChangeWeatherResult changeResult;
		}
	}
}