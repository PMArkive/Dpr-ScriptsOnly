namespace Dpr.Contest
{
	public class TapResultData
	{
		public TensionID tensionID;
		public int playerIndex;
		public bool isChangeTension;
		public bool isTensionUp;
		public bool isOverGauge;
		
		public void Reset()
		{
			playerIndex = 0;
			isChangeTension = false;
			isTensionUp = false;
			isOverGauge = false;
		}
	}
}