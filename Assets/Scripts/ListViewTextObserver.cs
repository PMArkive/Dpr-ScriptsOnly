using SmartPoint.Components;
using System;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ListViewTextObserver : LayoutCellObserver
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

	[Serializable]
	public class CallbackEvent : UnityEvent<string, WeakReference> { }

	public class Item
	{
		public string text;
		public CallbackEvent onClick;
		public WeakReference reference;
		
		public Item([Optional] string text, [Optional] UnityAction<string, WeakReference> callback, [Optional] WeakReference reference)
		{
			onClick = new CallbackEvent();
			onClick.AddListener(callback);

			this.reference = reference;
			this.text = text;
		}
	}
}