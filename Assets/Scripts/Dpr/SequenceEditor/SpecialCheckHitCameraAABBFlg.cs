namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SpecialCheckHitCameraAABBFlg, "yellow", "", "")]
	public class SpecialCheckHitCameraAABBFlg : Macro
	{
		public bool poke;
		public bool tra;
		
		public SpecialCheckHitCameraAABBFlg(Macro macro) : base(macro)
        {
            poke = ParseBool(macro.GetValue("poke"), 1);
            tra = ParseBool(macro.GetValue("tra"), 1);
        }
    }
}