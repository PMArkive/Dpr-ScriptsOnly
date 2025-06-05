namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PostEffectColorGradingSet, "lightgreen", "", "")]
	public class PostEffectColorGradingSet : Macro
	{
		public string texture;
		public float influence;
		public SEQ_DEF_MOVETYPE move;
		
		public PostEffectColorGradingSet(Macro macro) : base(macro)
        {
            texture = ParseString(macro.GetValue("texture"));
            influence = ParseFloat(macro.GetValue("influence"), 1.0f);
            move = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("move"));
        }
    }
}