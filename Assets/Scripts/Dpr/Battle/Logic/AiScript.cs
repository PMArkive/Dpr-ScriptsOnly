namespace Dpr.Battle.Logic
{
    public sealed class AiScript
    {
        private static BtlAIBaseScript[] s_PawnBaeCache = new BtlAIBaseScript[(int)BtlAiScriptNo.BTL_AISCRIPT_NO_NUM];
        private uint m_loadedScriptNo;
        private BtlAIBaseScript m_script;

        public AiScript()
        {
            m_script = null;
            m_loadedScriptNo = (int)BtlAiScriptNo.BTL_AISCRIPT_NO_NULL;
        }

        // TODO
        public bool StartLoadScript(BtlAiScriptNo scriptNo) { return false; }

        // TODO
        private static BtlAIBaseScript CreateScriptBase(uint scriptNo) { return null; }

        // TODO
        public static void ReleaseAiScriptCache() { }

        // TODO
        public bool WaitLoadScript() { return false; }

        // TODO
        public void SetExecParameter(AiScriptCommandHandler commandHandler) { }

        // TODO
        public bool Execute() { return false; }

        // TODO
        public void GetResult(Result dest) { }

        // TODO
        public void UnLoadScript() { }

        public class Result
        {
            public int score;
            public bool isPokeChangeEnable;
        }
    }
}