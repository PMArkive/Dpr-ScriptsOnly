using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NexPlugin
{
	public static class Utility
	{
		// TODO
		public static bool AcquireNexUniqueIdAsync(out uint asyncId, IntPtr pNgsFacade, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AcquireNexUniqueIdCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool AcquireNexUniqueIdWithPasswordAsync(out uint asyncId, IntPtr pNgsFacade, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AcquireNexUniqueIdWithPasswordCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool AssociateNexUniqueIdWithMyPrincipalIdAsync(out uint asyncId, IntPtr pNgsFacade, UniqueIdInfo uniqueIdInfo, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool AssociateNexUniqueIdWithMyPrincipalIdAsync(out uint asyncId, IntPtr pNgsFacade, List<UniqueIdInfo> uniqueIdInfo, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] AsyncResultCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool GetAssociatedNexUniqueIdWithMyPrincipalIdAsync(out uint asyncId, IntPtr pNgsFacade, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] GetAssociatedNexUniqueIdWithMyPrincipalIdCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool GetAssociatedNexUniqueIdWithMyPrincipalIdAsync(out uint asyncId, IntPtr pNgsFacade, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] GetAssociatedNexUniqueIdWithMyPrincipalIdListCB callback)
        {
            asyncId = default;
            return default;
        }

        // TODO
        public static bool GetIntegerSettingsAsync(out uint asyncId, IntPtr pNgsFacade, uint integerSettingIndex, [Optional] [DefaultParameterValue(0)] int timeOut, [Optional] GetIntegerSettingsCB callback)
		{
			asyncId = default;
			return default;
		}

		public static extern bool IsValidNexUniqueId(ulong nexUniqueId);

		public delegate void AcquireNexUniqueIdCB(AsyncResult asyncResult, ulong nexUniqueId);
		public delegate void AcquireNexUniqueIdWithPasswordCB(AsyncResult asyncResult, UniqueIdInfo uniqueIdInfo);
		public delegate void GetAssociatedNexUniqueIdWithMyPrincipalIdCB(AsyncResult asyncResult, UniqueIdInfo uniqueIdInfo);
		public delegate void GetAssociatedNexUniqueIdWithMyPrincipalIdListCB(AsyncResult asyncResult, List<UniqueIdInfo> uniqueIdInfo);
		public delegate void GetIntegerSettingsCB(AsyncResult asyncResult, Dictionary<ushort, int> integerSettings);
	}
}