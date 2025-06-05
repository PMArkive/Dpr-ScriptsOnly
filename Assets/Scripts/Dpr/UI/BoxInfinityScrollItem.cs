using Pml.PokePara;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.UI
{
    public class BoxInfinityScrollItem : MonoBehaviour
    {
        // TODO
        public virtual void Setup(BaseParam param) { }

        public class BaseParam
        {
            public int paramIndex = -1;
            public List<ItemParam> itemParams = new List<ItemParam>();
            public BoxWindow.DisplayMode displayMode;

            public class ItemParam
            {
                public PokemonParam pokemonParam;
                public BoxItem.Param itemParam;
            }
        }
    }
}