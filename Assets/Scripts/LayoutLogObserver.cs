using SmartPoint.Components;
using TMPro;
using UnityEngine;

public class LayoutLogObserver : LayoutCellObserver
{
	public LayoutScrollView.Cell _cell;
	public TextMeshProUGUI _contentText;
	
	// TODO
	public override Vector2 sizeDelta { get; }
	
	// TODO
	public override void OnUpdate(float deltaTime) { }
	
	// TODO
	public void OnClick() { }
	
	// TODO
	public override bool IsReady() { return default; }
	
	// TODO
	public override bool OnRebuildLayout() { return default; }
	
	// TODO
	public override void OnClose() { }
}