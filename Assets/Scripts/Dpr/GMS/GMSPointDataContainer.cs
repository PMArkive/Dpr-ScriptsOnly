namespace Dpr.GMS
{
	public class GMSPointDataContainer
	{
		private GMSPointDataModel[] pointDataModelArray;
		private int[] refDataIndexArray;
		private int hasDataNum;
		
		public GMSPointDataModel[] PointDatas { get => pointDataModelArray; }
		public int[] RefDataIndexArray { get => refDataIndexArray; }
		public int DataNum { get => pointDataModelArray.Length; }
		public int HasDataNum { get => hasDataNum; }
		
		// TODO
		public void SetPointDatas(GMSPointDataModel[] pointDataModelArray) { }
		
		// TODO
		public void RemapRefDataIndex() { }
	}
}