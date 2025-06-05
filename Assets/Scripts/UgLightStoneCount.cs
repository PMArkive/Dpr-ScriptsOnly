using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UgLightStoneCount : MonoBehaviour
{
	[SerializeField]
	private List<Sprite> numResource;
	[SerializeField]
	private int digit = 2;

	[Header("分子")]
	[SerializeField]
	private Image numeratorLeft;
	[SerializeField]
	private Image numeratorCenter;
	[SerializeField]
	private Image numeratorRight;

	[Header("分母")]
	[SerializeField]
	private Image denominatoLeft;
	[SerializeField]
	private Image denominatoCenter;
	[SerializeField]
	private Image denominatoRight;

	private Image[] numeratorImages;
	private Image[] denominatoImages;
	private int max;
	
	// TODO
	public void Initialize() { }
	
	// TODO
	public void SetDenominato(int num) { }
	
	// TODO
	public void SetNumerator(int num) { }
	
	// TODO
	private int DigitNum(int num) { return default; }
	
	// TODO
	private int[] Split(int num) { return default; }
}