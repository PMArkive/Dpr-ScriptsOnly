using Dpr.Battle.View;
using Dpr.Message;
using Pml;
using Pml.PokePara;

namespace Dpr.Contest
{
    public class EntryPlayerData
    {
        public BtlvBallInfo ballInfo;
        public string playerName;
        public string pokemonNickName;
        public string trainerModelPath;
        public ushort fashion;
        public PlayerType playerType;
        public WazaNo wazaNo;
        public MonsNo monsNo;
        public Sex playerSex = Sex.NUM;
        public Sex monsSex = Sex.NUM;
        public RareType rareType;
        public ushort itemNo;
        public MessageEnumData.MsgLangId userLangID;
        public MessageEnumData.MsgLangId monsLangID;
        public float wazaSeqTime;
        public uint formNo;
        public int cassetVersion;
        public int colorID;
        public int npcDataIndex;
        public WazaNo npcWazaNo;
        public byte style;
        public byte beautiful;
        public byte cute;
        public byte clever;
        public byte strong;
        public byte fur;
        public bool isRare;
        public bool isDpClear;

        public void Reset()
        {
            trainerModelPath = string.Empty;
            pokemonNickName = string.Empty;
            playerName = string.Empty;
            fashion = 0;
            wazaNo = WazaNo.NULL;
            monsNo = MonsNo.NULL;
            playerSex = Sex.NUM;
            monsSex = Sex.NUM;
            rareType = RareType.NOT_RARE;
            itemNo = 0;
            userLangID = MessageManager.Instance.UserLanguageID;
            monsLangID = MessageManager.Instance.UserLanguageID;
            wazaSeqTime = 0.0f;
            formNo = 0;
            cassetVersion = 0;
            colorID = 0;
            npcDataIndex = 0;
            npcWazaNo = WazaNo.NULL;
            style = 0;
            beautiful = 0;
            cute = 0;
            clever = 0;
            strong = 0;
            fur = 0;
            isRare = false;
            isDpClear = false;
        }
    }
}