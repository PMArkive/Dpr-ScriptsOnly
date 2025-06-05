using Dpr.UI;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UnionFrontDeskContextMenu
{
	protected static readonly Vector2 CONTEXT_BATTLE_MENU_POSITION = new Vector2(680.0f, 280.0f);

	private ContextMenuWindow contextMenuWindow;
	private List<string> messgaeList = new List<string>();
	public Action<int> _selectRequirementsMenu;
	public Action<int> _selectDescriptionMenu;
	public Action<int> _selectInternetModeMenu;
	public Action<int> _selectBattleRuleMenuLocal;
	public Action<int> _selectBattleRuleMenuInternet;
	
	// TODO
	public void CreateContextRequirementsMenu() { }
	
	// TODO
	public void CreateContextDescriptionMenu() { }
	
	// TODO
	public void CreateContextInternetMenu() { }
	
	// TODO
	public void CreateContextColiseumMenu() { }
	
	// TODO
	public void CreateContextBattleRuleMenu() { }
	
	// TODO
	public void ShowYesNoWindow(Action<int> selectFunc) { }
	
	// TODO
	public void Close() { }
}