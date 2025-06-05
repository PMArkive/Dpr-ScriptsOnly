using System.Collections.Generic;

namespace Dpr.NetworkUtils
{
	public struct ValidateCheckPluralResult
	{
		public List<bool> illegalList;
		public ValidateResultID validateResult;
		public bool bIsSuccess;
		
		public void Reset()
		{
			bIsSuccess = false;
			validateResult = ValidateResultID.ProcessError;
			illegalList.Clear();
		}
	}
}