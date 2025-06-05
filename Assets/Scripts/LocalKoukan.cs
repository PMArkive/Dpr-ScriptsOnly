using Dpr.Message;
using Pml;
using Pml.PokePara;
using XLSXContent;

public class LocalKoukan
{
	// TODO
	public static LocalKoukanData.Sheetdata GetTargetData(int npcindex, MessageEnumData.MsgLangId lang) { return default; }
	
	// TODO
	public static MonsNo GetTargetMonsNo(int npcindex, MessageEnumData.MsgLangId lang) { return default; }
	
	// TODO
	public static Operation CreateOperation(PokemonParam myparam, int npcindex, MessageEnumData.MsgLangId lang, bool istemoti, int trayno, int pos) { return default; }
	
	// TODO
	public static Operation CreateOperation(PokemonParam from, PokemonParam other, bool istemoti, int trayno, int pos) { return default; }
	
	// TODO
	private static int GetIndex(int npcindex, MessageEnumData.MsgLangId lang) { return default; }
	
	// TODO
	private static PokemonParam CreateTradePokeParam(LocalKoukanData.Sheetdata data) { return default; }

	public class Operation
	{
		public bool IsTemotiMode;
		public int TrayNo;
		public int Pos;
		public PokemonParam from;
		public PokemonParam other;
		
		// TODO
		public void Apply() { }
	}
}