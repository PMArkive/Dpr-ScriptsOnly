using System.Collections.Generic;
using UnityEngine;

public class DemoPokeHeightAutoAdjuster : MonoBehaviour
{
	private FieldPokemonEntity pokeEntity;
	private List<float> heightList = new List<float>();
	public Transform Head;
	public Vector3 defaultPos = Vector3.zero;
	public float heightLimit = 0.5f;
	
	// TODO
	public void Awake() { }
	
	// TODO
	private void OnDestroy() { }
	
	// TODO
	public void Update() { }
}