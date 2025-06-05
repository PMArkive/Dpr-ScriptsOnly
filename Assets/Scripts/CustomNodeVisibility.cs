using System;
using UnityEngine;

[Serializable]
public class CustomNodeVisibility
{
    public GameObject bone;
    public Renderer skin;

    public void Update()
    {
        if (skin != null)
            skin.enabled = Mathf.Abs(bone.transform.localPosition.x) >= 0.005f;
    }
}