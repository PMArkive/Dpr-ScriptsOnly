using Pml;

namespace Dpr.Battle.Logic
{
    public sealed class PartyDesc
    {
        public PokeDesc[] pokeDesc = Arrays.InitializeWithDefaultInstances<PokeDesc>(PokeParty.MAX_MEMBERS);

        // TODO
        public static void Clear(PartyDesc desc) { }

        // TODO
        public static void Copy(PartyDesc dest, in PartyDesc src) { }
    }
}
