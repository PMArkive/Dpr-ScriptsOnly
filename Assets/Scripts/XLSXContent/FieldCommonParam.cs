using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class FieldCommonParam : ScriptableObject
    {
        public Sheetdata[] data;

        public Sheetdata this[int index] => data[index];

        [Serializable]
        public class Sheetdata
        {
            public float param;
        }
    }
}