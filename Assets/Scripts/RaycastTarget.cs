using UnityEngine;
using UnityEngine.UI;

public class RaycastTarget : Graphic
{
	public override Material materialForRendering { get => null; }
	
	// TODO
	protected override void OnPopulateMesh(VertexHelper vertexHelper) { }
}