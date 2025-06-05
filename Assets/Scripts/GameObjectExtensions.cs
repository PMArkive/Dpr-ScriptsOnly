using UnityEngine;

public static class GameObjectExtensions
{
    // TODO
    public static T FindComponent<T>(this GameObject self, string name) { return default; }

    public static GameObject FindDeep(this GameObject self, string name, bool includeInactive = false)
    {
        var components = self.GetComponentsInChildren<Transform>(includeInactive);
        for (int i=0; i<components.Length; i++)
        {
            if (components[i].name == name)
                return components[i].gameObject;
        }

        return null;
    }

    // TODO
    public static void DeleteAllChild(this GameObject self) { }

    // TODO
    public static T GetComponentNullable<T>(this GameObject go) { return default; }
}