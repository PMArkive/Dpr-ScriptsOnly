namespace Dpr.Battle.Logic
{
	public sealed class Section_ChangeWeather_Check : Section
	{
		public Section_ChangeWeather_Check(in CommonParam commonParam) : base(commonParam) { }

        // TODO
        public void Execute(Result pResult, in Description description) { }
		
		// TODO
		private bool canOverwrite(BtlWeather nextWeather) { return default; }

		public class Description
		{
			public BtlWeather weather;
			public byte turn;
			
			public Description()
			{
				weather = BtlWeather.BTL_WEATHER_NONE;
				turn = 0;
			}
		}

		public class Result
		{
			public ChangeWeatherResult result;
		}
	}
}