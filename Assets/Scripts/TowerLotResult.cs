using Dpr.Trainer;
using Pml;
using XLSXContent;

public class TowerLotResult
{
    public int matchingID;
    public uint stockID;
    public TowerTrID[] trainerID = new TowerTrID[2] { TowerTrID.NONE, TowerTrID.NONE };
    public ulong[] personalRand = new ulong[4];

    // TODO
    public TowerTrID GetTrainerID(int index) { return TowerTrID.NONE; }

    // TODO
    public TrainerType GetTrainerType(int index) { return TrainerType.INVALID; }

    // TODO
    public TowerTrainerTable.SheetTrainerData GetTrainerData(int index) { return null; }

    // TODO
    public PokeParty CreatePokeParty(int trainerIndex) { return null; }

    // TODO
    public SealTemplateID[] GetSealTemplates(int trainerIndex) { return null; }

    // TODO
    public bool IsSingle() { return false; }

    // TODO
    public void GetBGM(out string battleBGM, out string winBGM)
    {
        battleBGM = "";
        winBGM = "";
    }
}