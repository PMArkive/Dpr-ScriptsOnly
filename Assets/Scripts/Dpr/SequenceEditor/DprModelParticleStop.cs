namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DprModelParticleStop, "pink", "one_frame", "")]
	public class DprModelParticleStop : Macro
	{
		public int particleIndex;
		
		public DprModelParticleStop(Macro macro) : base(macro)
        {
            particleIndex = ParseInt(macro.GetValue("particleIndex"), 0);
        }
    }
}