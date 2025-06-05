using Dpr.SubContents;
using UnityEngine;

namespace Dpr.Field.Walking
{
	public class CorTest : MonoBehaviour
	{
		private ICorSystem corSys;
		private CorSystemContainer container;

		[Button("Test", "Test", new object[0])]
		public int Button04;
		[Button("Pause", "Pause", new object[0])]
		public int Button05;
		[Button("Restart", "Restart", new object[0])]
		public int Button06;
		[Button("Cancel", "Cancel", new object[0])]
		public int Button07;
		[Button("DeltaTimePause", "DeltaTimePause", new object[0])]
		public int Button08;
		[Button("SubCancel", "SubCancel", new object[0])]
		public int Button09;

		[SerializeField]
		private int SubNo;
		
		// TODO
		private void Awake() { }
		
		// TODO
		private void Test() { }
		
		// TODO
		private void Cancel() { }
		
		// TODO
		private void Pause() { }
		
		// TODO
		private void Restart() { }
		
		// TODO
		private void DeltaTimePause() { }
		
		// TODO
		private void SubCancel() { }
	}
}