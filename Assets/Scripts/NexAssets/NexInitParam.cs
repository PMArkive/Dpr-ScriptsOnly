using System;
using UnityEngine;

namespace NexAssets
{
	[Serializable]
	public class NexInitParam
	{
		private const int KILOBYTE = 1024;
		private const int MIN_TIMEOUT = 1000;
		private const int MAX_TIMEOUT = 60000;
		private const int DEF_TIMEOUT = 30000;
		private const int MIN_MEMORY = 300;
		private const int MAX_MEMORY = 10240;
		private const int MIN_RESERVEMEMORY = 40;

		[SerializeField]
		private string gameServerId = "0";
		[SerializeField]
		private string accessKey = "";
		[SerializeField]
		[Range(MIN_TIMEOUT, MAX_TIMEOUT)]
		private int timeOut = DEF_TIMEOUT;
		[SerializeField]
		[Range(MIN_MEMORY, MAX_MEMORY)]
		private uint pluginMemSize = 2 * KILOBYTE;
		[SerializeField]
		private NexPlugin.Common.ThreadMode threadMode = NexPlugin.Common.ThreadMode.ThreadModeSafeTransportBuffer;
		[SerializeField]
		private Common.CALL_DISPATCH callDispatch = (Common.CALL_DISPATCH)3;
		[SerializeField]
		[Range(0.0f, 60000.0f)]
		private uint dispatchTimeOut;
		[SerializeField]
		private NexPlugin.Common.DispachFlag dispatchFlag;
		[SerializeField]
		private bool autoLogin = true;
		[SerializeField]
		private bool autoLogout = true;
        [SerializeField]
		private int coreNo = 1;
		
		// TODO
		public Common.NEX_INIT_PARAM GetNexInitParam() { return default; }
	}
}