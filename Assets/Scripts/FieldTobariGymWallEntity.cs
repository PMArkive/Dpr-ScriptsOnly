using DPData;
using UnityEngine;

public class FieldTobariGymWallEntity : FieldObjectEntity
{
    public override string entityType { get => "FieldCollision"; }

    public float GymWallLeftValue;
    public float GymWallRightValue;
    public string GymWallPushEventLabel;
    public bool GymWallBottomColOff_Left;
    public bool GymWallBottomColOff_Right;

    public bool WallIsLeftLimit { get; set; }
    public bool WallIsRightLimit { get; set; }
    public float GymWallWorldLeftValue { get; set; }
    public float GymWallWorldRightValue { get; set; }

    private BoxCollider[] Colliders;
    private Rect RoughlyColRect;
    private float LeftColX;
    private float RightColX;
    private bool RequestUpdateRoughlyColRect;

    protected override void Awake()
    {
        float ToWorldValue(float localValue)
        {
            var pos = transform.localPosition;
            pos.x = localValue;
            return transform.parent.TransformPoint(pos).x;
        }

        base.Awake();
        GymWallWorldLeftValue = ToWorldValue(GymWallLeftValue);
        GymWallWorldRightValue = ToWorldValue(GymWallRightValue);
        isLanding = false;
    }

    protected override void OnUpdate(float deltaTime)
    {
        base.OnUpdate(deltaTime);

        if (!isActiveAndEnabled || !RequestUpdateRoughlyColRect)
            return;

        SetupCol();
        RequestUpdateRoughlyColRect = false;
    }

    public void ApplySaveData(in FIELD_OBJ_SAVE_DATA saveData)
    {
        var pos = worldPosition;
        switch (saveData.mv_dir)
        {
            case 1:
                pos.x = GymWallWorldLeftValue;
                break;

            case 2:
                pos.x = GymWallWorldRightValue;
                break; 
        }

        SetPositionDirect(pos);
    }

    public void CreateSaveData(ref FIELD_OBJ_SAVE_DATA saveData)
    {
        if (WallIsLeftLimit)
            saveData.mv_dir = 1;
        else if (WallIsRightLimit)
            saveData.mv_dir = 2;
        else
            saveData.mv_dir = 0;
    }

    public void Setup()
    {
        isLanding = false;
        WallIsLeftLimit = Mathf.Abs(worldPosition.x - GymWallWorldLeftValue) < 0.01f;
        WallIsRightLimit = Mathf.Abs(worldPosition.x - GymWallWorldRightValue) < 0.01f;
        Colliders = GetComponents<BoxCollider>();
        RequestUpdateRoughlyColRect = true;
    }

    public void Moved(bool isLeft)
    {
        WallIsLeftLimit = isLeft;
        WallIsRightLimit = !isLeft;
        RequestUpdateRoughlyColRect = true;
    }

    private void SetupCol()
    {
        RoughlyColRect.xMin = float.MaxValue;
        RoughlyColRect.xMax = float.MinValue;
        RoughlyColRect.yMin = float.MaxValue;
        RoughlyColRect.yMax = float.MinValue;

        bool atLimit = (GymWallBottomColOff_Left && WallIsLeftLimit) || (GymWallBottomColOff_Right && WallIsRightLimit);

        for (int i=0; i<Colliders.Length; i++)
        {
            var collider = Colliders[i];
            var bounds = collider.bounds;
            collider.enabled = !atLimit || bounds.max.y > 1.0001f;
            RoughlyColRect.xMin = Mathf.Min(RoughlyColRect.xMin, bounds.min.x);
            RoughlyColRect.xMax = Mathf.Max(RoughlyColRect.xMax, bounds.max.x);
            RoughlyColRect.yMin = Mathf.Min(RoughlyColRect.yMin, bounds.min.z);
            RoughlyColRect.yMax = Mathf.Max(RoughlyColRect.yMax, bounds.max.z);
        }

        RightColX = RoughlyColRect.xMin;
        LeftColX = RoughlyColRect.xMax;
        RoughlyColRect.xMin = RoughlyColRect.xMin - 1.0f;
        RoughlyColRect.xMax = RoughlyColRect.xMax + 1.0f;
        RoughlyColRect.yMin = RoughlyColRect.yMin - 1.0f;
        RoughlyColRect.yMax = RoughlyColRect.yMax + 1.0f;
    }

    public bool CheckHit(Vector3 playerPos, Vector3 playerVec)
    {
        // Outside the left of the wall
        if (playerPos.x < RoughlyColRect.xMin)
            return false;

        // Outisde the right of the wall
        if (playerPos.x > RoughlyColRect.xMax)
            return false;

        // Outside the top of the wall
        if (playerPos.z < RoughlyColRect.yMin)
            return false;

        // Outside the bottom of the wall
        if (playerPos.z > RoughlyColRect.yMax)
            return false;

        // Going left, but the wall is already on the left or you're outside the right of the collision
        if (playerVec.x > 0.0f && (playerPos.x > RightColX || WallIsLeftLimit))
            return false;

        // Going right, but the wall is already on the right or you're outside the left of the collision
        if (playerVec.x < 0.0f && (playerPos.x < LeftColX || WallIsRightLimit))
            return false;

        // Not moving fast enough
        if (Mathf.Abs(playerVec.normalized.x) < 0.9238795f)
            return false;

        for (int i=0; i<Colliders.Length; i++)
        {
            var ray = new Ray(new Vector3(playerPos.x, playerPos.y + 0.4f, playerPos.z), playerVec.normalized);
            if (Colliders[i].Raycast(ray, out RaycastHit _, playerVec.magnitude))
                return true;
        }

        return false;
    }
}