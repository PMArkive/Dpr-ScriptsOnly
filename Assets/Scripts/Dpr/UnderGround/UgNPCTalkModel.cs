using Dpr.MsgWindow;
using System;
using XLSXContent;

namespace Dpr.UnderGround
{
	public class UgNPCTalkModel
	{
		public bool NPCTalking;
		public bool NPCTalkEnd;
		public string talkMessageLabel;
		private UgNpcList.SheetSheet1 NpcData;
		private MsgWindow.MsgWindow window;
		private MsgWindowParam msgParam;
		private bool isShowFinishedMessage;
		private int seq;
		
		public byte NPC_ID { get => (byte)NpcData.NpcId; }
		public string NameLabel { get => NpcData.NameLabel; }
		
		// TODO
		public void InputUpdate(float deltaTime) { }
		
		// TODO
		private void SetShowFinished(MsgWindowParam param) { }
		
		public UgNPCTalkModel(UgNpcList.SheetSheet1 Npc)
		{
			NpcData = Npc;

			var arr = Array.FindAll(UgResManager.UgNpcTalk.Sheet1, x => !x.IsPatch);
			var npcTalk = arr[UnityEngine.Random.Range(0, arr.Length)];

            talkMessageLabel = Npc.Sex == Pml.Sex.MALE ? npcTalk.MaleTalkLabel : npcTalk.FemaleTalkLabel;
		}
		
		// TODO
		public void Aisatsu() { }
		
		// TODO
		public void JikoSyoukai() { }
		
		// TODO
		public void TalkMessage() { }
	}
}