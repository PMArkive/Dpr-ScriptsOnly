using System;

namespace nn.account
{
	public static class NetworkServiceAccount
	{
		public const int IdTokenLengthMax = 3072;

		public static extern Result EnsureAvailable(UserHandle handle);
		public static extern Result IsAvailable(ref bool pOut, UserHandle handle);
		public static extern Result GetId(ref NetworkServiceAccountId pOutId, UserHandle handle);
		
		// TODO
		public static Result EnsurIdTokenCacheAsync(AsyncContext pOutContext, UserHandle handle) { return default; }

		public static extern Result EnsurIdTokenCacheAsync(IntPtr pOutContext, UserHandle handle);
		
		// TODO
		public static Result LoadIdTokenCache(ref ulong pOutActualSize, byte[] buffer, UserHandle handle) { return default; }

		private static extern Result LoadIdTokenCache(ref ulong pOutActualSize, byte[] buffer, int bufferSize, UserHandle handle);
		
		// TODO
		public static ErrorRange ResultNetworkServiceAccountUnavailable { get; }
		
		// TODO
		public static ErrorRange ResultTokenCacheUnavailable { get; }
		
		// TODO
		public static ErrorRange ResultNetworkCommunicationError { get; }
		
		// TODO
		public static ErrorRange ResultSslService { get; }
	}
}