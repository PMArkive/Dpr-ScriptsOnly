namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.BallBarDisp, "lightblue", "one_frame", "")]
    public class BallBarDisp : Macro
    {
        public SEQ_DEF_POS trg;

        public BallBarDisp(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
        }
    }
}