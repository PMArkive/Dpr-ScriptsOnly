namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffCharaLightEnv, "lightgreen", "", "")]
	public class EffCharaLightEnv : Macro
	{
		public SEQ_DEF_TRAINER trg;
		public SEQ_DEF_TR_ENV type;
		public bool enable;
		
		public EffCharaLightEnv(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_TRAINER(macro.GetValue("trg"));
            type = Parse_SEQ_DEF_TR_ENV(macro.GetValue("type"));
            enable = ParseBool(macro.GetValue("enable"), 1);
        }
    }
}