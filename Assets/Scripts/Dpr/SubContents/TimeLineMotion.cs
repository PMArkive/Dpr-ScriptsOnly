using Dpr.Battle.View.Objects;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.SubContents
{
	public class TimeLineMotion : MonoBehaviour
	{
		private BattlePlayerEntity playerEntity;
		private BattlePokemonEntity pokeEntity;
		private BOPokemon boPokemon;
		public Color AddColor = Color.white;
		private float LoopSec;
		private Transform Waist;
		private List<float> heightList = new List<float>();
		public float HeightLimit = -1.0f;
		public uint Pattern;
		public bool updatePattern;
		private float prevScale = -1.0f;
		public int DebugIndex;

		[Button("Test", "Test", new object[0])]
		public int Button01;
		
		// TODO
		private void OnDestroy() { }
		
		// TODO
		public void CallMotion(int AnimID) { }
		
		// TODO
		public void SetLoopSec(float sec) { }
		
		// TODO
		private void SetEntity() { }
		
		// TODO
		public void Update() { }
		
		// TODO
		public void Test() { }
	}
}