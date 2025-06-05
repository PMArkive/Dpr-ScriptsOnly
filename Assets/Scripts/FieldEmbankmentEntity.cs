using Audio;
using Dpr.EvScript;
using UnityEngine;

public class FieldEmbankmentEntity : FieldEventEntity
{
    [SerializeField]
    private EmbankmentType embankmentType;
    private FieldCharacterEntity character;
    private bool isCharacterOut;
    private bool isPlayingAnimeOut;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnUpdate(float deltaTime)
    {
        base.OnUpdate(deltaTime);
        UpdateEmbankment();
    }

    public void UpdateEmbankment()
    {
        if (character == null)
        {
            for (int i=0; i<EntityManager.fieldCharacters.Length; i++)
            {
                if (EntityManager.fieldCharacters[i] != null)
                {
                    if (EntityManager.fieldCharacters[i].transform.position == transform.position)
                        character = EntityManager.fieldCharacters[i];
                }
            }
        }

        if (character == null)
            return;

        if (isCharacterOut)
        {
            if (transform.localScale != Vector3.zero)
                SetCharacterActive(true);

            if (isPlayingAnimeOut)
            {
                if (!character.GetAnimationPlayer().IsPlayingEnd)
                    return;

                isPlayingAnimeOut = false;
                character.GetAnimationPlayer().forcePlay = false;
                character.GetAnimationPlayer().Play(FieldCharacterEntity.Animation.Idle);

                PlayerWork.isPlayerInputActive = true;
                if (!TrainerWork.GetWinFlag(character.EventParams.TrainerID))
                    EvDataManager.Instanse.ForceEyeEncount(character.EventParams.TrainerID);
            }

            gameObject.SetActive(false);
        }
        else
        {
            if (character.gameObject.activeSelf)
                SetCharacterActive(false);
        }
    }

    public bool CharacterOut(bool encount)
    {
        if (isCharacterOut)
            return false;

        if (character == null)
            return false;

        if (TrainerWork.GetWinFlag(character.EventParams.TrainerID))
            return false;

        isCharacterOut = true;
        SetCharacterActive(true);

        character.yawAngle = Quaternion.LookRotation(EntityManager.activeFieldPlayer.transform.position - character.gameObject.transform.position).eulerAngles.y;

        switch (embankmentType)
        {
            case EmbankmentType.GROUND:
                FieldManager.Instance.CallEffect(EffectFieldID.EF_F_CHARA_OUT_GROUND, transform, null, null);
                break;

            case EmbankmentType.SNOW:
                FieldManager.Instance.CallEffect(EffectFieldID.EF_F_CHARA_OUT_SNOW, transform, null, null);
                break;

            case EmbankmentType.SAND:
                FieldManager.Instance.CallEffect(EffectFieldID.EF_F_CHARA_OUT_SAND, transform, null, null);
                break;
        }

        AudioManager.Instance.PlaySe(AK.EVENTS.S_FI243, null);
        isPlayingAnimeOut = true;

        character.GetAnimationPlayer().Play(19);
        character.GetAnimationPlayer().forcePlay = true;

        PlayerWork.isPlayerInputActive = false;
        EntityManager.activeFieldPlayer.PlayIdle();

        return true;
    }

    private void SetCharacterActive(bool isActive)
    {
        if (!character)
            return;

        if (isActive)
            transform.localScale = Vector3.zero;
        else
            transform.localScale = Vector3.one;

        character.gameObject.SetActive(isActive);
    }

    public enum EmbankmentType : int
    {
        NONE = 0,
        GROUND = 1,
        SNOW = 2,
        SAND = 3,
        KUSA = 4,
    }
}