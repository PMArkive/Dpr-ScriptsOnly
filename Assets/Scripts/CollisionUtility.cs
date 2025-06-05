using UnityEngine;

public class CollisionUtility
{
    private static Collider[] _overlapResults = new Collider[16];

    public static Vector3 CollideObstacle(Vector3 position, float radius, Vector3 direction, float distance, out bool jump, out bool isCollided, out float dotAngle, int mask = -1, float threshold = 0.99f)
    {
        return CollideObstacle(position, radius, direction, distance, out jump, out isCollided, out dotAngle, out _, mask, threshold);
    }

    public static bool IsCollideObstacle(Vector3 position, float radius, Vector3 direction, float distance, int mask = -1)
    {
        return Physics.SphereCast(position + new Vector3(0.0f, radius, 0.0f), radius, direction, out _, distance, mask);
    }

    public static Vector3 CollideObstacle(Vector3 position, float radius, Vector3 direction, float distance, out bool jump, out bool isCollided, out float dotAngle, out Vector3 colNormal, int mask = -1, float threshold = 0.99f)
    {
        jump = false;
        isCollided = false;
        dotAngle = 0.0f;
        colNormal = Vector3.zero;

        var newDir = direction * distance;

        if (Physics.SphereCast(position + new Vector3(0.0f, radius, 0.0f), radius, direction, out RaycastHit hit, distance, mask))
        {
            colNormal = hit.normal;
            dotAngle = Vector2.Dot(-(new Vector2(hit.normal.x, hit.normal.z).normalized), new Vector2(direction.x, direction.z).normalized);
            isCollided = true;

            newDir -= hit.normal * (distance - hit.distance) * Vector3.Dot(direction, hit.normal) * 1.1f;

            var mag = Vector3.Magnitude(newDir);
            if (mag > Vector3.kEpsilon && Physics.SphereCast(position, radius, newDir / mag, out _, mag, mask))
                newDir = Vector3.zero;
            else if (hit.collider.gameObject.layer == Layer.JumpLayer && Vector3.Dot(hit.collider.transform.forward, direction) > threshold)
                jump = true;
        }

        return newDir;
    }

    public static bool IsOverrapSphere(Transform target, Vector3 offset, float radius, int mask = -1)
    {
        return Physics.OverlapSphereNonAlloc(target.position + offset, radius, _overlapResults, mask) != 0;
    }

    public static Collider[] OverrapSphere(Transform target, Vector3 offset, float radius, out int count, int mask = -1)
    {
        count = Physics.OverlapSphereNonAlloc(target.position + offset, radius, _overlapResults, mask);
        return _overlapResults;
    }

    public static float CollideGround(Vector3 position, float rayHeightOffset, int mask)
    {
        if (Physics.Raycast(position + new Vector3(0.0f, rayHeightOffset, 0.0f), new Vector3(0.0f, -1.0f, 0.0f), out RaycastHit hit, 100.0f, mask))
            return hit.point.y - position.y;
        else
            return 0.0f;
    }

    public static bool IsCollideGround(Vector3 position, float rayHeightOffset, int mask)
    {
        return Physics.Raycast(position + new Vector3(0.0f, rayHeightOffset, 0.0f), new Vector3(0.0f, -1.0f, 0.0f), out _, 100.0f, mask);
    }

    public static float OverCollideGround(Vector3 position, float rayHeightOffset, int mask, bool log = false)
    {
        if (Physics.Raycast(position + new Vector3(0.0f, rayHeightOffset, 0.0f), new Vector3(0.0f, 1.0f, 0.0f), out RaycastHit hit, 10.0f, mask))
            return hit.point.y;
        else
            return 1.0f;
    }

    public static bool IsOverCollideGround(Vector3 position, float rayHeightOffset, int mask)
    {
        return Physics.Raycast(position + new Vector3(0.0f, rayHeightOffset, 0.0f), new Vector3(0.0f, 1.0f, 0.0f), out _, 10.0f, mask);
    }
}