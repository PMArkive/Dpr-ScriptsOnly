using INL1;

namespace Dpr.NetworkUtils
{
	public struct RequestValidateResult
	{
		public IlcaNetServerCallbackResult callbackResult;
		public ValidateResultID validateResult;
		
		public void Reset()
		{
			callbackResult = IlcaNetServerCallbackResult.Error;
			validateResult = ValidateResultID.None;
		}
	}
}