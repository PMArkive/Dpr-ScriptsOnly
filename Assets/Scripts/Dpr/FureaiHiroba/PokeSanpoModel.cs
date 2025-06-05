using System;
using System.Collections.Generic;
using UnityEngine;
using XLSXContent;

namespace Dpr.FureaiHiroba
{
    [Serializable]
    public sealed class PokeSanpoModel
    {
        public bool isLookPlayer;
        public bool isAddWalking;
        public float CollidedRotValue;
        private float LookPlayerDistance = 3.0f;
        private float WalkingAddDistance = 1.5f;
        public int PositionNo;
        public Vector3 InitPos;
        public Vector3 RandomOffsetPos;
        public bool isPairEnd;

        public bool isPairMode { get => PairModel != null; }
        public bool isPairPosition { get => PositionNo > 9; }
        public PokeSanpoPairModel PairModel { get; set; }
        public Vector3 defaultDirection { get; set; }
        public PokeSanpoActionModel actionModel { get; set; }

        private static List<Vector3> AngleToDirection = new List<Vector3>()
        {
            Vector3.back, Vector3.left, Vector3.forward, Vector3.right,
        };

        public void CreateActionModel(float bodySize, FreeSanpoActionProbability.SheetSheet1 ActionProbability, int nakayoshiRank)
        {
            LookPlayerDistance = nakayoshiRank * 0.6f + bodySize + 2.0f;
            WalkingAddDistance = bodySize + 1.5f;
            actionModel = new PokeSanpoActionModel(ActionProbability);
        }

        public void Update(float deltaTime, Transform Player, Transform transform)
        {
            var dist = Vector3.Distance(Player.position, transform.position);

            isLookPlayer = LookPlayerDistance > dist || (isLookPlayer && (dist < LookPlayerDistance + 1.0f));
            isAddWalking = dist < WalkingAddDistance;

            if (UnityEngine.Random.Range(0, 30) == 0)
                RandomOffsetPos = (Vector3.right * UnityEngine.Random.Range(-3, 3)) + (Vector3.forward * UnityEngine.Random.Range(-3, 3));
        }

        public void SetDefaultDirection(int Angle)
        {
            defaultDirection = AngleToDirection[Mathf.Abs(Angle / 90)];
        }

        public void SetPair(bool isMaster, FureaiPokeModel masterPoke, FureaiPokeModel slavePoke)
        {
            PairModel = new PokeSanpoPairModel(isMaster, masterPoke, slavePoke);
        }

        public void DeletePair()
        {
            if (PairModel == null)
                return;

            PairModel.pair.sanpoModel.PairModel = null;
            PairModel.pair.sanpoModel.isPairEnd = true;
            Destroy();
            isPairEnd = true;
        }

        public void Destroy()
        {
            PairModel?.Destroy();
            PairModel = null;
            actionModel?.Destroy();
        }
    }
}