using Dpr.Message;
using Dpr.SubContents;
using Pml.PokePara;
using System.Collections;
using UnityEngine;

namespace Dpr.Demo
{
	public class Demo_Trade : DemoBase
	{
		private TimeLineBinder timeLine;
		public PokemonParam MyPokeParam_Copy;
		public PokemonParam FriendPokeParam_Copy;
		public UnionTradeManager.BoxPokeData FriendPokeParam;
		private TradeState nowState;
		private Param _param;
		private MarkerReceiver receiver;
		private bool isTimelineComplete;
		public int Debug_RemoveEffectsNum;
		public bool UsePreGetCheck;
		public bool IsGetMonsNo;
		public bool IsGetEvolvedMonsNo;
		private float[] displayTime = new float[] { 3.0f, 3.5f, 1.5f };
		
		public Demo_Trade()
		{
			UseCamera = true;
			FadeColor = Color.black;
			DisableEnvironmentController = false;
			isDisablePostProcess = true;
			isDisableMainCamera = true;
		}
		
		// TODO
		public override void Destroy() { }
		
		// TODO
		public void SetParam(int myId, int friendId, string friendName, bool isMiracle = false, MessageEnumData.MsgLangId msgLangId = MessageEnumData.MsgLangId.JPN) { }
		
		// TODO
		public override IEnumerator Enter() { return default; }
		
		// TODO
		public override IEnumerator Main() { return default; }
		
		// TODO
		public override IEnumerator Exit() { return default; }
		
		// TODO
		private void SetMessage() { }
		
		// TODO
		private void GoNextState() { }

		private enum TradeState : int
		{
			Start = 0,
			Recive1 = 1,
			Recive2 = 2,
		}

		public class Param
		{
			public int myTranerId;
			public int friendTranerId;
			public string friendTranerName;
			public bool isMiracle;
			public MessageEnumData.MsgLangId langId;
		}
	}
}