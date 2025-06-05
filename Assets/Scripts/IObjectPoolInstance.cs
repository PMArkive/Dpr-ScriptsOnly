using UnityEngine;

public interface IObjectPoolInstance
{
    void SetGameObject(GameObject obj);

    GameObject GetGameObject();

    void OnCreate();

    void OnRelease();
}