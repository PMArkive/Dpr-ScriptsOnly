namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.DprModelParticlePlay, "pink", "", "")]
	public class DprModelParticlePlay : Macro
	{
		public int particleIndex;
		
		public DprModelParticlePlay(Macro macro) : base(macro)
        {
            particleIndex = ParseInt(macro.GetValue("particleIndex"), 0);
        }
    }
}