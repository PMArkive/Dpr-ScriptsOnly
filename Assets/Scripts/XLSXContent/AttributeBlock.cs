using System;
using UnityEngine;

[Serializable]
public class AttributeBlock : ScriptableObject
{
    public int[] Attributes;
    public int Width;

    public int this[int index] { get => Attributes[index]; }

    public int this[int gridX, int gridY] { get => Attributes[gridX + Width * gridY]; }

    public int Length { get => Attributes.Length; }
}