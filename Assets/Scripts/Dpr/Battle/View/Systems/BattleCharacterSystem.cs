using Dpr.Battle.Logic;
using Dpr.Battle.View.Objects;
using Pml.PokePara;
using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace Dpr.Battle.View.Systems
{
	public class BattleCharacterSystem
	{
		private BattleViewSystem _viewSystem;
		private BOTrainer[] _trainers;
		private BOPokemon[] _pokemons;
		
		public BOTrainer[] Trainers { get => _trainers; set => _trainers = value; }
		public BOPokemon[] Pokemons { get => _pokemons; set => _pokemons = value; }
		
		public BattleCharacterSystem(BattleViewSystem pViewSystem)
		{
			_viewSystem = pViewSystem;
			_trainers = new BOTrainer[7]; // TODO: Find a good constant for these?
            _pokemons = new BOPokemon[7]; // TODO: Find a good constant for these?
		}
		
		// TODO
		public void Dispose() { }
		
		// TODO
		public IEnumerator StartLoadAllCharacter(bool[] isPokemonSetupFlags, bool[] isTrainerSetupFlags, [Optional] Action onComplete) { return default; }

		// TODO
		public IEnumerator StartLoadPoke(BtlvPos vPos, bool IsVisible, [Optional] Action onComplete) { return default; }
		
		// TODO
		public IEnumerator StartLoadPoke(BtlvPos vPos, bool IsVisible, BtlvPos vPosTarget, [Optional] Action onComplete) { return default; }
		
		// TODO
		public IEnumerator StartLoadPoke(BtlvPos vPos, PokemonParam param, bool IsVisible, [Optional] Action onComplete) { return default; }
		
		// TODO
		public IEnumerator StartLoadExceptionPoke(BtlvPos vPos, PokemonParam param, string AssetBundleName, bool IsVisible, [Optional] Action onComplete) { return default; }
		
		// TODO
		public void StartDelete(BOPokemon pokemon) { }
		
		// TODO
		public bool IsFinishDelete(BOPokemon pokemon) { return default; }
		
		// TODO
		private IEnumerator StartLoadTrainer(BtlvPos vPos, TRAINER_DATA data, TrainerSimpleParam param, [Optional] Action onComplete) { return default; }
		
		// TODO
		public BOPokemon GetPokemonModel(BtlvPos vPos) { return default; }
		
		// TODO
		public BOTrainer GetTrainerModel(BtlvPos vPos) { return default; }
		
		// TODO
		public IEnumerator StartLoadMigawari([Optional] Action onComplete) { return default; }
		
		// TODO
		public IEnumerator StartLoadDigudaStone([Optional] Action onComplete) { return default; }
	}
}