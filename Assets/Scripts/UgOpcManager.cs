using Dpr.NetworkUtils;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UgOpcManager : OpcManager
{
	public OpcState.OnlineState MyState;
	private List<int> CreatingOpcList = new List<int>();
	public Action<int> OnCreateOpc;
	private List<OpcController> allOpcControllers = new List<OpcController>();
	private List<ObjParam> _objParams = new List<ObjParam>();
	
	// TODO
	public override void SetNetData(INetData netData) { }
	
	// TODO
	public override void RemoveCharacter(int stationIndex, bool isGameObjectDestroy = true) { }
	
	// TODO
	public override void DestroyCharacterObject(GameObject gameObj) { }
	
	// TODO
	private void DestroyLeakObject(int stationIndex) { }
	
	// TODO
	public override void CreateCharacter(INetData joinData) { }
	
	// TODO
	public override void RemoveAllCharacter() { }
	
	// TODO
	public override void Destroy() { }
	
	// TODO
	public void Update(float deltaTime) { }

	private class ObjParam
	{
		public int stationIndex = -1;
		public FieldObjectEntity entity;
		public GameObject gameObj;
	}
}