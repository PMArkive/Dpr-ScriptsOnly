using UnityEngine;

namespace Dpr.NetworkUtils
{
	public struct JoinData
	{
		public byte avatarId;
		public byte colorId;
		public byte cassetVersion;
		public short InitRotY;
		public Vector3 InitPos;
	}
}