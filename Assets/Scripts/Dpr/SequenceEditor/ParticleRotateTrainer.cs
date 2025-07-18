namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ParticleRotateTrainer, "green", "", "")]
	public class ParticleRotateTrainer : Macro
	{
		public SEQ_DEF_TRAINER trg;
		public string node;
		public float ofs;
		public bool vertical;
		public SEQ_DEF_MOVETYPE move;
		
		public ParticleRotateTrainer(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_TRAINER(macro.GetValue("trg"));
            node = ParseString(macro.GetValue("node"));
            ofs = ParseFloat(macro.GetValue("ofs"));
            vertical = ParseBool(macro.GetValue("vertical"), 0);
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}