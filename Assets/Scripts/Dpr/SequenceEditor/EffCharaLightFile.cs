namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.EffCharaLightFile, "lightgreen", "", "")]
	public class EffCharaLightFile : Macro
	{
		public SEQ_DEF_TRAINER trg;
		public string envfile;
		public bool enable;
		
		public EffCharaLightFile(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_TRAINER(macro.GetValue("trg"));
            envfile = ParseString(macro.GetValue("envfile"));
            enable = ParseBool(macro.GetValue("enable"), 1);
        }
    }
}