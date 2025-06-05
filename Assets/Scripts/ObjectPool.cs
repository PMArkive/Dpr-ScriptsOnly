using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool<TKey, TValue> where TValue : IObjectPoolInstance, new()
{
    public Dictionary<TKey, Param> _dict = new Dictionary<TKey, Param>();

    // Some of the code below is presumed, it's hard to understand ghidra here (especially Release)

    public void Instantiates(int count, TKey key, GameObject prefab, Transform parentTransform)
    {
        var param = new Param
        {
            _prefab = prefab,
            _parentTransform = parentTransform,
            _values = new List<TValue>(),
        };

        for (int i=0; i<count; i++)
        {
            var obj = Object.Instantiate(prefab, parentTransform, false);
            obj.SetActive(false);
            var newInstance = new TValue();
            newInstance.SetGameObject(obj);
            param._values.Add(newInstance);
        }

        _dict[key] = param;
    }

    public bool Destroies(TKey key)
    {
        if (!_dict.TryGetValue(key, out Param param))
            return false;

        for (int i=0; i<param._values.Count; i++)
            Object.Destroy(param._values[i].GetGameObject());

        _dict.Remove(key);
        return true;
    }
    
    public TValue Create(TKey key, bool isActived = true)
    {
        if (!_dict.TryGetValue(key, out Param param))
            return default(TValue);

        if (param._values.Count == 0)
        {
            var obj = Object.Instantiate(param._prefab, param._parentTransform, false);
            var newInstance = new TValue();
            newInstance.SetGameObject(obj);
            param._values.Add(newInstance);
        }

        var lastInstance = param._values[param._values.Count - 1];
        param._values.RemoveAt(param._values.Count - 1);
        lastInstance.GetGameObject().SetActive(isActived);
        lastInstance.OnCreate();

        return lastInstance;
    }

    public bool Release(TKey key, TValue value, bool isForceDelete = false)
    {
        var obj = value.GetGameObject();

        if (_dict.TryGetValue(key, out Param param) && !isForceDelete)
        {
            if (obj != null)
            {
                obj.SetActive(false);
                value.OnRelease();
                obj.transform.SetParent(param._parentTransform, false);

                if (!param._values.Any(x => x.GetGameObject() == obj))
                    param._values.Add(value);

                return true;
            }
        }

        value.OnRelease();
        if (obj != null)
        {
            obj.transform.SetParent(null);
            Object.Destroy(obj);
        }

        return false;
    }

    public class Param
    {
        public GameObject _prefab;
        public Transform _parentTransform;
        public List<TValue> _values;
    }
}