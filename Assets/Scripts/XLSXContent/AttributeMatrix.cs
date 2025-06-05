using System;
using UnityEngine;

[Serializable]
public class AttributeMatrix : ScriptableObject
{
    public AttributeBlock[] AttributeBlocks;
    public int Width;

    public AttributeBlock this[int index] { get => AttributeBlocks[index]; }

    public AttributeBlock this[int gridX, int gridY]
    {
        get
        {
            if (gridX > -1 && gridY > -1)
                return AttributeBlocks[gridX + Width * gridY];
            else
                return null;
        }
    }
}