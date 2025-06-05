using Dpr.Message;

namespace Dpr.GMS
{
	public class TradeResultData
	{
		public int year;
		public byte month;
		public byte day;
		public SendMonsDataModel sendData;
		public ReceiveMonsDataModel receiveData;
		public string parentName = string.Empty;
		public MessageEnumData.MsgLangId parentLangId = MessageEnumData.MsgLangId.JPN;
		
		public TradeResultData()
		{
			sendData = new SendMonsDataModel();
			receiveData = new ReceiveMonsDataModel();

			Clear();
		}
		
		// TODO
		public void Clear() { }
	}
}