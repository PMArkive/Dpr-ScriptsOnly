using System;
using UnityEngine;

namespace NexAssets
{
	[Serializable]
	public class NpDateTime
	{
		[SerializeField]
		private byte day;
		[SerializeField]
		private byte hour;
		[SerializeField]
		private byte minute;
		[SerializeField]
		private byte month;
		[SerializeField]
		private byte second;
		[SerializeField]
		private short year;
		
		// TODO
		public void Validate() { }
		
		// TODO
		public NpDateTime GetNpDateTime() { return default; }
	}
}