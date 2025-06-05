using Dpr.Message;
using Pml;

namespace Dpr.Contest
{
	public class ResultPlayerData
	{
		public bool isBestPlayer;
		public int playerIndex;
		public string userNickName;
		public string localizeNickName;
		public Sex playerSex;
		public MessageEnumData.MsgLangId playerLangID;
		public string partnerNickName;
		public Sex monsSex;
		public MessageEnumData.MsgLangId monsLangID;
		public int visualScore;
		public int danceScore;
		public int wazaScore;
		public int bestTimingCount;
		public int greatTimingCount;
		public int niceTimingCount;
		public int missTimingCount;
	}
}