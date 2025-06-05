using System;
using UnityEngine;

namespace XLSXContent
{
    [Serializable]
    public class MonohiroiKinomi : ScriptableObject
    {
        public SheetSheet1[] Sheet1;

        public SheetSheet1 this[int index] => Sheet1[index];

        [Serializable]
        public class SheetSheet1
        {
            public int Kakuritu;
            public int ItemID;
            public string ItemName;
        }
    }
}