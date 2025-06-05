namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ParticleDelete, "green", "one_frame", "")]
	public class ParticleDelete : Macro
	{
		public SEQ_DEF_PARTICLE_DELETE deleteType;
		
		public ParticleDelete(Macro macro) : base(macro)
        {
            deleteType = (SEQ_DEF_PARTICLE_DELETE)ParseInt(macro.GetValue("deleteType"), 0);
        }
	}
}