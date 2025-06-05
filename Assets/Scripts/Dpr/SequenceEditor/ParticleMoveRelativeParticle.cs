using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ParticleMoveRelativeParticle, "green", "", "")]
	public class ParticleMoveRelativeParticle : Macro
	{
		public int trg;
		public Vector3 pos;
		public bool isRotPos;
		public SEQ_DEF_MOVETYPE move;
		
		public ParticleMoveRelativeParticle(Macro macro) : base(macro)
        {
            trg = ParseInt(macro.GetValue("trg"), 1);
            pos = ParseVector3(macro.GetValue("pos"));
            isRotPos = ParseBool(macro.GetValue("isRotPos"), 0);
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}