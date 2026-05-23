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
			if (Call(CMD_CHECK_DAMAGE_WAZA, new long[] { (ushort)CurrentWazaNo() }) == 0)
				return;

			// User is not afflicted by Fake Out
            if (Call(CMD_CHECK_NEKODAMASI, new long[] { CHECK_ATTACK }) == 0)
			{
				ScoreCtrl(1);
				return;
			}

			// Target's HP is under 20%
			if (Call(CMD_IF_HP_UNDER, new long[] { CHECK_DEFENCE, 20 }) != 0)
			{
                // 220/256 chance (85.94%)
                if (Call(CMD_IF_RND_UNDER, new long[] { 220 }) != 0)
				{
                    ScoreCtrl(-1);
                    return;
                }
            }
            // Target's HP is under 40%
            else if (Call(CMD_IF_HP_UNDER, new long[] { CHECK_DEFENCE, 40 }) != 0)
			{
                // 150/256 chance (58.59%)
                if (Call(CMD_IF_RND_UNDER, new long[] { 150 }) != 0)
                {
                    ScoreCtrl(-1);
                    return;
                }
            }
        }
	}
}