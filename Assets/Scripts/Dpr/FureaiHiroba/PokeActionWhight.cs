using Dpr.SubContents;

namespace Dpr.FureaiHiroba
{
    public class PokeActionWhight : IHaveWeight
    {
        public string Name;
        public int ActionNo;
        private float _weight;

        public float lotteryWeight { get => _weight; }

        public PokeActionWhight(string name, int ActionNo, float weight)
        {
            this.Name = name;
            this.ActionNo = ActionNo;
            this._weight = weight;
        }
    }
}