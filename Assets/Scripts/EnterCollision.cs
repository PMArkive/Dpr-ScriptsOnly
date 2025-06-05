using SmartPoint.AssetAssistant;
using System;
using UnityEngine;

public class EnterCollision : SingletonMonoBehaviour<EnterCollision>
{
	private const float PLAYER_RADIUS = 0.5f;

	public Action _OnEnterCallBack;
	protected GameObject targetObj;
	protected float radius;
	protected Vector3 center;
	public bool isEnter;
	
	// TODO
	public void Create(Action enterFunc, float rad, GameObject target) { }
	
	// TODO
	public virtual void OnDestroy() { }
	
	// TODO
	protected virtual void OnUpdate(float deltaTime) { }
	
	// TODO
	public bool IsInCircle() { return default; }
	
	// TODO
	protected void PlaySE(uint playSEId) { }
}