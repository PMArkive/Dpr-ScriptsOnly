using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SoundBelugaMovePosition, "blue", "one_frame", "")]
	public class SoundBelugaMovePosition : Macro
	{
		public Vector3 pos;
		public bool relative;
		public SEQ_DEF_MOVETYPE move;
		
		public SoundBelugaMovePosition(Macro macro) : base(macro)
        {
            pos = ParseVector3(macro.GetValue("pos"));
            relative = ParseBool(macro.GetValue("relative"));
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}