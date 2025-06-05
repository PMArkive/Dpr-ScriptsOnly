using DG.Tweening;
using Dpr.Battle.Logic;
using Pml.PokePara;
using Pml;
using UnityEngine;

namespace Dpr.BallDeco
{
    public static class BallDecoWork
    {
        public const int CapsuleInitialCount = 12;
        public const int CapsuleMaxCount = 99;
        public const int AffixSealMaxCount = 20;
        public const int SealSaveSize = 200;
        public const int SealMaxCount = 99;
        public const int Capsule2DCalcCenterThetaAngle = 90;
        public const int Capsule2DCalcCenterFrontPhiAngle = 0;
        public const int Capsule2DCalcCenterBackPhiAngle = -180;
        public const string BallLightEffectAssetBundlePathFormat = "effect/prefab/seal/ef_s_seal_eb{0:D3}";
        public static readonly int Capsule2DCalcFrontRadius = 1;
        public static readonly int Capsule2DCalcBackRadius = 1;
        public static readonly int Capsule2DCalcFrontSplitAngle = 28;
        public static readonly int Capsule2DCalcBackSplitAngle = 25;
        public static readonly float EffectMoveValue = 0.0f;
        public static readonly Ease EffectMoveEasingType = Ease.Linear;
        public static bool IsFixBallDecoExtraData = false;
        private static bool[] tempAttachCapsuleFlags = new bool[6];

        public static SaveBallDecoData m_ballDecoData { get => PlayerWork.GetBallDecoData(); }
        public static SaveBallDecoExtraData m_ballDecoExtraData { get => PlayerWork.GetBallDecoExtraData(); }

        // TODO
        public static void ResetBallDecoExtraData() { }

        // TODO
        public static void FixBallDecoExtraData() { }

        public static void GetPokeIndex(PokemonParam pokemonParam, out int tray, out int pos)
        {
            tray = -1;
            pos = -1;

            uint newPos = PlayerWork.playerParty.GetMemberIndex(pokemonParam);
            if (newPos < 6)
                pos = (int)newPos;
        }

        // TODO
        public static void ClearTempAttachCapsuleFlags() { }

        // TODO
        public static void SetTempAttachCapsuleFlag(int pokeId, bool flag) { }

        // TODO
        public static bool IsAttachCapsule(BTL_POKEPARAM btlPokeParam) { return false; }

        // TODO
        public static int GetCapsuleCount() { return 0; }

        // TODO
        public static void AddCapsuleCount(int count) { }

        // TODO
        public static bool Get3DEditMode(int capsuleId) { return false; }

        // TODO
        public static void Set3DEditMode(int capsuleId, bool is3DEditMode) { }

        // TODO
        public static void SetAppliedTemplate(int capsuleId, bool isAppliedTemplate) { }

        // TODO
        public static int GetAttachCapsuleId(uint pokemonId, uint personalRnd, int tray, int pos) { return 0; }

        // TODO
        public static void SetAttachCapsule(int capsuleId, uint pokemonId, uint personalRnd, int tray, int pos) { }

        // TODO
        public static void SwapCapsuleData(int capsuleId1, int capsuleId2) { }

        // TODO
        public static void SwapCapsuleExtraDataByTrayIndex(int tray1, int tray2) { }

        // TODO
        public static void SwapCapsuleExtraData(int tray1, int pos1, int tray2, int pos2) { }

        // TODO
        public static void MoveCapsuleExtraData(int fromTray, int fromPos, int toTray, int toPos) { }

        // TODO
        public static void ScootOverCapsuleExtraData(int index) { }

        // TODO
        public static void RemoveAttachCapsule(int tray, int pos) { }

        // TODO
        public static int GetCanCopySealCount(int capsuleId) { return 0; }

        // TODO
        public static int GetCanCopySealCount(CapsuleData capsuleData) { return 0; }

        // TODO
        public static bool CopyCapsuleData(int fromCapsuleId, int toCapsuleId) { return false; }

        // TODO
        public static bool CopyCapsuleData(CapsuleData capsuleData, int toCapsuleId) { return false; }

        // TODO
        public static bool CopyTradeCapsuleData(CapsuleData capsuleData, int toCapsuleId) { return false; }

        // TODO
        public static int GetAffixSealCount(int capsuleId) { return 0; }

        // TODO
        public static AffixSealData GetAffixSealData(int capsuleId, int affixSealId) { return default; }

        // TODO
        public static void SetAffixSealData(int capsuleId, int affixSealId, ushort sealId, Vector3 pos) { }

        // TODO
        public static void SetAffixSealData(int capsuleId, AffixSealData[] affixSealDatas, byte affixSealCount) { }

        // TODO
        public static bool AddAffixSealData(int capsuleId, ushort sealId, Vector3 pos) { return false; }

        // TODO
        public static void RemoveAffixSealData(int capsuleId, int affixSealId) { }

        // TODO
        public static bool GetSealIsGet(int id) { return false; }

        // TODO
        public static int GetSealCount(int id) { return 0; }

        // TODO
        public static int GetSealTotalCount(int id) { return 0; }

        // TODO
        public static int GetCanAddSealCount(int id) { return 0; }

        // TODO
        public static void AddSealCount(int id, int count) { }

        // TODO
        public static void SubSealCount(int id, int count, bool isAffixSeal) { }

        // TODO
        public static void ReturnSealCount(int id, int count) { }

        public static ref CapsuleData GetCapsuleData(int capsuleId)
        {
            return ref PlayerWork.GetBallDecoData().CapsuleDatas[capsuleId];
        }

        // TODO
        public static int GetAttachTray(int capsuleId) { return 0; }

        // TODO
        public static int GetAttachPosition(int capsuleId) { return 0; }

        // TODO
        public static Vector3 Convert2DPosition(int x, int y, bool isFront) { return Vector3.zero; }

        // TODO
        public static float GetEffectPositionOffset(Size size) { return 0.0f; }

        // TODO
        public static string GetBallLightEffectAssetBundleName(BallId ballId) { return ""; }

        // TODO
        public static bool GetFixedEffectData(SealID sealID, out Vector3 pos, out Vector3 rot, out Vector3 scaleRate)
        {
            pos = Vector3.zero;
            rot = Vector3.zero;
            scaleRate = Vector3.zero;
            return false;
        }
    }
}