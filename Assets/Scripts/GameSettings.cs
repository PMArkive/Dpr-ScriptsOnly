using System;
using UnityEngine;
using XLSXContent;

[CreateAssetMenu(menuName = "ScriptableObjects/GameSettings", fileName = "GameSettings")]
[Serializable]
public class GameSettings : ScriptableObject
{
    [SerializeField]
    public MapInfo mapInfo;
    [SerializeField]
    public ArenaInfo arenaInfo;
    [SerializeField]
    public MapAttributeTable mapAttributeTable;
    [SerializeField]
    public MapAttributeExTable mapAttributeExTable;
    [SerializeField]
    public CalenderEncTable calenderEncTable;
    [SerializeField]
    public FieldEncountTable fieldEncountTable_d;
    [SerializeField]
    public FieldEncountTable fieldEncountTable_p;
    [SerializeField]
    public WaterSettings waterSettings;
}