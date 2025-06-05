using System.Collections.Generic;
using UnityEngine;
using XLSXContent;

namespace Dpr.DigFossil
{
	public class DigMasterDataManager : MonoBehaviour
	{
		[SerializeField]
		private StoneBoxRawData boxRawData;
		[SerializeField]
		private DepositItemRawData itemRawData;
		[SerializeField]
		private HardStoneRawData hardStoneRawData;
		[SerializeField]
		private StatueEffectRawData statueEffectData;

		public List<StoneBoxData> StoneBoxDatas { get; } = new List<StoneBoxData>();
		public List<DepositItemData> DepositItemDatas { get; } = new List<DepositItemData>();
		public List<HardStoneData> HardStoneDatas { get; } = new List<HardStoneData>();
        public List<StatueEffectRawData.Sheettable> StatueEffectData { get; set; }

        public const short ITEM_ID_STONE_BOX = -10;
		public const short ITEM_ID_HARD_STONE = -100;
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public StatueEffectRawData.Sheettable GetStatueEffectData(short statueId) { return default; }
		
		// TODO
		public static T[,] ShapeRotationRight<T>(in T[,] inDst) { return default; }
		
		// TODO
		public static T[,] ShapeRotationRight<T>(in T[,] inDst, int count) { return default; }
		
		// TODO
		private static char[,] ToShape(in string inShape) { return default; }

		public enum RatioId : int
		{
			Diamond = 0,
			Diamond_Dialga = 1,
			Diamond_Zenkoku = 2,
			Pearl = 3,
			Pearl_Palkia = 4,
			Pearl_Zenkoku = 5,
		}

		public interface IDeposit
		{
			char[,] Shape { get; }
			
			int Width { get; }
			
			int Height { get; }
			
			short ItemId { get; }
			
			bool IsDeposit { get; }
			
			bool IsStoneBox { get; }
			
			bool IsOnly { get; }
			
			string TextureName { get; }
			
			int NormalWidth { get; }
			
			int NormalHeight { get; }
			
			int Turn { get; }
			
			bool bIsRare { get; }
			
			short OffsetSize { get; }
			
			short OffsetX { get; }
			
			short OffsetY { get; }

			int GetRatio(RatioId id);
		}

		public class StoneBoxData : IDeposit
		{			
			public char[,] Shape { get; }
			public int Width { get; }
			public int Height { get; }
			public string TextureName { get; }
			public int NormalWidth { get; }
			public int NormalHeight { get; }
			public int Turn { get => 0; }
			public short ItemId { get => 0; }
			public bool IsDeposit { get => true; }
			public bool IsStoneBox { get => true; }
			public bool IsOnly { get => true; }
			public bool bIsRare { get => true; }
			public short OffsetSize { get; }
			public short OffsetX { get; }
			public short OffsetY { get; }
			public StoneBoxRawData.SheetBox RawData { get; }
			public string BoxModelName { get; }
			public short PokeType { get => RawData.type; }
			public short Reality { get => RawData.boxId; }
			
			public int GetRatio(RatioId id)
			{
				switch (id)
				{
					case RatioId.Diamond:        return RawData.ratio1;
					case RatioId.Diamond_Dialga: return RawData.ratio2;
					default:                     return 0;
				}
			}
			
			public StoneBoxData(in StoneBoxRawData.SheetBox inRawData)
			{
                RawData = inRawData;
                Shape = ToShape(inRawData.shape);
                Width = Shape.GetLength(1);
                Height = Shape.GetLength(0);
                NormalWidth = Width;
                NormalHeight = Height;
                TextureName = string.Format("dig_dep_box_{0:D2}_{1:D2}", PokeType, Reality);
                BoxModelName = string.Format("objects/ob20{0:D2}_{1:D2}", Reality, PokeType);
            }
		}

		public class DepositItemData : IDeposit
		{
			public char[,] Shape { get; }
			public int Width { get; }
			public int Height { get; }
			public short ItemId { get => rawData.itemId; }
			public string TextureName { get; }
			public int NormalWidth { get; }
			public int NormalHeight { get; }
			public int Turn { get; }
			public bool IsDeposit { get => true; }
			public bool IsStoneBox { get => false; }
			public bool IsOnly { get => rawData.bIsOnly; }
			public bool bIsRare { get => rawData.bIsRare; }
			public string ResultTextureName { get; }
			public short OffsetSize { get => rawData.offsetSize; }
			public short OffsetX { get => rawData.offsetX; }
			public short OffsetY { get => rawData.offsetY; }
			public int LabelId { get => rawData.MSLabelId; }

            private readonly DepositItemRawData.SheetDeposit rawData;

            public int GetRatio(RatioId id)
			{
				int ratio;
                switch (id)
                {
                    case RatioId.Diamond:
                        ratio = rawData.ratio1;
						break;

                    case RatioId.Diamond_Dialga:
                        ratio = rawData.ratio2;
                        break;

                    case RatioId.Diamond_Zenkoku:
                        ratio = rawData.ratio3;
                        break;

                    case RatioId.Pearl:
                        ratio = rawData.ratio4;
                        break;

                    case RatioId.Pearl_Palkia:
                        ratio = rawData.ratio5;
                        break;

                    case RatioId.Pearl_Zenkoku:
                        ratio = rawData.ratio6;
                        break;

                    default:
						return 0;
                }

                if (rawData.turn + 1 == 0)
                    return 0;
                else
                    return ratio / (rawData.turn + 1);
            }
			
			public DepositItemData(in DepositItemRawData.SheetDeposit inRawData)
			{
				rawData = inRawData;
				Shape = ToShape(inRawData.shape);
				Width = Shape.GetLength(1);
				NormalHeight = Shape.GetLength(0);
				Turn = 0;
				Height = NormalHeight;
				NormalWidth = Width;
				TextureName = string.Format("dig_dep_{0:D3}_{1:D1}", ItemId, Turn);
				ResultTextureName = string.Format("dig_item_{0:D3}", ItemId);
            }
			
			public DepositItemData(in DepositItemData inDst, int turn)
			{
				rawData = inDst.rawData;
				Shape = ShapeRotationRight(inDst.Shape, turn);
                Width = Shape.GetLength(1);
                Height = Shape.GetLength(0);
                NormalWidth = inDst.NormalWidth;
                NormalHeight = inDst.NormalHeight;
				Turn = turn;
                TextureName = string.Format("dig_dep_{0:D3}_{1:D1}", ItemId, Turn);
				ResultTextureName = inDst.ResultTextureName;
            }
		}

		public class HardStoneData : IDeposit
		{
			public char[,] Shape { get; }
			public int Width { get; }
			public int Height { get; }
			public short ItemId { get => ITEM_ID_HARD_STONE; }
			public string TextureName { get; }
			public int NormalWidth { get; }
			public int NormalHeight { get; }
			public int Turn { get; }
			public bool IsDeposit { get => false; }
			public bool IsStoneBox { get => false; }
			public bool IsOnly { get => false; }
			public bool bIsRare { get => false; }
			public short OffsetSize { get; }
			public short OffsetX { get; }
			public short OffsetY { get; }

            private readonly HardStoneRawData.SheetHardStone rawData;

            public int GetRatio(RatioId id)
			{
				return 0;
			}
			
			public HardStoneData(in HardStoneRawData.SheetHardStone inRawData)
			{
                rawData = inRawData;
                Shape = ToShape(inRawData.shape);
                Width = Shape.GetLength(1);
                Height = Shape.GetLength(0);
                Turn = 0;
                NormalWidth = Width;
                NormalHeight = Height;
				TextureName = rawData.textureName + "_" + 0;
            }
			
			public HardStoneData(in HardStoneData inDst, int turn)
			{
                rawData = inDst.rawData;
                Shape = ShapeRotationRight(inDst.Shape, turn);
                Width = Shape.GetLength(1);
                Height = Shape.GetLength(0);
                NormalWidth = inDst.NormalWidth;
                NormalHeight = inDst.NormalHeight;
				Turn = turn;
                TextureName = rawData.textureName + "_" + turn;
            }
		}
	}
}