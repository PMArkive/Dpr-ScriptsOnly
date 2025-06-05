using GameData;
using Pml;
using Pml.PokePara;
using UnityEngine;
using XLSXContent;

namespace Dpr.SecretBase
{
	public class StatueEffectData
	{
		public ushort statueId { get => rawData.statueId; }
		public int ugItemId { get => rawData.UgItemID; }
		public MonsNo monsId { get => (MonsNo)rawData.monsId; }
		public byte rarity { get => rawData.rarity; }
		public byte width { get => rawData.width; }
		public byte height { get => rawData.height; }
		public sbyte type1Id { get => rawData.type1Id; }
		public sbyte type2Id { get => rawData.type2Id; }
		public short[] PokeTypeEffect { get; } = new short[(int)PokeType.NUMS];
		public int MSLabelId { get => rawData.MSLabelId; }
		public Vector3 offset { get => rawData.offset; }
		public float cameraDistance { get => rawData.cameraDistance; }
		public bool isNormal { get => rawData.rarity == 1; }
		public bool isLegend { get => rawData.rarity == 5; }
		public bool isShiny { get => rawData.rarity == 2 || rawData.rarity == 3; }
		public byte shader { get => rawData.shader; }
		public string motionId { get => rawData.motion; }
		public float motionFrame { get => rawData.frame; }
		public ushort formNo { get => rawData.FormNo; }
		public Sex sex { get => rawData.Sex; }
		public bool isRarePoke { get => rawData.Rare; }
		public bool isRareIcon { get => rawData.rarity == 2; }
		public RareType rareType { get => rawData.Rare ? RareType.CAPTURED : RareType.NOT_RARE; }
		public StatueEffectRawData.Sheettable rawData { get; }
		
		public StatueEffectData(StatueEffectRawData.Sheettable inRawData)
		{
			rawData = inRawData;

			if (inRawData.type1Id > -1)
				PokeTypeEffect[inRawData.type1Id] = inRawData.pokeTypeEffect[0];

			if (inRawData.type2Id > -1)
				PokeTypeEffect[inRawData.type2Id] = inRawData.pokeTypeEffect[1];
		}
		
		public PokemonInfo.SheetCatalog GetPokeCatalog()
		{
			return DataManager.GetPokemonCatalog(monsId, formNo, sex, isRarePoke);
		}
	}
}