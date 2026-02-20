namespace Dpr.Battle.Logic
{
	public class BtlAiAllowance : BtlAIBaseScript
	{
		protected override void main()
		{
			_ = string.Format("■PAWN allowanceAI start ...wazaNo = {0}[{1}], score={2}\n", CurrentWazaNo(), (int)CurrentWazaNo(), p_Score);
			main_proc();
            _ = string.Format("■PAWN allowanceAI score = {0}\n", p_Score);
        }
		
		private void main_proc()
		{
			// Move does 0 damage
			if (Call(CMD_CHECK_DAMAGE_WAZA, new long[] { (ushort)CurrentWazaNo() }) == HAVE_NO)
				return;

			// Attacker not affected by Fake Out
            if (Call(CMD_CHECK_NEKODAMASI, new long[] { CHECK_ATTACK }) == HAVE_NO)
			{
				ScoreCtrl(1);
				return;
			}

			// If HP is under 20%, 220/256 chance (85.94%) for -1 score
			if (Call(CMD_IF_HP_UNDER, new long[] { CHECK_DEFENCE, 20 }) != HAVE_NO)
			{
				if (Call(CMD_IF_RND_UNDER, new long[] { 220 }) != HAVE_NO)
				{
                    ScoreCtrl(-1);
                    return;
                }
            }
            // If HP is under 40%, 150/256 chance (58.59%) for -1 score
            else if (Call(CMD_IF_HP_UNDER, new long[] { CHECK_DEFENCE, 40 }) != HAVE_NO)
			{
                if (Call(CMD_IF_RND_UNDER, new long[] { 150 }) != HAVE_NO)
                {
                    ScoreCtrl(-1);
                    return;
                }
            }
        }
	}
}