using System;

namespace NexPlugin
{
	public struct NpDateTime
	{
		public short year;
		public byte month;
		public byte day;
		public byte hour;
		public byte minute;
		public byte second;
		private byte isNotNever;

		public static readonly NpDateTime INVALID_DATE_TIME = new NpDateTime(9999, 12, 31, 23, 59, 59);
		public static readonly NpDateTime Future = new NpDateTime(9999, 12, 31, 23, 59, 59);
        public static readonly NpDateTime PERMANENT_DATE_TIME = new NpDateTime(9999, 12, 31, 0, 0, 0);
		public static readonly NpDateTime Never = new NpDateTime(false);
		
		public NpDateTime(DateTime dt)
		{
			year = (short)dt.Year;
			month = (byte)dt.Month;
			day = (byte)dt.Day;
			hour = (byte)dt.Hour;
			minute = (byte)dt.Minute;
			second = (byte)dt.Second;

			isNotNever = 1;
		}
		
		public NpDateTime(short srcYear, byte srcMonth, byte srcDay, byte srcHour, byte srcMinute, byte srcSecond)
		{
			year = srcYear;
			month = srcMonth;
			day = srcDay;
			hour = srcHour;
			minute = srcMinute;
			second = srcSecond;

			isNotNever = 1;
		}
		
		public NpDateTime(IntPtr src)
		{
			this = Detail.ExchangePtrToStruct<NpDateTime>(src);
		}
		
		public NpDateTime(bool notnever)
		{
			day = 0;
			hour = 0;
			minute = 0;
			second = 0;
            year = 0;
            month = 0;
			day = 0;

			isNotNever = notnever ? (byte)1 : (byte)0;
        }
		
		// TODO
		public void Trace() { }
		
		// TODO
		internal string ToString() { return default; }
	}
}