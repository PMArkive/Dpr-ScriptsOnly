using DPData;
using Dpr.Item;
using Dpr.Message;
using Dpr.SubContents;
using Pml.PokePara;
using System.Collections.Generic;
using XLSXContent;

public class PofinCookModel
{
	public const int POFIN_ID_KOTTERI = 25;
	public const int POFIN_ID_KUDOI = 26;
	public const int POFIN_ID_MAZUI = 27;
	public const int POFIN_ID_MAROYAKA = 28;
	public const int POFIN_ID_CHYOUMAROYAKA = 29;

	public static readonly string MESSAGE_NAME = "dp_poffin_main";
	public static readonly string LABEL_NAME = "DP_poffin_main_";

    private ItemInfo[] kinomiInfo;
	public List<KinomiData.SheetData> kinomiData = new List<KinomiData.SheetData>();
	private byte[] AjiParam = new byte[(int)Pml.PokePara.Taste.MAX];
	private byte Taste;
	public float CookedTime;
	public int SearCount;
	public int SpillCount;
	public int TeamHosei;
	private int MinusCount;
	private int PlusCount;
	private int SameKinomiCount;
	
	public PofinCookModel(float time, int sear, int spill, int teamHosei, ItemInfo[] kinomi)
	{
		kinomiInfo = kinomi;
		
		Init();

		CookedTime = time;
		SearCount = sear;
		SpillCount = spill;
		TeamHosei = teamHosei;

		for (int i=0; i<kinomi.Length; i++)
		{
			// Empty
		}

		CalcParam();

		// All of this is basically ignored, likely had some sort of debug logging
		var result = GetPofinData();
		var resultData = PoffinCookingSceneManager.Instance.PofinData.Find(x => x.MstID == result.Key.MstID);
		_ = MessageManager.Instance.GetMsgFile(MessageDataConstants.POFFIN_NAME_MSBT_FILE).GetNameStr(resultData.LabelName);
	}
	
	// TODO
	private void Init() { }
	
	// TODO
	private void CalcParam() { }
	
	// TODO
	private List<KeyValuePair<int, int>> GetPlusParam() { return default; }
	
	// TODO
	public KeyValuePair<PoffinData, int> GetPofinData() { return default; }
	
	// TODO
	private bool[] GetRandomFlavor3() { return default; }

	private enum Aji : int
	{
		Spicy = 0,
		Dry = 1,
		Sweet = 2,
		Bitter = 3,
		Sour = 4,
	}
}