using Dpr.SubContents;
using Pml.PokePara;
using UnityEngine;

namespace Dpr.FureaiHiroba
{
	public class FureaiDebugSettings : MonoBehaviour
	{
		[Button("AAA", "▼連れ歩きアクション関連", new object[0])]
		public int Button01;

		public static float _Time_ActionInterval = 5.0f;
		[SerializeField]
		private float Time_ActionInterval;

		public static bool _StopOnly;
		[SerializeField]
		private bool StopOnly;

		public static bool _KyoroOnly;
		[SerializeField]
		private bool KyoroOnly;

		[Button("AAA", "▼さんぽアクション関連", new object[0])]
		public int Button03;

		public static bool _WaitKyoroOnly;
		[SerializeField]
		private bool WaitKyoroOnly;

		public static bool _UroUroOnly;
		[SerializeField]
		private bool UroUroOnly;

		public static bool _RunOnly;
		[SerializeField]
		private bool RunOnly;

		public static bool _SleepOnly;
		[SerializeField]
		private bool SleepOnly;

		[Button("AAA", "▼なかよし、性格関連", new object[0])]
		public int Button02;

		public static bool _Enable;
		[SerializeField]
		private bool Enable;

		public static uint _Nakayoshi;
		[SerializeField]
		[Range(0.0f, 255.0f)]
		private uint Nakayoshi;

		public static Seikaku _Seikaku;
		[SerializeField]
		private Seikaku Seikaku;

		public static string _TalkText;
		[SerializeField]
		private string TalkText;
		
		private void OnValidate()
		{
			_Time_ActionInterval = Time_ActionInterval;
			_KyoroOnly = KyoroOnly;
			_StopOnly = StopOnly;
			_Nakayoshi = Nakayoshi;
			_Seikaku = Seikaku;
			_Enable = Enable;
			_TalkText = TalkText;
			_WaitKyoroOnly = WaitKyoroOnly;
			_UroUroOnly = UroUroOnly;
			_RunOnly = RunOnly;
			_SleepOnly = SleepOnly;
		}
		
		private void AAA()
		{
			// Empty
		}
	}
}