using System.Collections.Generic;
using UnityEngine;

namespace Dpr.DigFossil
{
	public interface IDigBoard
	{
		void Initialize();
		
		Vector2 GridSize { get; }
		
		Vector2 FieldSize { get; }
		
		Vector2 FieldOffset { get; }
		
		int[,] BuildupMap { get; }
		
		int[,] DepositMap { get; }
		
		List<DigDepositViewManager.PlacementInfo> DepositPlacementInfos { get; }

		void Dig(Vector2 pos, bool bIsPickaxe, bool bIsAdjacent, int cursorNum);

		void RandomDig(bool bIsPickaxe);

		int CalcMapColumnIndex(float x);

		int CalcMapRowIndex(float y);

		bool IsCheckDigOutAll();

		int GetDepositCount();
		
		DigMasterDataManager.RatioId RatioId { get; }
	}
}