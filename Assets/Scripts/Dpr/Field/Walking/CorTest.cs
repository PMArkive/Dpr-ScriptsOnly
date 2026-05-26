using Dpr.FureaiHiroba;
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
		
		private void Awake()
		{
			corSys?.Cancel();

			container = new CorSystemContainer("メイン"); // Main
			corSys = container;
		}
		
		private void Test()
		{
			var strs = new string[] { "A", "B", "C", "D", "E" };
			var fullStr = "攻撃" + strs[Random.Range(0, 5)];
			var text = FureaiDebugManager.CreateText(fullStr);

			var sub = container.AddWait(5.0f, corSys => text.text = corSys.CorName + ":" + corSys.duration.ToString(), fullStr);
			sub.onFinished += () => Destroy(text.gameObject);

			if (!container.isPlaying)
				container.Play();
        }
		
		private void Cancel()
		{
			corSys.Cancel();
		}
		
		private void Pause()
		{
			corSys.Pause();
		}
		
		private void Restart()
		{
			corSys.Restart();
		}
		
		private void DeltaTimePause()
		{
			if (DeltaTime.isPause)
				DeltaTime.UnPause();
			else
				DeltaTime.Pause();
		}
		
		private void SubCancel()
		{
			container.SubCancel(SubNo);
		}
	}
}