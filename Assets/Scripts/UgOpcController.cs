using Dpr;
using Dpr.NetworkUtils;
using System;

public class UgOpcController : OpcController
{
	private FieldObjectMove _fieldObjectMove = new FieldObjectMove();
	public Action OnStartFinished;
	private bool isSwim;
	
	// TODO
	private void Awake() { }
	
	// TODO
	protected override void Start() { }
	
	// TODO
	public override void SetNetData(INetData netData) { }
	
	// TODO
	private void StateChange(INetData netData) { }
	
	// TODO
	public override void SetOpcOnlineState(OpcState.OnlineState state)
	{
		// TODO
		bool CheckRecruiment() { return default; }
    }
	
	// TODO
	private void DoNaminori(INetData netData) { }
	
	// TODO
	public void SetNaminoriState(bool isSwim) { }
	
	// TODO
	protected override void MyUpdate(float deltaTime) { }
	
	// TODO
	protected override void OnDestroy() { }
}