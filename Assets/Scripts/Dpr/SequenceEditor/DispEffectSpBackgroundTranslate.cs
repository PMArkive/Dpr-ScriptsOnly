using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DispEffectSpBackgroundTranslate, "lightgreen", "", "")]
	public class DispEffectSpBackgroundTranslate : Macro
	{
		public bool isReset;
		public Vector3 position;
		public Vector3 rotation;
		public Vector3 scale;
		public SEQ_DEF_MOVETYPE move;
		
		public DispEffectSpBackgroundTranslate(Macro macro) : base(macro)
        {
            isReset = ParseBool(macro.GetValue("isReset"), 0);
            position = ParseVector3(macro.GetValue("position"), 0.0f, 0.0f, 0.0f);
            rotation = ParseVector3(macro.GetValue("rotation"), 0.0f, 0.0f, 0.0f);
            scale = ParseVector3(macro.GetValue("scale"), 1.0f, 1.0f, 1.0f);
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}