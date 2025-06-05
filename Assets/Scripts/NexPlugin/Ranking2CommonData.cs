using System.Collections.Generic;

namespace NexPlugin
{
	public class Ranking2CommonData
	{
		internal List<byte> binaryData;
		internal string userName;
		
		public Ranking2CommonData()
		{
			userName = "";
			binaryData = new List<byte>();
		}
		
		// TODO
		public string GetUserName() { return default; }
		
		// TODO
		public void SetUserName(string userName_) { }
		
		// TODO
		public List<byte> GetBinaryData() { return default; }
		
		// TODO
		public void SetBinaryData(List<byte> binaryData_) { }
		
		// TODO
		public void Reset() { }
		
		// TODO
		public void Trace() { }
		
		// TODO
		public override string ToString() { return default; }
	}
}