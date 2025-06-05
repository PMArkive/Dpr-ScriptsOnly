using Dpr.Trainer;
using Pml.PokePara;
using Pml;
using System.Collections;
using XLSXContent;
using GameData;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using Dpr.Battle.Logic;
using Dpr.BallDeco;

public static class TrainerSystem
{
    private static CompTowerMatching _comparerTowerMatching = new CompTowerMatching();
    private static CompTowerSingleStock _comparerTowerSingleStock = new CompTowerSingleStock();
    private static CompTowerDoubleStock _comparerTowerDoubleStock = new CompTowerDoubleStock();
    private static CompTowerTrainerPoke _compareTowerTrainerPoke = new CompTowerTrainerPoke();
    private static readonly TagTableElem[] TAG_TABLE = new TagTableElem[5]
    {
        new TagTableElem(TrainerType.FUTAGO_2,     TrainerType.FUTAGO_1,     TrainerType.BOY),
        new TagTableElem(TrainerType.LOVELOVE_2,   TrainerType.LOVELOVE_1,   TrainerType.BOY),
        new TagTableElem(TrainerType.DOUBLETEAM_2, TrainerType.DOUBLETEAM_1, TrainerType.BOY),
        new TagTableElem(TrainerType.FAMILY_2,     TrainerType.FAMILY_1,     TrainerType.BOY),
        new TagTableElem(TrainerType.INTERVIEW_2,  TrainerType.INTERVIEW_1,  TrainerType.BOY),
    };

    private static TowerTrainerTable TowerTrainerTable { get => DataManager.TowerTrainerTable; }
    private static TowerMatchingTable TowerMatchingTable { get => DataManager.TowerMatchingTable; }
    private static TowerSingleStockTable TowerSingleStockTable { get => DataManager.TowerSingleStockTable; }
    private static TowerDoubleStockTable TowerDoubleStockTable { get => DataManager.TowerDoubleStockTable; }

    // TODO
    public static PokemonParam createPokemon(in PokeParamForCreate pokeData, TowerTrainerTable.SheetTrainerData trainerData, TrainerTable.SheetTrainerType trainerTypeData, ulong personal_rand) { return null; }

    // TODO
    public static TowerLotResult CreateTowerLotResult(TowerLotRule lotRule, TowerLotCls lotCls, int rank, int round, ulong seed) { return null; }

    // TODO
    public static TowerLotResult CreateTowerLotResultByIndex(TowerLotRule lotRule, TowerLotCls lotCls, int rank, int round, int _index) { return null; }

    // TODO
    public static TowerTrainerTable.SheetTrainerData GetTowerTrainerData(TowerTrID towerTrId) { return null; }

    // TODO
    public static TowerTrainerTable.SheetTrainerPoke GetTowerPoke(uint pokeID) { return null; }

    // TODO
    public static TowerTrainerTable.SheetTrainerPoke GetTowerPokeByIndex(int index) { return null; }

    // TODO
    public static TowerMatchingTable.SheetTowerMatching GetTowerMatching(int matchingID) { return null; }

    // TODO
    public static TowerSingleStockTable.SheetTowerSingleStock GetTowerSingleStock(uint StockID) { return null; }

    // TODO
    public static TowerDoubleStockTable.SheetTowerDoubleStock GetTowerDoubleStock(uint StockID) { return null; }

    // TODO
    public static void GetTowerSingleStockRange(List<TowerSingleStockTable.SheetTowerSingleStock> recordList, uint StockIDMin, uint StockIDMax) { }

    // TODO
    public static void GetTowerDoubleStockRange(List<TowerDoubleStockTable.SheetTowerDoubleStock> recordList, uint StockIDMin, uint StockIDMax) { }

    // TODO
    private static bool getTowerSingleStockRange(out int outIndexMin, out int outIndexMax, uint StockIDMin, uint StockIDMax)
    {
        outIndexMin = 0;
        outIndexMax = 0;
        return false;
    }

    // TODO
    private static int getTowerSingleStockIndex(uint MatchingID) { return 0; }

    // TODO
    private static bool getTowerDoubleStockRange(out int outIndexMin, out int outIndexMax, uint StockIDMin, uint StockIDMax)
    {
        outIndexMin = 0;
        outIndexMax = 0;
        return false;
    }

    // TODO
    private static int getTowerDoubleStockIndex(uint MatchingID) { return 0; }

    // TODO
    public static int GetTowerMatchingID(TowerLotRule lotRule, TowerLotCls lotCls, int rank, int round) { return 0; }

    // TODO
    public static bool IsSingleTowerMatchinID(int id) { return false; }

    // TODO
    private static int LeftSegmentIndex(int index, int arrayLength) { return 0; }

    public static void CheckTowerTable()
    {
        // Empty
    }

    private static TrainerTable TrainerTable { get => DataManager.TrainerTable; }

    // TODO
    public static TrainerTable.SheetTrainerType GetTrainerType(TrainerType trainerType) { return null; }

    // TODO
    public static TrainerTable.SheetTrainerData GetTrainerData(TrainerID trainerID) { return null; }

    // TODO
    public static TrainerTable.SheetTrainerPoke GetTrainerPoke(TrainerID trainerID) { return null; }

    // TODO
    public static TrainerTable.SheetSealTemplate GetSealTemplate(SealTemplateID trainerSealId) { return null; }

    // TODO
    public static TrainerTable.SheetSkirtGraphicsChara GetSkirtGraphicsChara(string modelId) { return null; }

    // TODO
    public static void EncountTrainerPersonalDataMake(BSP_TRAINER_DATA pBattleTrainerData, TrainerID trainerID) { }

    // TODO
    public static void EncountTrainerPokeDataMake(PokeParty pPokeParty, PartyDesc pPartyDesc, TrainerID trainerID, CapsuleData[] capsuleDatas) { }

    // TODO
    public static void SetupSealTemplate(ref CapsuleData dst, SealTemplateID sealTemplateID, PokemonParam pp) { }

    // TODO
    private static void createPokeParty(PokeParty pPokeParty, TrainerTable.SheetTrainerPoke trainerPoke, TrainerTable.SheetTrainerData trainerData, TrainerTable.SheetTrainerType trainerTypeData, CapsuleData[] capsuleDatas) { }

    // TODO
    public static PokemonParam createPokemon(in PokeParamForCreate pokeData, TrainerTable.SheetTrainerData trainerData, TrainerTable.SheetTrainerType trainerTypeData, [Optional] PokeParty pokePartyForRndCheck) { return null; }

    // TODO
    private static bool FindPersnalRnd(PokeParty pokePartyForRndCheck, uint personal_rand) { return false; }

    // TODO
    private static void setupInitSpec(InitialSpec pInitSpec, in PokeParamForCreate pokeData, ulong personal_rand, byte trainerSex) { }

    // TODO
    private static void setupPokemon(PokemonParam pPokeParam, in PokeParamForCreate pokeData, TrainerTable.SheetTrainerType trainerTypeData, bool isApplyPPUp) { }

    // TODO
    private static void setupPokemon_Waza(PokemonParam pPokeParam, in PokeParamForCreate pokeData) { }

    // TODO
    private static void setupPokemon_WazaPPUp(PokemonParam pPokeParam) { }

    // TODO
    public static TrainerType GetTagTrainerType(TrainerType trtype1, TrainerType trtype2) { return TrainerType.INVALID; }

    public class CompTowerMatching : IComparer
    {
        // TODO
        public int Compare(object x, object y) { return 0; }
    }

    public class CompTowerSingleStock: IComparer
    {
        // TODO
        public int Compare(object x, object y) { return 0; }
    }

    public class CompTowerDoubleStock: IComparer
    {
        // TODO
        public int Compare(object x, object y) { return 0; }
    }

    public class CompTowerTrainerPoke: IComparer
    {
        // TODO
        public int Compare(object x, object y) { return 0; }
    }

    public struct PokeParamForCreate
    {
        public ushort MonsNo;
        public ushort FormNo;
        public bool IsRare;
        public byte Level;
        public Sex Sex;
        public byte Seikaku;
        public TokuseiNo TokuseiNo;
        public ushort Waza1;
        public ushort Waza2;
        public ushort Waza3;
        public ushort Waza4;
        public ushort Item;
        public BallId Ball;
        public byte TalentHp;
        public byte TalentAtk;
        public byte TalentDef;
        public byte TalentSpAtk;
        public byte TalentSpDef;
        public byte TalentAgi;
        public byte EffortHp;
        public byte EffortAtk;
        public byte EffortDef;
        public byte EffortSpAtk;
        public byte EffortSpDef;
        public byte EffortAgi;
        public SealTemplateID SealID;

        // TODO
        public bool Setup(TrainerTable.SheetTrainerPoke pokeData, int index) { return false; }

        // TODO
        public void Setup(TowerTrainerTable.SheetTrainerPoke pokeData) { }
    }

    private struct TagTableElem
    {
        public TrainerType typeA;
        public TrainerType typeB;
        public TrainerType tagType;

        public TagTableElem(TrainerType typeA, TrainerType typeB, TrainerType tagType)
        {
            this.typeA = typeA;
            this.typeB = typeB;
            this.tagType = tagType;
        }
    }
}