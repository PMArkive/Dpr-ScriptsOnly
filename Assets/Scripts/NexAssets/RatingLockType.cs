namespace NexAssets
{
	public enum RatingLockType : int
	{
		NotLock = 0,
		IntervalLock = 1,
		PeriodicLock = 2,
		DaysAfterLock = 3,
		PermanentLock = 4,
	}
}