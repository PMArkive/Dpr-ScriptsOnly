namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffBackGroundTrgChangeAnimState, "pink", "one_frame", "")]
	public class EffBackGroundTrgChangeAnimState : Macro
	{
		public string target;
		public string state;
		
		public EffBackGroundTrgChangeAnimState(Macro macro) : base(macro)
        {
            target = ParseString(macro.GetValue("target"));
            state = ParseString(macro.GetValue("state"));
        }
    }
}