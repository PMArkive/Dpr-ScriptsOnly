using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PokemonMaskController
{
    private static readonly int STENCIL_ID = Shader.PropertyToID("_Stencil");
    private static readonly int STENCIL_OP_ID = Shader.PropertyToID("_StencilOp");
    private static readonly int POKEMON_STENCIL_ID = Shader.PropertyToID("_PokemonStencil");
    private static readonly int ZWRITE_ID = Shader.PropertyToID("_ZWrite");
    private static readonly int ZTEST_ID = Shader.PropertyToID("_ZTest");
    private const int START_STENCIL_ID = 8;
    private const int STENCIL_ENTRY_SIZE = 32;
    private static bool[] _stencilEntries = new bool[STENCIL_ENTRY_SIZE];
    private static Dictionary<BaseEntity, MaskAndCore> _maskGroups = new Dictionary<BaseEntity, MaskAndCore>();

    private static int FindEntry()
    {
        return Array.IndexOf(_stencilEntries, false);
    }

    public static void Register(BaseEntity baseEntity)
    {
        if (baseEntity == null)
            return;

        var nextEntryIndex = Array.IndexOf(_stencilEntries, false);

        if (_maskGroups.TryGetValue(baseEntity, out _))
            return;

        var entityName = baseEntity.entityEname;
        var isGastly = entityName.IndexOf("092") > -1;
        var isRotom = entityName.IndexOf("0479") > -1;

        var meshes = baseEntity.GetComponentsInChildren<SkinnedMeshRenderer>()
            .Where(__ => __ != null && __.sharedMaterials != null && __.sharedMaterials.Any(x =>
            {
                var shader = x.shader;

                if (shader == null)
                    return false;

                if (shader.name.IndexOf("Core") > -1 ||
                    shader.name.IndexOf("Mask") > -1 ||
                    shader.name.IndexOf("PetrifyFire") > -1)
                    return true;

                return (isGastly || isRotom) &&
                    (shader.name.IndexOf("Bump") > -1 ||
                     shader.name.IndexOf("Petrify") > -1);
            }));

        var meshesMask = new List<SkinnedMeshRenderer>();
        var meshesCoreOrPetrify = new List<SkinnedMeshRenderer>();
        var meshesNeither = new List<SkinnedMeshRenderer>();

        foreach (var mesh in meshes)
        {
            var mats = mesh.materials;
            for (int i=0; i<mats.Length; i++)
            {
                var mat = mats[i];
                var shader = mat.shader;

                if (shader == null)
                    continue;

                var coreOrPetrifyFireShader = shader.name.IndexOf("Core") > -1 || shader.name.IndexOf("PetrifyFire") > -1;
                var maskShader = shader.name.IndexOf("Mask") > -1;

                if (!coreOrPetrifyFireShader && !maskShader)
                {
                    mat.SetInt(POKEMON_STENCIL_ID, nextEntryIndex + 136);
                    mat.SetInt(STENCIL_OP_ID, 2);
                    meshesNeither.Add(mesh);
                }
                else if (maskShader)
                {
                    mat.SetInt(ZWRITE_ID, 1);
                    mat.renderQueue = 2451;
                    meshesMask.Add(mesh);

                    mat.SetInt(STENCIL_ID, nextEntryIndex + START_STENCIL_ID);
                }
                else
                {
                    if (coreOrPetrifyFireShader)
                    {
                        if (isGastly)
                            mat.SetInt(ZTEST_ID, 5);

                        mat.SetInt(ZWRITE_ID, 0);
                        mat.renderQueue = 2500;
                        meshesCoreOrPetrify.Add(mesh);
                    }

                    mat.SetInt(STENCIL_ID, nextEntryIndex + START_STENCIL_ID);
                }
            }
        }

        if (meshesMask.Count != 0 && meshesCoreOrPetrify.Count != 0)
        {
            _stencilEntries[nextEntryIndex] = true;
            _maskGroups.Add(baseEntity, new MaskAndCore()
            {
                entryIndex = nextEntryIndex,
                mask = meshesMask.ToArray(),
                core = meshesCoreOrPetrify.ToArray(),
                other = meshesNeither.ToArray(),
            });
        }
    }

    public static void Unregister(BaseEntity baseEntity)
    {
        if (!_maskGroups.TryGetValue(baseEntity, out MaskAndCore maskAndCore))
            return;

        for (int i=0; i<maskAndCore.mask.Length; i++)
        {
            var mats = maskAndCore.mask[i].materials;
            for (int j=0; j<mats.Length; j++)
                UnityEngine.Object.DestroyImmediate(mats[j]);
        }

        for (int i=0; i<maskAndCore.core.Length; i++)
        {
            var mats = maskAndCore.core[i].materials;
            for (int j=0; j<mats.Length; j++)
                UnityEngine.Object.DestroyImmediate(mats[j]);
        }

        for (int i=0; i<maskAndCore.other.Length; i++)
        {
            var mats = maskAndCore.other[i].materials;
            for (int j=0; j<mats.Length; j++)
                UnityEngine.Object.DestroyImmediate(mats[j]);
        }

        _stencilEntries[maskAndCore.entryIndex] = false;
        _maskGroups.Remove(baseEntity);
    }

    private struct MaskAndCore
    {
        public int entryIndex;
        public SkinnedMeshRenderer[] mask;
        public SkinnedMeshRenderer[] core;
        public SkinnedMeshRenderer[] other;
    }
}