using System.Collections.Generic;
using UnityEngine;

namespace Dpr.FureaiHiroba
{
    internal class FormationData
    {
        private Dictionary<int, List<Vector2>> FormationOffsets = new Dictionary<int, List<Vector2>>();

        public void SetFormationOffsets(int pokeNum, List<Vector2> formation)
        {
            FormationOffsets.Add(pokeNum, formation);
        }

        public Vector3 GetOffset(int pokeNum, int positionNo)
        {
            var item = FormationOffsets[pokeNum];
            return new Vector3(item[positionNo].x, 0.0f, -item[positionNo].y);
        }
    }
}