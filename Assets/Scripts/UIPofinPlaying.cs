using DG.Tweening;
using Dpr.SubContents;
using Dpr.UI;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIPofinPlaying : MonoBehaviour
{
	[SerializeField]
	private Image Arrow;
	[SerializeField]
	private Sprite rightArrow;
	[SerializeField]
	private Sprite leftArrow;
	[SerializeField]
	private Image CountDigit;
	[SerializeField]
	private RectTransform CountFrame;
	[SerializeField]
	private Sprite[] DigitSprite;
	[SerializeField]
	private Image StartImage;
	[SerializeField]
	private Image CompleteImage;
	[SerializeField]
	private CanvasGroup MessageFrame;
	[SerializeField]
	private UIText MessageText;
	[SerializeField]
	private Image[] KinomiImages = new Image[4];
	public bool isStart;

	private static readonly string[] textLabels = new string[]
	{
        "DP_poffin_main_154", "DP_poffin_main_155", "DP_poffin_main_156",
		"DP_poffin_main_157", "DP_poffin_main_158",
    };

	[Button("PlayStart", "PlayStart", new object[0])]
	public int Button0;

	private Sequence seq;

    [Button("RightArrow", "RightArrow", new object[0])]
    public int Button01;
    [Button("LeftArrow", "LeftArrow", new object[0])]
    public int Button02;
    [Button("CountDown", "CountDown 3", new object[] { 3 })]
    public int Button03;
    [Button("CountDown", "CountDown 2", new object[] { 2 })]
    public int Button04;
    [Button("CountDown", "CountDown 1", new object[] { 1 })]
    public int Button05;

	[SerializeField]
	private Ease ease;

	[Button("StartText", "StartText", new object[0])]
	public int Button06;
	[Button("CompleteText", "CompleteText", new object[0])]
	public int Button07;
	[Button("TextSet", "TextSet", new object[0])]
	public int Button08;

	private Tweener tw_scale;
	private Tweener tw_fade;
	private Tween delay;
	private MessageType nowMessage;

	[Button("PlayMessage", "PlayMessage", new object[] { 0 })]
	public int Button09;
	[Button("EndMessage", "EndMessage", new object[0])]
	public int Button10;
	
	// TODO
	private void Start() { }
	
	// TODO
	public void PlayStart(int[] kinomiIDs, Action KinomiInEffect) { }
	
	// TODO
	public IEnumerator StartCor(int[] kinomiIDs, Action KinomiInEffect) { return default; }
	
	// TODO
	public Tween RightArrow() { return default; }
	
	// TODO
	public Tween LeftArrow() { return default; }
	
	// TODO
	public Tweener ArrowClear() { return default; }
	
	// TODO
	public Tweener CountDown(int digit) { return default; }
	
	// TODO
	public Tweener KinomiIn() { return default; }
	
	// TODO
	public Tweener StartText() { return default; }
	
	// TODO
	public Tweener CompleteText() { return default; }
	
	// TODO
	public void TextInit() { }
	
	// TODO
	public void TextExit() { }
	
	// TODO
	public void PlayMessage(MessageType type) { }
	
	// TODO
	public void EndMessage() { }

	public enum MessageType : int
	{
		TooSlow = 0,
		TooFast = 1,
		LittleSlow = 2,
		LittleFast = 3,
		VerySlow = 4,
		_None = 5,
	}
}