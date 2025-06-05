using UnityEngine;

public class Layer
{
    public static readonly int Nothing = 0;
    public static readonly int Everything = -1;
    public static readonly int DefaultLayer = LayerMask.NameToLayer("Default");
    public static readonly int JumpLayer = LayerMask.NameToLayer("Jump");
    public static readonly int GroundLayer = LayerMask.NameToLayer("Ground");
    public static readonly int Ground = 1 << GroundLayer;
    public static readonly int ObstacleLayer = LayerMask.NameToLayer("Obstacle");
    public static readonly int Obstacle = 1 << ObstacleLayer;
    public static readonly int Event = 1 << LayerMask.NameToLayer("Event");
    public static readonly int Jump = 1 << JumpLayer;
    public static readonly int Attribute = 1 << LayerMask.NameToLayer("Attribute");
    public static readonly int CharacterLayer = LayerMask.NameToLayer("Character");
    public static readonly int Character = 1 << CharacterLayer;
    public static readonly int FieldLayer = LayerMask.NameToLayer("Field");
    public static readonly int Field = 1 << FieldLayer;
    public static readonly int EffectLayer = LayerMask.NameToLayer("Effect");
    public static readonly int Effect = 1 << EffectLayer;
    public static readonly int NoRendererLayer = LayerMask.NameToLayer("NoRenderer");
    public static readonly int NoRenderer = 1 << NoRendererLayer;
    public static readonly int UI = 1 << LayerMask.NameToLayer("UI");
    public static readonly int UIModelLayer = LayerMask.NameToLayer("UIModel");
}