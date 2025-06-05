using UnityEngine;

public static class ComponentExtensions
{
    public static T FindComponent<T>(this Component self, string name) where T : Component
    {
        var tf = self.transform.Find(name);
        if (tf == null)
            return null;

        return tf.GetComponent<T>();
    }

    public static GameObject FindDeep(this Component self, string name, bool includeInactive = false)
    {
        var components = self.GetComponentsInChildren<Transform>(includeInactive);
        for (int i=0; i<components.Length; i++)
        {
            if (components[i].name == name)
                return components[i].gameObject;
        }

        return null;
    }
}