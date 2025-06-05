using Dpr.FureaiHiroba;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PofinGameCalc
{
	private Tuple<int, int>[] RotSpeedTarget = new Tuple<int, int>[]
	{
		new Tuple<int, int>(1, 7),
		new Tuple<int, int>(3, 7),
		new Tuple<int, int>(6, 9),
	};
	public bool isRotRight;
	public int SearCount;
	public int SpillCount;
	public float NamerakasaHosei;
	public int MAX_ROTATE_SPEED = 2500;
	public float DOWN_SPEED = 40.0f;
	public float ACCEL_POWER = 1.2f;
	public float accel;
	public float prevAngleR = -1.0f;
	public float prevAngleL = -1.0f;
	public float rotateTime = 99.0f;
	public float PlayingTime;
	public float EndTime = 60.0f;
	public float RotCount;
	public int[] NeedPhaseChangeRotCounts = new int[] { 15, 16, 16 };
	public int CookPhase;
	public float deltaAccel;
	private float searTime;
	private float spillTime;
	public Action OnSear;
	public Action OnSpill;
	public Action OnSearZone;
	public Action OnSpillZone;
	public Action OnNoMiss;
	private bool isSmoke;
	public Action OnSmoke;
	public int SpeedVal;
	public float BlendHoten;
	private float NoMissTime;
	private float RotMagni = 0.8f;
	private List<FureaiPokeModel> pokeModels;
	
	// TODO
	public bool IsCorrect(float rotDirection) { return default; }
	
	// TODO
	public bool isGameEnd { get; }
	
	// TODO
	public float SpeedHosei { get; }
	
	// TODO
	public float BatterColorRate { get; }
	
	// TODO
	public void SetPokeModel(List<FureaiPokeModel> pokeModels) { }
	
	// TODO
	public void Update(float deltaTime) { }
	
	// TODO
	private bool IsSearZone() { return default; }
	
	// TODO
	private bool IsSpillZone() { return default; }
	
	// TODO
	private void CheckSear() { }
	
	// TODO
	private void CheckSpill() { }
	
	// TODO
	private void CheckStepAndTime() { }
	
	// TODO
	public float GetBlendValue() { return default; }
	
	// TODO
	public float CalcRot(float angleR, float angleL, float deltaTime) { return default; }
	
	// TODO
	private void PhaseNext() { }
	
	// TODO
	public bool CheckNeedChangeRotateDirection(float deltaTime) { return default; }
	
	// TODO
	private int GetSpeedValue() { return default; }
	
	// TODO
	public float GetNearAngle(float angle, float prevAngle) { return default; }
	
	// TODO
	public float Vector2ToAngle(Vector2 input) { return default; }
}