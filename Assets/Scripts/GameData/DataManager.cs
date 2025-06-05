using Pml.PokePara;
using Pml;
using System.Collections;
using System.Collections.Generic;
using XLSXContent;
using SmartPoint.AssetAssistant;
using Dpr.Battle.Logic;
using System;
using Dpr.MsgWindow;
using FieldCommon;
using Dpr.NetworkUtils;

namespace GameData
{
    public class DataManager
    {
        public static CharacterGraphics CharacterGraphics;
        public static TrainerTable TrainerTable;
        public static Dictionary<string, PlaceData> PlaceData;
        public static Dictionary<string, MapWarp> MapWarpData;
        public static Dictionary<string, StopData> StopData;
        public static GimmickGraphics GimmickGraphics;
        public static PokemonInfo PokemonInfo;
        public static ContestWazaInfo ContestWazaInfo;
        public static ShopTable ShopTable;
        public static CharacterDressData CharacterDressData;
        public static KinomiData KinomiData;
        public static KinomiPlaceData KinomiPlaceData;
        public static HoneyTree HoneyTree;
        public static MonohiroiTable MonohiroiTable;
        public static UgJumpPos UgJumpPos;
        public static TowerTrainerTable TowerTrainerTable;
        public static TowerMatchingTable TowerMatchingTable;
        public static TowerSingleStockTable TowerSingleStockTable;
        public static TowerDoubleStockTable TowerDoubleStockTable;
        public static AdventureNoteData AdventureNoteData;
        public static Dictionary<int, List<AdventureNoteData.SheetData>> AdventureNoteDataDict;
        public static TowerBattlePoint TowerBattlePoint;
        public static TagPlaceData TagPlaceData;
        public static LocalKoukanData LocalKoukanData;
        public static ContestCommonData ContestCommonData;
        public static TvDataTable TvDataTable;
        public static TvSchedule TvSchedule;
        public static OnPostLoadDataDelegate onPostLoadData;
        public static FieldCommonParam FieldCommonParam;
        public static FieldWazaCutInParam FieldWazaCutInParam;
        public static ZenmetuZone ZenmetuZone;
        public static MoveAfterSaveGrid MoveAfterSaveGrid;
        private static ComparerCatalog _comparerCatalog = new ComparerCatalog();
        private static ComparerKinomi _comparerKinomi = new ComparerKinomi();
        public static StatueEffectRawData statueEffectRawData;

        public static IEnumerator StartUpLoad()
        {
            CharacterGraphics = null;
            PlaceData = new Dictionary<string, PlaceData>();
            MapWarpData = new Dictionary<string, MapWarp>();
            StopData = new Dictionary<string, StopData>();

            // This is put through string.Format for some reason
            yield return Load(string.Format("masterdatas", new object[] { }));

            yield return Load_statueeffectdata();
        }

        public static IEnumerator Load(string assetBundleName)
        {
            AssetManager.AppendAssetBundleRequest(assetBundleName, true, null, null);
            yield return AssetManager.DispatchRequests((eventType, name, asset) =>
            {
                if (asset == null)
                    return;

                if (asset is CharacterGraphics)
                {
                    CharacterGraphics = asset as CharacterGraphics;
                }
                else if (asset is TrainerTable)
                {
                    TrainerTable = asset as TrainerTable;
                } 
                else if (asset is PlaceData)
                {
                    if (!PlaceData.ContainsKey(asset.name))
                        PlaceData.Add(asset.name, asset as PlaceData);
                    else
                        PlaceData[asset.name] = asset as PlaceData;
                }
                else if (asset is MapWarp)
                {
                    if (!MapWarpData.ContainsKey(asset.name))
                        MapWarpData.Add(asset.name, asset as MapWarp);
                    else
                        MapWarpData[asset.name] = asset as MapWarp;
                }
                else if (asset is StopData)
                {
                    if (!StopData.ContainsKey(asset.name))
                        StopData.Add(asset.name, asset as StopData);
                    else
                        StopData[asset.name] = asset as StopData;
                }
                else if (asset is MsgWindowData)
                {
                    MsgWindowManager.SetMsgWindowData(asset as MsgWindowData);
                }
                // TODO: Why is Instance null here?
                /*else if (asset is NetworkData)
                {
                    NetworkManager.Instance.SetupMasterData(asset as NetworkData);
                }*/
                else if (asset is ContestCommonData)
                {
                    ContestCommonData = asset as ContestCommonData;
                }
                else if (asset is GimmickGraphics)
                {
                    GimmickGraphics = asset as GimmickGraphics;
                }
                else if (asset is PokemonInfo)
                {
                    PokemonInfo = asset as PokemonInfo;
                }
                else if (asset is ContestWazaInfo)
                {
                    ContestWazaInfo = asset as ContestWazaInfo;
                }
                else if (asset is FieldCommonParam)
                {
                    FieldCommonParam = asset as FieldCommonParam;
                }
                else if (asset is FieldWazaCutInParam)
                {
                    FieldWazaCutInParam = asset as FieldWazaCutInParam;
                }
                else if (asset is ShopTable)
                {
                    ShopTable = asset as ShopTable;
                }
                else if (asset is CharacterDressData)
                {
                    CharacterDressData = asset as CharacterDressData;
                }
                else if (asset is KinomiData)
                {
                    KinomiData = asset as KinomiData;
                }
                else if (asset is KinomiPlaceData)
                {
                    KinomiPlaceData = asset as KinomiPlaceData;
                }
                else if (asset is HoneyTree)
                {
                    HoneyTree = asset as HoneyTree;
                }
                else if (asset is MonohiroiTable)
                {
                    MonohiroiTable = asset as MonohiroiTable;
                }
                else if (asset is UgJumpPos)
                {
                    UgJumpPos = asset as UgJumpPos;
                }
                else if (asset is TowerTrainerTable)
                {
                    TowerTrainerTable = asset as TowerTrainerTable;
                }
                else if (asset is TowerMatchingTable)
                {
                    TowerMatchingTable = asset as TowerMatchingTable;
                }
                else if (asset is TowerSingleStockTable)
                {
                    TowerSingleStockTable = asset as TowerSingleStockTable;
                }
                else if (asset is TowerDoubleStockTable)
                {
                    TowerDoubleStockTable = asset as TowerDoubleStockTable;
                }
                else if (asset is TowerBattlePoint)
                {
                    TowerBattlePoint = asset as TowerBattlePoint;
                }
                else if (asset is TagPlaceData)
                {
                    TagPlaceData = asset as TagPlaceData;
                }
                else if (asset is LocalKoukanData)
                {
                    LocalKoukanData = asset as LocalKoukanData;
                }
                else if (asset is TvDataTable)
                {
                    TvDataTable = asset as TvDataTable;
                }
                else if (asset is TvSchedule)
                {
                    TvSchedule = asset as TvSchedule;
                }
                else if (asset is AdventureNoteData)
                {
                    AdventureNoteData = asset as AdventureNoteData;
                    AdventureNoteDataDict = new Dictionary<int, List<AdventureNoteData.SheetData>>();

                    for (int i=0; i<AdventureNoteData.Data.Length; i++)
                    {
                        var item = AdventureNoteData.Data[i];

                        if (item.Version == 0 || item.Version == (PlayerWork.cassetVersion != CassetVersion.DPR_B ? 2 : 1))
                        {
                            AdventureNoteDataDict.TryGetValue(item.Category, out List<AdventureNoteData.SheetData> list);
                            if (list != null)
                                list.Add(item);
                            else
                                AdventureNoteDataDict.Add(item.Category, new List<AdventureNoteData.SheetData>() { item });
                        }
                    }
                }
                else if (asset is ZenmetuZone)
                {
                    ZenmetuZone = asset as ZenmetuZone;
                }
                else if (asset is MoveAfterSaveGrid)
                {
                    MoveAfterSaveGrid = asset as MoveAfterSaveGrid;
                }
            });

            TrainerSystem.CheckTowerTable();
            bool isAppendPml = PmlUse.Instance.AppendAssetBundleRequests();
            bool isAppendBattleData = BattleDataTableManager.Instance.AppendAssetBundleRequests();
            if (isAppendPml || isAppendBattleData)
            {
                yield return AssetManager.DispatchRequests((eventType, name, asset) =>
                {
                    if (isAppendPml)
                        PmlUse.Instance.OnDispatchRequests(eventType, name, asset);
                    if (isAppendBattleData)
                        BattleDataTableManager.Instance.OnDispatchRequests(eventType, name, asset);
                });

                PmlUse.Instance.OnAfterLoadAll();
                BattleDataTableManager.Instance.OnAfterLoadAll();
            }

            onPostLoadData?.Invoke();
            onPostLoadData = null;

            AssetManager.UnloadAssetBundle(assetBundleName);
        }

        public static bool IsLoaded()
        {
            return PmlUse.Instance.IsInitialized && CharacterGraphics != null;
        }

        public static PokemonInfo.SheetCatalog GetPokemonCatalog(MonsNo monsNo, int formNo, Sex sex, bool isRare, bool isEgg = false)
        {
            if (PokemonInfo == null)
                return null;

            if (isEgg && monsNo == MonsNo.MANAFI)
                return GetPokemonCatalog(120);
            else if (isEgg)
                return GetPokemonCatalog(20);
            else
                return GetPokemonCatalog((int)monsNo * 10000 + formNo * 100 + (int)sex * 10 + (isRare ? 1 : 0));
        }

        public static PokemonInfo.SheetCatalog GetPokemonCatalog(int uniqueId)
        {
            var result = Array.BinarySearch(PokemonInfo.Catalog, uniqueId, _comparerCatalog);
            if (result > -1)
                return PokemonInfo.Catalog[result];

            return null;
        }

        // TODO
        public static int GetUniqueID(PokemonParam pokemonParam) { return 0; }

        // TODO
        public static int GetUniqueID(MonsNo monsNo, int formNo, Sex sex, RareType rareType, bool isEgg) { return 0; }

        // TODO
        public static int GetUniqueID(MonsNo monsNo, int formNo, Sex sex, bool isRare, bool isEgg) { return 0; }

        // TODO
        public static bool IsEggByUniqueID(int uniqueId) { return false; }

        // TODO
        public static SealTable.SheetSealData GetSealData(SealID sealId) { return null; }

        // TODO
        public static SealTable.SheetEffectPositionOffset GetSealEffectPositionOffset(Size size) { return null; }

        // TODO
        public static SealTable.SheetFixedPositionEffect GetFixedSealEffectData(SealID sealID) { return null; }

        // TODO
        public static CharacterDressData.SheetData GetCharacterDressData(int dressId) { return null; }

        // TODO
        public static ShopTable.SheetBoutiqueShop GetBoutiqueShopData(int dressId) { return null; }

        // TODO
        public static KinomiData.SheetData GetKinomiDataByItemNo(ItemNo itemNo) { return null; }

        public static float GetFieldCommonParam(ParamIndx paramIndex)
        {
            return FieldCommonParam[(int)paramIndex].param;
        }

        private static IEnumerator Load_statueeffectdata()
        {
            AssetManager.AppendAssetBundleRequest("statueeffectdata", true, null, null);
            yield return AssetManager.DispatchRequests((eventType, assetName, asset) =>
            { 
                if (eventType == RequestEventType.Activated && asset != null)
                {
                    if (asset is StatueEffectRawData)
                        statueEffectRawData = asset as StatueEffectRawData;
                }
            });

            AssetManager.UnloadAssetBundle("statueeffectdata");
        }

        // TODO
        public static PokemonInfo.SheetTrearuki GetPokemonCatalogTrearuki(MonsNo monsNo, int formNo, Sex sex, bool isRare, bool isEgg = false) { return null; }

        public delegate void OnPostLoadDataDelegate();

        private class ComparerCatalog : IComparer
        {
            public int Compare(object x, object y)
            {
                var xCatalog = x as PokemonInfo.SheetCatalog;
                return xCatalog.UniqueID - Convert.ToInt32(y);
            }
        }

        private class ComparerKinomi : IComparer
        {
            public int Compare(object x, object y)
            {
                var xKinomi = x as KinomiData.SheetData;
                return (int)xKinomi.ItemNo - Convert.ToInt32(y);
            }
        }
    }
}