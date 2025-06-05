using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class MaterialParam
{
    public Material mat;
    public MaterialUsing[] usings;

    public void SetUpUsing(Renderer[] renderers)
    {
        var list = new ArrayList();

        for (int i=0; i<renderers.Length; i++)
        {
            var renderer = renderers[i];
            for (int j=0; j<renderer.sharedMaterials.Length; j++)
            {
                if (renderer.sharedMaterials[j] != null && renderer.sharedMaterials[j] == mat)
                {
                    list.Add(new MaterialUsing()
                    {
                        renderer = renderer,
                        index = j,
                    });
                    break;
                }
            }
        }

        usings = list.ToArray(typeof(MaterialUsing)) as MaterialUsing[];
    }
}