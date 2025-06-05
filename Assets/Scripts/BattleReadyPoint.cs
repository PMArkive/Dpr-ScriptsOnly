using Effect;
using UnityEngine;

public class BattleReadyPoint : EnterCollision
{
	private EffectData waitEffect;
	private EffectData readyEffect;
	private EffectInstance effectInstance;
	private int pointNumber;
	
	public int PointNumber { get => pointNumber; }
	
	// TODO
	public void Create(int number, float rad, GameObject target, EffectData wait, EffectData ready) { }
	
	// TODO
	public override void OnDestroy() { }
	
	public bool IsEnter { get => isEnter; }
	
	// TODO
	public void Enter() { }
	
	// TODO
	public void Leave() { }
	
	// TODO
	public bool IsContact() { return default; }
	
	// TODO
	public void PlayWaitEffect() { }
	
	// TODO
	public void PlayReadyEffect() { }
	
	// TODO
	private void ClearEffect(EffectInstance effect) { }
	
	// TODO
	protected override void OnUpdate(float deltaTime) { }
}