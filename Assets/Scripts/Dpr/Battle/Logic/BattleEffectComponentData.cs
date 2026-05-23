using System.Runtime.InteropServices;
using XLSXContent;

namespace Dpr.Battle.Logic
{
    public sealed class BattleEffectComponentData
    {
        private string overwrappedBattleBGM;
        private string overwrappedWinBGM;
        private BattleDataTable.SheetBattleSetupEffectData data;
        private EffectBattleID _effectBattleID = EffectBattleID.NONE;
        private string _soundEventName;
        public string cmdSeqName;

        public EffectBattleID effectBattleID { get => _effectBattleID; set => _effectBattleID = value; }
        public string soundEventName { get => _soundEventName; set => _soundEventName = value; }
        public string battleBgm
        {
            get
            {
                if (!string.IsNullOrEmpty(overwrappedBattleBGM))
                    return overwrappedBattleBGM;

                return data?.BattleBGM ?? null;
            }
            set => overwrappedBattleBGM = value;
        }
        public string winBgm
        {
            get
            {
                if (!string.IsNullOrEmpty(overwrappedWinBGM))
                    return overwrappedWinBGM;

                return data?.WinBGM ?? null;
            }
            set => overwrappedWinBGM = value;
        }
        public int fadeType { get => data?.FadeType ?? -1; }

        private string ChooseCmdSeq(int index)
        {
            if (data == null)
                return string.Empty;

            var badgeCount = PlayerWork.badge;

            if (index < 0)
            {
                var maxIndex = 0;
                var totalWeights = 0;

                for (int i=0; i<data.Weight.Length; i++)
                {
                    if (i != 0)
                    {
                        if (badgeCount < data.Cond[i - 1])
                            break;

                        if (string.IsNullOrEmpty(data.CmdSeqName[i]))
                            break;
                    }

                    maxIndex++;
                    totalWeights += data.Weight[i];
                }

                var roll = UnityEngine.Random.Range(0.0f, totalWeights);
                var currentWeight = (int)roll;

                for (int i=0; i!=maxIndex; i++)
                {
                    currentWeight -= data.Weight[i];
                    if (currentWeight < 0)
                        return data.CmdSeqName[i];
                }

                return data.CmdSeqName[0];
            }
            else if (!string.IsNullOrEmpty(data.CmdSeqName[index]))
            {
                return data.CmdSeqName[index];
            }
            else
            {
                return data.CmdSeqName[0];
            }
        }

        public void SetUpBattleEffectComponentData(BattleSetupEffectId setupEffectId, [Optional, DefaultParameterValue(EffectBattleID.NONE)] EffectBattleID effectBattleId, [Optional, DefaultParameterValue(0)] int cmdSeqIndex, [Optional] string soundEventName)
        {
            var table = BattleDataTableManager.Instance.BattleDataTable.BattleSetupEffectData;
            if ((int)setupEffectId >= table.Length || (int)setupEffectId < 0)
                setupEffectId = BattleSetupEffectId.DEFAULT;

            data = table[(int)setupEffectId];
            _soundEventName = soundEventName;
            cmdSeqName = ChooseCmdSeq(cmdSeqIndex);
            overwrappedBattleBGM = null;
            overwrappedWinBGM = null;
        }

        public void SetUpBattleEffectComponentData_Tutorial()
        {
            data = BattleDataTableManager.Instance.BattleDataTable.BattleSetupEffectData[(int)BattleSetupEffectId.WILD_SINGLE_TUTORIAL];
            cmdSeqName = ChooseCmdSeq(0);
            overwrappedBattleBGM = null;
            overwrappedWinBGM = null;
        }
    }
}