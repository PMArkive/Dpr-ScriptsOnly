using Dpr.UI;
using UnityEngine;
using UnityEngine.UI;

public class FieldPokemonCenterMonitorEntity : FieldEventEntity
{
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private PokemonIcon[] pokemonIcons;
    [SerializeField]
    private float defaultScale = 1.4f;
    [SerializeField]
    private float animationScale = 1.6f;
    private Image[] pokemonImages;
    private int currentDisplayIndex = -1;
    private float animationTime;
    private float progressTime;
    private bool isPlayingHealAnimation;

    protected override void Awake()
    {
        base.Awake();
        isLanding = false;

        if (canvas != null && canvas.worldCamera == null && GameManager.fieldCamera != null)
        {
            var cam = GameManager.fieldCamera.GetComponent<Camera>();
            if (cam != null)
            {
                canvas.worldCamera = cam;
                canvas.planeDistance = 0.0f;
            }
        }

        pokemonImages = new Image[pokemonIcons.Length];

        for (int i=0; i<pokemonIcons.Length; i++)
        {
            var img = pokemonIcons[i].GetComponent<Image>();
            if (img != null)
                pokemonImages[i] = img;
        }

        DestroyAllIcons();
    }

    protected override void OnUpdate(float deltaTime)
    {
        base.OnUpdate(deltaTime);

        if (currentDisplayIndex > -1)
        {
            progressTime += deltaTime;
            SetScale(currentDisplayIndex, Mathf.Lerp(animationScale, defaultScale, progressTime / animationTime));
            if (progressTime / animationTime >= 1.0f)
                currentDisplayIndex = -1;
        }

        if (!isPlayingHealAnimation)
            return;

        progressTime += deltaTime;

        float time = progressTime / animationTime;
        float scale = defaultScale;

        if (time >= 0.5f)
        {
            if (time >= 1.0f)
                isPlayingHealAnimation = false;
            else
                scale = Mathf.Lerp(animationScale, defaultScale, time - 0.5f + time - 0.5f);
        }
        else
        {
            scale = Mathf.Lerp(defaultScale, animationScale, time + time);
        }

        for (int i=0; i<pokemonImages.Length; i++)
            SetScale(i, scale);
    }

    public void DisplayIcon(int index, int pokemonIndex)
    {
        canvas.gameObject.SetActive(true);
        DestroyIcon(index);

        if (pokemonIndex < PlayerWork.playerParty.GetMemberCount() && index < pokemonIcons.Length)
        {
            pokemonIcons[index].Load(PlayerWork.playerParty.GetMemberPointer((uint)pokemonIndex));
            pokemonIcons[index].gameObject.SetActive(true);
            SetScale(index, animationScale);
            currentDisplayIndex = index;
            animationTime = 0.1f;
            progressTime = 0.0f;
        }
    }

    public void PlayHealAnimation()
    {
        for (int i=0; i<pokemonImages.Length; i++)
            SetScale(i, defaultScale);

        currentDisplayIndex = -1;
        animationTime = 0.3f;
        progressTime = 0.0f;
        isPlayingHealAnimation = true;
    }

    public void DestroyAllIcons()
    {
        canvas.gameObject.SetActive(false);
        for (int i=0; i<pokemonIcons.Length; i++)
            DestroyIcon(i);
    }

    private void DestroyIcon(int index)
    {
        pokemonImages[index].gameObject.SetActive(false);
        pokemonImages[index].sprite = null;
        SetScale(index, defaultScale);
    }

    private void SetScale(int index, float scale)
    {
        pokemonImages[index].rectTransform.SetLocalScaleX(scale);
        pokemonImages[index].rectTransform.SetLocalScaleY(scale);
        pokemonImages[index].rectTransform.SetLocalScaleZ(scale);
    }
}