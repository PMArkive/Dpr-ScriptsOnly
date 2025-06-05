using System;
using UnityEngine;

namespace Dpr
{
    public class PatcheelPattern : MonoBehaviour
    {
        private const int PATCH_NUM = 4;
        private const int UV_TBL_SIZE = 256;
        public UVData[] UVDatas = new UVData[PATCH_NUM];

        public void Awake()
        {
            SetPattern();
        }

        public void SetPattern(uint personalRand = 0x6678397A)
        {
            UVDatas[0].value = (int)((personalRand >> 0x18) & 0xFF);
            UVDatas[1].value = (int)((personalRand >> 0x10) & 0xFF);
            UVDatas[2].value = (int)((personalRand >> 0x08) & 0xFF);
            UVDatas[3].value = (int)(personalRand           & 0xFF);

            for (int i=0; i<UVDatas.Length; i++)
            {
                var uvs = UVDatas[i].UVs;
                var val = UVDatas[i].value;

                var x = uvs[val].x;
                var y = uvs[val].y;

                UVDatas[i].renderer.material.SetTextureOffset("_Col0Tex", new Vector2(x * -8.0f, y * -8.0f));
            }
        }

        public static void SetPattern(GameObject obj, uint personalRand)
        {
            obj.GetComponent<PatcheelPattern>().SetPattern(personalRand);
        }

        [Serializable]
        public class UVData
        {
	        public SkinnedMeshRenderer renderer;
            public Vector2[] UVs = new Vector2[UV_TBL_SIZE];
            public int value;
        }
    }
}