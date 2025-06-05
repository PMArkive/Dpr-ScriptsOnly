namespace Dpr.Battle.Logic
{
    public sealed class WazaCommandPutter
    {
        private ServerCommandQueue m_pCommandQueue;
        private ServerCommandPutter m_pCommandPutter;

        public WazaCommandPutter(in SetupParam param)
        {
            m_pCommandQueue = param.pCommandQueue;
            m_pCommandPutter = param.pCommandPutter;
        }

        // TODO
        public void ReserveMessage(WazaMessageParam pMsgParam) { }

        // TODO
        public void PutMessageToReservedPos(WazaMessageParam pMsgParam, WazaEffectParams pEffectParam) { }

        // TODO
        public void PutMessage(WazaMessageParam pMsgParam, WazaEffectParams pEffectParam) { }

        // TODO
        private void putMessage(WazaMessageParam pMsgParam, WazaEffectParams pEffectParam) { }

        // TODO
        public void PutWazaEffect(in WazaParam wazaParam, WazaEffectParams wazaEffect, in WazaEffectReservedPos reservedQueuePos) { }

        public class SetupParam
        {
            public ServerCommandQueue pCommandQueue;
            public ServerCommandPutter pCommandPutter;
        }
    }
}