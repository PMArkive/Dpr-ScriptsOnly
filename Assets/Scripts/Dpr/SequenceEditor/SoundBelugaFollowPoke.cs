using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SoundBelugaFollowPoke, "blue", "", "")]
	public class SoundBelugaFollowPoke : Macro
	{
		public bool isEnable;
		public SEQ_DEF_POS trg;
		public SEQ_DEF_NODE node;
		public Vector3 ofs;
		
		public SoundBelugaFollowPoke(Macro macro) : base(macro)
        {
            isEnable = ParseBool(macro.GetValue("isEnable"), 1);
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            node = Parse_SEQ_DEF_NODE(macro.GetValue("node"));
            ofs = ParseVector3(macro.GetValue("ofs"));
        }
    }
}