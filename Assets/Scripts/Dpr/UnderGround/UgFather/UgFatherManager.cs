using SmartPoint.AssetAssistant;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Dpr.UnderGround.UgFather
{
    public class UgFatherManager : SingletonMonoBehaviour<UgFatherManager>
    {
        private List<string> TypeId = new List<string>()
        {
            "TREASURE", "HEALING", "GOODS_S", "GOODS_L",
        };
        private const string UgFatherId = "FATHER";
        private List<UgFatherBase> fathers = new List<UgFatherBase>();
        private UgFatherBase currentFather;

        private IEnumerator Start()
        {
            Sequencer.update += InputUpdate;
            FieldManager.Instance.OnZoneChangeEvent += Setup;

            yield return null;
        }

        private void OnDestroy()
        {
            Sequencer.update -= InputUpdate;
            FieldManager.Instance.OnZoneChangeEvent -= Setup;

            Clear();
        }

        private void InputUpdate(float deltaTime)
        {
            if (currentFather != null)
            {
                currentFather.OnUpdate(deltaTime);
            }
            else
            {
                if (UgFatherInput.Talk)
                {
                    currentFather = GetContactFather();
                    if (currentFather != null)
                    {
                        currentFather.OnTalkEvent();
                        EntityManager.activeFieldPlayer.PlayIdle();
                        PlayerWork.isPlayerInputActive = false;
                    }
                }
            }
        }

        private UgFatherBase GetContactFather()
        {
            foreach (var father in fathers)
            {
                if (!father.gameObject.activeInHierarchy)
                    continue;

                var diff = EntityManager.activeFieldPlayer.worldPosition - father.FieldCharacterEntity.worldPosition;

                // Check height (weird conditions here)
                if (diff.y < -1.0f || (!float.IsNaN(diff.y) && diff.y > 1.0f))
                    continue;

                // Check if less than 1 tile distance (weird conditions here again)
                diff.y = 0.0f;
                var distSq = diff.sqrMagnitude;
                if (distSq >= 1e-05f)
                {
                    var dist = (float)Math.Sqrt(distSq);
                    if (dist < 1.0f)
                        return father;

                    continue;
                }
                else
                {
                    return father;
                }
            }

            return null;
        }

        private void Setup()
        {
            StartCoroutine(DelaySetup());
        }

        private IEnumerator DelaySetup()
        {
            yield return null;
        }

        private void OnEventEnd()
        {
            PlayerWork.isPlayerInputActive = true;
            currentFather = null;
        }

        public void Clear()
        {
            fathers.Clear();
        }

        private enum Type : int
        {
            Treasure = 0,
            Healing = 1,
            Goods_S = 2,
            Goods_L = 3,
        }
    }
}