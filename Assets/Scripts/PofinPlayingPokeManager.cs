using Dpr.FureaiHiroba;
using System.Collections.Generic;
using UnityEngine;

public class PofinPlayingPokeManager
{
	private List<FureaiPokeModel> fureaiPokes;
	private List<Transform> pokePositions;
	private Transform LookAtTarget;
	private List<Vector3> ReturnPositions = new List<Vector3>();
	private PofinPokePosition pokePositionManager;
	public static readonly int[] SuperMaroyakaAnimID = new int[] { FieldPokemonEntity.Animation.Happy01, FieldPokemonEntity.Animation.Happy02 };
	public static readonly int[] LikeAnimID = new int[] { FieldPokemonEntity.Animation.Happy02, FieldPokemonEntity.Animation.Happy03 };

    public PofinPlayingPokeManager(List<FureaiPokeModel> fureaiPokes, List<Transform> pokePositions, Transform LookAtTarget)
	{
		this.fureaiPokes = fureaiPokes;
		this.pokePositions = pokePositions;
		this.LookAtTarget = LookAtTarget;

		pokePositionManager = LookAtTarget.parent.GetComponent<PofinPokePosition>();
		PokeConfiguration();
	}
	
	// TODO
	public void EndPofinMake() { }
	
	// TODO
	public void NoMissAction() { }
	
	// TODO
	public void KogeAction() { }
	
	// TODO
	public void KoboshiAction() { }
	
	// TODO
	public void CompleteAction(PofinCookModel resultModel) { }
	
	// TODO
	private void PokeConfiguration() { }
	
	// TODO
	private void PokeAction(int animIndex) { }
	
	// TODO
	private void PokePositionReturn() { }
	
	// TODO
	private void PokeAddWalking() { }
}