namespace INL1
{
	public enum IlcaNetUtilInternetGoResult : int
	{
		SUCCESS = 0,
		DONOT_LOGIN_CALL_MISS = 5,
		DONOT_NEXUID_CALL_MISS = 6,
		ERROR = 10,
		DONOT_INET = 10,
		DONOT_NSO = 11,
		DONOT_NEXUID = 12,
		DONOT_NSAIDT = 13,
		DONOT_LOGIN = 14,
		CRASH = 15,
	}
}