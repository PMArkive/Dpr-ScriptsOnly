using Dpr.BattleMatching;
using Dpr.Message;
using Dpr.UI;
using System.Collections.Generic;
using UnityEngine;

public class UnionBattleRuleWindow : MonoBehaviour
{
	private const int TAG_INDEX_RULE = 0;
	private const int TAG_INDEX_PLAYER_NAME = 1;

	private static readonly string TITLE_RULE_TEXT_LABEL = "DLP_net_union_room_063";
	private static readonly string TITLE_TARGET_TEXT_LABEL = "DLP_net_union_room_064";
	private static readonly string SELECT_RULE_TEXT_LABEL = "DLP_net_union_room_109";
	private static readonly string TARGET_PLAYER_NAME_TEXT_LABEL = "DLP_net_union_room_110";

	[SerializeField]
	private UIText titleRuleText;
	[SerializeField]
	private UIText titleTargetText;
	[SerializeField]
	private List<UnionTargetPlate> targetNamePlateList;
	[SerializeField]
	private UIText battleRuleText;
	[SerializeField]
	private CanvasGroup canvasGroup;
	
	// TODO
	public void Init() { }
	
	// TODO
	public void SetText(string txtPlayerName, int ruleIndex, MessageEnumData.MsgLangId langId) { }
	
	// TODO
	public void SetText(List<UnionMatchWaitData> matchWaitDataList, int ruleIndex) { }
	
	// TODO
	public void Show() { }
	
	// TODO
	public void Hide() { }
	
	// TODO
	private string GetRuleText(int ruleIndex) { return default; }
}