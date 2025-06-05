using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DispEffectSpEnvironmentCharacterColorSet, "lightgreen", "", "")]
	public class DispEffectSpEnvironmentCharacterColorSet : Macro
	{
		public bool isReset;
		public Vector3 characterLightColor;
		public float characterLightIntensity;
		public Vector3 characterReflectorColor;
		public SEQ_DEF_MOVETYPE move;
		
		public DispEffectSpEnvironmentCharacterColorSet(Macro macro) : base(macro)
        {
            isReset = ParseBool(macro.GetValue("isReset"), 0);
            characterLightColor = ParseVector3(macro.GetValue("characterLightColor"), 1.0f, 1.0f, 1.0f);
            characterLightIntensity = ParseFloat(macro.GetValue("characterLightIntensity"), 1.2f);
            characterReflectorColor = ParseVector3(macro.GetValue("characterReflectorColor"), 1.0f, 1.0f, 1.0f);
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}