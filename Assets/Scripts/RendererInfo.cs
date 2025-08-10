using UnityEngine;

public struct RendererInfo
{
	public Renderer Renderer { get; private set; }
    public int MaterialCount { get; private set; }

    public RendererInfo(Renderer renderer)
    {
        Renderer = renderer;
        MaterialCount = renderer.sharedMaterials.Length;
    }
}