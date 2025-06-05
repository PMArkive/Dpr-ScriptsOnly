using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraSortTragroups : MonoBehaviour
{
	private Camera _camera;
	private static List<(PokemonTraGroup, Transform)> _traGroupAndTransforms = new List<(PokemonTraGroup, Transform)>();
	
	// TODO
	private void Awake() { }
	
	// TODO
	public static void Register(PokemonTraGroup traGroup) { }
	
	// TODO
	public static void Unregister(PokemonTraGroup traGroup) { }
	
	// TODO
	private void OnPreCull() { }
}