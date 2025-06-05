using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SoundBelugaFollowObj, "blue", "", "")]
	public class SoundBelugaFollowObj : Macro
	{
		public SEQ_DEF_FOLLOW type;
		public int trg;
		public Vector3 ofs;
		
		public SoundBelugaFollowObj(Macro macro) : base(macro)
        {
            type = Parse_SEQ_DEF_FOLLOW(macro.GetValue("type"));
            trg = ParseInt(macro.GetValue("trg"));
            ofs = ParseVector3(macro.GetValue("ofs"));
        }
    }
}