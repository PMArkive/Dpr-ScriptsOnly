using Dpr.Battle.Logic;
using Dpr.Battle.View;
using Dpr.Battle.View.Objects;
using Dpr.Battle.View.Systems;
using Pml.PokePara;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.SequenceEditor
{
    public interface ISequenceViewSystem
    {
        void OnUpdate(float deltaTime);

        void OnLateUpdate(float deltaTime);

        void ResetPokemon(BtlvPos vPos, int frame, SEQ_DEF_MOVETYPE moveType, SEQ_DEF_DEFAULT_PLACEMENT placement = SEQ_DEF_DEFAULT_PLACEMENT.SEQ_DEF_DEFAULT_PLACEMENT_DEFAULT);

        void GetDefaultPokePos(BtlvPos vPos, ref Vector3 pos, ref int deg, SEQ_DEF_DEFAULT_PLACEMENT placement = SEQ_DEF_DEFAULT_PLACEMENT.SEQ_DEF_DEFAULT_PLACEMENT_DEFAULT);

        BOPokemon GetPokeModel(BtlvPos vPos);

        Size GetPokeSize(BattleViewSystem.BattleViewSide side, bool isGPoke = false);

        void ResetTrainer(BtlvPos vPos, bool isOrigin, SEQ_DEF_DEFAULT_PLACEMENT placement = SEQ_DEF_DEFAULT_PLACEMENT.SEQ_DEF_DEFAULT_PLACEMENT_DEFAULT);

        BattleViewCharacter GetTrainerModel(BtlvPos vPos);

        string GetBallModelPath(int idx);

        void ResetAll();

        void SEQ_CMD_ResetDefaultCamera(int frame, SEQ_DEF_MOVETYPE moveType, SequenceCameraSystem system);

        bool SeqComFunc_IsFlipEffect(BtlvPos target, BtlvPos subTarget);

        BattleViewCharacter SeqComFunc_GetTargetChara(SEQ_DEF_TRAINER trg, int idx = 0);

        BattleViewCharacter SeqComFunc_GetTargetChara(SEQ_DEF_TRAINER_ADD trg, int idx = 0);

        BtlvPos SeqComFunc_GetTargetPoke(SEQ_DEF_POS target, int index = 0);

        BtlvPos SeqComFunc_GetTargetPokeSub(SEQ_DEF_POS target);

        BtlvPos SeqComFunc_GetTargetPoke_Org(int idx);

        void SeqComFunc_GetPokeRelativePos(ref RELARIVE_POKE_OPTION opt, ref Vector3 pRetPos, ref Vector3 pRetRot, ref Vector3 pRetScale, bool isCameraAdjust);

        void SeqComFunc_GetSpecialPos(SEQ_DEF_SPPOS trgType, ref Vector3 retPos, ref Vector3 retRot);

        void SeqComFunc_GetPokeFiledPos(ref Vector3 retPos, ref Vector3 retRot, BtlvPos plater, bool isAttack);

        int SeqComFunc_GetTargetPokeNum(bool isCheck = true);

        BtlvPos SeqComFunc_GetTargetCharaVPos(SEQ_DEF_TRAINER target, int index = 0);

        void SeqComFunc_CalcPokeDir(Vector3 nowPos, BtlvPos trgPoke, SEQ_DEF_NODE trgNode, ref Vector3 retRot, bool isVertical);

        void SeqComFunc_CalcPosDir(Vector3 nowPos, Vector3 trgPos, ref Vector3 retRot, bool isVertical);

        void SeqComFunc_MoveRelativePoke(ITranslationObject iPtrObj, int frame, RELARIVE_POKE_OPTION opt, bool isTrainer = false);

        void SeqComFunc_MoveSpecialPos(ITranslationObject iPtrObj, int frame, SEQ_DEF_SPPOS trgType, Vector3 ofs, bool isRotate, bool isFlip);

        BtlvBallInfo SeqComFunc_GetEffectBallInfo(int idx);

        void SetTerrainChipVisibility(bool disp);

        void StartWeather(BtlWeather weather);

        void SetSuspendSequenceFunc(SEQ_DEF_WAIT type);

        TaskManager GetTaskManager();

        TaskManager GetTaskManagerLate();

        BTL_POKEPARAM GetBattlePokeParam(BtlvPos pos);

        MainModule GetMainModule();

        BTLV_WAZA_EFF_PARAM GetWazaParam();

        BTLV_WAZA_EFF_PARAM SetWazaParam(BTLV_WAZA_EFF_PARAM param);

        string GetBttleWazaModelPath(string idx);

        void CheckWazaDataPath_Particle(ref string path, int idx, bool isBallEffect, bool isCapture, bool isAttributeEffect, bool isStreamLineEffect);

        BattleSequenceSystem GetSequenceSystem();

        BattleCharacterSystem GetCharacterSystem();

        SequenceCameraSystem GetCameraSystem();

        BattleWeatherSystem GetBattleWeatherSystem();

        BattleGroundEffectSystem GetBattleGroundEffectSystem();

        Stack<Tuple<int, uint, uint>> GetSoundPlayingIDHashTable();

        bool IsStencilEnable { get; set; }

        float blurry { get; set; }

        void SetIsSoundPlayingFinishCheckInvalid(bool value);
    }
}
