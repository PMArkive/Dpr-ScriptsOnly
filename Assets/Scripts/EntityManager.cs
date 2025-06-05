using SmartPoint.AssetAssistant.UnityExtensions;
using System.Collections.Generic;
using System.Linq;

public static class EntityManager
{
    private static List<BaseEntity> _baseEntities = new List<BaseEntity>();

    public static BattlePlayerEntity activeBattlePlayer { get; set; } = null;
    public static FieldPlayerEntity activeFieldPlayer { get; set; } = null;
    public static FieldPokemonEntity activeFieldPartner { get; set; } = null;
    public static FieldPlayerEntity[] fieldPlayers { get; set; } = ArrayHelper.Empty<FieldPlayerEntity>();
    public static FieldPokemonEntity[] fieldPokemons { get; set; } = ArrayHelper.Empty<FieldPokemonEntity>();
    public static FieldCharacterEntity[] fieldCharacters { get; set; } = ArrayHelper.Empty<FieldCharacterEntity>();
    public static FieldObjectEntity[] fieldObjects { get; set; } = ArrayHelper.Empty<FieldObjectEntity>();
    public static FieldEventEntity[] fieldEventObjects { get; set; } = ArrayHelper.Empty<FieldEventEntity>();
    public static FieldEventDoorEntity[] fieldDoorObjects { get; set; } = ArrayHelper.Empty<FieldEventDoorEntity>();
    public static FieldEventLiftEntity[] fieldLiftObjects { get; set; } = ArrayHelper.Empty<FieldEventLiftEntity>();
    public static FieldTobariGymWallEntity[] fieldTobariGymWalls { get; set; } = ArrayHelper.Empty<FieldTobariGymWallEntity>();
    public static FieldNagisaGymGearEntity[] fieldNagisaGymGears { get; set; } = ArrayHelper.Empty<FieldNagisaGymGearEntity>();
    public static FieldNomoseGymWaterEntity[] fieldNomoseGymWater { get; set; } = ArrayHelper.Empty<FieldNomoseGymWaterEntity>();
    public static FieldNomoseGymSwitchEntity[] fieldNomoseGymSwitches { get; set; } = ArrayHelper.Empty<FieldNomoseGymSwitchEntity>();
    public static FieldElevatorBackgroundEntity[] fieldElevatorBackground { get; set; } = ArrayHelper.Empty<FieldElevatorBackgroundEntity>();
    public static FieldPokemonCenterEntity[] fieldPokemonCenter { get; set; } = ArrayHelper.Empty<FieldPokemonCenterEntity>();
    public static FieldPokemonCenterMonitorEntity[] fieldPokemonCenterMonitor { get; set; } = ArrayHelper.Empty<FieldPokemonCenterMonitorEntity>();
    public static FieldEventTrainEntity[] fieldEventTrain { get; set; } = ArrayHelper.Empty<FieldEventTrainEntity>();
    public static FieldEyePaintingEntity[] fieldEyePainting { get; set; } = ArrayHelper.Empty<FieldEyePaintingEntity>();
    public static FieldEmbankmentEntity[] fieldEmbankment { get; set; } = ArrayHelper.Empty<FieldEmbankmentEntity>();
    public static FieldTvEntity[] fieldTv { get; set; } = ArrayHelper.Empty<FieldTvEntity>();

    public static void Add(BaseEntity entity)
    {
        if (entity == null)
            return;

        if (activeFieldPlayer == null && entity != null && entity is FieldPlayerEntity)
            activeFieldPlayer = (FieldPlayerEntity)entity;
        else if (activeBattlePlayer == null && entity != null && entity is BattlePlayerEntity)
            activeBattlePlayer = (BattlePlayerEntity)entity;

        _baseEntities.Add(entity);
    }

    public static void Remove(BaseEntity entity)
    {
        if (entity == null)
            return;

        _baseEntities.Remove(entity);
    }

    public static T GetEntity<T>() where T : BaseEntity
    {
        return _baseEntities.Find(x => x.GetType() == typeof(T)) as T;
    }

    public static T[] GetEntities<T>() where T : BaseEntity
    {
        return _baseEntities.Where(x => x.GetType() == typeof(T)).Cast<T>().ToArray();
    }

    public static T[] GetInheritedEntities<T>() where T : BaseEntity
    {
        return _baseEntities.Where(x => x is T).Cast<T>().ToArray();
    }

    public static void BuildFieldEntities()
    {
        fieldPlayers = GetEntities<FieldPlayerEntity>();
        fieldPokemons = GetEntities<FieldPokemonEntity>();
        fieldCharacters = GetInheritedEntities<FieldCharacterEntity>();
        fieldObjects = GetInheritedEntities<FieldObjectEntity>();
        fieldEventObjects = GetInheritedEntities<FieldEventEntity>();
        fieldDoorObjects = GetInheritedEntities<FieldEventDoorEntity>();
        fieldLiftObjects = GetInheritedEntities<FieldEventLiftEntity>();
        fieldTobariGymWalls = GetInheritedEntities<FieldTobariGymWallEntity>();
        fieldNagisaGymGears = GetInheritedEntities<FieldNagisaGymGearEntity>();
        fieldNomoseGymWater = GetInheritedEntities<FieldNomoseGymWaterEntity>();
        fieldNomoseGymSwitches = GetInheritedEntities<FieldNomoseGymSwitchEntity>();
        fieldElevatorBackground = GetInheritedEntities<FieldElevatorBackgroundEntity>();
        fieldPokemonCenter = GetInheritedEntities<FieldPokemonCenterEntity>();
        fieldPokemonCenterMonitor = GetInheritedEntities<FieldPokemonCenterMonitorEntity>();
        fieldEventTrain = GetInheritedEntities<FieldEventTrainEntity>();
        fieldEyePainting = GetInheritedEntities<FieldEyePaintingEntity>();
        fieldEmbankment = GetInheritedEntities<FieldEmbankmentEntity>();
        fieldTv = GetInheritedEntities<FieldTvEntity>();

        if (activeFieldPlayer != null)
            return;

        if (fieldPlayers == null)
            activeFieldPlayer = null;
        else
            activeFieldPlayer = fieldPlayers.FirstOrDefault();
    }
}