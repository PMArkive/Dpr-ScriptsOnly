using Dpr.Battle.View.Objects;
using Dpr.Playables;
using System.Collections.Generic;
using System.Linq;
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
		
		private void OnDestroy()
		{
			playerEntity = null;
			pokeEntity = null;
			boPokemon = null;
			Waist = null;
			heightList = null;
		}
		
		public void CallMotion(int AnimID)
		{
			SetEntity();

			if (playerEntity != null)
			{
				playerEntity.GetAnimationPlayer().GetAnimationLayer(BattleAnimationPlayer.LayerIndex.BaseLayer).Play(AnimID, 0.001f);
				playerEntity.GetAnimationPlayer().GetAnimationLayer(BattleAnimationPlayer.LayerIndex.EyeLayer).AnimationSpeed = 0.0f;
            }

			if (pokeEntity != null && pokeEntity.GetAnimationPlayer().currentIndex != AnimID)
				pokeEntity.GetAnimationPlayer().Play(AnimID, 0.001f);
		}
		
		public void SetLoopSec(float sec)
		{
			LoopSec = sec;
		}
		
		private void SetEntity()
		{
			if (playerEntity != null)
				return;

			if (pokeEntity != null)
				return;

            var childCount = transform.childCount;
            if (childCount == 0)
                return;

            var child = transform.GetChild(childCount - 1);
			playerEntity = child.GetComponent<BattlePlayerEntity>();
			pokeEntity = child.GetComponent<BattlePokemonEntity>();

			if (pokeEntity != null)
				Waist = pokeEntity.transform.Find("Origin").GetChild(0);
        }
		
		public void Update()
		{
			SetEntity();

			if (updatePattern)
			{
				updatePattern = false;

				var childCount = transform.childCount;
                if (childCount == 0)
					return;

				var patcheel = transform.GetChild(childCount - 1).GetComponent<PatcheelPattern>();
				if (patcheel != null)
					patcheel.SetPattern(Pattern);
			}

			if (pokeEntity != null)
			{
				if (pokeEntity.GetAnimationPlayer().IsValidCurrentPlayable)
				{
					if (pokeEntity.GetAnimationPlayer().IsPlayingEnd &&
						pokeEntity.GetAnimationPlayer().currentIndex != (int)BattlePokemonEntity.AnimationState.WaitA01)
					{
						pokeEntity.GetAnimationPlayer().Play((int)BattlePokemonEntity.AnimationState.WaitA01, 0.001f);
                    }

					pokeEntity.SetBlinkEnabled(true);
				}

				pokeEntity.FixMultiplierColor = AddColor;

				if (prevScale != -1.0f && prevScale == pokeEntity.transform.localScale.y)
				{
					heightList.Add(Waist.localPosition.y * pokeEntity.transform.localScale.y);
					if (heightList.Count > 30)
						heightList.RemoveAt(0);

					var avg = heightList.Average();
					if (avg > 1.0f)
						pokeEntity.gameObject.transform.localPosition = Vector3.down * (avg - 1.0f);
				}

				prevScale = pokeEntity.transform.localScale.y;
				pokeEntity.GetPokeAnimSound().Enable = false;
			}
		}
		
		public void Test()
		{
			if (playerEntity != null)
				playerEntity.GetAnimationPlayer().GetAnimationLayer(BattleAnimationPlayer.LayerIndex.BaseLayer).Play(DebugIndex);
			else if (pokeEntity != null)
				pokeEntity.GetAnimationPlayer().Play(DebugIndex);
		}
	}
}