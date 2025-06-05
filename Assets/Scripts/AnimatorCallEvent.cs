using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class AnimatorCallEvent : MonoBehaviour
{
	private Animator mAnimator;
	private bool hasLayerOverride;
	public bool dispLog;
	public UnityAction<string, int> mAction_AK_EffectStart00;
	public UnityAction<string, int> mAction_AK_EffectStart01;
	public UnityAction<string, int> mAction_AK_ButuriStart01;
	public UnityAction<string, int> mAction_AK_SEStart01;
	public UnityAction<string, int> mAction_AK_SEStart02;
	public UnityAction<string, int> mAction_AK_SEStart03;
	public UnityAction<string, int> mAction_AK_PartsMaterial01;
	private int loop01Weight;
	
	public int Loop01Weight { get => loop01Weight; }
	
	// TODO
	private void Start() { }
	
	// TODO
	private void Update() { }
	
	// TODO
	private void DispLog(string log) { }
	
	// TODO
	private void AK_EffectStart00(int value) { }
	
	// TODO
	private void AK_EffectStart01(int value) { }
	
	// TODO
	private void AK_ButuriStart01(int value) { }
	
	// TODO
	private void AK_SEStart01(int value) { }
	
	// TODO
	private void AK_SEStart02(int value) { }
	
	// TODO
	private void AK_SEStart03(int value) { }
	
	// TODO
	private void AK_PartsMaterial01(int value) { }
	
	// TODO
	private void AK_PartsSkel01(int value) { }
}