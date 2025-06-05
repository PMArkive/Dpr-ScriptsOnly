using Dpr.Field.Walking;
using Dpr.SubContents;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.FureaiHiroba
{
    [Serializable]
    internal class PokeWalkerDebug
    {
        private WalkingCharacterModel _model;
        private Transform WalkStartArea;
        private Transform RunStartArea;
        private Transform TargetDistance;
        private bool isDebugDraw;
        private List<GameObject> goList = new List<GameObject>();
        [Button("", "なかよし度、性格による距離倍率補正", new object[0])]
        public int Button01;
        [SerializeField]
        private float PositionHosei;
        [SerializeField]
        private float WalkHosei;
        [SerializeField]
        private float RunHosei;

        private FureaiPokeModel model { get => _model as FureaiPokeModel; }

        public PokeWalkerDebug(WalkingCharacterModel model)
        {
            _model = model;
        }

        public void CreateTrackPoint()
        {
            if (WalkStartArea != null)
                WalkStartArea.SetActive(isDebugDraw);

            if (RunStartArea != null)
                RunStartArea.SetActive(isDebugDraw);

            if (TargetDistance != null)
                TargetDistance.SetActive(isDebugDraw);
        }

        public Vector3[] CreateDebugRoute(Transform target, Transform transform, Vector3[] route)
        {
            ClearRoute();

            if (isDebugDraw)
            {
                var parent = new GameObject("Route");
                goList.Add(parent);

                route?.ToList().ForEach(x =>
                {
                    var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.position = x + (Vector3.up * 0.3f);
                    cube.transform.localScale = Vector3.one * 0.3f;
                    cube.transform.SetParent(parent.transform);
                    goList.Add(cube);
                });
            }

            return route;
        }

        public void ClearRoute()
        {
            goList.ForEach(x => UnityEngine.Object.Destroy(x));
            goList.Clear();
        }

        public void CreateReactionArea()
        {
            var rnd = UnityEngine.Random.Range(0.0f, 0.01f);

            WalkStartArea = GameObject.CreatePrimitive(PrimitiveType.Cylinder).transform;
            WalkStartArea.transform.parent = model.transform;
            WalkStartArea.name = "WalkStartArea";
            WalkStartArea.localPosition = Vector3.zero + (Vector3.up * (rnd + 0.02f));

            RunStartArea = GameObject.CreatePrimitive(PrimitiveType.Cylinder).transform;
            RunStartArea.transform.parent = model.transform;
            RunStartArea.name = "RunStartArea";
            RunStartArea.localPosition = Vector3.zero + (Vector3.up * (rnd + 0.01f));

            TargetDistance = GameObject.CreatePrimitive(PrimitiveType.Cylinder).transform;
            TargetDistance.transform.parent = model.transform;
            TargetDistance.name = "TargetDistance";
            TargetDistance.localPosition = Vector3.zero + (Vector3.up * (rnd + 0.03f));

            var defaultGraphics = Graphic.defaultGraphicMaterial;

            var walkStartAreaRenderer = WalkStartArea.GetComponent<MeshRenderer>();
            walkStartAreaRenderer.material = defaultGraphics;
            walkStartAreaRenderer.material.color = new Color(0.0f, 0.0f, 1.0f, 0.2f);

            var runStartAreaRenderer = RunStartArea.GetComponent<MeshRenderer>();
            runStartAreaRenderer.material = defaultGraphics;
            runStartAreaRenderer.material.color = new Color(1.0f, 0.0f, 0.0f, 0.2f);

            var targetDistanceRenderer = TargetDistance.GetComponent<MeshRenderer>();
            targetDistanceRenderer.material = defaultGraphics;
            targetDistanceRenderer.material.color = new Color(1.0f, 1.0f, 1.0f, 0.2f);

            CreateTrackPoint();

            model.OnChangeState += () =>
            {
                if (model.nowState == typeof(PokeWalkingState))
                    SetActive(true);
                else
                    SetActive(false);
            };
        }

        public void Update()
        {
            if (WalkStartArea == null && model.walkData != null)
                CreateReactionArea();

            if (WalkStartArea == null)
                return;

            var scale = 1.0f / model.transform.localScale.x;

            var dist = model.walkData.GetAwayDistance();
            WalkStartArea.localScale = new Vector3(scale * (dist + dist), 0.01f, scale * (dist + dist));

            dist = model.walkData.GetFarDistance();
            RunStartArea.localScale = new Vector3(scale * (dist + dist), 0.01f, scale * (dist + dist));

            dist = model.walkData.targetDistance;
            TargetDistance.localScale = new Vector3(scale * (dist + dist), 0.01f, scale * (dist + dist));

            PositionHosei = model.walkData.PositionHosei;
            WalkHosei = model.walkData.walkHosei;
            RunHosei = model.walkData.runHosei;
        }

        public void SetActive(bool isActive)
        {
            isDebugDraw = isActive;
            CreateTrackPoint();
        }
    }
}