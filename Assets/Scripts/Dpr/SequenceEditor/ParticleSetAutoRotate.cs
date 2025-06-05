namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.ParticleSetAutoRotate, "green", "one_frame", "")]
	public class ParticleSetAutoRotate : Macro
	{
		public bool isEnable;
		
		public ParticleSetAutoRotate(Macro macro) : base(macro)
        {
            isEnable = ParseBool(macro.GetValue("isEnable"), 1);
        }
    }
}