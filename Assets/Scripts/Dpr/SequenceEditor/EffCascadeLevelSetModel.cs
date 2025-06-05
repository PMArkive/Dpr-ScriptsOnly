namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffCascadeLevelSetModel, "lightgreen", "", "")]
	public class EffCascadeLevelSetModel : Macro
	{
		public int grpNo;
		public int level;
		
		public EffCascadeLevelSetModel(Macro macro) : base(macro)
        {
            grpNo = ParseInt(macro.GetValue("grpNo"));
            level = ParseInt(macro.GetValue("level"), 2);
        }
    }
}