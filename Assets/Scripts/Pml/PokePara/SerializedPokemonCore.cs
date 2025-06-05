using System;
using UnityEngine;

namespace Pml.PokePara
{
	[Serializable]
	public struct SerializedPokemonCore
	{
		[SerializeField]
		public byte[] buffer;
		
		// TODO
		public void CopyFrom(in SerializedPokemonCore src) { }
		
		// TODO
		public void CreateWorkIfNeed(bool isRecreate = false) { }
	}
}