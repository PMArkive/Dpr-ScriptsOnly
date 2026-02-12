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
		
		public void SetPointDatas(GMSPointDataModel[] pointDataModelArray)
		{
			this.pointDataModelArray = pointDataModelArray;
			var uVar1 = new int[pointDataModelArray.Length];
			this.Length = uVar1;
			GMS_GMSPointDataContainer.RemapRefDataIndex();
		}
		
		// TODO
		public void RemapRefDataIndex() { }
	}
}