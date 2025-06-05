using UnityEngine;
using UnityEngine.UI;

public class UnionOnlineDebugWindow : MonoBehaviour
{
	private static readonly string NETWORK_TYPE = "networkType : ";
	private static readonly string MATCHING_MODE = "matchingMode : ";
	private static readonly string GAME_MODE = "gameMode : ";
	private static readonly string MATCHMAKE_KEYWORD = "matchmakeKeyword : ";
	private static readonly string ATTRIBUTE_VALUE_ENABLE = "attributeValueEnable : ";
	private static readonly string NETGAMER_MAX_NUM = "netGamerMaxNum : ";
	private static readonly string SESSION_STATE = "sessionState : ";
	private static readonly string GAME_STATE = "gameState : ";
	private static readonly string SESSION_ID = "sessionId : ";
	private static readonly string SESSION_NUM = "sessionNum : ";
	private static readonly string NETGAMER_NUM = "netGamerNum : ";
	private static readonly string SESSION_OPEN = "sessionOpen : ";
	private static readonly string HOST_STATION_INDEX = "hostStationIndex : ";
	private static readonly string MINE_STATION_INDEX = "mineStationIndex : ";
	private static readonly string IS_HOST = "isHost : ";
	private static readonly string SEND_BYTE = "sendByte : ";
	private static readonly string SEND_BYTE_PEAK = "sendBytePeak : ";

	[SerializeField]
	private Text networkTypeText;
	[SerializeField]
	private Text matchingModeText;
	[SerializeField]
	private Text gameModeText;
	[SerializeField]
	private Text matchmakeKeywordText;
	[SerializeField]
	private Text attributeValueEnableText;
	[SerializeField]
	private Text netGamerMaxNumText;
	[SerializeField]
	private Text sessionStateText;
	[SerializeField]
	private Text gameStateText;
	[SerializeField]
	private Text sessionIdText;
	[SerializeField]
	private Text sessionNumText;
	[SerializeField]
	private Text netGamerNumText;
	[SerializeField]
	private Text sessionOpenText;
	[SerializeField]
	private Text hostStationIndexText;
	[SerializeField]
	private Text mineStationIndexText;
	[SerializeField]
	private Text isHostText;
	[SerializeField]
	private Text sendByteText;
	[SerializeField]
	private Text sendBytePeakText;
	
	// TODO
	public void SetNetworkParamText() { }
	
	// TODO
	private void Start() { }
	
	// TODO
	private void Update() { }
}