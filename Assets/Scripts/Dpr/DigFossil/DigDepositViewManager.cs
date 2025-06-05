using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

namespace Dpr.DigFossil
{
	public class DigDepositViewManager : MonoBehaviour, IDigDepositViewManager
	{
		[SerializeField]
		private GameObject depositPrefab;
		[SerializeField]
		private SpriteAtlas atlas;
		[SerializeField]
		private DigBoard board;
		[SerializeField]
		private DigEffectManager effectManager;
		private Material depositMaterial;
		
		// TODO
		public IEnumerator Load() { return default; }
		
		// TODO
		public void Initialize(List<PlacementInfo> placementList) { }

		public class PlacementInfo
		{
			public DigMasterDataManager.IDeposit deposit;
			public int column;
			public int row;
			public int dugOutOrder;
			public IDigDeposit view;
			public bool bIsFound;
			
			public PlacementInfo(DigMasterDataManager.IDeposit deposit, int column, int row)
			{
				this.deposit = deposit;
				this.view = null;
				this.column = column;
				this.row = row;
				this.dugOutOrder = 0;
				this.bIsFound = false;
			}
		}
	}
}