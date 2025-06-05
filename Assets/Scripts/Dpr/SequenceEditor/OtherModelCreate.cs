namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.OtherModelCreate, "violet", "", "PreloadOtherModel")]
	public class OtherModelCreate : Macro
	{
		public SEQ_DEF_POS trg;
		public int Monsno;
		public int Form;
		public SEQ_DEF_MONS_SEX Sex;
		public bool IsRare;
		public bool IsEgg;
		public SEQ_DEF_POKE_G gType;
		
		public OtherModelCreate(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            Monsno = ParseInt(macro.GetValue("Monsno"));
            Form = ParseInt(macro.GetValue("Form"));
            Sex = Parse_SEQ_DEF_MONS_SEX(macro.GetValue("Sex"));
            IsRare = ParseBool(macro.GetValue("IsRare"), 0);
            IsEgg = ParseBool(macro.GetValue("IsEgg"), 0);
            gType = Parse_SEQ_DEF_POKE_G(macro.GetValue("gType"));
        }
    }
}