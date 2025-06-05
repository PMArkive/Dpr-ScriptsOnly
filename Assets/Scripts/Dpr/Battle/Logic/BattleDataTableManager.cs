using AttributeData;
using SmartPoint.AssetAssistant;
using System;
using XLSXContent;

namespace Dpr.Battle.Logic
{
    public sealed class BattleDataTableManager
    {
        private static BattleDataTableManager s_Instance;
        private static readonly string[] AB_NAMES = { "battle_masterdatas" };

        public static BattleDataTableManager Instance
        {
            get
            {
                if (s_Instance == null)
                    s_Instance = new BattleDataTableManager();
                return s_Instance;
            }
        }
        public BattleDataTable BattleDataTable { get; set; }
        public BattleDefaultPlacementData BattleDefaultPlacementData { get; set; }
        public BattleWaitCameraData BattleWaitCameraData { get; set; }
        public BattleSetupEffectLots BattleSetupEffectLots { get; set; }
        public bool IsInitialized { get; set; }
        private bool IsABAppended { get; set; }

        public bool AppendAssetBundleRequests()
        {
            if (!IsInitialized && !IsABAppended)
            {
                IsABAppended = true;
                for (int i=0; i<AB_NAMES.Length; i++)
                    AssetManager.AppendAssetBundleRequest(AB_NAMES[i], true, null, null);

                return true;
            }

            return false;
        }

        public bool OnDispatchRequests(RequestEventType eventType, string name, UnityEngine.Object asset)
        {
            if (!IsInitialized)
            {
                if (eventType == RequestEventType.Cached)
                {
                    if (Array.IndexOf<string>(AB_NAMES, name) > -1)
                    {
                        AssetManager.UnloadAssetBundle(name);
                        return true;
                    }
                }
                else if (eventType == RequestEventType.Activated && asset != null)
                {
                    if (asset is BattleDataTable)
                        BattleDataTable = asset as BattleDataTable;
                    else if (asset is BattleDefaultPlacementData)
                        BattleDefaultPlacementData = asset as BattleDefaultPlacementData;
                    else if (asset is BattleWaitCameraData)
                        BattleWaitCameraData = asset as BattleWaitCameraData;
                    else if (asset is BattleSetupEffectLots)
                        BattleSetupEffectLots = asset as BattleSetupEffectLots;
                    else
                        return false;

                    return true;
                }
            }

            return false;
        }

        private bool IsLoaded
        {
            get
            {
                return BattleDataTable != null &&
                    BattleDefaultPlacementData != null &&
                    BattleWaitCameraData != null &&
                    BattleSetupEffectLots != null;
            }
        }

        public void OnAfterLoadAll()
        {
            if (!IsInitialized)
            {
                Sequencer.update += OnAfterLoadAll_Update;
                IsInitialized = true;
            }
        }

        private static void OnAfterLoadAll_Update(float deltaTime)
        {
            Sequencer.update -= OnAfterLoadAll_Update;
        }

        // TODO
        public static BattleSetupEffectLots.SheetArenaEffTable GetArenaEff(ArenaID arenaID) { return null; }

        // TODO
        public static BattleSetupEffectLots.SheetAttEffTable GetAttEff(MapAttributeEx mapAttributeEx, ArenaID arenaID) { return null; }

        // TODO
        public static BattleSetupEffectLots.SheetRuleEffTable GetRuleEff(BattleSetupEffectLot lot) { return null; }
    }
}
