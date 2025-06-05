using System;

[Serializable]
public class PokemonVariationData
{
	public MaterialParam[] mMaterialParams;

	[Serializable]
	public class MaterialParam
	{
		public string variation;
		public bool createFlag = true;
	}
}