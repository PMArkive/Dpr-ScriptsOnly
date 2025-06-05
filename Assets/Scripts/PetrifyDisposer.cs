using System.Collections.Generic;
using UnityEngine;

public class PetrifyDisposer : MonoBehaviour
{
	[HideInInspector]
	public List<Renderer> volatileRenderers = new List<Renderer>();
	
	// TODO
	private void OnDestroy() { }
}