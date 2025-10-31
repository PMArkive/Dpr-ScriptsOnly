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
	
	private void Start()
	{
		mAnimator = GetComponent<Animator>();

		if (mAnimator.layerCount > 1 && mAnimator.GetLayerName(1) == "Layer Override00")
			hasLayerOverride = true;
	}
	
	private void Update()
	{
		// Empty
	}
	
	private void DispLog(string log)
	{
		// Empty
	}
	
	private void AK_EffectStart00(int value)
	{
		if (mAnimator == null)
			return;

		if (mAnimator.GetCurrentAnimatorClipInfoCount(0) != 0)
		{
			_ = "AK_EffectStart00:" + mAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name;
			mAction_AK_EffectStart00?.Invoke(mAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name, value);
        }
		else
        {
            mAction_AK_EffectStart00?.Invoke("", value);
        }
	}
	
	private void AK_EffectStart01(int value)
	{
        if (mAnimator == null)
            return;

        if (mAnimator.GetCurrentAnimatorClipInfoCount(0) != 0)
        {
            _ = "AK_EffectStart01:" + mAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name;
            mAction_AK_EffectStart01?.Invoke(mAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name, value);
        }
        else
        {
            mAction_AK_EffectStart01?.Invoke("", value);
        }
    }
	
	private void AK_ButuriStart01(int value)
	{
        if (mAnimator == null)
            return;

        if (mAnimator.GetCurrentAnimatorClipInfoCount(0) != 0)
        {
            _ = "AK_ButuriStart01:" + mAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name;
            mAction_AK_ButuriStart01?.Invoke(mAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name, value);
        }
        else
        {
            mAction_AK_ButuriStart01?.Invoke("", value);
        }
    }
	
	private void AK_SEStart01(int value)
	{
        if (mAnimator == null)
            return;

        if (mAnimator.GetCurrentAnimatorClipInfoCount(0) != 0)
            mAction_AK_SEStart01?.Invoke(mAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name, value);
        else
            mAction_AK_SEStart01?.Invoke("", value);
    }
	
	private void AK_SEStart02(int value)
	{
        if (mAnimator == null)
            return;

        if (mAnimator.GetCurrentAnimatorClipInfoCount(0) != 0)
            mAction_AK_SEStart02?.Invoke(mAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name, value);
        else
            mAction_AK_SEStart02?.Invoke("", value);
    }
	
	private void AK_SEStart03(int value)
	{
        if (mAnimator == null)
            return;

        if (mAnimator.GetCurrentAnimatorClipInfoCount(0) != 0)
            mAction_AK_SEStart03?.Invoke(mAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name, value);
        else
            mAction_AK_SEStart03?.Invoke("", value);
    }
	
	private void AK_PartsMaterial01(int value)
	{
		if (mAnimator != null && hasLayerOverride)
			mAnimator.SetLayerWeight(1, value == 0 ? 0.0f : 1.0f);
	}
	
	private void AK_PartsSkel01(int value)
	{
		if (mAnimator == null)
			return;

		loop01Weight = value;

		if (hasLayerOverride)
			mAnimator.SetLayerWeight(1, value);
	}
}