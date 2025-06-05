using UnityEngine;

namespace Dpr.NetworkUtils
{
	public struct PosData
	{
		private ushort posX;
		private ushort posZ;
		public short rotY;
		
		public Vector2 pos
		{
			get => new Vector2(-posX * 0.05f, posZ * 0.05f);
			set
			{
				posX = (ushort)(int)Mathf.Abs(value.x * 20.0f);
				posZ = (ushort)(int)Mathf.Abs(value.y * 20.0f);
			}
		}
	}
}