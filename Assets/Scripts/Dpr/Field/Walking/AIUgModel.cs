using System.Collections.Generic;
using UnityEngine;

namespace Dpr.Field.Walking
{
    public class AIUgModel : AIModel
    {
        public List<Vector3> entrancePosition = new List<Vector3>();
        public Vector3 InitPos;
        public MoveType moveType;

        public AIUgModel(UgPokeController controller) : base(controller)
        {
            // Empty
        }

        public override void Destroy()
        {
            base.Destroy();
            entrancePosition.Clear();
        }
    }
}