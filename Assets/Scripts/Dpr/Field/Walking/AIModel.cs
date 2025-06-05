using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.Field.Walking
{
    public class AIModel
    {
        public WalkingCharacterModel charaModel;
        public WalkingCharacterView view;
        public Transform transform;
        public CorSystem corSys = new CorSystem();
        private GetAI _GetAI;

        public List<Vector3> route { get => charaModel.route; }
        public WalkData walkData { get => charaModel.walkData; }
        public Transform player { get => EntityManager.activeFieldPlayer.transform; }
        public float playerDistance { get => Vector3.Distance(player.position, transform.position); }
        public AI AI { get => _GetAI.Invoke(); }

        public AIModel(WalkingCharacterController controller)
        {
            charaModel = controller.model;
            view = controller.view;
            transform = controller.transform;
            _GetAI = () => controller.AI;
        }

        public virtual void Destroy()
        {
            charaModel = null;
            view = null;
            transform = null;

            corSys.Destroy();

            corSys = null;
            _GetAI = null;
        }

        public IEnumerator Loop(EndCheck EndCheck, Action action)
        {
            while (EndCheck.Invoke() && !charaModel.isDestroyed)
            {
                action.Invoke();
                yield return new WaitForEndOfFrame();
            }
        }

        public delegate bool EndCheck();
        public delegate AI GetAI();
    }
}