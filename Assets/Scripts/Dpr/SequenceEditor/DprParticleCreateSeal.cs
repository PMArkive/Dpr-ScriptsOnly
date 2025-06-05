namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DprParticleCreateSeal, "green", "", "PreloadParticle")]
	public class DprParticleCreateSeal : Macro
	{
		public SEQ_DEF_POS trg;
		public int index;
		public int grpNo;
		public SEQ_DEF_PARTICLE_DELETE deleteType;
		
		public DprParticleCreateSeal(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            index = ParseInt(macro.GetValue("index"));
            grpNo = ParseInt(macro.GetValue("grpNo"));
            deleteType = (SEQ_DEF_PARTICLE_DELETE)ParseInt(macro.GetValue("deleteType"), 0);
        }
    }
}