using Pml;

namespace Dpr.GMS
{
	public class PointHistoryDataModel : PointHistoryData
	{
		private bool bIsNew;
		
		public int DataIndex { get => dataIndex; }
		
		public void SetDataIndex(int dataIndex)
		{
			this.dataIndex = dataIndex;
		}
		
		// TODO
		public string GetMonsNickname() { return default; }
		
		public void SetMonsNickname(string nickName)
		{
			Text_StringBuilder.Clear(this.receiveMonsNicknameSb);
			Text_StringBuilder.Append(this.receiveMonsNicknameSb,nickName);
		}
		
		// TODO
		public string GetMonsName() { return default; }
		
		public void SetMonsName(string monsName)
		{
			Text_StringBuilder.Clear(this.receiveMonsNameSb);
			Text_StringBuilder.Append(this.receiveMonsNameSb,monsName);
		}
		
		// TODO
		public string GetParentName() { return default; }
		
		public void SetParentName(string parentName)
		{
			Text_StringBuilder.Clear(this.receiveMonsParentNameSb);
			Text_StringBuilder.Append(this.receiveMonsParentNameSb,parentName);
		}
		
		// TODO
		public string GetDateTimeStr() { return default; }
		
		public void SetDateTimeStr(string dateTimeStr)
		{
			Text_StringBuilder.Clear(this.dateTimeSb);
			Text_StringBuilder.Append(this.dateTimeSb,dateTimeStr);
		}
		
		public bool IsNew { get => bIsNew; }
		
		// TODO
		public void SetNewFlag(bool flag) { }
		
		public IntermediatePointData GetPointData { get => currentPointData; }
		public MonsNo ReceiveMonsNo { get => currentPointData?.receiveMonsNo ?? MonsNo.NULL; }
		public uint ReceiveFormNo { get => currentPointData?.receiveMonsFormNo ?? 0; }
		
		public void SetPointData(IntermediatePointData pointData)
		{
			this.currentPointData = pointData;
		}
		
		public void ClearData()
		{
			this.dataIndex = 0xffffffff;
			this.currentPointData = 0;
			this.sendMonsIconSpr = 0;
			this.Length = 0;
			this[0] = 0;
			this.receiveMonsLangIconSpr = 0;
			this.receiveMonsParentLangIconSpr = 0;
			if (this.receiveMonsNameSb != 0) {
			  Text_StringBuilder.Clear(this.receiveMonsNameSb);
			}
			if (this.receiveMonsNicknameSb != 0) {
			  Text_StringBuilder.Clear(this.receiveMonsNicknameSb);
			}
			if (this.receiveMonsParentNameSb != 0) {
			  Text_StringBuilder.Clear(this.receiveMonsParentNameSb);
			}
			if (this.dateTimeSb != 0) {
			  Text_StringBuilder.Clear(this.dateTimeSb);
			}
		}
	}
}