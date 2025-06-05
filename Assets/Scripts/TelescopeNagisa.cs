using Dpr;
using UnityEngine;

public class TelescopeNagisa
{
	private ScopePhase Phase;
	private Vector2Int EventPos;
	private FieldFloatMove Time = new FieldFloatMove();
	
	public bool IsBusy { get => Phase != ScopePhase.None; }
	
	// TODO
	public void Start(Vector2Int eventPos) { }
	
	// TODO
	public void Update(float deltaTime) { }

	private enum ScopePhase : int
	{
		None = 0,
		Start = 1,
		Open = 2,
		Wait = 3,
		PreClose = 4,
		Close = 5,
	}
}