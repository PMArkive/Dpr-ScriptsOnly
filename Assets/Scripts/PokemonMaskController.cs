using System;
using System.Collections.Generic;
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

    // TODO
    public static void Register(BaseEntity baseEntity) { }

    // TODO
    public static void Unregister(BaseEntity baseEntity) { }

    private struct MaskAndCore
    {
        public int entryIndex;
        public SkinnedMeshRenderer[] mask;
        public SkinnedMeshRenderer[] core;
        public SkinnedMeshRenderer[] other;
    }
}