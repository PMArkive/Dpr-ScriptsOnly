using Dpr.Field.Walking;
using UnityEngine;

namespace Dpr.FureaiHiroba
{
    public class PokeFureaiActionModel
    {
        public CorSystem corSystem;
        protected float IntervalTime;
        protected float elapsedTime;

        public bool IsAction { get => corSystem.isPlaying; }

        protected void Init()
        {
            elapsedTime = Random.Range(-2.0f, 2.0f);
            corSystem = new CorSystem("");
        }
    }
}