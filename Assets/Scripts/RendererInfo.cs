using UnityEngine;

public struct RendererInfo
{
	public Renderer Renderer { get; set; }
    public int MaterialCount { get; set; }

    public RendererInfo(Renderer renderer)
    {
        Renderer = renderer;
        MaterialCount = renderer.sharedMaterials.Length;
    }
}