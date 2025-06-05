using System.Collections;
using UnityEngine;

public static class ExtensionMethods
{
    public static void ReplaceLayerRecursively(this GameObject self, int source, int destination)
    {
        if (self.layer == source)
            self.layer = destination;

        foreach (Transform child in self.transform)
            child.gameObject.ReplaceLayerRecursively(source, destination);
    }

    public static void SetLayerRecursively(this GameObject self, int layer)
    {
        self.layer = layer;
        foreach (var child in self.transform)
        {
            var tfChild = child as Transform;
            tfChild.gameObject.SetLayerRecursively(layer);
        }
    }

    public static T AddComponentIfNecessary<T>(this GameObject self) where T : Component
    {
        var component = self.GetComponent<T>();

        if (component != null)
            return component;

        return self.AddComponent<T>();
    }

    public static void SetPosition(this Transform self, Vector3 value)
    {
        self.position = value;
    }

    public static void SetPositionX(this Transform self, float value)
    {
        var pos = self.position;
        pos.x = value;
        self.position = pos;
    }

    public static void SetPositionY(this Transform self, float value)
    {
        var pos = self.position;
        pos.y = value;
        self.position = pos;
    }

    public static void SetPositionZ(this Transform self, float value)
    {
        var pos = self.position;
        pos.z = value;
        self.position = pos;
    }

    public static void SetLocalPosition(this Transform self, Vector3 value)
    {
        self.localPosition = value;
    }

    public static void SetLocalPositionX(this Transform self, float value)
    {
        var pos = self.localPosition;
        pos.x = value;
        self.localPosition = pos;
    }

    public static void SetLocalPositionY(this Transform self, float value)
    {
        var pos = self.localPosition;
        pos.y = value;
        self.localPosition = pos;
    }

    public static void SetLocalPositionZ(this Transform self, float value)
    {
        var pos = self.localPosition;
        pos.z = value;
        self.localPosition = pos;
    }

    public static void SetRotationEuler(this Transform self, Vector3 value)
    {
        self.rotation = Quaternion.Euler(value);
    }

    public static void SetRotationXEuler(this Transform self, float value)
    {
        var rot = self.rotation.eulerAngles;
        rot.x = value;
        self.rotation = Quaternion.Euler(rot);
    }

    public static void SetRotationYEuler(this Transform self, float value)
    {
        var rot = self.rotation.eulerAngles;
        rot.y = value;
        self.rotation = Quaternion.Euler(rot);
    }

    public static void SetRotationZEuler(this Transform self, float value)
    {
        var rot = self.rotation.eulerAngles;
        rot.z = value;
        self.rotation = Quaternion.Euler(rot);
    }

    public static void SetLocalRotationEuler(this Transform self, Vector3 value)
    {
        self.localRotation = Quaternion.Euler(value);
    }

    public static void SetLocalRotationXEuler(this Transform self, float value)
    {
        var rot = self.localRotation.eulerAngles;
        rot.x = value;
        self.localRotation = Quaternion.Euler(rot);
    }

    public static void SetLocalRotationYEuler(this Transform self, float value)
    {
        var rot = self.localRotation.eulerAngles;
        rot.y = value;
        self.localRotation = Quaternion.Euler(rot);
    }

    public static void SetLocalRotationZEuler(this Transform self, float value)
    {
        var rot = self.localRotation.eulerAngles;
        rot.z = value;
        self.localRotation = Quaternion.Euler(rot);
    }

    public static void SetLocalScale(this Transform self, Vector3 value)
    {
        self.localScale = value;
    }

    public static void SetLocalScaleX(this Transform self, float value)
    {
        var scale = self.localScale;
        scale.x = value;
        self.localScale = scale;
    }

    public static void SetLocalScaleY(this Transform self, float value)
    {
        var scale = self.localScale;
        scale.y = value;
        self.localScale = scale;
    }

    public static void SetLocalScaleZ(this Transform self, float value)
    {
        var scale = self.localScale;
        scale.z = value;
        self.localScale = scale;
    }

    public static T GetComponentThis<T>(this Component self, ref T value) where T : Component
    {
        if (value == null)
        {
            value = self.GetComponent<T>();
            return value;
        }

        return value;
    }

    public static T AddComponentIfNecessary<T>(this Component self) where T : Component
    {
        return self.gameObject.AddComponentIfNecessary<T>();
    }

    public static void SetActive(this Component self, bool value)
    {
        self.gameObject.SetActive(value);
    }

    public static bool IsNullOrEmpty(this IList self)
    {
        return self == null || self.Count == 0;
    }

    public static bool IsBounds(this IList self, int index)
    {
        return index >= 0 && index < self.Count;
    }
}