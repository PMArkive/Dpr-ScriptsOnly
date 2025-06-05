using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLSXContent;

namespace Dpr.UnderGround
{
	public class UgFieldDataManager
	{
		public List<FossilPosData> FossilPosDataList = new List<FossilPosData>(23); // TODO: Find a constant for this?
		public List<UnderGroundFossilNum.SheetData> FossilNumData;

		private const string Path_MasterData = "masterdata";

		public Object[] SecretBaseHoles = new Object[7]; // TODO: Find a constant for this?
        public Object Hyouta;
		
		// TODO
		public void Destroy() { }
		
		// TODO
		public Object GetSecretBaseObject() { return default; }
		
		// TODO
		public IEnumerator LoadMD() { return default; }
		
		// TODO
		public IEnumerator LoadAsset() { return default; }
		
		// TODO
		public UgFieldDataManager() { }

		public struct FossilPosData
		{
			public ZoneID zoneID;
			public UnderGroundFossilPos.SheetData[] PosDataList;
			
			public FossilPosData(UnderGroundFossilPos.SheetData[] data)
			{
				PosDataList = data;
				zoneID = data[0].ZoneID;
			}
			
			// TODO
			public Vector2Int GetRandomPos(int pointNo) { return default; }
			
			// TODO
			public bool CheckWallPos(Vector2Int grid, out DIR wallDir)
			{
				wallDir = default;
				return default;
			}
			
			// TODO
			public DIR CheckRightOrLeft(Vector2Int wallGrid) { return default; }
		}
	}
}