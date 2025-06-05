namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.GPokemonEffectVisible, "red", "one_frame", "")]
	public class GPokemonEffectVisible : Macro
	{
		public SEQ_DEF_POS trg;
		public SEQ_DEF_MOVETYPE obj;
		public bool visible;
		public bool fade;
		
		public GPokemonEffectVisible(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            obj = Parse_SEQ_DEF_MOVETYPE(macro.GetValue("obj"));
            visible = ParseBool(macro.GetValue("visible"), 0);
            fade = ParseBool(macro.GetValue("fade"), 0);
        }
    }
}