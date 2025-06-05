using AttributeData;
using Audio;
using Effect;
using FieldCommon;
using GameData;
using UnityEngine;

namespace Dpr.Field
{
    public class FieldFishing
    {
        private Seq _seqNo;
        private Result _returnResult;
        private Vector2Int _grid;
        private float _inputTime;
        private float _inputLimit;
        private FishingRod _rodType;
        private Balloon _ballon;
        private Vector3 _effectPosition;
        private bool _isRideBicycle;
        private EffectInstance[] _eff_Instance = new EffectInstance[5];
        private AudioInstance[] _se_audio_instance = new AudioInstance[8];
        private bool _throw_se;
        private float _hit_random_time;
        private float _hit_wait_time;
        private float FAIL_TIME = 5.0f;
        private bool _is_feint;
        private float _feint_down;
        private float _feint_time;

        public void Clear()
        {
            _ballon = null;
            for (int i=0; i<_eff_Instance.Length; i++)
            {
                _eff_Instance[i]?.Stop();
                _eff_Instance[i] = null;
            }

            for (int i=0; i<_se_audio_instance.Length; i++)
            {
                _se_audio_instance[i]?.Stop();
                _se_audio_instance[i] = null;
            }
        }

        private float DATA_TuriageFrameTbl(FishingRod rodType)
        {
            switch (rodType)
            {
                case FishingRod.BoroiTurizao:
                    return DataManager.GetFieldCommonParam(ParamIndx.Fishing_BoroInput);

                case FishingRod.IiTurizao:
                    return DataManager.GetFieldCommonParam(ParamIndx.Fishing_IIInput);

                case FishingRod.SugoiTurizao:
                    return DataManager.GetFieldCommonParam(ParamIndx.Fishing_SugoiInput);

                default:
                    return 1.0f;
            }
        }

        public bool StartFishing(FishingRod rodType)
        {
            if (ZoneWork.IsUnderGround(PlayerWork.zoneID))
                return false;

            if (ZoneWork.NoFishingZone(PlayerWork.zoneID))
                return false;

            Clear();

            var origPos = EntityManager.activeFieldPlayer.worldPosition;

            GameManager.GetAttribute(EntityManager.activeFieldPlayer.gridPosition, out int code, out int _);
            if (AttributeID.MATR_IsBridge(code))
            {
                if (AttributeID.MATR_IsBridgeV(code))
                    return false;

                if (AttributeID.MATR_IsBridgeH(code))
                    return false;

                var encount = GameManager.GetFieldEncountData(PlayerWork.zoneID);
                if (encount.encRate_turi_boro == 0 && encount.encRate_turi_ii == 0 && encount.encRate_sugoi == 0)
                    return false;
            }

            _returnResult.encResult = null;
            _grid = FieldObjectEntity.PositionToGrid(origPos + EntityManager.activeFieldPlayer.transform.forward);
            _seqNo = 0;
            _returnResult.isFishing = true;
            _returnResult.state = ResultState.Update;
            _rodType = rodType;

            GameManager.GetAttribute(_grid, out _returnResult.attriCode, out int stop);
            if (stop == 128)
                return false;

            GameManager.GetAttribute(_grid, out int watercode, out int waterstop);

            if (waterstop == 128)
                return false;

            var table = GameManager.GetAttributeTable(watercode);

            if (!table.Water && !AttributeID.MATR_IsWater(table.Code))
                return false;

            GameManager.GetAttribute(EntityManager.activeFieldPlayer.gridPosition, out int tilecode, out int _);
            if (AttributeID.MATR_IsBridgeWater(tilecode))
            {
                var exraw = GameManager.GetAttributeExCodeRaw(EntityManager.activeFieldPlayer.gridPosition);
                if (GameManager.IsHighAttribute(exraw, origPos.y))
                    return false;
            }

            GameManager.GetAttribute(_grid, out int forwardCode, out int _);
            if (AttributeID.MATR_IsBridgeWater(forwardCode))
            {
                var exraw = GameManager.GetAttributeExCodeRaw(_grid);
                if (GameManager.IsHighAttribute(exraw, origPos.y))
                    return false;
            }

            var ex = GameManager.GetAttributeEx(_grid, origPos.y);
            _returnResult.attriEx = ex.AttributeEx;

            var pos = FieldObjectEntity.GridToPosition(_grid);
            var forward = new Vector3(pos.x - origPos.x, 0.0f, pos.y - origPos.z).normalized;
            if (!IsWaterGrid(ref forward))
                return false;

            var newAngle = Quaternion.LookRotation(forward).eulerAngles;
            EntityManager.activeFieldPlayer.SetYawAngleDirect(newAngle.y);
            _effectPosition = origPos + (EntityManager.activeFieldPlayer.transform.forward * 1.1f);

            if (!PlayerWork.IsFormSwim())
            {
                GameManager.GetAttribute(EntityManager.activeFieldPlayer.gridPosition, out int adjustedcode, out int _);
                if (AttributeID.MATR_IsShoal(adjustedcode))
                    _effectPosition.y += 0.6f;
                else
                    _effectPosition.y -= 0.25f;
            }

            return true;
        }

        private bool IsWaterGrid(ref Vector3 forward)
        {
            var grid = FieldObjectEntity.PositionToGrid(EntityManager.activeFieldPlayer.worldPosition + forward);
            GameManager.GetAttribute(grid, out int code, out int stop);

            if (stop == 128)
                return false;

            var table = GameManager.GetAttributeTable(code);

            if (!table.Water || !AttributeID.MATR_IsWater(table.Code))
                return false;

            GameManager.GetAttribute(EntityManager.activeFieldPlayer.gridPosition, out int tilecode, out int _);
            if (AttributeID.MATR_IsBridgeWater(tilecode))
            {
                var ex = GameManager.GetAttributeExCodeRaw(EntityManager.activeFieldPlayer.gridPosition);
                if (GameManager.IsHighAttribute(ex, EntityManager.activeFieldPlayer.worldPosition.y))
                    return false;
            }

            GameManager.GetAttribute(grid, out int forwardCode, out int _);
            if (AttributeID.MATR_IsBridgeWater(forwardCode))
            {
                var ex = GameManager.GetAttributeExCodeRaw(grid);
                if (GameManager.IsHighAttribute(ex, EntityManager.activeFieldPlayer.worldPosition.y))
                    return false;
            }

            return true;
        }

        // TODO
        public Result Update(float time)
        {
            return new Result();
        }

        private void RideBicycle()
        {
            if (!_isRideBicycle)
                return;

            _isRideBicycle = false;

            EntityManager.activeFieldPlayer.SetRideBicycle(null);
            FieldManager.Instance.CallEffect(EffectFieldID.EF_F_CYCLE_RIDE, EntityManager.activeFieldPlayer.transform, null, null);
        }

        public static int RodVaridation(FishingRod rod)
        {
            switch (rod)
            {
                case FishingRod.IiTurizao:
                    return 0;

                case FishingRod.SugoiTurizao:
                    return 2;

                default:
                    return 1;
            }
        }

        private enum Seq : int
        {
            Start = 0,
            StartAnimeWait = 1,
            StartAnimeEnd = 2,
            Update = 3,
            HitInput = 4,
            End = 5,
            FaileAnimeWait = 6,
            SuccessAnimeWait = 7,
            HitEndAnimeWait = 8,
        }

        public enum ResultState : int
        {
            Update = 0,
            Sucsess = 1,
            NoneEnc = 2,
            MissInput = 3,
            Cancel = 4,
        }

        public struct Result
        {
            public bool isFishing;
            public EncountResult encResult;
            public ResultState state;
            public int attriCode;
            public MapAttributeEx attriEx;
        }

        private enum EffectID : int
        {
            EF_F_FISHING_THROW_01 = 0,
            EF_F_FISHING_WAIT_01 = 1,
            EF_F_FISHING_HIT_01 = 2,
            EF_F_FISHING_CATCH_01 = 3,
            EF_F_FISHING_CATCH_02 = 4,
            END = 5,
        }

        private enum AudioID : int
        {
            s_fi021 = 0,
            s_fi021_2 = 1,
            s_fi021_3 = 2,
            s_fi022 = 3,
            s_fi023 = 4,
            s_fi024 = 5,
            s_fi025 = 6,
            s_fi026 = 7,
            end = 8,
        }
    }
}
