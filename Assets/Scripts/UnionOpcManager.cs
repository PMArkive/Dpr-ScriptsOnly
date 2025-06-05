using Dpr.NetworkUtils;
using Dpr.UI;
using UnityEngine;

public class UnionOpcManager : OpcManager
{
	private const string INVALID_ASSET_NAME = "fc2003_00";
	private const string UNION_SESSION_START_MESSAGE_FILE_NAME = "dlp_net_union_room";
	private Vector2 CONTEXT_MENU_POSITION = new Vector2(590.0f, 350.0f);
	private static readonly string[] UNION_START_MASSEAGES = new string[]
	{
        "DLP_net_union_room_044", "DLP_net_union_room_045",
		"DLP_net_union_room_046", "DLP_net_union_room_047",
    };
	
	// TODO
	public override void CreateCharacter(INetData joinData) { }
	
	// TODO
	private (bool, string) OnInputCheck(string resultText, SoftwareKeyboard.ErrorState errorState) { return default; }
	
	// TODO
	public void SetIsMatchWait(bool isMatchWait, int stationIndex) { }
}