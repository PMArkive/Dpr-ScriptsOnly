namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.SpecialQuizResult, "purple", "one_frame", "")]
	public class SpecialQuizResult : Macro
	{
		public SEQ_DEF_FAIRY_QUIZ_TYPE type1;
		public SEQ_DEF_FAIRY_QUIZ_RESULT result1;
		public SEQ_DEF_FAIRY_QUIZ_TYPE type2;
		public SEQ_DEF_FAIRY_QUIZ_RESULT result2;
		public SEQ_DEF_FAIRY_QUIZ_TYPE type3;
		public SEQ_DEF_FAIRY_QUIZ_RESULT result3;
		
		public SpecialQuizResult(Macro macro) : base(macro)
        {
            type1 = Parse_SEQ_DEF_FAIRY_QUIZ_TYPE(macro.GetValue("type1"));
            result1 = Parse_SEQ_DEF_FAIRY_QUIZ_RESULT(macro.GetValue("result1"));
            type2 = Parse_SEQ_DEF_FAIRY_QUIZ_TYPE(macro.GetValue("type2"));
            result2 = Parse_SEQ_DEF_FAIRY_QUIZ_RESULT(macro.GetValue("result2"));
            type3 = Parse_SEQ_DEF_FAIRY_QUIZ_TYPE(macro.GetValue("type3"));
            result3 = Parse_SEQ_DEF_FAIRY_QUIZ_RESULT(macro.GetValue("result3"));
        }
    }
}