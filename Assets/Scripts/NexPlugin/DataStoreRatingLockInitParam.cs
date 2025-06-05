namespace NexPlugin
{
	public class DataStoreRatingLockInitParam
	{
		internal DataStore.RatingLockType lockType;
		internal short periodDuration;
		internal sbyte periodHour;
		
		public DataStoreRatingLockInitParam()
		{
			lockType = DataStore.RatingLockType.RATING_LOCK_NONE;
			periodDuration = 0;
			periodHour = 0;
		}
		
		// TODO
		private void Reset() { }
		
		// TODO
		public void SetIntervalLock(short intervalSec) { }
		
		// TODO
		public void SetPeriodicLock(DataStore.RatingLockPeriod period, sbyte hour) { }
		
		// TODO
		public void SetDaysAfterLock(short days, sbyte hour) { }
		
		// TODO
		public void SetPermanentLock() { }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}