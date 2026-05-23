namespace Dpr.Battle.Logic
{
    public sealed class AiScript
    {
        private static BtlAIBaseScript[] s_PawnBaeCache = new BtlAIBaseScript[(int)BtlAiScriptNo.BTL_AISCRIPT_NO_NUM];
        private uint m_loadedScriptNo; // Seems to never be assigned to other than in the constructor
        private BtlAIBaseScript m_script;

        public AiScript()
        {
            m_script = null;
            m_loadedScriptNo = (int)BtlAiScriptNo.BTL_AISCRIPT_NO_NULL;
        }

        public bool StartLoadScript(BtlAiScriptNo scriptNo)
        {
            if (m_script == null || m_loadedScriptNo != (uint)scriptNo)
                m_script = CreateScriptBase((uint)scriptNo);

            return true;
        }

        private static BtlAIBaseScript CreateScriptBase(uint scriptNo)
        {
            if (s_PawnBaeCache[scriptNo] != null)
                return s_PawnBaeCache[scriptNo];

            BtlAIBaseScript script;
            switch ((BtlAiScriptNo)scriptNo)
            {
                case BtlAiScriptNo.BTL_AISCRIPT_NO_WAZA_BASIC:
                    script = new BtlAiBasic();
                    break;

                case BtlAiScriptNo.BTL_AISCRIPT_NO_WAZA_STRONG:
                    script = new BtlAiStrong();
                    break;

                case BtlAiScriptNo.BTL_AISCRIPT_NO_WAZA_EXPERT:
                    script = new BtlAiExpert();
                    break;

                case BtlAiScriptNo.BTL_AISCRIPT_NO_WAZA_DOUBLE:
                    script = new BtlAiDouble();
                    break;

                case BtlAiScriptNo.BTL_AISCRIPT_NO_WAZA_ALLOWANCE:
                    script = new BtlAiAllowance();
                    break;

                case BtlAiScriptNo.BTL_AISCRIPT_NO_ITEM_BASIC:
                    script = new BtlAiItem();
                    break;

                case BtlAiScriptNo.BTL_AISCRIPT_NO_POKECHANGE_BASIC:
                    script = new BtlAiPokeChange();
                    break;

                default:
                    script = null;
                    break;
            }

            if (script == null)
                return null;

            s_PawnBaeCache[scriptNo] = script;
            return script;
        }

        public static void ReleaseAiScriptCache()
        {
            for (int i=0; i<s_PawnBaeCache.Length; i++)
                s_PawnBaeCache[i] = null;
        }

        public bool WaitLoadScript()
        {
            return m_script != null;
        }

        public void SetExecParameter(AiScriptCommandHandler commandHandler)
        {
            if (m_script != null)
            {
                m_script.SetGlobalParameters(commandHandler.GetCommandParam().clientID, 0, 0);
                BattleAiCommand.SetCommandHandler(commandHandler.GetCommandParam().clientID, commandHandler);
            }
        }

        public bool Execute()
        {
            m_script?.Execute();

            return true;
        }

        public void GetResult(Result dest)
        {
            m_script.GetResult(dest);
        }

        public void UnLoadScript()
        {
            m_script = null;
        }

        public class Result
        {
            public int score;
            public bool isPokeChangeEnable;
        }
    }
}