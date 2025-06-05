using Audio;
using Dpr.EvScript;
using Dpr.SubContents;
using SmartPoint.AssetAssistant;
using System;
using System.Collections;
using UnityEngine;

public static class TransitionAnimation
{
    public const int GAME_FPS = 30;
    public const float GURUGURU_HEIGHT_UNION = 10.0f;
    public const float GURUGURU_HEIGHT_OTHER = 20.0f;
    public static FieldCharacterEntity targetChara;

    public static void GuruguruRisingStart()
    {
        EvDataManager.Instanse._dummyPlayer.transform.position = targetChara.worldPosition;

        Sequencer.update += PlayerGuruguru;
        Sequencer.update += PlayerRising;
    }

    public static void GuruguruFallStart(FieldCharacterEntity targetEntity)
    {
        targetChara = targetEntity;

        float y = Utils.GetGuruGuruHeight(PlayerWork.zoneID);
        targetChara.worldPosition = new Vector3(targetChara.transform.position.x, y, targetChara.transform.position.z);
        EvDataManager.Instanse._dummyPlayer.transform.position = new Vector3(targetChara.transform.position.x, 0.0f, targetChara.transform.position.z);

        Sequencer.update += PlayerGuruguru;
        Sequencer.update += PlayerFall;
    }

    public static IEnumerator PlayerGuruguruStop(FieldCharacterEntity targetEntity, float angle, float height, bool isRising, Action OnComplete)
    {
        bool CheckHeight()
        {
            if (isRising)
                return height <= targetChara.worldPosition.y;
            else
                return targetChara.worldPosition.y <= height;
        }

        targetChara = targetEntity;

        bool isTargetHeight = false;

        while (!isTargetHeight)
        {
            if (CheckHeight())
            {
                isTargetHeight = true;

                Sequencer.update -= PlayerRising;
                Sequencer.update -= PlayerFall;
            }

            yield return null;
        }

        targetChara.worldPosition = new Vector3(targetChara.worldPosition.x, height, targetChara.worldPosition.z);

        angle += 360.0f;
        float angleMin = angle - 20.0f;
        float angleMax = angle + 20.0f;
        bool isTargetAngle = false;

        while (!isTargetAngle)
        {
            if (angleMin <= targetChara.yawAngle && targetChara.yawAngle <= angleMax)
            {
                isTargetAngle = true;
                Sequencer.update -= PlayerGuruguru;
            }

            yield return null;
        }

        targetChara.yawAngle = angle;

        PlayerWork.isPlayerInputActive = true;

        if (!isRising)
            GameManager.fieldCamera.Target = targetChara.transform;

        OnComplete?.Invoke();
    }

    // TODO
    public static IEnumerator EntityTransitionAnimationStop(FieldCharacterEntity targetEntity, float height, float angle, bool isRising, Action OnComplete, bool isGuruGuru = true)
    {
        bool CheckHeight()
        {
            if (isRising)
            {
                if (height < targetChara.worldPosition.y)
                    targetChara.worldPosition.y = height;

                return height <= targetChara.worldPosition.y;
            }
            else
            {
                if (targetChara.worldPosition.y < height)
                    targetChara.worldPosition.y = height;

                return targetChara.worldPosition.y <= height;
            }
        }



        return null;
    }

    public static IEnumerator AgEntityTransitionAnimationStop(FieldCharacterEntity targetEntity, float height, float angle, bool isRising, Action OnComplete, bool isGuruGuru = true)
    {
        bool CheckHeight()
        {
            if (isRising)
            {
                if (height < targetChara.worldPosition.y)
                    targetChara.worldPosition.y = height;

                return height <= targetChara.worldPosition.y;
            }
            else
            {
                if (targetChara.worldPosition.y < height)
                    targetChara.worldPosition.y = height;

                return targetChara.worldPosition.y <= height;
            }
        }

        targetChara = targetEntity;
        targetChara.isLanding = false;

        if (isGuruGuru)
            Sequencer.update += PlayerGuruguru;

        if (isRising)
            Sequencer.update += PlayerRising;

        int endFlame = 5;
        int animeFlame = 0;

        AudioManager.Instance.PlaySe(isRising ? AK.EVENTS.S_UND001_HYOTA : AK.EVENTS.S_UND001, null);

        FieldManager.Instance.UG_Hole.transform.localPosition = new Vector3(0.0f, 0.1f, 2.0f);
        FieldManager.Instance.UG_Hole.transform.localScale = Vector3.zero;
        FieldManager.Instance.UG_Hole.SetActive(true);
        FieldManager.Instance.UG_Hole.transform.SetLocalRotationEuler(new Vector3(0.0f, 0.0f, 0.0f));

        while (animeFlame < endFlame)
        {
            animeFlame++;
            float scale = Math.Min(FieldManager.Instance.UG_Hole.transform.localScale.x + Time.deltaTime * GAME_FPS, 2.0f);
            FieldManager.Instance.UG_Hole.transform.localScale = new Vector3(scale, scale, scale);

            yield return null;
        }

        if (!isRising)
        {
            yield return new WaitForSeconds(0.5f);
            Sequencer.update += PlayerFall;
        }

        animeFlame = 0;
        var animPlayer = targetChara.GetAnimationPlayer();

        bool isTargetHeight = false;
        bool playedJumpEnd = false;

        while (!isTargetHeight)
        {
            if (!isRising && !playedJumpEnd)
            {
                if (targetChara.worldPosition.y - height <= 0.5f)
                {
                    animPlayer.Play(FieldCharacterEntity.Animation.Squat, 0.2f);
                    playedJumpEnd = true;
                }
                else
                {
                    animPlayer.Play(FieldCharacterEntity.Animation.JumpLoop, 0.2f);
                }
            }

            if (CheckHeight())
            {
                isTargetHeight = true;
                Sequencer.update -= PlayerRising;
                Sequencer.update -= PlayerFall;
            }

            yield return null;
        }
        
        if (isGuruGuru)
        {
            angle += 360.0f;
            float angleMin = angle - 20.0f;
            float angleMax = angle + 20.0f;
            bool isTargetAngle = false;

            while (!isTargetAngle)
            {
                if (angleMin <= targetChara.yawAngle && targetChara.yawAngle <= angleMax)
                    isTargetAngle = true;

                yield return null;
            }

            targetChara.yawAngle = angle;
        }

        if (!isRising)
            yield return new WaitForSeconds(0.2f);

        animPlayer.Play(FieldCharacterEntity.Animation.Idle, 0.2f);
        targetChara.worldPosition = new Vector3(targetChara.worldPosition.x, height, targetChara.worldPosition.z);
        targetChara.isLanding = true;

        AudioManager.Instance.PlaySe(AK.EVENTS.S_UND002_HYOTA, null);

        while (animeFlame < endFlame)
        {
            animeFlame++;
            float scale = Math.Max(FieldManager.Instance.UG_Hole.transform.localScale.x + Time.deltaTime * -20.0f, 0.0f);
            FieldManager.Instance.UG_Hole.transform.localScale = new Vector3(scale, scale, scale);

            yield return null;
        }

        FieldManager.Instance.UG_Hole.transform.SetLocalRotationEuler(new Vector3(0.0f, 0.0f, 0.0f));
        FieldManager.Instance.UG_Hole.transform.SetLocalPosition(new Vector3(0.0f, 0.1f, 0.0f));
        FieldManager.Instance.UG_Hole.SetActive(false);

        PlayerWork.isPlayerInputActive = true;
        GameManager.fieldCamera.Target = EntityManager.activeFieldPlayer.transform;

        OnComplete?.Invoke();
    }

    public static void PlayerGuruguru(float deltaTime)
    {
        targetChara.yawAngle += deltaTime * 1050.0f;
        targetChara.GetAnimationPlayer().Play(FieldCharacterEntity.Animation.Idle);
    }

    public static void PlayerRising(float deltaTime)
    {
        targetChara.isLanding = false;
        targetChara.worldPosition = new Vector3(targetChara.worldPosition.x, targetChara.worldPosition.y + deltaTime * 8.0f, targetChara.worldPosition.z);
    }

    public static void PlayerFall(float deltaTime)
    {
        targetChara.worldPosition = new Vector3(targetChara.worldPosition.x, targetChara.worldPosition.y - deltaTime * 8.0f, targetChara.worldPosition.z);
    }

    public static float GetGuruGuruHeight(ZoneID zoneID)
    {
        return zoneID == ZoneID.UNION01 ? GURUGURU_HEIGHT_UNION : GURUGURU_HEIGHT_OTHER;
    }
}