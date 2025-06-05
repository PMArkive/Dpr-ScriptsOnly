using DG.Tweening.Core;
using UnityEngine;

namespace DG.Tweening
{
	[AddComponentMenu(menuName: "")]
	public class DOTweenVisualManager : MonoBehaviour
	{
		public VisualManagerPreset preset;
		public OnEnableBehaviour onEnableBehaviour;
		public OnDisableBehaviour onDisableBehaviour;
		private bool _requiresRestartFromSpawnPoint;
		private ABSAnimationComponent _animComponent;
		
		// TODO
		private void Awake() { }
		
		// TODO
		private void Update() { }
		
		// TODO
		private void OnEnable() { }
		
		// TODO
		private void OnDisable() { }
	}
}