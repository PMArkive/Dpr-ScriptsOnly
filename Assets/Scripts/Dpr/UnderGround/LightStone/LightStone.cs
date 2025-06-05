using Effect;
using Pml;
using UnityEngine;

namespace Dpr.UnderGround.LightStone
{
	public class LightStone : MonoBehaviour
	{
		[SerializeField]
		private Transform root;
		[SerializeField]
		private Transform monsterRoot;
		[SerializeField]
		private Transform effectRoot;

		private State state;
		private State nextState;
		private MonsNo monsNo;
		private FieldPokemonEntity entity;
		private EffectInstance lightStoneEffect;
		
		public Vector2Int Pos { get; set; }
		
		// TODO
		public void Init(Vector2Int pos) { }
		
		// TODO
		public void LoadModel(MonsNo monsNo) { }
		
		// TODO
		public void ReturnUnUsed() { }
		
		// TODO
		public void ReturnUnUsedWithAnimation() { }
		
		// TODO
		public bool OnUpdate(float deltaTime) { return default; }
		
		// TODO
		public bool IsContact() { return default; }
		
		// TODO
		public bool IsUnuse() { return default; }
		
		// TODO
		public void OnHit() { }
		
		// TODO
		public void DigStart() { }
		
		// TODO
		private void PLayDigAnimation() { }
		
		// TODO
		public void FindLightStone() { }
		
		// TODO
		public bool IsAliveModel() { return default; }
		
		// TODO
		private void PlaySmokeEffect(float delay) { }
		
		// TODO
		public void PlayLightStoneEffect(float delay) { }
		
		// TODO
		private void PlayPokeSE() { }
		
		// TODO
		private void SetState(State state) { }

		private enum State : int
		{
			Uninitialized = 0,
			Idle = 1,
			DigAnimation = 2,
			LightStone = 3,
			Empty = 4,
		}
	}
}