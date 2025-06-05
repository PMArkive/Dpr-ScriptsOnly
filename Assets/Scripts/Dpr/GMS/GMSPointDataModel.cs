using UnityEngine;

namespace Dpr.GMS
{
	public class GMSPointDataModel : GMSPointData
	{
		private Vector2 screenPos;
		private Vector3 normal;
		private int dataCount;
		private int markIndex;
		private bool bIsView;
		private bool bHasData;
		private bool bHasNewData;
		
		// TODO
		public void CreateData(ushort index, string pointTitle, in Vector3 point) { }
		
		public PointHistoryDataModel[] HistoryDataArray { get => historyDataArray; }
		public bool HasData { get => bHasData; }
		public bool IsMaxData { get => dataCount >= GMSDataConstants.POINT_HISTORY_DATA_NUM; }
		public int DataCount { get => dataCount; }
		public bool HasNewData { get => bHasNewData; }
		public int MarkIndex { get => markIndex; }
		
		// TODO
		public void ResetMarkIndex() { }
		
		// TODO
		public void ResetAllNewFlag() { }
		
		// TODO
		public PointHistoryDataModel GetHistoryDataByIndex(int index) { return default; }
		
		// TODO
		public PointHistoryDataModel GetMarkHistoryData() { return default; }
		
		// TODO
		public void SetHistoryData(int index, PointHistoryDataModel newHistoryData) { }
		
		// TODO
		public void AddHistoryData(PointHistoryDataModel newHistoryData) { }
		
		// TODO
		private void CheckHasNewFlagData() { }
		
		// TODO
		public void ChangeMarkHistoryData(int newMarkIndex) { }
		
		// TODO
		public void MoveTopNewHistoryData() { }
		
		// TODO
		public void DeleteHistoryData(int index) { }
		
		// TODO
		private void CheckHasHistoryData() { }
		
		// TODO
		public void SortHistoryData() { }
		
		// TODO
		public Sprite GetPointMarkIconSpr() { return default; }
		
		public Vector3 Normal { get => normal; }
		public bool IsView { get => bIsView; }
		public Vector2 ScreenPos { get => screenPos; }
		
		// TODO
		public void ChangeViewStatus(bool canView) { }
		
		// TODO
		public void SetScreenPosition(Vector2 screenPos) { }
	}
}