using Dpr.BallDeco;
using Pml.PokePara;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Dpr.UI
{
	public class CapsuleInfo
	{
		private int capsuleId;
		
		public CapsuleData Data { get; set; }
		public PokemonParam AttachPokemonParam { get; set; }
		public PokemonParam PreviewPokemonParam { get; set; }
		public bool Is3DEditMode { get => Data.Is3DEditMode; }
		public bool IsAppliedTemplate { get => Data.IsAppliedTemplate; }
		public bool IsAffixedSeal { get => Data.AffixSealCount != 0; }
		public bool IsAffixSealMaxCount { get => Data.AffixSealCount == BallDecoWork.AffixSealMaxCount; }
		public int AttachTray { get; set; }
		public int AttachPosition { get; set; }
		
		public CapsuleInfo(int id)
		{
			capsuleId = id;
			RefreshData();
		}
		
		public CapsuleInfo(CapsuleData data, [Optional] PokemonParam pokemonParam)
		{
			capsuleId = -1;
			Data = data;

			RefreshData();

			if (pokemonParam != null)
				AttachPokemonParam = pokemonParam;
		}
		
		// TODO
		public void RefreshData() { }
		
		// TODO
		public void AttachPokemon(PokemonParam pokemonParam, int tray, int pos) { }
		
		// TODO
		public void DetachPokemon() { }
		
		// TODO
		public void SwitchEditMode() { }
		
		// TODO
		public void Swap(CapsuleInfo capsuleInfo) { }
		
		// TODO
		public int GetCanCopySealCount() { return default; }
		
		// TODO
		public void CopyTo(CapsuleInfo capsuleInfo) { }
		
		// TODO
		public int AddAffixSeal(ushort sealId, Vector3 pos) { return default; }
		
		// TODO
		public void SetAffixSeal(int affixSealId, ushort sealId, Vector3 pos) { }
		
		// TODO
		public void RemoveAffixSeal(int affixSealId, bool isDoReturn = true) { }
		
		// TODO
		public void RemoveAllAffixSeals() { }
		
		// TODO
		public void SwapAffixSeal(int affixSealId, ushort sealId) { }
		
		// TODO
		public void SwapEachAffixSeal(int toAffixSealId, int fromAffixSealId) { }
	}
}