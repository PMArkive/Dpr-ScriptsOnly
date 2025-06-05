using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DispEffectSpEnvironmentPokemonColorSet, "lightgreen", "", "")]
	public class DispEffectSpEnvironmentPokemonColorSet : Macro
	{
		public bool isReset;
		public Vector3 pokeLightColor;
		public float pokeLightIntensity;
		public Vector3 pokeReflectorColor;
		public SEQ_DEF_MOVETYPE move;
		
		public DispEffectSpEnvironmentPokemonColorSet(Macro macro) : base(macro)
        {
            isReset = ParseBool(macro.GetValue("isReset"), 0);
            pokeLightColor = ParseVector3(macro.GetValue("pokeLightColor"), 1.0f, 1.0f, 1.0f);
            pokeLightIntensity = ParseFloat(macro.GetValue("pokeLightIntensity"), 1.2f);
            pokeReflectorColor = ParseVector3(macro.GetValue("pokeReflectorColor"), 1.0f, 1.0f, 1.0f);
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}