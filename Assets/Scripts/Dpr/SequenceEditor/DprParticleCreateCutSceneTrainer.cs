namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DprParticleCreateCutSceneTrainer, "green", "", "PreloadParticle")]
	public class DprParticleCreateCutSceneTrainer : Macro
	{
		public SEQ_DEF_TRAINER trg;
		public SEQ_DEF_PARTICLE_DELETE deleteType;
		
		public DprParticleCreateCutSceneTrainer(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_TRAINER(macro.GetValue("trg"));
            deleteType = (SEQ_DEF_PARTICLE_DELETE)ParseInt(macro.GetValue("deleteType"), 0);
        }
    }
}