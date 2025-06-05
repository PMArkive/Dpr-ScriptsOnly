using Dpr.Battle.View;
using Dpr.EvScript;
using UnityEngine;

public sealed class BattlePlayerEntity : BattleCharacterEntity
{
    [SerializeField]
    private Renderer _watchRenderer;
    [SerializeField]
    private Renderer[] _hatRenderers;
    [SerializeField]
    private Renderer[] _shoesRenderers;
    public int HatVariationParam = -1;
    public int ShoesVariationParam = -1;
    private bool isCaputureDemo;

    public ColorVariation ColorVariation { get => this.GetComponentThis(ref _colorVariation); }
    public override string entityType { get => "BattlePlayer"; }
    public bool watchVisibility
    {
        get => _watchRenderer == null || _watchRenderer.enabled;
        set { if (_watchRenderer != null) _watchRenderer.enabled = value; }
    }
    public int HatVariation
    {
        get
        {
            if (_hatRenderers.IsNullOrEmpty())
                return -1;

            for (int i=0; i<_hatRenderers.Length; i++)
            {
                if (_hatRenderers[i] != null && _hatRenderers[i].enabled)
                    return i;
            }

            return -1;
        }
        set
        {
            if (_hatRenderers.IsNullOrEmpty())
                return;

            for (int i=0; i<_hatRenderers.Length; i++)
            {
                if (_hatRenderers[i] != null)
                    _hatRenderers[i].enabled = value == i;
            }
        }
    }
    public int ShoesVariation
    {
        get
        {
            if (_shoesRenderers.IsNullOrEmpty())
                return -1;

            for (int i=0; i<_shoesRenderers.Length; i++)
            {
                if (_shoesRenderers[i] != null && _shoesRenderers[i].enabled)
                    return i;
            }

            return -1;
        }
        set
        {
            if (_shoesRenderers.IsNullOrEmpty())
                return;

            for (int i=0; i<_shoesRenderers.Length; i++)
            {
                if (_shoesRenderers[i] != null)
                    _shoesRenderers[i].enabled = value == i;
            }
        }
    }

    public override void Initialize(TrainerSimpleParam param, bool isContest = false)
    {
        base.Initialize(param);
        HatVariation = param.hatVariation;
        HatVariationParam = param.hatVariation;
        ShoesVariation = param.shoesVariation;
        ShoesVariationParam = param.shoesVariation;
    }

    public override void SetCaputureDemo()
    {
        isCaputureDemo = true;

        if (_watchRenderer == null)
            return;

        _watchRenderer.enabled = true;
    }

    public override void SetRenderActive(bool isActive)
    {
        for (int i=0; i<_renderers.Length; i++)
            _renderers[i].enabled = isActive;

        if (!isActive)
            return;

        HatVariation = HatVariationParam;
        ShoesVariation = ShoesVariationParam;

        if (isCaputureDemo)
        {
            if (_watchRenderer == null)
                return;

            _watchRenderer.enabled = true;
        }
        else
        {
            if (_watchRenderer == null)
                return;

            _watchRenderer.enabled = FlagWork.GetFlag(EvWork.FLAG_INDEX.FE_POKETCH_GET);
        }
    }

    protected override void Awake()
    {
        base.Awake();

        if (_watchRenderer == null)
            return;

        _watchRenderer.enabled = FlagWork.GetFlag(EvWork.FLAG_INDEX.FE_POKETCH_GET);
    }
}