using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class EncEffectGymController : MonoBehaviour
{
	[SerializeField]
	private Image _playerImage;
	[SerializeField]
	private Image _enemyImage;
	private Animation _anime;
	[SerializeField]
	private Canvas _canvas;
	
	// TODO
	private void OnEnable() { }
	
	// TODO
	public void SetImage(Sprite player, Sprite enemy1, [Optional] Sprite enemy2) { }
	
	// TODO
	public void Play() { }
	
	// TODO
	private void AnimeEnd() { }
	
	// TODO
	public void Release() { }
}