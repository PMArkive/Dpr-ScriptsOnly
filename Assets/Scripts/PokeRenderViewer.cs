using DG.Tweening;
using Dpr.SubContents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokeRenderViewer : MonoBehaviour
{
	private RectTransform rectTra;
	private List<Tweener> Tws = new List<Tweener>();
	public FieldPokemonEntity entity;
	private Coroutine PokeAnimationUpdateCor;
	private Transform PositionTra;
	private Transform Waist;
	public int AnimationID = -1;
	private RenderTexture tex;
	[SerializeField]
	private Sprite[] CircleImages;
	public Image CircleUI;
	public RawImage PokeImage;

	private static readonly Color ClearColor = new Color(1.0f, 1.0f, 1.0f, 0.0f);

	[Button("StopMotion", "StopMotion", new object[0])]
	public int Button01;
	
	// TODO
	private void Awake() { }
	
	// TODO
	public Tweener ShowPokeView(Object PokeAsset, Vector2 posFrom, Vector2 posTo, Transform RenderCamera, Vector2 size, bool isNoMotion = false) { return default; }
	
	// TODO
	public void StopMotion() { }
	
	// TODO
	public void OpenWindow(Vector2 posFrom, Vector2 posTo, Vector2 Size) { }
	
	// TODO
	public Tweener HidePokeView() { return default; }
	
	// TODO
	private IEnumerator PokeAnimationUpdate() { return default; }
	
	// TODO
	public void SetScalePoke3D(Vector3 scale) { }
	
	// TODO
	public void SetPositionPoke3D(Vector3 pos) { }
	
	// TODO
	public void ChangeCircleImage(int index) { }
	
	// TODO
	private void OnDestroy() { }
}