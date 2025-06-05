using DPData;
using UnityEngine;

namespace Dpr.SecretBase
{
	public struct StatueItemData
	{
		public int statueId;
		public int pedestalId;
		public int dir;
		public Vector2Int pos;
		
		public StatueItemData(int statueId)
		{
			this.statueId = statueId;

			pedestalId = -1;
			dir = (int)Dir.Forward;
			pos = new Vector2Int(0, 0);
		}
		
		public StatueItemData(UgStoneStatue saveData)
		{
			statueId = saveData.statueId;
			pedestalId = saveData.pedestalId;
			dir = saveData.dir;
			pos = new Vector2Int(saveData.posX, saveData.posY);
		}
		
		public UgStoneStatue ToSaveData()
		{
			return new UgStoneStatue()
			{
				statueId = statueId,
				pedestalId = pedestalId,
				posX = pos.x,
				posY = pos.y,
				dir = dir,
			};
		}
	}
}