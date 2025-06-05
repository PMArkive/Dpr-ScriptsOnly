using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.DigFossil
{
	public class DigBoard : MonoBehaviour, IDigBoard
	{
		[SerializeField]
		[Range(0.0f, 100.0f)]
		private int boxRatio = 50;
		[SerializeField]
		private GridLayoutGroup grid;
		[SerializeField]
		private DigMasterDataManager masterData;
		[SerializeField]
		private DigAudioManager audioManager;
		[SerializeField]
		private DigEffectManager effectManager;
		[SerializeField]
		private DigVibration vibration;

		public const int DIGMAP_SIZE = 130;
		private const int DIGMAP_WIDTH = 13;
		private const int DIGMAP_HEIGHT = 10;
		private const int PARTS_NUM_MAX = 8;
		private const int PARTS_TREASURE_NUM_MAX = 4;
		private const int DEPOSIT_EMPTY = -1;
		
		public Vector2 GridSize { get; set; }
		public Vector2 FieldSize { get; set; }
		public Vector2 FieldOffset { get; set; }
		public int[,] BuildupMap { get; } = new int[DIGMAP_HEIGHT, DIGMAP_WIDTH];
        public int[,] DepositMap { get; } = new int[DIGMAP_HEIGHT, DIGMAP_WIDTH];
		public List<DigDepositViewManager.PlacementInfo> DepositPlacementInfos { get; } = new List<DigDepositViewManager.PlacementInfo>();
		public DigMasterDataManager.RatioId RatioId { get; set; }

        private int dugOutOrder;
        private bool isInitialized;

        // TODO
        public void Initialize() { }
		
		// TODO
		public int CalcMapColumnIndex(float x) { return default; }
		
		// TODO
		public int CalcMapRowIndex(float y) { return default; }
		
		// TODO
		public int GetDepositCount() { return default; }
		
		// TODO
		public int GetDigOutItemCount() { return default; }
		
		// TODO
		public bool IsCheckDigOutAll() { return default; }
		
		// TODO
		public bool IsCheckDigOut() { return default; }
		
		// TODO
		public uint[] GetDigItemNumbers() { return default; }
		
		// TODO
		public void Dig(Vector2 pos, bool bIsPickaxe, bool bIsAdjacent = true, int cursorNum = -1) { }
		
		// TODO
		public void RandomDig(bool bIsPickaxe) { }
		
		// TODO
		private void Dig(int mapX, int mapY, bool bIsPickaxe, bool bIsAdjacent = true) { }
		
		// TODO
		private void DigWithAnimation(Vector2 position, int cursorNum, bool bIsPickaxe, bool bIsAdjacent = true) { }
		
		// TODO
		private bool DigMap(int mapX, int mapY, int digNum) { return default; }
		
		// TODO
		private bool DigHumerOrPickaxe(int mapX, int mapY, bool bIsPickaxe) { return default; }
		
		// TODO
		private void PlayDigEffect(int cursorNum, bool bIsPickaxe, bool bIsBuildupBroken) { }
		
		// TODO
		private void CheckDigOut() { }
		
		// TODO
		private bool IsCheckDigOut(DigDepositViewManager.PlacementInfo info) { return default; }
		
		// TODO
		private DigDepositViewManager.PlacementInfo GetDeposit(int x, int y) { return default; }
		
		// TODO
		private void RandomDeposit() { }
		
		// TODO
		private int GetTreasurePartsRandomMax<T>(in List<T> inList, DigMasterDataManager.RatioId id) { return default; }
		
		// TODO
		private int GetTreasurePartsRandom<T>(in List<T> inList, DigMasterDataManager.RatioId id, int random) { return default; }
		
		// TODO
		private bool PartsDeposit<T>(in List<T> inList, int partsIndex, int x, int y) { return default; }
		
		// TODO
		private bool IsAttribute(in DigMasterDataManager.IDeposit inDeposit, int x, int y) { return default; }
		
		// TODO
		private bool IsFreeDiposit() { return default; }
		
		// TODO
		private void RandomBuildUp() { }
	}
}