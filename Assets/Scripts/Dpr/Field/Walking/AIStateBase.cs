using SmartPoint.AssetAssistant;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Dpr.Field.Walking
{
    public abstract class AIStateBase
    {
        public static float Speed = 1.0f;
        private Transform _lookTarget;
        protected AIModel model;
        private List<ActionModel> ActionList = new List<ActionModel>();
        protected ActionModel nowAction;
        protected float downTime;
        protected float ActionProbability = DefaultProbability;
        public float ActionLotteryInterval = DefaultInterval;
        protected const float DefaultInterval = 2.0f;
        protected const float DefaultProbability = 0.05f;
        private List<ActionModel> list = new List<ActionModel>(10);

        public Transform LookTarget
        {
            get
            {
                if (_lookTarget != null)
                    return _lookTarget;

                return model.player;
            }
            set
            {
                _lookTarget = value;
            }
        }
        public CorSystem corSys { get => model.corSys; }
        protected bool isCanAction { get => corSys.isPlaying && downTime <= 0.0f; }
        protected float playerDistance { get => model.playerDistance; }
        protected Transform player { get => EntityManager.activeFieldPlayer.transform; }
        protected float deltaTime { get => Sequencer.elapsedTime; }

        public AIStateBase(AIModel model)
        {
            this.model = model;
        }

        public virtual void Enter()
        {
            // Empty
        }

        public virtual void Exit()
        {
            // Empty
        }

        public virtual void CommonUpdate()
        {
            list.Clear();

            if (ActionLotteryInterval < 0.0f && UnityEngine.Random.Range(0.0f, 0.999f) < ActionProbability)
            {
                for (int i=0; i<ActionList.Count; i++)
                {
                    if (ActionList[i].lotteryType == ActionModel.Lottery_Normal && ActionList[i].IsUsable())
                        list.Add(ActionList[i]);
                }
            }

            for (int i=0; i<ActionList.Count; i++)
            {
                if (ActionList[i].lotteryType == ActionModel.Lottery_Force && ActionList[i].IsUsable())
                    list.Add(ActionList[i]);
            }

            if (list.Count == 0)
            {
                if (!corSys.isPlaying)
                {
                    ActionLotteryInterval -= deltaTime;
                    downTime -= deltaTime;
                    StateUpdate();
                }
            }
            else
            {
                if (nowAction != null)
                    list = list.FindAll(x => nowAction.priority < x.priority);

                var action = list.GetRandomofMaxpriority();
                if (action != null)
                    Play(action, null);
            }
        }

        protected abstract void StateUpdate();

        public void Play(ActionModel action, [Optional] Action OnFinished)
        {
            corSys.Cancel();
            corSys.Play(action.DoAction(model));
            corSys.OnFinished(() =>
            {
                downTime = action.downTime;
                nowAction = null;
                OnFinished?.Invoke();
            });

            nowAction = action;
        }

        public void PlayAnim(int animID, [Optional] Action OnFinished)
        {
            Play(new PlayAnim(animID), OnFinished);
        }

        protected ActionModel AddAction(ActionModel action)
        {
            ActionList.Add(action);

            if (action.lotteryType == ActionModel.Lottery_Normal)
                action.usables += () => isCanAction;

            return action;
        }

        public void Destroy()
        {
            ActionList.Clear();
            ActionList = null;

            list.Clear();
            list = null;
        }

        public void Cancel()
        {
            corSys?.Cancel();
        }
    }
}