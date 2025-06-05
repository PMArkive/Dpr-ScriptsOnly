namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.TrainerSetAnimationConfig, "red", "one_frame", "PreloadTrainerAnimationConfig")]
	public class TrainerSetAnimationConfig : Macro
	{
		public SEQ_DEF_TRAINER_ADD trg;
		public string cfgfile;
		public string pakfile;
		public bool isPlayer;
		
		public TrainerSetAnimationConfig(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_TRAINER_ADD(macro.GetValue("trg"));
            cfgfile = ParseString(macro.GetValue("cfgfile"));
            pakfile = ParseString(macro.GetValue("pakfile"));
            isPlayer = ParseBool(macro.GetValue("isPlayer"), 0);
        }
    }
}