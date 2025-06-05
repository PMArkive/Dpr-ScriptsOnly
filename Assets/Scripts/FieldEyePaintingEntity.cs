using Audio;
using UnityEngine;

public class FieldEyePaintingEntity : FieldEventEntity
{
    public EyePaintingType EyePainting;
    public GameObject Painting;
    public EyePaintingType DefaultEyePainting;
    private EyePaintingType CurrentEyePainting;

    protected override void Awake()
    {
        base.Awake();
        isLanding = false;
        SetActivePaint(DefaultEyePainting);
    }

    public void ChangeEyePainting()
    {
        for (int i=0; i<EntityManager.fieldEyePainting.Length; i++)
            EntityManager.fieldEyePainting[i].SetActivePaint(EyePainting);
    }

    public void SetActivePaint(EyePaintingType type)
    {
        if (CurrentEyePainting == type)
            return;

        var previousPainting = CurrentEyePainting;
        CurrentEyePainting = type;

        if (Painting != null)
        {
            Painting.SetActive(EyePainting == type);

            if (previousPainting == EyePaintingType.NONE && CurrentEyePainting == EyePaintingType.NONE)
                AudioManager.Instance.PlaySe(AK.EVENTS.S_FI245, null);
        }
    }

    public enum EyePaintingType : int
    {
        NONE = 0,
        FRONT = 1,
        LEFT = 2,
        RIGHT = 3,
    }
}