namespace Dpr.FureaiHiroba
{
    public class PokeSanpoPairModel
    {
        public FureaiPokeModel masterPoke;
        public FureaiPokeModel slavePoke;
        public bool isMaster;

        public FureaiPokeModel self { get => isMaster ? masterPoke : slavePoke; }
        public FureaiPokeModel pair { get => isMaster ? slavePoke : masterPoke; }

        public PokeSanpoPairModel(bool isMaster, FureaiPokeModel masterPoke, FureaiPokeModel slavePoke)
        {
            this.isMaster = isMaster;
            this.masterPoke = masterPoke;
            this.slavePoke = slavePoke;
        }

        public void Destroy()
        {
            masterPoke = null;
            slavePoke = null;
        }
    }
}