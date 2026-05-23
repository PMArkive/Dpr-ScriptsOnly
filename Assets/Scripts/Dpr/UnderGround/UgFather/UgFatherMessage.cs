using Dpr.Message;
using Dpr.MsgWindow;
using Pml.UgFather;
using System;

namespace Dpr.UnderGround.UgFather
{
	public static class UgFatherMessage
	{
		public static void ShowHealingChoices(Action onFinishedShowAllMessage, Action onFinishedCloseWindow)
        {
            MsgWindowManager.OpenMsg(CreateParam("DLP_underground_533", onFinishedShowAllMessage, onFinishedCloseWindow));
        }
		
		public static void ShowHealingBegin(Action onFinishedShowAllMessage, Action onFinishedCloseWindow)
		{
			MessageWordSetHelper.SetPlayerNickNameWord(0);
			MsgWindowManager.OpenMsg(CreateParam("DLP_underground_535", onFinishedShowAllMessage, onFinishedCloseWindow));
		}
		
		public static void ShowHealingEnd(Action onFinishedShowAllMessage, Action onFinishedCloseWindow)
		{
            MessageWordSetHelper.SetPlayerNickNameWord(0);
            MsgWindowManager.OpenMsg(CreateParam("DLP_underground_536", onFinishedShowAllMessage, onFinishedCloseWindow));
        }
		
		public static void Close()
		{
			MsgWindowManager.CloseMsg();
		}
		
		private static MsgWindowParam CreateParam(string labelName, Action onFinishedShowAllMessage, Action onFinishedCloseWindow)
		{
			return new MsgWindowParam()
            {
                useMsgFile = MessageManager.Instance.GetMsgFile(UgFatherDataManager.UNDER_GROUND_MSBT_NAME),
				labelName = labelName,
                onFinishedShowAllMessage = onFinishedShowAllMessage,
                onFinishedCloseWindow = onFinishedCloseWindow,
            };
        }
	}
}