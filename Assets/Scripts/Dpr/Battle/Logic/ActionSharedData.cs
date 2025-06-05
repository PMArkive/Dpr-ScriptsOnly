namespace Dpr.Battle.Logic
{
    public sealed class ActionSharedData
    {
        public WazaMessageParam wazaMessageParam = new WazaMessageParam();
        public WazaEffectParams wazaEffectParams = new WazaEffectParams();
        public WazaRobParam magicCoatParam = new WazaRobParam();
        public bool isWazaFailMessageDisplayed;
        public bool isWazaFailMessageRoundUp;
        public bool isInterruptAction;
    }
}