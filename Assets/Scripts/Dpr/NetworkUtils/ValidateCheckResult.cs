namespace Dpr.NetworkUtils
{
	public struct ValidateCheckResult
	{
		public ValidateResultID validateResult;
		public bool bIsSuccess;
		
		public void Reset()
		{
			bIsSuccess = false;
			validateResult = ValidateResultID.ProcessError;
		}
	}
}