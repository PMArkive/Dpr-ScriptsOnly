using System;
using UnityEngine;

public class FieldWazaCutInCapture : MonoBehaviour
{
	public bool isCapture;
	public RenderTexture RenderTexture;
	private Action<bool> ResultFunc;
	
	// TODO
	private void Awake() { }
	
	// TODO
	public void Capture(Action<bool> result) { }
	
	// TODO
	public void Release() { }
	
	// TODO
	private void OnRenderImage(RenderTexture src, RenderTexture dest) { }
}