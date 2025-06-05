using UnityEngine;

namespace Dpr.SequenceEditor
{
    [Macro(CommandNo.PokemonShaderCol, "red", "", "")]
	public class PokemonShaderCol : Macro
	{
		public SEQ_DEF_POS trg;
		public Vector3 start_col;
		public float start_pow;
		public Vector3 end_col;
		public float end_pow;
		
		public PokemonShaderCol(Macro macro) : base(macro)
        {
            trg = Parse_SEQ_DEF_POS(macro.GetValue("trg"));
            start_col = ParseVector3(macro.GetValue("start_col"), 1.0f, 1.0f, 1.0f);
            start_pow = ParseFloat(macro.GetValue("start_pow"));
            end_col = ParseVector3(macro.GetValue("end_col"), 1.0f, 1.0f, 1.0f);
            end_pow = ParseFloat(macro.GetValue("end_pow"));
        }
    }
}