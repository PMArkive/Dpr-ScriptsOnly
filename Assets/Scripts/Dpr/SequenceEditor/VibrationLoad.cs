namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.VibrationLoad, "blue", "one_frame", "PreloadVibration")]
	public class VibrationLoad : Macro
	{
		public string hash;
		
		public VibrationLoad(Macro macro) : base(macro)
        {
            hash = ParseString(macro.GetValue("hash"));
        }
    }
}