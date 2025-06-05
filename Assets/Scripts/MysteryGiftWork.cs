using DPData;
using DPData.MysteryGift;
using Dpr.Battle.Logic;
using Pml.PokePara;

public static class MysteryGiftWork
{
	public const ushort CheckInternetGiftDataNo = 9999;
	public const long NgCheckSecond = 21600;
	public const byte InputNgCount = 10;
	
	// TODO
	public static MysteryGiftSaveData m_mysteryGiftData { get; set; }
	
	// TODO
	public static void AddRecvData(RecvData recvData) { }
	
	// TODO
	public static bool IsReceived(ushort deliveryId) { return default; }
	
	// TODO
	public static bool IsExistRecvData() { return default; }
	
	// TODO
	public static void SetReceiveFlag(MysteryGiftData giftData) { }
	
	// TODO
	public static RecvData[] GetRecvDatas() { return default; }
	
	// TODO
	public static void ReceiveItemGift(ushort itemId) { }
	
	// TODO
	public static void ReceiveDressUpItemGift(uint dressId) { }
	
	// TODO
	public static CanReceiveResult CanReceive(MysteryGiftCommonData commonData) { return default; }
	
	// TODO
	public static void ResetNgCount() { }
	
	// TODO
	public static bool IsNgFlagOn() { return default; }
	
	// TODO
	public static bool IncNgCount() { return default; }
	
	// TODO
	public static RecvData CreateRecvData(MysteryGiftData data) { return default; }
	
	// TODO
	public static ConvertResult ConvertMysteryGiftData(byte[] dataBytes, out MysteryGiftData mysteryGiftData)
	{
		mysteryGiftData = default;
		return default;
	}
	
	// TODO
	public static PokemonParam CreatePokemonParam(MysteryGiftPokemonData pokemonData) { return default; }
	
	// TODO
	public static void DebugOneDayHistory(int addDay = 0) { }
	
	// TODO
	public static void ResetReceivedFlag() { }
	
	// TODO
	public static void ResetOneDayReceivedDatas() { }
	
	// TODO
	private static void SetOnceReceiveFlag(ushort deliveryId) { }
	
	// TODO
	private static void SetOneDayReceiveFlag(ushort deliveryId, long timestamp) { }
	
	// TODO
	private static bool IsNgTime(long oldTime, long newTime) { return default; }
	
	// TODO
	public static bool GetGameServerTime(out long timestamp)
	{
		timestamp = default;
		return default;
	}
	
	// TODO
	private static T ConvertData<T>(byte[] dataBytes, int start) { return default; }
	
	// TODO
	private static void GetPokemonNameAndLanguage(MysteryGiftPokemonData pokemonData, MyStatus myStatus, out string nickName, out string parentName, out byte nickNameLang)
	{
		nickName = default;
		parentName = default;
		nickNameLang = default;
	}
	
	// TODO
	private static void ConvertRecvPokemonData(MysteryGiftPokemonData pokemonData, out MonsData monsData)
	{
		monsData = default;
	}
	
	// TODO
	private static bool CheckCrc(byte[] data, ushort crc) { return default; }
	
	// TODO
	private static int CalcCrcValue(byte[] dataBytes) { return default; }
}