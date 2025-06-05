namespace Dpr.Battle.Logic
{
	public class BATTLE_RESULT_DATA
	{
		public BtlResult result;
		public byte fairyGymResult;
		public bool honooGymResult_wonByPlayer;
		public uint turnNum;
		public byte sakasaPoint;
		public byte sakasaSpFlag;
		public BATTLE_TVNAVI_DATA tvNaviData = new BATTLE_TVNAVI_DATA();
		public ushort captureMonsNo;
	}
}