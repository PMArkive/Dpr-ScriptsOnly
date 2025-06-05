using NexPlugin;
using System;
using UnityEngine;

namespace NexAssets
{
	[Serializable]
	public class DataStoreRatingLockInitParam
	{
		[SerializeField]
		private RatingLockType ratingLockType;
		[SerializeField]
		[Range(0.0f, 32767.0f)]
		private short periodDuration;
		[SerializeField]
		private DataStore.RatingLockPeriod periodDurationFlag = DataStore.RatingLockPeriod.RATING_LOCK_PERIOD_DAY1;
		[SerializeField]
		[Range(-23.0f, 23.0f)]
		private sbyte periodHour;
		[SerializeField]
		[Range(0.0f, 32767.0f)]
		private short periodDays;
		
		// TODO
		public DataStoreRatingLockInitParam GetDataStoreRatingLockInitParam() { return default; }
	}
}