namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.TrainerSetEyeBlinkFlg, "red", "", "")]
	public class TrainerSetEyeBlinkFlg : Macro
	{
		public SEQ_DEF_TRAINER_ADD trg;
		public bool enable;
		public bool check;
		public bool loseCheck;
		
		public TrainerSetEyeBlinkFlg(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_TRAINER_ADD(macro.GetValue("trg"));
            enable = ParseBool(macro.GetValue("enable"), 1);
            check = ParseBool(macro.GetValue("check"));
            loseCheck = ParseBool(macro.GetValue("loseCheck"));
        }
    }
}